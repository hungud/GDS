using System;

using CoreWebLib;
using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Reglas;
using BaseDatosLib.Paquetes;

using GDSLib.Base;

namespace GDSLib.PTA
{
    public sealed class ReglasEmision : Common
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
        public ReglasEmision(string codigoSeguimiento,
                             string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public ReglasEmision(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~ReglasEmision()
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
        public CE_Estatus NoPermiteTransportador(RQ_ObtenerReglasEmision parametros,
                                                 out bool resultado,
                                                 bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = true;

            try
            {
                using (var lpkgGdsReglasEmision = new PkgGdsReglasEmision(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsReglasEmision.GdsNoPermiteTransportador'", new { parametros.IdTransportador, parametros.Pseudo, parametros.Gds.Value }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsReglasEmision.GdsNoPermiteTransportador(
                        Conexion,
                        Esquema,
                        parametros.IdTransportador,
                        parametros.Pseudo,
                        parametros.Gds.Value);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsReglasEmision.GdsNoPermiteTransportador'", new { resultado }, CodigoSeguimiento);
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
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerListaPermiteTransportador(CE_ReglaEmision parametros,
                                                           out CE_ReglaEmision[] resultado,
                                                           bool muteErrors = true)
        {
            var lmensaje = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsReglasEmision = new PkgGdsReglasEmision(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsReglasEmision.GdsObtenerListaPermiteTran'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    var llistaPermiteTransportador = lpkgGdsReglasEmision.GdsObtenerListaPermiteTran(Conexion, Esquema, parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsReglasEmision.GdsObtenerListaPermiteTran'", new { llistaPermiteTransportador }, CodigoSeguimiento);

                    resultado = ((llistaPermiteTransportador != null) ? llistaPermiteTransportador.ToArray() : null);
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
                lmensaje = new CE_Estatus(ex);
            }

            return lmensaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus AnadirPermiteTransportador(CE_ReglaEmision parametros,
                                                     out bool resultado,
                                                     bool muteErrors = true)
        {
            var lmensaje = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsReglasEmision = new PkgGdsReglasEmision(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsReglasEmision.GdsAnadirPermiteTran'", new { parametros }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsReglasEmision.GdsAnadirPermiteTran(Conexion, Esquema, parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsReglasEmision.GdsAnadirPermiteTran'", new { resultado }, CodigoSeguimiento);
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
                lmensaje = new CE_Estatus(ex);
            }

            return lmensaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="registrosAfectados"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus EliminarPermiteTransportador(CE_ReglaEmision[] parametros,
                                                       out int registrosAfectados,
                                                       bool muteErrors = true)
        {
            var lmensaje = new CE_Estatus(true);

            registrosAfectados = 0;

            try
            {
                using (var lpkgGdsGeneric = new PkgGdsGeneric(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

                    // iniciando transacción
                    Conexion.IniciarTransaccion();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsDeleteReglasEmision'", CodigoSeguimiento);

                    // convirtiendo parametro a xml string
                    var lparametrosXml = XmlHelper.XmlSerializerforOracle(parametros, false, true);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsDeletePermiteTransportador'", CodigoSeguimiento);

                    // ejecutando procedimiento
                    lpkgGdsGeneric.GdsDeletePermiteTransportador(Conexion, Esquema, lparametrosXml, out registrosAfectados);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsDeleteReglasEmision'", new { registrosAfectados }, CodigoSeguimiento);

                    // evaluando si cancelar transaccion
                    var lcancelarTransaccion = ((registrosAfectados == 0) || (registrosAfectados > parametros.Length));

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.FinalizarTransaccion'", new { lcancelarTransaccion }, CodigoSeguimiento);

                    // finalizando transacción
                    Conexion.FinalizarTransaccion(lcancelarTransaccion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.FinalizarTransaccio'", CodigoSeguimiento);

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
                lmensaje = new CE_Estatus(ex);
            }

            return lmensaje;
        }

        #endregion
    }
}
