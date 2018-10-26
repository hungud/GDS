using System;
using System.Xml;

namespace SabreLib.Utiles
{
    // =================================
    // emnumeraciones

    #region "emnumeraciones"

    public enum WebServiceAction
    {
        SessionCreate = 0,
        SessionClose = 1,
        SabreCommand = 2,
        IgnoreTransaction = 3,
        Ping = 4,
        TravelItineraryRead = 5,
        ContextChange = 6,
        AirPrice = 7,
        DailySalesReport = 8,
        DailyEMDReport = 9,
        UnusedeTicketReport = 10,
        DailyRefundReport = 11,
        EnhancedAirBook = 12,
        TravelItineraryAddInfo = 13,
        SpecialService = 14,
        AddRemark = 15,
        TicketCoupon = 16,
        AutomatedExchange = 17,
        AirTicket = 18,
        EndTransaction = 19,
        QueueAccess = 20,
        QueueAnalysis = 21,
        QueueCount = 22,
        QueuePlace = 23,
        TravelItineraryModifyInfo = 24,
        ModifyRemark = 25,
        DesignatePrinter = 26,
        ArunkService = 27,
        EnhancedAirTicket = 28,
        GetReservation = 29
    }

    #endregion

    // =============================
    // clases

    #region "clases"

    public sealed class WebServiceFileValueSabre : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        private WebServiceFileValueSabre()
        {
        }

        public WebServiceFileValueSabre(WebServiceAction name)
        {
            var ldocumentoXml = new XmlDocument();

            // cargando archivo
            ldocumentoXml.Load((Ambiente.ExecutionPath + Configuracion.WebServiceFileValueSabre));

            var lelemList = ldocumentoXml.GetElementsByTagName("WebService");
            var lnodeList = lelemList[((int) name)].ChildNodes;

            // cargando propiedades
            Name = lnodeList[0].InnerText;
            Service = lnodeList[1].InnerText;
            Action = lnodeList[2].InnerText;
            Cid = lnodeList[3].InnerText;
            Version = lnodeList[4].InnerText;
        }

        ~WebServiceFileValueSabre()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    Name = null;
                    Service = null;
                    Action = null;
                    Cid = null;
                    Version = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =================================
        // auto propiedades

        #region "auto propiedades"

        public string Name { get; set; }
        public string Service { get; set; }
        public string Action { get; set; }
        public string Cid { get; set; }
        public string Version { get; set; }

        #endregion
    }

    #endregion
}
