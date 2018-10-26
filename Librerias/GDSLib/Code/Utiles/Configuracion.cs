using System.Configuration;

using GDSLib.Models;

namespace GDSLib.Utiles
{
    internal class Configuracion
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

        public static byte RetriesOfExecution
        {
            get { return byte.Parse(_configFile.AppSettings.Settings["RetriesOfExecution"].Value); }
        }

        public static string B2BWalletEvaluationMark
        {
            get { return _configFile.AppSettings.Settings["B2BWalletEvaluationMark"].Value; }
        }

        public static int B2BWalletMaximumPassengers
        {
            get { return int.Parse(_configFile.AppSettings.Settings["B2BWalletMaximumPassengers"].Value); }
        }

        public static byte B2BWalletServiceDecimalPlaces
        {
            get { return byte.Parse(_configFile.AppSettings.Settings["B2BWalletServiceDecimalPlaces"].Value); }
        }

        public static string RutaBaseLogApps 
        {
            get { return _configFile.AppSettings.Settings["RutaBaseLogApps"].Value; }
        }

        public static bool AppEnMantenimiento 
        {
            get 
            {
                var lvalue = _configFile.AppSettings.Settings["AppEnMantenimiento"].Value;
                return lvalue.Equals("1");
            }
        }

        public static string SitCredentials { 
            get 
            {
                var lenabledSIT = _configFile.AppSettings.Settings["SitEnabled"].Value.Equals("1");
                if (lenabledSIT)
                {
                    return _configFile.AppSettings.Settings["SitCredentials"].Value;
                }
                return string.Empty;
            } 
        }
       
        #endregion

        // =================================
        // metodos estaticos

        #region "metodos estaticos"

        public static string[] GetMessageApp(string acronym)
        {
            return _configFile.AppSettings.Settings[(acronym + ".MensajeMantenimiento")].Value.Split('/');
        }

        public static string GetSchema(string acronyms)
        {
            var lacronyms = acronyms.Split('/');

            return _configFile.AppSettings.Settings[(lacronyms[1] + ".Database.Schema")].Value;
        }

        private static DatabaseCredential GetDatabaseCredentials(string acronym)
        {
            return new DatabaseCredential
            {
                Username = _configFile.AppSettings.Settings[(acronym + ".Database.Credentials.Username")].Value,
                Password = _configFile.AppSettings.Settings[(acronym + ".Database.Credentials.Password")].Value
            };
        }

        public static string GetConnectionString(string acronyms)
        {
            var lacronyms = acronyms.Split('/');

            // obteniendo la candena de conexión, el esquema y las credenciales de base de datos
            var lconnectionString = _configFile.ConnectionStrings.ConnectionStrings[(lacronyms[0] + ".Database.Connection")].ConnectionString;
            var lcredentials = GetDatabaseCredentials(lacronyms[2]);

            // retornando cadena de conexión a base de datos
            return string.Format(lconnectionString, lcredentials.Username, lcredentials.Password);
        }

        public static string GetRegularExpression(string name)
        {
            return _configFile.AppSettings.Settings[("RegularExpression." + name)].Value;
        }

        #endregion
    }
}
