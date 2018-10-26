using System.Linq;

using EntidadesGDS.Comentario;
using EntidadesGDS.Boleto;
using EntidadesGDS.Facturacion;

namespace EntidadesGDS.General
{
    /// <summary>
    ///   Representa un PNR
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_Reserva
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string PNR { get; set; }
        public CE_ReservaReferencia Referencia { set; get; }
        public CE_Cliente Cliente { get; set; }
        public CE_Usuario Usuario { get; set; }
        public CE_Aplicacion Aplicacion { get; set; }
        public CE_Pasajero[] Pasajeros { get; set; }
        public CE_Itinerario Itinerario { get; set; }
        public CE_Cotizacion[] Cotizaciones { get; set; }

        // forma de pago utilizada para la cotización (ejemplo caso: KIU)
        public EnumTipoFormaPagoComision? TipoFormaPagoComision { get; set; }

        public string EmisionClero { get; set; }
        public bool? EsReemision { get; set; }
        public bool? EmitirEMDPorCambioTarifa { get; set; }
        public bool? EmiteConRUC { get; set; }
        public CE_Facturacion Facturacion { set; get; }
        public CE_LineaContable[] LineasContables { set; get; }
        public CE_Comentario[] Comentarios { set; get; }
        public CE_ServicioEspecial[] ServiciosEspeciales { set; get; }
        public CE_Boleto[] Boletos { set; get; }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        public void RegistrarCoitzacion(CE_Cotizacion cotizacion)
        {
            if (cotizacion != null)
            {
                // inicializando los mensajes
                Cotizaciones = (Cotizaciones ?? new CE_Cotizacion[0]);

                // actualizando cotizaciones
                Cotizaciones = Cotizaciones.Union(new [] { cotizacion }).ToArray();
            }
        }

        #endregion
    }
}
