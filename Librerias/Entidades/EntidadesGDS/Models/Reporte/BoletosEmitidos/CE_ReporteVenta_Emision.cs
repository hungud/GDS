using EntidadesGDS.FormaPago;
using EntidadesGDS.Boleto;

namespace EntidadesGDS.Reporte.BoletosEmitidos
{
    public class CE_ReporteVenta_Emision
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string TipoDocumento { set; get; }              // DocumentType
        public EnumTipoRutaItinerario TipoRuta { set; get; }   // DomesticInternational
        public string InformacionAdicional1 { set; get; }      // IndicatorOne
        public string InformacionAdicional2 { set; get; }      // IndicatorTwo
        public string PNR { set; get; }                        // ItineraryRef
        public CE_FormaPago[] Pagos { set; get; }              // Payments
        public string NombrePasajero { set; get; }             // PersonName
        public CE_Boleto Boleto { set; get; }                  // TicketingInfo

        #endregion
    }
}
