using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ServiciosGDS.Filters
{
    public class CustomHttpsAttribute : ActionFilterAttribute
    {
        // =============================
        // eventos

        #region "eventos"

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!string.Equals(actionContext.Request.RequestUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("HTTPS Required")
                };
            }
        }

        #endregion
    }
}
