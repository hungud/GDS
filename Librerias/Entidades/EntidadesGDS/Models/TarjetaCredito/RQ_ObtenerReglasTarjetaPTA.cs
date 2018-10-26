using EntidadesGDS.Base;

namespace EntidadesGDS.TarjetaCredito
{
    public class RQ_ObtenerReglasTarjetaPTA
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PNR { set; get; }
        public string IATA { set; get; }
        public string Transportador { set; get; }
        public string CiudadDestino { set; get; }
        public decimal? ImporteReserva { set; get; }
        public int CantidadPasajeros { set; get; }
        public CE_Concepto[] Conceptos { set; get; }

        #endregion
    }
}
