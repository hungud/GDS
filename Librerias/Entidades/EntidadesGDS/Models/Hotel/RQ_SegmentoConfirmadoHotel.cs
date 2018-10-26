namespace EntidadesGDS.Hotel
{
    public class RQ_SegmentoConfirmadoHotel
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string CodigoReserva { get; set; }
        public string FechaEmision { get; set; }
        public string FechaSalida { get; set; }
        public string FechaEntrada { get; set; }
        public string FechaReserva { get; set; }
        public string Pasajero { get; set; }
        public int CantidadHabitaciones { get; set; }
        public string CodigoReservaHotel { get; set; }
        public string IdTipoHabitacion { get; set; }
        public string IdTipoTarifa { get; set; }
        public int? PagoEn { get; set; }
        public string IdMoneda { get; set; }
        public decimal? ImporteGravado { get; set; }
        public decimal? ImporteNoGravado { get; set; }
        public decimal? ImporteIGV { get; set; }
        public string CodigoRazonHotel { get; set; }
        public int? DK { get; set; }
        public int? IdHotelSRV { get; set; }
        public CE_Hotel Hotel { get; set; }

        #endregion
    }
}
