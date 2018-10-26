using System;
using System.Xml.Serialization;

namespace EntidadesGDS.Facturacion
{
    public class CE_InterfaceDetalle
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string ID_REFERENCIA { set; get; }
        public long? ID_SECUENCIA { set; get; }
        public int? ID_PAX { set; get; }
        public long? NUMERO_DE_BOLETO { set; get; }
        public int? ID_PROVEEDOR_GDS { set; get; }
        public string TIPO_DESCUENTO { set; get; }
        public string DESCUENTO { set; get; }
        public int? CON_ASISTENCIA { set; get; }
        public string NUMERO_DE_VUELO { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_ASISTENCIA { set; get; }

        [XmlElement("FECHA_ASISTENCIA")]
        public string StringFECHA_ASISTENCIA
        {
            set { FECHA_ASISTENCIA = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_ASISTENCIA == null) ? null : FECHA_ASISTENCIA.Value.ToString("MM/dd/yyyy HH:mm:ss")); }
        }

        public string COD_RESERVA_LAEREA  { set; get; }
        public string TIPO_ASISTENCIA  { set; get; }
        public string ASIENTO { set; get; }
        public string TELEFONO_ASISTENCIA { set; get; }
        public string OBSERVACION_ASISTENCIA { set; get; }
        public int? CON_GASTO_EMISION { set; get; }

        // ERROR CON TODOS LOS DECIMALES AL PASAR A ORACLER EN EL XML
        //public decimal? TARIFA_AUXILIAR { set; get; }
        public string TARIFA_AUXILIAR { set; get; }

        public int? SIN_FACTURAR { set; get; }
        public int? EN_PNR { set; get; }
        public int? ID_COTIZACION_PAX { set; get; }
        public int? ID_GRUPO_AEREO { set; get; }
        public string INCENTIVO_INTERAGENCIAS { set; get; }
        public string MISIONERO { set; get; }
        public int? ES_CONEXION { set; get; }
        public string FEE_APNK { set; get; }
        public string FEE_TJT { set; get; }
        public string MILLAS_EN_USD { set; get; }
        public string QUIEN_AUTORIZA_DSCTO_AD { set; get; }
        public int? ID_SECUENCIA_INFANTE { set; get; }
        public string NUMERO_MCO { set; get; }
        public string TARIFA_MCO { set; get; }
        public string IGV_MCO { set; get; }
        public string TAX_MCO { set; get; }
        public int? MCO_EN_FC { set; get; }
        public int? ES_IT { set; get; }
        public int? CON_MOROSIDAD { set; get; }
        public int? ES_WAIVER { set; get; }
        public string NUMERO_DOCUMENTO { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_DE_ALTA { set; get; }

        [XmlElement("FECHA_DE_ALTA")]
        public string StringFECHA_DE_ALTA
        {
            set { FECHA_DE_ALTA = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_DE_ALTA == null) ? null : FECHA_DE_ALTA.Value.ToString("MM/dd/yyyy HH:mm:ss")); }
        }

        public int? ES_INFANTE_ADULTO { set; get; }
        public int? ES_TOURCODE_AUTOMATICO { set; get; }
        public string IMPORTE_FEE { set; get; }
        public string IMPORTE_WAIVER { set; get; }
        public string ID_TIPO_DOCUMENTO_IDENTIDAD { set; get; }
        public string NUM_DOCUMENTO_IDENTIDAD { set; get; }
        public string PORC_OVER_LINEA_AEREA { set; get; }
        public string FACTOR_META { set; get; }
        public int? NUMERO_TARIFARIO { set; get; }
        public int? NUMERO_REGULACION { set; get; }
        public int? OVER_NACE_CANCELADO { set; get; }
        public string TIPO_COMISION_GDS { set; get; }
        public string COMISION_GDS { set; get; }
        public string IMPORTE_SIN_FACTURAR { set; get; }
        public string TARIFA_PUBLICADA_ORIGINAL { set; get; }
        public int? ID_GRUPO { set; get; }
        public int? REEMISION_AUTOMATICA { set; get; }
        public string DEPARTAMENTO_CTA { set; get; }
        public string ID_DE_EMPLEADO_CTA { set; get; }
        public string TARIFA_MAS_ECONOMICA { set; get; }
        public string ID_GRUPO_SERVICIO { set; get; }
        public int? ID_PROVEEDOR { set; get; }
        public string DESCRIPCION { set; get; }
        public string ID_MONEDA { set; get; }
        public string PRECIO_DE_VENTA { set; get; }
        public string NO_IMPONIBLE { set; get; }
        public string PRECIO_NETO_DE_COSTO { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_IN { set; get; }

        [XmlElement("FECHA_IN")]
        public string StringFECHA_IN
        {
            set { FECHA_IN = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_IN == null) ? null : FECHA_IN.Value.ToString("MM/dd/yyyy HH:mm:ss")); }
        }

        [XmlIgnore]
        public DateTime? FECHA_OUT { set; get; }

        [XmlElement("FECHA_OUT")]
        public string StringFECHA_OUT
        {
            set { FECHA_OUT = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_OUT == null) ? null : FECHA_OUT.Value.ToString("MM/dd/yyyy HH:mm:ss")); }
        }

        public string IGV { set; get; }
        public string TIPO_DE_WAIVER { set; get; }
        public string SEGMENTO_REUTILIZABLE { set; get; }
        public string ID_MOTIVO_SIN_ASIENTO { set; get; }
        public string TARIFA_ADICIONAL { set; get; }
        public int? REFERENCIA_PROCESAR { set; get; }
        public string APROBADOR_CTA { set; get; }
        public string TIPO_DE_VIAJE { set; get; }
        public string SEGMENTO_REEMBOLSABLE { set; get; }
        public string CODIGO_CUPON_SIT { set; get; }
        public string NRO_ENGAGEMENT { set; get; }
        public string ACTIVIDAD { set; get; }
        public int? CANTIDAD_SAFE_TKT { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_DE_NACIMIENTO_PAX { set; get; }

        [XmlElement("FECHA_DE_NACIMIENTO_PAX")]
        public string StringFECHA_DE_NACIMIENTO_PAX
        {
            set { FECHA_DE_NACIMIENTO_PAX = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_DE_NACIMIENTO_PAX == null) ? null : FECHA_DE_NACIMIENTO_PAX.Value.ToString("MM/dd/yyyy HH:mm:ss")); }
        }

        public string NOMBRE_DE_PAX { set; get; }
        public string FACTOR_META_YQ { set; get; }

        #endregion
    }
}
