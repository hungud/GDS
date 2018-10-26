using System;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Hotel;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_GetReservation_1170;

namespace SabreLib.lItinerary
{
    public sealed class GetReservation : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public GetReservation(EnumAplicaciones application,
                              CE_Session sesion,
                              string codigoSeguimiento,
                              bool muteErrors = true)
            : base(WebServiceAction.GetReservation, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~GetReservation()
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
        /// <param name="additionalInformation"></param>
        /// <returns></returns>
        private string ProcessConfirmationNumber(HotelTypeAdditionalInformation additionalInformation)
        {
            string lnumeroConfirmacion = null;

            if (additionalInformation.ConfirmationNumber != null)
            {
                foreach (var linfo in additionalInformation.ConfirmationNumber)
                {
                    lnumeroConfirmacion = linfo.Value;
                }
            }

            return lnumeroConfirmacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacion"></param>
        /// <returns></returns>
        private CE_Hotel ProcessInfoHotel(SegmentTypePNRBSegment informacion)
        {
            var linfo = ((Hotel) informacion.Item);

            if (linfo.AdditionalInformation != null)
            {
                return new CE_Hotel
                {
                    NombreHotel = linfo.Reservation.HotelName,
                    CodigoCadenaHotelera = linfo.Reservation.ChainCode,
                    CodigoCiudadHotel = linfo.Reservation.HotelCityCode,
                    CodigoHotel = ProcessHotelCode(linfo.Reservation.HotelCode),
                    Contacto = ProcessInfoContact(linfo.AdditionalInformation),
                    Direccion = ProcessInfoAddress(linfo.AdditionalInformation)
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="additionalInformation"></param>
        /// <returns></returns>
        private CE_Direccion ProcessInfoAddress(HotelTypeAdditionalInformation additionalInformation)
        {
            if (additionalInformation.Address != null)
            {
                return new CE_Direccion
                {
                    Ciudad = additionalInformation.Address.City,
                    CodigoPais = additionalInformation.Address.CountryCode,
                    ZipCodigo = additionalInformation.Address.ZipCode,
                    Direcciones = additionalInformation.Address.AddressLine
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="additionalInformation"></param>
        /// <returns></returns>
        private CE_Contacto ProcessInfoContact(HotelTypeAdditionalInformation additionalInformation)
        {
            if (additionalInformation.ContactNumbers != null)
            {
                return new CE_Contacto
                {
                    NumerosTelefono = additionalInformation.ContactNumbers.PhoneNumber,
                    NumeroFax = additionalInformation.ContactNumbers.FaxNumber
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalPricing"></param>
        /// <returns></returns>
        private CE_PrecioTotal ProcessTotalPricing(HotelTypeReservationHotelTotalPricing totalPricing)
        {
            if (totalPricing != null)
            {
                return new CE_PrecioTotal
                {
                    Impuesto = ProcessTotalTax(totalPricing.TotalTax),
                    Moneda = totalPricing.ApproximateTotal.AmountAndCurrency.Split(' ')[1],
                    MontoTotalAproximado = decimal.Parse(totalPricing.ApproximateTotal.AmountAndCurrency.Split(' ')[0]),
                    Descargos = ProcessDiclaimers(totalPricing.Disclaimer)
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diclaimers"></param>
        /// <returns></returns>
        public CE_Descargos[] ProcessDiclaimers(HotelTypeReservationHotelTotalPricingDisclaimer[] diclaimers)
        {
            if (diclaimers != null)
            {
                return diclaimers.Select(d => new CE_Descargos
                    {
                        Id = int.Parse(d.Id),
                        Descripcion = d.Value
                    }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="precioTotalImpuesto"></param>
        /// <returns></returns>
        public CE_ImpuestoTotal ProcessTotalTax(HotelTypeReservationHotelTotalPricingTotalTax precioTotalImpuesto)
        {
            if (precioTotalImpuesto != null)
            {
                return new CE_ImpuestoTotal
                {
                    MontoImpuestoTotal = decimal.Parse(precioTotalImpuesto.Amount)
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hotelCodes"></param>
        /// <returns></returns>
        private string ProcessHotelCode(HotelTypeReservationHotelCode[] hotelCodes)
        {
            string lrespuesta = null;

            if (hotelCodes != null)
            {
                foreach (var ldata in hotelCodes)
                {
                    lrespuesta = ldata.Value;
                    break;
                }
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dkPnrb"></param>
        /// <returns></returns>
        private int? ProcessCustomerID(IReadOnlyList<string> dkPnrb)
        {
            if (dkPnrb != null)
            {
                return int.Parse(dkPnrb[0].Trim());
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passengersPnrb"></param>
        /// <returns></returns>
        private CE_PasajeroHotel[] ProcessInfoPassengers(PassengersPNRB passengersPnrb)
        {
            if (passengersPnrb != null)
            {
                return passengersPnrb.Passenger.Select(p => 
                    new CE_PasajeroHotel
                    {
                        NumeroPasajero = ProcessPassengerNameNumber(p.nameId),
                        Apellido = p.LastName,
                        Nombre = p.FirstName,
                        Tipo = p.passengerType
                    }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroPasajero"></param>
        /// <returns></returns>
        private string ProcessPassengerNameNumber(string numeroPasajero)
        {
            return numeroPasajero.Split('.').Select(n => n.TrimStart('0')).Pipe(l => string.Join(".", l));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacion"></param>
        /// <returns></returns>
        private CE_SegmentoHotel ProcessSegment(SegmentTypePNRBSegment informacion)
        {
            if (informacion != null)
            {
                var linfo = ((Hotel) informacion.Item);

                if (linfo != null)
                {
                    var reservation = linfo.Reservation;

                    return new CE_SegmentoHotel
                    {
                        NumeroLinea = ProcessPassengerNameNumber(reservation.LineNumber),
                        Tipo = reservation.LineType,
                        Status = reservation.LineStatus,
                        IATA = reservation.POSRequestorID,
                        EsPasado = linfo.isPast,
                        FechaEntrada = reservation.TimeSpanStart.ToString("dd/MM/yyyy"),
                        FechaSalida = reservation.TimeSpanEnd.ToString("dd/MM/yyyy"),
                        DuracionEstadia = int.Parse(reservation.TimeSpanDuration),
                        CodigoAccesoTarifa = ((reservation.RateAccessCodeBooked != null) ? reservation.RateAccessCodeBooked.RateAccessCode : null),
                        TipoHabitacion = new CE_TipoHabitacion
                        {
                            Codigo = reservation.RoomType.RoomTypeCode,
                            ShortText = reservation.RoomType.ShortText,
                            CantidadPasajerosEnHabitacion = int.Parse(reservation.RoomType.NumberOfUnits)
                        },
                        PrecioHabitacion = new CE_PrecioHabitacion
                        {
                            CodigoMoneda = reservation.RoomRates.CurrencyCode,
                            PrecioSinImpuestos = decimal.Parse(reservation.RoomRates.AmountBeforeTax)
                        },
                        PrecioTotal = ProcessTotalPricing(reservation.HotelTotalPricing),
                        Hotel = ProcessInfoHotel(informacion),
                        CodigoConfirmacion = ProcessConfirmationNumber(linfo.AdditionalInformation)
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segmentPnrb"></param>
        /// <returns></returns>
        private CE_SegmentoHotel[] ProcessInfoSegments(SegmentTypePNRB segmentPnrb)
        {
            if ((segmentPnrb != null) && (segmentPnrb.Segment != null))
            {
                var lsegmentos = segmentPnrb.Segment.Where(s => (s.Item.GetType() == typeof(Hotel))).ToList();

                return lsegmentos.Select(ProcessSegment).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="remarksPnrb"></param>
        /// <returns></returns>
        private CE_Remark[] ProcessRemarks(RemarksPNRB remarksPnrb)
        {
            if ((remarksPnrb != null) && (remarksPnrb.Remark != null))
            {
                return remarksPnrb.Remark.Select(remark =>
                {
                    var text = string.Empty;
                    var remarkLines = remark.RemarkLines;

                    if (remarkLines != null && remarkLines.RemarkLine != null)
                    {
                        text = string.Join("/", remarkLines.RemarkLine.Select(i => i.Text).ToArray());
                    }

                    return new CE_Remark
                    {
                        Code = remark.code,
                        ElementId = remark.elementId,
                        Id = int.Parse(remark.id),
                        Index = int.Parse(remark.index),
                        Type = ((TipoRemarkEnum) Enum.Parse(typeof(TipoRemarkEnum), remark.type.ToString())),
                        Text = text
                    };

                }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <param name="reservaHotel"></param>
        /// <returns></returns>
        private void ProcessResult(GetReservationRS response,
                                   out CE_Estatus estatus,
                                   out CE_ReservaHotel reservaHotel)
        {
            estatus = new CE_Estatus();

            reservaHotel = null;

            var lreservationRs = ((ReservationPNRB) response.Item);

            if (lreservationRs != null)
            {
                reservaHotel = new CE_ReservaHotel
                {
                    AgenteCreador = lreservationRs.BookingDetails.CreationAgentID,
                    FechaCreacion = lreservationRs.BookingDetails.CreationTimestamp.ToString(),
                    PNR = lreservationRs.BookingDetails.RecordLocator,
                    PseudoAAA = lreservationRs.POS.Source.PseudoCityCode,
                    PseudoHome = lreservationRs.POS.Source.HomePseudoCityCode,
                    CustomerId = ProcessCustomerID(lreservationRs.DKNumbers)
                };

                if (lreservationRs.PassengerReservation != null)
                {
                    reservaHotel.Pasajeros = ProcessInfoPassengers(lreservationRs.PassengerReservation.Passengers);
                    reservaHotel.SegmentosHotel = ProcessInfoSegments(lreservationRs.PassengerReservation.Segments);
                    reservaHotel.Remarks = ProcessRemarks(lreservationRs.Remarks);
                    estatus.Ok = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="areasTematicas"></param>
        /// <param name="reservaHotel"></param>
        /// <returns></returns>
         private CE_Estatus Execute(string pnr,
                                    string[] areasTematicas,
                                    out CE_ReservaHotel reservaHotel)
         {
             GetReservationOperationRequest lgetReservationOperationRequest = null;
             GetReservationOperationResponse lgetReservationOperationResponse = null;

             var lrespuesta = new CE_Estatus();

             reservaHotel = null;

             try
             {
                 // construyendo request
                 lgetReservationOperationRequest = new GetReservationOperationRequest
                 {
                     Security = Security,
                     MessageHeader = MessageHeader,
                     GetReservationRQ = new GetReservationRQ
                     {
                         EchoToken = "String",
                         Version = WebServiceFileValueSabre.Version,
                         RequestType = "Stateful",
                         Locator = (string.IsNullOrWhiteSpace(pnr) ? null : pnr),
                         ReturnOptions = new ReturnOptionsPNRB
                         {
                             UnmaskCreditCard = true,
                             ShowTicketStatus = true,
                             SubjectAreas = areasTematicas,
                             ResponseFormat = "STL"
                         }
                     }
                 };

                 using (var lservicio = Configuracion.GetServiceModelClient<GetReservationPortTypeChannel>())
                 {
                     // registrando eventos
                     Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'GetReservationPortTypeChannel.GetReservationRQ'", null, new { lgetReservationOperationRequest }, CodigoSeguimiento);

                     // procesando solicitud
                     lgetReservationOperationResponse = lservicio.GetReservationOperation(lgetReservationOperationRequest);

                     // registrando eventos
                     Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'GetReservationPortTypeChannel.GetReservationRQ'", null, new { lgetReservationOperationResponse }, CodigoSeguimiento);

                     // actualizando respuesta
                     ProcessResult(lgetReservationOperationResponse.GetReservationRS, out lrespuesta, out reservaHotel);
                 }

             }
             catch (Exception ex)
             {
                 // registrando eventos
                 Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, pnr, areasTematicas, lgetReservationOperationRequest, lgetReservationOperationResponse, lrespuesta }, CodigoSeguimiento);

                 // no silenciar errores
                 if (!MuteErrors)
                 {
                     throw;
                 }

                 reservaHotel = null;

                 // actualizando respuesta
                 lrespuesta = new CE_Estatus(ex);
             }

             return lrespuesta;
         }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="pnr"></param>
         /// <param name="reservaHotel"></param>
         /// <returns></returns>
         public CE_Estatus ObtenerItinerarioHotel(string pnr,
                                                  out CE_ReservaHotel reservaHotel)
         {
             return Execute(pnr, new[] { "FULL" }, out reservaHotel);
         }

        #endregion
    }
}
