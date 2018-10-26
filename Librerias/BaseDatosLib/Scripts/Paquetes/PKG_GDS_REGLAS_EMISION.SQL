CREATE OR REPLACE PACKAGE PKG_GDS_REGLAS_EMISION IS

  -- Author  : BCHOY
  -- Versión : 14.12.17
  -- Created : 14/12/2017 07:00:05
  -- Purpose :

  type cursorGDS IS REF CURSOR;

PROCEDURE GDS_NO_PERMITE_TRANSPORTADOR(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN number,
  p_NoPermiteEmision     OUT number);

PROCEDURE GDS_OBTENER_LISTA_PERMITE_TRAN(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN varchar2,
  p_Descripcion          IN varchar2,
  p_EsPropio             IN varchar2,
  p_Cursor               OUT cursorGDS);

PROCEDURE GDS_ANADIR_PERMITE_TRAN(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN number,
  p_Descripcion          IN varchar2,
  p_EsPropio             IN varchar2,
  p_RowsAffected         OUT number);

PROCEDURE GDS_ELIMINAR_PERMITE_TRAN(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN number,
  p_RowsAffected         OUT number);

-- // --

CREATE OR REPLACE PACKAGE BODY PKG_GDS_REGLAS_EMISION IS

PROCEDURE GDS_NO_PERMITE_TRANSPORTADOR(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN number,
  p_NoPermiteEmision     OUT number)

AS
BEGIN
  SELECT
    CASE WHEN (ET.ID_GDS IS NULL) THEN TR.CONS_NO_PERMITE_EMISION_APP ELSE 0 END INTO p_NoPermiteEmision
  FROM TRANSPORTADOR TR
  LEFT OUTER JOIN (
    SELECT ET.ID_GDS, ET.ID_TRANSPORTADOR
    FROM GDS_PERMITE_EMISION_TRANS ET
    WHERE (UPPER(ET.ID_TRANSPORTADOR) = UPPER(p_Transportador))
    AND (UPPER(ET.PCC) = UPPER(p_Pseudo))
    AND (ET.ID_GDS = p_Gds)) ET ON (TR.ID_TRANSPORTADOR = ET.ID_TRANSPORTADOR)
  WHERE (UPPER(TR.ID_TRANSPORTADOR) = UPPER(p_Transportador));

EXCEPTION
    WHEN NO_DATA_FOUND THEN
      p_NoPermiteEmision := 1;

END GDS_NO_PERMITE_TRANSPORTADOR;

PROCEDURE GDS_OBTENER_LISTA_PERMITE_TRAN(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN varchar2,
  p_Descripcion          IN varchar2,
  p_EsPropio             IN varchar2,
  p_Cursor               OUT cursorGDS)

AS
BEGIN 
  OPEN p_Cursor FOR 
  SELECT 
    ET.ID_TRANSPORTADOR AS IDTRANSPORTADOR, 
    ET.PCC AS PSEUDO, 
    ET.ID_GDS AS GDS, 
    ET.FECHA_ALTA AS FECHAALTA, 
    ET.DESCRIPCION, 
    ET.ES_PROPIO AS ESPROPIO 
  FROM GDS_PERMITE_EMISION_TRANS ET
  WHERE (UPPER(ET.ID_TRANSPORTADOR) = UPPER(NVL(p_Transportador, ET.ID_TRANSPORTADOR)))
  AND (UPPER(ET.PCC) like UPPER('%' || NVL(p_Pseudo, ET.PCC) || '%'))
  AND (ET.ID_GDS IN ( 
    SELECT TRIM(regexp_substr(NVL(p_Gds, ET.ID_GDS), '[^,]+', 1, level)) ITEMS
    FROM dual
    CONNECT BY TRIM(regexp_substr(NVL(p_Gds, ET.ID_GDS), '[^,]+', 1, level)) IS NOT NULL
  ))
  AND (UPPER(ET.DESCRIPCION) like UPPER('%' || NVL(p_Descripcion, ET.DESCRIPCION) || '%'))
  AND (UPPER(ET.ES_PROPIO) like UPPER('%' || NVL(p_EsPropio, ET.ES_PROPIO) || '%'))
  ORDER BY ET.ID_GDS, ET.ID_TRANSPORTADOR, ET.PCC;

END GDS_OBTENER_LISTA_PERMITE_TRAN;

PROCEDURE GDS_ANADIR_PERMITE_TRAN(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN number,
  p_Descripcion          IN varchar2,
  p_EsPropio             IN varchar2,
  p_RowsAffected         OUT number)

AS
BEGIN 
  INSERT INTO GDS_PERMITE_EMISION_TRANS (
    ID_TRANSPORTADOR, PCC, ID_GDS, FECHA_ALTA, DESCRIPCION, ES_PROPIO
  ) VALUES (
    TRIM(UPPER(p_Transportador)), TRIM(UPPER(p_Pseudo)), p_Gds, SYSDATE, 
    TRIM(UPPER(p_Descripcion)), TRIM(UPPER(p_EsPropio))
  );

  p_RowsAffected := SQL%ROWCOUNT;

END GDS_ANADIR_PERMITE_TRAN;

PROCEDURE GDS_ELIMINAR_PERMITE_TRAN(
  p_Transportador        IN varchar2,
  p_Pseudo               IN varchar2,
  p_Gds                  IN number,
  p_RowsAffected         OUT number)

AS
BEGIN 
  DELETE FROM GDS_PERMITE_EMISION_TRANS 
  WHERE (UPPER(ID_TRANSPORTADOR) = UPPER(p_Transportador))
  AND (UPPER(PCC) = UPPER(p_Pseudo))
  AND (ID_GDS = p_Gds);

  p_RowsAffected := SQL%ROWCOUNT;

END GDS_ELIMINAR_PERMITE_TRAN;

END PKG_GDS_REGLAS_EMISION;
