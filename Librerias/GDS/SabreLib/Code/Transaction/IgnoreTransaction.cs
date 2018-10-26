using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_IgnoreTransactionLLS_200;

namespace SabreLib.Transaction
{
    public sealed class IgnoreTransaction : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        /// <returns></returns>
        public IgnoreTransaction(EnumAplicaciones application,
                                 CE_Session sesion,
                                 string codigoSeguimiento)
            : base(WebServiceAction.IgnoreTransaction, application, sesion, codigoSeguimiento)
        {
        }

        ~IgnoreTransaction()
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
        /// <returns></returns>
        private void ProcessResult(IgnoreTransactionRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".IgnoreTransactionRQ return IgnoreTransactionRS null");

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
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus Execute()
        {
            IgnoreTransactionRQRequest lignoreTransactionRQRequest = null;
            IgnoreTransactionRQResponse lignoreTransactionRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lignoreTransactionRQRequest = new IgnoreTransactionRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    IgnoreTransactionRQ = new IgnoreTransactionRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<IgnoreTransactionPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'IgnoreTransactionPortTypeChannel.IgnoreTransactionRQ'", new { lignoreTransactionRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lignoreTransactionRQResponse = lservicio.IgnoreTransactionRQ(lignoreTransactionRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'IgnoreTransactionPortTypeChannel.IgnoreTransactionRQ'", new { lignoreTransactionRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lignoreTransactionRQResponse.IgnoreTransactionRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lignoreTransactionRQRequest, lignoreTransactionRQResponse, lrespuesta }, CodigoSeguimiento);

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
