using System;
using System.Web.Services;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Facturacion;
using GDSLib.PTA;

namespace ServiciosGDSSoap
{
    /// <summary>
    /// Summary description for ServicioFacturacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioFacturacion : WebService
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
        public CE_Response1<CE_SecuenciaReferencia> ObtenerSecuenciaReferencia(CE_Request1 request)
        {
            var lrespuesta = new CE_Response1<CE_SecuenciaReferencia>();

            try
            {
                using (var lfacturacion = new Facturacion(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lfacturacion.Prepare();

                    CE_SecuenciaReferencia lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lfacturacion.ObtenerSecuenciaReferencia(out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_SecuenciaReferencia>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebMethod]
        public CE_Response1<CE_FacturaCabecera> ObtenerCorrelativoFacturacion(CE_Request2<CE_Facturacion> request)
        {
            var lrespuesta = new CE_Response1<CE_FacturaCabecera>();

            try
            {
                using (var lfacturacion = new Facturacion(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lfacturacion.Prepare();

                    CE_FacturaCabecera lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lfacturacion.ObtenerCorrelativoFacturacion(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_FacturaCabecera>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebMethod]
        public CE_Response1<CE_InterfaceProveedor> ObtenerInterfaceProveedor(CE_Request2<RQ_ObtenerInterfaceProveedor> request)
        {
            var lrespuesta = new CE_Response1<CE_InterfaceProveedor>();

            try
            {
                using (var lfacturacion = new Facturacion(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lfacturacion.Prepare();

                    CE_InterfaceProveedor lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lfacturacion.ObtenerInterfaceProveedor(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_InterfaceProveedor>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebMethod]
        public CE_Estatus ProcesarFacturacion(CE_Request2<CE_Interface> request)
        {
            var lrespuesta = new CE_Estatus();

            try
            {
                using (var lfacturacion = new Facturacion(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lfacturacion.Prepare();

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lfacturacion.ProcesarFacturacion(request.Parametros);
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [WebMethod]
        public CE_Response1<CE_FranquiciaConfig> ObtenerConfiguracionFranquicia(CE_Request2<int> request)
        {
            var lrespuesta = new CE_Response1<CE_FranquiciaConfig>();

            try
            {
                using (var lfacturacion = new Facturacion(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    // preparando ejecución
                    lfacturacion.Prepare();

                    CE_FranquiciaConfig lresultado;

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta.Estatus = lfacturacion.ObtenerConfiguracionFranquicia(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_FranquiciaConfig>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
