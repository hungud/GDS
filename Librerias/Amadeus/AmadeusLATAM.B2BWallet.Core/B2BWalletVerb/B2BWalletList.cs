// <copyright file="B2BWalletList.cs" company="Amadeus IT Group Colombia">   
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Clase que permite realizar los llamados a los servicios necesarios para listar las tarjetas de crédito que cumplen con unos criterios especificos.
    /// </summary>
    public class B2BWalletList : IVerb
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
        /// Metodo que centraliza la ejecución de peticiones que permiten generar la lista de las tarjetas de crédito que cumplan con ciertos criterios.
        /// </summary>
        /// <returns>Entidad que presenta los datos de respuesta de la petición WS.</returns>
        public EnvelopeRSModel Execute(EnvelopeRQModel request)
        {
            EnvelopeRSModel envelopeRSModel = new EnvelopeRSModel();

            amadeusSession = new SessionWSModel();
            soapAction = GeneralUtility.GetValuesAnnotation<SoapActionModel>(AmadeusServiceEnum.PAY_ListVirtualCards_2_0);
            amadeusSession.AmadeusService = soapAction.ActionRQ;
            amadeusSession.XSLTemplate = soapAction.XSLTemplateRQ;
            amadeusSession.TransactionStatusCode = TransactionStatusCodeEnum.Stateless;
            amadeusSession.GetSessionData = true;

            XDocument xDocMessage = request.Message;
            List<string> lstValidator = ValidateRequest(ref xDocMessage);

            if (lstValidator == null || lstValidator.Count() == 0)
            {
                // Ejecuta la consulta al verbo
                amadeusSession.XmlRequestInitial = xDocMessage;
                amadeusService = new PAY_ListVirtualCardsService(amadeusSession);
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
                    new XElement("Type",
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("Type"))),
                    new XElement("VendorCode",
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("VendorCode"))),
                    new XElement("CurrencyCode",
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("CurrencyCode"), GeneralUtility.GetAppSetting("CurrencyCode"))),
                    new XElement("Period", 
                        new XAttribute("Start",
                            string.IsNullOrEmpty(ConversionUtility.GetXAttributeFromXElement(xmlElement.Element("Period"), "Start")) ?
                                GeneralUtility.VerifyRequired(ref reply, "La fecha de periodo inicial es requerida.") :
                                ConversionUtility.GetXAttributeFromXElement(xmlElement.Element("Period"), "Start")),                           
                        new XAttribute("End",
                             string.IsNullOrEmpty(ConversionUtility.GetXAttributeFromXElement(xmlElement.Element("Period"), "End")) ?
                                GeneralUtility.VerifyRequired(ref reply, "La fecha de periodo final es requerida.") :
                                ConversionUtility.GetXAttributeFromXElement(xmlElement.Element("Period"), "End"))
                    ),    
                    new XElement("AmountRange",
                        new XAttribute("Min",
                            ConversionUtility.GetXAttributeFromXElement(xmlElement.Element("AmountRange"), "Min")
                            ),
                        new XAttribute("Max",
                            ConversionUtility.GetXAttributeFromXElement(xmlElement.Element("AmountRange") , "Max")
                            )
                        ),
                    new XElement("CardStatus",
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("CardStatus"))                        
                    )
                )
            );

            return reply;
        }

        #endregion "Private Methods"
    }
}
