using CoreWebLib.Base;

namespace EntidadesGDS.General
{
    public class CE_Tarjeta
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public EnumTipoDocumento? TipoDocumentoTitular { set; get; }
        public string NumeroDocumentoTitular { set; get; }
        public string NombreTitular { set; get; }
        [JsonIgnoreSerialize]
        public string Numero { set; get; }
        [JsonIgnoreSerialize]
        public string CodigoVerificacion { set; get; }
        public string PaisEmision { set; get; }
        public string NombreBanco { set; get; }
        public string FechaVencimiento { set; get; }
        [JsonIgnoreSerialize]
        public string CodigoAprobacion { set; get; }

        #endregion
    }
}
