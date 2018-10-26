using CustomLog;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using GDSLib.Sabre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ServiciosGDS.Controllers
{
    public class ServicioAnulacionSabreController : BaseController
    {

        [HttpPost]
        [ActionName("AnularBoleto")]
        public CE_Response3<CE_Boleto[]> AnularBoleto(CE_Request3<RQ_AnulacionBoleto> request)
        {
            var lrespuesta = new CE_Response3<CE_Boleto[]>();

            try
            {
                using (var lanulacion = new Anulacion(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    //Preparando e inicializando conexiones
                    lanulacion.Prepare();

                    CE_Boleto[] lresultado = null;
                    lrespuesta.Estatus = lanulacion.AnularBoletos(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request });

                lrespuesta = new CE_Response3<CE_Boleto[]>(ex);
            }

            return lrespuesta;
        }

    }
}