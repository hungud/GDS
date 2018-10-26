using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

using CustomLog;

namespace ServiciosGDS
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        // =============================
        // eventos

        #region "eventos"

        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // registrando evento
            Bitacora.Current.Debug("Iniciando Servicios GDS.");

            // registrando evento
            Bitacora.Current.Debug("¿Modo Producción?", new { Configuracion.ProductionMode });
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // registrando evento
            Bitacora.Current.Debug("Deteniendo Servicios GDS.");
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = Configuracion.Globalization;

            // registrando evento
            Bitacora.Current.Debug("Actualizando CultureInfo.");

            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");

            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, PUT, DELETE");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        #endregion
    }
}
