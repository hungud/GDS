// <copyright file="ExceptionUtility.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Clase que busca reemplazar los mensajes de excepción no controlados, generando mensajes personalizados.
    /// </summary>
    public class ExceptionUtility : Exception
    {
        #region "Public Properties"

        /// <summary>
        /// Variable publica de solo lectura para consolidar mensajes especificos a devolverse luego de una excepción en el conector.
        /// </summary>
        public static readonly Dictionary<int, string> ErrorCodes = new Dictionary<int, string>
        {
            {1, "Acción no disponible en este servicio." },
            {2, "Error en el proceso de funcionalidad del servicio." },
            {3, "Error en el cifrado de datos." },         
        };

        #endregion "Public Properties"

        #region "Public Methods"
                
        /// <summary>
        ///  Construtor de la clase que recibe el mensaje especifico a devolver al usuario.
        /// </summary>
        /// <param name="message"> mensaje especifico a devolver al usuario</param>
        public ExceptionUtility(string message) : base(message){ }

        /// <summary>
        /// Permite generar el envoltorio de los posibles errores presentados durante el proceso de ejcución de un servicio.
        /// </summary>
        /// <param name="errorAttributes">valirable de tipo diccionario con la llave como caracteristica del error y la descripcion del error.</param>
        /// <returns>Un xml de tipo string con la definición de los errores a presentar.</returns>
        public static string GetEnvelopeErrorsResponse(Dictionary<string, string> errorAttributes)
        {
            XElement xRootOtaRs = new XElement("Errors");            

            foreach (KeyValuePair<string, string> attribute in errorAttributes)
            {
                if (attribute.Key.ToUpperInvariant().Contains("MESSAGE"))
                {
                    XElement xError = new XElement("Error");
                    xError.Value = GeneralUtility.FilterString(attribute.Value, GeneralUtility.GetTrimmedEndPoint(), "[Endpoint]");
                    xRootOtaRs.Add(xError);
                }
            }            

            /// Manejo de errores permitiendo ser almacenados en un archivo de texto con periodicidad diaria.
            GeneralUtility.WriteExceptionLog(errorAttributes);

            return xRootOtaRs.ToString();
        }

        #endregion "Public Methods"
    }
}
