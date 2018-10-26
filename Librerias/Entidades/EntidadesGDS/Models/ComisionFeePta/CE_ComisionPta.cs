using EntidadesGDS.Base;

namespace EntidadesGDS.ComisionFeePta
{
    public class CE_ComisionPta
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? NumeroTarifario { set; get; }
        public int? NumeroComision { set; get; }
        public EnumTipoCodigoComision? TipoCodigo { set; get; }      // Tourcode o NetRemit
        public string Codigo { set; get; }                           // código de Tourcode o NetRemit
        public decimal? PorcentajeComisionKP { set; get; }
        public decimal? PorcentajeAgencia { set; get; }
        public decimal? PorcentajeFactorMeta { set; get; }
        public decimal? PorcentajeOver { set; get; }
        public decimal? PorcentajeOverNaceCancelado { set; get; }
        public bool? EsEmisionWeb { set; get; }
        public string AccountCode { set; get; }
        public decimal? AdicionarOver { set; get; }
        public decimal? PorcentajeFfactorMetaYQ { set; get; }
        public CE_Concepto[] ConceptosEvaluados { set; get; }
        public CE_ComisionPtaAdicional ComisionPtaAdicional { set; get; }

        #endregion
    }
}
