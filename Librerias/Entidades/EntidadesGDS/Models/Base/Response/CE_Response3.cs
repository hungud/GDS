using System;

namespace EntidadesGDS.Base.Response
{
    public sealed class CE_Response3<TResult> : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public CE_Response3(CE_Estatus estatus,
                            CE_Session sesion,
                            TResult resultado)
        {
            Estatus = estatus;
            Sesion = sesion;
            Resultado = resultado;
        }

        public CE_Response3(CE_Estatus estatus)
            : this(estatus, null, default(TResult))
        {
        }

        public CE_Response3(InternalException excepcion)
            : this((new CE_Estatus(excepcion)))
        {
        }

        public CE_Response3(Exception excepcion)
            : this((new CE_Estatus(excepcion)))
        {
        }

        public CE_Response3(bool ok)
            : this(new CE_Estatus(ok))
        {
        }

        public CE_Response3()
            : this(true)
        {
        }

        ~CE_Response3()
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
                    Sesion = null;
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
        public CE_Session Sesion { set; get; }
        public TResult Resultado { set; get; }

        #endregion
    }
}
