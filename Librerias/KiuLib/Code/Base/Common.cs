using System;
using System.Collections.Generic;
using System.Linq;

using CustomLog;
using EntidadesGDS;
using EntidadesGDS.Base;



namespace KiuLib.Base
{
    public class Common<TSecurity, TMessageHeader> : IDisposable
           where TSecurity : class
          where TMessageHeader : class
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
        //private Common(EnumAplicaciones application,
        //               string codigoSeguimiento,
        //               bool muteErrors = true)
        //{
        //    _application = application;
        //    CodigoSeguimiento = codigoSeguimiento;
        //    MuteErrors = muteErrors;

        //    // registrando evento
        //    Bitacora.Current.Info("Parametros recibidos", new { _application,CodigoSeguimiento, MuteErrors }, codigoSeguimiento);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="service"></param>
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
            Bitacora.Current.Info("Parametros recibidos", new { _application, MuteErrors }, CodigoSeguimiento);
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
                    Security = default(TSecurity);
                    MessageHeader = default(TMessageHeader);
                    CodigoSeguimiento = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        protected TSecurity Security { private set; get; }
        protected TMessageHeader MessageHeader { private set; get; }
        public string CodigoSeguimiento { private set; get; }
        public bool MuteErrors { private set; get; }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        public void Prepare()
        {
            try
            {

                // instanciando clase
                dynamic lsecurity = Activator.CreateInstance<TSecurity>();

                // completando objeto de seguridad
                Security = KiuUtility.GetSecurity<TSecurity>(_application);
                MessageHeader = KiuUtility.GetMessageHeader<TMessageHeader>();

            }
            catch (Exception ex)
            {
                Dispose();

                // registrando evento
                Bitacora.Current.Error(ex, new { _application, Security, MessageHeader }, CodigoSeguimiento);

                throw;
            }
        }
       

        #endregion
    }
}
