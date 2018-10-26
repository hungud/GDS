
using System;

namespace KiuLib.Models
{
    public sealed class KiuHeader
    {
        // =============================
        // auto propiedades
        #region "auto propiedades"
        public string EchoToken { set; get; }
        public DateTime TimeStamp { set; get; }
        public string  Target { set; get; }
        public string  Version { set; get; }
        public string PrimaryLangID { set; get; }
        #endregion
    }
}
