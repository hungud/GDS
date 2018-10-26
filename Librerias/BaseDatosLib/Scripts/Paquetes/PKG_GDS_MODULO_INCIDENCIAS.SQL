
 -- Header 
 PROCEDURE GDS_INSERTAR_BITACORA_CC  ( p_IdCliente               IN NUMBER,
                                       p_PNR                     IN VARCHAR2,
                                       p_CategoriaBoleto         IN VARCHAR2,
                                       p_Solicitante             IN VARCHAR2,
                                       p_Aprobador               IN VARCHAR2,
                                       p_CentroCosto             IN VARCHAR2,
                                       p_OrdenServicio           IN VARCHAR2,
                                       p_MotivoViaje             IN VARCHAR2,
                                       p_OcurTema                IN VARCHAR2,
                                       p_LoginCrea               IN VARCHAR2,
                                       p_UsuWebIdCrea            IN NUMBER,
                                       p_OfiID                   IN NUMBER,
                                       p_DepID                   IN NUMBER,
                                       p_RowsAffected            OUT NUMBER);    

-- Body

PROCEDURE GDS_INSERTAR_BITACORA_CC (P_IDCLIENTE               IN NUMBER,
                                      P_PNR                     IN VARCHAR2,
                                      P_CATEGORIABOLETO         IN VARCHAR2,
                                      P_SOLICITANTE             IN VARCHAR2,
                                      P_APROBADOR               IN VARCHAR2,
                                      P_CENTROCOSTO             IN VARCHAR2,
                                      P_ORDENSERVICIO           IN VARCHAR2,
                                      P_MOTIVOVIAJE             IN VARCHAR2,
                                      P_OCURTEMA                IN VARCHAR2,
                                      P_LOGINCREA               IN VARCHAR2,
                                      P_USUWEBIDCREA            IN NUMBER,
                                      P_OFIID                   IN NUMBER,
                                      P_DEPID                   IN NUMBER,
                                      P_ROWSAFFECTED               OUT NUMBER)
  AS
     V_OCUR_ID NUMBER;
  BEGIN
     SELECT (NVL(MAX(OCUR_ID), 0) + 1) 
     INTO V_OCUR_ID 
     FROM WEB_CORP_OCURRENCIAS_CLI 
     WHERE ID_CLIENTE = P_IDCLIENTE;
     
     INSERT INTO WEB_CORP_OCURRENCIAS_CLI(ID_CLIENTE,  OCUR_ID,  CATEGORIA_BOLETO, SOLICITANTE, 
                                          APROBADOR,  CENTRO_COSTO, ORDEN_SERVICIO, MOTIVO_VIAJE, 
                                          PNR, OCUR_TEMA, LOGIN_CREA, USUWEB_ID_CREA, 
                                          OFI_ID, DEP_ID, FECHA_CREA)
     VALUES(P_IDCLIENTE, V_OCUR_ID, P_CATEGORIABOLETO, P_SOLICITANTE,
            P_APROBADOR, P_CENTROCOSTO,  P_ORDENSERVICIO, P_MOTIVOVIAJE,
            P_PNR, P_OCURTEMA, P_LOGINCREA, P_USUWEBIDCREA,
            P_OFIID, P_DEPID, SYSDATE );
     
     P_ROWSAFFECTED := SQL%ROWCOUNT;         

  END  GDS_INSERTAR_BITACORA_CC;          