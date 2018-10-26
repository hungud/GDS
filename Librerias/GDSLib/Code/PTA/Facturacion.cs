using System;

using CoreWebLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Facturacion;
using BaseDatosLib.Procedimientos;
using BaseDatosLib.Paquetes;

using GDSLib.Base;

namespace GDSLib.PTA
{
    public sealed class Facturacion : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public Facturacion(string codigoSeguimiento,
                           string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public Facturacion(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~Facturacion()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="punto"></param>
        /// <param name="idSucursal"></param>
        /// <param name="tipoComprobante"></param>
        /// <param name="facturaCabecera"></param>
        /// <returns></returns>
        internal void ObtenerCorrelativoFacturacion(int punto,
                                                    int idSucursal,
                                                    EnumTipoComprobanteFacturacion tipoComprobante,
                                                    out CE_FacturaCabecera facturaCabecera)
        {
            using (var lgdsIntegracionM = new GdsIntegracionM(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lgdsIntegracionM.ObtCorrelativoFacturacion'", new { punto, idSucursal, tipoComprobante }, CodigoSeguimiento);

                // buscando correlativo de facturación
                facturaCabecera = lgdsIntegracionM.ObtCorrelativoFacturacion(
                    Conexion, 
                    Esquema,
                    punto,
                    idSucursal,
                    tipoComprobante);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lgdsIntegracionM.ObtCorrelativoFacturacion'", new { facturaCabecera }, CodigoSeguimiento);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudoConsulta"></param>
        /// <param name="pseudoEmision"></param>
        /// <param name="interfaceProveedor"></param>
        /// <returns></returns>
        internal void ObtenerInterfaceProveedor(string pseudoConsulta,
                                                string pseudoEmision,
                                                out CE_InterfaceProveedor interfaceProveedor)
        {
            using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerInterfaceProv'", new { pseudoConsulta, pseudoEmision }, CodigoSeguimiento);

                // buscando interface de proveedor
                interfaceProveedor = lpkgGdsModuloPnrPta.GdsObtenerInterfaceProv(Conexion, Esquema, pseudoConsulta, pseudoEmision);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerInterfaceProv'", new { interfaceProveedor }, CodigoSeguimiento);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerSecuenciaReferencia(out CE_SecuenciaReferencia resultado,
                                                     bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lupGetInterfaceNumeracion = new UpGetInterfaceNumeracion(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lupGetInterfaceNumeracion.Ejecutar'", CodigoSeguimiento);

                    // buscando secuencia y referencia
                    resultado = lupGetInterfaceNumeracion.Ejecutar(Conexion, Esquema);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lupGetInterfaceNumeracion.Ejecutar'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerCorrelativoFacturacion(CE_Facturacion parametros,
                                                        out CE_FacturaCabecera resultado,
                                                        bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                CE_FacturaCabecera lfacturaCabecera;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ObtenerCorrelativoFacturacion'", new { parametros.Punto, parametros.IdSucursal, parametros.Cabecera.TipoComprobante }, CodigoSeguimiento);

                // obteniendo correlativo facturación
                ObtenerCorrelativoFacturacion(parametros.Punto.Value, parametros.IdSucursal.Value, parametros.Cabecera.TipoComprobante.Value, out lfacturaCabecera);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ObtenerCorrelativoFacturacion'", new { lfacturaCabecera }, CodigoSeguimiento);

                // actualizando respuesta
                resultado = lfacturaCabecera;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerInterfaceProveedor(RQ_ObtenerInterfaceProveedor parametros,
                                                    out CE_InterfaceProveedor resultado,
                                                    bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                CE_InterfaceProveedor linterfaceProveedor;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ObtenerInterfaceProveedor'", new { parametros.PseudoConsulta, parametros.PseudoEmision }, CodigoSeguimiento);

                // obteniendo interface proveedor
                ObtenerInterfaceProveedor(parametros.PseudoConsulta, parametros.PseudoEmision, out linterfaceProveedor);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ObtenerInterfaceProveedor'", new { linterfaceProveedor }, CodigoSeguimiento);

                // actualizando respuesta
                resultado = linterfaceProveedor;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ProcesarFacturacion(CE_Interface parametros,
                                              bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            var lregistrosAfectados = 0;

            string lcabeceraXml = null;
            string ldetalleXml = null;

            try
            {
                // serializando cabecera y detalle
                lcabeceraXml = XmlHelper.XmlSerializerforOracle(parametros.Cabecera, false, false);
                ldetalleXml = XmlHelper.XmlSerializerforOracle(parametros.Detalle, false, false);

                using (var lpkgGdsGeneric = new PkgGdsGeneric(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

                    // iniciando transacción
                    Conexion.IniciarTransaccion();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarFacturacionCabecera'", new { lcabeceraXml }, CodigoSeguimiento);

                    // insertando cabecera de facturación
                    lpkgGdsGeneric.GdsInsertarFacturacionCabecera(Conexion, Esquema, lcabeceraXml, out lregistrosAfectados);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarFacturacionCabecera'", new { lregistrosAfectados }, CodigoSeguimiento);

                    // evaluando si la operación fue exitosa
                    if (lregistrosAfectados != 0)
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarFacturacionDetalle'", new { ldetalleXml },  CodigoSeguimiento);

                        // insertando detalle de facturación
                        lpkgGdsGeneric.GdsInsertarFacturacionDetalle(Conexion, Esquema, ldetalleXml, out lregistrosAfectados);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarFacturacionDetalle'", new { lregistrosAfectados }, CodigoSeguimiento);
                    }

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.FinalizarTransaccion'", CodigoSeguimiento);

                    // finalizando transacción
                    Conexion.FinalizarTransaccion((lregistrosAfectados == 0));

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.FinalizarTransaccion'", CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors, lregistrosAfectados, lcabeceraXml, ldetalleXml }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerConfiguracionFranquicia(int idCliente,
                                                         out CE_FranquiciaConfig resultado,
                                                         bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerFranquiciaConfig'", new { idCliente }, CodigoSeguimiento);

                    // buscando interface de proveedor
                    resultado = lpkgGdsModuloPnrPta.GdsObtenerFranquiciaConfig(Conexion, Esquema, idCliente);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerFranquiciaConfig'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { idCliente, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        #endregion
    }
}
