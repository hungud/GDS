using System;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_SessionCreate_100;

namespace SabreLib.Herramientas
{
    public sealed class SessionCreate : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public SessionCreate(EnumAplicaciones application,
                            CE_Session sesion,
                            string codigoSeguimiento,
                            bool muteErrors = true)
            : base(WebServiceAction.SessionCreate, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~SessionCreate()
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
        private void ProcessResult(SessionCreateRQResponse response,
                                   out CE_Estatus estatus,
                                   out CE_Session sesion)
        {
            estatus = new CE_Estatus();
            sesion = null;

            if ((response.SessionCreateRS == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".SessionCreateRQ return SessionCreateRS null");

                return;
            }

            if ((response.SessionCreateRS.Errors != null) && (response.SessionCreateRS.Errors.Error != null))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarError(string.Format("{0} - {1}", response.SessionCreateRS.Errors.Error.ErrorCode, response.SessionCreateRS.Errors.Error.ErrorMessage));

                return;
            }

            if ((response.SessionCreateRS.Warnings != null) && (response.SessionCreateRS.Warnings.Warning != null))
            {
                // actualizando respuesta (warnings)
                estatus.RegistrarAlerta(
                        string.Format(
                            "{0} - {1} - {2} - {3}", 
                            response.SessionCreateRS.Warnings.Warning.Code, 
                            response.SessionCreateRS.Warnings.Warning.Type,
                            response.SessionCreateRS.Warnings.Warning.Status,
                            response.SessionCreateRS.Warnings.Warning.ShortText
                        ));
            }

            if (response.SessionCreateRS.status.Equals("Approved", StringComparison.InvariantCultureIgnoreCase))
            {
                // actualizando respuesta
                estatus.Ok = true;

                sesion = Sesion;
                sesion.Token = response.Security.BinarySecurityToken;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public CE_Estatus Execute(out CE_Session sesion)
        {
            SessionCreateRQRequest lsessionCreateRQRequest = null;
            SessionCreateRQResponse lsessionCreateRQResponse = null;

            var lrespuesta = new CE_Estatus();

            sesion = null; 

            try
            {
                // construyendo request
                lsessionCreateRQRequest = new SessionCreateRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    SessionCreateRQ = new SessionCreateRQ
                    {
                        returnContextID = true,
                        returnContextIDSpecified = true,
                        POS = new SessionCreateRQPOS
                        {
                            Source = new SessionCreateRQPOSSource
                            {
                                PseudoCityCode = Sesion.Pseudo
                            }
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<SessionCreatePortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'SessionCreatePortTypeChannel.SessionCreateRQ'", null, new { lsessionCreateRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lsessionCreateRQResponse = lservicio.SessionCreateRQ(lsessionCreateRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'SessionCreatePortTypeChannel.SessionCreateRQ'", null, new { lsessionCreateRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lsessionCreateRQResponse, out lrespuesta, out sesion);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, lsessionCreateRQRequest, lsessionCreateRQResponse, lrespuesta }, CodigoSeguimiento);

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
