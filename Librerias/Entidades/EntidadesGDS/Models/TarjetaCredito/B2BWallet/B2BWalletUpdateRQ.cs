using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    public class DataUpdateRQ
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string MessageID { set; get; }

        [XmlElement("Reference")]
        public ReferenceBase[] Reference { set; get; }

        public string Comment { set; get; }

        #endregion
    }

    public class MessageUpdateRQ : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessageUpdateRQ()
        {
            Data = new DataUpdateRQ();
        }

        ~MessageUpdateRQ()
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

        public DataUpdateRQ Data { set; get; }

        #endregion
    }

    public class B2BWalletUpdateRQ : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletUpdateRQ()
        {
            Message = new MessageUpdateRQ
            {
                Data = new DataUpdateRQ()
            };
        }

        ~B2BWalletUpdateRQ()
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

        public MessageUpdateRQ Message { set; get; }

        #endregion
    }

    #endregion
}
