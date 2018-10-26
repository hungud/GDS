using System;

namespace EntidadesGDS.Base.Request
{
    public sealed class CE_Request4 : CE_RequestBase
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        ~CE_Request4()
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
                    CodigosEntorno = null;
                    Sesion = null;

                    base.Dispose(true);
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string CodigosEntorno { set; get; }
        public CE_Session Sesion { set; get; }

        #endregion
    }
}
