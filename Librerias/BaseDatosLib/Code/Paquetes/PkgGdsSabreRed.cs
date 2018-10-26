using System;
using System.Data;

using Newtonsoft.Json;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Models.General;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsSabreRed : Common
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
        public PkgGdsSabreRed(string codigoSeguimiento,
                                  Conexion conexion,
                                  string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_SABRE_RED")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsSabreRed(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsSabreRed()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region GdsObtenerInformacionSesion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="idSesion"></param>
        /// <returns></returns>
        public CE_InformacionSesion GdsObtenerInformacionSesion(Conexion conexion,
                                                                string esquema,
                                                                string idSesion)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idsesion", ParameterType.Varchar2, ParameterDirection.Input, idSesion, idSesion.Length));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // contruyendo parametros
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_DATOS_SESION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_InformacionSesion>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        #endregion

        #region GdsAlmacenarInformacionSesion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="infoSesion"></param>
        /// <returns></returns>
        public string GdsAlmacenarInformacionSesion(Conexion conexion,
                                                    string esquema, 
                                                    CE_InformacionSesion infoSesion)
        {
            Parametros lparametros;

            var uuid = Guid.NewGuid().ToString();

            var lextras = string.Empty;

            if(infoSesion.Extras != null)
            {
                lextras = JsonConvert.SerializeObject(infoSesion.Extras);
            }

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idsesion", ParameterType.Varchar2, ParameterDirection.Input, uuid, uuid.Length));
                lparametros.Add(new Parametro("p_pseudoactual", ParameterType.Varchar2, ParameterDirection.Input, infoSesion.PseudoActual, infoSesion.PseudoActual.Length));
                lparametros.Add(new Parametro("p_pseudoorigen",  ParameterType.Varchar2, ParameterDirection.Input, infoSesion.PseudoOrigen, infoSesion.PseudoOrigen.Length));
                lparametros.Add(new Parametro("p_idvendedor", ParameterType.Varchar2, ParameterDirection.Input, infoSesion.IdVendedor, infoSesion.IdVendedor.Length));
                lparametros.Add(new Parametro("p_firmaagente", ParameterType.Varchar2, ParameterDirection.Input, infoSesion.FirmaAgente, infoSesion.FirmaAgente.Length));
                lparametros.Add(new Parametro("p_idaplicacion", ParameterType.Int32, ParameterDirection.Input, infoSesion.IdAplicacion));
                lparametros.Add(new Parametro("p_tokengds", ParameterType.Varchar2, ParameterDirection.Input, infoSesion.TokenGDS, infoSesion.TokenGDS.Length));
                lparametros.Add(new Parametro("p_tokenjwt", ParameterType.Varchar2, ParameterDirection.Input, infoSesion.TokenJWT, infoSesion.TokenJWT.Length));
                lparametros.Add(new Parametro("p_codigoreserva", ParameterType.Varchar2, ParameterDirection.Input, infoSesion.CodigoReserva, infoSesion.CodigoReserva.Length));
                lparametros.Add(new Parametro("p_extras", ParameterType.Varchar2, ParameterDirection.Input, lextras, lextras.Length));
                lparametros.Add(new Parametro("p_rutadestino", ParameterType.Varchar2, ParameterDirection.Input,infoSesion.RutaDestino, infoSesion.RutaDestino.Length));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTAR_DATOS_SESION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado
                var lregistrosAfectados = int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString());

                var lresponse = (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) == 1);

                return lresponse ? uuid : string.Empty;
            }
        }

        #endregion

        #endregion
    }
}
