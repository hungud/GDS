namespace EntidadesGDS.General
{
    public class CE_Cotizacion
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? NumeroPQ { set; get; }
        public bool? Seleccionada { set; get; }
        public CE_Aerolinea[] LineasValidadoras { set; get; }
        public CE_TipoTarifa TipoTarifa { get; set; }
        public string UltimoDiaDeCompra { get; set; }
        public decimal? TotalCotizacion { get; set; }
        public CE_Ciudad CiudadDestino { get; set; }
        public string Pseudo { get; set; }
        public string Iata { get; set; }
        public string IdEmpresa { get; set; }
        public string AccountCode { get; set; }
        public CE_Tarifa[] Tarifas { get; set; }
        public EnumRepuestaSimple? IncluyeYQ { get; set; }
        public string TipoStock { set; get; }
        public bool? Reemision { set; get; }

        #endregion
    }
}
