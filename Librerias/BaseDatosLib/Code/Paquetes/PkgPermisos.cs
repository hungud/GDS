using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgPermisos : Common
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
        public PkgPermisos(string codigoSeguimiento,
                           Conexion conexion,
                           string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_PERMISOS")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgPermisos(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgPermisos()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="idUsuarioWeb"></param>
        /// <returns></returns>
        public bool SpPermReemisionAut(Conexion conexion,
                                       string esquema,
                                       string idUsuarioWeb)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_usuwebid_in", ParameterType.Varchar2, ParameterDirection.Input, idUsuarioWeb, 255));
                lparametros.Add(new Parametro("p_tienepermiso_out", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "SP_PERM_REEMISION_AUT");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                    // leyendo resultado
                    var ltienePermiso = (int.Parse(lparametros.Find("p_tienepermiso_out").Valor.ToString()) == 1);

                    // cerrando datos
                    ldatos.Close();

                    return ltienePermiso;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuarioWeb"></param>
        /// <returns></returns>
        public bool SpPermReemisionAut(string idUsuarioWeb)
        {
            return SpPermReemisionAut(Conexion, Esquema, idUsuarioWeb);
        }

        #endregion
    }
}
