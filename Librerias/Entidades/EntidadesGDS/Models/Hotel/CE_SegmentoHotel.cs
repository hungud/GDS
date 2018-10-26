namespace EntidadesGDS.Hotel
{
    public class CE_SegmentoHotel
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string NumeroLinea { get; set; }
        public string Tipo { get; set; }
        public string Status { get; set; }
        public string IATA { get; set; }
        public string CodigoAccesoTarifa { get; set; } //RateAccessCode
        public string FechaEntrada { get; set; }
        public string FechaSalida { get; set; }
        public int DuracionEstadia { get; set; }
        public bool? EsPasado { get; set; }
        public string Texto { get; set; }
        public CE_TipoHabitacion TipoHabitacion { get; set; }
        public CE_PrecioHabitacion PrecioHabitacion { get; set; }
        public CE_PrecioTotal PrecioTotal { get; set; }
        public CE_Hotel Hotel { get; set; }
        public string CodigoConfirmacion { get; set; }

        #endregion
    }
}
