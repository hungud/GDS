using System.Configuration;
using System.Linq;
using System.Net;

using KiuLib.Models;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace KiuLib.Utiles
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

        public static string URL
        {
            get { return _configFile.AppSettings.Settings["Servico.URL"].Value; }
        }
     
        #endregion

        // =================================
        // metodos estaticos

        #region "metodos estaticos"

        public static KiuCredential GetKiuCredentials(string company)
        {
            return new KiuCredential
            {
                PseudoCity = _configFile.AppSettings.Settings[("Credentials.PseudoCity")].Value,
                Country = _configFile.AppSettings.Settings[("Credentials.Country")].Value,
                Currency = _configFile.AppSettings.Settings[("Credentials.Currency")].Value,
                Agent = _configFile.AppSettings.Settings[(company + ".Kiu.Credentials.Agent")].Value,
                Terminal = _configFile.AppSettings.Settings[(company + ".Kiu.Credentials.Terminal")].Value,
            };
        }


        public static KiuHeader GetKiuHeader()
        {
            return new KiuHeader
            {
                EchoToken = _configFile.AppSettings.Settings[("Header.EchoToken")].Value,
                Target = _configFile.AppSettings.Settings[("Header.Target")].Value,
                Version = _configFile.AppSettings.Settings[("Header.Version")].Value,
                PrimaryLangID = _configFile.AppSettings.Settings[("Header.PrimaryLangID")].Value,
            };
        }

      
        public static string GetKiuResultado(string sXML)
           {
               string responsebody = null;

                using (var client = new WebClient())
                {

                   var Username = _configFile.AppSettings.Settings[("Credentials.Username")].Value;
                   var Password = _configFile.AppSettings.Settings[("Credentials.Password")].Value;
                   var URL = _configFile.AppSettings.Settings[("Servico.URL")].Value;


                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var reqparm = new NameValueCollection
                        {
                            {"user", Username},
                            {"password", Password},
                            {"request", sXML}
                        };

                    var responsebytes = client.UploadValues(URL, "POST", reqparm);
                    responsebody = (new UTF8Encoding()).GetString(responsebytes);

                    responsebody =  responsebody.Substring(responsebody.IndexOf("UTF-8") + 8);
                }

            return responsebody;


        }



        public static TResponse GetKiuResultado2<TResponse,TRequest>(dynamic Objeto)
        {
            string sXML = null;
            string responsebody = null;
           

            //Convierte el objeto a XML
            using (StringWriter stringwriter = new StringWriter())
            {
                var serializer = new XmlSerializer(typeof(TRequest));
                serializer.Serialize(stringwriter, Objeto);
                sXML = stringwriter.ToString().Replace("utf-16", "utf-8");
            }


            //Ejecuta el servicio de KIU
            using (var client = new WebClient())
            {

                var Username = _configFile.AppSettings.Settings[("Credentials.Username")].Value;
                var Password = _configFile.AppSettings.Settings[("Credentials.Password")].Value;
                var URL = _configFile.AppSettings.Settings[("Servico.URL")].Value;


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var reqparm = new NameValueCollection
                        {
                            {"user", Username},
                            {"password", Password},
                            {"request", sXML}
                        };

                var responsebytes = client.UploadValues(URL, "POST", reqparm);
                responsebody = (new UTF8Encoding()).GetString(responsebytes);

                responsebody = responsebody.Substring(responsebody.IndexOf("UTF-8") + 8);
            }


            //Convierte la respuesta XML a una clase
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(responsebody);

            var odSerializer = new XmlSerializer(typeof(TResponse));
            using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDoc.DocumentElement))
            {
                return (TResponse)odSerializer.Deserialize(xmlNodeReader);
            }


        }


        
        #endregion
    }
}
