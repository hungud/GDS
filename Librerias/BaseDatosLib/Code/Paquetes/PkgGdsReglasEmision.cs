using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Reglas;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public class PkgGdsReglasEmision : Common
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
        public PkgGdsReglasEmision(string codigoSeguimiento,
                                   Conexion conexion,
                                   string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_REGLAS_EMISION")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsReglasEmision(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsReglasEmision()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "GdsNoPermiteTransportador"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="transportador"></param>
        /// <param name="pseudo"></param>
        /// <param name="gds"></param>
        /// <returns></returns>
        public bool GdsNoPermiteTransportador(Conexion conexion,
                                              string esquema,
                                              string transportador,
                                              string pseudo,
                                              int gds)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 6));
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, pseudo, 20));
                lparametros.Add(new Parametro("p_gds", ParameterType.Int32, ParameterDirection.Input, gds));
                lparametros.Add(new Parametro("p_nopermiteemision", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_NO_PERMITE_TRANSPORTADOR");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // retornando resultado
                return (int.Parse(lparametros.Find("p_nopermiteemision").Valor.ToString()) == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportador"></param>
        /// <param name="pseudo"></param>
        /// <param name="gds"></param>
        /// <returns></returns>
        public bool GdsNoPermiteTransportador(string transportador,
                                              string pseudo,
                                              int gds)
        {
            return GdsNoPermiteTransportador(Conexion, Esquema, transportador, pseudo, gds);
        }

        #endregion

        #region "GdsObtenerListaPermiteTran"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="reglaEmision"></param>
        /// <returns></returns>
        public List<CE_ReglaEmision> GdsObtenerListaPermiteTran(Conexion conexion,
                                                                string esquema,
                                                                CE_ReglaEmision reglaEmision)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.IdTransportador, 6));
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.Pseudo, 20));
                lparametros.Add(new Parametro("p_gds", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.Gds, 20));
                lparametros.Add(new Parametro("p_descripcion", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.Descripcion, 70));
                lparametros.Add(new Parametro("p_espropio", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.EsPropio));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_LISTA_PERMITE_TRAN");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_ReglaEmision>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reglaEmision"></param>
        /// <returns></returns>
        public List<CE_ReglaEmision> GdsObtenerListaPermiteTran(CE_ReglaEmision reglaEmision)
        {
            return GdsObtenerListaPermiteTran(Conexion, Esquema, reglaEmision);
        }

        #endregion

        #region "GdsAnadirPermiteTran"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="reglaEmision"></param>
        /// <returns></returns>
        public bool GdsAnadirPermiteTran(Conexion conexion,
                                         string esquema,
                                         CE_ReglaEmision reglaEmision)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.IdTransportador, 6));
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.Pseudo, 20));
                lparametros.Add(new Parametro("p_gds", ParameterType.Int32, ParameterDirection.Input, reglaEmision.Gds));
                lparametros.Add(new Parametro("p_descripcion", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.Descripcion, 70));
                lparametros.Add(new Parametro("p_espropio", ParameterType.Varchar2, ParameterDirection.Input, reglaEmision.EsPropio));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ANADIR_PERMITE_TRAN");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reglaEmision"></param>
        /// <returns></returns>
        public bool GdsAnadirPermiteTran(CE_ReglaEmision reglaEmision)
        {
            return GdsAnadirPermiteTran(Conexion, Esquema, reglaEmision);
        }

        #endregion

        #endregion
    }
}
