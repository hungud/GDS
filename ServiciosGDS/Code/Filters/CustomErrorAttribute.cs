using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

using CustomLog;

namespace ServiciosGDS.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomErrorAttribute : ExceptionFilterAttribute
    {
        // =============================
        // eventos

        #region "eventos"

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // registrando evento
            Bitacora.Current.Error(actionExecutedContext.Exception, new { actionExecutedContext.ActionContext.ActionArguments });

            //var exceptionType = actionExecutedContext.Exception.GetType();
            //var message = ((exceptionType == typeof(MyException)) ? actionExecutedContext.Exception.Message : "Error no Esperado.");

            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent("Error Inesperado en los Servicio GDS.", Encoding.UTF8, "text/plain"),
                StatusCode = HttpStatusCode.InternalServerError
            };

            base.OnException(actionExecutedContext);
        }

        #endregion
    }
}
