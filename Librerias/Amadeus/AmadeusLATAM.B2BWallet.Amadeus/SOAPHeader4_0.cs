// <copyright file="SOAPHeader4_0.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Amadeus
{
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using Utility;
    using System.Linq;
    using System.IO;
    using AmadeusLATAM.B2BWallet.Amadeus.Enum;

    /// <summary>
    /// Funcionalidades especificas para la generación del encabezado de una petición SOAP.
    /// </summary>
    public static class SOAPHeader4_0
    {
        #region Public Properties

        /// <summary>
        /// Template que contiene el envoltorio del SOAP, para peticiones que requieren autenticación y por ende apertura de sesión (Stateless o Start).
        /// </summary>
        public static string HeaderLoginRQ
        {
            get
            {
                return @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ses=""http://xml.amadeus.com/2010/06/Session_v3"">
                            <soap:Header>
                            {transactionStatusCode}
                            <add:MessageID xmlns:add=""http://www.w3.org/2005/08/addressing"">{messageId}</add:MessageID>
                            <add:Action xmlns:add=""http://www.w3.org/2005/08/addressing"">http://webservices.amadeus.com/{service}</add:Action>
                            <add:To xmlns:add=""http://www.w3.org/2005/08/addressing"">{endPoint}</add:To>
                            <link:TransactionFlowLink xmlns:link=""http://wsdl.amadeus.com/2010/06/ws/Link_v1""/>
                            <oas:Security xmlns:oas=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                                <oas:UsernameToken xmlns:oas1=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"" oas1:Id=""UsernameToken-1"">
                                <oas:Username>{userId}</oas:Username>
                                <oas:Nonce EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">{nonceToSend}</oas:Nonce>
                                <oas:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">{passwordDigest}</oas:Password>
                                <oas1:Created>{created}</oas1:Created>
                                </oas:UsernameToken>
                            </oas:Security>
                            <AMA_SecurityHostedUser xmlns=""http://xml.amadeus.com/2010/06/Security_v1"">
                                <UserID POS_Type=""1"" PseudoCityCode=""{officeId}"" RequestorType=""U""/>
                            </AMA_SecurityHostedUser>
                            </soap:Header>
                            <soap:Body>{body}</soap:Body>
                        </soap:Envelope>";
            }
        }

        /// <summary>
        /// Template que contiene el envoltorio del SOAP, para peticiones que ya poseen autenticación (Inseries o End).
        /// </summary>
        public static string HeaderInProcessRQ
        {
            get
            {
                return @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:ses=""http://xml.amadeus.com/2010/06/Session_v3"">
                            <soap:Header>
                                <ses:Session TransactionStatusCode=""{transactionStatusCode}"">
                                    <ses:SessionId>{sessionId}</ses:SessionId>
                                    <ses:SequenceNumber>{sequenceNumber}</ses:SequenceNumber>
                                    <ses:SecurityToken>{securityToken}</ses:SecurityToken>
                                </ses:Session>
                            <add:MessageID xmlns:add=""http://www.w3.org/2005/08/addressing"">{messageId}</add:MessageID>
                            <add:Action xmlns:add=""http://www.w3.org/2005/08/addressing"">http://webservices.amadeus.com/{service}</add:Action>
                            <add:To xmlns:add=""http://www.w3.org/2005/08/addressing"">{endPoint}</add:To>                                
                            </soap:Header>
                            <soap:Body>{body}</soap:Body>
                        </soap:Envelope>";
            }
        }
        #endregion

        #region "Public Method"

        /// <summary>
        /// Permite la generación del encabezado para las peticiones que requieren autenticación y generación de sesión.
        /// </summary>
        /// <param name="SessionWSModel"></param>
        /// <returns></returns>
        public static string GenerateVerbRequestLogin(SessionWSModel SessionWSModel)
        {   
            var password = (SessionWSModel.TypePasswordEncryption == TypePasswordEncryptionEnum.PasswordBase64) ? GeneralUtility.Base64Decode(SessionWSModel.BinaryData) : SessionWSModel.BinaryData;
            
            string nonce = GenerateNonce();
            string created = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            password = GeneratePasswordDigest(nonce, password, created);
            nonce = GeneralUtility.Base64Encode(nonce);

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("{transactionStatusCode}", ((int)SessionWSModel.TransactionStatusCode == 0 ? string.Empty : "<ses:Session TransactionStatusCode=\"Start\"/>"));
            parameters.Add("{messageId}", GeneralUtility.GUID());
            parameters.Add("{service}", SessionWSModel.AmadeusService);
            parameters.Add("{endPoint}", SessionWSModel.EndPoint);
            parameters.Add("{userId}", SessionWSModel.UserID);
            parameters.Add("{nonceToSend}", nonce);
            parameters.Add("{passwordDigest}", password);
            parameters.Add("{created}", created);
            parameters.Add("{officeId}", SessionWSModel.OfficeID);
            parameters.Add("{body}", SessionWSModel.XmlRequest.ToString());
                        
            return GeneralUtility.ReplaceParameters(HeaderLoginRQ, parameters);
        }

        /// <summary>
        /// Permite la generación del encabezado para las peticiones que no requieren autenticación.
        /// </summary>
        /// <param name="SessionWSModel"></param>
        /// <returns></returns>
        public static string GenerateVerbRequestInProcess(SessionWSModel SessionWSModel)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("{transactionStatusCode}", SessionWSModel.TransactionStatusCode.ToString());
            parameters.Add("{sessionId}", SessionWSModel.SessionId);
            parameters.Add("{sequenceNumber}", SessionWSModel.SequenceNumber.ToString());
            parameters.Add("{securityToken}", SessionWSModel.SecurityToken);
            parameters.Add("{messageId}", GeneralUtility.GUID());
            parameters.Add("{service}", SessionWSModel.AmadeusService);
            parameters.Add("{endPoint}", SessionWSModel.EndPoint);
            parameters.Add("{body}", SessionWSModel.XmlRequest.ToString());

            return GeneralUtility.ReplaceParameters(HeaderInProcessRQ, parameters);
        }

        /// <summary>
        /// Generar password digest para SoapHeader 4.0
        /// </summary>
        /// <param name="nonce">Cadena aleatoria con longitud multiplo de 4, sin codificar.</param>
        /// <param name="password">Password decodificado.</param>
        /// <param name="timestamp">fecha y hora actual con el formato yyyy-MM-ddTHH:mm:ss.fffZ</param>
        /// <returns>Cadena de caracteres con el password digest.</returns>
        public static string GeneratePasswordDigest(string nonce, string password, string timestamp)
        {
            var sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] time = Encoding.UTF8.GetBytes(timestamp);
            byte[] pwd = Encoding.UTF8.GetBytes(password);
            pwd = sha1Hasher.ComputeHash(pwd);
            byte[] nonc = Encoding.UTF8.GetBytes(nonce);
            byte[] operand = new byte[nonc.Length + time.Length + pwd.Length];
            Array.Copy(nonc, operand, nonc.Length);
            Array.Copy(time, 0, operand, nonce.Length, time.Length);
            Array.Copy(pwd, 0, operand, nonce.Length + time.Length, pwd.Length);
            byte[] hashedDataBytes = sha1Hasher.ComputeHash(operand);
            return Convert.ToBase64String(hashedDataBytes);
        }
                        
        /// <summary>
        /// Ejecutar peticiones Request hacia los servidores de Amadeus WS.
        /// </summary>
        /// <param name="SessionWSModel">Entidad que posee los datos necesarios para lanzar la petición WS.</param>
        public static void ExecuteSOAPRequest(ref SessionWSModel SessionWSModel)
        {
            var ok = false;
            SOAPUtility SU = new SOAPUtility(SessionWSModel.EndPoint);
            SU.Xml_Request_Template = "{0}";
            SU.ContentType = "text/xml;charset=UTF-8";
            SU.Headers.Add("Accept-Encoding", "gzip");            
            string response = SU.HttpSOAPRequest(SessionWSModel.XmlRequest.ToString(), 
                                    "\"http://webservices.amadeus.com/" + SessionWSModel.AmadeusService + "\"",
                                    null, 
                                    ref ok);

            SessionWSModel.XmlResponse = XDocument.Parse(response);
            SessionWSModel.Successful = ok;
            if (SessionWSModel.GetSessionData) SetSessionDetailsRS(ref SessionWSModel);
        }

        #endregion "Public Method"

        #region "Private Method"

        /// <summary>
        /// Generar un identificativo único global.
        /// </summary>
        /// <returns>Cadena con identificador único global.</returns>
        private static string GenerateNonce()
        {
            return GeneralUtility.GUID().Substring(0, 8);
        }

        /// <summary>
        /// Permite obtener los datos de sesión de una petición ya lanzada.
        /// </summary>
        /// <param name="sessionWS">Entidad que posee todo lo relacionado con la petición enviada a WS de Amadeus.</param>
        private static void SetSessionDetailsRS(ref SessionWSModel sessionWS)
        {
            XNamespace xNameSpace = "http://xml.amadeus.com/2010/06/Session_v3";
            sessionWS.SessionId = GeneralUtility.ConvertXElementToValue(sessionWS.XmlResponse.Descendants(xNameSpace + "SessionId").FirstOrDefault());
            sessionWS.SecurityToken = GeneralUtility.ConvertXElementToValue(sessionWS.XmlResponse.Descendants(xNameSpace + "SecurityToken").FirstOrDefault());
            sessionWS.SequenceNumber = GeneralUtility.ConvertStringToInteger(GeneralUtility.ConvertXElementToValue(sessionWS.XmlResponse.Descendants(xNameSpace + "SequenceNumber").FirstOrDefault()));
        }

        #endregion "Private Method"
    }
}
