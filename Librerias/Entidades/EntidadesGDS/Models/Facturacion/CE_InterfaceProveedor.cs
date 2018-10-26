namespace EntidadesGDS.Facturacion
{
    public class CE_InterfaceProveedor
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PseudoConsulta { set; get; }
        public string EsquemaConsulta { set; get; }
        public int? ProveedorConsulta { set; get; }
        public int? ReferenciaConsulta { set; get; }
        public string PseudoEmision { set; get; }
        public string EsquemaEmision { set; get; }
        public int? ProveedorEmision { set; get; }
        public int? ReferenciaEmision { set; get; }
        public bool? DobleInterface { set; get; }

        #endregion
    }
}
