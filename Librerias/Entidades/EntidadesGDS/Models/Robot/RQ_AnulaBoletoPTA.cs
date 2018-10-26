using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Models.Robot
{
    public class RQ_AnulaBoletoPTA
    {
        public string PNR { get; set; }
        public string NumeroBoleto { get; set; }
        public string IdVendedorAnula { get; set; }
        public string IdMotivoAnulacion { get; set; }
        public string AutorizaNoCobroVOID { get; set; }
        public int FacturarVoidACliente { get; set; }
        public int ConReposicion { get; set; }

    }
}
