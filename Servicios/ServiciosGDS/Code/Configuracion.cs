using System.Configuration;
using System.Globalization;
//using System.Collections.Generic;

namespace ServiciosGDS
{
    public static class Configuracion
    {
        // =================================
        // propiedades estaticas

        #region "propiedades estaticas"

        public static bool ProductionMode
        {
            get
            {
                var lvalor = ConfigurationManager.AppSettings["ProductionMode"];

                return ((!string.IsNullOrWhiteSpace(lvalor)) && bool.Parse(lvalor));
            }
        }

        public static string RSAPrivateKey
        {
            get { return ConfigurationManager.AppSettings["RSAPrivateKey"]; }
        }

        /*
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
        */

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

        public static string VoidTestForDKeDestinos
        {
            get { return ConfigurationManager.AppSettings["eDestinos.VoidTestForDK"]; }
        }

        public static bool UseImpertsonateeDestinos
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["eDestinos.UseImpersonate"]); }
        }

        public static string EchoDirectoryeDestinos
        {
            get { return ConfigurationManager.AppSettings["eDestinos.EchoDirectory"]; }
        }

        public static string VoidDirectoryeDestinos
        {
            get { return ConfigurationManager.AppSettings["eDestinos.VoidDirectory"]; }
        }

        #endregion
    }
}
