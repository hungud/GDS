namespace EntidadesGDS.Comentario
{
    public class CE_Comentario
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public int? Id { set; get; }
        public int? RPH { set; get; }
        public EnumTipoComentario? Tipo { set; get; }
        public string Codigo { set; get; }
        public string Texto { set; get; }

        #endregion
    }
}
