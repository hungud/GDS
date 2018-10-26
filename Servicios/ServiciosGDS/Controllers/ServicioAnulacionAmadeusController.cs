using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using GDSLib.Amadeus;

namespace ServiciosGDS.Controllers
{
    public class ServicioAnulacionAmadeusController : BaseController
    {
        //
        // GET: /AnulacionAmadeus/

        [HttpPost]
        [ActionName("AnularBoleto")]
        public CE_Response3<CE_Boleto[]> AnularBoleto(CE_Request3<RQ_AnulacionBoleto> request)
        {
            var lrespuesta = new CE_Response3<CE_Boleto[]>();

            try
            {
                using (var lanulacion = new Anulacion(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    //Preparando e inicializando conexiones
                    lanulacion.Prepare();

                    CE_Boleto[] lresultado = null;
                    CE_Session lcurrentSession = request.Sesion;
                    lrespuesta.Estatus = lanulacion.AnularBoletos(request.Parametros, out lresultado, ref lcurrentSession);
                    lrespuesta.Resultado = lresultado;
                    lrespuesta.Sesion = lcurrentSession;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request });

                lrespuesta = new CE_Response3<CE_Boleto[]>(ex);
            }

            return lrespuesta;
        }

        /*
        [HttpPost]
        [ActionName("ExecuteTST")]
        public CE_Response2 ExecuteTST(CE_Request3<string> request)
        {
            using (var lanulacion = new Anulacion(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
            {
                lanulacion.Prepare();

                CE_Boleto[] lresultado = null;
                CE_Session lcurrentSession = request.Sesion;
                lanulacion.ConsultarTST(request.Parametros, ref lcurrentSession);
            }

            return new CE_Response2();
        }
        */
    }
}
