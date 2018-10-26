using System;

namespace EntidadesGDS.General
{
    public class CE_ReservaReferencia
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PseudoCreacion { get; set; }
        public string IdAgente { get; set; }
        public string FechaCreacion { get; set; }
        public string HoraCreacion { get; set; }
        public DateTime? FechaHoraCreacion { set; get; }

        #endregion
    }
}
