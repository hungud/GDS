using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.TarjetaCredito
{
    public class RQ_ActualizacionTarjetaB2B
    {
        public string PNR { get; set; }
        public string PseudoEmision { get; set; }
        public string ReferenciaExterna { get; set; }
        public string ReferenciaAmadeus { get; set; }
        public string Comentario { get; set; }
        public int IdGDS { get; set; }
        public string FechaEmision { get; set; }
        public int Status { get; set; }
        public RQ_ActualizacionTarjetaB2b_Boleto[] Boletos { get; set; }
    }
}
