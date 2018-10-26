using System;
using System.IO;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Incidencia;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioIncidenciaBitacoraController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("RegistrarIncidenciaBitacora")]
        public CE_Response1<bool> RegistrarIncidenciaBitacora(CE_Request2<CE_BitacoraCC> request)
        {
            var lrespuesta = new CE_Response1<bool>();
            try
            {
                using (var lincidenciaBitacoraCC = new IncidenciaBitacoraCC(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lincidenciaBitacoraCC.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lincidenciaBitacoraCC.RegistrarIncidenciaBitacoraCC(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                    if (lresultado) 
                    {
                        lincidenciaBitacoraCC.EnviarConfirmacionRegistro(request.Parametros, obtenerPlantilla());
                    }
                }
            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                // actualizando respuesta
                lrespuesta = new CE_Response1<bool>(ex) { Resultado = false };
            }

            return lrespuesta;
        }
        #endregion

        private string obtenerPlantilla() {
            var lpathPlantilla = AppDomain.CurrentDomain.BaseDirectory + @"Recursos\Plantillas\PlantillaCorreoBitacora.html";
            return string.Join("\n", File.ReadAllLines(lpathPlantilla));
        }
    }
}
