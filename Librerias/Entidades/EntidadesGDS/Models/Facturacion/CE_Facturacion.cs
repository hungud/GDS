using EntidadesGDS.FormaPago;

namespace EntidadesGDS.Facturacion
{
    public class CE_Facturacion
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? Punto { get; set; }
        public int? IdSucursal { get; set; }
        public CE_FacturaCabecera Cabecera { set; get; }
        public CE_FacturaCliente Cliente { set; get; }
        public CE_FormaPago[] Pagos { set; get; }

        #endregion
    }
}
