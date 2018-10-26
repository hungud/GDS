using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Facturacion;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class GdsIntegracionM : Common
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
        public GdsIntegracionM(string codigoSeguimiento,
                               Conexion conexion,
                               string esquema)
            : base(codigoSeguimiento, conexion, esquema, "GDS_INTENGRACION_M")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public GdsIntegracionM(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~GdsIntegracionM()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "ObtCorrelativoFacturacion"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="punto"></param>
        /// <param name="idSucursal"></param>
        /// <param name="tipoComprobante"></param>
        /// <returns></returns>
        public CE_FacturaCabecera ObtCorrelativoFacturacion(Conexion conexion,
                                                            string esquema,
                                                            int punto,
                                                            int idSucursal,
                                                            EnumTipoComprobanteFacturacion tipoComprobante)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idpunto", ParameterType.Int32, ParameterDirection.Input, punto));
                lparametros.Add(new Parametro("p_tipodecomprobante", ParameterType.Varchar2, ParameterDirection.Input, tipoComprobante.ToString(), 255));
                lparametros.Add(new Parametro("p_idsucursal", ParameterType.Int32, ParameterDirection.Input, idSucursal));
                lparametros.Add(new Parametro("p_respuesta", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "OBT_CORRELATIVO_FACTURACION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y removiendo el primer caracter de la respuesta
                var lresultado = lparametros.Find("p_respuesta").Valor.TrimOrNull().Remove(0, 1);

                return new CE_FacturaCabecera
                {
                    TipoComprobante = tipoComprobante,
                    NumeroSerie = lresultado.Split('/')[0],
                    IdFacturaCabecera = lresultado.Split('/')[1]
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="punto"></param>
        /// <param name="idSucursal"></param>
        /// <param name="tipoComprobante"></param>
        /// <returns></returns>
        public CE_FacturaCabecera ObtCorrelativoFacturacion(int punto,
                                                            int idSucursal,
                                                            EnumTipoComprobanteFacturacion tipoComprobante)
        {
            return ObtCorrelativoFacturacion(Conexion, Esquema, punto, idSucursal, tipoComprobante);
        }

        #endregion

        #endregion
    }
}
