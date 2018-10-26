using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.ComisionFeePta;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsModuloComisionPta : Common
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
        public PkgGdsModuloComisionPta(string codigoSeguimiento,
                                       Conexion conexion,
                                       string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_MODULO_COMISION_PTA")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsModuloComisionPta(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsModuloComisionPta()
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
        /// <param name="procedimiento"></param>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        private void GdsLimpiar(Conexion conexion,
                                string procedimiento,
                                string pnr,
                                string transportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", procedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(procedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", procedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);
            }
        }

        #region "GdsLimpiarConceptos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public void GdsLimpiarConceptos(Conexion conexion,
                                        string esquema,
                                        string pnr,
                                        string transportador)
        {
            var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_LIMPIAR_CONCEPTOS");

            GdsLimpiar(conexion, lprocedimiento, pnr, transportador);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public void GdsLimpiarConceptos(string pnr,
                                        string transportador)
        {
            GdsLimpiarConceptos(Conexion, Esquema, pnr, transportador);
        }

        #endregion

        #region "GdsLimpiarEvaluaciones"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public void GdsLimpiarEvaluaciones(Conexion conexion,
                                           string esquema,
                                           string pnr,
                                           string transportador)
        {
            var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_LIMPIAR_EVALUACIONES");

            GdsLimpiar(conexion, lprocedimiento, pnr, transportador);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public void GdsLimpiarEvaluaciones(string pnr,
                                           string transportador)
        {
            GdsLimpiarEvaluaciones(Conexion, Esquema, pnr, transportador);
        }

        #endregion

        #region "GdsObtenerConceptos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public List<CE_Concepto> GdsObtenerConceptos(Conexion conexion,
                                                     string esquema,
                                                     string pnr,
                                                     string transportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_CONCEPTOS");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_Concepto>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public List<CE_Concepto> GdsObtenerConceptos(string pnr,
                                                     string transportador)
        {
            return GdsObtenerConceptos(Conexion, Esquema, pnr, transportador);
        }

        #endregion

        #region "GdsObtenerAdicional"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <param name="idCliente"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public CE_ComisionPtaAdicional GdsObtenerAdicional(Conexion conexion,
                                                           string esquema,
                                                           string pnr,
                                                           int idCliente,
                                                           string transportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, idCliente));
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_ADICIONAL");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_ComisionPtaAdicional>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="idCliente"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public CE_ComisionPtaAdicional GdsObtenerAdicional(string pnr,
                                                           int idCliente,
                                                           string transportador)
        {
            return GdsObtenerAdicional(Conexion, Esquema, pnr, idCliente, transportador);
        }

        #endregion

        #region "GdsObtenerAdicional"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="transportador"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public decimal GdsObtenerComisionPorDefecto(Conexion conexion,
                                                    string esquema,
                                                    string transportador,
                                                    int idEmpresa,
                                                    int idGrupo)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_idempresa", ParameterType.Int32, ParameterDirection.Input, idEmpresa));
                lparametros.Add(new Parametro("p_idgrupo", ParameterType.Int32, ParameterDirection.Input, idGrupo));
                lparametros.Add(new Parametro("p_comision", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_COMISION_X_DEFECTO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                    // leyendo resultado
                    var lcomision = decimal.Parse(lparametros.Find("p_comision").Valor.ToString());

                    // cerrando datos
                    ldatos.Close();

                    return lcomision;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportador"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public decimal GdsObtenerComisionPorDefecto(string transportador,
                                                    int idEmpresa,
                                                    int idGrupo)
        {
            return GdsObtenerComisionPorDefecto(Conexion, Esquema, transportador, idEmpresa, idGrupo);
        }

        #endregion

        #endregion
    }
}
