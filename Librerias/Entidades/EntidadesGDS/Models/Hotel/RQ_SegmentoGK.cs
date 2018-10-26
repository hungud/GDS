using EntidadesGDS.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Hotel
{
    public class RQ_SegmentoGK: RQ_SegmentoHotelBase
    {
        
        public CE_Ciudad Ciudad { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal MontoImpuestos { get; set; }
        public decimal MontoImpuestosAdicionales { get; set; }
        public decimal MontoFEE { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoCheckIn { get; set; }
        public decimal MontoCheckOut { get; set; }

    }
}
