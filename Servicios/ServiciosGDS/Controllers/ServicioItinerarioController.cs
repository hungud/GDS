using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using EntidadesGDS.Comentario;
using EntidadesGDS.Itinerario;
using EntidadesGDS.General;
using EntidadesGDS.Facturacion;
using GDSLib.Sabre;

namespace ServiciosGDS.Controllers
{
    public class ServicioItinerarioController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        // CAMBIAR LA FIRMA
        [HttpPost]
        [ActionName("Obtener")]
        public CE_Response3<CE_Reserva> Obtener(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_Reserva>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Reserva lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.Obtener(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Reserva>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerCompletar")]
        public CE_Response3<CE_Reserva> ObtenerCompletar(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_Reserva>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Reserva lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.Obtener(request.Parametros, out lresultado, true);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Reserva>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerLineasContables")]
        public CE_Response3<CE_LineaContable[]> ObtenerLineasContables(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_LineaContable[]>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_LineaContable[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ObtenerLineasContables(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_LineaContable[]>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerTarifasAlmacenadas")]
        public CE_Response3<CE_Cotizacion[]> ObtenerTarifasAlmacenadas(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_Cotizacion[]>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Cotizacion[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ObtenerTarifasAlmacenadas(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Cotizacion[]>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("DesplegarBoleto")]
        public CE_Response3<CE_Boleto> DesplegarBoleto(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_Boleto>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Boleto lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.DesplegarBoleto(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Boleto>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("AnadirArunk")]
        public CE_Response2 AnadirArunk(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.AnadirArunk();
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

        #region "Comentarios"

        [HttpPost]
        [ActionName("ObtenerComentarios")]
        public CE_Response3<CE_Comentario[]> ObtenerComentarios(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_Comentario[]>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Comentario[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ObtenerComentarios(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Comentario[]>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("AnadirComentarios")]
        public CE_Response2 AnadirComentarios(CE_Request3<CE_Comentario[]> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.AnadirComentarios(request.Parametros);
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
        [ActionName("ActualizarComentarios")]
        public CE_Response2 ActualizarComentarios(CE_Request3<CE_Comentario[]> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ActualizarComentarios(request.Parametros);
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
        [ActionName("BorrarComentarios")]
        public CE_Response2 BorrarComentarios(CE_Request3<int[]> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.BorrarComentarios(request.Parametros);
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
        [ActionName("BorrarComentariosPorRango")]
        public CE_Response2 BorrarComentariosPorRango(CE_Request3<RQ_BorrarRango> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.BorrarComentariosPorRango(request.Parametros);
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

        #endregion

        #region "Docs & Foids"

        [HttpPost]
        [ActionName("VerificarDocsFoids")]
        public CE_Response3<CE_Pasajero> VerificarDocsFoids(CE_Request3<string[]> request)
        {
            var lrespuesta = new CE_Response3<CE_Pasajero>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Pasajero lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.VerificarDocsFoids(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Pasajero>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ActualizarFoidsAndDocs")]
        public CE_Response2 ActualizarFoidsAndDocs(CE_Request3<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ActualizarFoidsAndDocs(request.Parametros);
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
        [ActionName("ActualizarPasajeros")]
        public CE_Response2 ActualizarPasajeros(CE_Request3<RQ_ActualizarPasajeros> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ActualizarPasajeros(request.Parametros);
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

        #endregion

        [HttpPost]
        [ActionName("ObtenerCotizacion")]
        public CE_Response3<CE_Cotizacion> ObtenerCotizacion(CE_Request3<RQ_ObtenerCotizaciones> request)
        {
            var lrespuesta = new CE_Response3<CE_Cotizacion>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Cotizacion lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = litinerario.ObtenerCotizacion(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_Cotizacion>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}