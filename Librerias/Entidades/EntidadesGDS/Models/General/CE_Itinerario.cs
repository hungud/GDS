namespace EntidadesGDS.General
{
    /// <summary>
    ///   Representa un Itinerario
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_Itinerario
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public EnumTipoViaje? TipoViaje { get; set; }
        public EnumTipoVuelo? TipoVuelo { get; set; }
        public string CodeShare { get; set; }
        public EnumTipoRutaItinerario? TipoRuta { get; set; }
        public CE_Segmento[] Segmentos { get; set; }
        public string AerolineasAuxiliares { set; get; }

        #endregion
    }
}
