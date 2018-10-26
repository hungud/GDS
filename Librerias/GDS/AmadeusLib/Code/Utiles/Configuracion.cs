using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;

using EntidadesGDS;

using AmadeusLib.Models;

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

        private static string ExecutionPath
        {
            get
            {
                // obteniendo la ruta completa de la libreria (incluyendo el nombre de la misma)
                var lpath = (new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;

                // retornando la ruta (sin incluir el nombre de la libreria)
                return (Path.GetDirectoryName(lpath) + @"\\");
            }
        }

        public static string WebServiceFileValueAmadeus
        {
            get { return ExecutionPath + _configFile.AppSettings.Settings["WebServiceFileValueAmadeus"].Value; }
        }

        public static string B2BServiceFileValueAmadeus
        {
            get { return _configFile.AppSettings.Settings["B2BServiceFileValueAmadeus"].Value; }
        }

        public static string ManualApprovalCodeCrediCard
        {
            get { return _configFile.AppSettings.Settings["ManualApprovalCodeCrediCard"].Value; }
        }

        public static int CustomerIdTest
        {
            get { return int.Parse(_configFile.AppSettings.Settings["CustomerIdTest"].Value); }
        }

        public static string PathLogServiceHeader4
        {
            get { return _configFile.AppSettings.Settings["PathLogWebServiceFileValueAmadeus"].Value; }
        }

        public static bool EnableLogHeader4
        {
            get { return _configFile.AppSettings.Settings["EnableLogHeader4"].Value.Equals("1"); }
        }

        #endregion

        // =================================
        // metodos estaticos

        #region "metodos estaticos"

        public static AmadeusCredential GetAmadeusCredentials(string company, EnumEnvironment environment)
        {
            return new AmadeusCredential
            {
                WSAP = _configFile.AppSettings.Settings["Amadeus.Credentials.WSAP." + environment].Value,
                EndPoint = _configFile.AppSettings.Settings["Amadeus.Credentials.EndPoint." + environment].Value,
                UserId = _configFile.AppSettings.Settings[(company + ".Amadeus.Credentials.UserID." + environment)].Value,
                OfficeId = _configFile.AppSettings.Settings[(company + ".Amadeus.Credentials.OfficeID")].Value,
                BinaryData = _configFile.AppSettings.Settings[(company + ".Amadeus.Credentials.BinaryData." + environment)].Value
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

        public static string GetIataByOfficeID(string officeId)
        {
            return _configFile.AppSettings.Settings["Amadeus.Iata." + officeId].Value;
        }

        #endregion
    }
}
