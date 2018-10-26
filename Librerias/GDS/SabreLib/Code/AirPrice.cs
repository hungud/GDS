using System;
using System.Text.RegularExpressions;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_AirPriceLLS_216;

namespace SabreLib
{
    public sealed class AirPrice : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// Se debe tomar en cuenta que antes de ejecutar el servicos para cotizar una reemisión 
        /// se debe enviar el pasajero y los segmentos que se desea reemitir
        /// 
        /// <param name="application"></param>
        /// <param name="sesion">Token que va a utilizar el servico</param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        /// </summary>
        public AirPrice(EnumAplicaciones application,
                        CE_Session sesion,
                        string codigoSeguimiento,
                        bool muteErrors = true)
            : base(WebServiceAction.AirPrice, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~AirPrice()
        {
            Dispose(false);
        }

        #endregion

        // =============================

        // metodos

        #region "metodos"

        #region "Validate"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        private void ValidatePreExecute(RQ_ObtenerCotizaciones parametros)
        {
            // evaluando si no indicado para que esta detinada esta la cotización
            if (!parametros.Reemision.HasValue)
            {
                // forzando excepción
                throw new InternalException("No ha indicado para que esta destinada la Cotización (Emisión o Reemisión).");
            }

            // evaluando si se esta intentando actualizar los nombres o apellidos de los pasajeros
            if (((parametros.Segmentos == null) || (!parametros.Segmentos.Any(s => (s.Seleccionado ?? false))))
                || (parametros.Pasajeros == null) || (!parametros.Pasajeros.Any(p => (p.Seleccionado ?? false))))
            {
                // forzando excepción
                throw new InternalException("No ha seleccionado Segmentos y/o Pasajeros.");
            }

            if (parametros.Reemision.Value)
            {
                if (parametros.Pasajeros.Count(p => (p.Seleccionado ?? false)) != 1)
                {
                    // forzando excepción
                    throw new InternalException("Solo puede cotizar un (1) pasajero para una Reemisión.");
                }
            }
        }

        #endregion

        #region "Prepare"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segmentos"></param>
        /// <returns></returns>
        private OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiersItineraryOptions PrepareItineraryOptions(CE_Segmento[] segmentos)
        {
            if (segmentos.Any(s => (s.Seleccionado ?? false)))
            {
                return new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiersItineraryOptions
                {
                    SegmentSelect = segmentos
                        .Where(s => (s.Seleccionado ?? false))
                            .Select(s => new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiersItineraryOptionsSegmentSelect
                            {
                                Number = s.NumeroSegmento.ToString()
                            }).ToArray()
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pasajeros"></param>
        /// <returns></returns>
        private OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiersNameSelect[] PrepareNameSelect(CE_Pasajero[] pasajeros)
        {
            if (pasajeros.Any(s => (s.Seleccionado ?? false)))
            {
                return pasajeros
                    .Where(s => (s.Seleccionado ?? false))
                    .Select(p => new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiersNameSelect
                    {
                        NameNumber = p.NumeroPasajero
                    }).ToArray();
            }

            return null;
        }

        private OTA_AirPriceRQPriceRequestInformationOptionalQualifiersFlightQualifiers PrepareFlightQualifiers(string lineaValidadora)
        {
            if (!string.IsNullOrEmpty(lineaValidadora)) 
            {
                var lexpresion = Regex.Match(lineaValidadora, Configuracion.GetRegularExpression("VendorPrefs"));

                if (string.IsNullOrWhiteSpace(lineaValidadora) && lexpresion.Success)
                {
                    return new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersFlightQualifiers
                    {
                        VendorPrefs = new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersFlightQualifiersVendorPrefs
                        {
                            Airline = new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersFlightQualifiersVendorPrefsAirline
                            {
                                Code = lineaValidadora
                            }
                        }
                    };
                }
            }

            return null;
        }

        #endregion

        #region "Process"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="validatingCarrier"></param>
        /// <returns></returns>
        private CE_Aerolinea[] ProcessValidatingCarrier(OTA_AirPriceRSPriceQuoteMiscInformationValidatingCarrier[] validatingCarrier)
        {
            return validatingCarrier[0].Ticket.Select(t => new CE_Aerolinea
            {
                CodigoAerolinea = t.CarrierCode
            }).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itineraryPricingInfo"></param>
        /// <returns></returns>
        private CE_Ciudad ProcessAirItineraryPricingInfo(OTA_AirPriceRSPriceQuotePricedItineraryAirItineraryPricingInfo[] itineraryPricingInfo)
        {
            var lsameMarket = false;
            
            var lfirstMarket = itineraryPricingInfo
                .Select(i => i.PTC_FareBreakdown.First(f => (!string.IsNullOrWhiteSpace(f.FareBasis.Market))).FareBasis.Market)
                    .ToArray()[0];

            itineraryPricingInfo.ToList().ForEach(i =>
            {
                lsameMarket = i.PTC_FareBreakdown
                    .Where(f => (!string.IsNullOrWhiteSpace(f.FareBasis.Market)))
                    .ToList()
                    .TrueForAll(f =>
                        f.FareBasis.Market.Equals(lfirstMarket, StringComparison.InvariantCultureIgnoreCase)
                    );
            });

            if (lsameMarket)
            {
                return new CE_Ciudad
                {
                    CodigoCiudadSegmento = lfirstMarket.Substring(3, 3)
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itinTotalFare"></param>
        /// <param name="codigoMonedaConsulta"></param>
        /// <returns></returns>
        private decimal ProcessItinTotalFare(OTA_AirPriceRSPriceQuotePricedItineraryAirItineraryPricingInfoItinTotalFare itinTotalFare,
                                             string codigoMonedaConsulta)
        {
            if (itinTotalFare.BaseFare.CurrencyCode.Equals(codigoMonedaConsulta, StringComparison.InvariantCultureIgnoreCase))
            {
                return decimal.Parse(itinTotalFare.BaseFare.Amount);
            }

            return decimal.Parse(itinTotalFare.EquivFare.Amount);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="codigoMonedaConsulta"></param>
        /// <param name="segmentos"></param>
        /// <param name="estatus"></param>
        /// <param name="cotizacion"></param>
        /// <returns></returns>
        private void ProcessResult(OTA_AirPriceRS response,
                                   string codigoMonedaConsulta,
                                   CE_Segmento[] segmentos, 
                                   out CE_Estatus estatus,
                                   out CE_Cotizacion cotizacion)
        {
            estatus = new CE_Estatus();

            cotizacion = null;

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".OTA_AirPriceRQ return OTA_AirPriceRS null");

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

                // filtrando segmentos seleccionados
                var lsegmentosSeleccionados = segmentos.Where(s => (s.Seleccionado ?? false)).ToArray();

                cotizacion = new CE_Cotizacion
                {
                    Pseudo = response.PriceQuote.PricedItinerary.AirItineraryPricingInfo[0].FareCalculationBreakdown.First(f => (f.Branch != null)).Branch.PCC,
                    LineasValidadoras = ProcessValidatingCarrier(response.PriceQuote.MiscInformation.ValidatingCarrier),
                    CiudadDestino = ProcessAirItineraryPricingInfo(response.PriceQuote.PricedItinerary.AirItineraryPricingInfo),
                    Tarifas = response.PriceQuote.PricedItinerary.AirItineraryPricingInfo
                        .Select(a => new CE_Tarifa
                        {
                            Neto = ProcessItinTotalFare(a.ItinTotalFare, codigoMonedaConsulta),
                            Total = decimal.Parse(a.ItinTotalFare.TotalFare.Amount),
                            BaseTarifaria = a.PTC_FareBreakdown.Where(f => (!string.IsNullOrEmpty(f.FareBasis.Market)))
                                .Select((p, i) => new CE_BaseTarifaria
                                {
                                    NumeroSegmento = lsegmentosSeleccionados[i].NumeroSegmento,
                                    BaseTarifaria = p.FareBasis.Code,
                                }).ToArray(),
                            CantidadTipoPasajero =  int.Parse(a.PassengerTypeQuantity.Quantity),
                            TipoPasajero = new CE_TipoPasajero{ IdTipoPasajero = a.PassengerTypeQuantity.Code },
                            Impuestos = a.ItinTotalFare.Taxes.Tax.Select(t => new CE_Impuesto
                            {
                                CodigoImpuesto = t.TicketingTaxCode,
                                Descripcion = t.TaxName,
                                CodigoMonedaPago = codigoMonedaConsulta,
                                Importe = decimal.Parse(t.Amount)
                            }).ToArray()
                        }).ToArray() 
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="cotizacion"></param>
        /// <returns></returns>
        public CE_Estatus Execute(RQ_ObtenerCotizaciones parametros,
                                  out CE_Cotizacion cotizacion)
        {
            OTA_AirPriceRQRequest lotaAirPriceRQRequest = null;
            OTA_AirPriceRQResponse lotaAirPriceRQResponse = null;

            var lrespuesta = new CE_Estatus();

            cotizacion = null;

            try
            {
                ValidatePreExecute(parametros);

                // construyendo request
                lotaAirPriceRQRequest = new OTA_AirPriceRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    OTA_AirPriceRQ = new OTA_AirPriceRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        PriceRequestInformation = new OTA_AirPriceRQPriceRequestInformation
                        {
                            OptionalQualifiers = new OTA_AirPriceRQPriceRequestInformationOptionalQualifiers
                            {
                                PricingQualifiers = new OTA_AirPriceRQPriceRequestInformationOptionalQualifiersPricingQualifiers
                                {
                                    CurrencyCode = parametros.CodigoMoneda
                                },
                                FlightQualifiers = PrepareFlightQualifiers(parametros.LineaValidadora)
                            }
                        }
                    }
                };

                // evaluando si enviar los segmentos (solo cuando exista alguno sin seleccionar)
                if (parametros.Segmentos.Any(s => (!(s.Seleccionado ?? false))))
                {
                    lotaAirPriceRQRequest.OTA_AirPriceRQ.PriceRequestInformation.OptionalQualifiers.PricingQualifiers.ItineraryOptions = PrepareItineraryOptions(parametros.Segmentos);
                }

                // evaluando si enviar los pasajeros (solo cuando exista alguno sin seleccionar)
                if (parametros.Pasajeros.Any(s => (!(s.Seleccionado ?? false))))
                {
                    lotaAirPriceRQRequest.OTA_AirPriceRQ.PriceRequestInformation.OptionalQualifiers.PricingQualifiers.NameSelect = PrepareNameSelect(parametros.Pasajeros);
                }

                using (var lservicio = Configuracion.GetServiceModelClient<OTA_AirPricePortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'OTA_AirPricePortTypeChannel.OTA_AirPriceRQ'", new { lotaAirPriceRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lotaAirPriceRQResponse = lservicio.OTA_AirPriceRQ(lotaAirPriceRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'OTA_AirPricePortTypeChannel.OTA_AirPriceRQ'", new { lotaAirPriceRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lotaAirPriceRQResponse.OTA_AirPriceRS, parametros.CodigoMoneda, parametros.Segmentos, out lrespuesta, out cotizacion);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { MuteErrors, parametros, cotizacion, lotaAirPriceRQRequest, lotaAirPriceRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                cotizacion = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, parametros, cotizacion, lotaAirPriceRQRequest, lotaAirPriceRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                cotizacion = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
