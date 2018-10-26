using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    //[XmlType("Period")]
    public class PeriodListRQ
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Start { set; get; }

        [XmlAttribute]
        public string End { set; get; }

        #endregion
    }

    //[XmlType("AmountRange")]
    public class AmountRangeListRQ
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Min { set; get; }

        [XmlAttribute]
        public string Max { set; get; }

        #endregion
    }

    [XmlType("Data")]
    public class DataListRQ
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string MessageID { set; get; }
        public string Type { set; get; }
        public string VendorCode { set; get; }
        public PeriodListRQ Period { set; get; }
        public AmountRangeListRQ AmountRange { set; get; }
        public string CurrencyCode { set; get; }
        public string CardStatus { set; get; }

        #endregion
    }

    [XmlType("Message")]
    public class MessageListRQ : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessageListRQ()
        {
            Data = new DataListRQ();
        }

        ~MessageListRQ()
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

        public DataListRQ Data { set; get; }

        #endregion
    }

    public class B2BWalletListRQ : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletListRQ()
        {
            Message = new MessageListRQ
            {
                Data = new DataListRQ()
            };
        }

        ~B2BWalletListRQ()
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

        public MessageListRQ Message { set; get; }

        #endregion
    }

    #endregion
}
