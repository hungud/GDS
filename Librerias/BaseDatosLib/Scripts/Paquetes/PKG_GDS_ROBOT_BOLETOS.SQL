CREATE OR REPLACE PACKAGE nuevomundo.PKG_GDS_ROBOT_BOLETOS IS

  -- Author  : LLUZA
  -- Created : 29/11/2017 09:04:00

TYPE cursorGDS IS REF CURSOR;

------------------------------------------------------------------

PROCEDURE GDS_INSERTA_VOUCHER        (p_PnrCode        IN VARCHAR2,
                                      p_Pseudo         IN VARCHAR2,
                                      p_PrintFlag      IN NUMBER,
                                      p_TicketNumbre   IN VARCHAR2,
                                      p_CuerpoBoleto   IN CLOB);

------------------------------------------------------------------

PROCEDURE GDS_BOLETOS_FACTURADO    (  p_TicketNumbre          IN VARCHAR2,
                                      p_IdEmpresaSucursal     IN number,
                                      p_MarcaEsConsolidador   IN number,
                                      p_ListaGDS              IN varchar2,
                                      p_Fecha                 IN varchar2,
                                      p_Cursor                OUT cursorGDS);
------------------------------------------------------------------  

END PKG_GDS_ROBOT_BOLETOS;

------------------------------------------------------------------  
------------------------------------------------------------------  
CREATE OR REPLACE PACKAGE BODY nuevomundo.PKG_GDS_ROBOT_BOLETOS IS

PROCEDURE GDS_INSERTA_VOUCHER        (p_PnrCode        IN VARCHAR2,
                                      p_Pseudo         IN VARCHAR2,
                                      p_PrintFlag      IN NUMBER,
                                      p_TicketNumbre   IN VARCHAR2,
                                      p_CuerpoBoleto   IN CLOB)
                                      
AS
  p_EXISTE_BOLETO INTEGER:=0;
  
BEGIN
  
  SELECT COUNT(*) INTO p_EXISTE_BOLETO
    FROM TURBO_CC_CHARGE_FORM TCC
   WHERE TCC.PNR_CODE = p_PnrCode
     AND TCC.TICKET_NUMBER = p_TicketNumbre;

  IF (p_EXISTE_BOLETO = 0) THEN
      INSERT INTO TURBO_CC_CHARGE_FORM TCC
                  (TCC.PNR_CODE,  
                   TCC.COUNTER_TA,
                   TCC.PRINT_FLAG,
                   TCC.TICKET_NUMBER,
                   TCC.CUERPO_DOCUMENTO,
                   TCC.FECHA_ALTA)
         VALUES (p_PnrCode,
                 p_Pseudo,
                 p_PrintFlag,
                 p_TicketNumbre,
                 p_CuerpoBoleto,
                 SYSDATE);
  ELSE
        UPDATE TURBO_CC_CHARGE_FORM TCC
               SET TCC.PNR_CODE = p_PnrCode,  
                TCC.COUNTER_TA = p_Pseudo,
                TCC.PRINT_FLAG = p_PrintFlag,
                TCC.TICKET_NUMBER = p_TicketNumbre,
                TCC.CUERPO_DOCUMENTO = p_CuerpoBoleto,
                TCC.FECHA_ALTA = SYSDATE;
  END IF;
  
END GDS_INSERTA_VOUCHER;                                      
-------------------------------------------------------------------------------------------------------

PROCEDURE GDS_BOLETOS_FACTURADO    (  p_TicketNumbre          IN VARCHAR2,
                                      p_IdEmpresaSucursal     IN number,
                                      p_MarcaEsConsolidador   IN number,
                                      p_ListaGDS              IN varchar2,
                                      p_Fecha                 IN varchar2,
                                      p_Cursor                OUT cursorGDS)

AS
     p_FECHAALTA varchar2(10);
