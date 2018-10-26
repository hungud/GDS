using System;
using System.Collections.Generic;
using System.Web.Http;

using CustomLog;

using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using EntidadesGDS.Hotel;
using EntidadesGDS.Models.Hotel;
using GDSLib.Sabre;
using GDSLib.PTA;

namespace ServiciosGDS.Controllers
{
    public class ServicioItinerarioHotelController : BaseController
    {
        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("Obtener")]
        public CE_Response3<CE_ReservaHotel> Obtener(CE_Request3<string> request)
        {
            var lrespuesta = new CE_Response3<CE_ReservaHotel>();
            try
            {
                using (var litinerarioHotel = new ItinerarioHotel(request.Aplicacion.Value, 
                                                                  request.CodigoSeguimiento, 
                                                                  request.CodigosEntorno, 
                                                                  request.Sesion)) {
                    litinerarioHotel.Prepare();
                    CE_ReservaHotel lreservaHotel;
                    lrespuesta.Estatus = litinerarioHotel.Obtener(request.Parametros, out lreservaHotel);
                    lrespuesta.Resultado = lreservaHotel;
                }
            }
            catch (Exception ex) 
            {
                Bitacora.Current.Error(ex, new { request });
                lrespuesta = new CE_Response3<CE_ReservaHotel>(ex);
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerTipoHabitacionHotel")]
        public CE_Response1<List<CE_Item>> ObtenerTiposHabitacion(CE_Request1 request)
        {
            var lrespuesta = new CE_Response1<List<CE_Item>>();
            try
            {
                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    List<CE_Item> ltiposHabitacion;
                    lrespuesta.Estatus = lhotel.ObtenerTiposHabitacion(out ltiposHabitacion);
                    lrespuesta.Resultado = ltiposHabitacion;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_Item>>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerTiposTarifaHotel")]
        public CE_Response1<List<CE_Item>> ObtenerTiposTarifa(CE_Request1 request)
        {
            var lrespuesta = new CE_Response1<List<CE_Item>>();
            try
            {
                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    List<CE_Item> ltiposTarifa;
                    lrespuesta.Estatus = lhotel.ObtenerTipoTarifaHotel(out ltiposTarifa);
                    lrespuesta.Resultado = ltiposTarifa;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_Item>>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerPaisHotel")]
        public CE_Response1<List<CE_Pais>> ObtenerPaisHotel(CE_Request2<string> request)
        {
            var lrespuesta = new CE_Response1<List<CE_Pais>>();
            try
            {
                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    List<CE_Pais> lpaisesHotel;
                    lrespuesta.Estatus = lhotel.ObtenerPaisesHotel(request.Parametros, out lpaisesHotel);
                    lrespuesta.Resultado = lpaisesHotel;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_Pais>>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerCiudadesPorCodigo")]
        public CE_Response1<List<CE_Ciudad>> ObtenerCiudadesHotelPorCodigo(CE_Request2<string[]> request)
        {
            var lrespuesta = new CE_Response1<List<CE_Ciudad>>();
            try
            {
                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    List<CE_Ciudad> lciudadesHotel;
                    lrespuesta.Estatus = lhotel.ObtenerCiudadesPorCodigo(request.Parametros, out lciudadesHotel);
                    lrespuesta.Resultado = lciudadesHotel;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_Ciudad>>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerCiudadesHotel")]
        public CE_Response1<List<CE_Ciudad>> ObtenerCiudadesHotel(CE_Request2<string[]> request)
        {
            var lrespuesta = new CE_Response1<List<CE_Ciudad>>();
            try
            {
                if (request.Parametros.Length != 2) {
                    throw new Exception("Es necesario enviar el departamento y el país!");
                }

                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    List<CE_Ciudad> lciudadesHotel;
                    lrespuesta.Estatus = lhotel.ObtenerCiudadesHotel(request.Parametros[0], request.Parametros[1], out lciudadesHotel);
                    lrespuesta.Resultado = lciudadesHotel;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_Ciudad>>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ObtenerHotelesPorDepartamento")]
        public CE_Response1<List<CE_HotelPTA>> ObtenerHotelesPorDepartamento(CE_Request2<string[]> request)
        {
            var lrespuesta = new CE_Response1<List<CE_HotelPTA>>();
            try
            {
                if (request.Parametros.Length != 2)
                {
                    throw new Exception("Es necesario enviar el departamento y la ciudad!");
                }

                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    List<CE_HotelPTA> lhoteles;
                    lrespuesta.Estatus = lhotel.ObtenerHotelesPTA(request.Parametros[0], request.Parametros[1], out lhoteles);
                    lrespuesta.Resultado = lhoteles;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });
                lrespuesta = new CE_Response1<List<CE_HotelPTA>>(ex) { Resultado = null };
            }
            return lrespuesta;
        }

        [HttpPost]
        [ActionName("RegistrarSegmentoConfirmado")]
        public CE_Response3<bool> RegistrarSegmentoConfirmado(CE_Request3<RQ_SegmentoConfirmadoHotel> request)
        {
            var lrespuesta = new CE_Response3<bool>();

            try
            {
                using (var lhotel = new Hotel(request.CodigoSeguimiento, request.CodigosEntorno))
                {
                    lhotel.Prepare();
                    bool lresultado;
                    lrespuesta.Estatus = lhotel.RegistrarSegmentoConfirmadoHotel(request.Parametros, out lresultado);
                    lrespuesta.Resultado = lresultado;
                }
            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                // actualizando respuesta
                lrespuesta = new CE_Response3<bool>(ex) { Resultado = false };
            }

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("RegistrarSegmentoGK")]
        public CE_Response3<bool> RegistrarSegmentoGK(CE_Request3<RQ_SegmentoGK> request)
        {
            var lrespuesta = new CE_Response3<bool>();
            try
            {
                using (var lhotel = new HotelGK(request.Aplicacion, request.CodigoSeguimiento, request.CodigosEntorno, request.Sesion))
                {
                    lhotel.Prepare();
                    lrespuesta.Estatus = lhotel.ProcesarSegmentoGK(request.Parametros);
                    lrespuesta.Resultado = lrespuesta.Estatus.Ok;
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { request, lrespuesta });

                lrespuesta = new CE_Response3<bool>(ex) { Resultado = false };
            }
            return lrespuesta;
        }

        #endregion
    }
}
