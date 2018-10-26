using EntidadesGDS.General;
using EntidadesGDS.ComisionFeePta;

namespace EntidadesGDS.Clientes.eDestinos
{
    public sealed class CE_ProcesarBoletos
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string NumeroBoleto { set; get; }
        public CE_TipoTarifa TipoTarifa { get; set; }
        public CE_Ciudad CiudadDestino { get; set; }
        public CE_ComisionPta ComisionPta { set; get; }
        public CE_FeePta FeePta { set; get; }

        #endregion
    }
}
