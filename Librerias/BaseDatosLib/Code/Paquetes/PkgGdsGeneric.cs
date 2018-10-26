using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public class PkgGdsGeneric : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public PkgGdsGeneric(string codigoSeguimiento,
                             Conexion conexion,
                             string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_GENERIC")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsGeneric(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsGeneric()
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
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="procedimiento"></param>
        /// <param name="tabla"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        private void GdsExecuteWithXml(Conexion conexion,
                                       string esquema,
                                       string procedimiento, 
                                       string tabla,
                                       string datosXml,
                                       out int registrosAfectados)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_table", ParameterType.Varchar2, ParameterDirection.Input, tabla, 255));
                lparametros.Add(new Parametro("p_xmldata", ParameterType.Clob, ParameterDirection.Input, datosXml));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, procedimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado
                registrosAfectados = int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="tabla"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        private void GdsInsertWithXml(Conexion conexion,
                                      string esquema,
                                      string tabla,
                                      string datosXml,
                                      out int registrosAfectados)
        {
            GdsExecuteWithXml(conexion, esquema, "GDS_INSERT_WITH_XML", tabla, datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="tabla"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        private void GdsDeleteWithXml(Conexion conexion,
                                      string esquema,
                                      string tabla,
                                      string datosXml,
                                      out int registrosAfectados)
        {
            GdsExecuteWithXml(conexion, esquema, "GDS_DELETE_WITH_XML", tabla, datosXml, out registrosAfectados);
        }

        #region "GdsInsertarConceptosTarjetaCreditoPta"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarConceptosTarjetaCreditoPta(Conexion conexion,
                                                          string esquema,
                                                          string datosXml,
                                                          out int registrosAfectados)
        {
            GdsInsertWithXml(conexion, esquema, "MPC_EVALUACION", datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarConceptosTarjetaCreditoPta(string datosXml,
                                                          out int registrosAfectados)
        {
            GdsInsertarConceptosTarjetaCreditoPta(Conexion, Esquema, datosXml, out registrosAfectados);
        }

        #endregion

        #region "GdsInsertarConceptosComision"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarConceptosComision(Conexion conexion,
                                                 string esquema,
                                                 string datosXml,
                                                 out int registrosAfectados)
        {
            GdsInsertWithXml(conexion, esquema, "TOURCODES_EVALUACION", datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarConceptosComision(string datosXml,
                                                 out int registrosAfectados)
        {
            GdsInsertarConceptosComision(Conexion, Esquema, datosXml, out registrosAfectados);
        }

        #endregion

        #region "GdsInsertarConceptosFee"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarConceptosFee(Conexion conexion,
                                            string esquema,
                                            string datosXml,
                                            out int registrosAfectados)
        {
            GdsInsertWithXml(conexion, esquema, "TARIFABULK_EVALUACION", datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarConceptosFee(string datosXml,
                                            out int registrosAfectados)
        {
            GdsInsertarConceptosFee(Conexion, Esquema, datosXml, out registrosAfectados);
        }

        #endregion

        #region "GdsInsertarFacturacionCabecera"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarFacturacionCabecera(Conexion conexion,
                                                   string esquema,
                                                   string datosXml,
                                                   out int registrosAfectados)
        {
            GdsInsertWithXml(conexion, esquema, "INTERFACE_GENERAL", datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarFacturacionCabecera(string datosXml,
                                                   out int registrosAfectados)
        {
            GdsInsertarFacturacionCabecera(Conexion, Esquema, datosXml, out registrosAfectados);
        }

        #endregion

        #region "GdsInsertarFacturacionDetalle"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarFacturacionDetalle(Conexion conexion,
                                                  string esquema,
                                                  string datosXml,
                                                  out int registrosAfectados)
        {
            GdsInsertWithXml(conexion, esquema, "INTERFACE_DETALLE", datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsInsertarFacturacionDetalle(string datosXml,
                                                  out int registrosAfectados)
        {
            GdsInsertarFacturacionDetalle(Conexion, Esquema, datosXml, out registrosAfectados);
        }

        #endregion

        #region "GdsDeleteReglasEmision"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsDeletePermiteTransportador(Conexion conexion,
                                                  string esquema,
                                                  string datosXml,
                                                  out int registrosAfectados)
        {
            GdsDeleteWithXml(conexion, esquema, "GDS_PERMITE_EMISION_TRANS", datosXml, out registrosAfectados);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datosXml"></param>
        /// <param name="registrosAfectados"></param>
        /// <returns></returns>
        public void GdsDeletePermiteTransportador(string datosXml,
                                                  out int registrosAfectados)
        {
            GdsDeletePermiteTransportador(Conexion, Esquema, datosXml, out registrosAfectados);
        }

        #endregion

        #endregion
    }
}
