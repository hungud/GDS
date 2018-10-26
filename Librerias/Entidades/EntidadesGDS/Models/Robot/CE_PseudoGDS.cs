using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Models.Robot
{
    public class CE_PseudoGDS
    {

        public string IdPseudo { get; set; }
        public string Descripcion { get; set; }
        public int IdGDS { get; set; }
        public bool NoRelease { get; set; }
        public bool PccNoNM { get; set; }
        public string FechaAlta { get; set; }
        public string Grupo { get; set; }
        public string IdCliente { get; set; }
        public bool PermiteOpcionesEspeciales { get; set; }


    }
}
