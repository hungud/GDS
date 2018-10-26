// <copyright file="SoapActionModel.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Model
{
    /// <summary>
    /// Entidad que permite manejar todos los datos complementarios de anotaciones, en una enumeración de un servicio de Amadeus.
    /// </summary>
    public class SoapActionModel : System.Attribute
    {
        #region "Public Properties"

        /// <summary>
        /// Nombre del servicio.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Versión del servicio.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Descripción de la acción del Soap en su request.
        /// </summary>
        public string ActionRQ { get; set; }

        /// <summary>
        /// Descripción de la acción del Soap en su response.
        /// </summary>
        public string ActionRS { get; set; }

        /// <summary>
        /// Plantilla de transformación para manejar el XML de Entrada
        /// </summary>
        public string XSLTemplateRQ { get; set; }

        /// <summary>
        /// Plantilla de transformación para manejar el XML de Respuesta
        /// </summary>
        public string XSLTemplateRS { get; set; }

        #endregion "Public Properties"
    }
}
