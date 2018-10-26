using System.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace ServiciosGDS
{
    public static class Configuracion
    {
        // =================================
        // propiedades estaticas

        #region "propiedades estaticas"

        public static string RSAPrivateKey
        {
            get { return ConfigurationManager.AppSettings["RSAPrivateKey"]; }
        }

        public static string AuthorizedUsername
        {
            get { return ConfigurationManager.AppSettings["AuthorizedUsername"]; }
        }

        public static string AuthorizedPassword
        {
            get { return ConfigurationManager.AppSettings["AuthorizedPassword"]; }
        }

        public static IEnumerable<string> AuthorizedIPClients
        {
            get
            {
                var lvalor = ConfigurationManager.AppSettings["AuthorizedIPClients"];

                return (string.IsNullOrEmpty(lvalor) ? null : lvalor.Split(';'));
            }
        }

        public static CultureInfo Globalization
        {
            get
            {
                return new CultureInfo(ConfigurationManager.AppSettings["Globalization.CultureInfo"].Trim())
                {
                    DateTimeFormat = new DateTimeFormatInfo
                    {
                        DateSeparator = ConfigurationManager.AppSettings["Globalization.DateSeparator"].Trim(),
                        ShortDatePattern = ConfigurationManager.AppSettings["Globalization.ShortDatePattern"].Trim()
                    }
                };
            }
        }

        public static string TestDK
        {
            get { return ConfigurationManager.AppSettings["TestDK"].Trim(); }
        }

        public static string ManualApprovalCodeTDC
        {
            get { return ConfigurationManager.AppSettings["ManualApprovalCodeTDC"].Trim(); }
        }

        public static string EncryptKey
        {
            get { return ConfigurationManager.AppSettings["EncryptKey"].Trim(); }
        }

        public static string WebServiceFileValueSabre
        {
            get { return ConfigurationManager.AppSettings["WebServiceFileValueSabre"].Trim(); }
        }

        public static Dictionary<string, string[]> SabreCredentials
        {
            get
            {
                var lvalores = ConfigurationManager.AppSettings["Sabre.Credentials"].Trim();

                return lvalores.Split(';').ToDictionary(e => e.Split(':')[0].Trim(), e => e.Split(':')[1].Replace(" ", string.Empty).Split(','));
            }
        }

        #endregion
    }
}
