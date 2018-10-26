using System;
using System.Collections.Generic;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.TarjetaCredito;
using BaseDatosLib.PaquetesWeb;

using GDSLib.Base;

namespace GDSLib.PTA
{
    public class SesionB2BWallet : Common
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
        public SesionB2BWallet(string codigoSeguimiento,
                                    string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        public SesionB2BWallet(EnumAplicaciones? aplicacion, string codigoSeguimiento,
                                    string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public SesionB2BWallet(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~SesionB2BWallet()
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
        /// <param name="parametro"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerSesion(int parametro,
                                        out List<CE_SessionB2BWallet> resultado)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsSabreRed = new PkgGdsSesionB2BWallet(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSabreRed.GdsObtenerSesion'", new { parametro }, CodigoSeguimiento);

                    resultado = lpkgGdsSabreRed.GdsObtenerSesion(Conexion, Esquema, parametro);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSabreRed.GdsObtenerSesion'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametro }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarSesion(CE_SessionB2BWallet parametro,
                                           out bool resultado)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsSabreRed = new PkgGdsSesionB2BWallet(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSabreRed.ActualizarSesion'", new { parametro }, CodigoSeguimiento);

                    resultado = lpkgGdsSabreRed.ActualizarSesion(Conexion, Esquema, parametro);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSabreRed.ActualizarSesion'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametro }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
