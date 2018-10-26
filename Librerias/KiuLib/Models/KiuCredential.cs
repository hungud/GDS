using System;

namespace KiuLib.Models
{
    public sealed class KiuCredential
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"
        public string PseudoCity { set; get; }
        public string Country { set; get; }
        public string Currency { set; get; }
        public string Agent { set; get; }
        public string Terminal { set; get; }
        #endregion
    }
}
