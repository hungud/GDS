namespace EntidadesGDS.General
{
    /// <summary>
    ///   Representa un Cliente
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_Cliente
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? IdCliente { set; get; }          // DK
        public string NombreCliente { set; get; }
        public int? IdSubCodigo { get; set; }
        public string IdComisionista { get; set; }
        public string IdTipoCliente { get; set; }
        public string IdCondicionPago { get; set; }
        public string IdPromotor { get; set; }

        #endregion
    }
}
