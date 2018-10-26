using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Converter;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Boleto;
using EntidadesGDS.FormaPago;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_eTicketCouponLLS_200;

namespace SabreLib.lItinerary
{
    public sealed class TicketCoupon : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="sesion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public TicketCoupon(EnumAplicaciones application,
                            CE_Session sesion,
                            string codigoSeguimiento,
                            bool muteErrors = true)
            : base(WebServiceAction.TicketCoupon, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketCoupon()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cupones"></param>
        /// <returns></returns>
        private CE_Segmento[] ProcessFlightSegment(eTicketCouponRSTicketingInfosTicketingInfoTicketingCouponData cupones)
        {
            return cupones.Coupons
                .Select(c =>
                {
                    var ldepartureDateTime = DateStringSabre.ToValidDate(c.FlightSegment.DepartureDateTime, true);

                    return new CE_Segmento
                    {
                        Aerolinea = new CE_Aerolinea { CodigoAerolinea = c.FlightSegment.MarketingAirline.Code },
                        NumeroVuelo = c.FlightSegment.FlightNumber,
                        ClaseReserva = c.FlightSegment.ResBookDesigCode,
                        FechaSalida = DateStringSabre.ToValidStringDateGds(ldepartureDateTime.Value),
                        HoraSalida = DateStringSabre.ToValidStringTimeGds(ldepartureDateTime.Value),
                        CiudadSalida = new CE_Ciudad { CodigoCiudadSegmento = c.FlightSegment.OriginLocation.LocationCode },
                        CiudadLlegada = new CE_Ciudad { CodigoCiudadSegmento = c.FlightSegment.DestinationLocation.LocationCode },
                        Status = c.StatusCode
                    };
                }).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cupones"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        private void UpdateTicket(eTicketCouponRSTicketingInfosTicketingInfoTicketingCouponData cupones,
                                  CE_Boleto boleto)
        {
            if (!string.IsNullOrWhiteSpace(cupones.ConjunctiveTicketNumbers))
            {
                // buscando el número final del boleto en conjunción
                var lgrupos = Regex.Match(cupones.ConjunctiveTicketNumbers, Configuracion.GetRegularExpression("ConjunctiveTicketNumbers"));

                boleto.EnConjuncion = Extension.ConvertOrDefault<int?>(lgrupos.Groups[1].Value);
            }

            boleto.CuponesUsados = cupones.Coupons.Length;
            boleto.Reemision = cupones.Coupons.Any(c => string.Format("{0}", c.StatusCode).Equals("EXCH", StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cupones"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        private CE_Cotizacion ProcessFareBasis(eTicketCouponRSTicketingInfosTicketingInfoTicketingCouponData cupones,
                                               string numeroBoleto, 
                                               string pseudo)
        {
            var ltarifa = new CE_Tarifa
            {
                TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = cupones.AirItineraryPricingInfo.PassengerTypeQuantity.Code },
                Neto = Extension.ConvertOrDefault<decimal?>(cupones.AirItineraryPricingInfo.ItinTotalFare.BaseFare.Amount),
                Total = Extension.ConvertOrDefault<decimal?>(cupones.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount),
                Impuestos = cupones.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax.Select(t => 
                    new CE_Impuesto
                    {
                        CodigoImpuesto = t.TaxCode,
                        Importe = decimal.Parse(t.Amount)
                    }).ToArray(),
                BaseTarifaria = cupones.Coupons.Select(c => 
                    new CE_BaseTarifaria
                    {
                        NumeroSegmento = int.Parse(c.FlightSegment.RPH),
                        BaseTarifaria = c.FlightSegment.FareBasis.Code
                    }).ToArray()
            };

            return new CE_Cotizacion
            {
                Seleccionada = true,
                TipoTarifa = new CE_TipoTarifa
                {
                    Codigo = (Advanced.In(cupones.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount, "BT", "IT") ? EnumCodigoTarifa.PV : EnumCodigoTarifa.PL),
                    Tipo = (Advanced.In(cupones.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount, "BT", "IT") ? EnumTipoTarifa.IT : EnumTipoTarifa.FV)
                },
                LineasValidadoras = new []
                {
                    new CE_Aerolinea { IdPrefijo = numeroBoleto.Substring(0, 3) } 
                },
                //CiudadDestino = 
                TotalCotizacion = ltarifa.Total,
                Pseudo = pseudo,
                Tarifas = new []{ ltarifa }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cupones"></param>
        /// <returns></returns>
        private CE_Pasajero ProcessPassenger(eTicketCouponRSTicketingInfosTicketingInfoTicketingCouponData cupones)
        {
            EnumTipoDocumento? ltipoDocumento = null;
            string lnumeroDocumento = null;
            string lruc = null;

            if (!string.IsNullOrWhiteSpace(cupones.CustomerInfo.Customer.PersonName.NameReference))
            {
                // buscando ruc o datos de identificación
                var lexpresion = Regex.Match(cupones.CustomerInfo.Customer.PersonName.NameReference, Configuracion.GetRegularExpression("NameReference"));

                // evaluando si se encontro un ruc
                if (lexpresion.Groups[1].Value.Equals("RUC", StringComparison.InvariantCultureIgnoreCase))
                {
                    lruc = lexpresion.Groups[2].Value;

                }
                else
                {
                    ltipoDocumento = ProcessPassengerDocumentType(lexpresion.Groups[1].Value);
                    lnumeroDocumento = lexpresion.Groups[2].Value;
                }
            }

            return new CE_Pasajero
            {
                Nombre = cupones.CustomerInfo.Customer.PersonName.GivenName,
                Apellido = cupones.CustomerInfo.Customer.PersonName.Surname,
                TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = cupones.CustomerInfo.Customer.PersonName.PassengerType },
                TipoDocumento = ltipoDocumento,
                NumeroDocumento = lnumeroDocumento,
                RUC = lruc 
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagos"></param>
        /// <returns></returns>
        private CE_FormaPago[] ProcessPayments(eTicketCouponRSTicketingInfosTicketingInfoTicketingCouponDataCustomerInfoCustomerPayment[] pagos)
        {
            var lresult = new List<CE_FormaPago>();

            // "CA"
            var lcash = pagos.FirstOrDefault(p => p.Type.ToString().Equals("CA", StringComparison.InvariantCultureIgnoreCase));

            if (lcash != null)
            {
                lresult.Add(new CE_FormaPago
                {
                    TipoFormaPago = EnumTipoFormaPago.CASH,
                    Medio = ProcessPaymentForm(lcash.Text),
                });
            }

            // "CC"
            var lcrediCards = pagos.Where(p => p.Type.ToString().Equals("CC", StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (lcrediCards.Any())
            {
                lresult.AddRange(lcrediCards.Select(lcc => new CE_FormaPago
                {
                    TipoFormaPago = EnumTipoFormaPago.CARD,
                    Medio = ProcessPaymentForm(lcc.CC_Info.PaymentCard.Code),
                    Tarjeta = new CE_Tarjeta
                    {
                         Numero = lcc.ReferenceNumber,
                         FechaVencimiento = lcc.CC_Info.PaymentCard.ExpirationDate,
                         CodigoAprobacion = lcc.ApprovalID
                    },
                    MontoPago = Extension.ConvertOrDefault<decimal?>(lcc.CC_Info.PaymentCard.Amount),
                }));
            }

            return lresult.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cupones"></param>
        /// <returns></returns>
        private string ProcessCoupons(eTicketCouponRSTicketingInfosTicketingInfoTicketingCouponData cupones)
        {
            return (cupones.Coupons.Any(c => (!c.CodedStatus.Equals("VOID", StringComparison.InvariantCultureIgnoreCase))) ? "ACTIVO" : "VOID");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="estatus"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        private void ProcessResult(eTicketCouponRS response,
                                   string numeroBoleto,
                                   out CE_Estatus estatus,
                                   out CE_Boleto boleto)
        {
            estatus = new CE_Estatus();
            boleto = null;

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".eTicketCouponRQ return eTicketCouponRS null");

                return;
            }

            if ((response.ApplicationResults.Error != null) && (response.ApplicationResults.Error.Any()))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarErrores(
                    response.ApplicationResults.Error
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );

                return;
            }

            if ((response.ApplicationResults.Warning != null) && (response.ApplicationResults.Warning.Any()))
            {
                // actualizando respuesta (warnings)
                estatus.RegistrarAlertas(
                    response.ApplicationResults.Warning
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );
            }

            if (response.ApplicationResults.status == CompletionCodes.Complete)
            {
                // actualizando respuesta
                estatus.Ok = true;

                // contruyendo boleto base
                boleto = new CE_Boleto
                {
                    NumeroBoleto = numeroBoleto,
                    Pseudo = response.TicketingInfos.TicketingInfo.Ticketing.PseudoCityCode,
                    Iata = response.TicketingInfos.TicketingInfo.Ticketing.IATA_Number,
                    Segmentos = ProcessFlightSegment(response.TicketingInfos.TicketingInfo.Ticketing.CouponData),
                    Estatus = ProcessCoupons(response.TicketingInfos.TicketingInfo.Ticketing.CouponData)
                };

                // actualizando boleto
                UpdateTicket(response.TicketingInfos.TicketingInfo.Ticketing.CouponData, boleto);

                // construyendo cotizacion
                boleto.Cotizacion = ProcessFareBasis(response.TicketingInfos.TicketingInfo.Ticketing.CouponData, numeroBoleto, boleto.Pseudo);

                // construyendo pasajero
                boleto.Pasajero = ProcessPassenger(response.TicketingInfos.TicketingInfo.Ticketing.CouponData);

                // construyendo pagos
                boleto.Pagos = ProcessPayments(response.TicketingInfos.TicketingInfo.Ticketing.CouponData.CustomerInfo.Customer.Payment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        public CE_Estatus Execute(string numeroBoleto,
                                  out CE_Boleto boleto)
        {
            eTicketCouponRQRequest leTicketCouponRQRequest = null;
            eTicketCouponRQResponse leTicketCouponRQResponse = null;

            var lrespuesta = new CE_Estatus();

            boleto = null;

            try
            {
                // construyendo request
                leTicketCouponRQRequest = new eTicketCouponRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    eTicketCouponRQ = new eTicketCouponRQ
                    {
                        TimeStamp = DateTime.Now,
                        Version = WebServiceFileValueSabre.Version,
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStampSpecified = true,
                        Ticketing = new eTicketCouponRQTicketing
                        {
                            eTicketNumber = numeroBoleto
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<eTicketCouponPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'eTicketCouponPortTypeChannel.TravelItineraryReadRQ'", new { leTicketCouponRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    leTicketCouponRQResponse = lservicio.eTicketCouponRQ(leTicketCouponRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'eTicketCouponPortTypeChannel.TravelItineraryReadRQ'", new { leTicketCouponRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(leTicketCouponRQResponse.eTicketCouponRS, numeroBoleto, out lrespuesta, out boleto);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, numeroBoleto, boleto, leTicketCouponRQRequest, leTicketCouponRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                boleto = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
