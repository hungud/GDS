CREATE OR REPLACE PACKAGE nuevomundo.PKG_GDS_GENERIC IS

  -- Author   : BCHOY
  -- Versión  : 06.12.17
  -- Created  : 06/12/2017 20:00:05
  -- Modified : 11/05/2018 07:51:00
  -- Purpose  :

  -- Public type declarations

PROCEDURE GDS_INSERT_WITH_XML(
  p_Table        IN varchar2,
  p_XmlData      IN clob,
  p_RowsAffected OUT number);

PROCEDURE GDS_DELETE_WITH_XML(
  p_Table        IN varchar2,
  p_XmlData      IN clob,
  p_RowsAffected OUT number);

END PKG_GDS_GENERIC;

-- // --

CREATE OR REPLACE PACKAGE BODY nuevomundo.PKG_GDS_GENERIC IS

PROCEDURE GDS_INSERT_WITH_XML(
  p_Table         IN varchar2,
  p_XmlData       IN clob,
  p_RowsAffected  OUT number)

AS
  v_Context DBMS_XMLSave.ctxType;

BEGIN
  v_Context := DBMS_XMLSave.newContext(p_Table);

  -- por lo momentos comentado debido a que cambie la fecha de forma incorrecta / investigar mas
  -- desde la aplicaciión se debe de pasar con este formato: 'MM/dd/yyyy HH:mm:ss'
  -- DBMS_XMLSave.setDateFormat(v_Context,'dd/MM/yyyy HH:mm:ss');

  p_RowsAffected := DBMS_XMLSave.insertXML(v_Context, p_XmlData);
  DBMS_XMLSave.closeContext(v_Context);

END GDS_INSERT_WITH_XML;

PROCEDURE GDS_DELETE_WITH_XML(
  p_Table         IN varchar2,
  p_XmlData       IN clob,
  p_RowsAffected  OUT number)

AS
  v_Context DBMS_XMLSave.ctxType;

BEGIN
  v_Context := DBMS_XMLSave.newContext(p_Table);

  p_RowsAffected := DBMS_XMLSave.deleteXML(v_Context, p_XmlData);
  DBMS_XMLSave.closeContext(v_Context);

END GDS_DELETE_WITH_XML;

END PKG_GDS_GENERIC;
