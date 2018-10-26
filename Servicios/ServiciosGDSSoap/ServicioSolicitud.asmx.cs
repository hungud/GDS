using System;
using System.Web.Services;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.TarjetaCredito;
using EntidadesGDS.Solicitudes;
using GDSLib.WEB;

namespace ServiciosGDSSoap
{
    /// <summary>
    /// Summary description for ServicioSolicitud
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioSolicitud : WebService
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
        public CE_Response1<CE_EvaluacionTarjetaPTA> ObtenerDatosTarjetaSolicitud(CE_Request2<RQ_TarjetaCreditoSolicitud> request)
        {
            var lrespuesta = new CE_Response1<CE_EvaluacionTarjetaPTA>();

            try
            {
                using (var lsolicitud = new Solicitud(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lsolicitud.Prepare();

                    CE_EvaluacionTarjetaPTA lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lsolicitud.ObtenerDatosTarjeta(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;

                    // PARA EL PUTO SISTEMA CENTRAL (VB .NET 2003) DE LUZA Y SU PROBLEMA DE PARSEO DE NULLABLES
                    if (lrespuesta.Resultado != null)
                    {
                        lrespuesta.Resultado.IdRegla = -1;
                        lrespuesta.Resultado.IdTarjetaCreditoPTA = -1;
                    }
                }

                // registrando evento
                Bitacora.Current.Debug("RESULTADO", new { lrespuesta }, request.CodigoSeguimiento);

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
