using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Base;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsModuloNoPublikdasPta : Common
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
        public PkgGdsModuloNoPublikdasPta(string codigoSeguimiento,
                                          Conexion conexion,
                                          string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_MODULO_NOPUBLIKDAS_PTA")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsModuloNoPublikdasPta(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsModuloNoPublikdasPta()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

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
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_LIMPIAR_CONCEPTOS");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);
            }
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
        /// <returns></returns>
        public void GdsLimpiarEvaluaciones(Conexion conexion,
                                           string esquema,
                                           string pnr)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_LIMPIAR_EVALUACIONES");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <returns></returns>
        public void GdsLimpiarEvaluaciones(string pnr)
        {
            GdsLimpiarEvaluaciones(Conexion, Esquema, pnr);
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
        
        #endregion
    }
}
