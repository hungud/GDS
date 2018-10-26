using CoreWebLib.Base;
namespace EntidadesGDS.Servicio
{
    public class RQ_SendEmailMessage
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string Acronym { set; get; }
        public string Subject { set; get; }
        public string Content { set; get; }
        public string From { set; get; }
        public string[] To { set; get; }
        public string[] CC { set; get; }
        public string[] BCC { set; get; }

        [JsonIgnoreSerialize]
        public byte[] Attachment { get; set; }

        public string ReplyTo { get; set; }

        [JsonIgnoreSerialize]
        public RQ_SendEmailMessageAttachment[] Attachments { get; set; }

        #endregion
    }

    public class RQ_SendEmailMessageAttachment
    {
        public string FileName { get; set; }
        public byte[] FileBytes { get; set; }

    }
}
