using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Models.Itinerario;

using GDSLib.Amadeus;

namespace ServiciosGDS.Controllers
{
    public class ServicioItinerarioAmadeusController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("Obtener")]
        public CE_Response3<CE_Reserva> Obtener(CE_Request3<RQ_ObtenerReserva> request)
        {
            var lrespuesta = new CE_Response3<CE_Reserva>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    //// preparando ejecución
                    //litinerario.Prepare();

                    CE_Reserva lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    var lcurrentSession = request.Sesion;

                    lrespuesta.Estatus = litinerario.Obtener(request.Parametros, out lresultado, ref lcurrentSession);
                    lrespuesta.Resultado = lresultado;
                    lrespuesta.Sesion = lcurrentSession;
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
        [ActionName("ModuloComercialPostVenta")]
        public CE_Response1<CE_Reserva[]> ModuloComercialPostVenta(CE_Request2<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response1<CE_Reserva[]>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Reserva[] lresultado;

                    lrespuesta.Estatus = litinerario.ModuloComercialPostVenta(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Reserva[]>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("CancelarItinerario")]
        public CE_Response3<CE_Reserva> CancelarItinerario(CE_Request3<RQ_PnrCancel> request)
        {
            var lrespuesta = new CE_Response3<CE_Reserva>();
            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    litinerario.Prepare();

                    CE_Reserva lresultado;
                    var lcurrentSession = request.Sesion;
                    lrespuesta.Estatus = litinerario.CancelarItinerario(request.Parametros, out lresultado, ref lcurrentSession);
                    lrespuesta.Resultado = lresultado;
                    lrespuesta.Sesion = lcurrentSession;
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

        #endregion
    }
}
