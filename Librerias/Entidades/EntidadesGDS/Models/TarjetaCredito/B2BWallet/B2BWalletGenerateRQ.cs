using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    [XmlType("Data")]
    public class DataGenerateRQ : B2BWalletDataRQBase
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string MessageID { set; get; }
        public string VendorCode { set; get; }

        [XmlElement("Amount")] // #1 - respetar este orden de lo contrario se vera afectada la des/serializacion (client -> rest api)
        public string StringAmount
        {
            set { Amount = (string.IsNullOrWhiteSpace(value) ? ((decimal?) null) : decimal.Parse(value)); }
            get { return ((Amount.HasValue && DecimalPlaces.HasValue) ? ToStringWithoutDecimalSymbol(Amount, DecimalPlaces.Value) : null); }
        }

        [XmlIgnore] // #2 - respetar este orden de lo contrario se vera afectada la des/serializacion (client -> rest api)
        public decimal? Amount { set; get; }

        [XmlElement("DecimalPlaces")] // #3 - respetar este orden de lo contrario se vera afectada la des/serializacion (client -> rest api)
        public string StringDecimalPlaces
        {
            set { DecimalPlaces = (string.IsNullOrWhiteSpace(value) ? ((byte?) null) : byte.Parse(value)); }
            get { return string.Format("{0}", DecimalPlaces); }
        }

        [XmlIgnore] // #4 - respetar este orden de lo contrario se vera afectada la des/serializacion (client -> rest api)
        public byte? DecimalPlaces { set; get; }

        public string CurrencyCode { set; get; }
        public string MaximumTransaction { set; get; }
        public string EndDate { set; get; }

        #endregion
    }

    [XmlType("Message")]
    public class MessageGenerateRQ : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessageGenerateRQ()
        {
            Data = new DataGenerateRQ();
        }

        ~MessageGenerateRQ()
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
                    Data = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public DataGenerateRQ Data { set; get; }

        #endregion
    }

    public class B2BWalletGenerateRQ : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletGenerateRQ()
        {
            Message = new MessageGenerateRQ
            {
                Data = new DataGenerateRQ()
            };
        }

        ~B2BWalletGenerateRQ()
        {
            Dispose(false);
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public new void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    base.Dispose(true);

                    if (Message != null)
                    {
                        Message.Dispose();
                        Message = null;
                    }
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public MessageGenerateRQ Message { set; get; }

        #endregion
    }

    #endregion
}
