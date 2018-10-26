using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.General;
using EntidadesGDS.Hotel;
using EntidadesGDS.Models.Hotel;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsHotelesCC : Common
    {
           // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public PkgGdsHotelesCC(string codigoSeguimiento,
                               Conexion conexion,
                               string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_HOTELES_CC")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsHotelesCC(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsHotelesCC()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"
        
        /// <summary>
        /// Registra Información de reserva Hotel Confirmado 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="infoSegmentoConfirmado"></param>
        /// <returns></returns>
        public bool GdsRegistarSegmentoConfirmadoHotel(Conexion conexion,
                                                       string esquema,
                                                       RQ_SegmentoConfirmadoHotel infoSegmentoConfirmado)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_codigoreserva", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.CodigoReserva, 255));
                lparametros.Add(new Parametro("p_fechaemision", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.FechaEmision, 255));
                lparametros.Add(new Parametro("p_fechacheckin", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.FechaEntrada, 255));
                lparametros.Add(new Parametro("p_fechacheckout", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.FechaSalida, 255));
                lparametros.Add(new Parametro("p_fechareserva", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.FechaReserva, 255));
                lparametros.Add(new Parametro("p_pax", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.Pasajero , 255));
                lparametros.Add(new Parametro("p_canthabitaciones", ParameterType.Int32, ParameterDirection.Input, infoSegmentoConfirmado.CantidadHabitaciones));
                lparametros.Add(new Parametro("p_idhotelsrv", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.IdHotelSRV, 255));
                lparametros.Add(new Parametro("p_codigoreservahotel", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.CodigoReservaHotel, 255));
                lparametros.Add(new Parametro("p_idtipohabitacion", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.IdTipoHabitacion, 255));
                lparametros.Add(new Parametro("p_idtipotarifa", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.IdTipoTarifa, 255));
                lparametros.Add(new Parametro("p_pagoen", ParameterType.Int32, ParameterDirection.Input, infoSegmentoConfirmado.PagoEn));
                lparametros.Add(new Parametro("p_idmoneda", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.IdMoneda, 255));
                lparametros.Add(new Parametro("p_importegravado", ParameterType.Decimal, ParameterDirection.Input, infoSegmentoConfirmado.ImporteGravado));
                lparametros.Add(new Parametro("p_importenogravado", ParameterType.Decimal, ParameterDirection.Input, infoSegmentoConfirmado.ImporteNoGravado));
                lparametros.Add(new Parametro("p_importeigv", ParameterType.Decimal, ParameterDirection.Input, infoSegmentoConfirmado.ImporteIGV));
                lparametros.Add(new Parametro("p_codigorazonhotel", ParameterType.Varchar2, ParameterDirection.Input, infoSegmentoConfirmado.CodigoRazonHotel));
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, infoSegmentoConfirmado.DK));
                lparametros.Add(new Parametro("p_rowsaffected", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTAR_INFO_SERV_HOTEL");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return (int.Parse(lparametros.Find("p_rowsaffected").Valor.ToString()) == 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="infoSegmentoConfirmado"></param>
        /// <returns></returns>
        public int? GdsRegistarHotel_CC(Conexion conexion,
                                        string esquema,
                                        RQ_SegmentoConfirmadoHotel infoSegmentoConfirmado)
        {
            Parametros lparametros;
            
            var linfoHotel = infoSegmentoConfirmado.Hotel;
            var ldireccion =  ((linfoHotel.Direccion != null) ? linfoHotel.Direccion.Direcciones[0] : string.Empty);
            var ltelefono = ((linfoHotel.Contacto != null) ? linfoHotel.Contacto.NumerosTelefono[0] : string.Empty);
            var lidPais = ((linfoHotel.Direccion != null) ? linfoHotel.Direccion.CodigoPais : string.Empty);

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_nombre", ParameterType.Varchar2, ParameterDirection.Input, linfoHotel.NombreHotel, 255));
                lparametros.Add(new Parametro("p_razonsocial", ParameterType.Varchar2, ParameterDirection.Input, linfoHotel.NombreHotel, 255));
                lparametros.Add(new Parametro("p_direccion", ParameterType.Varchar2, ParameterDirection.Input, ldireccion, 255));
                lparametros.Add(new Parametro("p_idciudad", ParameterType.Varchar2, ParameterDirection.Input, linfoHotel.CodigoCiudadHotel, 255));
                lparametros.Add(new Parametro("p_idpais", ParameterType.Varchar2, ParameterDirection.Input, lidPais, 255));
                lparametros.Add(new Parametro("p_telefono", ParameterType.Varchar2, ParameterDirection.Input,ltelefono, 255));
                lparametros.Add(new Parametro("p_iddepartamentopta", ParameterType.Varchar2, ParameterDirection.Input, "CTA",  255));
                lparametros.Add(new Parametro("p_idhotel", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_INSERTAR_HOTEL");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return int.Parse(lparametros.Find("p_idhotel").Valor.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="customerId"></param>
        /// <param name="idTipoTabla"></param>
        /// <returns></returns>
        public string GdsObtenerPrefijoRemark(Conexion conexion,
                                              string esquema,
                                              int? customerId, 
                                              string idTipoTabla)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, customerId));
                lparametros.Add(new Parametro("p_idtipotabla", ParameterType.Varchar2, ParameterDirection.Input, idTipoTabla, 255));
                lparametros.Add(new Parametro("p_prefijoremark", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_PREFIJO_REMARK");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return lparametros.Find("p_prefijoremark").Valor != null ? lparametros.Find("p_prefijoremark").Valor.ToString() : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public List<CE_Item> GdsObtenerTiposDeTarifa(Conexion conexion,
                                                     string esquema)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TIPO_TARIFA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToList<CE_Item>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public List<CE_Item> GdsObtenerTiposDeHabitacion(Conexion conexion,
                                                         string esquema)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TIPO_HABITACION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToList<CE_Item>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="departamentoPTA"></param>
        /// <returns></returns>
        public List<CE_Pais> GdsObtenerPaisesHotel(Conexion conexion,
                                                   string esquema,
                                                   string departamentoPTA)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_departamentopta", ParameterType.Varchar2, ParameterDirection.Input, departamentoPTA, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_PAISES_HOTEL");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToList<CE_Pais>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="departamentoPTA"></param>
        /// <param name="idPais"></param>
        /// <returns></returns>
        public List<CE_Ciudad> GdsObtenerCiudadesHotel(Conexion conexion,
                                                       string esquema,
                                                       string departamentoPTA,
                                                       string idPais)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_departamentopta", ParameterType.Varchar2, ParameterDirection.Input, departamentoPTA, 255));
                lparametros.Add(new Parametro("p_idpais", ParameterType.Varchar2, ParameterDirection.Input, idPais, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_CIUDADES_HOTEL");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToList<CE_Ciudad>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="departamentoPTA"></param>
        /// <param name="idCiudad"></param>
        /// <returns></returns>
        public List<CE_HotelPTA> GdsObtenerHotelesPTA(Conexion conexion,
                                                      string esquema,
                                                      string departamentoPTA,
                                                      string idCiudad)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_departamentopta", ParameterType.Varchar2, ParameterDirection.Input, departamentoPTA, 255));
                lparametros.Add(new Parametro("p_idciudad", ParameterType.Varchar2, ParameterDirection.Input, idCiudad, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_HOTEL_DEPARTAMENTO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToList<CE_HotelPTA>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    if (lresultado != null)
                    {
                        lresultado.ForEach(hotel =>
                        {
                            if (string.IsNullOrEmpty(hotel.CodigoCadenaHotelera))
                            {
                                hotel.CodigoCadenaHotelera = "YY";
                            }
                        });
                    }

                    return lresultado;
                }
            }
        }

        #endregion
    }
}
