using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using GDSLib.Amadeus;


namespace ServiciosGDS.Controllers
{
    public class ServicioHerramientasAmadeusController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("Ejecutarcomando")]
        public CE_Response2 EjecutarComando(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response2();
            try
            {
                using (var lherramienta = new Herramienta(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    var lcurrentSession = request.Sesion;
                    lrespuesta.Estatus = lherramienta.Ejecutar(request.Parametros, ref lcurrentSession);
                    lrespuesta.Sesion = lcurrentSession;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response2(ex);
            }
            return lrespuesta;
        }

        #endregion
    }
}
