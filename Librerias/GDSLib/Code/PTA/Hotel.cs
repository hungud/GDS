using System;
using System.Collections.Generic;
using System.Linq;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Hotel;
using EntidadesGDS.Models.Hotel;
using BaseDatosLib.Paquetes;

using GDSLib.Base;

namespace GDSLib.PTA
{
    public sealed class Hotel : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public Hotel(string codigoSeguimiento,
                                    string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public Hotel(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~Hotel()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus RegistrarSegmentoConfirmadoHotel(RQ_SegmentoConfirmadoHotel parametros,
                                                           out bool resultado,
                                                           bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsRegistarHotel_CC'", new { parametros }, CodigoSeguimiento);

                    var lidHotel = lpkgGdsHotelesCc.GdsRegistarHotel_CC(Conexion, Esquema, parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsRegistarHotel_CC'", new { lidHotel }, CodigoSeguimiento);

                    if (lidHotel != null)
                    {
                        parametros.IdHotelSRV = lidHotel;

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsRegistarSegmentoConfirmadoHotel'", new { parametros }, CodigoSeguimiento);

                        resultado = lpkgGdsHotelesCc.GdsRegistarSegmentoConfirmadoHotel(Conexion, Esquema, parametros);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsRegistarSegmentoConfirmadoHotel'", new { resultado }, CodigoSeguimiento);

                        lrespuesta.Ok = resultado;

                    }
                    else
                    {
                        lrespuesta.Ok = false;
                        lrespuesta.RegistrarErrores(new[] { "Ocurrió un error al registrar hotel CTA." });
                    }
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerTipoTarifaHotel(out List<CE_Item> resultado)
        {
            var lrespuesta = new CE_Estatus(false);

            resultado = null;

            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsObtenerTiposDeTarifa'", CodigoSeguimiento);

                    var ltiposTarifa = lpkgGdsHotelesCc.GdsObtenerTiposDeTarifa(Conexion, Esquema);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsObtenerTiposDeTarifa'", new { ltiposTarifa }, CodigoSeguimiento);

                    lrespuesta.Ok = true;

                    // actualizando respuesta
                    resultado = ltiposTarifa;
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerTiposHabitacion(out List<CE_Item> resultado)
        {
            var lrespuesta = new CE_Estatus(false);

            resultado = null;

            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsObtenerTiposDeHabitacion'", CodigoSeguimiento);

                    var ltiposHabitacion = lpkgGdsHotelesCc.GdsObtenerTiposDeHabitacion(Conexion, Esquema);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsObtenerTiposDeHabitacion'", new { ltiposHabitacion }, CodigoSeguimiento);

                    lrespuesta.Ok = true;

                    resultado = ltiposHabitacion;
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departamentoPTA"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerPaisesHotel(string departamentoPTA, 
                                             out List<CE_Pais> resultado)
        {
            var lrespuesta = new CE_Estatus(false);

            resultado = null;

            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsObtenerPaisesHotel'", new { departamentoPTA }, CodigoSeguimiento);

                    var lpaisesHotel = lpkgGdsHotelesCc.GdsObtenerPaisesHotel(Conexion, Esquema, departamentoPTA);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsObtenerPaisesHotel'", new { lpaisesHotel }, CodigoSeguimiento);

                    lrespuesta.Ok = true;

                    resultado = lpaisesHotel;
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigosCiudad"></param>
        /// <param name="resultadoCiudades"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerCiudadesPorCodigo(string[] codigosCiudad,
                                                   out List<CE_Ciudad> resultadoCiudades)
        {
            var lrespuesta = new CE_Estatus(true);

            resultadoCiudades = null;

            try
            {
                using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
                {
                    var lcodigosCiudades = string.Join(",", codigosCiudad);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerCiudad'", new { lcodigosCiudades }, CodigoSeguimiento);

                    // buscando información de las ciudades de los segmentos
                    resultadoCiudades = lpkgGdsModuloPnrPta.GdsObtenerCiudad(Conexion, Esquema, lcodigosCiudades);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerCiudad'", new { resultadoCiudades }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departamentoPTA"></param>
        /// <param name="pais"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerCiudadesHotel(string departamentoPTA, 
                                              string pais, 
                                              out List<CE_Ciudad> resultado)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsObtenerCiudadesHotel'", new { departamentoPTA, pais }, CodigoSeguimiento);

                    var lciudadesHotel = lpkgGdsHotelesCc.GdsObtenerCiudadesHotel(Conexion, Esquema, departamentoPTA, pais);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsObtenerCiudadesHotel'", new { lciudadesHotel }, CodigoSeguimiento);

                    var lcodigosCiudades = lciudadesHotel.Select(s => s.IdCiudad).ToArray();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.ObtenerCiudadesPorCodigo'", new { lcodigosCiudades }, CodigoSeguimiento);

                    ObtenerCiudadesPorCodigo(lcodigosCiudades, out resultado);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.ObtenerCiudadesPorCodigo'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departamentoPTA"></param>
        /// <param name="idCiudad"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerHotelesPTA(string departamentoPTA, 
                                            string idCiudad, 
                                            out List<CE_HotelPTA> resultado)
        {
            var lrespuesta = new CE_Estatus(false);

            resultado = null;

            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsObtenerHotelesPTA'", new { departamentoPTA, idCiudad }, CodigoSeguimiento);

                    var lhotelesPTA = lpkgGdsHotelesCc.GdsObtenerHotelesPTA(Conexion, Esquema, departamentoPTA, idCiudad);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsObtenerHotelesPTA'", new { lhotelesPTA }, CodigoSeguimiento);

                    lrespuesta.Ok = true;

                    resultado = lhotelesPTA;
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <returns></returns>
        public void PreCompletarReservaConPrefijoRemark(CE_ReservaHotel parametro)
        {
            try
            {
                using (var lpkgGdsHotelesCc = new PkgGdsHotelesCC(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsHotelesCc.GdsObtenerPrefijoRemark'", new { parametro.CustomerId }, CodigoSeguimiento);

                    var prefijo = lpkgGdsHotelesCc.GdsObtenerPrefijoRemark(Conexion, Esquema, parametro.CustomerId, "HOT");

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsHotelesCc.GdsObtenerPrefijoRemark'", new { prefijo }, CodigoSeguimiento);

                    parametro.PrefijoRemarkHotel = prefijo;
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametro }, CodigoSeguimiento);

                throw;
            }
        }

        #endregion
    }
}
