namespace EntidadesGDS.General
{
    public class CE_Impuesto
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string CodigoImpuesto { set; get; }
        public string Descripcion { set; get; }
        public decimal? Importe { set; get; }
        public bool? Porcentaje { set; get; }
        public string CodigoMonedaPago { set; get; }

        #endregion
    }
}
