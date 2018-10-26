using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Models.Itinerario
{
    public class RQ_PnrCancel
    {
        public string PNR { get; set; }
        public bool CancelarTodoItinerario { get; set; }
        public string[] NumeroLineasACancelar { get; set; }
        public bool EjecutarEndTransaction { get; set; }
        public bool CerrarSesion { get; set; }
    }
}
