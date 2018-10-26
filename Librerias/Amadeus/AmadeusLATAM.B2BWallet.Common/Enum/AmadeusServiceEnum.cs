// <copyright file="AmadeusServiceEnum.cs" company="Amadeus IT Group Colombia">   
// Copyright (c) 2018 All Right Reserved   
// </copyright>   
// <author>Amadeus - Diego Buitrago</author> 

namespace AmadeusLATAM.B2BWallet.Common.Enum
{
    using AmadeusLATAM.B2BWallet.Common.Model;

    /// <summary>
    /// Enumeración de los servicios disponibles para ser utilizados.
    /// </summary>
    public enum AmadeusServiceEnum
    {
        [SoapActionModel()] Undefined = 0,
        [SoapActionModel(Name = "PAY_GenerateVirtualCard", Version = "2.0", ActionRQ = "PAY_GenerateVirtualCard_2.0", ActionRS = "PAY_GenerateVirtualCard_2.0", XSLTemplateRQ = "PAY_GenerateVirtualCard_RQ.xslt", XSLTemplateRS = "PAY_GenerateVirtualCard_RS.xslt")] PAY_GenerateVirtualCard_2_0,
        [SoapActionModel(Name = "PAY_GetVirtualCardDetails", Version = "2.0", ActionRQ = "PAY_GetVirtualCardDetails_2.0", ActionRS = "PAY_GetVirtualCardDetails_2.0", XSLTemplateRQ = "PAY_GetVirtualCardDetails_RQ.xslt", XSLTemplateRS = "PAY_GetVirtualCardDetails_RS.xslt")] PAY_GetVirtualCardDetails_2_0,
        [SoapActionModel(Name = "PAY_UpdateVirtualCard", Version = "2.0", ActionRQ = "PAY_UpdateVirtualCard_2.0", ActionRS = "PAY_UpdateVirtualCard_2.0", XSLTemplateRQ = "PAY_UpdateVirtualCard_RQ.xslt", XSLTemplateRS = "PAY_UpdateVirtualCard_RS.xslt")] PAY_UpdateVirtualCard_2_0,
        [SoapActionModel(Name = "PAY_DeleteVirtualCard", Version = "2.0", ActionRQ = "PAY_DeleteVirtualCard_2.0", ActionRS = "PAY_DeleteVirtualCard_2.0", XSLTemplateRQ = "PAY_DeleteVirtualCard_RQ.xslt", XSLTemplateRS = "PAY_DeleteVirtualCard_RS.xslt")] PAY_DeleteVirtualCard_2_0,
        [SoapActionModel(Name = "PAY_ListVirtualCards", Version = "2.0", ActionRQ = "PAY_ListVirtualCards_2.0", ActionRS = "PAY_ListVirtualCards_2.0", XSLTemplateRQ = "PAY_ListVirtualCards_RQ.xslt", XSLTemplateRS = "PAY_ListVirtualCards_RS.xslt")] PAY_ListVirtualCards_2_0,
        [SoapActionModel(Name = "PAY_ScheduleVirtualCardLoad", Version = "2.0", ActionRQ = "PAY_ScheduleVirtualCardLoad_2.0", ActionRS = "PAY_ScheduleVirtualCardLoad_2.0", XSLTemplateRQ = "", XSLTemplateRS = "")] PAY_ScheduleVirtualCardLoad_2_0,
        [SoapActionModel(Name = "PAY_CancelVirtualCardLoad", Version = "2.0", ActionRQ = "PAY_CancelVirtualCardLoad_2.0", ActionRS = "PAY_CancelVirtualCardLoad_2.0", XSLTemplateRQ = "", XSLTemplateRS = "")] PAY_CancelVirtualCardLoad_2_0,
    }
}
