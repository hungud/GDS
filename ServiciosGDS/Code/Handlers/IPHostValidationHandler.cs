using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading;
using System.Threading.Tasks;

//using ServiciosGDS.Utils;

namespace ServiciosGDS.Handlers
{
    public class IPHostValidationHandler : DelegatingHandler
    {
        // =============================
        // eventos

        #region "eventos"

        /*
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken) 
        {
            var lcontext = ((HttpContextBase) request.Properties["MS_HttpContext"]);

            var luserIP = lcontext.Request.UserHostAddress;
 
            var foundIP = Configuracion.AuthorizedIPClients.FirstOrDefault(e => e.Equals(luserIP, StringComparison.InvariantCultureIgnoreCase));

            if (foundIP == null)
            {
                //return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.Forbidden)
                //{
                //    Content = new StringContent("Unauthorized IP Address")
                //}, 
                //cancellationToken);

                // optimizacion
                var lmessage = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized IP Address ++")
                };

                var lcompleteTask = new TaskCompletionSource<HttpResponseMessage>();

                lcompleteTask.SetResult(lmessage);

                return lcompleteTask.Task;
            }

            return base.SendAsync(request, cancellationToken);
        }
        */

        #endregion
    }
}
