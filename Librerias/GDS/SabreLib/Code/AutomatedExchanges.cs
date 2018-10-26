using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_AutomatedExchangesLLS_261;

namespace SabreLib
{
    public sealed class AutomatedExchanges : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
    {
        // =============================
        // emnumeraciones

        #region "emnumeraciones"

        internal enum EnumAutomatedExchangeType
        {
            Comparison = 1,
            Confirmation = 2
        }

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="sesion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public AutomatedExchanges(EnumAplicaciones application,
                                  CE_Session sesion,
                                  string codigoSeguimiento)
            : base(WebServiceAction.AutomatedExchange, application, sesion, codigoSeguimiento)
        {
        }

        ~AutomatedExchanges()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /*
        private AutomatedExchangesRQExchangeComparison PrepareComparisonRQRequest(AutomatedExchangesRQRequest request)
        {
            var lsegmentosBranded = new List<AutomatedExchangesRQExchangeComparisonExchangeSegment>();
            var lsegmentosSeleccionados = new List<AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersSegmentSelect>();

            // segmentoas con branded
            foreach (var lsegmento in request.objCalificadores.lstSegmentos)
            {
                //lsegmentosBranded.Add(new AutomatedExchangesRQExchangeComparisonExchangeSegment
                //{
                //    SegmentNumber = lsegmento,
                //    PriceRequestInformation = new AutomatedExchangesRQExchangeComparisonExchangeSegmentPriceRequestInformation
                //    {
                //        OptionalQualifiers = new AutomatedExchangesRQExchangeComparisonExchangeSegmentPriceRequestInformationOptionalQualifiers
                //        {
                //            PricingQualifiers = new AutomatedExchangesRQExchangeComparisonExchangeSegmentPriceRequestInformationOptionalQualifiersPricingQualifiers
                //            {
                //                Brand = "SL"
                //            }
                //        }
                //    }
                //});

                lsegmentosSeleccionados.Add(new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersSegmentSelect
                {
                    Number = lsegmento
                });
            }

            var lpricingQualifiers = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiers
            {
                ItineraryOptions = lsegmentosSeleccionados.ToArray(),
                FareOptions = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersFareOptions
                {
                    Public = (request.objCalificadores.enuTipoTarifa == CE_TipoTarifa.PL),
                    PublicSpecified = (request.objCalificadores.enuTipoTarifa == CE_TipoTarifa.PL),
                    Private = (request.objCalificadores.enuTipoTarifa == CE_TipoTarifa.PV),
                    PrivateSpecified = (request.objCalificadores.enuTipoTarifa == CE_TipoTarifa.PV)
                },
                NameSelect = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersNameSelect
                {
                    NameNumber = request.objCalificadores.strIdPassenger
                },
                PassengerType = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersPassengerType
                {
                    Code = request.objCalificadores.objPassengerType.IdTipoPax
                }
            };

            if (!string.IsNullOrWhiteSpace(request.objCalificadores.strAccount))
            {
                lpricingQualifiers.Account = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersAccount
                {
                    Code = request.objCalificadores.strAccount
                };
            }

            if (!string.IsNullOrWhiteSpace(request.objCalificadores.strCorporateId))
            {
                lpricingQualifiers.Corporate = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersPricingQualifiersCorporate
                {
                    ID = request.objCalificadores.strCorporateId
                };
            }

            var loptionalQualifiers = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiers
            {
                FlightQualifiers = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersFlightQualifiers
                {
                    VendorPrefs = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersFlightQualifiersVendorPrefs
                    {
                        Airline = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersFlightQualifiersVendorPrefsAirline
                        {
                            Code = request.objCalificadores.objTransportador.strCodigoAerolinea
                        }
                    }
                },
                PricingQualifiers = lpricingQualifiers
            };

            if (!string.IsNullOrWhiteSpace(request.objCalificadores.strTourCode))
            {
                loptionalQualifiers.MiscQualifiers = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersMiscQualifiers
                {
                    TourCode = new AutomatedExchangesRQExchangeComparisonPriceRequestInformationOptionalQualifiersMiscQualifiersTourCode
                    {
                        Text = request.objCalificadores.strTourCode
                    }
                };
            }

            // retornando request
            return new AutomatedExchangesRQExchangeComparison
            {
                OriginalTicketNumber = request.objCalificadores.strTicketOriginal,
                PriceRequestInformation = new AutomatedExchangesRQExchangeComparisonPriceRequestInformation
                {
                    OptionalQualifiers = loptionalQualifiers
                },
                ExchangeSegment = (lsegmentosBranded.Any() ? lsegmentosBranded.ToArray() : null)
            };
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="numeroPQ"></param>
        /// <returns></returns>
        private AutomatedExchangesRQExchangeConfirmation PrepareConfirmationRQRequest(CE_Reserva reserva,
                                                                                      out string numeroPQ)
        {
            // buscando cotización seleccionada
            var lcotizacion = reserva.Cotizaciones.Last(c => (c.Reemision.Value && c.Seleccionada.Value));

            // evaluando si NO se encontro ninguna cotización seleccionada
            if (lcotizacion == null)
            {
                // forzando excepción
                throw new InternalException(string.Format("No se encontro ninguna cotización seleccionada - PNR: {0}", reserva.PNR));
            }

            numeroPQ = lcotizacion.NumeroPQ.ToString();

            var lresultado = new AutomatedExchangesRQExchangeConfirmation
            {
                PQR_Number = numeroPQ,
                DoNotIssueEMDForChangeFeeSpecified = reserva.EmitirEMDPorCambioTarifa.Value,
                DoNotIssueEMDForChangeFee = (!reserva.EmitirEMDPorCambioTarifa.Value),
                OptionalQualifiers = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiers
                {
                    FOP_Qualifiers = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersFOP_Qualifiers(),
                    MiscQualifiers = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersMiscQualifiers
                    {
                        Commission = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersMiscQualifiersCommission
                        {
                            Percent = lcotizacion.Tarifas[0].ComisionPta.PorcentajeComisionKP.ToString()
                        }
                    }
                }
            };

            /*  -- POR LO MOMENTOS COMENTADO DEBIDO A QUE PARA EL CASO DE REEMISION SE MANDA ESTOS VALORES EN EL "ENHACED AIR TICKET" --
             * 
            // evaluando si existe se ha se usarse un código netremit (rosita nos indica que se puede pasar a la confirmación aqui)
            if (lcotizacion.Tarifas[0].ComisionPta.TipoCodigo.HasValue && (lcotizacion.Tarifas[0].ComisionPta.TipoCodigo == EnumTipoCodigoComision.NetRemit))
            {
                lresultado.OptionalQualifiers.MiscQualifiers.TourCode = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersMiscQualifiersTourCode
                {
                    Text = lcotizacion.Tarifas[0].ComisionPta.Codigo
                };
            }
            */

