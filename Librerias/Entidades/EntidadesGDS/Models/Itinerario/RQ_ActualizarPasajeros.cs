using EntidadesGDS.General;

namespace EntidadesGDS.Itinerario
{
    public class RQ_ActualizarPasajeros
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? IdCliente { set; get; }
        public string NumeroComprobante { set; get; } 
        public CE_Pasajero[] Pasajeros { set; get; }

        #endregion
    }
}
