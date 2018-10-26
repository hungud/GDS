using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_TravelItineraryModifyInfoLLS_211;

namespace SabreLib.lItinerary
{
    /// <summary>
    /// A pesar de que el servicio "TravelItineraryModifyInfo" permite la modificación de nombres de un pasajero ¡¡ JAMAS DEBE DE USARSE CON ESE FIN !!
    /// </summary>
    public sealed class TravelItineraryModifyInfo : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service1, MessageData>
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="sesion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public TravelItineraryModifyInfo(EnumAplicaciones application,
                                         CE_Session sesion,
                                         string codigoSeguimiento,
                                         bool muteErrors = true)
            : base(WebServiceAction.TravelItineraryModifyInfo, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~TravelItineraryModifyInfo()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "Prepare"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="pasajero"></param>
        /// <returns></returns>
        private TravelItineraryModifyInfoRQCustomerInfoPersonName PreparePassenger(RQ_ActualizarPasajeros parametros,
                                                                                   CE_Pasajero pasajero)
        {
            var lpersonName = new TravelItineraryModifyInfoRQCustomerInfoPersonName();

            if (!string.IsNullOrWhiteSpace(pasajero.TipoPasajero.IdTipoPasajero))
            {
                lpersonName.NameNumber = pasajero.NumeroPasajero;
                lpersonName.PassengerType = pasajero.TipoPasajero.IdTipoPasajero;
            }

            lpersonName.RPH = pasajero.NumeroPasajero;

            if (!string.IsNullOrWhiteSpace(pasajero.RUC))
            {
                lpersonName.NameReference = (
                        "RUC" + (string.IsNullOrWhiteSpace(parametros.NumeroComprobante) ? pasajero.RUC : string.Format("{0}-{1}", pasajero.RUC, parametros.NumeroComprobante))
                    );

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(pasajero.NumeroDocumento))
                {
                    var ltipoDocumento = ((pasajero.TipoDocumento == EnumTipoDocumento.DNI) ? "D" : ((pasajero.TipoDocumento == EnumTipoDocumento.CarnetExtranjeria) ? "CE" : "PP"));

                    lpersonName.NameReference = (
                            ltipoDocumento + (string.IsNullOrWhiteSpace(parametros.NumeroComprobante) ? pasajero.NumeroDocumento : string.Format("{0}-{1}", pasajero.NumeroDocumento, parametros.NumeroComprobante))
                        );                    
                }
            }

            return lpersonName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        private TravelItineraryModifyInfoRQCustomerInfo PrepareCustomerInfo(RQ_ActualizarPasajeros parametros)
        {
            return new TravelItineraryModifyInfoRQCustomerInfo
            {
                CustomerIdentifier = (
                        (parametros.IdCliente.HasValue 
                            ? new TravelItineraryModifyInfoRQCustomerInfoCustomerIdentifier { Identifier = string.Format("{0:0000000}",  parametros.IdCliente) } 
                            : null)
                    ),

                PersonName = parametros.Pasajeros.Select(p => PreparePassenger(parametros, p)).ToArray()
            };
        }

        #endregion

        #region "Validate"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private void ValidatePreExecute(TravelItineraryModifyInfoRQRequest request)
        {
            // evaluando si se esta intentando actualizar los nombres o apellidos de los pasajeros
            if (request.TravelItineraryModifyInfoRQ.CustomerInfo.PersonName
                .Any(p => (!string.IsNullOrWhiteSpace(p.GivenName)) || (!string.IsNullOrWhiteSpace(p.Surname))))
            {
                // forzando excepción
                throw new InternalException("¡¡ La actualización de los Nombres/Apellidos de los pasajeros esta PROHIBIDA !!");
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void ProcessResult(TravelItineraryModifyInfoRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".TravelItineraryModifyInfoRQ return TravelItineraryModifyInfoRS null");

                return;
            }

            if ((response.ApplicationResults.Error != null) && (response.ApplicationResults.Error.Any()))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarErrores(
                    response.ApplicationResults.Error
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );

                return;
            }

            if ((response.ApplicationResults.Warning != null) && (response.ApplicationResults.Warning.Any()))
            {
                // actualizando respuesta (warnings)
                estatus.RegistrarAlertas(
                    response.ApplicationResults.Warning
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );
            }

            if (response.ApplicationResults.status == CompletionCodes.Complete)
            {
                // actualizando respuesta
                estatus.Ok = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public CE_Estatus Execute(RQ_ActualizarPasajeros parametros)
        {
            TravelItineraryModifyInfoRQRequest ltravelItineraryModifyInfoRQRequest = null;
            TravelItineraryModifyInfoRQResponse ltravelItineraryModifyInfoRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                ltravelItineraryModifyInfoRQRequest = new TravelItineraryModifyInfoRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    TravelItineraryModifyInfoRQ = new TravelItineraryModifyInfoRQ
                    {
                        ReturnHostCommand = "true",
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        CustomerInfo = PrepareCustomerInfo(parametros)
                    }
                };

                // realizando validaciones antes de procesar la solicitud
                ValidatePreExecute(ltravelItineraryModifyInfoRQRequest);

                using (var lservicio = Configuracion.GetServiceModelClient<TravelItineraryModifyInfoPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'TravelItineraryModifyInfoPortTypeChannel.TravelItineraryModifyInfoRQ'", new { ltravelItineraryModifyInfoRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    ltravelItineraryModifyInfoRQResponse = lservicio.TravelItineraryModifyInfoRQ(ltravelItineraryModifyInfoRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'TravelItineraryModifyInfoPortTypeChannel.TravelItineraryModifyInfoRQ'", new { ltravelItineraryModifyInfoRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(ltravelItineraryModifyInfoRQResponse.TravelItineraryModifyInfoRS, out lrespuesta);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { MuteErrors, parametros, ltravelItineraryModifyInfoRQRequest, ltravelItineraryModifyInfoRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, parametros, ltravelItineraryModifyInfoRQRequest, ltravelItineraryModifyInfoRQResponse, lrespuesta }, CodigoSeguimiento);

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
