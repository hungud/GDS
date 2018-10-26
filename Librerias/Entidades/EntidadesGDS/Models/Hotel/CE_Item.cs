namespace EntidadesGDS.Models.Hotel
{
    public class CE_Item
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string Clave { get; set; }
        public string Valor { get; set; }

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public CE_Item()
        {
        }

        public CE_Item(string Clave, string Valor)
        {
            this.Clave = Clave;
            this.Valor = Valor;
        }

        #endregion
    }
}
