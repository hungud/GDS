using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_ReissueConfirmedPricing.Request;
using AmadeusLib.Servicios.Ticket_ReissueConfirmedPricing.Response;

namespace AmadeusLib.Ticket
{
    public sealed class TicketReissueConfirmedPricing : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketReissueConfirmedPricing;

        private static readonly object _sync_TicketReissueConfirmedPricing = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketReissueConfirmedPricing(EnumAplicaciones? application,
                                             string codigoSeguimiento,
                                             bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketReissueConfirmedPricing()
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
            Ticket_ReissueConfirmedPricing lticketReissueConfirmedRequest = null;
            Ticket_ReissueConfirmedPricingReply lticketReissueConfirmedResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketReissueConfirmedRequest, session }, CodigoSeguimiento);

                lock (_sync_TicketReissueConfirmedPricing)
                {
                    // procesando solicitud
                    lticketReissueConfirmedResponse = Execute<Ticket_ReissueConfirmedPricing, Ticket_ReissueConfirmedPricingReply>(
                        WebServiceActionHeader4.TicketReissueConfirmedPricing,
                        ((TransactionType) session.AmadeusTransactionType),
                        lticketReissueConfirmedRequest, 
                        ref session,
                        ref _serialiazer_TicketReissueConfirmedPricing);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lticketReissueConfirmedResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lticketReissueConfirmedResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lticketReissueConfirmedRequest, lticketReissueConfirmedResponse }, CodigoSeguimiento);

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
