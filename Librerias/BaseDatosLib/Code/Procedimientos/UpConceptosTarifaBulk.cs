using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using BaseDatosLib.Base;

namespace BaseDatosLib.Procedimientos
{
    public class UpConceptosTarifaBulk : Common
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
        public UpConceptosTarifaBulk(string codigoSeguimiento,
                                     Conexion conexion,
                                     string esquema)
            : base(codigoSeguimiento, conexion, esquema, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public UpConceptosTarifaBulk(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~UpConceptosTarifaBulk()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodo

        #region "metodo"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="pnr"></param>
        /// <returns></returns>
        public void Ejecutar(Conexion conexion,
                             string esquema,
                             string transportador,
                             string ciudadDestino,
                             string pnr)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("v_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("v_ciudad_destino", ParameterType.Varchar2, ParameterDirection.Input, ciudadDestino, 255));
                lparametros.Add(new Parametro("v_codigo_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}", esquema, "UP_CONCEPTOS_TARIFABULK");

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
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="pnr"></param>
        /// <returns></returns>
        public void Ejecutar(string transportador,
                             string ciudadDestino,
                             string pnr)
        {
            Ejecutar(Conexion, Esquema, transportador, ciudadDestino, pnr);
        }

        #endregion
    }
}
