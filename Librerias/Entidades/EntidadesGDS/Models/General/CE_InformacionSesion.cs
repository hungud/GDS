namespace EntidadesGDS.Models.General
{
    public class CE_InformacionSesion
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string IdSesion { get; set; }
        public string PseudoActual { get; set; }
        public string PseudoOrigen { get; set; }
        public string IdVendedor { get; set; }
        public string FirmaAgente { get; set; }
        public int IdAplicacion { get; set; }
        public string TokenGDS { get; set; }
        public string TokenJWT { get; set; }
        public string CodigoReserva { get; set; }
        public string FechaCreacion { get; set; }
        public object Extras { get; set; }
        public string RutaDestino { get; set; }

        #endregion
    }
}
