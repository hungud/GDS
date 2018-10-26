using EntidadesGDS.General;

namespace EntidadesGDS.Incidencia
{
    public class CE_BitacoraCC
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? Dk { get; set; }
        public string PNR { get; set; }
        public int? IdCategoriaBoleto { get; set; }
        public string Solicitante { get; set; }
        public string Aprobador { get; set; }
        public string CentroCosto { get; set; }
        public string OrdenServicio { get; set; }
        public string OcurTema { get; set; }
        public string MotivoViaje { get; set; }
        public string UsuarioWebLogin { get; set; }
        public string CorreoAgente { get; set; }
        public string NombreAgente { get; set; }
        public string OcurDescripcion { get; set; }
        public string IdVendedor { get; set; }
        public CE_UsuarioWeb UsuarioWeb {get; set;}
        public CE_Cliente Cliente { get; set; }

        #endregion
    }
}
