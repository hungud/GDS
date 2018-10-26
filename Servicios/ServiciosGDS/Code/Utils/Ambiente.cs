using System.Reflection;
using System.Web.Hosting;

namespace ServiciosGDS.Utils
{
    public static class Ambiente
    {
        // =============================
        // propiedades

        #region "propiedades"

        public static string ApplicationAcercaDe
        {
            get
            {
                var lassembly = Assembly.GetExecutingAssembly().GetName();

                return string.Format("{0} {1}", lassembly.Name, lassembly.Version);
            }
        }

        public static string ApplicationPhysicalPath
        {
            get { return HostingEnvironment.ApplicationPhysicalPath; }
        }

        #endregion
    }
}
