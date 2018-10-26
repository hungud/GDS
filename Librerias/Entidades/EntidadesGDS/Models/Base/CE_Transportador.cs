namespace EntidadesGDS.Base
{
    public class CE_Transportador
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdTransportador { set; get; }
        public string NombreTransportador { set; get; }
        public string Homologa { set; get; }
        public string Equivalente { set; get; }
        public string Cambio { set; get; }
        public bool? NecesitaFoid { set; get; }

        #endregion
    }
}
