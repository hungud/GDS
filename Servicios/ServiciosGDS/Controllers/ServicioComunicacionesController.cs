using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Servicio;
using ServicioLib;

namespace ServiciosGDS.Controllers
{
    public class ServicioComunicacionesController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("SendShortMessage")]
        public CE_Estatus SendShortMessage(CE_Request2<RQ_SendShortMessage> request)
        {
            var lrespuesta = new CE_Estatus();

            try
            {
                using (var lshortMessage = new ShortMessage(request.CodigoSeguimiento))
                {
                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lshortMessage.Send(request.Parametros);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("SendEmailMessage")]
        public CE_Estatus SendEmailMessage(CE_Request2<RQ_SendEmailMessage> request)
        {
            var lrespuesta = new CE_Estatus();

            try
            {
                using (var lemailMessage = new EmailMessage(request.CodigoSeguimiento))
                {
                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lemailMessage.Send(request.Parametros);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
