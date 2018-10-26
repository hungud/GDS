using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_ContextChangeLLS_203;

namespace SabreLib.Herramientas
{
    public sealed class ContextChange : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public ContextChange(EnumAplicaciones application,
                             CE_Session sesion,
                             string codigoSeguimiento,
                             bool muteErrors = true)
            : base(WebServiceAction.ContextChange, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~ContextChange()
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
        /// <param name="sesion"></param>
        /// <returns></returns>
        private void ProcessResult(ContextChangeRS response, 
                                   out CE_Estatus estatus,
                                   out CE_Session sesion)
        {
            estatus = new CE_Estatus();

            sesion = null;

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".OTA_AirPriceRQ return ContextChangeRS null");

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

                if ((response.SecurityToken != null) && response.SecurityToken.Updated)
                {
                    sesion = Sesion;
                    sesion.Token = response.SecurityToken.Value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public CE_Estatus Execute(string pseudo,
                                  out CE_Session sesion)
        {
            ContextChangeRQRequest lcontextChangeRQRequest = null;
            ContextChangeRQResponse lcontextChangeRQResponse = null;

            var lrespuesta = new CE_Estatus();

            sesion = null;

            try
            {
                lcontextChangeRQRequest = new ContextChangeRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    ContextChangeRQ = new ContextChangeRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        ChangeAAA = new ContextChangeRQChangeAAA
                        {
                            PseudoCityCode = pseudo
                        },
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<ContextChangePortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'ContextChangePortTypeChannel.ContextChangeRQ'", null, new { lcontextChangeRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lcontextChangeRQResponse = lservicio.ContextChangeRQ(lcontextChangeRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'ContextChangePortTypeChannel.ContextChangeRQ'", null, new { lcontextChangeRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lcontextChangeRQResponse.ContextChangeRS, out lrespuesta, out sesion);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, pseudo, lcontextChangeRQRequest, lcontextChangeRQResponse, lrespuesta }, CodigoSeguimiento);

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
