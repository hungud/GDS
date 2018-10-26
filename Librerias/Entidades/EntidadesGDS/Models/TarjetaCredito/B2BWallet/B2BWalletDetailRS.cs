using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    [XmlType("Transaction")]
    public class TransactionDetailRS
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Reference { set; get; }

        [XmlAttribute]
        public string Type { set; get; }

        [XmlAttribute]
        public string Timestamp { set; get; }

        public ValueBase[] Values { set; get; }
        public DetailBase[] Details { set; get; }

        #endregion
    }

    [XmlType("Data")]
    public class DatatDetailRS
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlElement("Reference")]
        public ReferenceBase[] Reference { set; get; }

        public string PrimaryAccountNumber { set; get; }
        public string CVV { set; get; }
        public string Validity { set; get; }
        public string VendorCode { set; get; }
        public ValidityPeriodBase ValidityPeriod { set; get; }
        public string CardStatus { set; get; }
        public ValueBase[] Values { set; get; }
        public TransactionDetailRS[] Transactions { set; get; }

        #endregion
    }

    [XmlType("Message")]
    public class MessagetDetailRS : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessagetDetailRS()
        {
        }

        ~MessagetDetailRS()
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
                    Errors = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public DatatDetailRS Data { set; get; }
        public ErrorBase[] Errors { set; get; }

        #endregion
    }

    public class B2BWalletDetailRS : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletDetailRS()
        {
        }

        ~B2BWalletDetailRS()
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

                    Success = null;

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

        public string Success { set; get; }
        public MessagetDetailRS Message { set; get; }

        #endregion
    }

    #endregion
}
