using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.TarjetaCredito
{
    public class CE_SessionB2BWallet
    {
        public string Token { get; set; }
        public string NewToken { get; set; }
        public string ConversationID { get; set; }
        public string Aplicacion { get; set; }
        public string Usuario { get; set; }
        public int Estado { get; set; }
        public int Destino { get; set; }

    }
}
