using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using CustomLog;

namespace ServiciosGDS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomActionAttribute : ActionFilterAttribute
    {
        // =============================
        // eventos

        #region "eventos"

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            // registrando evento
            Bitacora.Current.Debug(null, new { actionContext.ActionArguments });
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            // registrando evento
            Bitacora.Current.Debug(null, new { ((ObjectContent) actionExecutedContext.Response.Content).Value });

            base.OnActionExecuted(actionExecutedContext);
        }

        #endregion
    }
}
