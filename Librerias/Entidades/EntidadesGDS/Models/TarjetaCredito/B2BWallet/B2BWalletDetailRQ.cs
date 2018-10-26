using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    public class Display
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlAttribute]
        public string Full { set; get; }

        #endregion
    }

    public class DataDetailRQ
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string MessageID { set; get; }

        [XmlElement("Reference")]
        public ReferenceBase[] Reference { set; get; }

        public Display Display { set; get; }

        #endregion
    }

    public class MessageDetailRQ : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessageDetailRQ()
        {
            Data = new DataDetailRQ();
        }

        ~MessageDetailRQ()
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

        public DataDetailRQ Data { set; get; }

        #endregion
    }

    public class B2BWalletDetailRQ : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletDetailRQ()
        {
            Message = new MessageDetailRQ
            {
                Data = new DataDetailRQ()
            };
        }

        ~B2BWalletDetailRQ()
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

        public MessageDetailRQ Message { set; get; }

        #endregion
    }

    #endregion
}
