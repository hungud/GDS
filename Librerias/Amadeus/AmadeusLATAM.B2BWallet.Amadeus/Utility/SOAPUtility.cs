// <copyright file="SOAPUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Amadeus.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;

    /// <summary>
    /// Permite trabajar funcionalidades especificas de realización de peticiones SOAP hacia Amadeus WS.
    /// </summary>
    public class SOAPUtility
    {
        #region "Public Properties"

        /// <summary>
        /// Variable que permite el envio de peticiones a los servicios web de Amadeus.
        /// </summary>
        public HttpWebRequest req = null;

        /// <summary>
        /// Permite manejar la plantilla de elementos XML Soap (Envelop, Header and Body).
        /// </summary>
        public string Xml_Request_Template = string.Empty;

        /// <summary>
        /// Manejo de tipo de archivo (XML - UTF8).
        /// </summary>
        public string ContentType = string.Empty;

        /// <summary>
        /// Definición del tiempo limite de espera de una petición.
        /// </summary>
        public int Timeout { get; set; }

        /// <summary>
        /// Definición de nombre del sistema final.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Definición de elementos que conforman una petición Soap a traves de HTTPWebRequest.
        /// </summary>
        public Dictionary<string, string> Headers = new Dictionary<string, string>();

        #endregion "Public Properties"

        #region "Private Properties"

        /// <summary>
        /// Definición para el manejo de cookies para las peticiones HTTPWebRequest.
        /// </summary>
        private CookieContainer cookieContainer = new CookieContainer();

        /// <summary>
        /// URL que indica el endpoint junto con el ambiente al cual se va a generar la petición de Amadeus WS.
        /// </summary>
        private string EndPoint_SOAP = string.Empty;

        #endregion "Private Properties"

        #region "Public Methods"

        /// <summary>
        /// Constructor de la instancia, que permite inicializar los objetos necesarios para comuncicación con el EndPoint de Amadeus.
        /// </summary>
        /// <param name="endPoint"></param>
        public SOAPUtility(string endPoint)
        {
            EndPoint_SOAP = endPoint;
            req = (HttpWebRequest)WebRequest.Create(EndPoint_SOAP);
            req.KeepAlive = true;
            setVars();
        }

        /// <summary>
        /// Realiza la peticion al EndPoint de Amadeus.
        /// </summary>
        /// <param name="xmlInfo">PayLoad de la peticion</param>
        /// <param name="action">SOAP Action de  la peticion </param>
        /// <param name="proxy">Datos del proxy (si se quiere usar uno)</param>
        /// <param name="res">parametro por referencia OK si la peticion se completo correctamente</param>
        /// <returns>Xml completo de la respuesta SOAP</returns>
        public string HttpSOAPRequest(string xmlInfo, 
                                      string action, 
                                      string proxy, 
                                      ref bool res)
        {
            string xml = string.Format(Xml_Request_Template, xmlInfo);
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;             
                System.Net.ServicePointManager.Expect100Continue = false;
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(EndPoint_SOAP);
                req.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                req.KeepAlive = true;
                if (Host.Length > 0)
                {
                    req.Host = Host;
                }
                req.UserAgent = "B2B Wallet Service";
                req.CookieContainer = cookieContainer;
                req.Timeout = Timeout;
                if (proxy != null)
                    req.Proxy = new WebProxy(proxy, true);
                byte[] byteArray = Encoding.UTF8.GetBytes(xml);
                req.ContentType = ContentType;
                if (action.Length > 0)
                    req.Headers.Add("SOAPAction", action);
                if (Headers.Count() > 0) //Headers adicionales
                {
                    foreach (var item in Headers)
                    {
                        req.Headers.Add(item.Key, item.Value);
                    }
                }
                req.ContentLength = byteArray.Length;
                req.Method = "POST";

                Stream stm = req.GetRequestStream();

                // Escribir datos al Stream.
                stm.Write(byteArray, 0, byteArray.Length);
                // Cerrar el objeto Stream.
                stm.Close();

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                stm = resp.GetResponseStream();
                StreamReader r = new StreamReader(stm);
                string myd = r.ReadToEnd();
                res = true;

                return myd;
            }
            catch (WebException we)
            {
                res = false;
                string myd = string.Empty;
                if (we.Response != null)
                {
                    Stream stm = we.Response.GetResponseStream();
                    StreamReader r = new StreamReader(stm);
                    myd = r.ReadToEnd();
                }
                else
                {
                    throw we;
                }
                return (myd);
            }
            catch (Exception se)
            {
                res = false;
                return (se.Message);
            }
        }

        #endregion "Public Methods"

        #region "Private Methods"

        /// <summary>
        /// Inicializa las variable necesarias para hacer un llamado basico, ContentType y el "Sobre" SOAP ver 1.1
        /// </summary>
        private void setVars()
        {
            ContentType = "text/xml; charset=utf-8";
            Xml_Request_Template = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\"  xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SOAP-ENC=\"http://schemas.xmlsoap.org/soap/encoding/\" SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><SOAP-ENV:Body>{0}</SOAP-ENV:Body></SOAP-ENV:Envelope>";
            Timeout = 120000;
            Host = "";
        }

        #endregion "Private Methods"
    }
}
