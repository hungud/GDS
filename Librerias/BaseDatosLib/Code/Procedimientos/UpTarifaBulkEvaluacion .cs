using System.Collections.Generic;
using System.Linq;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS.ComisionFeePta;

using BaseDatosLib.Base;

namespace BaseDatosLib.Procedimientos
{
    public sealed class UpTarifaBulkEvaluacion : Common
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
        public UpTarifaBulkEvaluacion(string codigoSeguimiento,
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
        public UpTarifaBulkEvaluacion(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~UpTarifaBulkEvaluacion()
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
        public List<CE_FeePta> Ejecutar(Conexion conexion,
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
                lparametros.Add(new Parametro("v_regla_tarifaBulk_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_cadena_importes_out", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}", esquema, "UP_TARIFABULK_EVALUACION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                List<CE_FeePta> lresultado = null;

                // evaluando si se obtuvo una cadena de importes
                if (!lparametros.Find("v_cadena_importes_out").EsNulo)
                {
                    // leyendo resultados
                    var lreglaTarifaBulkOut = lparametros.Find("v_regla_tarifaBulk_out").Valor.TrimOrNull();
                    var lnumeroTarifarioOut = lparametros.Find("v_cadena_importes_out").Valor.TrimOrNull();

                    /**** NOTA ****
                     v_cadena_importes_out EJEMP: QF05;0;30.00;50.00;1;1;0;1/QP75;0;40.00;60.00;1;1;1;0/
                     EQUIV: Pseudo;EsPorcentaje;FeeMinimo;FeeMaximo;SePermiteVentaWeb;MuestraWebAgencia;NoPermiteRuc;SePermiteEmitirConTarjetaCredito/
                    */

                    // construyendo resultado
                    lresultado = lnumeroTarifarioOut.Split('/')
                        .Where(v => (!string.IsNullOrWhiteSpace(v)))
                            .Select(l =>
                            {
                                var lvalores = l.Split(';');

                                return new CE_FeePta
                                {
                                    PseudoOficina = lvalores[0],
                                    EsPorcentaje = (int.Parse(lvalores[1]) == 1),
                                    Regla = lreglaTarifaBulkOut,
                                    FeeMinimo = decimal.Parse(lvalores[2]),
                                    FeeMaximo = decimal.Parse(lvalores[3]),
                                    SePermiteVentaWeb = (int.Parse(lvalores[4]) == 1),
                                    MuestraWebAgencia = (int.Parse(lvalores[5]) == 1),
                                    PermiteRuc = (int.Parse(lvalores[6]) == 0),
                                    PermiteEmitirConTarjetaCredito = (int.Parse(lvalores[7]) == 1)
                                };
                            }).ToList();
                }

                return lresultado;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="pnr"></param>
        /// <returns></returns>
        public List<CE_FeePta> Ejecutar(string transportador,
                                        string ciudadDestino,
                                        string pnr)
        {
            return Ejecutar(Conexion, Esquema, transportador, ciudadDestino, pnr);
        }

        #endregion
    }
}
