namespace EntidadesGDS.General
{
    public class CE_ServicioEspecial
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? NumeroServicio { set; get; }
        public EnumSpecialServiceInfoType? Tipo { set; get; }
        public CE_Aerolinea Aerolinea { set; get; }
        public CE_Pasajero Pasajero { set; get; }
        public CE_Pasajero PasajeroAsociado { set; get; }
        public string Texto { set; get; }
        public bool? Eliminar { set; get; }

        #endregion
    }
}
