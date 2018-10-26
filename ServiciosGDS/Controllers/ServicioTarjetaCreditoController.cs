using System;
using System.Collections.Generic;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.TarjetaCredito;
using EntidadesGDS.TarjetaCredito.B2BWallet;
using AmadeusLib.B2B;
using AmadeusLib.Utiles;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioTarjetaCreditoController : BaseController
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
        [ActionName("ObtenerReglasTarjetaPTA")]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public CE_Response1<B2BWalletGenerateRS> B2BWalletGenerate(CE_Request2<B2BWalletGenerateRQ> request)
        {
            var lrespuesta = new CE_Response1<B2BWalletGenerateRS>();

            try
            {
                using (var lb2bWallet = new B2BWallet(request.Aplicacion.Value, request.CodigoSeguimiento))
                {
                    B2BWalletGenerateRS lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lb2bWallet.Execute(WebServiceAction.B2BWalletGenerate, request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<B2BWalletGenerateRS>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public CE_Response1<B2BWalletDetailRS> B2BWalleDetail(CE_Request2<B2BWalletDetailRQ> request)
        {
            var lrespuesta = new CE_Response1<B2BWalletDetailRS>();

            try
            {
                using (var lb2bWallet = new B2BWallet(request.Aplicacion.Value, request.CodigoSeguimiento))
                {
                    B2BWalletDetailRS lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lb2bWallet.Execute(WebServiceAction.B2BWalletDetail, request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<B2BWalletDetailRS>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public CE_Response1<B2BWalletUpdateRS> B2BWalletUpdate(CE_Request2<B2BWalletUpdateRQ> request)
        {
            var lrespuesta = new CE_Response1<B2BWalletUpdateRS>();

            try
            {
                using (var lb2bWallet = new B2BWallet(request.Aplicacion.Value, request.CodigoSeguimiento))
                {
                    B2BWalletUpdateRS lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lb2bWallet.Execute(WebServiceAction.B2BWalletUpdate, request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<B2BWalletUpdateRS>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public CE_Response1<B2BWalletDeleteRS> B2BWalletDelete(CE_Request2<B2BWalletDeleteRQ> request)
        {
            var lrespuesta = new CE_Response1<B2BWalletDeleteRS>();

            try
            {
                using (var lb2bWallet = new B2BWallet(request.Aplicacion.Value, request.CodigoSeguimiento))
                {
                    B2BWalletDeleteRS lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lb2bWallet.Execute(WebServiceAction.B2BWalletDelete, request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<B2BWalletDeleteRS>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public CE_Response1<B2BWalletListRS> B2BWalletList(CE_Request2<B2BWalletListRQ> request)
        {
            var lrespuesta = new CE_Response1<B2BWalletListRS>();

            try
            {
                using (var lb2bWallet = new B2BWallet(request.Aplicacion.Value, request.CodigoSeguimiento))
                {
                    B2BWalletListRS lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lb2bWallet.Execute(WebServiceAction.B2BWalletList, request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<B2BWalletListRS>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("RegistroEmisionB2B")]
        public CE_Response1<bool> RegistrarEmisionB2B(CE_Request2<CE_EmisionB2B> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var ltarjetaService = new TarjetaCredito(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    ltarjetaService.Prepare();
                    bool lresultado;
                    lrespuesta.Estatus = ltarjetaService.InsertarInformacionEmisionB2B(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
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
        [ActionName("ActualizarEmisionB2B")]
        public CE_Response1<bool> ActualizarInformacionEmisionB2B(CE_Request2<CE_EmisionB2B> request)
        {
            var lrespuesta = new CE_Response1<bool>();

            try
            {
                using (var ltarjetaService = new TarjetaCredito(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    ltarjetaService.Prepare();
                    bool lresultado;
                    lrespuesta.Estatus = ltarjetaService.ActualizarTarjetaB2BWallet(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
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
        [ActionName("EliminarEmisionesB2B")]
        public CE_Response1<bool> EliminarInformacionEmisionB2B(CE_Request2<List<CE_EmisionB2B>> request)
        {
            var lrespuesta = new CE_Response1<bool>();
            try
            {
                using (var ltarjetaService = new TarjetaCredito(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    ltarjetaService.Prepare();
                    bool lresultado;
                    lrespuesta.Estatus = ltarjetaService.EliminarTarjetasB2BWallet(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
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
        [ActionName("ObtenerEmisionesB2BPendientes")]
        public CE_Response1<List<CE_EmisionB2B>> ObtenerEmisionesB2BPendientes(CE_Request1 request)
        {
            var lrespuesta = new CE_Response1<List<CE_EmisionB2B>>();

            try
            {
                using (var ltarjetaService = new TarjetaCredito(request.Aplicacion.Value, request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    ltarjetaService.Prepare();
                    List<CE_EmisionB2B> lresultado;
                    lrespuesta.Estatus = ltarjetaService.ObtenerEmisionesB2BPendientesActualizacion(out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_EmisionB2B>>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
