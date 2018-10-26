using EntidadesGDS.ComisionFeePta;

namespace EntidadesGDS.General
{
    public class CE_Tarifa
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? CantidadTipoPasajero { set; get; }
        public CE_TipoPasajero TipoPasajero { get; set; }
        public CE_Pasajero[] Pasajeros { get; set; }
        public decimal? Neto { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalDiferenciaReemision { get; set; }
        public CE_Impuesto[] Impuestos { get; set; }
        public CE_BaseTarifaria[] BaseTarifaria { get; set; }
        public CE_ComisionPta ComisionPta { set; get; }
        public CE_FeePta FeePta { set; get; }

        #endregion
    }
}
