using AmadeusLib.Fare;
using CustomLog;
using EntidadesGDS;
using EntidadesGDS.Base;
using GDSLib.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSLib.Code.Amadeus
{
    public sealed class InstantSearch: Common2
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
        public InstantSearch(EnumAplicaciones aplicacion,
                       string codigoSeguimiento,
                       string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno)
        {
        }

        public InstantSearch()
        {
        }

        ~InstantSearch()
        {
            Dispose(false);
        }

        #endregion

        #region "metodos"

        // =============================
        // metodos

        #region "Obtener"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="reserva"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Obtener(string request,
                                  ref CE_Session session)
        {
            CE_Estatus lrespuesta;
            try
            {
                // instanciando objeto
                using (var linstantTravelBoard = new FareInstantTravelBoardSearch(Aplicacion.Value, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'PnrRetrieve.Execute'", CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = linstantTravelBoard.Execute(ref session, request);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'PnrRetrieve.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }
            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        #endregion

        #endregion

    }
}
