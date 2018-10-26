using System;
using System.Linq;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.PNR_Cancel.Request;
using AmadeusLib.Servicios.PNR_Reply.Response;

namespace AmadeusLib.PNR
{
    // =============================
    // emnumeraciones

    #region "emnumeraciones"

    public enum ActionCode
    {
        NO_ESPECIAL_PROCESSING = 0,        // ejecuta sin un procesamiento especial
        END_TRANSACTION = 10,              // ejecuta y graba
        END_TRANSACTION_AND_RETRIEVE = 11  // ejecuta, graba y recupera   
    }

    #endregion

    public sealed class PnrCancel : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_PnrCancel;

        private static readonly object _sync_PnrCancel = new object();

        #endregion

        // =============================
        // constantes

        #region "constantes"

        private const string TYPE_CANCEL_ELEMENTS = "E";
        private const string TYPE_CANCEL_ITINERARY = "I";
        private const string TYPE_ELEMENT_OTHERS = "OT";
        private const string TYPE_ELEMENT_SEGMENT = "ST";

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public PnrCancel(EnumAplicaciones? application,
                           string codigoSeguimiento,
                           bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }


        ~PnrCancel()
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
        /// <returns></returns>
        private PNR_Cancel ConstruirRequestCancelarTodoItinerario()
        {
            return new PNR_Cancel
            {
                cancelElements = new[] 
                {
                    new PNR_CancelCancelElements
                    {
                        entryType = TYPE_CANCEL_ITINERARY
                    }
                },
                pnrActions = new decimal[] { ((int) ActionCode.END_TRANSACTION) }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <param name="canceladoCorrectamente"></param>
        /// <returns></returns>
        private void ProcessResult(PNR_Reply response,
                                   out CE_Estatus estatus,
                                   out bool canceladoCorrectamente)
        {
            canceladoCorrectamente = false;
            estatus = new CE_Estatus();

            if (response == null)
            {
                estatus.RegistrarError(".Execute return PNR_Reply null ");
                return;
            }

            if (response.generalErrorInfo != null)
            {
                estatus.RegistrarErrores(response.generalErrorInfo.SelectMany(s => s.messageErrorText.text));
                return;
            }

            estatus.Ok = true;
            canceladoCorrectamente = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="type"></param>
        /// <param name="actionCode"></param>
        /// <param name="session"></param>
        /// <param name="ejecucionCorrecta"></param>
        /// <returns></returns>
        private CE_Estatus Execute(string[] items, 
                                   string type, 
                                   ActionCode actionCode, 
                                   ref CE_Session session, 
                                   out bool ejecucionCorrecta)
        {
            PNR_Cancel lpnrCancelRQ = null;
            PNR_Reply lpnrCancelRS = null;

            CE_Estatus lrespuesta;

            ejecucionCorrecta = false;

            try
            {
                var lelementsDelete = items
                    .Select(item => new PNR_CancelCancelElementsElement
                    {
                        identifier = type,
                        number = decimal.Parse(item),
                        numberSpecified = true
                    }).ToArray();

                lpnrCancelRQ = new PNR_Cancel
                {
                    cancelElements = new[] 
                    {
                        new PNR_CancelCancelElements
                        {
                            entryType = TYPE_CANCEL_ELEMENTS,
                            element = lelementsDelete
                        }
                    },
                    pnrActions = new decimal[] { ((int) actionCode) }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lpnrCancelRQ, session }, CodigoSeguimiento);

                lock (_sync_PnrCancel)
                {
                    // procesando solicitud
                    lpnrCancelRS = Execute<PNR_Cancel, PNR_Reply>(
                        WebServiceActionHeader4.PNRCancel,
                        ((TransactionType) session.AmadeusTransactionType),
                        lpnrCancelRQ, 
                        ref session,
                        ref _serialiazer_PnrCancel);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lpnrCancelRS, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lpnrCancelRS, out lrespuesta, out ejecucionCorrecta);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lpnrCancelRQ, lpnrCancelRS }, CodigoSeguimiento);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numerosLineaElementos"></param>
        /// <param name="session"></param>
        /// <param name="resultadoEjecucion"></param>
        /// <param name="ejecutarEndTransaction"></param>
        /// <returns></returns>
        public CE_Estatus CancelarElementosItinerario(string[] numerosLineaElementos,
                                                      ref CE_Session session,
                                                      out bool resultadoEjecucion,
                                                      bool ejecutarEndTransaction = false)
        {
            var lactionCode = (ejecutarEndTransaction ? ActionCode.END_TRANSACTION : ActionCode.NO_ESPECIAL_PROCESSING);

            return Execute(numerosLineaElementos, TYPE_ELEMENT_OTHERS, lactionCode, ref session, out resultadoEjecucion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numerosLineaSegmentos"></param>
        /// <param name="session"></param>
        /// <param name="resultadoEjecucion"></param>
        /// <param name="ejecutarEndTransaction"></param>
        /// <returns></returns>
        public CE_Estatus CancelarSegmentosItinerario(string[] numerosLineaSegmentos,
                                                      ref CE_Session session,
                                                      out bool resultadoEjecucion,
                                                      bool ejecutarEndTransaction = false)
        {
            var lactionCode = (ejecutarEndTransaction ? ActionCode.END_TRANSACTION : ActionCode.NO_ESPECIAL_PROCESSING);

            return Execute(numerosLineaSegmentos, TYPE_ELEMENT_SEGMENT, lactionCode, ref session, out resultadoEjecucion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="resultadoEjecucion"></param>
        /// <returns></returns>
        public CE_Estatus CancelarTodoItinerario(ref CE_Session session,
                                                 out bool resultadoEjecucion)
        {
            CE_Estatus lrespuesta;

            var lpnrCancelRQ = ConstruirRequestCancelarTodoItinerario();

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lpnrCancelRQ, session }, CodigoSeguimiento);

            // procesando solicitud
            var lpnrCancelRS = Execute<PNR_Cancel, PNR_Reply>(
                WebServiceActionHeader4.PNRCancel,
                ((TransactionType) session.AmadeusTransactionType),
                lpnrCancelRQ, 
                ref session,
                ref _serialiazer_PnrCancel);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lpnrCancelRS, session }, CodigoSeguimiento);

            // actualizando respuesta
            ProcessResult(lpnrCancelRS, out lrespuesta, out resultadoEjecucion);

            return lrespuesta;
        }

        #endregion
    }
}
