using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServiciosGDS.Handlers
{
    public class HttpsHandler : DelegatingHandler
    {
        // =============================
        // eventos

        #region "eventos"

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            if (!string.Equals(request.RequestUri.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                return Task.Factory.StartNew(() => new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("HTTPS Required")
                }, 
                cancellationToken);
            }

            return base.SendAsync(request, cancellationToken);
        }

        #endregion
    }
}
