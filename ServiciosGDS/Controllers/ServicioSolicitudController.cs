using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.TarjetaCredito;
using EntidadesGDS.Solicitudes;
using GDSLib.WEB;

namespace ServiciosGDS.Controllers
{
    public class ServicioSolicitudController : BaseController
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
        [ActionName("ObtenerDatosTarjetaSolicitud")]
        public CE_Response1<CE_EvaluacionTarjetaPTA> ObtenerDatosTarjetaSolicitud(CE_Request2<RQ_TarjetaCreditoSolicitud> request)
        {
            var lrespuesta = new CE_Response1<CE_EvaluacionTarjetaPTA>();

            try
            {
                using (var lsolicitud = new Solicitud(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lsolicitud.Prepare();

                    CE_EvaluacionTarjetaPTA lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lsolicitud.ObtenerDatosTarjeta(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_EvaluacionTarjetaPTA>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PoseePermisoParaRemitir")]
        public CE_Response1<bool> PoseePermisoParaRemitir(CE_Request2<string> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lsolicitud = new Solicitud(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lsolicitud.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lsolicitud.PoseePermisoParaRemitir(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<bool>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
