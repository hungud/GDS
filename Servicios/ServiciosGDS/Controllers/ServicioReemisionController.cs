using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using EntidadesGDS.General;
using GDSLib.Sabre;

namespace ServiciosGDS.Controllers
{
    public class ServicioReemisionController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        /*
        [HttpPost]
        [ActionName("ObtenerCompletarCotizarReemitir")]
        public CE_Response3<CE_Boleto[]> ObtenerCompletarCotizarReemitir(CE_Request3<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response3<CE_Boleto[]>();

            try
            {
                using (var lreemision = new Reemision(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    lreemision.Prepare();

                    CE_Boleto[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreemision.ObtenerCompletarCotizarReemitir(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Boleto[]>(ex);
            }

            return lrespuesta;
        }
        */

        [HttpPost]
        [ActionName("EjecutarModuloComercial")]
        public CE_Response3<CE_Reserva> EjecutarModuloComercial(CE_Request3<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response3<CE_Reserva>();

            try
            {
                using (var lreemision = new Reemision(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    lreemision.Prepare();

                    CE_Reserva lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreemision.EjecutarModuloComercial(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Reserva>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ConfirmarPQ")]
        public CE_Response2 ConfirmarPQ(CE_Request3<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Reemision(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ConfirmarPQ(request.Parametros);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerCompletarReemitir")]
        public CE_Response3<CE_Boleto[]> ObtenerCompletarReemitir(CE_Request3<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response3<CE_Boleto[]>();

            try
            {
                using (var lreemision = new Reemision(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    lreemision.Prepare();

                    CE_Boleto[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreemision.ObtenerCompletarReemitir(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Boleto[]>(ex);
            }

            return lrespuesta;
        }
        
        #endregion
    }
}
