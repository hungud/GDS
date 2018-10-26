// <copyright file="ConversionUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Linq;

    /// <summary>
    /// Clase especializada en metodos de conversión de datos de un tipo a otro.
    /// </summary>
    public class ConversionUtility
    {
        #region "Public Methods"

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
        /// Permite la conversión de definición String a Boolean.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera false.</param>
        /// <returns>Definición de tipo bool con el valor convertido.</returns>
        public static bool ConvertStringToBoolean(string value, bool defaultValue = false)
        {
            bool response;
            return bool.TryParse(value, out response) ? response : defaultValue;
        }

        /// <summary>
        /// Permite la conversión de definición String a Decimal.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera 0.</param>
        /// <returns>Definición de tipo Decimal con el valor convertido.</returns>
        public static Decimal ConvertStringToDecimal(string value, Decimal defaultValue = 0)
        {
            Decimal response;
            string character = string.IsNullOrEmpty(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) ? "." : CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            value = value.Replace(character == "," ? "." : ",", character);

            return decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out response) ? response : defaultValue;
        }

        /// <summary>
        /// Permite la conversión de definición String a float.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelve un valor determinado. Si no se envía, por defecto será 0</param>
        /// <returns>Definición de tipo float con el valor convertido.</returns>
        public static float ConvertStringToFloat(string value, float defaultValue = 0)
        {
            float response;
            string character = string.IsNullOrEmpty(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) ? "." : CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            value = value.Replace(character == "," ? "." : ",", character);

            return float.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out response) ? response : defaultValue;
        }

        /// <summary>
        /// Permite la conversión de definición String a double.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelve un valor determinado. Si no se envía, por defecto será 0</param>
        /// <returns>Definición de tipo double con el valor convertido.</returns>
        public static double ConvertStringToDouble(string value, double defaultValue = 0)
        {
            double response;
            string character = string.IsNullOrEmpty(CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator) ? "." : CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            value = value.Replace(character == "," ? "." : ",", character);

            return double.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out response) ? response : defaultValue;
        }

        /// <summary>
        /// Permite la conversión de definición string (formato ISO8601) a DateTime.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <returns>Definición de tipo DateTime con el valor convertido.</returns>
        public static DateTime ConvertStringISOToDateTime(string value)
        {
            return DateTime.ParseExact(value, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        /// <summary>
        /// Permite la conversión de definición string (formato ISO8601) a DateTime.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <returns>Definición de tipo DateTime con el valor convertido.</returns>
        public static string ConvertStringISOToAmadeus(string value)
        {
            return String.Format("{0}{1}{2}", value.Substring(8, 2), value.Substring(5, 2), value.Substring(2, 2));
        }

        /// <summary>
        /// Permite la conversión de definición String a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ConvertStringToDateTime(string value)
        {
            DateTime response;
            return DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.None, out response) ? response : DateTime.MinValue;
        }

        /// <summary>
        /// Permite la conversión de definición XElement a obtener el valor de tipo string.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera "".</param>
        /// <returns>Cadena de caracteres con el valor convertido.</returns>
        public static string ConvertXElementToValue(XElement value, string defaultValue = "")
        {
            return (value != null && !value.Equals("") ? value.Value : defaultValue);
        }

        /// <summary>
        /// Permite obtener el valor de un atributo que se encuentra dentro de un elemento.
        /// </summary>
        /// <param name="element">Definición del elemento.</param>
        /// <param name="AttributeName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetXAttributeFromXElement(XElement element, string AttributeName, string defaultValue = "")
        {
            return (element != null ? (element.Attribute(AttributeName) != null ? element.Attribute(AttributeName).Value : defaultValue) : defaultValue);
        }

        /// <summary>
        /// Permite la conversión de definición XAttribute a obtener el valor de tipo string.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera "".</param>
        /// <returns>Cadena de caracteres con el valor convertido.</returns>
        public static string ConvertXAttributeToValue(XAttribute value, string defaultValue = "")
        {
            return (value != null && value.Value != "" ? value.Value : defaultValue);
        }

        /// <summary>
        /// Permite la conversión de una definción de tipo Object a un tipo de valor string.
        /// </summary>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera "".</param>
        /// <returns></returns>
        public static string ConvertValueToString(object value, string defaultValue = "")
        {
            return ((value != null) ? (value.ToString().Trim().Equals(string.Empty) ? defaultValue : value.ToString()) : defaultValue);
        }

        /// <summary>
        /// Permite la conversión de definición String a Enumeration.
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value">Valor a convertir su definición.</param>
        /// <param name="defaultValue">Si no es posible la conversión devuelva un valor determinado, y si no se coloca nada por defecto sera indefinido.</param>
        /// <returns>Enumeración enviada como generica.</returns>
        public static TEnum ConvertStringToEnum<TEnum>(string value, TEnum defaultValue = default(TEnum)) where TEnum : struct
        {
            if (string.IsNullOrEmpty(value)) { return defaultValue; }
            TEnum lResult;
            if (System.Enum.TryParse(value, true, out lResult)) { return lResult; }
            return defaultValue;
        }

        /// <summary>
        /// Permite la conversión de un tipo lista y su contenido, a un tipo Diccionario con llave string y variable de valor segun se requiera T typeparam.
        /// </summary>
        /// <typeparam name="T">Tipo de dato con el cual viene los valores de la lista y con el cual se generaria el tipo del campo valor del diccionario retornado.</typeparam>
        /// <param name="list">Lista con datos a ser convertida.</param>
        /// <param name="key">Nombre de la llave del mensaje para cada item que se generará dentro del diccionario de retorno.</param>
        /// <returns>Un diccionario con llave consecutiva y en el valor el tipo de dato definido por T y con los datos de la lista entrante.</returns>
        public static Dictionary<string, T> ConvertListToDictionary<T>(List<T> list, string key="")
        {
            Dictionary<string, T> reply = new Dictionary<string, T>();
            int numeral = 0;

            foreach (T item in list)
            {
                reply.Add(key + "" + numeral++, item);
            }

            return reply;
        }

        #endregion "Public Methods"
    }
}