BEGIN
      IF (NVL(p_Fecha, 'X') = 'X') THEN
          p_FECHAALTA := TO_CHAR(SYSDATE, 'dd/MM/yyyy');
      ELSE
          p_FECHAALTA := p_Fecha;
      END IF;
      
      OPEN p_Cursor FOR 
      SELECT 
        PROMO.ANULADA AS ANULADA,
        SU.ID_SUCURSAL AS IDSUCURSAL,
        SU.DESCRIPCION AS DESCRIPCIONSUCURSAL,
        BO.ID_PUNTO AS PUNTO,
        BO.ID_CLIENTE AS IDCLIENTE,
        CLI.NOMBRE AS NOMBRECLIENTE,
        CLI.CORREO_ELECTRONICO AS CORREOCLIENTE,
        BO.ID_FILE AS IDFILE,
        BO.ID_TIPO_DE_STOCK AS IDTIPOSTOCK, 
        BO.COD_RESERVA AS PNR, 
        BO.NUMERO_DE_BOLETO AS NUMEROBOLETO,
        BO.MARCA_FACTURADO AS FACTURADO,
        TRANS.ID_PREFIJO AS IDPREFIJO,
        FAC.ID_TIPO_DE_COMPROBANTE AS IDTIPOCOMPROBANTE,
        FAC.NUMERO_SERIE1 AS NUMEROSERIE1,
        FAC.ID_FACTURA_CABEZA AS IDFACTURACABEZA,
        FAC.NOMBRE_PAX AS NOMBREPASAJERO,
        BO.MARCA_VOID AS VOIDEADO,
        BO.ID_VENDEDOR AS IDVENDEDOR,
        VN.NOMBRE AS NOMBREVENDEDOR,
        VN.CORREO_ELECTRONICO AS CORREOVENDEDOR,
        BO.ES_TARJETA_CREDITO_PTA AS ESTARJETACREDITOPTA
      FROM BOLETO_PAX BO
      INNER JOIN CLIENTE CLI ON (BO.ID_CLIENTE = CLI.ID_CLIENTE)
      INNER JOIN SUCURSAL SU ON SU.ID_SUCURSAL = BO.ID_SUCURSAL
      INNER JOIN PROMOTOR PROMO ON (PROMO.ID_PROMOTOR = CLI.ID_PROMOTOR)
      INNER JOIN TRANSPORTADOR TRANS ON (TRANS.ID_TRANSPORTADOR = BO.ID_TRANSPORTADOR)
      LEFT OUTER JOIN WEB_AUTORIZACION_DSCTO_EXTRA WEBO ON (WEBO.COD_RESERVA = BO.COD_RESERVA)
      INNER JOIN FACTURA_BOLETO FAC ON (FAC.ID_PROVEEDOR = BO.ID_PROVEEDOR)
        AND (FAC.NRO_BOLETO = BO.NUMERO_DE_BOLETO)
      INNER JOIN FACTURA_CABEZA CAB ON (FAC.ID_SUCURSAL = CAB.ID_SUCURSAL)
        AND (FAC.ID_TIPO_DE_COMPROBANTE = CAB.ID_TIPO_DE_COMPROBANTE)
        AND (FAC.NUMERO_SERIE1 = CAB.NUMERO_SERIE1)
        AND (FAC.ID_FACTURA_CABEZA = CAB.ID_FACTURA_CABEZA)
      INNER JOIN VENDEDOR VN ON (BO.ID_VENDEDOR = VN.ID_VENDEDOR)
      INNER JOIN PUNTO_DE_EMISION PM ON (PM.ID_SUCURSAL = SU.ID_SUCURSAL) 
        AND (PM.ID_PUNTO = BO.ID_PUNTO) 
      WHERE (BO.MARCA_VOID = 0)
      AND (BO.ES_CONEXION = 0)
      AND (TO_CHAR(BO.FECHA_DE_ALTA,'dd/MM/yyyy') = p_FECHAALTA)
      AND (BO.ID_TIPO_DE_STOCK IN (
          SELECT ID_TIPO_DE_STOCK FROM TIPO_DE_STOCK 
          WHERE (NVL(ID_GDS, -1) != -1)
          AND (ID_GDS IN (
              SELECT TRIM(regexp_substr(p_ListaGDS, '[^,]+', 1, level)) ITEMS
              FROM dual
              CONNECT BY TRIM(regexp_substr(p_ListaGDS, '[^,]+', 1, level)) IS NOT NULL
          ))
      ))
      AND (SU.ID_SUCURSAL IN (
          SELECT ID_SUCURSAL 
          FROM SUCURSAL 
          WHERE ((ID_EMPRESA = p_IdEmpresaSucursal) AND (ES_CONSOLIDADOR = p_MarcaEsConsolidador)))
      )
      AND BO.NUMERO_DE_BOLETO = p_TicketNumbre
      ORDER BY PROMO.ID_PROMOTOR, SU.ID_SUCURSAL, BO.ID_CLIENTE, BO.NUMERO_DE_BOLETO ASC;  

END GDS_BOLETOS_FACTURADO;                                      
-------------------------------------------------------------------------------------------------------
END PKG_GDS_ROBOT_BOLETOS;