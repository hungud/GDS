using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using KiuLib.Itinerary;

using GDSLib.Base;

namespace GDSLib.Kiu
{
    public sealed class Itinerario : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public Itinerario(EnumAplicaciones aplicacion,
                          string codigoSeguimiento,
                          string codigoEntorno,
                          CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        public Itinerario(EnumAplicaciones aplicacion,
                          string codigoSeguimiento,
                          string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, null)
        {
        }

        public Itinerario()
        {
        }

        ~Itinerario()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        public CE_Estatus Obtener(string pnr,
                                  out CE_Reserva reserva,
                                  bool completar = false)
        {
            var lrespuesta = new CE_Estatus();

            try
            {
                // instanciando objeto
                using (var ltravelItineraryRead = new TravelItineraryRead(Aplicacion.Value, CodigoSeguimiento))
                {
                    ltravelItineraryRead.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.ObtenerItinerario'", new { pnr, EnumTypeTravelItineraryReadKiu.Itinetario }, CodigoSeguimiento);

                    ltravelItineraryRead.ObtenerItinerario(pnr, EnumTypeTravelItineraryReadKiu.Itinetario, 1, out reserva);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.ObtenerItinerario'", new { reserva }, CodigoSeguimiento);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { pnr, completar }, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pnr, completar }, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
