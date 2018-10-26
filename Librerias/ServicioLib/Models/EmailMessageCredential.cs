namespace ServicioLib.Models
{
    internal sealed class EmailMessageCredential
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string Server { set; get; }
        public int? Port { set; get; }
        public string User { set; get; }
        public string Password { set; get; }
        public string[] BCC { set; get; }
        public string From { get; set; }

        #endregion
    }
}
