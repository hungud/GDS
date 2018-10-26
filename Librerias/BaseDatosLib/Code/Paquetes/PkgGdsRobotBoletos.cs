using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS.Robot;
using EntidadesGDS;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsRobotBoletos : Common
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
        public PkgGdsRobotBoletos(string codigoSeguimiento,
                                  Conexion conexion,
                                  string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_ROBOT_BOLETOS")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsRobotBoletos(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsRobotBoletos()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "GdsBoletoFacturado"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        public  CE_BoletoFacturado GdsBoletoFacturado(Conexion conexion,
                                                      string esquema,
                                                      string numeroBoleto)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_ticketnumbre", ParameterType.Varchar2, ParameterDirection.Input, numeroBoleto, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_BOLETO_FACTURADO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_BoletoFacturado>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        public CE_BoletoFacturado GdsBoletoFacturado(string numeroBoleto)
        {
            return GdsBoletoFacturado(Conexion, Esquema, numeroBoleto);
        }

        #endregion

        #region "GdsInsertaCuerpoBoleto"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pcc"></param>
        /// <param name="codigoReserva"></param>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="tipoOadp"></param>
        /// <param name="correlativo"></param>
        /// <param name="fechaEmision"></param>
        /// <param name="cuerpoDocumento"></param>
        /// <returns></returns>
        public bool GdsInsertaCuerpoBoleto(Conexion conexion,
                                           string esquema,
                                           string pcc,
                                           string codigoReserva,
                                           int codigoCliente,
                                           string numeroBoleto,
                                           EnumTipoOADP tipoOadp,
                                           int correlativo,
                                           string fechaEmision,
                                           string cuerpoDocumento)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pcc", ParameterType.Varchar2, ParameterDirection.Input, pcc, 12));
                lparametros.Add(new Parametro("p_codigoreserva", ParameterType.Varchar2, ParameterDirection.Input, codigoReserva, 6));
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, codigoCliente));
                lparametros.Add(new Parametro("p_numeroboleto", ParameterType.Varchar2, ParameterDirection.Input, numeroBoleto, 13));
                lparametros.Add(new Parametro("p_tipooadp", ParameterType.Int32, ParameterDirection.Input, ((int) tipoOadp), 1));
                lparametros.Add(new Parametro("p_correlativo", ParameterType.Int32, ParameterDirection.Input, correlativo, 1));
                lparametros.Add(new Parametro("p_FechaEmision", ParameterType.Clob, ParameterDirection.Input, fechaEmision));
                lparametros.Add(new Parametro("p_cuerpoboleto", ParameterType.Clob, ParameterDirection.Input, cuerpoDocumento));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTA_CUERPO_OADP");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado
                var lregistrosAfectados = int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString());

                // evaluando si se realizo la inserción
                return (lregistrosAfectados == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pcc"></param>
        /// <param name="codigoReserva"></param>
        /// <param name="codigoCliente"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="tipoOadp"></param>
        /// <param name="correlativo"></param>
        /// <param name="fechaEmision"></param>
        /// <param name="cuerpoDocumento"></param>
        /// <returns></returns>
        public bool GdsInsertaCuerpoBoleto(string pcc,
                                           string codigoReserva,
                                           int codigoCliente,
                                           string numeroBoleto,
                                           EnumTipoOADP tipoOadp,
                                           int correlativo,
                                           string fechaEmision,
                                           string cuerpoDocumento)
        {
            return GdsInsertaCuerpoBoleto(Conexion, Esquema, pcc, codigoReserva, codigoCliente, numeroBoleto, tipoOadp, correlativo, fechaEmision,cuerpoDocumento);
        }

        #endregion

        #region "GdsInsertaTurboPassengerReceipt"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="ticketNumber"></param>
        /// <param name="pnrCode"></param>
        /// <param name="dkNumber"></param>
        /// <param name="rucNumber"></param>
        /// <param name="pcc"></param>
        /// <param name="counterTA"></param>
        /// <param name="cuerpoDocumento"></param>
        /// <param name="pasajeroNombre"></param>
        /// <param name="pasajeroApellido"></param>
        /// <param name="idHeader"></param>
        /// <param name="counterEmail"></param>
        /// <param name="freqTravel"></param>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public bool GdsInsertaTurboPassengerReceipt(Conexion conexion,
                                                    string esquema,
                                                    string ticketNumber,
                                                    string pnrCode,
                                                    int dkNumber,
                                                    string rucNumber,
                                                    string pcc,
                                                    string counterTA,
                                                    string cuerpoDocumento,
                                                    string pasajeroNombre,
                                                    string pasajeroApellido,
                                                    EnumHeaderPassengerReceipt idHeader,
                                                    string counterEmail,
                                                    string freqTravel,
                                                    string ruta)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_ticketnumber", ParameterType.Varchar2, ParameterDirection.Input, ticketNumber, 10));
                lparametros.Add(new Parametro("p_pnrcode", ParameterType.Varchar2, ParameterDirection.Input, pnrCode, 6));
                lparametros.Add(new Parametro("p_dknumber", ParameterType.Int32, ParameterDirection.Input, dkNumber));
                lparametros.Add(new Parametro("p_rucnumber", ParameterType.Varchar2, ParameterDirection.Input, rucNumber, 11));
                lparametros.Add(new Parametro("p_pcc", ParameterType.Varchar2, ParameterDirection.Input, pcc, 4));
                lparametros.Add(new Parametro("p_counterta", ParameterType.Varchar2, ParameterDirection.Input, counterTA, 6));
                lparametros.Add(new Parametro("p_cuerpodocumento", ParameterType.Clob, ParameterDirection.Input, cuerpoDocumento));
                lparametros.Add(new Parametro("p_pasajeronombre", ParameterType.Varchar2, ParameterDirection.Input,pasajeroNombre, 30));
                lparametros.Add(new Parametro("p_pasajeroapellido", ParameterType.Varchar2, ParameterDirection.Input,pasajeroApellido, 30));
                lparametros.Add(new Parametro("p_idheader", ParameterType.Int32, ParameterDirection.Input,(int) idHeader));
                lparametros.Add(new Parametro("p_counteremail", ParameterType.Varchar2, ParameterDirection.Input,counterEmail, 300));
                lparametros.Add(new Parametro("p_freqtravel", ParameterType.Varchar2, ParameterDirection.Input, freqTravel,20));
                lparametros.Add(new Parametro("p_ruta", ParameterType.Varchar2, ParameterDirection.Input, ruta, 300));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTA_TPR");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado
                var lregistrosAfectados = int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString());

                // evaluando si se realizo la inserción
                return (lregistrosAfectados == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticketNumber"></param>
        /// <param name="pnrCode"></param>
        /// <param name="dkNumber"></param>
        /// <param name="rucNumber"></param>
        /// <param name="pcc"></param>
        /// <param name="counterTA"></param>
        /// <param name="cuerpoDocumento"></param>
        /// <param name="pasajeroNombre"></param>
        /// <param name="pasajeroApellido"></param>
        /// <param name="idHeader"></param>
        /// <param name="counterEmail"></param>
        /// <param name="freqTravel"></param>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public bool GdsInsertaTurboPassengerReceipt(string ticketNumber,
                                                    string pnrCode,
                                                    int dkNumber,
                                                    string rucNumber,
                                                    string pcc,
                                                    string counterTA,
                                                    string cuerpoDocumento,
                                                    string pasajeroNombre,
                                                    string pasajeroApellido,
                                                    EnumHeaderPassengerReceipt idHeader,
                                                    string counterEmail,
                                                    string freqTravel,
                                                    string ruta)
        {
            return GdsInsertaTurboPassengerReceipt(Conexion,
                                                   Esquema,
                                                   ticketNumber,
                                                   pnrCode,
                                                   dkNumber,
                                                   rucNumber,
                                                   pcc,
                                                   counterTA,
                                                   cuerpoDocumento,
                                                   pasajeroNombre,
                                                   pasajeroApellido,
                                                   idHeader,
                                                   counterEmail,
                                                   freqTravel,
                                                   ruta);
        }

        #endregion

        #region "GdsInsertaTurboCCCF"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="ticketNumber"></param>
        /// <param name="pnrCode"></param>
        /// <param name="dkNumber"></param>
        /// <param name="rucNumber"></param>
        /// <param name="pcc"></param>
        /// <param name="counterTA"></param>
        /// <param name="cuerpoDocumento"></param>
        /// <param name="pasajeroNombre"></param>
        /// <param name="pasajeroApellido"></param>
        /// <param name="idHeader"></param>
        /// <param name="counterEmail"></param>
        /// <param name="freqTravel"></param>
        /// <param name="ruta"></param>
        /// <returns></returns>
        public bool GdsInsertaTurboCCCF(Conexion conexion,
                                                    string esquema,
                                                    string ticketNumber,
                                                    string pnrCode,
                                                    string counterTA,
                                                    string cuerpoDocumento)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnrcode", ParameterType.Varchar2, ParameterDirection.Input, pnrCode, 6));
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, counterTA, 6));
                lparametros.Add(new Parametro("p_printflag", ParameterType.Int32, ParameterDirection.Input, 1));
                lparametros.Add(new Parametro("p_ticketnumber", ParameterType.Varchar2, ParameterDirection.Input, ticketNumber, 10));
                lparametros.Add(new Parametro("p_cuerpodocumento", ParameterType.Clob, ParameterDirection.Input, cuerpoDocumento));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTA_CCCF");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado
                var lregistrosAfectados = int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString());

                // evaluando si se realizo la inserción
                return (lregistrosAfectados == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticketNumber"></param>
        /// <param name="pnrCode"></param>
        /// <param name="counterTA"></param>
        /// <param name="cuerpoDocumento"></param>
        /// <returns></returns>
        public bool GdsInsertaTurboCCCF(string ticketNumber,
                                                    string pnrCode,
                                                    string counterTA,
                                                    string cuerpoDocumento)
        {
            return GdsInsertaTurboCCCF(Conexion, Esquema, ticketNumber, pnrCode, counterTA, cuerpoDocumento);
        }

        #endregion

        #region "GdsBuscarCodigoAerolina"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="ticketNumber"></param>
        /// <param name="pnrCode"></param>
        /// <param name="dkNumber"></param>
        /// <returns></returns>
        public string GdsBuscarCodigoAerolina(Conexion conexion,
                                              string esquema,
                                              string ticketNumber,
                                              string pnrCode,
                                              int dkNumber)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pnrcode", ParameterType.Varchar2, ParameterDirection.Input, pnrCode, 6));
                lparametros.Add(new Parametro("p_dknumber", ParameterType.Int32, ParameterDirection.Input, dkNumber));
                lparametros.Add(new Parametro("p_ticketnumber", ParameterType.Varchar2, ParameterDirection.Input, ticketNumber, 10));
                lparametros.Add(new Parametro("p_codaerolinea", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_BUSCAR_CODAEROLINEA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado
                var lresultado = lparametros.Find("p_CodAerolinea").Valor.TrimOrNull();

                return lresultado;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticketNumber"></param>
        /// <param name="pnrCode"></param>
        /// <param name="dkNumber"></param>
        /// <returns></returns>
        public string GdsBuscarCodigoAerolina(string ticketNumber,
                                              string pnrCode,
                                              int dkNumber)
        {
            return GdsBuscarCodigoAerolina(Conexion, Esquema, ticketNumber, pnrCode, dkNumber);
        }

        #endregion

        #endregion
    }
}
