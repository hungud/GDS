using System;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS.TarjetaCredito;

using BaseDatosLib.Base;

namespace BaseDatosLib.Procedimientos
{
    public sealed class SpMpcEvaluaTarjetaCred : Common
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
        public SpMpcEvaluaTarjetaCred(string codigoSeguimiento,
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
        public SpMpcEvaluaTarjetaCred(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~SpMpcEvaluaTarjetaCred()
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
        /// <param name="importeReserva"></param>
        /// <param name="eco"></param>
        /// <returns></returns>
        public CE_EvaluacionTarjetaPTA Ejecutar(Conexion conexion,
                                                string esquema,
                                                string pnr,
                                                string iata,
                                                decimal importeReserva,
                                                out string eco)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("vi_cod_reserva", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("vi_iata", ParameterType.Varchar2, ParameterDirection.Input, iata, 255));
                lparametros.Add(new Parametro("ni_importe_boleto", ParameterType.Decimal, ParameterDirection.Input, importeReserva));
                lparametros.Add(new Parametro("vo_id_codigo_tarjeta", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("do_fecha_expiracion", ParameterType.Date, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("no_id_tarjeta_credito_pta", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("no_id_regla", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("vo_numero_de_tarjeta", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("no_error", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}", esquema, "SP_MPC_EVALUA_TARJETA_CRED");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // leyendo parametro de salida
                var lnroError = int.Parse(lparametros.Find("no_error").Valor.ToString());

                // actualizando texto de evaluación
                eco = string.Format("SP_MPC_EVALUA_TARJETA_CRED => '{0}' donde 0: Ok, -1: Ocurrió un error, 1: Las Reglas no se cumplen", lnroError);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString(), Respuesta = eco }, CodigoSeguimiento);

                CE_EvaluacionTarjetaPTA lresultado = null;

                if (lnroError == 0)
                {
                    lresultado = new CE_EvaluacionTarjetaPTA
                    {
                        // leyendo resultados
                        CodigoTarjeta = lparametros.Find("vo_id_codigo_tarjeta").Valor.TrimOrNull(),
                        MesAnioExpiracion = DateTime.Parse(lparametros.Find("do_fecha_expiracion").Valor.ToString()).ToString("yyyy/MM"),
                        IdTarjetaCreditoPTA = int.Parse(lparametros.Find("no_id_tarjeta_credito_pta").Valor.ToString()),
                        IdRegla = int.Parse(lparametros.Find("no_id_regla").Valor.ToString()),
                        NumeroTarjeta = lparametros.Find("vo_numero_de_tarjeta").Valor.TrimOrNull()
                    };
                }

                return lresultado;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="iata"></param>
        /// <param name="importeReserva"></param>
        /// <param name="eco"></param>
        /// <returns></returns>
        public CE_EvaluacionTarjetaPTA Ejecutar(string pnr,
                                                string iata,
                                                decimal importeReserva,
                                                out string eco)
        {
            return Ejecutar(Conexion, Esquema, pnr, iata, importeReserva, out eco);
        }

        #endregion
    }
}
