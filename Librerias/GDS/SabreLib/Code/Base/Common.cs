using System;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Utiles;

namespace SabreLib.Base
{
    public class Common<TSecurity, TMessageHeader, TSecurityUsernameToken, TFrom, TTo, TPartyId, TService, TMessageData> : IDisposable
        where TSecurity : class
        where TMessageHeader : class
        where TSecurityUsernameToken : class
        where TFrom : class
        where TTo : class
        where TPartyId : class
        where TService : class
        where TMessageData : class
    {
        // =============================
        // variables

        #region "variables"

        private readonly WebServiceAction _service;
        private readonly EnumAplicaciones _application;

        private string _sessionConversationId;
        private string _sessionToken;
        private string _pseudo;
        private string _signatureUser;

        private bool _disposing;

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="application"></param>
        /// <param name="sessionConversationId"></param>
        /// <param name="sessionToken"></param>
        /// <param name="pseudo"></param>
        /// <param name="signatureUser"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        private Common(WebServiceAction service,
                       EnumAplicaciones application,
                       string sessionConversationId,
                       string sessionToken,
                       string pseudo,
                       string signatureUser,
                       string codigoSeguimiento,
                       bool muteErrors = true)
        {
            _service = service;
            _application = application;
            _sessionConversationId = sessionConversationId;
            _sessionToken = sessionToken;
            _pseudo = pseudo;
            _signatureUser = signatureUser;
            CodigoSeguimiento = codigoSeguimiento;
            MuteErrors = muteErrors;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { MuteErrors, _service, _application, _sessionConversationId, _sessionToken, _pseudo, _signatureUser }, CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        /// <param name="application"></param>
        /// <param name="session"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        protected Common(WebServiceAction service,
                         EnumAplicaciones application,  
                         CE_Session session,
                         string codigoSeguimiento,
                         bool muteErrors = true)
            : this(service, application, session.ConversationId, session.Token, session.Pseudo, session.SignatureUser, codigoSeguimiento, muteErrors)
        {
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
                    WebServiceFileValueSabre = null;
                    Security = default(TSecurity);
                    MessageHeader = default(TMessageHeader);
                    _sessionConversationId = null;
                    _sessionToken = null;
                    _pseudo = null;
                    _signatureUser = null;
                    CodigoSeguimiento = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        protected WebServiceFileValueSabre WebServiceFileValueSabre { private set; get; }
        protected TSecurity Security { private set; get; }
        protected TMessageHeader MessageHeader { private set; get; }
        public string CodigoSeguimiento { private set; get; }
        public bool MuteErrors { private set; get; }
        public CE_Session Sesion {
            get
            {
                return new CE_Session
                {
                    ConversationId = _sessionConversationId,
                    Token = _sessionToken,
                    Pseudo = _pseudo,
                    SignatureUser = _signatureUser
                };
            }
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Prepare()
        {
            try
            {
                // cargando archivo de configuracion de servicios
                WebServiceFileValueSabre = new WebServiceFileValueSabre(_service);

                // instanciando clase
                dynamic lsecurity = Activator.CreateInstance<TSecurity>();

                // completando objeto de seguridad
                lsecurity.UsernameToken = SabreUtility.GetUsernameToken<TSecurityUsernameToken>(_application);
                lsecurity.BinarySecurityToken = _sessionToken;

                // actualizando objeto de seguridad
                Security = lsecurity;

                // construyendo objeto message header
                MessageHeader = SabreUtility.GetMessageHeader<TMessageHeader, TFrom, TTo, TPartyId, TService, TMessageData>(WebServiceFileValueSabre, _sessionConversationId, _pseudo);

            }
            catch (Exception ex)
            {
                Dispose();

                // registrando evento
                Bitacora.Current.Error(ex, new { _service, _application, _sessionConversationId, _sessionToken, _pseudo, _signatureUser, WebServiceFileValueSabre, Security, MessageHeader }, CodigoSeguimiento);

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected string ProcessPaymentForm(string value)
        {
            // creando mapa
            var lmap = new Dictionary<string, string>
            {
                { "VI", "VISA" },
                { "BA", "VISA" },
                { "IK", "MASTERCARD" },
                { "DC", "DINERS" },
                { "AX", "AMERICAN EXPRESS" },
                { "CA", "CASH" },
                { "EX", "REEMISION" }
            };

            // buscando en mapa
            return (lmap.Any(k => k.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                ? lmap.First(k => k.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase)).Value
                : value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        protected EnumTipoDocumento ProcessPassengerDocumentType(string texto)
        {
            if (Advanced.In(texto, "CE", "NICE"))
            {
                return EnumTipoDocumento.CarnetExtranjeria;
            }

            if (texto.Contains("PP") || texto.StartsWith("P", StringComparison.InvariantCultureIgnoreCase))
            {
                return EnumTipoDocumento.Pasaporte;
            }

            return EnumTipoDocumento.DNI;
        }

        #endregion
    }
}
