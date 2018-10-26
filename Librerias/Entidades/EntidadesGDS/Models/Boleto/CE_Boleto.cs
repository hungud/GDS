using EntidadesGDS.General;
using EntidadesGDS.Facturacion;
using EntidadesGDS.FormaPago;

namespace EntidadesGDS.Boleto
{
    public class CE_Boleto
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public bool? Seleccionado { set; get; }
        public string Pseudo { set; get; }
        public string Iata { set; get; }
        public int? IdSucursal { set; get; }
        public int? IdPunto { set; get; }
        public int? IdProveedor { set; get; }
        public int? IdCotizacion { set; get; }
        public int? IdFile { set; get; }
        public string IdFileReferencia { set; get; }
        public bool? Sistema { set; get; }                   // para SYS
        public CE_Agente Agente { set; get; }
        public CE_Aerolinea Aerolinea { set; get; }
        public string NumeroBoleto { set; get; }
        public CE_Segmento[] Segmentos { set; get; }
        public CE_Pasajero Pasajero { set; get; }
        public CE_Impuesto[] Impuestos { set; get; }
        public decimal? Comision { set; get; }
        public int? EnConjuncion { set; get; }               // ConjunctiveCountfrancis1983
        public string NumeroBoletoEnConjuncion { set; get; } // Numero de Boleto en Conjuncion
        public int? CuponesUsados { set; get; }              // UsedCount
        public bool? Electronico { set; get; }
        public bool? Reemision { set; get; }
        public string Tipo { set; get; }                     // se asigna el tipo literal devuelto por GDS
        public string Estatus { set; get; }                  // Ind
        public string FechaEmision { set; get; }             // IssueTime
        public string HoraEmision { set; get; }              // IssueTime
        public CE_Cotizacion Cotizacion { set; get; }
        public CE_FacturaCliente Cliente { set; get; }
        public int NumeroLinea { set; get; }
        public int? IdEmpresa { get; set; }
        public CE_FormaPago[] Pagos { set; get; }

        #endregion
    }
}
