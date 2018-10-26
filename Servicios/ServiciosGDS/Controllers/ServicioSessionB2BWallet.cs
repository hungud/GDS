using System;
using System.Collections.Generic;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.TarjetaCredito;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioSessionB2BWalletController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("ObtenerSesion")]
        public CE_Response1<List<CE_SessionB2BWallet>> ObtenerSesion(CE_Request2<int> request)
        {
            var lrespuesta = new CE_Response1<List<CE_SessionB2BWallet>>();
            try
            {
                using (var lsesionB2BWallet = new SesionB2BWallet(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lsesionB2BWallet.Prepare();
                    List<CE_SessionB2BWallet> lresultado;
                    lsesionB2BWallet.ObtenerSesion(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_SessionB2BWallet>>(ex);
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ActualizarSesion")]
        public CE_Response1<bool> ObtenerSesion(CE_Request2<CE_SessionB2BWallet> request)
        {
            var lrespuesta = new CE_Response1<bool>();
            try
            {
                using (var lsesionB2BWallet = new SesionB2BWallet(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lsesionB2BWallet.Prepare();
                    bool lresultado;
                    lsesionB2BWallet.ActualizarSesion(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<bool>(ex);
            }
            return lrespuesta;
        }

        #endregion
    }
}
