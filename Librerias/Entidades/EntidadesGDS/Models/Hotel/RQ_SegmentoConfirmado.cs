using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Hotel
{
    public class RQ_SegmentoConfirmado: RQ_SegmentoHotelBase
    {
        public string FechaEmision { get; set; }
        public string FechaReserva { get; set; }
        public int CantidadHabitaciones { get; set; }
        public decimal? ImporteGravado { get; set; }
        public decimal? ImporteNoGravado { get; set; }
        public decimal? ImporteIGV { get; set; }
        public string CodigoRazonHotel { get; set; }
        public int? DK { get; set; }
        public int? IdHotelSRV { get; set; }
        public CE_Hotel Hotel { get; set; }

    }
}
