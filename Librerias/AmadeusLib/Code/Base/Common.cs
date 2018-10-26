using System;

using CustomLog;

using EntidadesGDS;

namespace AmadeusLib.Base
{
    public class Common : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private readonly EnumAplicaciones _application;

        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        protected Common(EnumAplicaciones application,
                         string codigoSeguimiento,
                         bool muteErrors = true)
        {
            _application = application;
            CodigoSeguimiento = codigoSeguimiento;
            MuteErrors = muteErrors;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { _application, MuteErrors }, CodigoSeguimiento);
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
        public bool MuteErrors { private set; get; }

        #endregion
    }
}
