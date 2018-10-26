// <copyright file="EnvelopeRSModel.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Model
{
    using System.Collections.Generic;
    using System.Xml.Linq;

    /// <summary>
    /// Entidad que permite manejar todos los datos de una petición de salida del servicio B2BWalletWCF.
    /// </summary>
    public class EnvelopeRSModel
    {
        #region "Public Properties"
        
        /// <summary>
        /// Muestra si el proceso fue correcto.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Mensaje entrante de la petición del verbo.
        /// </summary>
        public XDocument Message { get; set; }

        /// <summary>
        /// Presenta los mensajes de error recogidos en la generación de un proceso.
        /// </summary>
        public List<string> ListValidator { get; set; }

        #endregion "Public Properties"
    }
}
