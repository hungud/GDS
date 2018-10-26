namespace EntidadesGDS.Base
{
    public sealed class CE_Session
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string ConversationId { set; get; } //SessionId - Amadeus
        public string Token { set; get; } //Security Token - Amadeus
        public string SignatureUser { set; get; }
        public string Pseudo { set; get; }
        public int SequenceNumber { get; set; } // Secuencia - Amadeus
        public EnumTransactionType AmadeusTransactionType { get; set; }

        public EnumEnvironment Environment { get; set; }
        #endregion
    }
}
