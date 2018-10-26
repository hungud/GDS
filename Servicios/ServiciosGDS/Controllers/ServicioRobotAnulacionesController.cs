using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using GDSLib.Code.PTA;
using EntidadesGDS.Models.Robot;
using System.Collections.Generic;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioRobotAnulacionesController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("ObtenerPseudosGDS")]
        public CE_Response1<List<CE_PseudoGDS>> ObenerPseudosGDS(CE_Request3<int> request)
        {
            var lrespuesta = new CE_Response1<List<CE_PseudoGDS>>();

            try
            {
                using (var lgeneral = new General(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lgeneral.Prepare();
                    List<CE_PseudoGDS> lresultado;
                    lrespuesta.Estatus = lgeneral.ObtenerPseudosGDS(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<List<CE_PseudoGDS>>(ex);
            }
            return lrespuesta;
        }

        #endregion
    }
}
