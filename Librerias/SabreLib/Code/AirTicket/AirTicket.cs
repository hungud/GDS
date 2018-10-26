using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_AirTicketLLS_210;

namespace SabreLib.AirTicket
{
    // =============================
    // clases

    #region "clases"

    public sealed class AirTicket : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public AirTicket(EnumAplicaciones application,
                         CE_Session sesion,
                         string codigoSeguimiento,
                         bool muteErrors = true)
            : base(WebServiceAction.AirTicket, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~AirTicket()
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
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void ProcessResult(AirTicketRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".AirTicketRQ return AirTicketRS null");

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
                estatus.Registrar(response.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="numeroPQ"></param>
        /// <returns></returns>
        private AirTicketRQOptionalQualifiersPricingQualifiersPriceQuote PrepareAirTicketRQ(bool esReemision,
                                                                                            string numeroPQ)
        {
            return new AirTicketRQOptionalQualifiersPricingQualifiersPriceQuote
            {
                Record = new[]
                {
                    new AirTicketRQOptionalQualifiersPricingQualifiersPriceQuoteRecord
                    {
                        Reissue = esReemision,
                        Number = numeroPQ
                    }
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="numeroPQ"></param>
        /// <returns></returns>
        private CE_Estatus Execute(bool esReemision,
                                   string numeroPQ)
        {
            AirTicketRQRequest lairTicketRQRequest = null;
            AirTicketRQResponse lairTicketRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lairTicketRQRequest = new AirTicketRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    AirTicketRQ = new AirTicketRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        OptionalQualifiers = new AirTicketRQOptionalQualifiers
                        {
                            PricingQualifiers = new AirTicketRQOptionalQualifiersPricingQualifiers
                            {
                                PriceQuote = new[]
                                {
                                    PrepareAirTicketRQ(esReemision, numeroPQ)
                                }
                            }
                        }                        
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<AirTicketPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'AirTicketPortTypeChannel.AirTicketRQ'", null, new { lairTicketRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lairTicketRQResponse = lservicio.AirTicketRQ(lairTicketRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'AirTicketPortTypeChannel.AirTicketRQ'", null, new { lairTicketRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lairTicketRQResponse.AirTicketRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, esReemision, numeroPQ, lairTicketRQRequest, lairTicketRQResponse, lrespuesta }, CodigoSeguimiento);

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
        /// <param name="numeroPQ"></param>
        /// <returns></returns>
        public CE_Estatus Emitir(string numeroPQ)
        {
            return Execute(false, numeroPQ);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroPQ"></param>
        /// <returns></returns>
        public CE_Estatus Reemitir(string numeroPQ)
        {
            return Execute(true, numeroPQ);
        }

        #endregion
    }

    #endregion
}
