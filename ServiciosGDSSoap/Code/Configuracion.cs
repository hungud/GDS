using System.Configuration;
using System.Globalization;

namespace ServiciosGDSSoap
{
    public static class Configuracion
    {
        // =================================
        // propiedades estaticas

        #region "propiedades estaticas"

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

        #endregion
    }
}
