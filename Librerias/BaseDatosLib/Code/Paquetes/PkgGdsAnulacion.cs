using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Boleto;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsAnulacion: Common
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
        public PkgGdsAnulacion(string codigoSeguimiento,
                               Conexion conexion,
                               string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_ANULACION")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsAnulacion(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsAnulacion()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region metodos

        #region GdsActualizaBoletoPaxVoid

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="boletoPax"></param>
        /// <returns></returns>
        public bool GdsActualizaBoletoPaxVoid(Conexion conexion, 
                                              string esquema, 
                                              CE_BoletoPax boletoPax)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_Reserva", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.CodReserva, 255));
                lparametros.Add(new Parametro("p_Boleto", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.NumeroBoleto, 255));
                lparametros.Add(new Parametro("p_QuienAnula", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.QuienAnula, 255));
                lparametros.Add(new Parametro("p_Motivo", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.MotivoAnulacion, 255));
                lparametros.Add(new Parametro("p_FacCliente", ParameterType.Int32, ParameterDirection.Input, boletoPax.FacturarAnulacionAlCliente));
                lparametros.Add(new Parametro("p_SinRefacturar", ParameterType.Int32, ParameterDirection.Input, boletoPax.SinRefacturarPorAnulacion));
                lparametros.Add(new Parametro("p_RowsAffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ACTUALIZA_BOLETO_PAX_VOID");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) > 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boletoPax"></param>
        /// <returns></returns>
        public bool GdsActualizaBoletoPaxVoid(CE_BoletoPax boletoPax) 
        {
            return GdsActualizaBoletoPaxVoid(Conexion, Esquema, boletoPax);
        }

        #endregion GdsActualizaBoletoPaxVoid

        #region GdsIinsertaTextoFile

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="boletoPax"></param>
        /// <returns></returns>
        public bool GdsIinsertaTextoFile(Conexion conexion,
                                         string esquema,
                                         CE_BoletoPax boletoPax)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_File", ParameterType.Int32, ParameterDirection.Input, boletoPax.NumeroFile));
                lparametros.Add(new Parametro("p_Empresa", ParameterType.Int32, ParameterDirection.Input, boletoPax.IdEmpresa));
                lparametros.Add(new Parametro("p_Sucursal", ParameterType.Int32, ParameterDirection.Input, boletoPax.IdSucursal));
                lparametros.Add(new Parametro("p_Text", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.TextoFile, 255));
                lparametros.Add(new Parametro("p_Usuario", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.IdVendedor, 255));
                lparametros.Add(new Parametro("p_RowsAffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTA_TEXTO_FILE");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) > 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boletoPax"></param>
        /// <returns></returns>
        public bool GdsIinsertaTextoFile(CE_BoletoPax boletoPax) 
        {
            return GdsIinsertaTextoFile(Conexion, Esquema, boletoPax);
        }

        #endregion GdsIinsertaTextoFile

        #region GdsActualizarPnrConfirmacionVoid

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="reserva"></param>
        /// <param name="gds"></param>
        /// <returns></returns>
        public bool GdsActualizarPnrConfirmacionVoid(Conexion conexion,
                                                     string esquema,
                                                     string reserva,
                                                     int gds)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_Reserva", ParameterType.Varchar2, ParameterDirection.Input, reserva, 255));
                lparametros.Add(new Parametro("p_GDS", ParameterType.Int32, ParameterDirection.Input, gds));
                lparametros.Add(new Parametro("p_RowsAffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ACTUALIZA_PNR_CONFIR_VOID");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) > 0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="gds"></param>
        /// <returns></returns>
        public bool GdsActualizarPnrConfirmacionVoid(string reserva,
                                                     int gds)
        {
            return GdsActualizarPnrConfirmacionVoid(Conexion, Esquema, reserva, gds);
        }

        #endregion GdsActualizarPnrConfirmacionVoid

        #region GdsActualizarEmisionWebVoid

        /// <summary>
        /// Cambia el estado Si el pnr existe en control de confirmaciones
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="boletoPax">Estructura de datos boletoPax</param>
        /// <returns>true: si existe y le cambia el estado</returns>
        public bool GdsActualizarEmisionWebVoid(Conexion conexion,
                                                string esquema,
                                                CE_BoletoPax boletoPax)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_Reserva", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.CodReserva, 255));
                lparametros.Add(new Parametro("p_Boleto", ParameterType.Varchar2, ParameterDirection.Input, boletoPax.NumeroBoleto, 255));
                lparametros.Add(new Parametro("p_RowsAffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ACTUALIZA_PNR_CONFIR_VOID");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) > 0);
            }
        }

        /// <summary>
        /// Cambia el estado Si el pnr existe en control de confirmaciones
        /// </summary>
        /// <param name="boletoPax">Estructura de datos boletoPax</param>
        /// <returns>true: si existe y le cambia el estado</returns>
        public bool GdsActualizarEmisionWebVoid(CE_BoletoPax boletoPax)
        {
            return GdsActualizarEmisionWebVoid(Conexion, Esquema, boletoPax);
        }

        #endregion GdsActualizarEmisionWebVoid

        #endregion
    }
}
