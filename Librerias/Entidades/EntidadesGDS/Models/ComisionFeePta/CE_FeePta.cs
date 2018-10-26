using EntidadesGDS.Base;

namespace EntidadesGDS.ComisionFeePta
{
    public class CE_FeePta
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PseudoOficina { get; set; }
        public bool? EsPorcentaje { get; set; }
        public string Regla { get; set; }
        public decimal? FeeMinimo { get; set; }
        public decimal? FeeMaximo { get; set; }
        public bool? SePermiteVentaWeb { get; set; }
        public bool? MuestraWebAgencia { get; set; }
        public bool? PermiteRuc { get; set; }
        public bool? PermiteEmitirConTarjetaCredito { get; set; }
        public CE_Concepto[] ConceptosEvaluados { set; get; }

        #endregion
    }
}
