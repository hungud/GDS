using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Incidencia;

using BaseDatosLib.Base;

namespace BaseDatosLib.PaquetesWeb
{
    public sealed class PkgGdsModuloIncidenciasWeb : Common
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
        public PkgGdsModuloIncidenciasWeb(string codigoSeguimiento,
                                          Conexion conexion,
                                          string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_MODULO_INCIDENCIAS_WEB")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsModuloIncidenciasWeb(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "GdsObtenerDatosUsuarioWeb"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="usuarioWebLogin"></param>
        /// <returns></returns>
        public CE_UsuarioWeb GdsObtenerDatosUsuarioWeb(Conexion conexion, 
                                                       string esquema, 
                                                       string idVendedor) 
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_IdVendedor", ParameterType.Varchar2, ParameterDirection.Input, idVendedor, 50));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_DATOS_USUARIO_V2");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_UsuarioWeb>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuarioWebLogin"></param>
        /// <returns></returns>
        public CE_UsuarioWeb GdsObtenerDatosUsuarioWeb(string usuarioWebLogin)
        {
            return GdsObtenerDatosUsuarioWeb(Conexion, Esquema, usuarioWebLogin);
        }

        #endregion

        #endregion
    }
}
