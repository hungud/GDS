namespace EntidadesGDS.General
{
    // =============================
    // clases

    #region "clases"

    /// <summary>
    ///   Representa una Aplicación
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_Aplicacion
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public EnumTipoGds? TipoGds { get; set; }
        public EnumAplicaciones? TipoAplicacion { set; get; }
        public string CodigoMoneda { get; set; }
        public string PseudoConsulta { get; set; }
        public string PseudoEmision { get; set; }
        public string IataConsulta { get; set; }
        public string IdGrupo { get; set; }
        public string IdGrupoAuxiliar { get; set; }

        #endregion
    }

    #endregion
}
