using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Queue;
using GDSLib.Sabre;
using GDSLib.Code.Amadeus;

namespace ServiciosGDS.Controllers
{
    public class ServicioInstantSearchController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("Execute")]
        public CE_Response3<bool> Execute(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<bool>();
            try
            {
                using (var linstantSearch = new InstantSearch(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    var lcurrentSession = request.Sesion;
                    lrespuesta.Estatus = linstantSearch.Obtener(request.Parametros, ref lcurrentSession);
                    lrespuesta.Sesion = lcurrentSession;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request });
                lrespuesta = new CE_Response3<bool>(ex);
            }
            return lrespuesta;
        }

        

        #endregion
    }
}