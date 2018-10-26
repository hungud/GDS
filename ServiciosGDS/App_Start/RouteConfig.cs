using System.Web.Http;
using System.Web.Routing;

namespace ServiciosGDS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapHttpRoute(
              name: "Api UriPathExtension",
              routeTemplate: "api/{controller}.{extension}/{action}",
              defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            );

            routes.MapHttpRoute(
              name: "Api UriPathExtension ID",
              routeTemplate: "api/{controller}/{action}.{extension}",
              defaults: new { id = RouteParameter.Optional, extension = RouteParameter.Optional }
            );
        }
    }
}
