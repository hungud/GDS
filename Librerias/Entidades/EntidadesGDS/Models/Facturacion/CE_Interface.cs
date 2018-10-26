namespace EntidadesGDS.Facturacion
{
    public class CE_Interface
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public CE_InterfaceGeneral Cabecera { set; get; }
        public CE_InterfaceDetalle[] Detalle { set; get; }

        #endregion
    }
}
