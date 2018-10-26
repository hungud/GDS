using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_RepricePNRWithBookingClass.Request;
using AmadeusLib.Servicios.Ticket_RepricePNRWithBookingClass.Response;

namespace AmadeusLib.Ticket
{
    public sealed class TicketRepricePNRWithBookingClass : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketRepricePNRWithBookingClass;

        private static readonly object _sync_TicketRepricePNRWithBookingClass = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketRepricePNRWithBookingClass(EnumAplicaciones? application,
                                                string codigoSeguimiento,
                                                bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketRepricePNRWithBookingClass()
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
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(ref CE_Session session)
        {
            Ticket_RepricePNRWithBookingClass lticketRepricePnrRequest = null;
            Ticket_RepricePNRWithBookingClassReply lticketRepricePnrResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketRepricePnrRequest, session }, CodigoSeguimiento);

                lock (_sync_TicketRepricePNRWithBookingClass)
                {
                    // procesando solicitud
                    lticketRepricePnrResponse = Execute<Ticket_RepricePNRWithBookingClass, Ticket_RepricePNRWithBookingClassReply>(
                        WebServiceActionHeader4.TicketRepricePNRWithBookingClass,
                        ((TransactionType) session.AmadeusTransactionType),
                        lticketRepricePnrRequest, 
                        ref session,
                        ref _serialiazer_TicketRepricePNRWithBookingClass);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lticketRepricePnrResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lticketRepricePnrResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lticketRepricePnrRequest, lticketRepricePnrResponse }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
