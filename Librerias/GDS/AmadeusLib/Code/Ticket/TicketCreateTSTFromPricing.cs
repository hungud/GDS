using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_CreateTSTFromPricing.Request;
using AmadeusLib.Servicios.Ticket_CreateTSTFromPricing.Response;

namespace AmadeusLib.Ticket
{
    public sealed class TicketCreateTSTFromPricing : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketCreateTSTFromPricing;

        private static readonly object _sync_TicketCreateTSTFromPricing = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketCreateTSTFromPricing(EnumAplicaciones? application,
                                          string codigoSeguimiento,
                                          bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketCreateTSTFromPricing()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        public CE_Estatus Execute(ref CE_Session session)
        {
            Ticket_CreateTSTFromPricing lticketCreateTSTFromPricingRequest = null;
            Ticket_CreateTSTFromPricingReply lticketCreateTSTFromPricingResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketCreateTSTFromPricingRequest, session }, CodigoSeguimiento);

                lock (_sync_TicketCreateTSTFromPricing)
                {
                    // procesando solicitud
                    lticketCreateTSTFromPricingResponse = Execute<Ticket_CreateTSTFromPricing, Ticket_CreateTSTFromPricingReply>(
                        WebServiceActionHeader4.TicketCreateTSTFromPricing,
                        ((TransactionType) session.AmadeusTransactionType),
                        lticketCreateTSTFromPricingRequest, 
                        ref session,
                        ref _serialiazer_TicketCreateTSTFromPricing);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lticketCreateTSTFromPricingResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lticketCreateTSTFromPricingResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lticketCreateTSTFromPricingRequest, lticketCreateTSTFromPricingResponse }, CodigoSeguimiento);

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
