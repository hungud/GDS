namespace EntidadesGDS.General
{
    /// <summary>
    ///   Representa un Pasajero
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_Pasajero
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public bool? Seleccionado { set; get; }
        public string NumeroPasajero { get; set; }
        public int? NumeroLinea { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public CE_TipoPasajero TipoPasajero { get; set; }
        public EnumTipoDocumento? TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string RUC { set; get; }
        public EnumSexo? Sexo { set; get; }
        public string FechaNacimiento { set; get; }
        public bool? NecesitaFoids { set; get; }
        public bool? NecesitaDocs { set; get; }

        #endregion
    }
}
