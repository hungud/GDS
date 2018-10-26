namespace EntidadesGDS.TarjetaCredito
{
    public class CE_EmisionB2B
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PNR { get; set; }
        public string NumeroBoleto { get; set; }
        public string FechaEmision { get; set; }
        public string ReferenciaAmadeus { get; set; }
        public string ReferenciaExterna { get; set; }
        public string Comentario { get; set; }
        public string IdGDS { get; set; }
        public string CodigoLineaAerea { get; set; }
        public string NumeroTarjeta { get; set; }
        public int Status { get; set; }
        public int IntentosDeEliminacion { get; set; }
        public string PseudoEmision { get; set; }
        public decimal MontoTotalBoleto { get; set; }
        public string Iata { get; set; }
        public int Anulado { get; set; }
        public int? IdTarjetaCreditoPTA { set; get; }
        public int? IdRegla { set; get; }
        public int? SecuenciaID { get; set; }
        
        #endregion
    }
}
