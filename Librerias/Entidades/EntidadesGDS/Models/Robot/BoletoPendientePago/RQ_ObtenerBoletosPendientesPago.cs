namespace EntidadesGDS.Robot.BoletoPendientePago
{
    public class RQ_ObtenerBoletosPendientesPago
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string TipoClienteAgencia { set; get; }
        public string CondicionPagoCliente { set; get; }
        public int TipoClientePasajero { set; get; }
        public int IdClientePasajero { set; get; }
        public int IdEmpresaSucursal { set; get; }
        public int MarcaEsConsolidador { set; get; }
        public string ListaGds { set; get; }

        /* código(s) de la institución BSP que proporciona el correlativo de los boletos */
        public string ListaProveedoresBoletos { set; get; }

        public string Fecha { set; get; }
        public string AntesDeHora { set; get; }

        #endregion
    }
}
