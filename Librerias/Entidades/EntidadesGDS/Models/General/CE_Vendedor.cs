namespace EntidadesGDS.General
{
    public class CE_Vendedor
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"
        public string Firma { get; set; }
        public string IdVendedor { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string CorreoJefe { get; set; }        
        public string UsuarioSistema { get; set; }
        public string IdDepartamento { get; set; }
        public CE_Departamento Departamento { get; set; }

        #endregion
    }
}
