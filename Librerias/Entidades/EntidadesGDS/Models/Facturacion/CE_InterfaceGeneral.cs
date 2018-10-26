using System;
using System.Xml.Serialization;

namespace EntidadesGDS.Facturacion
{
    public class CE_InterfaceGeneral
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public string ID_REFERENCIA { set; get; }
        public long? ID_SECUENCIA { set; get; }
        public string ID_PSEUDO_CITY { set; get; }
        public int? ID_CLIENTE { set; get; }
        public int? ID_SUBCODIGO { set; get; }
        public string ID_EJECUTIVA { set; get; }
        public string ID_MONEDA { set; get; }
        public string COD_RESERVA { set; get; }
        public int? ID_FILE { set; get; }
        public string TEXTO_FC_1 { set; get; }
        public string TEXTO_FC_2 { set; get; }
        public string TEXTO_FC_3 { set; get; }
        public string TEXTO_FC_4 { set; get; }
        public string TIPO_DOCUMENTO_IDENTIDAD_A_FC { set; get; }
        public string NUMERO_DOCUMENTO_A_FC { set; get; }
        public string NOMBRE_A_FC { set; get; }
        public string DIRECCION_A_FC { set; get; }
        public string ID_TIPO_DE_COMPROBANTE { set; get; }
        public int? ID_FACTURA_CABEZA { set; get; }
        public int? NUMERO_SERIE { set; get; }
        public int? ID_EMPRESA { set; get; }
        public int? ID_SUCURSAL { set; get; }
        public int? TRAE_FCOMISION { set; get; }
        public int? ID_COTIZACION { set; get; }
        public string ID_FORMA_DE_PAGO { set; get; }
        public string ID_BANCO { set; get; }
        public int? ID_GDS { set; get; }
        public string FACTURAR_EN_PSEUDO { set; get; }
        public string APELLIDO_PATERNO { set; get; }
        public string APELLIDO_MATERNO { set; get; }
        public string NOMBRES { set; get; }
        public int? COMO_EMITIO { set; get; }
        public int? ORDEN_ATENCION { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_ENVIO { set; get; }

        [XmlElement("FECHA_ENVIO")]
        public string StringFECHA_ENVIO
        {
            set { FECHA_ENVIO = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_ENVIO != null) ? FECHA_ENVIO.Value.ToString("MM/dd/yyyy HH:mm:ss") : null); }
        }

        public string NOMBRE_ENVIO { set; get; }
        public string DIRECCION_ENVIO { set; get; }
        public string TEXTO_ENVIO { set; get; }
        public string QUIEN_SOLICITA { set; get; }
        public string TEXTO_FC_5 { set; get; }
        public string ID_MOTIVO_ENVIO { set; get; }
        public string ID_TIPO_CONTENIDO { set; get; }
        public string OATENCION_RIPLEY { set; get; }
        public string CUENTA_GASTO_MERCK { set; get; }
        public int? ALT_PAYEE_MERCK { set; get; }
        public string CODIGO_USUARIO_MERCK { set; get; }
        public string EXPLICACION_VIAJE_MERCK { set; get; }
        public string CENTRO_COSTO_NOKIA { set; get; }
        public string CODIGO_VENDEDOR_NOKIA { set; get; }
        public string NUM_INGRESO_BCP { set; get; }
        public string MISION_BCP { set; get; }
        public string MATRICULA_MISION_BCP { set; get; }
        public string CCOSTO_GTE_BCP { set; get; }
        public string MATRICULA_GTE_BCP { set; get; }
        public string NUMERO_DE_AUTORIZACION { set; get; }
        public string ACCOUNT { set; get; }
        public string BUSINESS_UNIT { set; get; }
        public string DEPTID { set; get; }
        public string PRODUCTO { set; get; }
        public string PROYECTO { set; get; }
        public int? CON_MOROSIDAD { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_DE_ALTA { set; get; }

        [XmlElement("FECHA_DE_ALTA")]
        public string StringFECHA_DE_ALTA
        {
            set { FECHA_DE_ALTA = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_DE_ALTA != null) ? FECHA_DE_ALTA.Value.ToString("MM/dd/yyyy HH:mm:ss") : null); }
        }

        public int? EMISION_AUTONOMA { set; get; }
        public int? CON_EXCESO_LINEA_CREDITO { set; get; }
        public int? COMO_SOLICITO { set; get; }
        public int? ID_PUNTO_FACTURAR { set; get; }
        public string ID_IATA_BOLETO { set; get; }
        public int? GRUPO_SIN_OATENCION_RIPLEY { set; get; }
        public string ID_MOTIVO_VIAJE { set; get; }
        public string ID_COMO_SE_ENTERO { set; get; }
        public string NOMBRE_TITULAR_TARJETA { set; get; }
        public string TIPO_DOC_TITULAR_TARJETA { set; get; }
        public string NRO_DOC_TITULAR_TARJETA { set; get; }
        public string ID_PAIS_EMISION_TARJETA { set; get; }
        public string NOMBRE_BANCO_TARJETA { set; get; }
        public int? ID_TIPO_DE_WAIVER { set; get; }
        public int? NO_IMPRIME_COMPROBANTE { set; get; }
        public string ID_CIUDAD_DESTINO { set; get; }
        public int? ID_SUCURSAL_FACTURAR { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_SALIDA { set; get; }

        [XmlElement("FECHA_SALIDA")]
        public string StringFECHA_SALIDA
        {
            set { FECHA_SALIDA = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_SALIDA != null) ? FECHA_SALIDA.Value.ToString("MM/dd/yyyy HH:mm:ss") : null); }
        }

        [XmlIgnore]
        public DateTime? FECHA_RETORNO { set; get; }

        [XmlElement("FECHA_RETORNO")]
        public string StringFECHA_RETORNO
        {
            set { FECHA_RETORNO = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_RETORNO != null) ? FECHA_RETORNO.Value.ToString("MM/dd/yyyy HH:mm:ss") : null); }
        }

        public int? REEMISION_FLAG { set; get; }
        public string OBS_BAYER { set; get; }
        public string AHORRO_X_CONVENIO { set; get; }
        public string AHORRO_X_GESTION { set; get; }
        public string EMAIL_CLIENTE { set; get; }
        public string MILLAS_VOLADAS { set; get; }
        public string FACTOR_META { set; get; }
        public string QUIEN_AUTORIZA { set; get; }
        public string AGENTE_CONFIRMA { set; get; }
        public int? NUMERO_SOLICITUD_YANACOCHA { set; get; }
        public string TAREA_GOLDER { set; get; }
        public int? ID_SOLICITANTE_BAYER { set; get; }
        public string TARIFA_MAS_ECONOMICA { set; get; }
        public string AEROLINEA_MAS_ECONOMICA { set; get; }
        public string CODIGO_FARO { set; get; }
        public string ID_MOTIVO_REEMISION { set; get; }
        public int? AHORRO_PERDIDO { set; get; }
        public string CODIGO_VENDEDORWEB { set; get; }
        public string CABINA { set; get; }
        public string METODO_DE_RESERVA { set; get; }
        public string DENTRO_DE_POLITICA { set; get; }
        public string TIPO_DE_BOLETO { set; get; }
        public string ID_TIPO_AHORRO { set; get; }
        public string EXCEPCION_DE_POLITICA { set; get; }
        public string ALOJAMIENTO { set; get; }
        public string TRASLADO { set; get; }
        public string CONTACTO { set; get; }
        public string RESIDE_EXTERIOR { set; get; }
        public string ID_MOTIVO_TARIFA_BAJA { set; get; }
        public string ID_MOTIVO_USO_TARIFA_MAS_ALTA { set; get; }
        public string AUTOEXCH_ERROR_MSGE { set; get; }
        public string ID_MOTIVO_CAMBIO { set; get; }
        public string NUMERO_SOLICITUD { set; get; }
        public int? ES_GRUPO { set; get; }
        public string FONDO_CTA { set; get; }
        public string CATEGORIA_CTA { set; get; }
        public string ACTIVIDAD_CTA { set; get; }
        public string COD_CLIENTE_CTA { set; get; }
        public string COD_ENCARGO_CTA { set; get; }
        public string COD_USUARIO_CTA { set; get; }
        public string APROBADOR_CTA { set; get; }
        public int? REFERENCIA_PROCESAR { set; get; }
        public int? REFERENCIA_PROCESADO { set; get; }
        public int? CON_PAGO_TARJETA { set; get; }
        public int? CON_PAGO_PEFECTIVO { set; get; }
        public int? AUTORIZA_EMISION { set; get; }
        public string IMPORTE_FEE_TMP { set; get; }
        public int? GENERA_FC_GASTOS_TMP { set; get; }
        public string NUMERO_SERIE1 { set; get; }
        public string MOTIVO_DE_VIAJE { set; get; }
        public string CLIENTE_DELA_CUENTA { set; get; }
        public string AERONAVE { set; get; }
        public string TRIPULACION { set; get; }
        public string ASIENTO_PREFERENTE { set; get; }
        public string CUENTA_CONTABLE { set; get; }
        public int? IMPRIME_FC_ELECTRONICA { set; get; }
        public string CODIGO_APROBACION { set; get; }
        public string UPI { set; get; }
        public string TRIP { set; get; }

        [XmlIgnore]
        public DateTime? FECHA_AUTORIZACION { set; get; }

        [XmlElement("FECHA_AUTORIZACION")]
        public string StringFECHA_AUTORIZACION
        {
            set { FECHA_AUTORIZACION = ((value == null) ? ((DateTime?) null) : DateTime.Parse(value)); }
            get { return ((FECHA_AUTORIZACION == null) ? null : FECHA_AUTORIZACION.Value.ToString("MM/dd/yyyy HH:mm:ss")); }
        }

        public string ORDEN_COMPRA { set; get; }
        public string STRING { set; get; }
        public string REMARK_COD { set; get; }
        public string SERVICE_LINE { set; get; }
        public string IMPORTE_PEF_CTC { set; get; }
        public int? ID_CAMPANA { set; get; }
        public int? ES_BLOQUEO { set; get; }
        public int? ES_TARJETA_CREDITO_PTA { set; get; }
        public string ID_PRESTAMO { set; get; }
        public string ID_FILE_REFERENCIA { set; get; }
        public string ID_VALOR { set; get; }
        public int? ES_TARJETA_BTA { set; get; }
        public int? ID_TARJETA_CREDITO_PTA { set; get; }
        public int? ID_REGLA_TARJETA_CREDITO_PTA { set; get; }

        #endregion
    }
}
