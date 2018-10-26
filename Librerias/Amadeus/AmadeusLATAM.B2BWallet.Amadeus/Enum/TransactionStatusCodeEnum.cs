// <copyright file="TransactionStatusCodeEnum.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Amadeus.Enum
{
    /// <summary>
    /// Enumeración que permite el manejo de estados individuales para los llamados de servicio en el manejo de la seión con Soap Header.
    /// </summary>
    public enum TransactionStatusCodeEnum
    {
        Stateless = 0,
        Start,
        InSeries,
        End
    }
}
