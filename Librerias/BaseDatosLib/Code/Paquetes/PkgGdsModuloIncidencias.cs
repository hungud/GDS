using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Incidencia;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsModuloIncidencias : Common
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
        public PkgGdsModuloIncidencias(string codigoSeguimiento,
                                       Conexion conexion,
                                       string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_MODULO_INCIDENCIAS")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsModuloIncidencias(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsModuloIncidencias()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "GdsInsertarBitacoraCC"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="bitacoraCC"></param>
        /// <returns></returns>
        public bool GdsInsertarBitacoraCC(Conexion conexion, 
                                          string esquema, 
                                          CE_BitacoraCC bitacoraCC) 
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, bitacoraCC.Dk));
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.PNR, 255));
                lparametros.Add(new Parametro("p_categoriaboleto", ParameterType.Int32, ParameterDirection.Input, bitacoraCC.IdCategoriaBoleto));
                lparametros.Add(new Parametro("p_solicitante", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.Solicitante, 255));
                lparametros.Add(new Parametro("p_aprobador", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.Aprobador, 255));
                lparametros.Add(new Parametro("p_centrocosto", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.CentroCosto, 255));
                lparametros.Add(new Parametro("p_ordenservicio", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.OrdenServicio, 255));
                lparametros.Add(new Parametro("p_motivoviaje", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.MotivoViaje, 255));
                lparametros.Add(new Parametro("p_ocurtema", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.OcurTema, 255));
                lparametros.Add(new Parametro("p_logincrea", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.UsuarioWeb.UsuarioWebLogin, 255));
                lparametros.Add(new Parametro("p_usuwebidcrea", ParameterType.Int32, ParameterDirection.Input, bitacoraCC.UsuarioWeb.UsuarioIdWeb));
                lparametros.Add(new Parametro("p_ofiid", ParameterType.Int32, ParameterDirection.Input, bitacoraCC.UsuarioWeb.OficinaIdWeb));
                lparametros.Add(new Parametro("p_depid", ParameterType.Int32, ParameterDirection.Input, bitacoraCC.UsuarioWeb.DepartamentoIdWeb));
                lparametros.Add(new Parametro("p_ocurdescripcion", ParameterType.Varchar2, ParameterDirection.Input, bitacoraCC.OcurDescripcion, (bitacoraCC.OcurDescripcion != null ? bitacoraCC.OcurDescripcion.Length : 1 )));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTAR_BITACORA_CC");

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
        /// <param name="bitacoraCC"></param>
        /// <returns></returns>
        public bool GdsInsertarBitacoraCC(CE_BitacoraCC bitacoraCC)
        {
            return GdsInsertarBitacoraCC(Conexion, Esquema, bitacoraCC);
        }

        #endregion

        #endregion
    }
}
