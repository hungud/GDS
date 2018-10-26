using EntidadesGDS.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Boleto
{
    public class RQ_AnulacionBoleto
    {
        public CE_Reserva Reserva { get; set; }
        public bool CancelarItinerario { get; set; }
    }
}
