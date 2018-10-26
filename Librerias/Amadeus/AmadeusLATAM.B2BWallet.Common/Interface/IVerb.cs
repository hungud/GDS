// <copyright file="IVerb.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Interface
{
    using AmadeusLATAM.B2BWallet.Common.Model;

    /// <summary>
    /// Interface que expone el metodo execute de la fachada implementada.
    /// </summary>
    public interface IVerb
    {
        /// <summary>
        /// Metodo común utilizado por todos los verbos OTA (Proyecto Core), para ejecutar la funcionalidad especifica. 
        /// </summary>
        /// <param name="request">Entidad que contiene el verbo especifico a ejecutarse, 
        /// mensajeria request de tipo OTA y datos de importancia dentro del envoltorio MPA.</param>
        /// <returns>Entidad con estrutura de tipo MPA con los datos de respuesta.</returns>
        EnvelopeRSModel Execute(EnvelopeRQModel request);
    }
}
