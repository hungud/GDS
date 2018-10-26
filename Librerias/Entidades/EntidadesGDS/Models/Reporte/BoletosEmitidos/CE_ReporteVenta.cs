namespace EntidadesGDS.Reporte.BoletosEmitidos
{
    public class CE_ReporteVenta
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public CE_ReporteVenta_Cabecera Cabecera { set; get; }      // CreationDetails
        public CE_ReporteVenta_Emision[] Emisiones { set; get; }    // IssuanceData 

        #endregion
    }
}
