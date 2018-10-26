using System;
using System.Threading;
using System.Web;

using CustomLog;

namespace ServiciosGDSSoap
{
    public class Global : HttpApplication
    {
        // =============================
        // eventos

        #region "eventos"

        void Application_Start(object sender, EventArgs e)
        {
            // registrando evento
            Bitacora.Current.Debug("Iniciando Servicios GDS Soap.");

            // registrando evento
            Bitacora.Current.Debug("¿Modo Producción?", new { Configuracion.ProductionMode });
        }

        private void Application_Error(object sender, EventArgs e)
        {
            // registrando evento
            Bitacora.Current.Debug("Deteniendo Servicios GDS Soap.");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = Configuracion.Globalization;

            // registrando evento
            Bitacora.Current.Debug("Actualizando CultureInfo.");
        }

        #endregion
    }
}
