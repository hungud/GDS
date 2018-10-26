using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioGeneralController : BaseController
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
        [ActionName("PreCompletarReserva")]
        public CE_Response1<CE_Reserva> PreCompletarReserva(CE_Request2<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response1<CE_Reserva>();

            try
            {
                using (var lgeneral = new General(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lgeneral.Prepare();

                    CE_Reserva lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lgeneral.PreCompletarReserva(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Reserva>(ex);
            }

            return lrespuesta;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("PreCompletarCliente")]
        public CE_Response1<CE_Cliente> PreCompletarCliente(CE_Request2<CE_Cliente> request)
        {
            var lrespuesta = new CE_Response1<CE_Cliente>();

            try
            {
                using (var lgeneral = new General(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lgeneral.Prepare();

                    CE_Cliente lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lgeneral.PreCompletarCliente(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Cliente>(ex);
            }

            return lrespuesta;
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ProcesandoComisionesFees")]
        public CE_Response1<CE_Reserva> ProcesandoComisionesFees(CE_Request2<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response1<CE_Reserva>();

            try
            {
                using (var lcomisionFee = new ComisionFee(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lcomisionFee.Prepare();

                    CE_Reserva lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lcomisionFee.ProcesandoComisionesFees(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Reserva>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
