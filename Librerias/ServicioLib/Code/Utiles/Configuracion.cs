using System.Configuration;
using System.Linq;

using CoreLib.Converter;

using ServicioLib.Models;

namespace ServicioLib.Utiles
{
    internal class Configuracion
    {
        // =================================
        // variables estaticas

        #region "variables estaticas"

        private static readonly Configuration _configFile;

        #endregion

        static Configuracion()
        {
            // abriendo archivo de configuración propio
            _configFile =
                ConfigurationManager.OpenMappedExeConfiguration(
                    new ExeConfigurationFileMap { ExeConfigFilename = Ambiente.ConfigFilePath },
                    ConfigurationUserLevel.None
                );
        }

        // =================================
        // metodos estaticos

        #region "metodos estaticos"

        public static ShortMessageCredential GetShortMessageCredentials(string acronym)
        {
            return new ShortMessageCredential
            {
                Server = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "ShortMessage.Credentials.Server")].Value,
                User = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "ShortMessage.Credentials.User")].Value,
                Password = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "ShortMessage.Credentials.Password")].Value
            };
        }

        public static EmailMessageCredential GetEmailMessageCredentials(string acronym)
        {
            var lemailMessageCredential = new EmailMessageCredential
            {
                Server = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "EmailMessage.Credentials.Server")].Value,
                User = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "EmailMessage.Credentials.User")].Value,
                Password = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "EmailMessage.Credentials.Password")].Value
            };

            var lport = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "EmailMessage.Port")].Value;
            var lbcc = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "EmailMessage.BCC")].Value;
            var lfrom = _configFile.AppSettings.Settings[((string.IsNullOrWhiteSpace(acronym) ? string.Empty : (acronym + ".")) + "EmailMessage.From")].Value;

            lemailMessageCredential.Port = Extension.ConvertOrDefault<int?>(lport);
            lemailMessageCredential.BCC = lbcc.Split(';').Where(e => (!string.IsNullOrWhiteSpace(e))).Select(e => e.Trim()).ToArray();
            lemailMessageCredential.From = lfrom;

            return lemailMessageCredential;
        }

        #endregion
    }
}
