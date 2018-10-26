namespace EntidadesGDS.TarjetaCredito
{
    public class CE_EvaluacionTarjetaPTA
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string CodigoTarjeta { set; get; }       // VendorCode (B2B2Wallet)
        public string MesAnioExpiracion { set; get; }   // Validity (B2B2Wallet)
        public int? IdTarjetaCreditoPTA { set; get; }   
        public int? IdRegla { set; get; }
        public string NumeroTarjeta { set; get; }       // PrimaryAccountNumber (B2B2Wallet)
        public string ReferenciaExterna { set; get; }   // Reference Type="External" (B2B2Wallet)
        public string ReferenciaAmadeus { set; get; }   // Reference Type="Amadeus" (B2B2Wallet
        public string NombreBanco { get; set; }
        public string IdPaisTarjeta { get; set; }
        public string NombrePaisTarjeta { get; set; }
        public string NombreTitular { get; set; }
        public string NumeroDocumentoTitular { get; set; }
        public string TipoDocumentoTitular { get; set; }
        public int? SecuenciaID { get; set; }

        #endregion
    }
}
