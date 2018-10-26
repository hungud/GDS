using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_SpecialServiceLLS_221;

namespace SabreLib.lItinerary
{
    public sealed class SpecialService : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public SpecialService(EnumAplicaciones application,
                              CE_Session sesion,
                              string codigoSeguimiento,
                              bool muteErrors = true)
            : base(WebServiceAction.SpecialService, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~SpecialService()
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
        /// <returns></returns>
        private SpecialServiceRQSpecialServiceInfoSecureFlight PrepareSpecialServiceRQSpecialServiceInfoSecureFlight(RQ_AnadirServicioEspecial parametros)
        {
            var lresultado = new SpecialServiceRQSpecialServiceInfoSecureFlight
            {
                SegmentNumber = "A",
                PersonName = new SpecialServiceRQSpecialServiceInfoSecureFlightPersonName
                {
                    NameNumber = parametros.Pasajero.NumeroPasajero,
                    GenderSpecified = true,
                    Gender = ((SpecialServiceRQSpecialServiceInfoSecureFlightPersonNameGender) Enum.Parse(typeof(SpecialServiceRQSpecialServiceInfoSecureFlightPersonNameGender), parametros.Pasajero.Sexo.ToString())),
                    GivenName = parametros.Pasajero.Nombre,
                    Surname = parametros.Pasajero.Apellido,
                    DateOfBirth = parametros.Pasajero.FechaNacimiento
                }
            };

            if (parametros.AmericanAirlines.HasValue)
            {
                lresultado.VendorPrefs = new SpecialServiceRQSpecialServiceInfoSecureFlightVendorPrefs
                {
                    Airline = new SpecialServiceRQSpecialServiceInfoSecureFlightVendorPrefsAirline
                    {
                        Hosted = parametros.AmericanAirlines.Value,
                        HostedSpecified = parametros.AmericanAirlines.Value
                    }
                };
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void ProcessResult(SpecialServiceRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".SpecialServiceRQ return SpecialServiceRS null");

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
        /// <param name="parametros"></param>
        /// <returns></returns>
        private CE_Estatus Execute(RQ_AnadirServicioEspecial parametros)
        {
            SpecialServiceRQRequest lspecialServiceRQRequest = null;
            SpecialServiceRQResponse lspecialServiceRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lspecialServiceRQRequest = new SpecialServiceRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    SpecialServiceRQ = new SpecialServiceRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        SpecialServiceInfo = new SpecialServiceRQSpecialServiceInfo
                        {
                            SecureFlight = new[] { PrepareSpecialServiceRQSpecialServiceInfoSecureFlight(parametros) }
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<SpecialServicePortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'SpecialServicePortTypeChannel.SpecialServiceRQ'", new { lspecialServiceRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lspecialServiceRQResponse = lservicio.SpecialServiceRQ(lspecialServiceRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'SpecialServicePortTypeChannel.SpecialServiceRQ'", new { lspecialServiceRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lspecialServiceRQResponse.SpecialServiceRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lspecialServiceRQRequest, lspecialServiceRQResponse, lrespuesta }, CodigoSeguimiento);

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
        /// <param name="esAmericanAirlines"></param>
        /// <param name="pasajero"></param>
        /// <returns></returns>
        public CE_Estatus InsertarDocs(bool esAmericanAirlines, 
                                       CE_Pasajero pasajero)
        {
            return Execute(new RQ_AnadirServicioEspecial
            {
                AmericanAirlines = esAmericanAirlines,
                Pasajero = pasajero,
            });
        }

        #endregion
    }
}
