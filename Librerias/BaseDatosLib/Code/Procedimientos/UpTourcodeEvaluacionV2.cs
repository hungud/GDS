using System;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.ComisionFeePta;

using BaseDatosLib.Base;

namespace BaseDatosLib.Procedimientos
{
    public sealed class UpTourcodeEvaluacionV2 : Common
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
        public UpTourcodeEvaluacionV2(string codigoSeguimiento,
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
        public UpTourcodeEvaluacionV2(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~UpTourcodeEvaluacionV2()
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
        /// <param name="idEmpresa"></param>
        /// <param name="pnr"></param>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public CE_ComisionPta Ejecutar(Conexion conexion,
                                       string esquema,
                                       int idEmpresa,
                                       string pnr,
                                       int idGrupo)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("v_arg_empresa", ParameterType.Int32, ParameterDirection.Input, idEmpresa));
                lparametros.Add(new Parametro("v_codigo_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("v_codigo_grupo", ParameterType.Int32, ParameterDirection.Input, idGrupo));
                lparametros.Add(new Parametro("v_numero_tarifario_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_numero_comision_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_tipo_codigo_out", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("v_tourcode_out", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("v_porc_comision_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_porc_agencia_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_porc_factor_meta_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_porc_over_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_over_nace_cancelado_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_es_emision_web_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_account_code_out", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("v_adicionar_over_out", ParameterType.Int32, ParameterDirection.Output, null));
                lparametros.Add(new Parametro("v_porc_factor_yq_out", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}", esquema, "UP_TOURCODE_EVALUACION_V2");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                var lresultado = new CE_ComisionPta
                {
                    // leyendo resultados
                    NumeroTarifario = int.Parse(lparametros.Find("v_numero_tarifario_out").Valor.ToString()),
                    NumeroComision = int.Parse(lparametros.Find("v_numero_comision_out").Valor.ToString()),
                    Codigo = lparametros.Find("v_tourcode_out").Valor.TrimOrNull(),
                    PorcentajeComisionKP = decimal.Parse(lparametros.Find("v_porc_comision_out").Valor.ToString()),
                    PorcentajeAgencia = decimal.Parse(lparametros.Find("v_porc_agencia_out").Valor.ToString()),
                    PorcentajeFactorMeta = decimal.Parse(lparametros.Find("v_porc_factor_meta_out").Valor.ToString()),
                    PorcentajeOver = decimal.Parse(lparametros.Find("v_porc_over_out").Valor.ToString()),
                    PorcentajeOverNaceCancelado = decimal.Parse(lparametros.Find("v_over_nace_cancelado_out").Valor.ToString()),
                    EsEmisionWeb = lparametros.Find("v_es_emision_web_out").Valor.ToString().Equals("1"),
                    AccountCode = lparametros.Find("v_account_code_out").Valor.TrimOrNull(),
                    AdicionarOver = decimal.Parse(lparametros.Find("v_adicionar_over_out").Valor.ToString()),
                    PorcentajeFfactorMetaYQ = decimal.Parse(lparametros.Find("v_porc_factor_yq_out").Valor.ToString())
                };

                var ltipoCodigo = lparametros.Find("v_tipo_codigo_out").Valor.TrimOrNull();

                if (!string.IsNullOrWhiteSpace(ltipoCodigo))
                {
                    lresultado.TipoCodigo = (ltipoCodigo.Equals("N", StringComparison.InvariantCultureIgnoreCase) ? EnumTipoCodigoComision.NetRemit : EnumTipoCodigoComision.TourCode);
                }

                return lresultado;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <param name="pnr"></param>
        /// <param name="idGrupo"></param>
        /// <returns></returns>
        public CE_ComisionPta Ejecutar(int idEmpresa,
                                       string pnr,
                                       int idGrupo)
        {
            return Ejecutar(Conexion, Esquema, idEmpresa, pnr, idGrupo);
        }

        #endregion
    }
}
