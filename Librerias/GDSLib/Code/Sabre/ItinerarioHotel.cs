using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Hotel;
using SabreLib.lItinerary;

using GDSLib.Base;
using GDSLib.PTA;

namespace GDSLib.Sabre
{
    public sealed class ItinerarioHotel : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public ItinerarioHotel(EnumAplicaciones aplicacion,
                               string codigoSeguimiento,
                               string codigoEntorno,
                               CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        { 
        }

        public ItinerarioHotel() 
        { 
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="reservaHotel"></param>
        /// <returns></returns>
        public CE_Estatus Obtener(string pnr, 
                                  out CE_ReservaHotel reservaHotel) 
        {
            CE_Estatus lrespuesta;

            try
            {
                using (var lservicio = new GetReservation(Aplicacion.Value, Sesion, CodigoSeguimiento)) 
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lservicio.Prepare'", CodigoSeguimiento);

                    lservicio.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lservicio.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lservicio.ObtenerItinerarioHotel'", new { pnr }, CodigoSeguimiento);

                    lrespuesta = lservicio.ObtenerItinerarioHotel(pnr, out reservaHotel);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lservicio.ObtenerItinerarioHotel'", new { lrespuesta, reservaHotel }, CodigoSeguimiento);

                    if (lrespuesta.Ok) 
                    {
                        var lhotel = new Hotel(CodigoSeguimiento, CodigoEntorno);

                        lhotel.Prepare();
                        lhotel.PreCompletarReservaConPrefijoRemark(reservaHotel);
                    }
                }

            }
            catch (Exception ex) 
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pnr }, CodigoSeguimiento);

                reservaHotel = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
