using EntidadesGDS.General;

namespace EntidadesGDS.Itinerario
{
    public class RQ_ObtenerCotizaciones
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string LineaValidadora { set; get; }
        public string CodigoMoneda { set; get; }
        public bool? Reemision { set; get; }
        public CE_Segmento[] Segmentos { set; get; }
        public CE_Pasajero[] Pasajeros { set; get; }

        #endregion
    }
}
