// <copyright file="B2BWalletGenerate.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Core.B2BWalletVerb
{
    using Amadeus.Enum;
    using Amadeus.Model;
    using AmadeusLATAM.B2BWallet.Common.Interface;
    using B2BWalletService;
    using Common.Enum;
    using Common.Model;
    using Common.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Clase que permite realizar los llamados a los servicios necesarios para generación de tarjetas de crédito.
    /// </summary>
    public class B2BWalletGenerate : IVerb
    {
        #region "Private Properties"

        /// <summary>
        /// Permite obtener a traves de esta entidad, todos las caracteristicas de un servicio a ser utilizado.
        /// </summary>
        private SoapActionModel soapAction = null;

        /// <summary>
        /// Permite almacenar los datos que son requeridos para enviar a la ejecución de la petición.
        /// </summary>
        private SessionWSModel amadeusSession = null;

        /// <summary>
        /// Instancia de la clase base o factoria, la cual permitira posteriormente el envio de la petición a la clase concreta especifica.
        /// </summary>
        private BaseService amadeusService;

        #endregion "Private Properties"

        #region "Public Methods"

        /// <summary>
        /// Metodo que centraliza la ejecución de peticiones que permiten generar una tarjeta de crédito.
        /// </summary>
        /// <returns>Entidad que presenta los datos de respuesta de la petición WS.</returns>
        public EnvelopeRSModel Execute(EnvelopeRQModel request)
        {
            EnvelopeRSModel envelopeRSModel = new EnvelopeRSModel();
  
            amadeusSession = new SessionWSModel();
            soapAction = GeneralUtility.GetValuesAnnotation<SoapActionModel>(AmadeusServiceEnum.PAY_GenerateVirtualCard_2_0);            
            amadeusSession.AmadeusService = soapAction.ActionRQ;
            amadeusSession.XSLTemplate = soapAction.XSLTemplateRQ;           
            amadeusSession.TransactionStatusCode = TransactionStatusCodeEnum.Stateless;                    
            amadeusSession.GetSessionData = true;
            amadeusSession.SaveTransactionLog = true;

            XDocument xDocMessage = request.Message;
            List<string> lstValidator = ValidateRequest(ref xDocMessage);
            
            if (lstValidator == null || lstValidator.Count() == 0)
            {
                // Ejecuta la consulta al verbo
                amadeusSession.XmlRequestInitial = xDocMessage;
                amadeusService = new PAY_GenerateVirtualCardService(amadeusSession);
                amadeusService.Execute(ref amadeusSession);

                envelopeRSModel.Success = amadeusSession.Successful;
                envelopeRSModel.ListValidator = amadeusSession.ListErrors;

                if (envelopeRSModel.Success)
                {
                    // Genera una estructura XML de salida.
                    envelopeRSModel.Message = XDocument.Parse(XMLUtility.XsltTransform(GeneralUtility.LoadFileXSLT(soapAction.XSLTemplateRS), amadeusSession.XmlResponse.ToString()));
                }
            }
            else
            {
                envelopeRSModel.ListValidator = lstValidator;
                envelopeRSModel.Success = false;
            }

            return envelopeRSModel;
        }

        #endregion "Public Methods"

        #region "Private Methods"
        /// <summary>
        /// Permite validar la entrada xml y los posibles datos obligatorios.
        /// </summary>
        /// <param name="message">XML de entrada al servicio.</param>
        /// <returns>XML de entrada con las validaciones hechas, pero ya listo para realizar peticiones si es que se encuentra correcto.</returns>
        private List<string> ValidateRequest(ref XDocument message)
        {
            List<string> reply = new List<string>();

            message = new XDocument(
                from xmlElement in message.Descendants("Data")
                select new XElement("Data",
                    new XElement("MessageID", 
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("MessageID"))),
                    new XElement("VendorCode", 
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("VendorCode"), GeneralUtility.GetAppSetting("VendorCode"))),
                    new XElement("Amount", 
                        string.IsNullOrEmpty(ConversionUtility.ConvertXElementToValue(xmlElement.Element("Amount"))) ? 
                            GeneralUtility.VerifyRequired(ref reply, "El monto es requerido.") 
                            : xmlElement.Element("Amount").Value),
                    new XElement("DecimalPlaces", 
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("DecimalPlaces"), GeneralUtility.GetAppSetting("DecimalPlaces"))),
                    new XElement("CurrencyCode", 
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("CurrencyCode"), GeneralUtility.GetAppSetting("CurrencyCode"))),
                    new XElement("MaximumTransaction", 
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("MaximumTransaction"), GeneralUtility.GetAppSetting("MaximumTransaction"))),
                    new XElement("EndDate", 
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("EndDate"), 
                            DateTime.Now.AddDays(ConversionUtility.ConvertStringToDouble(GeneralUtility.GetAppSetting("DaysEndDateTransaction", "1"))).ToString("yyyy-MM-dd"))
                        )
                    )
                );

            return reply;
        }

        #endregion "Private Methods"   
    }
}
