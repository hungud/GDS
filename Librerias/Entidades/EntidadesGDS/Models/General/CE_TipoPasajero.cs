namespace EntidadesGDS.General
{
    /// <summary>
    ///   Representa un Tipo de Pasajero
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_TipoPasajero
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdTipoPasajero { get; set; }
        public string Equivale { get; set; }
        public string Pertenece { get; set; }
        public string PerteneceAmadeus { get; set; }
        public bool? RequiereAsiento { get; set; }

        #endregion
    }
}
