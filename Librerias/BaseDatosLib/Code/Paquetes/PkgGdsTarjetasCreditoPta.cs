using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.TarjetaCredito;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsTarjetasCreditoPta : Common
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
        public PkgGdsTarjetasCreditoPta(string codigoSeguimiento,
                                        Conexion conexion,
                                        string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_TARJETAS_CREDITO_PTA")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsTarjetasCreditoPta(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsTarjetasCreditoPta()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region GdsLimpiar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="procedimiento"></param>
        /// <param name="pnr"></param>
        /// <returns></returns>
        private void GdsLimpiar(Conexion conexion,
                                string procedimiento,
                                string pnr)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", procedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(procedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", procedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);
            }
        }

        #endregion

        #region "GdsLimpiarConceptos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <returns></returns>
        public void GdsLimpiarConceptos(Conexion conexion,
                                        string esquema,
                                        string pnr)
        {
            var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_LIMPIAR_CONCEPTOS_TDC");

            GdsLimpiar(conexion, lprocedimiento, pnr);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <returns></returns>
        public void GdsLimpiarConceptos(string pnr)
        {
            GdsLimpiarConceptos(Conexion, Esquema, pnr);
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
            var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_LIMPIAR_EVALUACIONES_TDC");

            GdsLimpiar(conexion, lprocedimiento, pnr);
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

        #region "GdsObtenerConceptosTdc"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pnr"></param>
        /// <param name="iata"></param>
        /// <returns></returns>
        public List<CE_Concepto> GdsObtenerConceptosTdc(Conexion conexion,
                                                        string esquema,
                                                        string pnr,
                                                        string iata)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 255));
                lparametros.Add(new Parametro("p_iata", ParameterType.Varchar2, ParameterDirection.Input, iata, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_CONCEPTOS_TDC");

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
        /// <param name="iata"></param>
        /// <returns></returns>
        public List<CE_Concepto> GdsObtenerConceptosTdc(string pnr,
                                                        string iata)
        {
            return GdsObtenerConceptosTdc(Conexion, Esquema, pnr, iata);
        }

        #endregion

        #region GdsObtenerEmisionB2BPendientes

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public List<CE_EmisionB2B> GdsObtenerEmisionB2BPendientes(Conexion conexion,
                                                                  string esquema)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_EMISIONES_B2B");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_EmisionB2B>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        #endregion

        #region GdsObtenerEmisionB2BPorFecha

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public List<CE_EmisionB2B> GdsObtenerEmisionB2BPorFecha(Conexion conexion,
                                                                  string esquema,
                                                                  string fechaInicio,
                                                                  string fechaFin)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_inicioBusqueda", ParameterType.Varchar2, ParameterDirection.Input, fechaInicio, 255));
                lparametros.Add(new Parametro("p_finBusqueda", ParameterType.Varchar2, ParameterDirection.Input, fechaFin, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_GET_EMISIONES_B2B_X_FECHA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_EmisionB2B>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        #endregion

        #region GdsPreRegistarEmisionB2B

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int GdsPreRegistarEmisionB2B(Conexion conexion,
                                             string esquema,
                                             CE_EmisionB2B target)
        {
            Parametros lparametros;

            //0 = Tarjeta Amex  ---  1 = Tarjeta B2B Wallet
            var ltipoTarjeta = (string.IsNullOrEmpty(target.ReferenciaAmadeus) && string.IsNullOrEmpty(target.ReferenciaExterna)) ? 0 : 1;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, target.PNR, 255));
                lparametros.Add(new Parametro("p_referenciaamadeus", ParameterType.Varchar2, ParameterDirection.Input, target.ReferenciaAmadeus, 255));
                lparametros.Add(new Parametro("p_referenciaexterna", ParameterType.Varchar2, ParameterDirection.Input, target.ReferenciaExterna, 255));
                lparametros.Add(new Parametro("p_numerotarjeta", ParameterType.Varchar2, ParameterDirection.Input, target.NumeroTarjeta, 255));
                lparametros.Add(new Parametro("p_IdTarjetaCredito", ParameterType.Int32, ParameterDirection.Input, target.IdTarjetaCreditoPTA));
                lparametros.Add(new Parametro("p_IdReglaPTA", ParameterType.Int32, ParameterDirection.Input, target.IdRegla));
                lparametros.Add(new Parametro("p_codigoseguimiento", ParameterType.Varchar2, ParameterDirection.Input, CodigoSeguimiento, 255));
                lparametros.Add(new Parametro("p_tipoTarjeta", ParameterType.Int32, ParameterDirection.Input, ltipoTarjeta));
                lparametros.Add(new Parametro("p_SecuenciaID", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_PREINSERTAR_EMISION_B2B");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return int.Parse(lparametros.Find("p_SecuenciaID").Valor.ToString());
            }


        }
        #endregion

        #region GdsRegistarEmisionB2B

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool GdsRegistarEmisionB2B(Conexion conexion,
                                          string esquema,
                                          CE_EmisionB2B target)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, target.PNR, 255));
                lparametros.Add(new Parametro("p_numeroboleto", ParameterType.Varchar2, ParameterDirection.Input, target.NumeroBoleto, 255));
                lparametros.Add(new Parametro("p_codlineaaerea", ParameterType.Varchar2, ParameterDirection.Input, target.CodigoLineaAerea, 255));
                lparametros.Add(new Parametro("p_idgds", ParameterType.Varchar2, ParameterDirection.Input, target.IdGDS, 255));
                lparametros.Add(new Parametro("p_referenciaamadeus", ParameterType.Varchar2, ParameterDirection.Input, target.ReferenciaAmadeus, 255));
                lparametros.Add(new Parametro("p_referenciaexterna", ParameterType.Varchar2, ParameterDirection.Input, target.ReferenciaExterna, 255));
                lparametros.Add(new Parametro("p_pseudoemision", ParameterType.Varchar2, ParameterDirection.Input, target.PseudoEmision, 255));
                lparametros.Add(new Parametro("p_SecuenciaID", ParameterType.Int32, ParameterDirection.Input, target.SecuenciaID));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTAR_EMISION_B2B");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) > 0;
            }
        }

        #endregion

        #region GdsActualizarEmisionB2B

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool GdsActualizarEmisionB2B(Conexion conexion,
                                            string esquema,
                                            CE_EmisionB2B target)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, target.PNR, 255));
                lparametros.Add(new Parametro("p_numeroboleto", ParameterType.Varchar2, ParameterDirection.Input, target.NumeroBoleto, 255));
                lparametros.Add(new Parametro("p_comentario", ParameterType.Varchar2, ParameterDirection.Input, target.Comentario , 255));
                lparametros.Add(new Parametro("p_status", ParameterType.Int32, ParameterDirection.Input, target.Status));
                lparametros.Add(new Parametro("p_intentoseliminar", ParameterType.Int32, ParameterDirection.Input, target.IntentosDeEliminacion));
                lparametros.Add(new Parametro("p_montoTotalBoleto", ParameterType.Decimal, ParameterDirection.Input, target.MontoTotalBoleto));
                lparametros.Add(new Parametro("p_Anulado", ParameterType.Int32, ParameterDirection.Input, target.Anulado));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ACTUALIZAR_EMISION_B2B");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) > 0);
            }
        }

        #endregion

        #endregion
    }
}
