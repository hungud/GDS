using EntidadesGDS.Models.Hotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Hotel
{
    public class RQ_SegmentoHotelBase
    {
        public List<CE_PasajeroHotel> Pasajeros { get; set; }
        public CE_Item TipoHabitacion { get; set; }
        public CE_HotelPTA Hotel { get; set; }
        public string CodigoReserva { get; set; }
        public string CodigoReservaHotel { get; set; }
        public string TipoTarifa { get; set; }
        public string FechaInicioReserva { get; set; }
        public string FechaFinReserva { get; set; }
        public string PagoEn { get; set; }
        public string Moneda { get; set; }
        public string Observacion { get; set; }
        public string EmailCounter { get; set; }
    }
}
