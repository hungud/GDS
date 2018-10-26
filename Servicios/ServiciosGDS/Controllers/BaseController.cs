using System.Web.Http;

using ServiciosGDS.Utils;

namespace ServiciosGDS.Controllers
{
    public class BaseController : ApiController
    {
        // =============================
        // HttpGet

        #region "HttpGet"

        [HttpGet]
        [ActionName("AcercaDe")]
        public string AcercaDe()
        {
            return Ambiente.ApplicationAcercaDe;
        }

        #endregion
    }
}
