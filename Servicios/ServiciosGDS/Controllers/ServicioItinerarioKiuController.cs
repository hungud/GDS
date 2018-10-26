using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;

using GDSLib.Kiu;


namespace ServiciosGDS.Controllers
{
    public class ServicioItinerarioKiuController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("Obtener")]
        public CE_Response3<CE_Reserva> Obtener(CE_Request2<string> request)
        {
            var lrespuesta = new CE_Response3<CE_Reserva>();

            try
            {
                using (var litinerario = new Itinerario(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
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

        #endregion

    }
}
