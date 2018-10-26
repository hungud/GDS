using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using GDSLib.Code.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioMiscelaneosController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("MostrarAppEnMantenimiento")]
        public CE_Response1<bool> MostrarMensajeEnMantenimiento(CE_Request1 request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lmiscelaneo = new Miscelaneo(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lmiscelaneo.MostrarMensajeEnMantenimiento(out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<bool>(ex);
            }
            return lrespuesta;
        }


        [HttpPost]
        [ActionName("CredencialesSIT")]
        public CE_Response1<string> GetCredentialsSIT(CE_Request1 request)
        {
            var lrespuesta = new CE_Response1<string>();

            try
            {
                using (var lmiscelaneo = new Miscelaneo(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    string lresultado;
                    lrespuesta.Estatus = lmiscelaneo.GetCredencialesSIT(out lresultado);
                    lrespuesta.Resultado = lresultado;
                }
            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<string>();
            }
            return lrespuesta;
        }
        #endregion
    }
}
