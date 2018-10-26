using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_CheckEligibility.Request;
using AmadeusLib.Servicios.Ticket_CheckEligibility.Response;

namespace AmadeusLib.Ticket
{
    public sealed class TicketCheckEligibility : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketCheckEligibility;

        private static readonly object _sync_TicketCheckEligibility = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketCheckEligibility(EnumAplicaciones? application,
                                      string codigoSeguimiento,
                                      bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketCheckEligibility()
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
            Ticket_CheckEligibility lticketCheckEligibilityRequest = null;
            Ticket_CheckEligibilityReply lticketCheckEligibilityResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketCheckEligibilityRequest, session }, CodigoSeguimiento);

                lock (_sync_TicketCheckEligibility)
                {
                    // procesando solicitud
                    lticketCheckEligibilityResponse = Execute<Ticket_CheckEligibility, Ticket_CheckEligibilityReply>(
                        WebServiceActionHeader4.TicketCheckEligibility,
                        ((TransactionType) session.AmadeusTransactionType),
                        lticketCheckEligibilityRequest, 
                        ref session,
                        ref _serialiazer_TicketCheckEligibility);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lticketCheckEligibilityResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lticketCheckEligibilityResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lticketCheckEligibilityRequest, lticketCheckEligibilityResponse }, CodigoSeguimiento);

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
