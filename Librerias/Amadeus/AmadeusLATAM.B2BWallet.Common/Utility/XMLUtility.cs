// <copyright file="XMLUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.Xml.Xsl;

    /// <summary>
    /// Clase que posee funcionalidades comunes para el manejo de XML.
    /// </summary>
    public class XMLUtility
    {
        #region "Public Method"
        /// <summary>
        /// Permite cruzar contenido XML, XSLT y Parametros para el XSLT.
        /// </summary>
        /// <param name="source">Fuente de datos que se esta manejando.</param>
        /// <param name="xslTemplate">descripción de la plantilla a utilizar.</param>
        /// <param name="xmlRequest">Entrada XML que se cruzara con la plantilla de transformación.</param>
        /// <param name="parameters">Parametros que se deben pasar a la plantilla de transformación.</param>
        /// <returns>Cadena de caracteres con estructura XML y posee el contenido transformado.</returns>
        public static string XsltTransform(string xslTemplate, string xmlRequest, Dictionary<string, string> parameters = null)
        {
            StringBuilder strStringBuilder = new StringBuilder();

            try
            {
                StringReader str = new StringReader(xmlRequest);
                XPathDocument myXPathDoc = new XPathDocument(str);
                XslCompiledTransform myCompXslTrans = new XslCompiledTransform();
                XmlReader xml = XmlReader.Create(new StringReader(xslTemplate));
                myCompXslTrans.Load(xml);               

                XsltArgumentList argsList = new XsltArgumentList();

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> pair in parameters)
                    {
                        argsList.AddParam(pair.Key, string.Empty, pair.Value);
                    }
                }
                
                using (StringWriter strWriter = new StringWriter(strStringBuilder))
                {
                    myCompXslTrans.Transform(myXPathDoc, argsList, strWriter);
                }
            }
            catch (Exception ex)
            {
                GeneralUtility.WriteExceptionLog(new Dictionary<string, string> { { "GetType", ex.GetType().ToString() },
                                                                                  { "Message", ex.Message },
                                                                                  { "StackTrace", ex.StackTrace },
                                                                                  { "TemplateName", xslTemplate },
                                                                                      //{ "ErrorList:", String.Join("|", compiler.ErrorList) }
                });
                throw ex;
            }

            return strStringBuilder.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", string.Empty).ToString();           
        }

        /// <summary>
        /// Permite cruzar contenido XML, XSLT y Parametros para el XSLT.
        /// </summary>
        /// <param name="source">Fuente de datos que se esta manejando.</param>
        /// <param name="xslTemplate">descripción de la plantilla a utilizar.</param>
        /// <param name="xmlRequest">Entrada XML que se cruzara con la plantilla de transformación.</param>
        /// <param name="parameters">Parametros que se deben pasar a la plantilla de transformación.</param>
        /// <returns>Estructura XML sobre un tipo XDocument y posee el contenido transformado.</returns>
        public static XDocument XsltTransformXDoc(string xslTemplate, string xmlRequest, Dictionary<string, string> parameters)
        {
            return XDocument.Parse(XsltTransform(xslTemplate, xmlRequest, parameters));
        }

        /// <summary>
        /// Permite obtener la etiqueta Body dentro de la estructura de envoltorio de SOAP.
        /// </summary>
        /// <param name="xml">XML de donde se debe tomar el contenido dentro de la etiqueta Body.</param>
        /// <param name="withoutNamespace">Permite que tambien se remuevan los namespace en el XML.</param>
        /// <returns>Contenido dentro de la etiqueta Body.</returns>
        public static XDocument GetBody(XDocument xml, bool withoutNamespace = true)
        {            
            string strBody = xml.Descendants((XNamespace)"http://schemas.xmlsoap.org/soap/envelope/" + "Body").First().FirstNode.ToString();            

            if (withoutNamespace)
            {
                XElement xElem = XElement.Parse(strBody);
                RemoveNamespaces(xElem);
                strBody = RemoveNamespaceDeclarations(xElem.ToString());
            }

            return XDocument.Parse(strBody);
        }

        /// <summary>
        /// Permite obtener los datos de la sesion de una petición.
        /// </summary>
        /// <param name="xml">Entrade de tipo XML de la cual se buscará obtener los datos de la sesión.</param>
        /// <param name="withoutNamespace">Permite indicar si se elimina los namespace o no.</param>
        /// <returns>Un XML con los datos de la sesión adquirida.</returns>
        public static XDocument GetSession(XDocument xml, bool withoutNamespace = true)
        {
            string strHeader = xml.Descendants((XNamespace)"http://xml.amadeus.com/2010/06/Session_v3" + "Session").First().FirstNode.ToString();

            if (withoutNamespace)
            {
                XElement xElem = XElement.Parse(strHeader);
                RemoveNamespaces(xElem);
                strHeader = RemoveNamespaceDeclarations(xElem.ToString());
            }

            return XDocument.Parse(strHeader);
        }

        /// <summary>
        /// Permite remover las declaraciones de namespace para un archivo de tipo XML.
        /// </summary>
        /// <param name="xml">Entrada de tipo XML.</param>
        /// <returns>cadena con estructura XML que se le removieron los NameSpace.</returns>
        public static string RemoveNamespaceDeclarations(string xml)
        {
            string strXMLPattern = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            return Regex.Replace(xml, strXMLPattern, "");
        }        

        /// <summary>
        /// Metodo que permite ubicar dentro de un XML una estructura CData y devolver su contenido.
        /// </summary>
        /// <param name="xml">Estructura XML en la cual se debe extraer el valor que se encuentra dentro del CData.</param>
        /// <returns>Cadena de tipo XML en un XDocument.</returns>
        public static XDocument GetXMLFromXMLCData(XDocument xml)
        {
            var node = xml.DescendantNodes().SingleOrDefault(el => el.NodeType == XmlNodeType.CDATA);
            if (node != null)
            {
                var content = node.Parent.Value.Trim();
                return XDocument.Parse(content);
            }
            else
            {
                XDocument xdoc = GetBody(xml);
                return xdoc;
            }
        }

        /// <summary>
        /// Obtener el valor de un atributo.
        /// </summary>
        /// <param name="xml">XML en el cual se debe buscar el atributo requerido.</param>
        /// <param name="node">Elemento en el cual se debe buscar.</param>
        /// <param name="attr">Atributo que se debe buscar.</param>
        /// <returns>Valor encontrado con el atributo buscado.</returns>
        public static string GetAttributeValue(XDocument xml, string node, string attr)
        {
            try
            {
                string response = string.Empty;

                var q = from nodo in xml.Descendants()
                        where nodo.Name.LocalName == node
                        select nodo;
                if (q.Count() > 0)
                {
                    return q.ToList()[0].Attribute(attr).Value;
                }
                else
                    return null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Filtra duplicados en un XML
        /// </summary>
        /// <param name="nodes">Nodos a filtrar</param>
        /// <returns>Enumeración de nodos.</returns>
        public static IEnumerable<XNode> FilterDuplicates(IEnumerable<XNode> nodes)
        {
            foreach (XNode node in nodes.Where(n => !n.NodesBeforeSelf().Any(s => XNode.DeepEquals(n, s))))
            {
                switch (node.NodeType)
                {
                    case XmlNodeType.Element:
                        XElement elNode = node as XElement;
                        yield return new XElement(elNode.Name, elNode.Attributes(), FilterDuplicates(elNode.Nodes()));
                        break;
                    case XmlNodeType.Text:
                        yield return new XText(node as XText);
                        break;
                    case XmlNodeType.CDATA:
                        yield return new XCData(node as XCData);
                        break;
                    case XmlNodeType.Comment:
                        yield return new XComment(node as XComment);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        yield return new XProcessingInstruction(node as XProcessingInstruction);
                        break;
                }
            }
        }

        /// <summary>
        /// Quita el namespace a un XElement y sus descendientes
        /// </summary>
        /// <param name="xmlDocument">XElement a procesar</param>
        /// <returns>Objeto XElement sin namespace</returns>
        public static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(elem => RemoveAllNamespaces(elem)));
        }

        #endregion "Public Method"
        
        #region "Private Method"

        /// <summary>
        /// Metodo recursivo para recorrecor los elementos de un XML, para asi poder remover los namespace.
        /// </summary>
        /// <param name="element">Entrada de tipo XElement.</param>
        private static void RemoveNamespaces(XElement element)
        {
            // remove namespace prefix
            element.Name = element.Name.LocalName;

            // remove namespaces from children elements
            foreach (var elem in element.Elements())
            {
                RemoveNamespaces(elem);
            }

            // remove namespace attributes
            foreach (var attr in element.Attributes())
            {
                if (attr.IsNamespaceDeclaration)
                {
                    attr.Remove();
                }
            }
        }

        #endregion "Private Method"
    }
}
