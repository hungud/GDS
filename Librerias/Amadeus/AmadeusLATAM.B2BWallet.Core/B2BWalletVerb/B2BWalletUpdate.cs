// <copyright file="B2BWalletUpdate.cs" company="Amadeus IT Group Colombia">   
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
    /// Clase que permite realizar los llamados a los servicios necesarios para actualizar datos de las tarjetas de crédito.
    /// </summary>
    public class B2BWalletUpdate : IVerb
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
        /// Metodo que centraliza la ejecución de peticiones que permiten realizar la actualización de datos en una tarjeta de crédito.
        /// </summary>
        /// <returns>Entidad que presenta los datos de respuesta de la petición WS.</returns>
        public EnvelopeRSModel Execute(EnvelopeRQModel request)
        {
            EnvelopeRSModel envelopeRSModel = new EnvelopeRSModel();

            amadeusSession = new SessionWSModel();
            soapAction = GeneralUtility.GetValuesAnnotation<SoapActionModel>(AmadeusServiceEnum.PAY_UpdateVirtualCard_2_0);
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
                amadeusService = new PAY_UpdateVirtualCardService(amadeusSession);
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

            var quantityRef = message.Descendants("Reference").Where(w => !string.IsNullOrEmpty(w.Value)).Count();

            message = new XDocument(
                from xmlElement in message.Descendants("Data")
                select new XElement("Data",
                    new XElement("MessageID",
                        ConversionUtility.ConvertXElementToValue(xmlElement.Element("MessageID"))),
                    new XElement("Reference", new XAttribute("Type", "External"),
                        ConversionUtility.ConvertXElementToValue(xmlElement.Elements("Reference").Where(w => w.Attribute("Type") != null ? w.Attribute("Type").Value.Equals("External") : false).Select(s => s).FirstOrDefault())),
                    new XElement("Reference", new XAttribute("Type", "Amadeus"),
                        ConversionUtility.ConvertXElementToValue(xmlElement.Elements("Reference").Where(w => w.Attribute("Type") != null ? w.Attribute("Type").Value.Equals("Amadeus") : false).Select(s => s).FirstOrDefault(),
                            (quantityRef == 0 ? GeneralUtility.VerifyRequired(ref reply, "Es necesario el envio de por lo menos una referencia.") : ""))
                    ),
                    new XElement("Comment",
                        string.IsNullOrEmpty(ConversionUtility.ConvertXElementToValue(xmlElement.Element("Comment"))) ?
                            GeneralUtility.VerifyRequired(ref reply, "El Comentario es requerido.")
                            : xmlElement.Element("Comment").Value)
                )
            );

            return reply;
        }

        #endregion "Private Methods"
    }
}
