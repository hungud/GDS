// <copyright file="FacadeVerb.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author>  

namespace AmadeusLATAM.B2BWallet.Core
{
    using AmadeusLATAM.B2BWallet.Common.Enum;
    using AmadeusLATAM.B2BWallet.Common.Interface;
    using AmadeusLATAM.B2BWallet.Core.B2BWalletVerb;
    using Common.Utility;

   
    /// <summary>
    /// Clase utilizada como Fachada, la cual conoce qué clases del subsistema son responsables de una determinada petición, 
    /// y delega esas peticiones a los objetos apropiados del subsistema (Verbos OTA).
    /// 
    /// Motivación:
    /// El patrón fachada viene motivado por la necesidad de estructurar un entorno de programación y reducir su complejidad con la división 
    /// en subsistemas, minimizando las comunicaciones y dependencias entre éstos.
    /// 
    /// Participantes:
    /// Fachada (class FacadeVerb): 
    /// Conoce qué clases del subsistema son responsables de una determinada petición, y delega esas peticiones de los clientes a los objetos apropiados del subsistema.
    /// 
    /// Subclases (Verbs - VerbMethodEnum): 
    /// Implementan la funcionalidad del subsistema. Realizan el trabajo solicitado por la fachada. No conocen la existencia de la fachada.
    /// 
    /// Fuente de datos: https://es.wikipedia.org/wiki/Facade_(patr%C3%B3n_de_dise%C3%B1o)
    /// </summary>
    public static class FacadeVerb
    {
        #region "Public Methods"

        /// <summary>
        /// Encargado de delegar las peticiones a los Verbos (VerbMethodEnum), de acuerdo al llamado realizado por un cliente (a traves del parametro: "Command").
        /// </summary>
        /// <param name="method">Verbo solicitado por el cliente para implementar la funcionalidad.</param>
        /// <returns></returns>
        public static IVerb CreateVerb(VerbMethodEnum command)
        {
            IVerb response = null;

            switch (command)
            {
                /// Verbo de sobreescritura de parametros sobre el flujo de disponibilidad.
                case VerbMethodEnum.B2BWalletGenerate:
                    response = new B2BWalletGenerate();
                    break;
                /// Verbo para la generación de la disponibilidad de acuerdo a los criterios especificados.
                case VerbMethodEnum.B2BWalletDetail:
                    response = new B2BWalletDetail();
                    break;
                /// Verbo encargado de mostrar alternativas de viajes en un rango de dias solicitado tanto para oneway como para roundtrip.    
                case VerbMethodEnum.B2BWalletUpdate:
                    response = new B2BWalletUpdate();
                    break;
                /// Verbo encargado de mostrar los datos especificos de una alternativa de viajes seleccionada desde la disponibilidad. 
                case VerbMethodEnum.B2BWalletDelete:
                    response = new B2BWalletDelete();
                    break;
                /// Verbo encargado de mostrar los datos especificos de una alternativa de viajes seleccionada desde la disponibilidad. 
                case VerbMethodEnum.B2BWalletList:
                    response = new B2BWalletList();
                    break;
                /// Asignación por defecto para establecer un mensaje especifico en el caso de realizarse cuna petición a un verbo sin implementar o inexistente.
                default:
                    throw new ExceptionUtility(ExceptionUtility.ErrorCodes[1]);
            }

            return response;
        }

        #endregion "Public Methods"
    }
}
