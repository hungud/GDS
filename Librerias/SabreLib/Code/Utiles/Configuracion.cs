using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Configuration;

using SabreLib.Models;

namespace SabreLib.Utiles
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

        public static string WebServiceFileValueSabre
        {
            get { return _configFile.AppSettings.Settings["WebServiceFileValueSabre"].Value; }
        }

        public static string ManualApprovalCodeCrediCard
        {
            get { return _configFile.AppSettings.Settings["ManualApprovalCodeCrediCard"].Value; }
        }

        public static int CustomerIdTest
        {
            get { return int.Parse(_configFile.AppSettings.Settings["CustomerIdTest"].Value); }
        }

        public static int TimeSleepSeconds
        {
            get { return (int.Parse(_configFile.AppSettings.Settings["TimeSleep.Seconds"].Value) * 1000); }
        }

        #endregion

        // =================================
        // metodos estaticos

        #region "metodos estaticos"

        public static SabreCredential GetSabreCredentials(string company)
        {
            return new SabreCredential
            {
                Domain = _configFile.AppSettings.Settings[(company + ".Sabre.Credentials.Domain")].Value,
                Organization = _configFile.AppSettings.Settings[(company + ".Sabre.Credentials.Organization")].Value,
                Username = _configFile.AppSettings.Settings[(company + ".Sabre.Credentials.Username")].Value,
                Password = _configFile.AppSettings.Settings[(company + ".Sabre.Credentials.Password")].Value
            };
        }

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

        public static string GetRegularExpression(string name)
        {
            return _configFile.AppSettings.Settings[("RegularExpression." + name)].Value;
        }

        #endregion
    }
}
