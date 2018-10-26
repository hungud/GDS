using System;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.TarjetaCredito;
using EntidadesGDS.Solicitudes;
using BaseDatosLib.Paquetes;

using GDSLib.Base;

namespace GDSLib.WEB
{
    public sealed class Solicitud : Common
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
        public Solicitud(string codigoSeguimiento,
                         string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public Solicitud(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~Solicitud()
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
        public CE_Estatus ObtenerDatosTarjeta(RQ_TarjetaCreditoSolicitud parametros,
                                              out CE_EvaluacionTarjetaPTA resultado,
                                              bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            try
            {
                using (var lpkgGdsSolicitudes = new PkgGdsSolicitudes(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSolicitudes.ObtenerDatosTarjeta'", new { parametros.CodigoSolicitud, parametros.PNR, parametros.IdCliente }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsSolicitudes.ObtenerDatosTarjeta(
                        Conexion,
                        Esquema,
                        parametros.CodigoSolicitud.Value,
                        parametros.PNR,
                        parametros.IdCliente.Value);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSolicitudes.ObtenerDatosTarjeta'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                resultado = null;

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
        /// 
        /// </summary>
        /// <param name="idUsuarioWeb"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus PoseePermisoParaRemitir(string idUsuarioWeb,
                                                  out bool resultado,
                                                  bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            try
            {
                using (var lpkgPermisos = new PkgPermisos(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgPermisos.SpPermReemisionAut'", new { idUsuarioWeb }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgPermisos.SpPermReemisionAut(Conexion, Esquema, idUsuarioWeb);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgPermisos.SpPermReemisionAut'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { idUsuarioWeb, muteErrors }, CodigoSeguimiento);

                resultado = false;

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

        #endregion
    }
}
