using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using AmadeusLib.Herramientas;
using AmadeusLib.Ticket;

using GDSLib.Base;

namespace GDSLib.Amadeus
{
    public sealed class Herramienta : Common2
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public Herramienta(EnumAplicaciones aplicacion,
                           string codigoSeguimiento,
                           string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno)
        {
        }

        public Herramienta()
        {
        }

        ~Herramienta()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        public CE_Estatus Ejecutar(string comando,
                                   ref CE_Session sesion)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lcommandCryptic = new CommandCryptic(Aplicacion.Value, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lcommandCryptic.Execute'", new { comando, sesion }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lcommandCryptic.Execute(comando, ref sesion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lcommandCryptic.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { comando }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        public CE_Estatus Ignorar(ref CE_Session sesion)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lcommandCryptic = new CommandCryptic(Aplicacion.Value, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lcommandCryptic.Ignorar'", new { sesion }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lcommandCryptic.Ignorar(ref sesion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lcommandCryptic.Ignorar'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { sesion }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
