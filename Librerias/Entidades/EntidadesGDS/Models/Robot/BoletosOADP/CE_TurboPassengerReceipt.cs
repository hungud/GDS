namespace EntidadesGDS.Robot
{
    public class CE_TurboPassengerReceipt
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"
        public string Esquema { get; set; }
        public string TicketNumber { get; set; }
        public string PnrCode { get; set; }
        public int DkNumber { get; set; }
        public string RucNumber { get; set; }
        public string Pcc { get; set; }
        public string CounterTA { get; set; }
        public string CuerpoDocumento { get; set; }
        public string PasajeroNombre { get; set; }
        public string PasajeroApellido { get; set; }
        public EnumHeaderPassengerReceipt IdHeader { get; set; }
        public string CounterEmail { get; set; }
        public string FreqTravel { get; set; }
        public string Ruta { get; set; }

        #endregion
    }
}
