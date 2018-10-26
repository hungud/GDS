using EntidadesGDS.General;

namespace EntidadesGDS.FormaPago
{
    public class CE_FormaPago
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public EnumTipoFormaPago? TipoFormaPago { set; get; }
        public string Medio { set; get; }                        // Form.Value
        public string CodigoMonedaPago { set; get; }             // CurrencyCode
        public decimal? MontoPago { set; get; }                  // Amount
        public decimal? MontoNeto { get; set; }                  // Propiedad Amadeus Diario
        public decimal? MontoImpuestos { get; set; }             // Propiedad Amadeus Reporte Diario
        public CE_Tarjeta Tarjeta { set; get; }

        #endregion
    }
}
