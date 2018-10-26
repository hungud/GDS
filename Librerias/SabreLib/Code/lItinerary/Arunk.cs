using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_ArunkLLS_202;

namespace SabreLib.lItinerary
{
    public sealed class Arunk : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public Arunk(EnumAplicaciones application,
                     CE_Session sesion,
                     string codigoSeguimiento,
                     bool muteErrors = true)
            : base(WebServiceAction.ArunkService, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~Arunk()
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
        private void ProcessResult(ARUNK_RS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".ARUNK_RQ return ARUNK_RS null");

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
        /// <returns></returns>
        public CE_Estatus Execute()
        {
            ARUNK_RQRequest larunkRQRequest = null;
            ARUNK_RQResponse larunkRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                larunkRQRequest = new ARUNK_RQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    ARUNK_RQ = new ARUNK_RQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<ARUNK_PortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'ARUNK_PortTypeChannel.ARUNK_RQ'", null, new { larunkRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    larunkRQResponse = lservicio.ARUNK_RQ(larunkRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'ARUNK_PortTypeChannel.ARUNK_RQ'", null, new { larunkRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(larunkRQResponse.ARUNK_RS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, larunkRQRequest, larunkRQResponse, lrespuesta }, CodigoSeguimiento);

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
