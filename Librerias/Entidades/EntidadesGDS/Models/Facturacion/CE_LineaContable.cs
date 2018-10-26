using EntidadesGDS.FormaPago;
using EntidadesGDS.Boleto;

namespace EntidadesGDS.Facturacion
{
    public class CE_LineaContable
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public CE_Boleto Boleto { set; get; }
        public CE_FormaPago[] Pagos { set; get; }

        #endregion
    }
}
