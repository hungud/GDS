using System;

using EntidadesGDS;

using SabreLib.Models;
using SabreLib.Utiles;

namespace SabreLib.Base
{
    public static class SabreUtility
    {
        // =============================
        // metodos estaticos

        #region "metodos estaticos"

        public static TSecurityUsernameToken GetUsernameToken<TSecurityUsernameToken>(EnumAplicaciones application) 
            where TSecurityUsernameToken : class
        {
            // instanciando clase
            dynamic lsecurityUsernameToken = Activator.CreateInstance<TSecurityUsernameToken>();

            SabreCredential lcredentials = null;

            switch (application)
            {
                // interagencias
                case EnumAplicaciones.Interagencia:
                case EnumAplicaciones.SabreRed:
                case EnumAplicaciones.Turbo:
                    lcredentials = Configuracion.GetSabreCredentials("IA");
                    break;

                // srv
                case EnumAplicaciones.MotorEmisionesSrv:
                    lcredentials = Configuracion.GetSabreCredentials("SRV");
                    break;
            }

            // actualizando credenciales
            lsecurityUsernameToken.Domain = lcredentials.Domain;
            lsecurityUsernameToken.Organization = lcredentials.Organization;
            lsecurityUsernameToken.Username = lcredentials.Username;
            lsecurityUsernameToken.Password = lcredentials.Password;

            return ((TSecurityUsernameToken) lsecurityUsernameToken);
        }

        public static TMessageHeader GetMessageHeader<TMessageHeader, TFrom, TTo, TPartyId, TService, TMessageData>(WebServiceFileValueSabre serviceConfiguration,
                                                                                                                    string sessionConversationId,
                                                                                                                    string pseudo)
            where TMessageHeader : class
            where TFrom : class
            where TTo : class
            where TPartyId : class
            where TService : class
            where TMessageData : class
        {
            // instanciando clases
            dynamic lmessageHeader = Activator.CreateInstance<TMessageHeader>();
            dynamic lfrom = Activator.CreateInstance<TFrom>();
            dynamic lto = Activator.CreateInstance<TTo>();
            dynamic lpartyFrom = Activator.CreateInstance<TPartyId>();
            dynamic lpartyTo = Activator.CreateInstance<TPartyId>();
            dynamic lservice = Activator.CreateInstance<TService>();
            dynamic lmessageData = Activator.CreateInstance<TMessageData>();

            // momento actual
            var lmomentoActual = DateTime.UtcNow;

            // from 
            lpartyFrom.Value = "webservices.sabre.com";
            lpartyFrom.type = "sabreXML";

            // to
            lpartyTo.Value = "nmviajes.com";
            lpartyTo.type = "sabreXML";

            // service
            lservice.Value = serviceConfiguration.Service;
            lservice.type = "sabreXML";

            // messagedata
            lmessageData.MessageId = string.Format("{0:yyyyMMdd-HHmmssu}@nmviajes.com", lmomentoActual);
            lmessageData.RefToMessageId = serviceConfiguration.Cid;
            lmessageData.Timestamp = (lmomentoActual.ToString("s") + "Z");

            lfrom.PartyId = new TPartyId[] { lpartyFrom };
            lto.PartyId = new TPartyId[] { lpartyTo };

            lmessageHeader.ConversationId = sessionConversationId;
            lmessageHeader.CPAId = pseudo;
            lmessageHeader.Action = serviceConfiguration.Action;
            lmessageHeader.version = ("2003A.TsabreXML" + serviceConfiguration.Version);
            lmessageHeader.From = lfrom;
            lmessageHeader.To = lto;
            lmessageHeader.Service = lservice;
            lmessageHeader.MessageData = lmessageData;

            return ((TMessageHeader) lmessageHeader);
        }

        #endregion
    }
}
