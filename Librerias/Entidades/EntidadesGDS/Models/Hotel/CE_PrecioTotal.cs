namespace EntidadesGDS.Hotel
{
    public class CE_PrecioTotal
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public CE_ImpuestoTotal Impuesto { get; set; }
        public decimal MontoTotalAproximado { get; set; }
        public string  Moneda { get; set; }
        public CE_Descargos[] Descargos { get; set; }

        #endregion
    }
}
