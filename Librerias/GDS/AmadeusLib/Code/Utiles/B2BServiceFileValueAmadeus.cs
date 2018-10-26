using System;
using System.Xml;

using CoreWebLib;

namespace AmadeusLib.Utiles
{
    // =================================
    // emnumeraciones

    #region "emnumeraciones"

    public enum WebServiceAction
    {
        B2BWalletGenerate = 0,
        B2BWalletDetail = 1,
        B2BWalletUpdate = 2,
        B2BWalletDelete = 3,
        B2BWalletList = 4
    }

    #endregion

    // =============================
    // clases

    #region "clases"

    public sealed class B2BServiceFileValueAmadeus<T> : IDisposable
        where T : class
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

        #endregion

        // =================================
        // constructores y destructores

        #region "constructores y destructores"

        private B2BServiceFileValueAmadeus()
        {
        }

        public B2BServiceFileValueAmadeus(WebServiceAction name)
        {
            var ldocumentoXml = new XmlDocument();

            // cargando archivo
            ldocumentoXml.Load((Ambiente.ExecutionPath + Configuracion.B2BServiceFileValueAmadeus));
            
            // seleccionado nodo raiz
            var lraiz = ldocumentoXml.SelectSingleNode("//WebService[@Id=" + ((int) name) + "]");

            Request = XmlHelper.XmlDeserialize<T>(lraiz.InnerXml, true, false, (typeof(T).Name));
        }

        ~B2BServiceFileValueAmadeus()
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
                    Request = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =================================
        // auto propiedades

        #region "auto propiedades"

        public T Request { get; set; }

        #endregion
    }

    #endregion
}
