﻿using System;
using System.Xml.Serialization;

namespace EntidadesGDS.ComisionFeePta
{
    public sealed class DT_TOURCODES_EVALUACION
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string ID_TRANSPORTADOR { set; get; }
        public string ID_IATA { set; get; }
        public string CODIGO_RESERVA { set; get; }
        public int? CORRELATIVO_EVALUACION { set; get; }
        public int? CODIGO_CONCEPTO { set; get; }
        public string VALOR { set; get; }
        public int? ID_CLIENTE { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_ALTA { set; get; }

        [XmlElement("FECHA_ALTA")]
        public string StringFECHA_ALTA
        {
            set { FECHA_ALTA = ((value == null) ? ((DateTime?)null) : DateTime.Parse(value)); }
            get { return ((FECHA_ALTA != null) ? FECHA_ALTA.Value.ToString("MM/dd/yyyy HH:mm:ss") : null); }
        }

        #endregion
    }
}
