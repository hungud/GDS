namespace EntidadesGDS.Hotel
{
    /// <summary>
    /// Representa una Reserva Hotel
    /// </summary>
    public class CE_ReservaHotel
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PNR { get; set; }
        public string AgenteCreador { get; set; }
        public string FechaCreacion { get; set; }
        public string PseudoAAA { get; set; }
        public string PseudoHome { get; set; }
        public int? CustomerId { get; set; }
        public string PrefijoRemarkHotel { get; set; }
        public CE_PasajeroHotel[] Pasajeros { get; set; }
        public CE_SegmentoHotel[] SegmentosHotel { get; set; }
        public CE_Remark[] Remarks { get; set; }

        #endregion
    }
}
