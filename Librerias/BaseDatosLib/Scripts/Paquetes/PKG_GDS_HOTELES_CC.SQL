create or replace package nuevomundo.PKG_GDS_HOTELES_CC is

 TYPE GDS_Cursor IS REF Cursor;  
  
 PROCEDURE GDS_INSERTAR_INFO_SERV_HOTEL   (    p_CodigoReserva        IN VARCHAR2 DEFAULT null,
                                               p_FechaEmision         IN VARCHAR2 DEFAULT null,
                                               p_FechaCheckIn         IN VARCHAR2 DEFAULT null,
                                               p_FechaCheckOut        IN VARCHAR2 DEFAULT null,
                                               p_FechaReserva         IN VARCHAR2 DEFAULT null,
                                               p_Pax                  IN VARCHAR2 DEFAULT null,
                                               p_CantHabitaciones     IN NUMBER DEFAULT null,                                                                                              
                                               p_IdHotelSRV           IN NUMBER DEFAULT null,
                                               p_CodigoReservaHotel   IN VARCHAR2 DEFAULT null,
                                               p_IdTipoHabitacion     IN VARCHAR2 DEFAULT NULL,                                               
                                               p_IdTipoTarifa         IN VARCHAR2 DEFAULT NULL,
                                               p_PagoEN               IN NUMBER DEFAULT 0,                                      
                                               p_IdMoneda             IN VARCHAR2 DEFAULT NULL,
                                               p_ImporteGravado       IN DECIMAL DEFAULT 0,
                                               p_ImporteNoGravado     IN DECIMAL DEFAULT 0,
                                               p_ImporteIGV           IN DECIMAL DEFAULT 0,                                                                                               
                                               p_CodigoRazonHotel     IN VARCHAR2 DEFAULT NULL,
                                               p_IdCliente            IN NUMBER,
                                               p_ROWSAFFECTED         OUT NUMBER); 
                                               
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------                                               

 PROCEDURE GDS_INSERTAR_HOTEL           (    p_Nombre               IN VARCHAR2 DEFAULT null,
                                             p_RazonSocial          IN VARCHAR2 DEFAULT null,
                                             p_Direccion            IN VARCHAR2 DEFAULT null,
                                             p_IdCiudad             IN VARCHAR2 DEFAULT null,
                                             p_IdPais               IN VARCHAR2 DEFAULT null,
                                             p_Telefono             IN VARCHAR2 DEFAULT null,
                                             p_IdDepartamentoPTA    IN VARCHAR2 DEFAULT null,
                                             p_IdHotel              OUT NUMBER);
                                             
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------                                             

 PROCEDURE GDS_OBTENER_PREFIJO_REMARK   (    p_IdCliente            IN NUMBER,
                                             p_IdTipoTabla            IN VARCHAR2 ,
                                             p_PrefijoRemark        OUT VARCHAR2);
    
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------                                             

 PROCEDURE GDS_OBTENER_TIPO_TARIFA    (  p_Cursor OUT GDS_Cursor  );
 
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_TIPO_HABITACION (  p_Cursor OUT GDS_Cursor  );

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_PAISES_HOTEL    (  p_DepartamentoPTA IN VARCHAR2 DEFAULT NULL,
                                          p_Cursor OUT GDS_Cursor  );
                                                                                                                                 
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_CIUDADES_HOTEL    (  p_DepartamentoPTA IN VARCHAR2 DEFAULT NULL,
                                            p_IdPais IN VARCHAR2 DEFAULT NULL,
                                            p_Cursor OUT GDS_Cursor  );

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
 
 PROCEDURE GDS_OBTENER_HOTEL_DEPARTAMENTO    (  p_DepartamentoPTA IN VARCHAR2 DEFAULT NULL,
                                                p_IdCiudad IN VARCHAR2 DEFAULT NULL,
                                                p_Cursor OUT GDS_Cursor  );
 
                                                                                               

end PKG_GDS_HOTELES_CC;

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
  ------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
  ------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
  ------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
  

