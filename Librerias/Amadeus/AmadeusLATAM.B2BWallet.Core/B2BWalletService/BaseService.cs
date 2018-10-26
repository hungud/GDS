// <copyright file="BaseService.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Core.B2BWalletService
{
    using AmadeusLATAM.B2BWallet.Amadeus;
    using AmadeusLATAM.B2BWallet.Amadeus.Enum;
    using AmadeusLATAM.B2BWallet.Amadeus.Model;
    using AmadeusLATAM.B2BWallet.Common.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Clase base que se declara abstracta, para aplicar el patron Abstract Factory, de esta manera esta clase se comporta con lo factoria que centraliza no solo peticiones comunes, 
    /// sino que tambien permite generar un orden en la codificación y generación de clases concretas que se vinculan a esta factoria.
    /// </summary>
    public abstract class BaseService
    {
        #region "Protected Properties"

        /// <summary>
        /// Propiedad que permite manejar la estructura request a ser enviada a Amadeus WS.
        /// </summary>
        protected string xml1ARequest { get; set; }

        #endregion "Protected Properties"

        #region "Public Methods"

        /// <summary>
        /// Metodo abstracto que permite exponer el Execute y que recibe por referencia la entidad SessionWSModel, que viene con datos y se completaran de aqui en adelante.
        /// </summary>
        /// <param name="sessionWS">Entidad que tiene todos los datos para estructurar el envoltorio, el header y el body del XML a ser enviado a Amadeus.</param>
        public abstract void Execute(ref SessionWSModel sessionWS);

        /// <summary>
        /// Constructor, el cual posee como entrada la entidad SessionWSModel, la cual posee todos los datos necesarios para generar una petición de WS.
        /// </summary>
        /// <param name="sessionWS">Entidad que tiene todos los datos para estructurar el envoltorio, el header y el body del XML a ser enviado a Amadeus.</param>
        public BaseService(SessionWSModel sessionWS)
        {
            // Se hace la transformacion de la entrada Request a 1AWS
            sessionWS.XmlRequest = XDocument.Parse(XMLUtility.XsltTransform(GeneralUtility.LoadFileXSLT(sessionWS.XSLTemplate), sessionWS.XmlRequestInitial.ToString(), sessionWS.XsltParameter));

            // Obtener credenciales del Amadeus Web Services            
            sessionWS.EndPoint = GeneralUtility.GetEndPoint();
            sessionWS.WSAP = GeneralUtility.GetAppSetting("WSAP");

            // Se valida tipo de sesion
            switch (sessionWS.TransactionStatusCode)
            {
                case TransactionStatusCodeEnum.Start:
                case TransactionStatusCodeEnum.Stateless:
                    sessionWS.UserID = GeneralUtility.GetAppSetting("UserId");
                    sessionWS.OfficeID = GeneralUtility.GetAppSetting("OfficeId");
                    sessionWS.BinaryData = GeneralUtility.GetAppSetting("BinaryData");
                    xml1ARequest = SOAPHeader4_0.GenerateVerbRequestLogin(sessionWS);
                    break;
                case TransactionStatusCodeEnum.InSeries:
                case TransactionStatusCodeEnum.End:
                    xml1ARequest = SOAPHeader4_0.GenerateVerbRequestInProcess(sessionWS);
                    break;
            }

            sessionWS.XmlRequest = XDocument.Parse(xml1ARequest);
        }

        #endregion "Public Methods"

        #region "Protected Methods"
        /// <summary>
        /// Permite comunicarse con la capa AmadeusLATAM.B2BWallet.Amadeus para que sea enviada la petición del servicio web.
        /// </summary>
        /// <param name="sessionWS">Entidad que contiene los datos a ser manejados para realizar la petición.</param>
        protected void Connect1AService(ref SessionWSModel sessionWS)
        {
            // Guardar logs de trasacciones para la petición Requets.
            if (sessionWS.SaveTransactionLog)
            {
                GeneralUtility.SaveLog(sessionWS.AmadeusService + "_RQ", sessionWS.SessionId, sessionWS.XmlRequest.ToString());
            }

            SOAPHeader4_0.ExecuteSOAPRequest(ref sessionWS);

            // Guardar logs de trasacciones para la petición Response.
            if (sessionWS.SaveTransactionLog)
            {
                GeneralUtility.SaveLog(sessionWS.AmadeusService + "_RS", sessionWS.SessionId, GenerateSessionXML(sessionWS));
            }

            sessionWS.XmlResponse = XMLUtility.GetBody(sessionWS.XmlResponse);
        }

        /// <summary>
        /// Permite realizar el cifrado de datos de la tarjeta virtual.
        /// </summary>
        /// <param name="sessionWS">Datos requeridos para hacer hacer el cifrado de los datos de la tarjeta virtual.</param>
        /// <returns>El XML resultando con los datos cifrados si es que asi se solicito.</returns>
        protected XDocument EncryptData(SessionWSModel sessionWS)
        {
            XDocument xmlResponse = sessionWS.XmlResponse;

            string messageId = ConversionUtility.ConvertXElementToValue(sessionWS.XmlRequestInitial.Descendants("MessageID").FirstOrDefault());

            if (!string.IsNullOrEmpty(messageId))
            {
                try
                {
                    Amadeus.Utility.SecurityUtility securityUtility = new Amadeus.Utility.SecurityUtility();

                    foreach (XElement el in xmlResponse.Descendants("Card").Elements())
                    {
                        if (el.Name.ToString().Equals("PrimaryAccountNumber") || el.Name.ToString().Equals("CVV"))
                        {
                            el.Value = securityUtility.EncryptString(ConversionUtility.ConvertXElementToValue(el), messageId);
                        }
                        else if (el.Name.ToString().Equals("Validity"))
                        {
                            el.Attribute("EndDate").Value = securityUtility.EncryptString(ConversionUtility.ConvertXAttributeToValue(el.Attributes("EndDate").FirstOrDefault()), messageId);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new ExceptionUtility(ExceptionUtility.ErrorCodes[3]);
                }
            }

            return xmlResponse;
        }

        /// <summary>
        /// Permite validar los posibles errores que se dan en alguno de los servicios implementados.
        /// </summary>
        /// <param name="xdoc">XML que debe ser </param>
        /// <returns>Lista con mensajes de error encontrados en la mensajeria XML de Respuesta del servicio.</returns>
        protected List<string> ValidateErrors(XDocument xdoc)
        {
            List<string> listErrors = new List<string>();

            foreach (XElement itemError in xdoc.Descendants("Failure").Descendants("Error"))
            {
                string errorShortText = ConversionUtility.GetXAttributeFromXElement(itemError, "Code") + " - " + ConversionUtility.GetXAttributeFromXElement(itemError, "ShortText");

                if (!string.IsNullOrEmpty(errorShortText))
                {
                    listErrors.Add(errorShortText);
                }
            }

            return listErrors;
        }

        #endregion "Protected Methods"

        #region "Private Methods"

        /// <summary>
        /// Permite generar un mensaje de los recursos que seran alamacenados como logs de transacciones de la respuesta del servicio ejecutado.
        /// </summary>
        /// <param name="sessionWS">Entidad que posee datos necesarios para generar el xml de salidad.</param>
        /// <returns>Genera un XML de respuesta con los datos más relevantes para los logs de respuesta de los servicios de Amadeus WS.</returns>
        private static string GenerateSessionXML(SessionWSModel sessionWS)
        {
            return new XElement(sessionWS.AmadeusService,
                new XElement("Success", sessionWS.Successful),
                new XElement("SecurityToken", !string.IsNullOrEmpty(sessionWS.SecurityToken) ? sessionWS.SecurityToken : ""),
                new XElement("SessionId", !string.IsNullOrEmpty(sessionWS.SessionId) ? sessionWS.SessionId : ""),
                new XElement("LocalTime", DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fff")),
                new XElement("ZuluTime", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")),
                new XElement("Error", !sessionWS.Successful ? sessionWS.XmlResponse.ToString() : "")
            ).ToString();
        }

        #endregion "Private Methods"
    }
}
