using System;

using CustomLog;

using EntidadesGDS.Boleto;
using EntidadesGDS.Robot;
using EntidadesGDS.Robot.BoletosOADP;
using EntidadesGDS.Robot.BoletoPendientePago;
using BaseDatosLib.Paquetes;
using EntidadesGDS.Base;

using GDSLib.Base;
using EntidadesGDS.Models.Robot;

namespace GDSLib.PTA
{
    public sealed class Boleto : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public Boleto(string codigoSeguimiento,
                      string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public Boleto(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~Boleto()
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
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerBoletosPendientesPago(RQ_ObtenerBoletosPendientesPago parametros,
                                                       out CE_BoletoFacturado[] resultado,
                                                       bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsRobotAnulaciones = new PkgGdsRobotAnulaciones(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lpkgGdsRobotAnulaciones.GdsBoletosPendientesDePago'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    var lboletosPendientesPago = lpkgGdsRobotAnulaciones.GdsBoletosPendientesDePago(
                        Conexion,
                        Esquema,
                        parametros.TipoClienteAgencia,
                        parametros.CondicionPagoCliente,
                        parametros.TipoClientePasajero,
                        parametros.IdClientePasajero,
                        parametros.IdEmpresaSucursal,
                        parametros.MarcaEsConsolidador,
                        parametros.ListaGds,
                        parametros.ListaProveedoresBoletos,
                        parametros.Fecha,
                        parametros.AntesDeHora);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotAnulaciones.GdsBoletosPendientesDePago'", new { lboletosPendientesPago }, CodigoSeguimiento);

                    resultado = ((lboletosPendientesPago != null) ? lboletosPendientesPago.ToArray() : null);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        public CE_Estatus ObtenerBoletosEvaluacionRobotAnulaciones(RQ_ObtenerBoletosPendientesPago parametros,
                                                                   out CE_BoletoFacturado[] resultado)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsRobotAnulaciones = new PkgGdsRobotAnulaciones(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lpkgGdsRobotAnulaciones.GdsBoletosRobotAnulacion'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    var lboletosPendientesPago = lpkgGdsRobotAnulaciones.GdsBoletosRobotAnulacion(
                        Conexion,
                        Esquema,
                        parametros.Fecha,
                        int.Parse(parametros.ListaGds),
                        parametros.ListaProveedoresBoletos);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotAnulaciones.GdsBoletosRobotAnulacion'", new { lboletosPendientesPago }, CodigoSeguimiento);

                    resultado = ((lboletosPendientesPago != null) ? lboletosPendientesPago.ToArray() : null);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);
                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerBoletosSinergia(RQ_ObtenerBoletosSinergia parametros,
                                                 out CE_BoletoSinergia[] resultado,
                                                 bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsRobotAnulaciones = new PkgGdsRobotAnulaciones(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotAnulaciones.GdsBoletosSinergia'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    var lboletosSinergia = lpkgGdsRobotAnulaciones.GdsBoletosSinergia(
                        Conexion,
                        Esquema,
                        parametros.Pseudo,
                        parametros.PNR,
                        parametros.Fecha);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotAnulaciones.GdsBoletosSinergia'", new { lboletosSinergia }, CodigoSeguimiento);

                    resultado = ((lboletosSinergia != null) ? lboletosSinergia.ToArray() : null);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Este método se utiliza para obtener los datos del boletos con la finalidad de procesar los archivos OADP
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerBoletosFacturado(string numeroBoleto,
                                                  out CE_BoletoFacturado resultado,
                                                  bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsRobotBoletos = new PkgGdsRobotBoletos(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotBoletos.GdsBoletoFacturado'", new { numeroBoleto }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotBoletos.GdsBoletoFacturado(Conexion, Esquema, numeroBoleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotBoletos.GdsBoletoFacturado'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { numeroBoleto, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Este método se utiliza para obtener los datos del boletos con la finalidad de procesar los archivos OADP
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus InsertaCuerpoBoleto(RQ_InsertaCuerpoOADP parametros,
                                              out bool resultado,
                                              bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsRobotBoletos = new PkgGdsRobotBoletos(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotBoletos.GdsInsertaCuerpoBoleto'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotBoletos.GdsInsertaCuerpoBoleto(
                        Conexion,
                        Esquema,
                        parametros.PCC,
                        parametros.CodigoReserva,
                        parametros.CodigoCliente.Value,
                        parametros.NumeroBoleto,
                        parametros.TipoOadp.Value,
                        parametros.Correlativo.Value,
                        parametros.FechaEmision,
                        parametros.CuerpoDocumento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotBoletos.GdsInsertaCuerpoBoleto'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Este método se utiliza para obtener los datos del file asociado a un(os) boleto(s)
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerFileBoleto(string[] parametros,
                                            out CE_Boleto[] resultado,
                                            bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerFileBoleto'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    var lboletosFile = lpkgGdsModuloPnrPta.GdsObtenerFileBoleto(Conexion, Esquema, parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerFileBoleto'", new { lboletosFile }, CodigoSeguimiento);

                    resultado = ((lboletosFile != null) ? lboletosFile.ToArray() : null);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Este método se utiliza para obtener los datos del boletos con la finalidad de procesar los archivos OADP
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus InsertaTurboPassengerReceipt(CE_TurboPassengerReceipt parametros,
                                                       out bool resultado,
                                                       bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsRobotBoletos = new PkgGdsRobotBoletos(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotBoletos.GdsInsertaTurboPassengerReceipt'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotBoletos.GdsInsertaTurboPassengerReceipt(
                        Conexion,
                        Esquema,
                        parametros.TicketNumber,
                        parametros.PnrCode,
                        parametros.DkNumber,
                        parametros.RucNumber,
                        parametros.Pcc,
                        parametros.CounterTA,
                        parametros.CuerpoDocumento,
                        parametros.PasajeroNombre,
                        parametros.PasajeroApellido,
                        parametros.IdHeader,
                        parametros.CounterEmail,
                        parametros.FreqTravel,
                        parametros.Ruta);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotBoletos.GdsInsertaTurboPassengerReceipt'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Este método se utiliza para obtener los datos del boletos con la finalidad de procesar los archivos OADP
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus InsertaTurboCCCF(CE_TurboPassengerReceipt parametros,
                                           out bool resultado,
                                           bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsRobotBoletos = new PkgGdsRobotBoletos(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotBoletos.GdsInsertaTurboCCCF'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotBoletos.GdsInsertaTurboCCCF(
                        Conexion, 
                        Esquema, 
                        parametros.TicketNumber, 
                        parametros.PnrCode, 
                        parametros.CounterTA, 
                        parametros.CuerpoDocumento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotBoletos.GdsInsertaTurboCCCF'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Este método se utiliza para obtener los datos del boletos con la finalidad de procesar los archivos OADP
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus BuscarCodigoAerolina(CE_TurboPassengerReceipt parametros,
                                               out string resultado,
                                               bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = string.Empty;

            try
            {
                using (var lpkgGdsRobotBoletos = new PkgGdsRobotBoletos(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotBoletos.GdsBuscarCodigoAerolina'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotBoletos.GdsBuscarCodigoAerolina(Conexion, Esquema, parametros.TicketNumber, parametros.PnrCode, parametros.DkNumber);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotBoletos.GdsBuscarCodigoAerolina'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }



        public CE_Estatus GdsActualizarEstadoBoletoAnulado(RQ_AnulaBoletoPTA parametros,
                                                          out bool resultado)
        {
            var lestatus = new CE_Estatus(true);
            resultado = false;
            try
            {
                using (var lpkgGdsRobotAnulaciones = new PkgGdsRobotAnulaciones(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotAnulaciones.GdsActualizarEstadoBoletoAnulado'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotAnulaciones.GdsActualizarEstadoBoletoAnulado(
                        Conexion,
                        Esquema,
                        parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotAnulaciones.GdsActualizarEstadoBoletoAnulado'", new { resultado }, CodigoSeguimiento);
                }
            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);
                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }
            return lestatus;
        }


        #endregion
    }
}
