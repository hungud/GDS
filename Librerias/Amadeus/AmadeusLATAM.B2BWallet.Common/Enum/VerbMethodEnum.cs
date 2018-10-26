// <copyright file="VerbMethodEnum.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Enum
{
    /// <summary>
    /// Posibles verbos de servicios a ser utilizados.
    /// 
    /// Servicio = En el caso de servicios, son los que se encuentran dispuestos por amadeus Web Services para su ejecución.
    /// Verbos   = Son los metodos de servicio dispuestos por el WCF, y cada verbo puede hacer uso de varios servicios.
    /// </summary>
    public enum VerbMethodEnum
    {
        Undefined= 0,
        B2BWalletGenerate,
        B2BWalletDetail,
        B2BWalletUpdate,
        B2BWalletDelete,
        B2BWalletList
    }
}
