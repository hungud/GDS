namespace EntidadesGDS.General
{
    public class CE_Aerolinea
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public bool? Seleccionada { set; get; }
        public string CodigoAerolinea { set; get; }
        public string[] Homologas { set; get; }
        public string[] Equivalentes { set; get; }
        public string IdPrefijo { set; get; }
        public bool? NecesitaFoid { set; get; }

        #endregion
    }
}
