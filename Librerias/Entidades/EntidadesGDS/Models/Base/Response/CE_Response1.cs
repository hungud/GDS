using System;

namespace EntidadesGDS.Base.Response
{
    public sealed class CE_Response1<TResult> : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public CE_Response1(CE_Estatus estatus,
                            TResult resultado)
        {
            Estatus = estatus;
            Resultado = resultado;
        }

        public CE_Response1(CE_Estatus estatus)
            : this(estatus, default(TResult))
        {
        }

        public CE_Response1(InternalException excepcion)
            : this((new CE_Estatus(excepcion)))
        {
        }

        public CE_Response1(Exception excepcion)
            : this((new CE_Estatus(excepcion)))
        {
        }

        public CE_Response1(bool ok)
            : this(new CE_Estatus(ok))
        {
        }

        public CE_Response1()
            : this(true)
        {
        }

        ~CE_Response1()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    Estatus = null;
                    Resultado = default(TResult);
                }
            }

            _disposing = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public CE_Estatus Estatus { set; get; }
        public TResult Resultado { set; get; }

        #endregion
    }
}
