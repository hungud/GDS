using System.Data;
using System.Collections.Generic;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.TarjetaCredito;

using BaseDatosLib.Base;

namespace BaseDatosLib.PaquetesWeb
{
    public sealed class PkgGdsSesionB2BWallet : Common
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
        public PkgGdsSesionB2BWallet(string codigoSeguimiento,
                                          Conexion conexion,
                                          string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_SESION_B2BWALLET")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsSesionB2BWallet(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {

        }

        #endregion

        // =============================
        // metodos
        #region "metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public List<CE_SessionB2BWallet> GdsObtenerSesion(Conexion conexion,
                                                          string esquema,
                                                          int destino)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_destino", ParameterType.Int32, ParameterDirection.Input, destino));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_SESSION_DESTINO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_SessionB2BWallet>(ldatos);

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
        /// <param name="target"></param>
        /// <returns></returns>
        public bool ActualizarSesion(Conexion conexion,
                                     string esquema,
                                     CE_SessionB2BWallet target)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_estado", ParameterType.Int32, ParameterDirection.Input, target.Estado));
                lparametros.Add(new Parametro("p_aplicacion", ParameterType.Varchar2, ParameterDirection.Input, target.Aplicacion, 255));
                lparametros.Add(new Parametro("p_usuario", ParameterType.Varchar2, ParameterDirection.Input, target.Usuario, 255));
                lparametros.Add(new Parametro("p_conversationid", ParameterType.Varchar2, ParameterDirection.Input, target.ConversationID, 255));
                lparametros.Add(new Parametro("p_token", ParameterType.Varchar2, ParameterDirection.Input, target.Token, 255));
                lparametros.Add(new Parametro("p_newtoken", ParameterType.Varchar2, ParameterDirection.Input, target.NewToken, 255));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ACTUALIZA_SESSION");

                // registrando eventos            
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                return (int.Parse(lparametros.Find("p_RowsAffected").Valor.ToString()) > 0);
            }
        }

        #endregion
    }
}
