// <copyright file="PAY_UpdateVirtualCardService.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Core.B2BWalletService
{
    using AmadeusLATAM.B2BWallet.Amadeus.Model;
    using System.Collections.Generic;
    using System.Linq;

    /// Clase concreta que integra la funcionalidad de actualización de tarjetas de credito virtuales y la cual implementa de la factoria BaseService.
    public class PAY_UpdateVirtualCardService: BaseService
    {
        #region "Public Methods"

        /// <summary>
        /// Metodo utilizado para implementar el contructor sobre la clase base, para asi ser una clase concreta basada en la factoria o clase BaseService.
        /// </summary>
        /// <param name="session">Entidad que tiene los datos necesarios para realizar la petición  Amadeus, y adicional esta por referencia por lo que se completara con los datos de respuesta.</param>
        public PAY_UpdateVirtualCardService(SessionWSModel session) : base(session) { }

        /// <summary>
        /// Metodo que sobreescribe del metodo "Execute" de la factoria "BaseService."
        /// </summary>
        /// <param name="sessionWS">Entidad que tiene los datos necesarios para realizar la petición  Amadeus, y adicional esta por referencia por lo que se completara con los datos de respuesta.</param>
        public override void Execute(ref SessionWSModel sessionWS)
        {
            base.Connect1AService(ref sessionWS);

            List<string> listErrors = base.ValidateErrors(sessionWS.XmlResponse);

            if (listErrors == null || listErrors.Count() == 0)
            {
                sessionWS.XmlResponse = base.EncryptData(sessionWS);
            }
            else
            {
                sessionWS.ListErrors = listErrors;
                sessionWS.Successful = false;
            }
        }

        #endregion "Public Methods"
    }
}
