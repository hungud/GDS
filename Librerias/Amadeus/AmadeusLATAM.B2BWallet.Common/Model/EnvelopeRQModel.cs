// <copyright file="EnvelopeRQModel.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Model
{
    using AmadeusLATAM.B2BWallet.Common.Enum;
    using System.Xml.Linq;

    /// <summary>
    /// Entidad que permite manejar todos los datos de una petición entrante al servicio B2BWalletWCF
    /// </summary>
    public class EnvelopeRQModel
    {
        #region "Public Properties"
        
        /// <summary>
        /// Nombre del verbo que se invoca.
        /// </summary>        
        public VerbMethodEnum Command { get; set; }

        /// <summary>
        /// Ambiente al cual esta apuntando.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Codigo de la aplicación quien llama el servicios (para el caso de diversas aplicaciones).
        /// </summary>
        public string ConsumerID { get; set; }
        
        /// <summary>
        /// Mensaje entrante de la petición del verbo.
        /// </summary>
        public XDocument Message { get; set; }

        #endregion "Public Properties"
    }
}
