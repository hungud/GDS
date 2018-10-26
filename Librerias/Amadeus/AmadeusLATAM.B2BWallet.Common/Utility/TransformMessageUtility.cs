// <copyright file="TransformMessageUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author>  

namespace AmadeusLATAM.B2BWallet.Common.Utility
{
    using AmadeusLATAM.B2BWallet.Common.Enum;
    using AmadeusLATAM.B2BWallet.Common.Model;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Clase especializada en utilidades para el manejo de la mensajeria entrante al servicio.
    /// </summary>
    public class TransformMessageUtility
    {
        #region "Public Methods"

        /// <summary>
        /// Permite obtener los datos del envoltorio de la petición de entrada al servicio.
        /// </summary>
        /// <param name="request">Petición de entrada con estructura XML.</param>
        /// <returns>Entidad con los datos necesarios del envoltorio para trabajar con la petición de entrada.</returns>
        public static EnvelopeRQModel GetMessageEnvelopeRequest(string request)
        {
            XDocument xDocRequest = XDocument.Parse(GeneralUtility.DecodeMessage(request));
            return (from xmlElement in xDocRequest.Descendants()
                    select new EnvelopeRQModel
                    {
                        ConsumerID = ConversionUtility.ConvertXElementToValue(xmlElement.Element("ConsumerID"), "0"),
                        Command = ConversionUtility.ConvertStringToEnum<VerbMethodEnum>(ConversionUtility.ConvertXElementToValue(xmlElement.Element("Command")), 0),
                        Message = XDocument.Parse(ConversionUtility.ConvertValueToString(xmlElement.Descendants("Message").Elements().FirstOrDefault(), "<Data/>"))
                    }).FirstOrDefault();
        }

        /// <summary>
        /// Metodo que permite estructurar el XML de respuesta.
        /// </summary>
        /// <param name="command">Identificativo del verbo llamado.</param>
        /// <param name="consumerId">Identificativo de la aplicación que invoca alguna funcionalidad del servicio.</param>
        /// <param name="xmlMessage">Mensajeria XML que requiere ser envuelta dentro de la respuesta.</param>
        /// <param name="success">Mensajeria XML que requiere ser envuelta dentro de la respuesta.</param>
        /// <returns></returns>
        public static string WrapMessageToEnvelope(string command, string consumerId, string xmlMessage, bool success = true)
        {           
            string templateEnvelope = @"<Response><Success>{3}</Success><Command>{0}</Command><ConsumerID>{1}</ConsumerID><Message>{2}</Message></Response>";
            return XElement.Parse(string.Format(templateEnvelope, command, (string.IsNullOrEmpty(consumerId) ? GeneralUtility.GetAppSetting("ConsumerId", "1") : consumerId), xmlMessage, success)).ToString();
        }

        #endregion "Public Methods"
    }
}