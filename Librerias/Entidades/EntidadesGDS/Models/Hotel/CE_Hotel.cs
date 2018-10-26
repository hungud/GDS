namespace EntidadesGDS.Hotel
{
    public class CE_Hotel
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string CodigoCadenaHotelera { get; set; }
        public string CodigoHotel { get; set; }
        public string NombreHotel { get; set; }
        public string CodigoCiudadHotel { get; set; }
        public CE_Direccion Direccion { get; set; }
        public CE_Contacto Contacto { get; set; }

        #endregion
    }
}
