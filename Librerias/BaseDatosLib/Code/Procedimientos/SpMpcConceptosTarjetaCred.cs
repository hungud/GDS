using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using BaseDatosLib.Base;

namespace BaseDatosLib.Procedimientos
{
    public sealed class SpMpcConceptosTarjetaCred : Common
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
        public SpMpcConceptosTarjetaCred(string codigoSeguimiento,
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
        public SpMpcConceptosTarjetaCred(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~SpMpcConceptosTarjetaCred()
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
        /// <param name="pnr"></param>
        /// <param name="iata"></param>
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="eco"></param>
        /// <returns></returns>
        public bool Ejecutar(Conexion conexion,
                             string esquema,
                             string pnr,
                             string iata,
                             string transportador,
                             string ciudadDestino,
                             out string eco)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("vi_cod_reserva", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("vi_id_iata", ParameterType.Varchar2, ParameterDirection.Input, iata, 255));
                lparametros.Add(new Parametro("vi_id_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("vi_ciudad_destino", ParameterType.Varchar2, ParameterDirection.Input, ciudadDestino, 255));
                lparametros.Add(new Parametro("no_error", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("vo_error", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}", esquema, "SP_MPC_CONCEPTOS_TARJETA_CRED");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // leyendo parametros de salida
                var lnroError = int.Parse(lparametros.Find("no_error").Valor.ToString());
                var ltxtError = lparametros.Find("vo_error").Valor.TrimOrNull();

                // actualizando texto de evaluación
                eco = string.Format(
                        "SP_MPC_CONCEPTOS_TARJETA_CRED => '{0}'{1}{2}",
                        lnroError, ((lnroError == -1) ? "\n\n" : string.Empty), ltxtError
                    );

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString(), Respuesta = eco }, CodigoSeguimiento);

                return (lnroError == 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <param name="iata"></param>
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="eco"></param>
        /// <returns></returns>
        public bool Ejecutar(string pnr,
                             string iata,
                             string transportador,
                             string ciudadDestino,
                             out string eco)
        {
            return Ejecutar(Conexion, Esquema, pnr, iata, transportador, ciudadDestino, out eco);
        }

        #endregion
    }
}
