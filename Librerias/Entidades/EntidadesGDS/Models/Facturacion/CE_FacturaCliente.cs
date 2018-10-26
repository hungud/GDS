namespace EntidadesGDS.Facturacion
{
    public class CE_FacturaCliente
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public EnumTipoComprobanteFacturacion? TipoComprobante { set; get; }
        public string NumeroComprobante { get; set; }
        public EnumTipoDocumentoFacturacion? TipoDocumento { get; set; }
        public string NombreRazonSocial { set; get; }
        public string NumeroDocumento { get; set; }
        public string Direccion { get; set; }

        #endregion
    }
}
