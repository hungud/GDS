using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;

using AmadeusLib.Base;
using AmadeusLib.Servicios.PNR_Retrieve.Request;
using AmadeusLib.Servicios.PNR_Reply.Response;

namespace AmadeusLib.PNR
{
    public sealed class PnrRetrieve : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_PNR_Retrieve;

        private static readonly object _sync_PNR_Retrieve = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public PnrRetrieve(EnumAplicaciones application,
                           string codigoSeguimiento,
                           bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        {
        }

        ~PnrRetrieve()
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
        /// <param name="reserva"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(RQ_ObtenerReserva parametros,
                                  out CE_Reserva reserva,
                                  ref CE_Session session)
        {
            PNR_Retrieve lpnrRetrieveRequest = null;
            PNR_Reply lpnrReplyResponse = null;

            CE_Estatus lrespuesta;

            reserva = null;

            try
            {
                // construyendo request
                lpnrRetrieveRequest = new PNR_Retrieve
                {
                    retrievalFacts = new PNR_RetrieveRetrievalFacts
                    {
                        retrieve = new PNR_RetrieveRetrievalFactsRetrieve
                        {
                            type = "2"
                        },
                        reservationOrProfileIdentifier = new PNR_RetrieveRetrievalFactsReservationOrProfileIdentifier
                        {
                            reservation = new PNR_RetrieveRetrievalFactsReservationOrProfileIdentifierReservation
                            {
                                controlNumber = parametros.PNR
                            }
                        }
                    }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lpnrRetrieveRequest }, CodigoSeguimiento);

                lock (_sync_PNR_Retrieve)
                {
                    // procesando solicitud
                    lpnrReplyResponse = Execute<PNR_Retrieve, PNR_Reply>(
                        WebServiceActionHeader4.PnrRetrieve, 
                        ((TransactionType)session.AmadeusTransactionType), 
                        lpnrRetrieveRequest, 
                        ref session, 
                        ref _serialiazer_PNR_Retrieve);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lpnrReplyResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lpnrReplyResponse, parametros, ref session, out lrespuesta, out reserva);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, parametros, lpnrRetrieveRequest, lpnrReplyResponse }, CodigoSeguimiento);

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
