using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace AmadeusLib.Utiles
{
    internal static class Configuracion
    {
        // =================================
        // variables estaticas

        #region "variables estaticas"

        private static readonly Configuration _configFile;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        static Configuracion()
        {
            // abriendo archivo de configuración propio
            _configFile =
                ConfigurationManager.OpenMappedExeConfiguration(
                    new ExeConfigurationFileMap { ExeConfigFilename = Ambiente.ConfigFilePath },
                    ConfigurationUserLevel.None
                );
        }

        #endregion

        // =================================
        // propiedades estaticas

        #region "propiedades estaticas"

        public static string WebServiceFileValueAmadeus
        {
            get { return _configFile.AppSettings.Settings["WebServiceFileValueAmadeus"].Value; }
        }

        #endregion

        // =================================
        // metodos estaticos

        #region "metodos estaticos"

        public static T GetServiceModelClient<T>()
            where T : IClientChannel
        {
            var lchannelType = typeof(T);

            var lcontractType = lchannelType.GetInterfaces().First(i => (i.Namespace == lchannelType.Namespace));

            var lcontractAttribute = (lcontractType.GetCustomAttributes(typeof(ServiceContractAttribute), false).First() as ServiceContractAttribute);

            var lserviceModelSectionGroup = ServiceModelSectionGroup.GetSectionGroup(_configFile);

            var lendpoint = lserviceModelSectionGroup.Client.Endpoints
                .OfType<ChannelEndpointElement>()
                    .First(e => e.Contract == lcontractAttribute.ConfigurationName);

            // To turn on TLS 1.1 and 1.2 without affecting other protocols:
            // ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            // To turn off SSL3 without affecting other protocols:
            // System.Net.ServicePointManager.SecurityProtocol &= ~SecurityProtocolType.Ssl3;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var lchannelFactory = new ConfigurationChannelFactory<T>(lendpoint.Name, _configFile, null);

            var lclient = lchannelFactory.CreateChannel();

            return lclient;
        }

        #endregion
    }
}
