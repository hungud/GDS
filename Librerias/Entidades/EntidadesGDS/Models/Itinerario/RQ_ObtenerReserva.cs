namespace EntidadesGDS.Itinerario
{
    public class RQ_ObtenerReserva
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PNR { get; set; }

        // solo si se indica leer pasajeros e itinerario se leera tambien los boletos
        public bool LeerPasajeros { get; set; }
        public bool LeerItinerario { get; set; }
        public bool BuscarOperadoPor { get; set; }

        // solo si tomara en cuenta estos flags si se indico leer pasajeros
        public bool LeerServicioEspeciales { get; set; }
        public bool LeerLineasContables { get; set; }  // pagos para Amadeus
        public bool LeerCotizaciones { get; set; }

        public bool LeerComentarios { get; set; }

        // solo si tomara en cuenta este flag si se indico leer pasajeros y segmentos
        public bool LeerBoletos { set; get; }

        #endregion
    }
}