            // evaluando si NO existe una única forma de pago
            if ((reserva.Facturacion.Pagos == null) || (reserva.Facturacion.Pagos.Count() != 1))
            {
                // forzando excepción
                throw new InternalException(string.Format("No proporciono una única Forma de Pago - PNR: {0}", reserva.PNR));
            }

            switch (reserva.Facturacion.Pagos[0].TipoFormaPago)
            {
                case EnumTipoFormaPago.CASH:
                    lresultado.OptionalQualifiers.FOP_Qualifiers.BasicFOP = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersFOP_QualifiersBasicFOP
                    {
                        TypeSpecified = true,
                        Type = AutomatedExchangesRQExchangeConfirmationOptionalQualifiersFOP_QualifiersBasicFOPType.CA
                    };
                    break;

                case EnumTipoFormaPago.CARD:
                    lresultado.OptionalQualifiers.FOP_Qualifiers.BasicFOP = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersFOP_QualifiersBasicFOP
                    {
                        TypeSpecified = false,
                        CC_Info = new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersFOP_QualifiersBasicFOPCC_Info
                        {
                            SuppressSpecified = true,
                            Suppress = true,
                            PaymentCard =
                                new AutomatedExchangesRQExchangeConfirmationOptionalQualifiersFOP_QualifiersBasicFOPCC_InfoPaymentCard
                                {
                                    Code = reserva.Facturacion.Pagos[0].Medio,
                                    Number = reserva.Facturacion.Pagos[0].Tarjeta.Numero,
                                    ManualApprovalCode = ((reserva.Cliente.IdCliente == Configuracion.CustomerIdTest) ? Configuracion.ManualApprovalCodeCrediCard : null),
                                    ExpireDate = reserva.Facturacion.Pagos[0].Tarjeta.FechaVencimiento
                                }
                        }
                    };
                    break;
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="numeroPQ"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void ProcessResult(AutomatedExchangesRS response,
                                   string numeroPQ,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".AutomatedExchangesRQ return AutomatedExchangesRS null");

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
                //if (response.ExchangeConfirmation.PQR_Number.Equals(numeroPQ, StringComparison.InvariantCultureIgnoreCase))
                if (int.Parse(response.ExchangeConfirmation.PQR_Number) == int.Parse(numeroPQ))
                {
                    // actualizando respuesta
                    estatus.Ok = true;
                    estatus.Registrar(response.Text);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoOperacion"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private CE_Estatus Execute(EnumAutomatedExchangeType tipoOperacion,
                                   CE_Reserva reserva)

        {
            AutomatedExchangesRQRequest lautomatedExchangesRQRequest = null;
            AutomatedExchangesRQResponse lautomatedExchangesRQResponse = null;

            var lrespuesta = new CE_Estatus();

            string lnumeroPQ = null;

            try
            {
                // construyendo request
                lautomatedExchangesRQRequest = new AutomatedExchangesRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    AutomatedExchangesRQ = new AutomatedExchangesRQ
                    {
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version
                    }
                };

                // evaluando tipo de operación que se realizara
                switch (tipoOperacion)
                {
                    case EnumAutomatedExchangeType.Comparison:
                        //lautomatedExchangesRQRequest.AutomatedExchangesRQ.ExchangeComparison = PrepareComparisonRQRequest(formaPago, a);
                        break;

                    case EnumAutomatedExchangeType.Confirmation:
                        lautomatedExchangesRQRequest.AutomatedExchangesRQ.ExchangeConfirmation = PrepareConfirmationRQRequest(reserva, out lnumeroPQ);
                        break;
                }

                using (var lservicio = Configuracion.GetServiceModelClient<AutomatedExchangesPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'AutomatedExchangesPortTypeChannel.AutomatedExchangesRQ'", new { lautomatedExchangesRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lautomatedExchangesRQResponse = lservicio.AutomatedExchangesRQ(lautomatedExchangesRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'AutomatedExchangesPortTypeChannel.AutomatedExchangesRQ'", new { lautomatedExchangesRQResponse }, CodigoSeguimiento);

                    // construyendo respuesta
                    ProcessResult(lautomatedExchangesRQResponse.AutomatedExchangesRS, lnumeroPQ, out lrespuesta);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { MuteErrors, tipoOperacion, reserva, lautomatedExchangesRQRequest, lautomatedExchangesRQResponse, lrespuesta }, CodigoSeguimiento);

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
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, tipoOperacion, reserva, lautomatedExchangesRQRequest, lautomatedExchangesRQResponse, lrespuesta }, CodigoSeguimiento);

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

        /*
        public CE_Mensaje Comparar(CE_Reserva reserva)
        {
            return Execute(EnumAutomatedExchangeType.Comparison, reserva);
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        public CE_Estatus Confirmar(CE_Reserva reserva)
        {
            return Execute(EnumAutomatedExchangeType.Confirmation, reserva);
        }

        #endregion
    }
}
