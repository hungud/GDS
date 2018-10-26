using System;
using System.Collections.Generic;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;

using KiuLib.Base;
using KiuLib.Utiles;
using KiuLib.Models;

namespace KiuLib.Itinerary
{
    public sealed class TravelItineraryRead : Common<KiuCredential, KiuHeader>
    {

        // =============================
        // constructores y destructores

        #region "constructores y destructores"
        public TravelItineraryRead(EnumAplicaciones application,
                                   string codigoSeguimiento,
                                   bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        { 
        
        }

        ~TravelItineraryRead()
        {
            Dispose(false);
        }
        #endregion

        #region "Process"

        
        public CE_Estatus ObtenerItinerario(string pnr,
                                            EnumTypeTravelItineraryReadKiu type,
                                            int secuencia,
                                            out CE_Reserva reserva)
        {
            return Execute(pnr, type,secuencia, out reserva);
        }
       

      
        private CE_Estatus Execute(string pnr,
                                   EnumTypeTravelItineraryReadKiu type,
                                   int secuencia,
                                   out CE_Reserva reserva)
        {
          

            KIU_TravelItineraryReadRQ ltravelItineraryReadRQRequest = null;
            KIU_TravelItineraryRS ltravelItineraryReadRQResponse = null;


            var lrespuesta = new CE_Estatus();

            reserva = null;

            try
            {

                ltravelItineraryReadRQRequest = new KIU_TravelItineraryReadRQ
                {
                    EchoToken = byte.Parse(MessageHeader.EchoToken),
                    Target = MessageHeader.Target,
                    Version = Convert.ToDecimal(MessageHeader.Version),
                    PrimaryLangID = MessageHeader.PrimaryLangID,
                    TimeStamp = MessageHeader.TimeStamp,
                    SequenceNmbr = byte.Parse(secuencia.ToString()),

                    UniqueID =  new KIU_TravelItineraryReadRQUniqueID
                    {
                        ID = pnr,
                        Type = (byte)type,
                    },

                    POS = new KIU_TravelItineraryReadRQPOS
                    {
                        Source = new KIU_TravelItineraryReadRQPOSSource
                        {
                            AgentSine = Security.Agent,
                            TerminalID = Security.Terminal
                        }
                    }

                };

                ltravelItineraryReadRQResponse = Configuracion.GetKiuResultado2<KIU_TravelItineraryRS, KIU_TravelItineraryReadRQ>(ltravelItineraryReadRQRequest);


                ProcessResult(ltravelItineraryReadRQResponse, pnr, out lrespuesta, out reserva);

            }
            catch (InternalException ex)
            {
                // registrando evento
                Bitacora.Current.Warn(ex, new { MuteErrors, pnr, reserva, ltravelItineraryReadRQRequest, ltravelItineraryReadRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { MuteErrors, pnr, reserva, ltravelItineraryReadRQRequest, ltravelItineraryReadRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta; 
        }


        private void ProcessResult(KIU_TravelItineraryRS response,
                                   string pnr,
                                   out CE_Estatus estatus,
                                   out CE_Reserva reserva)
        {
            estatus = new CE_Estatus();
            reserva = null;

            if ((response.Error != null))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarError(".TravelItineraryReadRQ return TravelItineraryReadRS null");
                
                return;
            }


            if ((response != null) && (response.Error != null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(string.Format("{0} - {1}", response.Error.ErrorCode, response.Error.ErrorMsg));

                return;
            }



            if (response.TravelItinerary != null) 
            {

                 reserva = new CE_Reserva();
                 // obtenemos los pasajeros que se encuentran en la reserva
                 reserva.Pasajeros = ProcessCustomerInfo(response.TravelItinerary.CustomerInfos);
                 // obtenemos los segmentos que se encuentran en la reserva
                 reserva.Itinerario = new CE_Itinerario
                 {
                     Segmentos = ProcessItineraryInfo(response.TravelItinerary.ItineraryInfo.ReservationItems, pnr),
                 };

                
            
            }

            


        }
       

        #endregion


        private CE_Pasajero[] ProcessCustomerInfo(KIU_TravelItineraryRSTravelItineraryCustomerInfo[] CustomerInfos) 
        {

            List<CE_Pasajero> pasajeros = null;

            foreach (var customerInfos in CustomerInfos)
                {
                    var pasajero = new CE_Pasajero
                    {
                        NumeroPasajero = customerInfos.RPH.ToString(),
                                               
                        Nombre = customerInfos.Customer.PersonName.GivenName,
                        Apellido = customerInfos.Customer.PersonName.Surname,

                        TipoPasajero = new CE_TipoPasajero 
                        {
                            IdTipoPasajero = customerInfos.Customer.PassengerTypeCode.Trim(),

                            RequiereAsiento = (customerInfos.Customer.PassengerTypeCode.Trim().Equals("INF"))? false : true,
                        },

                        TipoDocumento = ProcessPassengerDocumentType(customerInfos.Customer.Document.DocType),
                        NumeroDocumento = customerInfos.Customer.Document.DocID,
                    };

                    if (pasajeros == null) pasajeros = new List<CE_Pasajero>();

                    pasajeros.Add(pasajero);
                }

            return pasajeros.ToArray();
        }

        private CE_Segmento[] ProcessItineraryInfo(KIU_TravelItineraryRSTravelItineraryItineraryInfoItem[] ItineraryInfo, string CodigoReserva)
        {
            List<CE_Segmento> Segmentos = null;

            foreach (var itineraryInfo in ItineraryInfo)
            {
                if (itineraryInfo.Air != null)
                {
                    var segmento = new CE_Segmento
                    {
                        TipoSegmento = EnumTipoSegmento.AIR,
                        NumeroSegmento = int.Parse(itineraryInfo.ItinSeqNumber.ToString()),
                        Status = itineraryInfo.Air.Reservation.Status == 39 ? "HK" : "HX",
                        Aerolinea = new CE_Aerolinea 
                        {
                             CodigoAerolinea = itineraryInfo.Air.Reservation.MarketingAirline,
                        },
                        NumeroVuelo = itineraryInfo.Air.Reservation.FlightNumber.ToString(),
                        ClaseReserva = itineraryInfo.Air.Reservation.ResBookDesigCode,

                        FechaSalida = string.Format("{0:dd/MM/yyyy}", itineraryInfo.Air.Reservation.DepartureDateTime),
                        HoraSalida =  string.Format("{0:HH:mm}", itineraryInfo.Air.Reservation.DepartureDateTime),

                        FechaLlegada = string.Format("{0:dd/MM/yyyy}", itineraryInfo.Air.Reservation.ArrivalDateTime),
                        HoraLlegada = string.Format("{0:HH:mm}", itineraryInfo.Air.Reservation.ArrivalDateTime),

                        OperadoPor = itineraryInfo.Air.Reservation.MarketingAirline,

                        CodigoReservaAerolinea = CodigoReserva,
                        
                    };

                    if (Segmentos == null) { Segmentos = new List<CE_Segmento>(); }

                    Segmentos.Add(segmento);
                                   
                }
            }


            return Segmentos.ToArray();
        
        }

        private EnumTipoDocumento ProcessPassengerDocumentType(string texto)
        {

            if (texto.Equals("CE"))
            {
                return EnumTipoDocumento.CarnetExtranjeria;
            }
            if (texto.Equals("PP"))
            {
                return EnumTipoDocumento.Pasaporte;
            }

            return EnumTipoDocumento.DNI;

        }


    }
}
