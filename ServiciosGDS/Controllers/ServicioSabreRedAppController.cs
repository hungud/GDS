using System;
using System.IO;
using System.Text;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using EntidadesGDS.Models.General;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioSabreRedAppController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("ReceptorEmisionAutonoma")]
        public CE_Response1<bool> ReceptorEmisionAutonoma(CE_Request2<string> request)
        {
            var lrespuesta = new CE_Response1<bool>();
            try
            {
                using (var lservicio = new SabreRedApp(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    bool resultado;
                    lrespuesta.Estatus = lservicio.EnviarConfirmacionUsoEAU(request.Parametros, out resultado);
                    lrespuesta.Resultado = resultado;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<bool>(ex) { Resultado = false };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("AlmacenarLog")]
        public CE_Response1<bool> GrabarLog(CE_Request2<CE_ArchivoExterno> request)
        {
            var lrespuesta = new CE_Response1<bool>();
            try
            {
                using (var lservicio = new SabreRedApp(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    bool lresultado;
                    lrespuesta.Estatus = lservicio.AlmacenarArchivosLog(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<bool>(ex) { Resultado = false };
            }
            return lrespuesta;
        }


        [HttpPost]
        [ActionName("ObtenerInformacionSesion")]
        public CE_Response1<CE_InformacionSesion> ObtenerInformacionSesion(CE_Request2<string> request)
        {
            var lrespuesta = new CE_Response1<CE_InformacionSesion>();
            try
            {
                using (var lservicio = new SabreRedApp(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lservicio.Prepare();
                    CE_InformacionSesion linformacionSesion;
                    lrespuesta.Estatus = lservicio.ObtenerInformacionSesion(request.Parametros, out linformacionSesion);
                    lrespuesta.Resultado = linformacionSesion;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<CE_InformacionSesion>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("RegistrarInformacionSesion")]
        public CE_Response1<string> RegistrarInformacionSesion(CE_Request3<CE_InformacionSesion> request)
        {
            var lrespuesta = new CE_Response1<string>();
            try
            {
                using (var lservicio = new SabreRedApp(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lservicio.Prepare();
                    string uuid;
                    lrespuesta.Estatus = lservicio.RegistrarInformacionSesion(request.Parametros, out uuid, false);
                    lrespuesta.Resultado = uuid;
                }
            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                // actualizando respuesta
                lrespuesta = new CE_Response1<string>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        #endregion
    }
}