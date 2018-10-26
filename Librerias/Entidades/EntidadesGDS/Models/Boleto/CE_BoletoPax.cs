using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesGDS.Boleto
{
    public class CE_BoletoPax
    {

        public string CodReserva { get; set; }
        public string NumeroBoleto { get; set; } 
        public int Proveedor { get; set; }
        public int IdEmpresa { get; set; }
        public int IdSucursal { get; set; }
        public string QuienAnula { get; set; }
        public string MotivoAnulacion { get; set; }
        public int NumeroFile  { get; set; }
        public string TextoFile { get; set; }
        public int  FacturarAnulacionAlCliente { get; set; }
        public int SinRefacturarPorAnulacion { get; set; }
        public string IdVendedor { get; set; }

    }
}
