using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_DesignatePrinterLLS201;

namespace SabreLib.Herramientas
{
    public sealed class DesignatePrinter : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public DesignatePrinter(EnumAplicaciones application,
                         CE_Session sesion,
                         string codigoSeguimiento,
                         bool muteErrors = true)
            : base(WebServiceAction.DesignatePrinter, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~DesignatePrinter()
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
        private void ProcessResult(DesignatePrinterRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".DesignatePrinterRQ return DesignatePrinterRS null"); 

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
        /// <param name="desfirmarImpresora"></param>
        /// <param name="perfilImpresora"></param>
        /// <returns></returns>
        private CE_Estatus Execute(bool desfirmarImpresora,
                                   string perfilImpresora)
        {
            DesignatePrinterRQRequest ldesignatePrinterRQRequest = null;
            DesignatePrinterRQResponse ldesignatePrinterRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                ldesignatePrinterRQRequest = new DesignatePrinterRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    DesignatePrinterRQ = new DesignatePrinterRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        Profile = new DesignatePrinterRQProfile
                        {
                            Undesignate = desfirmarImpresora,
                            UndesignateSpecified = desfirmarImpresora,
                            Number = perfilImpresora
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<DesignatePrinterPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'DesignatePrinterPortTypeChannel.DesignatePrinterRQ'", new { ldesignatePrinterRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    ldesignatePrinterRQResponse = lservicio.DesignatePrinterRQ(ldesignatePrinterRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'DesignatePrinterPortTypeChannel.DesignatePrinterRQ'", new { ldesignatePrinterRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(ldesignatePrinterRQResponse.DesignatePrinterRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, desfirmarImpresora, perfilImpresora, ldesignatePrinterRQRequest, ldesignatePrinterRQResponse, lrespuesta }, CodigoSeguimiento);

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
        /// <param name="perfilImpresora"></param>
        /// <returns></returns>
        public CE_Estatus AsignarPerfilImpresora(string perfilImpresora)
        {
            return Execute(false, perfilImpresora);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desfirmarImpresora"></param>
        /// <returns></returns>
        public CE_Estatus SalirPerfilImpresora(bool desfirmarImpresora)
        {
            return Execute(desfirmarImpresora, null);
        }

        #endregion
    }
}
