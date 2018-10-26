using System;

namespace EntidadesGDS.Base.Request
{
    public sealed class CE_Request2<TParameters> : CE_RequestBase
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        ~CE_Request2()
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
                    Parametros = default(TParameters);

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
        public TParameters Parametros { set; get; }

        #endregion
    }
}
