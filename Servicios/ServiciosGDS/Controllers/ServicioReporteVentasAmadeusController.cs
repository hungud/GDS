using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Reporte.BoletosEmitidos;
using GDSLib.Amadeus;

namespace ServiciosGDS.Controllers
{
    public class ServicioReporteVentasAmadeusController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("ObtenerReporteVentas")]
        public CE_Response3<CE_ReporteVenta> ObtenerReporteVentas(CE_Request3<RQ_ObtenerReporteVentas> request)
        {
            var lrespuesta = new CE_Response3<CE_ReporteVenta>();

            try
            {
                using (var lreporte = new Reporte(request.Aplicacion, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // ejecutando funcionalidad
                    var lcurrentSesion = request.Sesion;
                    lrespuesta = lreporte.ObtenerReporteVentas(request.Parametros, ref lcurrentSesion);
                    lrespuesta.Sesion = lcurrentSesion;
                }
            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                lrespuesta = new CE_Response3<CE_ReporteVenta>(ex);
            }

            return lrespuesta;
        }


        
        #endregion
    }
}
