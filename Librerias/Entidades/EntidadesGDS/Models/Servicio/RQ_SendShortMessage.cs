namespace EntidadesGDS.Servicio
{
    public class RQ_SendShortMessage
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string Acronym { set; get; }
        public string SenderTitle { set; get; }
        public string Content { set; get; }
        public string[] Recipients { set; get; }

        #endregion
    }
}
