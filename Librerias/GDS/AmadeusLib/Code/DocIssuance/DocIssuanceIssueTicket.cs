using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.DocIssuance_IssueTicket.Request;
using AmadeusLib.Servicios.DocIssuance_IssueTicket.Response;

namespace AmadeusLib.DocIssuance
{
    public sealed class DocIssuanceIssueTicket : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_DocIssuanceIssueTicket;

        private static readonly object _sync_DocIssuanceIssueTicket = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public DocIssuanceIssueTicket(EnumAplicaciones? application,
                                      string codigoSeguimiento,
                                      bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~DocIssuanceIssueTicket()
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
            DocIssuance_IssueTicket ldocIssueTicketRequest = null;
            DocIssuance_IssueTicketReply ldocIssueTicketResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { ldocIssueTicketRequest, session }, CodigoSeguimiento);

                lock (_sync_DocIssuanceIssueTicket)
                {
                    // procesando solicitud
                    ldocIssueTicketResponse = Execute<DocIssuance_IssueTicket, DocIssuance_IssueTicketReply>(
                        WebServiceActionHeader4.DocIssuanceIssueTicket,
                        ((TransactionType) session.AmadeusTransactionType),
                        ldocIssueTicketRequest, 
                        ref session,
                        ref _serialiazer_DocIssuanceIssueTicket);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { ldocIssueTicketResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(ldocIssueTicketResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, ldocIssueTicketRequest, ldocIssueTicketResponse }, CodigoSeguimiento);

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
