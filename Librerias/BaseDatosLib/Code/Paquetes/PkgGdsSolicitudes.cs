using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS.TarjetaCredito;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsSolicitudes : Common
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
        public PkgGdsSolicitudes(string codigoSeguimiento,
                                 Conexion conexion,
                                 string esquema)
            : base(codigoSeguimiento, conexion, esquema, "GDS_SOLICITUDES")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsSolicitudes(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsSolicitudes()
        {
            Dispose(false);
        }

        // =============================
        // metodos
        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "ObtenerDatosTarjeta"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="solCodigo"></param>
        /// <param name="solPnrCod"></param>
        /// <param name="cliempDk"></param>
        /// <returns></returns>
        public CE_EvaluacionTarjetaPTA ObtenerDatosTarjeta(Conexion conexion,
                                                           string esquema,
                                                           int solCodigo,
                                                           string solPnrCod,
                                                           int cliempDk)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_solcodigo", ParameterType.Int64, ParameterDirection.Input,  solCodigo));
                lparametros.Add(new Parametro("p_solpnrcod", ParameterType.Varchar2, ParameterDirection.Input, solPnrCod, 15));
                lparametros.Add(new Parametro("p_cliempdk", ParameterType.Int32, ParameterDirection.Input, cliempDk));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_DATOS_TARJETA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // casteando y evaluando el cursor
                    var lresultado = CastToOracleReader(ldatos, true);

                    CE_EvaluacionTarjetaPTA lformaPago = null;

                    if (lresultado != null)
                    {
                        if (!lresultado["PAGTIPOTARJETA"].ToString().Equals("-1"))
                        {
                            lformaPago = new CE_EvaluacionTarjetaPTA
                            {
                                CodigoTarjeta = lresultado["PAGTIPOTARJETA"].TrimOrNull(),
                                NumeroTarjeta = lresultado["PAGNROTARJETA"].TrimOrNull(),
                                MesAnioExpiracion = lresultado["PAGFECVENCTARJETA"].TrimOrNull(),
                                NombreBanco = lresultado["PAG_BANCO_TARJ_TITU"].TrimOrNull(),
                                IdPaisTarjeta = lresultado["PAIS_IATA"].TrimOrNull(),
                                NombrePaisTarjeta = lresultado["PAIS_NOM"].TrimOrNull(),
                                NombreTitular = lresultado["PAG_TITULAR_TARJ"].TrimOrNull(),
                                NumeroDocumentoTitular = lresultado["PAG_NUM_DOC_TITU"].TrimOrNull(),
                                TipoDocumentoTitular = lresultado["PAG_TIP_DOC_TITU"].TrimOrNull()
                            };
                        }
                    }

                    // cerrando datos
                    ldatos.Close();

                    return lformaPago;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solCodigo"></param>
        /// <param name="solPnrCod"></param>
        /// <param name="cliempDk"></param>
        /// <returns></returns>
        public CE_EvaluacionTarjetaPTA ObtenerDatosTarjeta(int solCodigo,
                                                           string solPnrCod,
                                                           int cliempDk)
        {
            return ObtenerDatosTarjeta(Conexion, Esquema, solCodigo, solPnrCod, cliempDk);
        }

        #endregion

        #endregion
    }
}
