// <copyright file="GeneralUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Amadeus.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;

    /// <summary>
    /// Metodos de utilidad general.
    /// </summary>
    public static class GeneralUtility
    {
        #region "Public Methods"
        /// <summary>
        /// Generar una cadena con un identificador único global.
        /// </summary>
        /// <returns>Identificador único global.</returns>
        public static string GUID()
        {
            return System.Guid.NewGuid().ToString();
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
        /// Permite la conversión de definición XElement a obtener el valor de tipo string.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera "".</param>
        /// <returns>Cadena de caracteres con el valor convertido.</returns>
        public static string ConvertXElementToValue(XElement value, string defaultValue = "")
        {
            return (value != null ? value.Value : defaultValue);
        }

        /// <summary>
        /// Permite la conversión de definición String a Integer.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera 0.</param>
        /// <returns>Definición de tipo int con el valor convertido.</returns>
        public static int ConvertStringToInteger(string value, int defaultValue = 0)
        {
            int response;
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.CurrentCulture, out response) ? response : defaultValue;
        }

        /// <summary>
        /// Permite invertir los caracteres de un texto.
        /// </summary>
        /// <param name="value">Cadena de caracteres entrante y a partir de la cual se invierten los caracteres.</param>
        /// <returns>Una cadena de caracteres con los carateres invertidos.</returns>
        public static string Reverse(string value)
        {
            char[] charArray = value.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Permite la generación de un valor de tipo GUID.
        /// </summary>
        /// <param name="value">Cadena de caracteres a partir de la cual se genera el GUID.</param>
        /// <returns>Un valor de tipo de dato GUID.</returns>
        public static Guid ToGuid(string value)
        {
            byte[] stringbytes = Encoding.UTF8.GetBytes(value);
            byte[] hashedBytes = new System.Security.Cryptography
                .SHA1CryptoServiceProvider()
                .ComputeHash(stringbytes);
            Array.Resize(ref hashedBytes, 16);
            return new Guid(hashedBytes);
        }

        #endregion "Public Methods"
    }
}
