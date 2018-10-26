namespace EntidadesGDS.General
{
    public class CE_Pais
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdPais { get; set; }
        public string NombrePais { get; set; }

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public CE_Pais()
        {
        }

        public CE_Pais(string IdPais, string NombrePais)
        {
            this.IdPais = IdPais;
            this.NombrePais = NombrePais;
        }

        #endregion
    }
}
