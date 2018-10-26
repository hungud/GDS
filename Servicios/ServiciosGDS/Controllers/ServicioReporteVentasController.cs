using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Reporte.BoletosEmitidos;
using GDSLib.Sabre;

namespace ServiciosGDS.Controllers
{
    public class ServicioReporteVentasController : BaseController
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
                using (var lreporte = new Reporte(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    // ejecutando funcionalidad
                    return lreporte.ObtenerReporteVentas(request.Parametros);
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
