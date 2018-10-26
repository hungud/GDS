using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.General;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsGeneral : Common
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
        public PkgGdsGeneral(string codigoSeguimiento,
                             Conexion conexion,
                             string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_GENERAL_NM")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsGeneral(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsGeneral()
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
        /// <param name="usuarioWEB"></param>
        /// <returns></returns>
        public CE_Vendedor ObtenerVendedorPorUsuarioWeb(Conexion conexion,
                                                        string esquema,
                                                        string usuarioWEB)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_usuarioweb", ParameterType.Varchar2, ParameterDirection.Input, usuarioWEB, usuarioWEB.Length));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_VENDEDOR_X_USUWEB");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_Vendedor>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="idVendedor"></param>
        /// <returns></returns>
        public CE_Vendedor ObtenerVendedorPorID(Conexion conexion,
                                                 string esquema,
                                                 string idVendedor)
        {
            var lrespuesta = ObtenerVendedorPorFiltro(conexion, esquema, 1, idVendedor);

            return ((lrespuesta != null) ? lrespuesta[0] : null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public List<CE_Vendedor> ObtenerVendedores(Conexion conexion,
                                                   string esquema)
        {
            var lrespuesta = ObtenerVendedorPorFiltro(conexion, esquema, 0, string.Empty);

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="tipoBusqueda"></param>
        /// <param name="parametroBusqueda"></param>
        /// <returns></returns>
        private List<CE_Vendedor> ObtenerVendedorPorFiltro(Conexion conexion,
                                                           string esquema,
                                                           int tipoBusqueda,
                                                           string parametroBusqueda)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_TipoBusqueda", ParameterType.Varchar2, ParameterDirection.Input, tipoBusqueda));
                lparametros.Add(new Parametro("p_ParametroBusqueda", ParameterType.Varchar2, ParameterDirection.Input, parametroBusqueda, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_VENDEDOR_X_FILTRO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToList<CE_Vendedor>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;                    
                }
            }
        }

        #endregion
    }
}
