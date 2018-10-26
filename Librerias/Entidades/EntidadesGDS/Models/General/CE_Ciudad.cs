namespace EntidadesGDS.General
{
    public class CE_Ciudad
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdCiudad { get; set; }
        public string CodigoCiudadSegmento { get; set; }
        public string NombreCiudad { get; set; }
        public bool? EsNacional { get; set; }
        public bool? EsAeropuerto { get; set; }
        public bool? EsEstacionTren { get; set; }
        public bool? ProhibeEmision { get; set; }
        public string CiudadEquivalente { get; set; }
        public string IdPais { get; set; }
        public string NombrePais { get; set; }
        public bool? NecesitaDocs { get; set; }
        public string IdRegion { get; set; }
        public string NombreRegion { get; set; }

        #endregion
    }
}
