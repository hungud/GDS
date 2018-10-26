using System.Net.Http.Formatting;
using System.Web.Http;

using ServiciosGDS.Filters;

namespace ServiciosGDS
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.AddUriPathExtensionMapping("json", "application/json");
            config.Formatters.XmlFormatter.AddUriPathExtensionMapping("xml", "text/xml");
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            config.Filters.Add(new CustomErrorAttribute());
            config.Filters.Add(new CustomActionAttribute());

            //config.Filters.Add(new IPHostValidationAttribute());
            //config.Filters.Add(new CustomHttpsAttribute());
            //config.Filters.Add(new TokenValidationAttribute());

            //config.MessageHandlers.Add(new Servicios.Handlers.HttpsHandler());
            //config.MessageHandlers.Add(new Servicios.Handlers.IPHostValidationHandler());

            // Para deshabilitar el seguimiento en la aplicación, incluya un comentario o quite la siguiente línea de código
            // Para obtener más información, consulte: http://www.asp.net/web-api
            //config.EnableSystemDiagnosticsTracing();
        }
    }
}
