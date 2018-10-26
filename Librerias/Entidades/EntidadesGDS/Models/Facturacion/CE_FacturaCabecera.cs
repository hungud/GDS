namespace EntidadesGDS.Facturacion
{
    public class CE_FacturaCabecera
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        // el documento que nuevo mundo genera
        public EnumTipoComprobanteFacturacion? TipoComprobante { set; get; }
        public string NumeroSerie { get; set; }
        public string IdFacturaCabecera { get; set; }

        #endregion
    }
}
