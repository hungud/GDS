using System;
using System.Xml.Serialization;

namespace EntidadesGDS.Reglas
{
    public class CE_ReglaEmision
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        [XmlElement("ID_TRANSPORTADOR")]
        public string IdTransportador { set; get; }

        [XmlElement("PCC")]
        public string Pseudo { set; get; }

        [XmlElement("ID_GDS")]
        public string Gds { set; get; }

        public DateTime? FechaAlta { set; get; }
        public string Descripcion { set; get; }
        public string EsPropio { set; get; }

        #endregion
    }
}
