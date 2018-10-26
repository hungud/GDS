using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using GDSLib.Sabre;

namespace ServiciosGDS.Controllers
{
    public class ServicioHerramientasController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("CrearSesion")]
        public CE_Response2 CrearSesion(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    CE_Session lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.CrearSesion(out lresultado);
                    lrespuesta.Sesion = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta; 
        }

        [HttpPost]
        [ActionName("CerrarSesion")]
        public CE_Estatus CerrarSesion(CE_Request4 request)
        {
            var lrespuesta = new CE_Estatus();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    CE_Session lresultado;

                    // ejecutando funcionalidad
                    lrespuesta = lherramienta.CerrarSesion(out lresultado);
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

        [HttpPost]
        [ActionName("CambiarContexto")]
        public CE_Response2 CambiarContexto(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    CE_Session lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.CambiarContexto(request.Parametros, out lresultado);
                    lrespuesta.Sesion = (lresultado ?? request.Sesion);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("AsignarPerfilImpresora")]
        public CE_Response2 AsignarPerfilImpresora(CE_Request3<string> request)
        {
            // ejecutando funcionalidad
            return (new Herramienta()).AsignarPerfilImpresora(request);
        }

        [HttpPost]
        [ActionName("SalirPerfilImpresora")]
        public CE_Response2 SalirPerfilImpresora(CE_Request3<bool> request)
        {
            // ejecutando funcionalidad
            return (new Herramienta()).SalirPerfilImpresora(request);
        }

        #region "SabreCommand"

        [HttpPost]
        [ActionName("EjecutarComando")]
        public CE_Response2 EjecutarComando(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.EjecutarComando(request.Parametros.Trim());
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("PseudoActual")]
        public CE_Response2 PseudoActual(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.PseudoActual();
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("TripleadoEn")]
        public CE_Response3<bool> TripleadoEn(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<bool>();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.TripleadoEn(request.Parametros.Trim(), out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response3<bool>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("CambiarPseudo")]
        public CE_Response2 CambiarPseudo(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.CambiarPseudo(request.Parametros.Trim());
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("FinalizarRecuperar")]
        public CE_Response2 FinalizarRecuperar(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.FinalizarRecuperar();
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("IgnorarRecuperar")]
        public CE_Response2 IgnorarRecuperar(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.IgnorarRecuperar();
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("BorrarLineasContables")]
        public CE_Response2 BorrarLineasContables(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.BorrarLineasContables();
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("BorrarLineaPrecioFutura")]
        public CE_Response2 BorrarLineaPrecioFutura(CE_Request4 request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.BorrarLineaPrecioFutura();
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("InsertarFoid")]
        public CE_Response2 InsertarFoid(CE_Request3<CE_Pasajero> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.InsertarFoid(request.Parametros);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ActualizarDk")]
        public CE_Response2 ActualizarDk(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.ActualizarDk(request.Parametros.Trim());
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ActualizarSubCodigo")]
        public CE_Response2 ActualizarSubCodigo(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, null, request.Sesion))
                {
                    // preparando ejecución
                    lherramienta.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lherramienta.ActualizarSubCodigo(request.Parametros.Trim());
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        #endregion

        #endregion
    }
}
