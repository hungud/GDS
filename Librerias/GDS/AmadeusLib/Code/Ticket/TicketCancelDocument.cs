using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_CancelDocument.Request;
using AmadeusLib.Servicios.Ticket_CancelDocument.Response;

// alias
using nsRQ = AmadeusLib.Servicios.Ticket_CancelDocument.Request;

namespace AmadeusLib.Ticket
{
    public sealed class TicketCancelDocument: Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketCancelDocument;

        private static readonly object _sync_TicketCancelDocument = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketCancelDocument(EnumAplicaciones? application,
                                    string codigoSeguimiento,
                                    bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketCancelDocument()
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
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <param name="cancelacionDocumentoCorrecta"></param>
        /// <returns></returns>
        private void ProcessResult(Ticket_CancelDocumentReply response, 
                                   out CE_Estatus estatus, 
                                   out bool cancelacionDocumentoCorrecta)
        {
            cancelacionDocumentoCorrecta = false;

            estatus = new CE_Estatus();

            if (response == null)
            {
                estatus.RegistrarError(".Execute return Ticket_CancelDocumentReply null");

                return;
            }

            if (response.transactionResults == null)
            {
                estatus.RegistrarError(".Execute return Ticket_CancelDocumentReply.transactionResults null");

                return;
            }

            var ltransactionResult = response.transactionResults[0];

            if (ltransactionResult.errorGroup != null)
            {
                estatus.RegistrarErrores(ltransactionResult.errorGroup.errorWarningDescription.freeText);

                return;
            }

            estatus.Ok = true;
            cancelacionDocumentoCorrecta = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="officeId"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="cancelacionDocumentoCorrecta"></param>
        /// <returns></returns>
        public CE_Estatus Execute(ref CE_Session session, 
                                      string officeId, 
                                      string numeroBoleto,
                                      out bool cancelacionDocumentoCorrecta)
        {
            Ticket_CancelDocument lticketCancelDocumentRQ = null;
            Ticket_CancelDocumentReply lticketCancelDocumentRS = null;

            cancelacionDocumentoCorrecta = false;

            CE_Estatus lrespuesta;

            try
            {
                // construyendo request
                lticketCancelDocumentRQ = new Ticket_CancelDocument
                {
                    documentNumberDetails = new nsRQ.TicketNumberTypeI
                    {
                        documentDetails = new nsRQ.TicketNumberDetailsTypeI
                        {
                            number = numeroBoleto
                        }
                    },
                    stockProviderDetails = new OfficeSettingsDetailsType
                    {
                        officeSettingsDetails = new DocumentInfoFromOfficeSettingType
                        {
                            marketIataCode = "PE"
                        }
                    },
                    targetOfficeDetails = new AdditionalBusinessSourceInformationType
                    {
                        originatorDetails = new OriginatorIdentificationDetailsType 
                        {
                            inHouseIdentification2 = officeId
                        }
                    }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketCancelDocumentRQ, session }, CodigoSeguimiento);

                lock (_sync_TicketCancelDocument)
                {
                    // procesando solicitud
                    lticketCancelDocumentRS = Execute<Ticket_CancelDocument, Ticket_CancelDocumentReply>(
                        WebServiceActionHeader4.TicketCancelDocument,
                        ((TransactionType) session.AmadeusTransactionType),
                        lticketCancelDocumentRQ, 
                        ref session,
                        ref _serialiazer_TicketCancelDocument);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lticketCancelDocumentRS, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lticketCancelDocumentRS, out lrespuesta, out cancelacionDocumentoCorrecta);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lticketCancelDocumentRQ, lticketCancelDocumentRS }, CodigoSeguimiento);

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
