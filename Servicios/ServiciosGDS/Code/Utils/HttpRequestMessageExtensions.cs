using System.Linq;
using System.Net.Http;
using System.Web.Http.Controllers;

using CoreLib.Generics;

namespace ServiciosGDS.Utils
{
    public static class HttpRequestMessageExtensions
    {
        // =============================
        // variables

        #region "variables"

        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";

        #endregion

        // =============================
        // metodos estaticos

        #region "metodos estaticos"

        public static string GetClientIpAddress(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];

                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];

                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            return null;
        }

        public static string GetArgumentsInformation(this HttpActionContext actionContext)
        {
            var largumentos = string.Empty;

            if (actionContext.ActionArguments.Keys.Any())
            {
                largumentos =
                    string.Format(
                        "con los siguientes argumentos:\r\r{0}",
                        Strings.ToDictionary(actionContext.ActionArguments, PropertiesStringSetting.Both)
                    );
            }

            var lresultado =
                string.Format(
                    "Desde la IP '{0}' se invoco al action: '{1}' {2}",
                    GetClientIpAddress(actionContext.Request),
                    actionContext.Request.RequestUri.AbsolutePath,
                    largumentos
                );

            return lresultado;
        }

        #endregion
    }
}
