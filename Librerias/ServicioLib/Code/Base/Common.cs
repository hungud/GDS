using System;

using CustomLog;

namespace ServicioLib.Base
{
    public class Common : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        protected Common(string codigoSeguimiento)
        {
            CodigoSeguimiento = codigoSeguimiento;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", CodigoSeguimiento);
        }

        ~Common()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    CodigoSeguimiento = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string CodigoSeguimiento { private set; get; }

        #endregion
    }
}