create or replace package body nuevomundo.PKG_GDS_HOTELES_CC is


 PROCEDURE GDS_INSERTAR_INFO_SERV_HOTEL   (    p_CodigoReserva        IN VARCHAR2 DEFAULT null,
                                               p_FechaEmision         IN VARCHAR2 DEFAULT null,
                                               p_FechaCheckIn         IN VARCHAR2 DEFAULT null,
                                               p_FechaCheckOut        IN VARCHAR2 DEFAULT null,
                                               p_FechaReserva         IN VARCHAR2 DEFAULT null,
                                               p_Pax                  IN VARCHAR2 DEFAULT null,
                                               p_CantHabitaciones     IN NUMBER DEFAULT null,                                                                                              
                                               p_IdHotelSRV           IN NUMBER DEFAULT null,
                                               p_CodigoReservaHotel   IN VARCHAR2 DEFAULT null,
                                               p_IdTipoHabitacion     IN VARCHAR2 DEFAULT NULL,                                               
                                               p_IdTipoTarifa         IN VARCHAR2 DEFAULT NULL,
                                               p_PagoEN               IN NUMBER DEFAULT 0,                                      
                                               p_IdMoneda             IN VARCHAR2 DEFAULT NULL,
                                               p_ImporteGravado       IN DECIMAL DEFAULT 0,
                                               p_ImporteNoGravado     IN DECIMAL DEFAULT 0,
                                               p_ImporteIGV           IN DECIMAL DEFAULT 0,                                                                                               
                                               p_CodigoRazonHotel     IN VARCHAR2 DEFAULT NULL,
                                               p_IdCliente            IN NUMBER,
                                               p_ROWSAFFECTED         OUT NUMBER)
  AS 
  
  BEGIN
    INSERT INTO FILE_SERVICIO_INFO( COD_RESERVA, FECHA_EMISION, FECHA_SALIDA, FECHA_REGRESO,
                                    FECHA_RESERVA, PAX_X_SERVICIO, CANTIDAD, ID_HOTEL_SRV,
                                    TICKET_DESIGNATOR, ID_TIPO_HABITACION, ID_TIPO_TARIFA,
                                    PAGO_EN, ID_MONEDA, IMPORTE_GRAVADO, IMPORTE_NO_GRAVADO,
                                    IMPORTE_IGV, CODIGO_RAZON_HOTEL, ID_CLIENTE)
    VALUES(p_CodigoReserva, p_FechaEmision, p_FechaCheckIn, p_FechaCheckOut, 
           p_FechaReserva, p_Pax, p_CantHabitaciones, p_IdHotelSRV, 
           p_CodigoReservaHotel, p_IdTipoHabitacion, p_IdTipoTarifa,
           p_PagoEN, p_IdMoneda, p_ImporteGravado, p_ImporteNoGravado,
           p_ImporteIGV, p_CodigoRazonHotel, p_IdCliente );
    
    P_ROWSAFFECTED := SQL%ROWCOUNT;  
    
  END  GDS_INSERTAR_INFO_SERV_HOTEL;                                                                                        

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
                                           
  PROCEDURE GDS_INSERTAR_HOTEL           (   p_Nombre               IN VARCHAR2 DEFAULT null,
                                             p_RazonSocial          IN VARCHAR2 DEFAULT null,
                                             p_Direccion            IN VARCHAR2 DEFAULT null,
                                             p_IdCiudad             IN VARCHAR2 DEFAULT null,
                                             p_IdPais               IN VARCHAR2 DEFAULT null,
                                             p_Telefono             IN VARCHAR2 DEFAULT null,
                                             p_IdDepartamentoPTA    IN VARCHAR2 DEFAULT null,
                                             p_IdHotel         OUT NUMBER)
  AS
     p_EXISTE_HOTEL INTEGER := 0;
     p_CORRELATIVO_HOTEL INTEGER := 0;
  BEGIN
     
     /* Valida que hotel no se haya registrado antes */
     SELECT COUNT(*) 
     INTO p_EXISTE_HOTEL
     FROM HOTEL H
     WHERE TRIM(UPPER(h.Nombre)) = TRIM(UPPER(p_Nombre));
     
     /* Si el hotel no esta registrado, lo registramos*/
     IF (p_EXISTE_HOTEL = 0) THEN
        
        /* Obtener el correlativo para usarlo de ID hotel */
        SELECT (ULTIMO_NUMERO_USADO  + 1)
        INTO p_CORRELATIVO_HOTEL
        FROM NUMERACION_EMPRESA
        WHERE ID_TIPO_DE_COMPROBANTE = 'HOT';
        
        /* Insertar Hotel */
        INSERT INTO HOTEL(ID_HOTEL, NOMBRE, RAZON_SOCIAL, DIRECCION, ID_CIUDAD, ID_PAIS, TELEFONO, ID_DEPARTAMENTO_PTA, FECHA_ALTA)
        VALUES ( p_CORRELATIVO_HOTEL, p_Nombre, p_RazonSocial, p_Direccion, p_IdCiudad, p_IdPais, p_Telefono, p_IdDepartamentoPTA, sysdate);
        
        /* Actualizar Correlativo */
        UPDATE NUMERACION_EMPRESA
        SET ULTIMO_NUMERO_USADO = p_CORRELATIVO_HOTEL
        WHERE ID_TIPO_DE_COMPROBANTE = 'HOT';   
        
        COMMIT;
     ELSE
        /* Si existe retornamos el codigo */
        SELECT ID_HOTEL 
        INTO p_CORRELATIVO_HOTEL
        FROM HOTEL H
        WHERE TRIM(UPPER(h.Nombre)) = TRIM(UPPER(p_Nombre)); 
     END IF;     
     
     p_IdHotel := p_CORRELATIVO_HOTEL;
  END GDS_INSERTAR_HOTEL;                                             

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_PREFIJO_REMARK   (    p_IdCliente            IN NUMBER,
                                             p_IdTipoTabla            IN VARCHAR2 ,
                                             p_PrefijoRemark        OUT VARCHAR2)
                                             
  AS
  
  BEGIN
    SELECT REMARK
    INTO p_PrefijoRemark
    FROM TIPO_TABLA_X_CLIENTE 
    WHERE ID_CLIENTE = p_IdCliente AND ID_TIPO_DE_TABLA = p_IdTipoTabla;                                             

  EXCEPTION WHEN NO_DATA_FOUND then
    p_PrefijoRemark := null;

  END GDS_OBTENER_PREFIJO_REMARK;    
  
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_TIPO_TARIFA  (p_Cursor OUT GDS_Cursor)       
   AS
   BEGIN
    OPEN p_Cursor FOR 
    SELECT ID_SUBCODIGO AS CLAVE, NOMBRE AS VALOR 
    FROM TIPO_DE_PROCESOS_DETALLE WHERE ID_CODIGO = 41;
  END GDS_OBTENER_TIPO_TARIFA;                        

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_TIPO_HABITACION  (p_Cursor OUT GDS_Cursor)       
   AS
   BEGIN
    OPEN p_Cursor FOR 
    SELECT ID_SUBCODIGO AS CLAVE, NOMBRE AS VALOR 
    FROM TIPO_DE_PROCESOS_DETALLE WHERE ID_CODIGO = 42;
  END GDS_OBTENER_TIPO_HABITACION;                          

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
  
 PROCEDURE GDS_OBTENER_PAISES_HOTEL  ( p_DepartamentoPTA IN VARCHAR2,
                                       p_Cursor OUT GDS_Cursor)       
   AS
   BEGIN
    OPEN p_Cursor FOR 
    SELECT ID_PAIS AS IDPAIS, NOMBRE AS NOMBREPAIS FROM PAIS WHERE ID_PAIS IN (
       SELECT ID_PAIS 
       FROM HOTEL 
       WHERE ID_DEPARTAMENTO_PTA = p_DepartamentoPTA);
       
  END GDS_OBTENER_PAISES_HOTEL;                          

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
  
 PROCEDURE GDS_OBTENER_CIUDADES_HOTEL  ( p_DepartamentoPTA IN VARCHAR2,
                                         p_IdPais IN VARCHAR2,
                                         p_Cursor OUT GDS_Cursor)       
   AS
   BEGIN
    OPEN p_Cursor FOR 
    SELECT ID_CIUDAD AS IDCIUDAD, NOMBRE AS NOMBRECIUDAD FROM CIUDAD 
    WHERE ID_CIUDAD IN (
          SELECT ID_CIUDAD 
          FROM HOTEL 
          WHERE ID_PAIS = p_IdPais AND ID_DEPARTAMENTO_PTA = p_DepartamentoPTA);
       
  END GDS_OBTENER_CIUDADES_HOTEL;                          

------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------------------------------------------------------------------------------

 PROCEDURE GDS_OBTENER_HOTEL_DEPARTAMENTO  ( p_DepartamentoPTA IN VARCHAR2,
                                             p_IdCiudad IN VARCHAR2,
                                             p_Cursor OUT GDS_Cursor)       
   AS
   BEGIN
    OPEN p_Cursor FOR 
    SELECT ID_HOTEL AS IDHOTEL,
       NOMBRE, 
       RAZON_SOCIAL AS RAZONSOCIAL, 
       DIRECCION, 
       CORREO_ELECTRONICO AS CORREO, 
       ID_CATEGORIA AS IDCATEGORIA, 
       TELEFONO, 
       CODIGO_CADENA AS CODIGOCADENAHOTELERA
    FROM HOTEL
    WHERE ID_CIUDAD = p_IdCiudad 
    AND ID_DEPARTAMENTO_PTA = p_DepartamentoPTA;
       
  END GDS_OBTENER_HOTEL_DEPARTAMENTO;  



end PKG_GDS_HOTELES_CC;
