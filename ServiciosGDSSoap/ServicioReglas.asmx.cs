using System;
using System.Web.Services;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Reglas;
using GDSLib.PTA;

namespace ServiciosGDSSoap
{
    /// <summary>
    /// Summary description for ServicioReglas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioReglas : WebService
    {
        // =============================
        // metodos web

        #region "metodos web"
        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebMethod]
        public CE_Response1<bool> NoPermiteTransportador(CE_Request2<RQ_ObtenerReglasEmision> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lreglasEmision = new ReglasEmision(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lreglasEmision.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lreglasEmision.NoPermiteTransportador(request.Parametros, out lresultado);
                    lrespuesta.Resultado = ((!lrespuesta.Estatus.Ok) || lresultado); // -- DEBE DE DEVOLVER "TRUE" EN CASO DE ERROR SIEMPRE --
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta -- DEBE DE DEVOLVER "TRUE" EN CASO DE ERROR SIEMPRE --
                lrespuesta = new CE_Response1<bool>(ex) { Resultado = true };
            }

            return lrespuesta;
        }
        */

        #endregion
    }
}
