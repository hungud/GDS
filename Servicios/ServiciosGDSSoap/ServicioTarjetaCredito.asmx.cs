using System;
using System.Web.Services;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.TarjetaCredito;
using GDSLib.PTA;

namespace ServiciosGDSSoap
{
    /// <summary>
    /// Summary description for ServicioTarjetaCredito
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioTarjetaCredito : WebService
    {
        // =============================
        // metodos web

        #region "metodos web"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebMethod]
        public CE_Response1<CE_EvaluacionTarjetaPTA> ObtenerReglasTarjetaPTA(CE_Request2<RQ_ObtenerReglasTarjetaPTA> request)
        {
            var lrespuesta = new CE_Response1<CE_EvaluacionTarjetaPTA>();

            try
            {
                using (var ltarjetaCredito = new TarjetaCredito(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    ltarjetaCredito.Prepare();

                    CE_EvaluacionTarjetaPTA lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = ltarjetaCredito.ObtenerReglasTarjetaPta(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_EvaluacionTarjetaPTA>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
