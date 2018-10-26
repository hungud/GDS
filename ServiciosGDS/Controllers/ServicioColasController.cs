using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Queue;
using GDSLib.Sabre;

namespace ServiciosGDS.Controllers
{
    public class ServicioColasController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("ObtenerListadoReserva")]
        public CE_Response3<CE_QueueAccess> ObtenerListadoReserva(CE_Request3<RQ_QueueAccess> request)
        {
            var lrespuesta = new CE_Response3<CE_QueueAccess>();

            try
            {
                using (var lcola = new Cola())
                {
                    // ejecutando funcionalidad
                    lrespuesta = lcola.ObtenerListadoReserva(request);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request });

                lrespuesta = new CE_Response3<CE_QueueAccess>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}