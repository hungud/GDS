using System;

using AmadeusLib.Base;
using AmadeusLATAM.B2BWallet.Amadeus.Enum;

namespace AmadeusLib.Utiles
{
    public sealed class WebServiceFileValueAmadeus : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        private WebServiceFileValueAmadeus()
        {
        }

        public WebServiceFileValueAmadeus(WebServiceActionHeader4 name)
        {
            var ldocumentoXml = AmadeusUtility.LoadXmlAmadeusConfig();

            var lelemList = ldocumentoXml.GetElementsByTagName("WebService");
            var lnodeList = lelemList[((int)name)].ChildNodes;
            Name = lnodeList[0].InnerText;
            Service = lnodeList[1].InnerText;
            Action = lnodeList[2].InnerText;
            Version = lnodeList[3].InnerText;
            TypePasswordEncryption = (TypePasswordEncryptionEnum)int.Parse(lnodeList[4].InnerText.Trim());
        }

        public WebServiceFileValueAmadeus Values() 
        {
            return this;
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
        public string Version { get; set; }
        public TypePasswordEncryptionEnum TypePasswordEncryption { get; set; }

        #endregion
    }
}
