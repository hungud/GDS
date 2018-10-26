using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Comentario;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_AddRemarkLLS_211;

namespace SabreLib.Remark
{
    public sealed class AddRemark : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public AddRemark(EnumAplicaciones application,
                         CE_Session sesion,
                         string codigoSeguimiento,
                         bool muteErrors = true)
            : base(WebServiceAction.AddRemark, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~AddRemark()
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
        private void ProcessResult(AddRemarkRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".AddRemarkRQ return AddRemarkRS null");

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
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public CE_Estatus Execute(CE_Comentario[] comentarios)
        {
            AddRemarkRQRequest laddRemarkRQRequest = null;
            AddRemarkRQResponse laddRemarkRQResponse = null;

            CE_Estatus lrespuesta = null;

            try
            {
                // construyendo request
                laddRemarkRQRequest = new AddRemarkRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    AddRemarkRQ = new AddRemarkRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        RemarkInfo = new AddRemarkRQRemarkInfo
                        {
                            Remark = comentarios
                                .Where(r => (!string.IsNullOrWhiteSpace(r.Texto)))
                                    .Select(r => new AddRemarkRQRemarkInfoRemark
                                    {
                                        Type = ((AddRemarkRQRemarkInfoRemarkType) Enum.Parse(typeof(AddRemarkRQRemarkInfoRemarkType), r.Tipo.ToString())),
                                        Code = r.Codigo,
                                        Text = r.Texto
                                    }).ToArray()
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<AddRemarkPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'AddRemarkPortTypeChannel.AddRemarkRQ'", null, new { laddRemarkRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    laddRemarkRQResponse = lservicio.AddRemarkRQ(laddRemarkRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'AddRemarkPortTypeChannel.AddRemarkRQ'", null, new { laddRemarkRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(laddRemarkRQResponse.AddRemarkRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, comentarios, laddRemarkRQRequest, laddRemarkRQResponse, lrespuesta }, CodigoSeguimiento);

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
