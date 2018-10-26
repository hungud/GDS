namespace EntidadesGDS.Base
{
    public class CE_Concepto
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdConcepto { set; get; } 
        public string Concepto { set; get; } 
        public string IdTipoConcepto { set; get; } 
        public string TipoConcepto { set; get; }
        public bool? EntreComillas { set; get; }
        public string Valor { set; get; } 

        #endregion
    }
}
