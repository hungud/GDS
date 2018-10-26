using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Fare_PricePNRWithBookingClass.Request;
using AmadeusLib.Servicios.Fare_PricePNRWithBookingClass.Response;

namespace AmadeusLib.Fare
{
    public sealed class FarePricePNRWithBookingClass : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_FarePricePNRWithBookingClass;

        private static readonly object _sync_FarePricePNRWithBookingClass = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public FarePricePNRWithBookingClass(EnumAplicaciones? application,
                                            string codigoSeguimiento,
                                            bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~FarePricePNRWithBookingClass()
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
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(ref CE_Session session)
        {
            Fare_PricePNRWithBookingClass lfarePricerPNRWithBookingClassRequest = null;
            Fare_PricePNRWithBookingClassReply lfarePricerPNRWithBookingClassResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lfarePricerPNRWithBookingClassRequest, session }, CodigoSeguimiento);

                lock (_sync_FarePricePNRWithBookingClass)
                {
                    // procesando solicitud
                    lfarePricerPNRWithBookingClassResponse = Execute<Fare_PricePNRWithBookingClass, Fare_PricePNRWithBookingClassReply>(
                        WebServiceActionHeader4.FarePricePNRWithBookingClass,
                        ((TransactionType) session.AmadeusTransactionType),
                        lfarePricerPNRWithBookingClassRequest, 
                        ref session,
                        ref _serialiazer_FarePricePNRWithBookingClass);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lfarePricerPNRWithBookingClassResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lfarePricerPNRWithBookingClassResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lfarePricerPNRWithBookingClassRequest, lfarePricerPNRWithBookingClassResponse }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
