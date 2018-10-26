using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS.Facturacion;

using BaseDatosLib.Base;

namespace BaseDatosLib.Procedimientos
{
    public sealed class UpGetInterfaceNumeracion : Common
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
        public UpGetInterfaceNumeracion(string codigoSeguimiento,
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
        public UpGetInterfaceNumeracion(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~UpGetInterfaceNumeracion()
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
        /// <returns></returns>
        public CE_SecuenciaReferencia Ejecutar(Conexion conexion,
                                               string esquema)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("v_referencia_out", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("v_secuencia_out", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}", esquema, "UP_GET_INTERFACE_NUMERACION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                return new CE_SecuenciaReferencia
                {
                    // leyendo resultados
                    Referencia = lparametros.Find("v_referencia_out").Valor.TrimOrNull(),
                    Secuencia = int.Parse(lparametros.Find("v_secuencia_out").Valor.ToString())
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_SecuenciaReferencia Ejecutar()
        {
            return Ejecutar(Conexion, Esquema);
        }

        #endregion
    }
}
