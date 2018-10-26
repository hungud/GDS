using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    public class DataDeleteRQ
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlElement("Reference")]
        public ReferenceBase[] Reference { set; get; }

        public string Comment { set; get; }

        #endregion
    }

    public class MessageDeleteRQ : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessageDeleteRQ()
        {
            Data = new DataDeleteRQ();
        }

        ~MessageDeleteRQ()
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

        public DataDeleteRQ Data { set; get; }

        #endregion
    }

    public class B2BWalletDeleteRQ : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletDeleteRQ()
        {
            Message = new MessageDeleteRQ
            {
                Data = new DataDeleteRQ()
            };
        }

        ~B2BWalletDeleteRQ()
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

        public MessageDeleteRQ Message { set; get; }

        #endregion
    }

    #endregion
}
