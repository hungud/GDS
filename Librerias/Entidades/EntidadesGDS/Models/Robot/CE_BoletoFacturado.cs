namespace EntidadesGDS.Robot
{
    public class CE_BoletoFacturado
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdPromotor { set; get; }
        public string NombrePromotor { set; get; }
        public string CorreoPromotor { set; get; }
        public bool? Anulada { set; get; }
        public string IdSucursal { set; get; }
        public string DescripcionSucursal { set; get; }
        public string Punto { set; get; }
        public string CorreoCaja { set; get; }
        public string IdCliente { set; get; }
        public string Iata { get; set; }
        public string Esquema { get; set; }
        public string NombreCliente { set; get; }
        public string IdCondicionPago { set; get; }
        public string CorreoCliente { set; get; }
        public string IdFile { set; get; }
        public string IdCotizacion { get; set; }
        public string IdTipoStock { set; get; }
        public string IdProveedor { get; set; }
        public string PNR { set; get; }
        public string NumeroBoleto { set; get; }
        public string Ruta { set; get; }
        public bool? Facturado { set; get; }
        public string IdPrefijo { set; get; }
        public string IdTipoComprobante { set; get; }
        public string NumeroSerie1 { set; get; }
        public string IdFacturaCabeza { set; get; }
        public string NoAnular { set; get; }
        public string FechaAlta { set; get; }
        public string ACobrar { set; get; }
        public string Aplicado { set; get; }
        public string Pendiente { set; get; }
        public string NombrePasajero { set; get; }
        public bool? Voideado { set; get; }
        public string IdVendedor { set; get; }
        public string NombreVendedor { set; get; }
        public string CorreoVendedor { set; get; }
        public string IdGds { set; get; }
        public string DescripcionGds { set; get; }
        public string EsTarjetaCreditoPTA { get; set; }
        public string PseudoEmite { get; set; }
        public bool? EsEmpresaGrupo { get; set; }
        public string TipoDeCliente { get; set; }
        public string MontoPagaOtroDK { get; set; }

        public int?  IdEmpresa { get; set; }

        #endregion
    }
}
