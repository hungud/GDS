using System;
using System.Xml.Serialization;

namespace EntidadesGDS.TarjetaCredito.B2BWallet
{
    // =============================
    // clases

    #region "clases"

    [XmlType("Data")]
    public class DatatDeleteRS
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlElement("Reference")]
        public ReferenceBase[] Reference { set; get; }

        #endregion
    }

    [XmlType("Message")]
    public class MessagetDeleteRS : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public MessagetDeleteRS()
        {
        }

        ~MessagetDeleteRS()
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

        public DatatDeleteRS Data { set; get; }
        public ErrorBase[] Errors { set; get; }

        #endregion
    }

    public class B2BWalletDeleteRS : B2BWalletBase
    {
        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        public B2BWalletDeleteRS()
        {
        }

        ~B2BWalletDeleteRS()
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
        public MessagetDeleteRS Message { set; get; }

        #endregion
    }

    #endregion
}
