using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

using EntidadesGDS;

using AmadeusLATAM.B2BWallet.Amadeus.Model;

using AmadeusLib.Models;
using AmadeusLib.Utiles;

namespace AmadeusLib.Base
{
    // =================================
    // emnumeraciones

    #region "emnumeraciones"

    public enum WebServiceActionHeader4
    {
        AirSellFromRecommendation = 0,
        CommandCryptic = 1,
        DocIssuanceIssueTicket = 2,
        FarePricePNRWithBookingClass = 3,
        FareMasterPricerTravelBoardSearch = 4,
        PNRAddMultiElements = 5,
        PNRCancel = 6,
        PnrRetrieve = 7,
        SalesReportsDisplayQueryReport = 8,
        TicketCancelDocument = 9,
        TicketCheckEligibility = 10,
        TicketCreateTSTFromPricing = 11,
        TicketProcessETicket = 12,
        TicketReissueConfirmedPricing = 13,
        TicketRepricePNRWithBookingClass = 14,
        FareInstantTravelBoardSearch = 15,
        TicketDisplayTST = 16
    }

    public enum TransactionType
    {
        Stateless,
        Start,
        InSeries,
        End
    }

    #endregion

    public static class AmadeusUtility
    {
        // =============================
        // metodos estaticos

        #region "metodos estaticos"

        internal static AmadeusCredential GetCredentials(EnumAplicaciones application, EnumEnvironment environment)
        {
            AmadeusCredential lcredentials = null;

            switch (application)
            {
                // interagencias
                case EnumAplicaciones.Interagencia:
                case EnumAplicaciones.SabreRed:
                case EnumAplicaciones.Turbo:
                case EnumAplicaciones.RobotAnulaciones:
                case EnumAplicaciones.Pta:
                    lcredentials = Configuracion.GetAmadeusCredentials("IA", environment);
                    break;

                // srv
                case EnumAplicaciones.MotorEmisionesSrv:
                    lcredentials = Configuracion.GetAmadeusCredentials("SRV", environment);
                    break;
            }

            return lcredentials;
        }

        internal static string GetIataByOfficeID(string officeID)
        {
            return Configuracion.GetIataByOfficeID(officeID);
        }

        internal static string GetServiceName(WebServiceActionHeader4 webServiceActionHeader)
        {
            return new WebServiceFileValueAmadeus(webServiceActionHeader).Action;
        }

        internal static WebServiceFileValueAmadeus GetServiceInformation(WebServiceActionHeader4 webServiceActionHeader)
        {
            return new WebServiceFileValueAmadeus(webServiceActionHeader).Values();
        }

        private static string GetServiceName(string action)
        {
            var ldocumentXML = LoadXmlAmadeusConfig();
            var xpath = "//WebService[Action=\"" + action + "\"]";
            var lnodo = ldocumentXML.SelectSingleNode(xpath);

            return lnodo.FirstChild.InnerText;
        }

        internal static XmlDocument LoadXmlAmadeusConfig()
        {
            var ldocumentoXml = new XmlDocument();
            var lpathXmlVersiones = Configuracion.WebServiceFileValueAmadeus;
            ldocumentoXml.Load(lpathXmlVersiones);

            return ldocumentoXml;
        }

        internal static void SaveLog(SessionWSModel session, 
                                     string target, 
                                     string type)
        {
            if (Configuracion.EnableLogHeader4)
            {
                if (!string.IsNullOrEmpty(target))
                {
                    var lpathFolderLog = string.Format(@"{0}\{1}", Configuracion.PathLogServiceHeader4, session.SessionId);

                    if (!File.Exists(lpathFolderLog))
                    {
                        Directory.CreateDirectory(lpathFolderLog);
                    }

                    var lpath = string.Format(@"{0}\{1}_{2}_{3}.xml",
                            lpathFolderLog,
                            session.SequenceNumber,
                            GetServiceName(session.AmadeusService),
                            type);

                    File.WriteAllText(lpath, target, Encoding.UTF8);
                }
            }
        }

        internal static XDocument ToDocument<TRequest>(TRequest request)
            where TRequest : class
        {
            string ldocumentoText;

            using (var lxmlStream = new MemoryStream())
            {
                var lxmlSerializer = new XmlSerializer(request.GetType());
                lxmlSerializer.Serialize(lxmlStream, request);

                lxmlStream.Position = 0;

                var lxmlDoc = new XmlDocument();
                lxmlDoc.Load(lxmlStream);

                ldocumentoText = lxmlDoc.InnerXml;
            }

            return XDocument.Parse(ldocumentoText);
        }

        #endregion
    }
}
