namespace EntidadesGDS.Robot.BoletosOADP
{
    public class RQ_InsertaCuerpoOADP
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PCC { get; set; }
        public string CodigoReserva { get; set; }
        public int? CodigoCliente { get; set; }
        public string NumeroBoleto { get; set; }
        public EnumTipoOADP? TipoOadp { get; set; }
        public int? Correlativo { get; set; }
        public string FechaEmision { get; set; }
        public string CuerpoDocumento { get; set; }

        #endregion
    }
}
