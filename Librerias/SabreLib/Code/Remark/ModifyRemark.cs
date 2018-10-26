using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Comentario;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_ModifyRemarkLLS_212;

namespace SabreLib.Remark
{
    public class ModifyRemark : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
    {
        // =============================
        // emnumeraciones

        #region "emnumeraciones"

        internal enum EnumModifyRemarkType
        {
            Delete = 1,
            DeleteRange = 2,
            UpdateText = 3,
            UpdatePayment = 3
        }

        #endregion

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
        public ModifyRemark(EnumAplicaciones application,
                            CE_Session sesion,
                            string codigoSeguimiento,
                            bool muteErrors = true)
            : base(WebServiceAction.ModifyRemark, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~ModifyRemark()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "Prepare"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        private ModifyRemarkRQRemarkInfo PrepareModifyRemarkRQRequest(CE_Comentario[] comentarios)
        {
            return new ModifyRemarkRQRemarkInfo
            {
                Remark = comentarios.Select(c => new ModifyRemarkRQRemarkInfoRemark
                {
                    Number = c.Id.ToString(),
                    Code = (string.IsNullOrWhiteSpace(c.Codigo) ? null : c.Codigo),
                    Type = ((ModifyRemarkRQRemarkInfoRemarkType)c.Tipo),
                    Text = c.Texto
                }).ToArray()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idsComentarios"></param>
        /// <returns></returns>
        private ModifyRemarkRQRemarkInfo PrepareModifyRemarkRQRequest(int[] idsComentarios)
        {
            return new ModifyRemarkRQRemarkInfo
            {
                Remark = idsComentarios.Select(n => new ModifyRemarkRQRemarkInfoRemark
                {
                    Number = n.ToString()
                }).ToArray()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComentarioDesde"></param>
        /// <param name="idComentarioHasta"></param>
        /// <returns></returns>
        private ModifyRemarkRQRemarkInfo PrepareModifyRemarkRQRequest(int idComentarioDesde,
                                                                      int idComentarioHasta)
        {
            return new ModifyRemarkRQRemarkInfo
            {
                Remark = new[]
                {
                    new ModifyRemarkRQRemarkInfoRemark
                    {
                        Number = idComentarioDesde.ToString(),
                        EndNumber = idComentarioHasta.ToString()
                    }
                }
            };
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void ProcessResult(ModifyRemarkRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".ModifyRemarkRQ return ModifyRemarkRS null");

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
        /// <param name="tipoOperacion"></param>
        /// <param name="comentarios"></param>
        /// <param name="idsComentarios"></param>
        /// <returns></returns>
        private CE_Estatus Execute(EnumModifyRemarkType tipoOperacion,
                                   CE_Comentario[] comentarios,
                                   int[] idsComentarios)
        {
            ModifyRemarkRQRequest lmodifyRemarkRQRequest = null;
            ModifyRemarkRQResponse lmodifyRemarkRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lmodifyRemarkRQRequest = new ModifyRemarkRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    ModifyRemarkRQ = new ModifyRemarkRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version
                    }
                };

                // evaluando tipo de operación que se realizara
                switch (tipoOperacion)
                {
                    case EnumModifyRemarkType.Delete:
                        lmodifyRemarkRQRequest.ModifyRemarkRQ.RemarkInfo = PrepareModifyRemarkRQRequest(idsComentarios);
                        break;

                    case EnumModifyRemarkType.DeleteRange:
                        lmodifyRemarkRQRequest.ModifyRemarkRQ.RemarkInfo = PrepareModifyRemarkRQRequest(idsComentarios[0], idsComentarios[1]);
                        break;

                    case EnumModifyRemarkType.UpdateText:
                        lmodifyRemarkRQRequest.ModifyRemarkRQ.RemarkInfo = PrepareModifyRemarkRQRequest(comentarios);
                        break;
                }

                using (var lservicio = Configuracion.GetServiceModelClient<ModifyRemarkPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'ModifyRemarkPortTypeChannel.ModifyRemarkRQ'", null, new { lmodifyRemarkRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lmodifyRemarkRQResponse = lservicio.ModifyRemarkRQ(lmodifyRemarkRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'ModifyRemarkPortTypeChannel.ModifyRemarkRQ'", null, new { lmodifyRemarkRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lmodifyRemarkRQResponse.ModifyRemarkRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, tipoOperacion, comentarios, idsComentarios, lmodifyRemarkRQRequest, lmodifyRemarkRQResponse, lrespuesta }, CodigoSeguimiento);

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
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public CE_Estatus Actualizar(CE_Comentario[] comentarios)
        {
            return Execute(EnumModifyRemarkType.UpdateText, comentarios, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idsComentarios"></param>
        /// <returns></returns>
        public CE_Estatus Borrar(int[] idsComentarios)
        {
            return Execute(EnumModifyRemarkType.Delete, null, idsComentarios);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComentarioDesde"></param>
        /// <param name="idComentarioHasta"></param>
        /// <returns></returns>
        public CE_Estatus BorrarPorRango(int idComentarioDesde,
                                         int idComentarioHasta)
        {
            return Execute(EnumModifyRemarkType.DeleteRange, null, new[] { idComentarioDesde, idComentarioHasta });
        }

        #endregion
    }
}
