using System;

namespace EntidadesGDS.Queue
{
    public class CE_QueueReserva
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"
        public int? Number { get; set; }
        public string Group { get; set; }
        public string UniqueID { get; set; }
        public string AgentSine { get; set; }
        public string PseudoCityCode { get; set; }
        public DateTime? DateTime { get; set; }

        #endregion
    }
}
