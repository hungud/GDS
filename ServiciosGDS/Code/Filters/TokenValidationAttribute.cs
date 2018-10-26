using System;
using System.Linq;
using System.Net;

using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

using CoreLib.Encriptador;

namespace ServiciosGDS.Filters
{
    public class TokenValidationAttribute : ActionFilterAttribute
    {
        // =============================
        // eventos

        #region "eventos"

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string lusername;
            string lpassword;

            try
            {
                lusername = actionContext.Request.Headers.GetValues("Authorization-Username").First();
                lpassword = actionContext.Request.Headers.GetValues("Authorization-Password").First();

            }
            catch (Exception)
            {
                actionContext.Response = 
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Missing Authorization Credentials")
                    };
                return;
            }

            try
            {
                lusername = RSAClass.Decrypt(Configuracion.RSAPrivateKey, lusername);
                lpassword = RSAClass.Decrypt(Configuracion.RSAPrivateKey, lpassword);

                var lauthorizedUsername = Configuracion.AuthorizedUsername;
                var lauthorizedPassword = Configuracion.AuthorizedPassword;

                if ((!lauthorizedUsername.Equals(lusername, StringComparison.InvariantCultureIgnoreCase))
                    || (!lauthorizedPassword.Equals(lpassword, StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new Exception(); 
                }

                base.OnActionExecuting(actionContext);

            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized User")
                };
            }
        }

        #endregion
    }
}
