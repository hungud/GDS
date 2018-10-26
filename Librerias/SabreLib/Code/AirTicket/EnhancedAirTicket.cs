using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.FormaPago;
using EntidadesGDS.Boleto;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_EnhancedAirTicket_120;

namespace SabreLib.AirTicket
{
    public sealed class EnhancedAirTicket : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public EnhancedAirTicket(EnumAplicaciones application,
                                 CE_Session sesion,
                                 string codigoSeguimiento,
                                 bool muteErrors = true)
            : base(WebServiceAction.EnhancedAirTicket, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~EnhancedAirTicket()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "Validate"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void ValidatePreRequest(bool esReemision,
                                        CE_Reserva reserva)
        {
            // evaluando si la operación que se trata de realizar coincide con marca de operación de la reserva
            if (esReemision != reserva.EsReemision)
            {
                // forzando excepción
                throw new InternalException("La Reserva indica una operación distinta a la que se esta tratando de ejecutar");
            }

            // evaluando si NO se ha seleccionado una unica cotización
            if (reserva.Cotizaciones.Count(c => (c.Seleccionada ?? false)) != 1)
            {
                // forzando excepción
                throw new InternalException("Debe de seleccionar una única Cotización de la Reserva");
            }

            // evaluando si el tipo de cotización seleccionada correponde con el tipo de operación a ejecutarse
            if (!reserva.Cotizaciones.Any(c => ((c.Seleccionada ?? false) && ((c.Reemision ?? false) == esReemision))))
            {
                // forzando excepción
                throw new InternalException("La Cotización seleccionada en la Reserva no es para el tipo de operación que esta tratando de ejecutar");
            }

            // evaluando si se esta tratando de ejecutar una reemisión
            if (esReemision)
            {
                // evaluando si NO se ha seleccionado un unico pasajero
                if (reserva.Pasajeros.Count(p => (p.Seleccionado ?? false)) != 1)
                {
                    // forzando excepción
                    throw new InternalException("Debe de seleccionar una único Pasajero de la Reserva para esta Reemisión");
                }

                // evaluando si para la reemisión se ha proporcionado más de 1 forma de pago
                if (reserva.EsReemision.Value && (reserva.Facturacion.Pagos.Count() > 1))
                {
                    // forzando excepción
                    throw new InternalException("Ha proporcionado más de una Forma de Pago para esta Reemisión");
                }

            }
            else
            {
                // evaluando si no se ha proporcionado ninguna forma de pago
                if ((reserva.Facturacion == null) || (reserva.Facturacion.Pagos == null) || (!reserva.Facturacion.Pagos.Any()))
                {
                    // forzando excepción
                    throw new InternalException("No ha proporcionado ninguna Forma de Pago con la Facturación para esta Emisión");
                }

                // evaluando si se ha proporcionado más de 2 formas de pago
                if (reserva.Facturacion.Pagos.Count() > 2)
                {
                    // forzando excepción
                    throw new InternalException("Ha proporcionado más de 2 Formas de Pago para esta Emisión");
                }

                // evaluando si se ha proporcionado más de 1 vez la forma de pago CASh
                if (reserva.Facturacion.Pagos.Count(p => (p.TipoFormaPago == EnumTipoFormaPago.CASH)) > 1)
                {
                    // forzando excepción
                    throw new InternalException("Ha proporcionado más de 1 vez la Forma de Pago 'CASH' para esta Emisión");
                }
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagos"></param>
        /// <returns></returns>
        private CE_FormaPago[] ArrangePayments(CE_FormaPago[] pagos)
        {
            return (
                    from pago in pagos
                    where (pago.TipoFormaPago == EnumTipoFormaPago.CARD)
                    select pago
                ).Union(
                    from pago in pagos
                    where (pago.TipoFormaPago == EnumTipoFormaPago.CASH)
                    select pago
                ).ToArray();
        }

        #region "Prepare"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cotizacionSeleccionada"></param>
        /// <returns></returns>
        private AirTicketRQTicketingFlightQualifiers PrepareFlightQualifiers(CE_Cotizacion cotizacionSeleccionada)
        {
            return new AirTicketRQTicketingFlightQualifiers
            {
                VendorPrefs = new AirTicketRQTicketingFlightQualifiersVendorPrefs
                {
                    Airline = new AirTicketRQTicketingFlightQualifiersVendorPrefsAirline
                    {
                        Code = cotizacionSeleccionada.LineasValidadoras.First(l => (l.Seleccionada ?? false)).CodigoAerolinea
                    }
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formaPago"></param>
        /// <returns></returns>
        private AirTicketRQTicketingFOP_QualifiersBasicFOP PrepareBasicFOP(CE_FormaPago formaPago)
        {
            var lresultado = new AirTicketRQTicketingFOP_QualifiersBasicFOP();

            switch (formaPago.TipoFormaPago)
            {
                case EnumTipoFormaPago.CARD:
                    lresultado = new AirTicketRQTicketingFOP_QualifiersBasicFOP
                    {
                        CC_Info = new AirTicketRQTicketingFOP_QualifiersBasicFOPCC_Info
                        {
                            PaymentCard = new AirTicketRQTicketingFOP_QualifiersBasicFOPCC_InfoPaymentCard
                            {
                                Number = formaPago.Tarjeta.Numero,
                                ExpireDate = formaPago.Tarjeta.FechaVencimiento,
                                Code = formaPago.Medio,
                                CardSecurityCode = formaPago.Tarjeta.CodigoVerificacion
                                //ManualApprovalCode = // EN EL PQ ESTA ASIGNANDO UNO PARA PRUEBA TRAVEL DESDE EL CONFIG
                            }
                        }
                    };

                    break;

                case EnumTipoFormaPago.CASH:
                    lresultado = new AirTicketRQTicketingFOP_QualifiersBasicFOP
                    {
                        Type = "CA"
                    };

                    break;
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagos"></param>
        /// <returns></returns>
        private AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOP PrepareMultipleFOP(CE_FormaPago[] pagos)
        {
            var lresultado = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOP
            {
                FOP_One = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_One
                {
                    CC_Info = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_OneCC_Info
                    {
                        PaymentCard = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_OneCC_InfoPaymentCard
                        {
                            Number = pagos[0].Tarjeta.Numero,
                            ExpireDate = pagos[0].Tarjeta.FechaVencimiento,
                            Code = pagos[0].Medio,
                            CardSecurityCode = pagos[0].Tarjeta.CodigoVerificacion
                            //ManualApprovalCode = // EN EL PQ ESTA ASIGNANDO UNO PARA PRUEBA TRAVEL DESDE EL CONFIG
                        }
                    }
                },
                Fare = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFare
                {
                    Amount = pagos[1].MontoPago.ToString()
                }
            };

            switch (pagos[1].TipoFormaPago)
            {
                case EnumTipoFormaPago.CARD:
                    lresultado.FOP_Two = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_Two
                    {
                        CC_Info = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_TwoCC_Info
                        {
                            PaymentCard = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_TwoCC_InfoPaymentCard
                            {
                                Number = pagos[1].Tarjeta.Numero,
                                ExpireDate = pagos[1].Tarjeta.FechaVencimiento,
                                Code = pagos[1].Medio,
                                CardSecurityCode = pagos[1].Tarjeta.CodigoVerificacion
                                //ManualApprovalCode = // EN EL PQ ESTA ASIGNANDO UNO PARA PRUEBA TRAVEL DESDE EL CONFIG
                            }
                        }
                    };

                    break;

                case EnumTipoFormaPago.CASH:
                    lresultado.FOP_Two = new AirTicketRQTicketingFOP_QualifiersBSP_TicketingMultipleFOPFOP_Two
                    {
                        Type = "CA"
                    };

                    break;
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagos"></param>
        /// <returns></returns>
        private AirTicketRQTicketingFOP_Qualifiers PrepareFOP_Qualifiers(CE_FormaPago[] pagos)
        {
            var lresultado = new AirTicketRQTicketingFOP_Qualifiers();

            // solo 1 forma de pago CASH o CARD
            if (pagos.Count() == 1)
            {
                lresultado.BasicFOP = PrepareBasicFOP(pagos[0]);

            }
            else
            {
                // más 1 forma de pago CASH o CARD
                lresultado.BSP_Ticketing = new AirTicketRQTicketingFOP_QualifiersBSP_Ticketing
                {
                    MultipleFOP = PrepareMultipleFOP(pagos)
                };
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="cotizacionSeleccionada"></param>
        /// <returns></returns>
        private AirTicketRQTicketingMiscQualifiers PrepareMiscQualifiers(bool esReemision,
                                                                         CE_Cotizacion cotizacionSeleccionada)
        {
            var lresultado = new AirTicketRQTicketingMiscQualifiers
            {
                Ticket = (esReemision ? null : new AirTicketRQTicketingMiscQualifiersTicket { Type = "ETR" }),
                Invoice = new AirTicketRQTicketingMiscQualifiersInvoice
                {
                    IndSpecified = true,
                    Ind = false,
                    ETReceiptSpecified = true,
                    ETReceipt = true,
                }
            };

            // evaluando si es una reemision
            if (esReemision)
            {
                // evaluando si existe código netremit o tourcode (para reemisiones todo va como tourcode indicado por rosita)
                if (cotizacionSeleccionada.Tarifas[0].ComisionPta.TipoCodigo.HasValue && (!string.IsNullOrWhiteSpace(cotizacionSeleccionada.Tarifas[0].ComisionPta.Codigo)))
                {
                    lresultado.TourCode = new AirTicketRQTicketingMiscQualifiersTourCode
                    {
                        SuppressIT = new AirTicketRQTicketingMiscQualifiersTourCodeSuppressIT
                        {
                            Ind = true
                        },
                        Text = cotizacionSeleccionada.Tarifas[0].ComisionPta.Codigo
                    };
                }

            }
            else
            {
                // se espera la comision solo cuando no se emite dado que cuando se reemite se espera en la confirmación del PQ
                lresultado.Commission = new AirTicketRQTicketingMiscQualifiersCommission
                {
                    PercentSpecified = true,
                    Percent = cotizacionSeleccionada.Tarifas[0].ComisionPta.PorcentajeComisionKP.Value
                };
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="cotizacionSeleccionada"></param>
        /// <returns></returns>
        private AirTicketRQTicketingPricingQualifiers PreparePricingQualifiers(bool esReemision, 
                                                                               CE_Cotizacion cotizacionSeleccionada)
        {
            return new AirTicketRQTicketingPricingQualifiers
            {
                PriceQuote = new []
                {
                    new AirTicketRQTicketingPricingQualifiersPriceQuote
                    {
                        Record = new []
                        {
                            new AirTicketRQTicketingPricingQualifiersPriceQuoteRecord
                            {
                                ReissueSpecified = esReemision,
                                Reissue = esReemision,
                                Number = cotizacionSeleccionada.NumeroPQ.ToString()
                            } 
                        }
                    }
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="cotizacionSeleccionada"></param>
        /// <param name="pagos"></param>
        /// <returns></returns>
        private AirTicketRQTicketing[] PrepareTicketing(bool esReemision,
                                                        CE_Cotizacion cotizacionSeleccionada,
                                                        CE_FormaPago[] pagos)
        {
            var lticket = new AirTicketRQTicketing
            {
                MiscQualifiers = PrepareMiscQualifiers(esReemision, cotizacionSeleccionada),
                PricingQualifiers = PreparePricingQualifiers(esReemision, cotizacionSeleccionada)
            };

            // evaluando que NO sea un reemisión
            if (!esReemision)
            {
                lticket.FlightQualifiers = PrepareFlightQualifiers(cotizacionSeleccionada);
                lticket.FOP_Qualifiers = PrepareFOP_Qualifiers(pagos);
            }

            return new[] { lticket };
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        private void ProcessResult(AirTicketRS response,
                                   out CE_Estatus estatus,
                                   out CE_Boleto[] boletos)
        {
            estatus = new CE_Estatus();
            boletos = null;

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".AirTicketRQ return AirTicketRS null");

                return;
            }

            // erro no se genero la emisióm
            // Code: ERR.SP.PROVIDER_ERROR
            // Value: No new tickets have been issued

            if ((response.ApplicationResults.Error != null) && (response.ApplicationResults.Error.Any()))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarErrores(
                    response.ApplicationResults.Error
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );
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

                boletos = response.Summary.Select(s => new CE_Boleto
                {
                    NumeroBoleto = s.DocumentNumber,
                    Tipo = s.DocumentType,
                    Pasajero = new CE_Pasajero
                    {
                        Nombre = s.FirstName,
                        Apellido = s.LastName
                    }
                }).ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esReemision"></param>
        /// <param name="perfilImpresora"></param>
        /// <param name="reserva"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        private CE_Estatus Execute(bool esReemision,
                                   string perfilImpresora,
                                   CE_Reserva reserva,
                                   out CE_Boleto[] boletos)
        {
            AirTicketRQRequest lairTicketRQRequest = null;
            AirTicketRQResponse lairTicketRQResponse = null;

            var lrespuesta = new CE_Estatus();

            boletos = null;

            try
            {
                // obteniendo cotización seleccionada
                var lcotizacionSeleccionada = reserva.Cotizaciones.Last(c => (c.Seleccionada.Value && (c.Reemision == esReemision)));

                // extrayendo y reordenando los pagos
                var lpagos = ArrangePayments(reserva.Facturacion.Pagos);

                // realizando validaciones antes de construir el request
                ValidatePreRequest(esReemision, reserva);

                // construyendo request
                lairTicketRQRequest = new AirTicketRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    AirTicketRQ = new AirTicketRQ
                    {
                        version = WebServiceFileValueSabre.Version,
                        targetCity = (string.IsNullOrWhiteSpace(reserva.Aplicacion.PseudoEmision) ? lcotizacionSeleccionada.Pseudo : reserva.Aplicacion.PseudoEmision),
                        Itinerary = new AirTicketRQItinerary
                        {
                            ID = reserva.PNR
                        },
                        AccountingLines = new AirTicketRQAccountingLines
                        {
                            All = true,
                            AllSpecified = true
                        },
                        DesignatePrinter = new AirTicketRQDesignatePrinter
                        {
                            Profile = new AirTicketRQDesignatePrinterProfile
                            {
                                Number = perfilImpresora
                            }
                        },
                        Ticketing = PrepareTicketing(esReemision, lcotizacionSeleccionada, lpagos),
                        PostProcessing = new AirTicketRQPostProcessing
                        {
                            EndTransaction = new AirTicketRQPostProcessingEndTransaction
                            {
                                Source = new AirTicketRQPostProcessingEndTransactionSource
                                {
                                    ReceivedFrom = CodigoSeguimiento
                                }
                            }
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<AirTicketPortTypeChannel>())
                {

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'AirTicketPortTypeChannel.EnhancedAirTicket'", null, new { lairTicketRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lairTicketRQResponse = lservicio.AirTicketRQ(lairTicketRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'AirTicketPortTypeChannel.EnhancedAirTicket'", null, new { lairTicketRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lairTicketRQResponse.AirTicketRS, out lrespuesta, out boletos);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Warn, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, perfilImpresora, reserva, boletos, lairTicketRQRequest, lairTicketRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                boletos = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, perfilImpresora, reserva, boletos, lairTicketRQRequest, lairTicketRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                boletos = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="perfilImpresora"></param>
        /// <param name="reserva"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        public CE_Estatus Eemitir(string perfilImpresora,
                                  CE_Reserva reserva,
                                  out CE_Boleto[] boletos)
        {
            return Execute(false, perfilImpresora, reserva, out boletos);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="perfilImpresora"></param>
        /// <param name="reserva"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        public CE_Estatus Reemitir(string perfilImpresora,
                                   CE_Reserva reserva,
                                   out CE_Boleto[] boletos)
        {
            return Execute(true, perfilImpresora, reserva, out boletos);
        }

        #endregion
    }
}
