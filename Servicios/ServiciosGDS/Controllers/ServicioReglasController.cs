using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Reglas;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioReglasController : BaseController
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
        [ActionName("NoPermiteTransportador")]
        public CE_Response1<bool> NoPermiteTransportador(CE_Request2<RQ_ObtenerReglasEmision> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lreglasEmision = new ReglasEmision(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lreglasEmision.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreglasEmision.NoPermiteTransportador(request.Parametros, out lresultado);
                    lrespuesta.Resultado = ((!lrespuesta.Estatus.Ok) || lresultado); // -- DEBE DE DEVOLVER "TRUE" EN CASO DE ERROR SIEMPRE --
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta -- DEBE DE DEVOLVER "TRUE" EN CASO DE ERROR SIEMPRE --
                lrespuesta = new CE_Response1<bool>(ex) { Resultado = true };
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ObtenerListaPermiteTransportador")]
        public CE_Response1<CE_ReglaEmision[]> ObtenerListaPermiteTransportador(CE_Request2<CE_ReglaEmision> request)
        {
            var lrespuesta = new CE_Response1<CE_ReglaEmision[]>();

            try
            {
                using (var lreglasEmision = new ReglasEmision(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lreglasEmision.Prepare();

                    CE_ReglaEmision[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreglasEmision.ObtenerListaPermiteTransportador(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_ReglaEmision[]>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("AnadirPermiteTransportador")]
        public CE_Response1<bool> AnadirPermiteTransportador(CE_Request2<CE_ReglaEmision> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lreglasEmision = new ReglasEmision(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lreglasEmision.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreglasEmision.AnadirPermiteTransportador(request.Parametros, out lresultado);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("EliminarPermiteTransportador")]
        public CE_Response1<int> EliminarPermiteTransportador(CE_Request2<CE_ReglaEmision[]> request)
        {
            var lrespuesta = new CE_Response1<int>();

            try
            {
                using (var lreglasEmision = new ReglasEmision(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lreglasEmision.Prepare();

                    int lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreglasEmision.EliminarPermiteTransportador(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<int>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
