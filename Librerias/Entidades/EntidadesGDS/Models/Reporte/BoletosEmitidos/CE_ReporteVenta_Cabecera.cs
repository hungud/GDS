using System;

namespace EntidadesGDS.Reporte.BoletosEmitidos
{
    public class CE_ReporteVenta_Cabecera
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string Pseudo { set; get; }            // PseudoCityCode
        public string NombreAgencia { set; get; }     // AgencyName
        public DateTime? FechaCreacion { set; get; }  // CreateDateTime

        #endregion
    }
}
