using System;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_SessionClose_101;

namespace SabreLib.Herramientas
{
    public sealed class SessionClose : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public SessionClose(EnumAplicaciones application,
                            CE_Session sesion,
                            string codigoSeguimiento,
                            bool muteErrors = true)
            : base(WebServiceAction.SessionClose, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~SessionClose()
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
        private void ProcessResult(SessionCloseRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".SessionCloseRQ return SessionCloseRS null");

                return;
            }

            if ((response.Errors != null) && (response.Errors.Error != null))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarError(string.Format("{0} - {1}", response.Errors.Error.ErrorCode, response.Errors.Error.ErrorMessage));

                return;
            }

            if ((response.Warnings != null) && (response.Warnings.Warning != null))
            {
                // actualizando respuesta (warnings)
                estatus.RegistrarAlerta(
                        string.Format(
                            "{0} - {1} - {2} - {3}",
                            response.Warnings.Warning.Code,
                            response.Warnings.Warning.Type,
                            response.Warnings.Warning.Status,
                            response.Warnings.Warning.ShortText
                        ));
            }

            if (response.status.Equals("Approved", StringComparison.InvariantCultureIgnoreCase))
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
            SessionCloseRQRequest lsessionCloseRQRequest = null;
            SessionCloseRQResponse lsessionCloseRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lsessionCloseRQRequest = new SessionCloseRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    SessionCloseRQ = new SessionCloseRQ
                    {
                        POS = new SessionCloseRQPOS
                        {
                            Source = new SessionCloseRQPOSSource
                            {
                                PseudoCityCode = Sesion.Pseudo
                            }
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<SessionClosePortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'SessionClosePortTypeChannel.SessionCloseRQ'", null, new { lsessionCloseRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lsessionCloseRQResponse = lservicio.SessionCloseRQ(lsessionCloseRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'SessionClosePortTypeChannel.SessionCloseRQ'", null, new { lsessionCloseRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lsessionCloseRQResponse.SessionCloseRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, lsessionCloseRQRequest, lsessionCloseRQResponse, lrespuesta }, CodigoSeguimiento);

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
