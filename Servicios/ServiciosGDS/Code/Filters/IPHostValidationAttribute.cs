using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using ServiciosGDS.Utils;

namespace ServiciosGDS.Filters
{
    public class IPHostValidationAttribute : ActionFilterAttribute
    {
        // =============================
        // eventos

        #region "eventos"

        /*
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var lcontext = ((HttpContextBase) actionContext.Request.Properties["MS_HttpContext"]);

            var luserIP = lcontext.Request.UserHostAddress;

            try
            {
                Configuracion.AuthorizedIPClients.First(e => e.Equals(luserIP, StringComparison.InvariantCultureIgnoreCase));

            }
            catch (Exception)
            {
                actionContext.Response =
                   new HttpResponseMessage(HttpStatusCode.Forbidden)
                   {
                       Content = new StringContent("Unauthorized IP Address")
                   };
            }
        }
        */

        #endregion
    }
}
