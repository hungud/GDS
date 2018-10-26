using System;

using EntidadesGDS;
using KiuLib.Models;
using KiuLib.Utiles;


namespace KiuLib.Base
{
    public static class KiuUtility
    {
        // =============================
        // metodos estaticos

        #region "metodos estaticos"
        public static TSecurityUsernameToken GetSecurity<TSecurityUsernameToken>(EnumAplicaciones application)
            where TSecurityUsernameToken : class
        {
            // instanciando clase
            dynamic lsecurityUsernameToken = Activator.CreateInstance<TSecurityUsernameToken>();

            KiuCredential lcredentials = null;
            switch (application)
            {
                // interagencias
                case EnumAplicaciones.Interagencia:
                    lcredentials = Configuracion.GetKiuCredentials("IA");

                    break;
                // srv
                case EnumAplicaciones.MotorEmisionesSrv:
                    lcredentials = Configuracion.GetKiuCredentials("SRV");
                    break;
            }

            // actualizando credenciales
            lsecurityUsernameToken.PseudoCity = lcredentials.PseudoCity;
            lsecurityUsernameToken.Country = lcredentials.Country;
            lsecurityUsernameToken.Currency = lcredentials.Currency;
            lsecurityUsernameToken.Agent = lcredentials.Agent;
            lsecurityUsernameToken.Terminal = lcredentials.Terminal;


            return ((TSecurityUsernameToken)lsecurityUsernameToken);
        }

        public static TMessageHeader GetMessageHeader<TMessageHeader>()
        {

            // momento actual
            var lmomentoActual = DateTime.Parse(string.Format("{0:yyyy-MM-ddThh:mm:ss}", DateTime.Now));

            // instanciando clases
            dynamic lmessageHeader = Activator.CreateInstance<TMessageHeader>();

             KiuHeader lheader = null;
            
            
            lheader = Configuracion.GetKiuHeader();
            
            lmessageHeader.EchoToken = lheader.EchoToken;
            lmessageHeader.TimeStamp = lmomentoActual;
            lmessageHeader.Target = lheader.Target;
            lmessageHeader.Version = lheader.Version;
            lmessageHeader.PrimaryLangID = lheader.PrimaryLangID;

            return ((TMessageHeader)lmessageHeader);
        }

        #endregion

    }
}
