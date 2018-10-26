using System;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using EntidadesGDS.Robot;
using EntidadesGDS.Robot.BoletoPendientePago;
using EntidadesGDS.Robot.BoletosOADP;
using EntidadesGDS.Models.Robot;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioBoletoController : BaseController
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
        [ActionName("ObtenerBoletosPendientesPago")]
        public CE_Response1<CE_BoletoFacturado[]> ObtenerBoletosPendientesPago(CE_Request2<RQ_ObtenerBoletosPendientesPago> request)
        {
            var lrespuesta = new CE_Response1<CE_BoletoFacturado[]>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    CE_BoletoFacturado[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.ObtenerBoletosPendientesPago(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_BoletoFacturado[]>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ActualizarEstadoBoletoAnulado")]
        public CE_Response1<bool> ActualizarEstadoBoletoAnulado(CE_Request2<RQ_AnulaBoletoPTA> request)
        {
            var lrespuesta = new CE_Response1<bool>();
            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lboleto.Prepare();
                    bool lresultado;
                    lrespuesta.Estatus = lboleto.GdsActualizarEstadoBoletoAnulado(request.Parametros, out lresultado);
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
        [ActionName("ObtenerBoletosEvaluacionRobotAnulaciones")]
        public CE_Response1<CE_BoletoFacturado[]> ObtenerBoletosEvaluacionRobotAnulaciones(CE_Request2<RQ_ObtenerBoletosPendientesPago> request)
        {
            var lrespuesta = new CE_Response1<CE_BoletoFacturado[]>();
            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    CE_BoletoFacturado[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.ObtenerBoletosEvaluacionRobotAnulaciones(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_BoletoFacturado[]>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ObtenerBoletosSinergia")]
        public CE_Response1<CE_BoletoSinergia[]> ObtenerBoletosSinergia(CE_Request2<RQ_ObtenerBoletosSinergia> request)
        {
            var lrespuesta = new CE_Response1<CE_BoletoSinergia[]>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    CE_BoletoSinergia[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.ObtenerBoletosSinergia(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_BoletoSinergia[]>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ObtenerBoletoFacturado")]
        public CE_Response1<CE_BoletoFacturado> ObtenerBoletoFacturado(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response1<CE_BoletoFacturado>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    CE_BoletoFacturado lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.ObtenerBoletosFacturado(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_BoletoFacturado>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("InsertaCuerpoBoleto")]
        public CE_Response1<bool> InsertaCuerpoBoleto(CE_Request2<RQ_InsertaCuerpoOADP> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.InsertaCuerpoBoleto(request.Parametros, out lresultado);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("ObtenerFileBoleto")]
        public CE_Response1<CE_Boleto[]> ObtenerFileBoleto(CE_Request2<string[]> request)
        {
            var lrespuesta = new CE_Response1<CE_Boleto[]>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    CE_Boleto[] lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.ObtenerFileBoleto(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Boleto[]>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("InsertaTurboPassengerReceipt")]
        public CE_Response1<bool> InsertaTurboPassengerReceipt(CE_Request2<CE_TurboPassengerReceipt> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.InsertaTurboPassengerReceipt(request.Parametros, out lresultado);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("InsertaTurboCCCF")]
        public CE_Response1<bool> InsertaTurboCCCF(CE_Request2<CE_TurboPassengerReceipt> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    bool lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.InsertaTurboCCCF(request.Parametros, out lresultado);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("BuscarCodigoAerolina")]
        public CE_Response1<string> BuscarCodigoAerolina(CE_Request2<CE_TurboPassengerReceipt> request)
        {
            var lrespuesta = new CE_Response1<string>();

            try
            {
                using (var lboleto = new Boleto(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lboleto.Prepare();

                    string lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lboleto.BuscarCodigoAerolina(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<string>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
