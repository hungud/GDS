// <copyright file="GeneralUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Web;
    using System.Xml.Linq;

    /// <summary>
    /// Clase que posee utilidades de apoyo general y metodos especializados para ser utilizados en cualquier momento.
    /// </summary>
    public static class GeneralUtility
    {
        #region "Public method"

        /// <summary>
        /// Obtiene los valores de la anotación de una enumeración.
        /// </summary>
        /// <param name="value">valor de tipo eneumeración</param>
        /// <returns>
        /// Entidad generica
        /// </returns>
        public static T GetValuesAnnotation<T>(System.Enum value)
        {
            T output = default(T);
            FieldInfo fi = value.GetType().GetField(value.ToString());
            T[] attrs = fi.GetCustomAttributes(typeof(T), false) as T[];

            if (attrs.Length > 0)
            {
                output = (T)attrs[0];
            }

            return output;
        }

        /// <summary>
        /// Permite obtener el valor de una llave establecida dentro del Web.config. 
        /// </summary>
        /// <param name="Key">Nombre de la llave.</param>
        /// <param name="defaultValue">Si no encuentra coincidencias devuelva este valor.</param>
        /// <returns>el valor obtenido de la llave en una variable string.</returns>
        public static string GetAppSetting(string Key, string defaultValue = "")
        {
            string Value = ConfigurationManager.AppSettings[Key];

            if (!string.IsNullOrEmpty(Value))
            {
                return Value;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Permite obtener el valor de EndPoint de Amadeus de acuerdo al ambiente solicitado.
        /// </summary>
        /// <returns>Valor del EndPoint de comuncicación con Amadeus WebServices.</returns>
        public static string GetEndPoint()
        {
            string endPoint = String.Empty;

            switch (GeneralUtility.VerifyNotNull(GeneralUtility.GetAppSetting("Target")))
            {
                case "1":
                    endPoint = GeneralUtility.VerifyNotNull(GeneralUtility.GetAppSetting("EndPointProduction"));
                    break;
                case "2":
                default:
                    endPoint = GeneralUtility.VerifyNotNull(GeneralUtility.GetAppSetting("EndPointTest"));
                    break;
            }

            return endPoint;
        }       

        /// <summary>
        /// Permite remover la cadena que representa el protocolo dentro de un URL.
        /// </summary>
        /// <returns>Retorna una URL de tipo string sin la estructura del protocolo.</returns>
        public static string GetTrimmedEndPoint()
        {
            string endPoint = GeneralUtility.GetEndPoint().Replace("https://", string.Empty).Replace("http://", string.Empty);
            return endPoint.Substring(0, endPoint.IndexOf('/'));
        }

        /// <summary>
        /// Permite almacenar las transacciones realizadas con los servicios web de Amadeus dentro de un archivo de texto comprimido a traves del algoritmo GZip;
        /// estos archivos quedarán almacenados en carpetas nombradas según la fecha de ejecución.
        /// </summary>
        /// <param name="verb">Nombre del verbo con que se realizo la transacción.</param>
        /// <param name="messageId">Número de identificador unico trabajado con el mismo messageId.</param>
        /// <param name="content">Contenido que se debe almacenar dentro del archivo de texto.</param>
        /// <returns>Retorna un valor verdadero o falso segun si se logro hacer la acción del metodo en forma correcta.</returns>
        public static bool SaveLog(string verb, string messageId, string content)
        {
            bool response = false;

            if (GetAppSetting("TransactionLogs") != null && GetAppSetting("TransactionLogs") == "1")
            {
                try
                {
                    string logFolder = GetAppSetting("FolderLog");
                    CreateDirectory(logFolder);
                    logFolder = (logFolder.EndsWith("\\") ? string.Empty : "\\") + logFolder + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + "\\";
                    CreateDirectory(logFolder);

                    CompressFile(logFolder, verb + "_" + messageId + "_" + DateTime.Now.ToString("yyyyMMddHHmmss.ff"), "txt", content);

                    response = true;
                }
                catch
                {
                    response = false;
                }
            }

            return response;
        }

        /// <summary>
        /// Permite almacenar la descripción y seguimiento de una excepción ocurrida dentro del conector.
        /// </summary>
        /// <param name="lstMessage">Listado de mensajes que se desea almacenar dentro del archivo de texto.</param>
        /// <returns>Retorna un valor verdadero o falso segun si se logro hacer la acción del metodo en forma correcta.</returns>
        public static bool WriteExceptionLog(Dictionary<string, string> lstMessage)
        {
            bool response = false;

            try
            {
                string logFolder = GetAppSetting("FolderExceptionLog");
                CreateDirectory(logFolder);
                string logFile = (logFolder.EndsWith("\\") ? string.Empty : "\\") + logFolder + "Exceptions_" + DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) + ".txt";
                CreateFile(logFile);

                File.SetAttributes(logFile, FileAttributes.Archive | FileAttributes.Device | FileAttributes.Normal);

                FileStream traceLog = new FileStream(logFile, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                TextWriterTraceListener myListener = new TextWriterTraceListener(traceLog);
                Trace.Listeners.Add(myListener);

                lstMessage.Add("DateTime", DateTime.Now.ToString());

                foreach (KeyValuePair<string, string> attribute in lstMessage)
                {
                    myListener.WriteLine(" - " + attribute.Key + ":" + Environment.NewLine + attribute.Value);
                }

                myListener.WriteLine("_______________________________________________");

                Trace.Flush();
                myListener.Flush();
                myListener.Close();

                response = true;
            }
            catch
            {
                response = false;
            }

            return response;
        }

        /// <summary>
        /// Permite obtener contenido de un archivo de estructura XML.
        /// </summary>        
        /// <param name="file">Nombre del archivo de estructura XML a Cargar (debe estar dentro de la estructura de carpetas de esta solución).</param>
        /// <returns>un elemento de tipo XDocument.</returns>
        public static XDocument LoadFileXML(string file)
        {
            return XDocument.Load(AppDomain.CurrentDomain.BaseDirectory.ToString() + GeneralUtility.GetAppSetting("FolderXml") + file);
        }

        /// <summary>
        /// Metodo especifico para el cargue de los archivos de tipo XSLT.
        /// </summary>        
        /// <param name="file">Nombre del archivo XSLT a cargar.</param>
        /// <returns>Contenido del archivo desde el disco duro.</returns>
        public static string LoadFileXSLT(string file)
        {
            string response = string.Empty;

            try
            {
                StreamReader reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory.ToString() + GeneralUtility.GetAppSetting("folderXslt") + file, Encoding.UTF8);
                response = reader.ReadToEnd();
                reader.Close();
            }
            catch (Exception ex)
            {
                GeneralUtility.WriteExceptionLog(new Dictionary<string, string> { { "GetType", ex.GetType().ToString() }, { "Message", "(Error en el cargue de la plantilla de transformación: " + file + ") " + ex.Message }, { "StackTrace", ex.StackTrace } });               
            }

            return response;
        }

        /// <summary>
        /// Permite codificar una cadena en Base 64.
        /// </summary>
        /// <param name="toEncode">Cadena de caracteres a codificar.</param>
        /// <returns>Cadena de caracteres con el valor codificado en Base64.</returns>
        public static string Base64Encode(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            return System.Convert.ToBase64String(toEncodeAsBytes);
        }

        /// <summary>
        /// Permite decodificar una cadena en Base 64.
        /// </summary>
        /// <param name="base64EncodedData">Cadena de caracteres a decodificar.</param>
        /// <returns>Cadena de caracteres con el valor decodificado con Base64.</returns>
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Generar una cadena con un identificador único global.
        /// </summary>
        /// <returns>Identificador único global.</returns>
        public static string GUID()
        {
            return System.Guid.NewGuid().ToString(); ;
        }

        /// <summary>
        /// Permite reemplazar valores sobre una cadena de caracteres especifica.
        /// </summary>
        /// <param name="template">Texto sobre el cual se va ha sobreescribir los valores.</param>
        /// <param name="parameters">Parametros sobre los cuales se va a buscar y reemplazar los valores.</param>
        /// <returns>Cadena de caracteres con los valore ya reeemplazados sobre la cadena inicial.</returns>
        public static string ReplaceParameters(string template, Dictionary<string, string> parameters)
        {
            StringBuilder data = new StringBuilder();
            data.Append(template);

            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                data.Replace(parameter.Key, parameter.Value);
            }

            return data.ToString();
        }

        /// <summary>
        /// Permite comprimir contenido de una cadena de caracteres con el algoritmo GZip.
        /// </summary>
        /// <param name="text">Cadena de texto a comprimir.</param>
        /// <returns>Cadena de caracteres con contenido comprimido.</returns>
        public static string CompressGZip(string text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);

            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Metodo que permite la descompresión de una cadena de caracteres con el algoritmo GZip.
        /// </summary>
        /// <param name="compressedText">Texto a descomprimir.</param>
        /// <returns>cadena de caracteres con contenido descomprimido.</returns>
        public static string DecompressGZip(string compressedText)
        {
            byte[] gZipBuffer = Convert.FromBase64String(compressedText);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    gZipStream.Read(buffer, 0, buffer.Length);
                }

                return Encoding.UTF8.GetString(buffer);
            }
        }

        /// <summary>
        /// Devuelve el timestamp y se le puede sumar un numero de mintos
        /// </summary>
        /// <param name="valor">Cantidad de minutos a adicionar</param>
        /// <returns></returns>
        public static string GetTimestamp(int minutes)
        {
            DateTime date = DateTime.Now.AddMinutes(minutes);
            return date.ToString("yyyy-MM-dd") + "T" + date.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Verifica si un campo de tipo string es nulo y en ese caso retorna un valor vacio, sino retorna el valor difernete de null.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Retorna una cadena de caracteres.</returns>
        public static string VerifyNotNull(string value)
        {
            if (value != null)
            {
                return value;
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// Permite definir si el valor en un tipo de variable string, es un numero o no.
        /// </summary>
        /// <param name="value">Valor a ser evaluado.</param>
        /// <returns>una respeusta verdadera o falsa, segun la verificación realizada.</returns>
        public static bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        /// <summary>
        /// Permite la decodificación de tipo HTML o XML.
        /// </summary>
        /// <param name="input">cadena de caracteres de entrada a ser decodificado.</param>
        /// <returns></returns>
        public static string DecodeMessage(string input)
        {
            return HttpContext.Current.Server.HtmlDecode(input);
        }

        /// <summary>
        /// Permite la realización de un reemplazo de un string, dentro de otro.
        /// </summary>
        /// <param name="originText">Cadena string original</param>
        /// <param name="filter">Cadena de caracteres de coincidencia para el reemplazo.</param>
        /// <param name="replaceValue">Valor con el que se va a reemplazar, si se encuentra coincidencia.</param>
        /// <returns>cadena de caracteres con el reemplazo.</returns>
        public static string FilterString(string originText, string filter, string replaceValue = "")
        {
            return originText.Replace(filter, replaceValue);
        }

        /// <summary>
        /// Permite generar una lista de mensajes.
        /// </summary>
        /// <param name="reply">Lista de tipo string, que se maneja por referencia, para ir acumulando mensajes.</param>
        /// <param name="message">Valor de cadena de caracteres a ser adicionado.</param>
        /// <param name="retunValue">Valor que retorna el metodo.</param>
        /// <returns>Cadena de caracteres con el valor enviado por el usuario en la variable returnValue.</returns>
        public static string VerifyRequired(ref List<string> reply, string message, string retunValue = "")
        {
            if (!string.IsNullOrEmpty(message))
            {
                reply.Add(message);
            }

            return retunValue;
        }

        #endregion "Public method"

        #region "Private method"
        /// <summary>
        /// Permite crear un directorio dentro de una ruta fisica siempre y cuando no exista.
        /// </summary>
        /// <param name="folderPath">Ruta completa con el nombre del directorio a crear.</param>
        private static void CreateDirectory(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// Permite crear un archivo dentro de una ruta fisica siempre y cuando no exista. 
        /// </summary>
        /// <param name="filePath">Ruta completa con el nombre del archivo a crear.</param>
        private static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }
        }

        /// <summary>
        /// Metodo para compresión de contenido de texto a traves del algoritmo gZip, y automaticamente lo deja con la extensión gz.
        /// </summary>
        /// <param name="path">Ruta de destino (que termina con una barra invertida).</param>
        /// <param name="fileName">Nombre del archivo de destino.</param>
        /// <param name="extension">Extensión del archivo de destino.</param>
        /// <param name="content">Contenido que se va ha comprimir.</param>
        private static void CompressFile(string path, string fileName, string extension, string content)
        {
            UnicodeEncoding uniEncode = new UnicodeEncoding();
            byte[] bytesToCompress = uniEncode.GetBytes(content);

            using (FileStream fileToCompress = File.Create(string.Format(@"{0}{1}.{2}.gz", path, fileName, extension)))
            {
                using (GZipStream compressionStream = new GZipStream(fileToCompress, CompressionMode.Compress))
                {
                    compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
                }
            }
        }

        #endregion "Private method"        
    }
}
