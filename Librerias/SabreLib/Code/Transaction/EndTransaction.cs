using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_EndTransactionLLS_207;

namespace SabreLib.Transaction
{
    public sealed class EndTransaction : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public EndTransaction(EnumAplicaciones application,
                              CE_Session sesion,
                              string codigoSeguimiento)
            : base(WebServiceAction.EndTransaction, application, sesion, codigoSeguimiento)
        {
        }

        ~EndTransaction()
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
        private void ProcessResult(EndTransactionRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".EndTransactionRQ return EndTransactionRS null");

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
                estatus.Registrar(response.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cerrar"></param>
        /// <returns></returns>
        private CE_Estatus Execute(bool cerrar)
        {
            EndTransactionRQRequest lendTransactionRQRequest = null;
            EndTransactionRQResponse lendTransactionRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lendTransactionRQRequest = new EndTransactionRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    EndTransactionRQ = new EndTransactionRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        Source = new EndTransactionRQSource
                        {
                            ReceivedFrom = CodigoSeguimiento
                        },
                        EndTransaction = new EndTransactionRQEndTransaction
                        {
                            Ind = cerrar
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<EndTransactionPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'EndTransactionPortTypeChannel.EndTransactionRQ'", null, new { lendTransactionRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lendTransactionRQResponse = lservicio.EndTransactionRQ(lendTransactionRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'EndTransactionPortTypeChannel.EndTransactionRQ'", null, new { lendTransactionRQResponse }, CodigoSeguimiento);

                    // construyendo respuesta
                    ProcessResult(lendTransactionRQResponse.EndTransactionRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, lendTransactionRQRequest, lendTransactionRQResponse, lrespuesta }, CodigoSeguimiento);

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus Firmar()
        {
            return Execute(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus FirmarCerrar()
        {
            return Execute(true);
        }

        #endregion
    }
}
