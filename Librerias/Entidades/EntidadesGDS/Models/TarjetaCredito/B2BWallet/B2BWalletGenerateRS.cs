using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    [XmlType("Data")]
    public class DataGenerateRS
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

        #endregion
    }

    [XmlType("Message")]
    public class MessageGenerateRS : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessageGenerateRS()
        {
        }

        ~MessageGenerateRS()
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

        public DataGenerateRS Data { set; get; }
        public ErrorBase[] Errors { set; get; }

        #endregion
    }

    public class B2BWalletGenerateRS : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletGenerateRS()
        {
            Message = new MessageGenerateRS
            {
                Data = new DataGenerateRS()
            };
        }

        ~B2BWalletGenerateRS()
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
        public MessageGenerateRS Message { set; get; }

        #endregion
    }

    #endregion
}
