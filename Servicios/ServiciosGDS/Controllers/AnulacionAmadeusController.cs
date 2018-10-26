using CustomLog;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using GDSLib.Code.Amadeus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ServiciosGDS.Controllers
{
    public class AnulacionAmadeusController : BaseController
    {
        //
        // GET: /AnulacionAmadeus/

        [HttpPost]
        [ActionName("AnularBoleto")]
        public CE_Response3<bool> AnularBoleto(CE_Request3<RQ_AnulacionBoleto> request)
        {
            var lrespuesta = new CE_Response3<bool>();

            try
            {
                using (var lanulacion = new Anulacion(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    CE_Boleto[] boletos = null;
                    CE_Session lcurrentSession = request.Sesion;
                    lrespuesta.Estatus = lanulacion.AnularBoletos(request.Parametros, out boletos, ref lcurrentSession);

                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request });

                lrespuesta = new CE_Response3<bool>(ex);
            }

            return lrespuesta;
        }

    }
}
