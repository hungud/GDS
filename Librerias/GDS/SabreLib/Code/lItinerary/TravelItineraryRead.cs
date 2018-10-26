using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Converter;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Comentario;
using EntidadesGDS.Boleto;
using EntidadesGDS.Facturacion;
using EntidadesGDS.FormaPago;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_TravelItineraryReadRQ_310;

namespace SabreLib.lItinerary
{
    /* posibles valores para SubjectAreas
    PRIMARY SUBJECT AREAS
    ACCOUNTING_LINES,
    AGENCY_ADDRESS,
    ANCILLARY,
    DK_NUMBER,
    DSS,
    FREQUENT_FLYER,
    GENERAL_FACTS,
    HOSTED_FACTS,
    PASSENGER_DETAILS,
    PAY_INFO,
    POPULATE_IS_PAST,
    PRICING_INFORMATION,
    PHONE,
    PRERESERVED_SEAT,
    PRICE_QUOTE,             
    PRICE_QUOTE*
    PROFILE_INDEX,
    RECEIVED_FROM,
    REMARKS,
    TICKETING,
    AGGREGATED SUBJECT AREAS
    SIMPLE,
    DEFAULT,
    FULL,
    ACTIVE_PNR_DATA
    */
    public sealed class TravelItineraryRead : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public TravelItineraryRead(EnumAplicaciones application,
                                   CE_Session sesion,
                                   string codigoSeguimiento,
                                   bool muteErrors = true)
            : base(WebServiceAction.TravelItineraryRead, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~TravelItineraryRead()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "Process"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroPasajero"></param>
        /// <returns></returns>
        private string ProcessPassengerNameNumber(string numeroPasajero)
        {
            return numeroPasajero.Split('.').Select(n => n.TrimStart('0')).Pipe(l => string.Join(".", l));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void UpdatePassengers(CE_Reserva reserva)
        {
            // evaluando si se recibio los datos necesarios para actualizar los pasajeros
            if ((reserva.Pasajeros != null) && reserva.Pasajeros.Any() && (reserva.ServiciosEspeciales != null) && reserva.ServiciosEspeciales.Any())
            {
                // clonando servicios especiales
                var lcopiaServiciosEspeciales = Advanced.ToCopyList<CE_ServicioEspecial, CE_ServicioEspecial>(reserva.ServiciosEspeciales);

                // recorriendo servicios especiales
                lcopiaServiciosEspeciales
                    .ForEach(s =>
                    {
                        if ((s.Eliminar == null) || (!s.Eliminar.Value))
                        {
                            CE_Pasajero lpasajero = null;
                            Match lencontrado = null;

                            switch (s.Tipo)
                            {
                                case EnumSpecialServiceInfoType.DOCS:
                                    // buscando sexo y fecha de nacimiento
                                    lencontrado = Regex.Match(s.Texto, Configuracion.GetRegularExpression("UpdatePassengers.Docs"));
                                    break;

                                case EnumSpecialServiceInfoType.FOID:
                                    // buscando datos de identificación
                                    lencontrado = Regex.Match(s.Texto, Configuracion.GetRegularExpression("UpdatePassengers.Foid"));
                                    break;

                                case EnumSpecialServiceInfoType.INFT:
                                    // buscando nombre y fecha de nacimiento
                                    lencontrado = Regex.Match(s.Texto, Configuracion.GetRegularExpression("UpdatePassengers.Inft"));
                                    break;
                            }

                            if ((lencontrado != null) && lencontrado.Success)
                            {
                                switch (s.Tipo)
                                {
                                    case EnumSpecialServiceInfoType.DOCS:
                                        // buscando pasajero
                                        lpasajero = reserva.Pasajeros
                                            .FirstOrDefault(p =>
                                                (p.NumeroPasajero.Equals(s.Pasajero.NumeroPasajero, StringComparison.InvariantCultureIgnoreCase)
                                                    && string.Format("{0}/{1}", p.Apellido, p.Nombre).Equals(lencontrado.Groups[3].Value, StringComparison.InvariantCultureIgnoreCase))
                                            );
                                        break;

                                    case EnumSpecialServiceInfoType.FOID:
                                        // buscando pasajero
                                        lpasajero = reserva.Pasajeros.FirstOrDefault(p => p.NumeroPasajero.Equals(s.Pasajero.NumeroPasajero, StringComparison.InvariantCultureIgnoreCase));
                                        break;

                                    case EnumSpecialServiceInfoType.INFT:
                                        // buscando pasajero
                                        lpasajero = reserva.Pasajeros
                                            .FirstOrDefault(p => string.Format("{0}/{1}", p.Apellido, p.Nombre).Equals(lencontrado.Groups[1].Value, StringComparison.InvariantCultureIgnoreCase));
                                        break;
                                }
                            }

                            if (lpasajero != null)
                            {
                                switch (s.Tipo)
                                {
                                    case EnumSpecialServiceInfoType.DOCS:
                                        lpasajero.FechaNacimiento = DateStringSabre.ToValidBirthdate(lencontrado.Groups[1].Value, "dd/MM/yyyy");
                                        lpasajero.Sexo = ((EnumSexo) Enum.Parse(typeof(EnumSexo), lencontrado.Groups[2].Value));
                                        break;

                                    case EnumSpecialServiceInfoType.FOID:
                                        lpasajero.TipoDocumento = ProcessPassengerDocumentType(lencontrado.Groups[1].Value);
                                        lpasajero.NumeroDocumento = lencontrado.Groups[2].Value;
                                        break;

                                    case EnumSpecialServiceInfoType.INFT:
                                        lpasajero.FechaNacimiento = DateStringSabre.ToValidBirthdate(lencontrado.Groups[2].Value, "dd/MM/yyyy");
                                        s.Pasajero = new CE_Pasajero { NumeroPasajero = lpasajero.NumeroPasajero };
                                        break;
                                }
                            }

                            s.Eliminar = ((lpasajero == null) ? true : s.Eliminar);
                        }
                    });

                // actualizando servicios especiales
                reserva.ServiciosEspeciales = lcopiaServiciosEspeciales.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restriccionesEmision"></param>
        /// <returns></returns>
        private string ProccessResTicketingRestrictions(string[] restriccionesEmision)
        {
            if ((restriccionesEmision != null) && restriccionesEmision.Any())
            {
                return restriccionesEmision.First(t => t.Contains("LAST DAY TO PURCHASE")).Replace("LAST DAY TO PURCHASE", string.Empty).Trim();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impuestos"></param>
        /// <returns></returns>
        private CE_Impuesto[] ProcessTaxes(List<TravelItineraryReadRSTravelItineraryAccountingInfoTaxes> impuestos)
        {
            // evaluando si se recibio los datos de los impuestos
            if ((impuestos != null) && impuestos.Any())
            {
                var lresult = new List<CE_Impuesto>();

                // "GST"
                var lgst = impuestos.Where(t => (t.GST != null)).ToList();

                if (lgst.Any())
                {
                    lresult.Add(new CE_Impuesto
                    {
                        CodigoImpuesto = "GST",
                        Importe = lgst.Sum(t => decimal.Parse(t.GST.Amount)),
                        Porcentaje = string.Format("{0}", impuestos[0].GST.Percent).Equals("1"),
                        CodigoMonedaPago = impuestos[0].GST.CurrencyCode
                    });
                }

                // "QST"
                var lqst = impuestos.Where(t => (t.QST != null)).ToList();

                if (lqst.Any())
                {
                    lresult.Add(new CE_Impuesto
                    {
                        CodigoImpuesto = "QST",
                        Importe = impuestos.Sum(t => decimal.Parse(t.QST.Amount)),
                        Porcentaje = string.Format("{0}", impuestos[0].QST.Percent).Equals("1"),
                        CodigoMonedaPago = impuestos[0].QST.CurrencyCode
                    });
                }

                // filtrando tipo de tax "QST"
                var ltax = impuestos.Where(t => (t.Tax != null)).ToList();

                if (ltax.Any())
                {
                    lresult.Add(new CE_Impuesto
                    {
                        CodigoImpuesto = "TAX",
                        Importe = impuestos.Sum(t => decimal.Parse(t.Tax.Amount)),
                        Porcentaje = string.Format("{0}", impuestos[0].Tax.Percent).Equals("1"),
                        CodigoMonedaPago = impuestos[0].Tax.CurrencyCode
                    });
                }

                return lresult.ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenciaItinerario"></param>
        /// <returns></returns>
        private CE_Cliente ProcessTravelItinerary(TravelItineraryReadRSTravelItineraryItineraryRef referenciaItinerario)
        {
            if ((referenciaItinerario != null) && (!string.IsNullOrWhiteSpace(referenciaItinerario.CustomerIdentifier)))
            {
                return new CE_Cliente
                {
                    IdCliente = int.Parse(referenciaItinerario.CustomerIdentifier)
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenciaItinerario"></param>
        /// <returns></returns>
        private CE_ReservaReferencia ProcessReference(TravelItineraryReadRSTravelItineraryItineraryRef referenciaItinerario)
        {
            if ((referenciaItinerario != null) && (referenciaItinerario.Source != null))
            {
                var lsource = referenciaItinerario.Source;

                return new CE_ReservaReferencia
                {
                    IdAgente = lsource.CreationAgent,
                    FechaCreacion = lsource.CreateDateTime.Split('T')[0],
                    HoraCreacion = lsource.CreateDateTime.Split('T')[1],
                    FechaHoraCreacion = DateTime.Parse(lsource.CreateDateTime),
                    PseudoCreacion = lsource.PseudoCityCode
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionCliente"></param>
        /// <returns></returns>
        private CE_Pasajero[] ProcessCustomerInfo(TravelItineraryReadRSTravelItineraryCustomerInfo informacionCliente)
        {
            // evaluando si se recibio los datos de los pasajeros
            if ((informacionCliente != null) && (informacionCliente.PersonName != null) && informacionCliente.PersonName.Any())
            {
                return informacionCliente.PersonName
                    .Select(p =>
                    {
                        EnumTipoDocumento? ltipoDocumento = null;
                        string lnumeroDocumento = null;
                        string lruc = null;

                        if (!string.IsNullOrWhiteSpace(p.NameReference))
                        {
                            // buscando ruc o datos de identificación
                            var lexpresion = Regex.Match(p.NameReference, Configuracion.GetRegularExpression("NameReference"));

                            // evaluando si se encontro un ruc
                            if (lexpresion.Groups[1].Value.Equals("RUC", StringComparison.InvariantCultureIgnoreCase))
                            {
                                lruc = lexpresion.Groups[2].Value;

                            }
                            else
                            {
                                ltipoDocumento = ProcessPassengerDocumentType(lexpresion.Groups[1].Value);
                                lnumeroDocumento = lexpresion.Groups[2].Value;
                            }
                        }

                        return new CE_Pasajero
                        {
                            NumeroLinea = int.Parse(p.RPH),
                            NumeroPasajero = ProcessPassengerNameNumber(p.NameNumber),
                            Nombre = p.GivenName,
                            Apellido = p.Surname,
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = p.PassengerType },
                            TipoDocumento = ltipoDocumento,
                            NumeroDocumento = lnumeroDocumento,
                            RUC = lruc
                        };
                    }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionItinerario"></param>
        /// <returns></returns>
        private CE_Itinerario ProcessItineraryInfo(TravelItineraryReadRSTravelItineraryItineraryInfo informacionItinerario)
        {
            // evaluando si se recibio los datos de los segmentos
            if ((informacionItinerario != null) && (informacionItinerario.ReservationItems != null) && informacionItinerario.ReservationItems.Any())
            {
                var lsegmentos = new List<CE_Segmento>();

                informacionItinerario.ReservationItems
                    .Where(r => (r.FlightSegment != null))                                                                // solo segmentos aéreos
                    .ToList()
                    .ForEach(r =>
                    {
                        string ldestinationLocation;
                        string lcodigoReservaAerolinea = null;
                        string loperadoPor = null;

                        var ldateTime = DateStringSabre.ToValidDate(r.FlightSegment[0].DepartureDateTime, true);
                        var lupdateTime = DateStringSabre.ToValidDate(r.FlightSegment[0].UpdatedDepartureTime, true);

                        // evaluaciones para obtener la fecha de salida
                        var lfechaSalida = ((lupdateTime >= ldateTime) ? lupdateTime.Value : ldateTime.Value);

                        var lcantidadParadas = int.Parse(r.FlightSegment[0].StopQuantity);

                        // ealuando si es posee paradas técnicas
                        if ((lcantidadParadas > 0) && (r.FlightSegment.Length > 1))
                        {
                            ldestinationLocation = r.FlightSegment[lcantidadParadas].DestinationLocation.LocationCode;

                            ldateTime = DateStringSabre.ToValidDate(r.FlightSegment[lcantidadParadas].ArrivalDateTime, true);
                            lupdateTime = DateStringSabre.ToValidDate(r.FlightSegment[lcantidadParadas].UpdatedArrivalTime, true);

                        }
                        else
                        {
                            ldestinationLocation = r.FlightSegment[0].DestinationLocation.LocationCode;

                            ldateTime = DateStringSabre.ToValidDate(r.FlightSegment[0].ArrivalDateTime, true);
                            lupdateTime = DateStringSabre.ToValidDate(r.FlightSegment[0].UpdatedArrivalTime, true);
                        }

                        // evaluaciones para obtener la fecha de llegada
                        var lfechaLlegada = ((lupdateTime >= ldateTime) ? lupdateTime.Value : ldateTime.Value);

                        // evaluaciones para obtener el codigo de reserva de la aerolinea
                        if (r.FlightSegment[0].SupplierRef != null)
                        {
                            lcodigoReservaAerolinea = r.FlightSegment[0].SupplierRef.ID.Replace("DCLA*", string.Empty);
                        }

                        // evaluaciones para obtener el operado por
                        if ((r.FlightSegment[0].OperatingAirline != null) && r.FlightSegment[0].OperatingAirline.Any())
                        {
                            loperadoPor = (string.IsNullOrWhiteSpace(r.FlightSegment[0].OperatingAirline[0].Code) ? r.FlightSegment[0].OperatingAirline[0].Banner : r.FlightSegment[0].OperatingAirline[0].Code);
                        }

                        lsegmentos.Add(new CE_Segmento
                        {
                            NumeroLinea = int.Parse(r.FlightSegment[0].Id),                                               // antes int.Parse(parent.PRH)
                            NumeroSegmento = int.Parse(r.FlightSegment[0].SegmentNumber),                                 // hugo comenta esta a un 90% seguro que PRH == SegmentNumber 
                            Aerolinea = new CE_Aerolinea { CodigoAerolinea = r.FlightSegment[0].MarketingAirline.Code },
                            NumeroVuelo = r.FlightSegment[0].FlightNumber,
                            ClaseReserva = r.FlightSegment[0].ResBookDesigCode,
                            FechaSalida = DateStringSabre.ToValidStringDateGds(lfechaSalida),
                            DiaSemanaSalida = lfechaSalida.DayOfWeek.ToString("D"),
                            HoraSalida = DateStringSabre.ToValidStringTimeGds(lfechaSalida),
                            CiudadSalida = new CE_Ciudad { CodigoCiudadSegmento = r.FlightSegment[0].OriginLocation.LocationCode },
                            FechaLlegada = DateStringSabre.ToValidStringDateGds(lfechaLlegada),
                            DiaSemanaLlegada = lfechaLlegada.DayOfWeek.ToString("D"),
                            HoraLlegada = DateStringSabre.ToValidStringTimeGds(lfechaLlegada),
                            CiudadLlegada = new CE_Ciudad { CodigoCiudadSegmento = ldestinationLocation },
                            Status = r.FlightSegment[0].Status,
                            CantidadAsientos = int.Parse(r.FlightSegment[0].NumberInParty),
                            CantidadParadas = lcantidadParadas,                                                           // cantidad de paradas técnicas
                            CodigoReservaAerolinea = lcodigoReservaAerolinea,
                            OperadoPor = loperadoPor,
                            EsPasado = r.FlightSegment[0].IsPast
                        });
                    });

                return new CE_Itinerario
                {
                    Segmentos = lsegmentos.ToArray()
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagos"></param>
        /// <returns></returns>
        private CE_FormaPago[] ProcessPayments(List<object[]> pagos)
        {
            // evaluando si se recibio los datos de los pagos
            if ((pagos != null) && pagos.Any())
            {
                var lresult = new List<CE_FormaPago>();

                // "CA"
                var lcash = pagos.FirstOrDefault(p => p[0].ToString().Equals("CA", StringComparison.InvariantCultureIgnoreCase));

                if (lcash != null)
                {
                    lresult.Add(new CE_FormaPago
                    {
                        TipoFormaPago = EnumTipoFormaPago.CASH,
                        Medio = ProcessPaymentForm(lcash[0].ToString()),
                        MontoPago = decimal.Parse(lcash[3].ToString()),
                        CodigoMonedaPago = lcash[4].ToString()
                    });
                }

                // "CC"
                var lcrediCards = pagos.Where(p => p[0].ToString().Equals("CC", StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (lcrediCards.Any())
                {
                    lresult.AddRange(lcrediCards.Select(lcc => new CE_FormaPago
                    {
                        TipoFormaPago = EnumTipoFormaPago.CARD,
                        Medio = ProcessPaymentForm(lcc[1].ToString()), 
                        Tarjeta = new CE_Tarjeta
                        {
                            Numero = lcc[2].ToString()
                        },
                        MontoPago = decimal.Parse(lcc[3].ToString()), 
                        CodigoMonedaPago = lcc[4].ToString()
                    }));
                }

                return lresult.ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="impuestos"></param>
        /// <returns></returns>
        private CE_Impuesto[] ProccessTaxesPQ(TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoItinTotalFareTaxes impuestos)
        {
            // evaluando si se recibio los datos de los impuestos del PQ
            if ((impuestos != null) && (impuestos.TaxBreakdownCode != null) && impuestos.TaxBreakdownCode.Any())
            {
                return impuestos.TaxBreakdownCode
                    .Select(t =>
                    {
                        var lexpresion = Regex.Match(t.Value, Configuracion.GetRegularExpression("Tax"));

                        return new CE_Impuesto
                        {
                            CodigoImpuesto = lexpresion.Groups[2].Value,
                            Importe = decimal.Parse(lexpresion.Groups[1].Value)
                        };
                    }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segmentos"></param>
        /// <returns></returns>
        private CE_BaseTarifaria[] ProccessFlightSegment(TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoPTC_FareBreakdownFlightSegment[] segmentos)
        {
            // evaluando si se recibio los datos de farebasis
            if ((segmentos != null) && segmentos.Any())
            {
                return segmentos
                    .Where(f => (f.FareBasis != null) && (!f.FareBasis.Code.Equals("VOID", StringComparison.InvariantCultureIgnoreCase)))
                    .Select(f => new CE_BaseTarifaria
                    {
                        NumeroSegmento = int.Parse(f.SegmentNumber),
                        BaseTarifaria = f.FareBasis.Code
                    }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pasajeros"></param>
        /// <param name="informacionContable"></param>
        /// <returns></returns>
        private CE_LineaContable[] ProcessAccountingInfo(IEnumerable<CE_Pasajero> pasajeros,
                                                         TravelItineraryReadRSTravelItineraryAccountingInfo[] informacionContable)
        {
            CE_LineaContable[] lresult = null;

            // evaluando si se recibio los datos de las lineas contables
            if ((informacionContable != null) && informacionContable.Any())
            {
                lresult = informacionContable
                    .GroupBy(a => a.DocumentInfo.Document.Number)
                    .Select(g => 
                     {
                         var laccountingInfo = informacionContable.First(a => a.DocumentInfo.Document.Number.Equals(g.Key, StringComparison.InvariantCultureIgnoreCase));

                         return new
                        {
                            laccountingInfo.Airline,
                            laccountingInfo.DocumentInfo,
                            laccountingInfo.PersonName,
                            laccountingInfo.TicketingInfo,
                            Payments = informacionContable
                                .Where(a => a.DocumentInfo.Document.Number.Equals(g.Key, StringComparison.InvariantCultureIgnoreCase))
                                    .Select(b => new object[] {
                                        b.PaymentInfo.Payment.Form,
                                        ((b.PaymentInfo.Payment.Form.Equals("CC", StringComparison.InvariantCultureIgnoreCase)) ? b.PaymentInfo.Payment.CC_Info[0].Code : null),
                                        ((b.PaymentInfo.Payment.Form.Equals("CC", StringComparison.InvariantCultureIgnoreCase)) ? b.PaymentInfo.Payment.CC_Info[0].Number : null),
                                        b.BaseFare.Amount,
                                        b.BaseFare.CurrencyCode,
                                        b.PaymentInfo.Commission.Amount
                                     }).ToList(),
                            Taxes = informacionContable
                                .Where(a => a.DocumentInfo.Document.Number.Equals(g.Key, StringComparison.InvariantCultureIgnoreCase))
                                    .Select(b => b.Taxes).ToList()
                        };
                    })
                    .Select(r => new CE_LineaContable
                    {
                        Boleto = new CE_Boleto
                        {
                            NumeroBoleto = r.DocumentInfo.Document.Number,
                            Aerolinea = new CE_Aerolinea { CodigoAerolinea = r.Airline.Code },
                            Pasajero = new CE_Pasajero
                            {
                                NumeroPasajero = pasajeros
                                    .First(p => p.NumeroPasajero.Equals(ProcessPassengerNameNumber(r.PersonName.NameNumber), StringComparison.InvariantCultureIgnoreCase)).NumeroPasajero
                            },
                            Impuestos = ProcessTaxes(r.Taxes),
                            Electronico = r.TicketingInfo.eTicket.Ind,
                            Reemision = r.TicketingInfo.Exchange.Ind,
                            CuponesUsados = int.Parse(r.TicketingInfo.Ticketing.ConjunctedCount)
                        },
                        Pagos = ProcessPayments(r.Payments)
                    }).ToArray();
            }

            return lresult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        private CE_Comentario[] ProcessRemarkInfo(TravelItineraryReadRSTravelItineraryRemark[] comentarios)
        {
            // evaluando si se recibio los datos de los comentarios
            if ((comentarios != null) && comentarios.Any())
            {
                return comentarios.Select(r => new CE_Comentario
                {
                    Id = int.Parse(r.Id),
                    RPH = int.Parse(r.RPH),
                    Tipo = ((EnumTipoComentario) Enum.Parse(typeof(EnumTipoComentario), Regex.Replace(r.Type, Configuracion.GetRegularExpression("Remark"), string.Empty), true)),
                    Codigo = r.Code,
                    Texto = r.Text
                }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="construccionTarifario"></param>
        /// <param name="lineaValidadoraSeleccionada"></param>
        /// <returns></returns>
        private CE_Aerolinea[] ProcessEndorsements(TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoPTC_FareBreakdown construccionTarifario,
                                                   string lineaValidadoraSeleccionada)
        {
            var lcodigos = new List<string>();

            construccionTarifario.Endorsements.ToList().ForEach(e =>
            {
                // buscando el texto para las lineas validadoras
                var lexpresion = Regex.Match(e.Text, Configuracion.GetRegularExpression("ValidatingCarrier"));

                // evaluando si encontro coincidencias
                if (lexpresion.Success)
                {
                    lcodigos.Add(lexpresion.Groups[1].Value);
                }
            });

            return lcodigos.Distinct().Select(c => new CE_Aerolinea
            {
                Seleccionada = c.Equals(lineaValidadoraSeleccionada, StringComparison.InvariantCultureIgnoreCase),
                CodigoAerolinea = c
            }).ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="construccionTarifario"></param>
        /// <returns></returns>
        private CE_Ciudad ProcessFareComponent(TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricingPriceQuotePricedItineraryAirItineraryPricingInfoPTC_FareBreakdown construccionTarifario)
        {
            // evaluando que se obtuvieran fare component (los PQ de reemisión devuelven esto nulo)
            if (construccionTarifario.FareComponent != null)
            {
                return new CE_Ciudad
                {
                    CodigoCiudadSegmento = construccionTarifario.FareComponent.Last(f => f.FareDirectionality.Equals("FROM", StringComparison.InvariantCultureIgnoreCase)).Location.Destination
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pasajeros"></param>
        /// <param name="preciosItinerario"></param>
        /// <returns></returns>
        private CE_Cotizacion[] ProcessItineraryPricing(CE_Pasajero[] pasajeros,
                                                        TravelItineraryReadRSTravelItineraryItineraryInfoItineraryPricing preciosItinerario)
        {
            // evaluando si se recibio los datos de cotizaciones
            if ((preciosItinerario != null) && (preciosItinerario.PriceQuote != null) && preciosItinerario.PriceQuote.Any())
            {
                var lresult = new List<CE_Cotizacion>();

                preciosItinerario.PriceQuote
                    .Where(pq => pq.MiscInformation.SignatureLine[0].Status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase))
                    .ToList()
                        .ForEach(pq =>
                        {
                            var lpricedItinerary = pq.PricedItinerary[0];
                            var lcontinuar = true;

                            if (pq.PriceQuotePlus.PassengerInfo == null)
                            {
                                lcontinuar =
                                    (int.Parse(lpricedItinerary.AirItineraryPricingInfo.PassengerTypeQuantity[0].Quantity) == pasajeros.Count(
                                        p => p.TipoPasajero.IdTipoPasajero.Equals(lpricedItinerary.AirItineraryPricingInfo.PassengerTypeQuantity[0].Code, StringComparison.InvariantCultureIgnoreCase)
                                    ));
                            }

                            if (lcontinuar)
                            {
                                var ltarifa = new CE_Tarifa
                                {
                                    Neto = decimal.Parse(lpricedItinerary.AirItineraryPricingInfo.ItinTotalFare[0].Totals.BaseFare.Amount),
                                    Total = decimal.Parse(lpricedItinerary.AirItineraryPricingInfo.ItinTotalFare[0].Totals.TotalFare.Amount),
                                    Impuestos = ProccessTaxesPQ(lpricedItinerary.AirItineraryPricingInfo.ItinTotalFare[0].Taxes),
                                    BaseTarifaria = ProccessFlightSegment(lpricedItinerary.AirItineraryPricingInfo.PTC_FareBreakdown[0].FlightSegment),
                                    TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = lpricedItinerary.AirItineraryPricingInfo.PassengerTypeQuantity[0].Code },
                                };

                                if (pq.PriceQuotePlus.PassengerInfo == null)
                                {
                                    ltarifa.Pasajeros = pasajeros.Select(p => new CE_Pasajero { NumeroPasajero = p.NumeroPasajero }).ToArray();
                                }
                                else
                                {
                                    ltarifa.Pasajeros = pq.PriceQuotePlus.PassengerInfo.PassengerData
                                        .Select(p => new CE_Pasajero { NumeroPasajero = ProcessPassengerNameNumber(p.NameNumber) }).ToArray();
                                }

                                lresult.Add(new CE_Cotizacion
                                {
                                    Seleccionada = false,
                                    NumeroPQ = int.Parse(pq.RPH),
                                    LineasValidadoras = ProcessEndorsements(lpricedItinerary.AirItineraryPricingInfo.PTC_FareBreakdown[0], lpricedItinerary.ValidatingCarrier),
                                    CiudadDestino = ProcessFareComponent(lpricedItinerary.AirItineraryPricingInfo.PTC_FareBreakdown[0]),
                                    UltimoDiaDeCompra = ProccessResTicketingRestrictions(lpricedItinerary.AirItineraryPricingInfo.PTC_FareBreakdown[0].ResTicketingRestrictions),
                                    TotalCotizacion = decimal.Parse(lpricedItinerary.AirItineraryPricingInfo.ItinTotalFare[0].TotalFare.Amount),
                                    Pseudo = pq.MiscInformation.SignatureLine[0].Text.Substring(0, 4),
                                    Tarifas = new[] { ltarifa },
                                    Reemision = (!string.IsNullOrWhiteSpace(pq.MiscInformation.SignatureLine[0].PQR_Ind))
                                });
                            }
                        });

                return lresult.ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pasajeros"></param>
        /// <param name="informacionServiciosEspeciales"></param>
        /// <returns></returns>
        private CE_ServicioEspecial[] ProcessSpecialServiceInfo(IEnumerable<CE_Pasajero> pasajeros,
                                                                TravelItineraryReadRSTravelItinerarySpecialServiceInfo[] informacionServiciosEspeciales)
        {
            CE_ServicioEspecial[] lresult = null;

            // evaluando si se recibio los datos de servicios especiales
            if ((informacionServiciosEspeciales != null) && informacionServiciosEspeciales.Any())
            {
                // servicios especiales "GFX" FOID/DOCS
                var lgfx = informacionServiciosEspeciales.Where(s => (Advanced.In(s.Type, "AFX", "GFX") && (Advanced.In(s.Service.SSR_Type, "INFT", "FOID", "DOCS")))).ToList();

                if (lgfx.Any())
                {
                    lresult = lgfx.Select(s =>
                    {
                        var lservicioEspecial = new CE_ServicioEspecial
                        {
                            NumeroServicio = int.Parse(s.RPH),
                            Tipo = ((EnumSpecialServiceInfoType) Enum.Parse(typeof(EnumSpecialServiceInfoType), s.Service.SSR_Type)),
                            Texto = s.Service.Text[0],
                            Eliminar = false
                        };

                        // buscando pasajero
                        var lpasajero = pasajeros
                            .FirstOrDefault(p => 
                                (p.NumeroPasajero.Equals(ProcessPassengerNameNumber(s.Service.PersonName[0].NameNumber))
                                    && string.Format("{0}/{1}", p.Apellido, p.Nombre)
                                        .Equals(Regex.Replace(s.Service.PersonName[0].Value, Configuracion.GetRegularExpression("PersonName"), string.Empty), StringComparison.InvariantCultureIgnoreCase))
                            );

                        if (lpasajero != null)
                        {
                            if (s.Service.SSR_Type.Equals("INFT", StringComparison.InvariantCultureIgnoreCase))
                            {
                                lservicioEspecial.PasajeroAsociado = new CE_Pasajero { NumeroPasajero = lpasajero.NumeroPasajero };
                            }
                            else
                            {
                                lservicioEspecial.Pasajero = new CE_Pasajero { NumeroPasajero = lpasajero.NumeroPasajero };
                            }
                        }

                        lservicioEspecial.Eliminar = ((lpasajero == null) ? true : lservicioEspecial.Eliminar);

                        return lservicioEspecial;

                    }).ToArray();
                }
            }

            return lresult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boletos"></param>
        /// <returns></returns>
        private CE_Boleto[] ProcessTicketing(TravelItineraryReadRSTravelItineraryItineraryInfoTicketing[] boletos)
        {
            // evaluando si se recibio los datos de boletos
            if ((boletos != null) && boletos.Any(t => (!string.IsNullOrWhiteSpace(t.eTicketNumber))))
            {
                var lresult = new List<CE_Boleto>();

                boletos
                    .Where(t => (!string.IsNullOrWhiteSpace(t.eTicketNumber)))
                        .ToList()
                            .ForEach(t =>
                            {
                                // buscando los datos del boleto
                                var lexpresion = Regex.Match(t.eTicketNumber, Configuracion.GetRegularExpression("eTicketNumber"));

                                // buscando si el boleto ya fue recolectado
                                var lindiceBoleto = lresult.FindIndex(b => 
                                        (b.NumeroBoleto.Equals(lexpresion.Groups[2].Value, StringComparison.InvariantCultureIgnoreCase) 
                                            && b.Estatus.Equals("ACTIVO", StringComparison.InvariantCultureIgnoreCase))
                                    );

                                // buscando si el boleto ya se registro
                                if (lindiceBoleto != -1)
                                {
                                    lresult.RemoveAt(lindiceBoleto);
                                }

                                // leyendo el pseudo
                                var lpseudo = (lexpresion.Groups[5].Value.Equals("SYS", StringComparison.InvariantCultureIgnoreCase) ? null : lexpresion.Groups[5].Value);

                                lresult.Add(
                                    new CE_Boleto
                                    {
                                        Pseudo = lpseudo,
                                        Sistema = string.IsNullOrWhiteSpace(lpseudo),
                                        Agente =  (string.IsNullOrWhiteSpace(lpseudo) ? null : new CE_Agente { Iniciales = lexpresion.Groups[6].Value.Substring(1) }),
                                        NumeroBoleto = lexpresion.Groups[2].Value,
                                        EnConjuncion = Extension.ConvertOrDefault<int?>(lexpresion.Groups[3].Value),
                                        Tipo = lexpresion.Groups[1].Value,
                                        Estatus = (lexpresion.Groups[4].Value.Contains("*VOID*") ? "VOID" : "ACTIVO"),
                                        FechaEmision = lexpresion.Groups[8].Value,
                                        HoraEmision = lexpresion.Groups[7].Value
                                    });
                            });

                return lresult.ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="historico"></param>
        /// <returns></returns>
        private void ProcessTickets(CE_Reserva reserva,
                                    OpenReservationElementType[] historico)
        {
            // evaluando si se recibio los datos necesarios para actualizar los boletos
            if ((reserva.Boletos != null) && reserva.Boletos.Any() && (historico != null) && historico.Any())
            {
                // buscando el número de segmento dentro del historico de la reserva
                reserva.Boletos
                    .ToList()
                    .ForEach(b =>
                    {
                        // filtrando historico
                        var lhistorico = historico
                            .Where(h => (
                                string.Format("{0}", h.type).Equals("SRVC") && 
                                (h.Item != null) && 
                                (h.SegmentAssociation != null) && 
                                h.SegmentAssociation.Any() && 
                                ((ServiceRequestType) h.Item).serviceType.Equals("SSR", StringComparison.InvariantCultureIgnoreCase) && 
                                ((ServiceRequestType) h.Item).ssrType.Equals("GFX", StringComparison.InvariantCultureIgnoreCase) &&
                                ((ServiceRequestType) h.Item).FreeText.Contains(b.NumeroBoleto)))
                            .ToList();

                        b.Pasajero = new CE_Pasajero {
                            NumeroPasajero = Regex.Replace(lhistorico[0].NameAssociation[0].Item.ToString(), Configuracion.GetRegularExpression("RemoveLeadingZeros"), string.Empty),
                            Apellido = lhistorico[0].NameAssociation[0].LastName,
                            Nombre = lhistorico[0].NameAssociation[0].FirstName
                        };

                        b.Segmentos = lhistorico
                            .Select(h => new CE_Segmento { NumeroLinea = int.Parse(h.SegmentAssociation[0].Id) })
                            .ToArray();
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="parametros"></param>
        /// <param name="estatus"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void ProcessResult(TravelItineraryReadRS response,
                                   RQ_ObtenerReserva parametros,
                                   out CE_Estatus estatus,
                                   out CE_Reserva reserva)
        {
            estatus = new CE_Estatus();
            reserva = null;

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".TravelItineraryReadRQ return TravelItineraryReadRS null");

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

                if ((response.TravelItinerary.CustomerInfo != null) && response.TravelItinerary.CustomerInfo.PersonName.Any())
                {
                    // contruyendo itinerario base
                    reserva = new CE_Reserva
                    {
                        PNR = parametros.PNR,
                        // construyendo información de cliente
                        Cliente = ProcessTravelItinerary(response.TravelItinerary.ItineraryRef),
                        Referencia = ProcessReference(response.TravelItinerary.ItineraryRef)
                    };

                    // evaluando si leer pasajeros
                    if (parametros.LeerPasajeros)
                    {
                        // construyendo lista de pasajeros
                        reserva.Pasajeros = ProcessCustomerInfo(response.TravelItinerary.CustomerInfo);

                        // evaluando si leer servicios especiales
                        if (parametros.LeerServicioEspeciales)
                        {
                            // construyendo servicios especiales
                            reserva.ServiciosEspeciales = ProcessSpecialServiceInfo(reserva.Pasajeros, response.TravelItinerary.SpecialServiceInfo);

                            // actualizando pasajeros con servicios especiales
                            UpdatePassengers(reserva);
                        }

                        // evaluando si leer las lineas contables
                        if (parametros.LeerLineasContables)
                        {
                            // construyendo lista de lineas contables
                            reserva.LineasContables = ProcessAccountingInfo(reserva.Pasajeros, response.TravelItinerary.AccountingInfo);
                        }
                    }

                    // evaluando si leer los segmentos
                    if (parametros.LeerItinerario)
                    {
                        // construyendo lista de segmentos
                        reserva.Itinerario = ProcessItineraryInfo(response.TravelItinerary.ItineraryInfo);

                        // evaluando si se han cargado segmentos sin codigo de reserva de la aerolinea
                        if ((reserva.Itinerario != null) && (reserva.Itinerario.Segmentos != null)
                            && reserva.Itinerario.Segmentos.Any(s => string.IsNullOrWhiteSpace(s.CodigoReservaAerolinea)))
                        {
                            // forzando excepción
                            throw new InternalException(string.Format("No se encontro código de reserva de la aerolinea - PNR: {0}", parametros.PNR));
                        }

                        // ###### EVALUAR SI EXISTE ITINERARIO ######

                        // evaluando si leer las cotizaciones
                        if (parametros.LeerPasajeros && parametros.LeerCotizaciones)
                        {
                            // construyendo lista de cotizaciones
                            reserva.Cotizaciones = ProcessItineraryPricing(reserva.Pasajeros, response.TravelItinerary.ItineraryInfo.ItineraryPricing);
                        }

                        // evaluando si leer los boletos
                        if (parametros.LeerBoletos)
                        {
                            // construyendo lista de boletos
                            reserva.Boletos = ProcessTicketing(response.TravelItinerary.ItineraryInfo.Ticketing);

                            // actualizando boletos con el historico
                            ProcessTickets(reserva, response.TravelItinerary.OpenReservationElements.OpenReservationElement);
                        }
                    }

                    // evaluando si leer los comentarios
                    if (parametros.LeerComentarios)
                    {
                        // construyendo lista de comentarios
                        reserva.Comentarios = ProcessRemarkInfo(response.TravelItinerary.RemarkInfo);
                    }
                }              
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="areasTematicas"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private CE_Estatus Execute(RQ_ObtenerReserva parametros,
                                   string[] areasTematicas,
                                   out CE_Reserva reserva)
        {
            TravelItineraryReadRQRequest ltravelItineraryReadRQRequest = null;
            TravelItineraryReadRQResponse ltravelItineraryReadRQResponse = null;

            var lrespuesta = new CE_Estatus();

            reserva = null;

            try
            {
                // construyendo request
                ltravelItineraryReadRQRequest = new TravelItineraryReadRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    TravelItineraryReadRQ = new TravelItineraryReadRQ
                    {
                        EchoToken = "String",
                        TimeStamp = DateTime.Now,
                        Version = WebServiceFileValueSabre.Version,
                        ReturnOptions = new TravelItineraryReadRQReturnOptions
                        {
                            UnmaskCreditCard = true
                        },
                        MessagingDetails = new TravelItineraryReadRQMessagingDetails
                        {
                            SubjectAreas = areasTematicas
                        },
                        UniqueID = new TravelItineraryReadRQUniqueID
                        {
                            ID = (string.IsNullOrWhiteSpace(parametros.PNR) ? null : parametros.PNR)
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<TravelItineraryReadPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'TravelItineraryReadPortTypeChannel.TravelItineraryReadRQ'", new { ltravelItineraryReadRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    ltravelItineraryReadRQResponse = lservicio.TravelItineraryReadRQ(ltravelItineraryReadRQRequest);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'TravelItineraryReadPortTypeChannel.TravelItineraryReadRQ'", new { ltravelItineraryReadRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(ltravelItineraryReadRQResponse.TravelItineraryReadRS, parametros, out lrespuesta, out reserva);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { MuteErrors, parametros, areasTematicas, reserva, ltravelItineraryReadRQRequest, ltravelItineraryReadRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, parametros, areasTematicas, reserva, ltravelItineraryReadRQRequest, ltravelItineraryReadRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerItinerario(RQ_ObtenerReserva parametros,
                                            out CE_Reserva reserva)
        {
            return Execute(parametros, new[] { "FULL" }, out reserva);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerItinerario(string pnr,
                                            out CE_Reserva reserva)
        {
            return ObtenerItinerario(
                new RQ_ObtenerReserva
                {
                    PNR = pnr,
                    LeerPasajeros = true,
                    LeerItinerario = true,
                    LeerServicioEspeciales = true,
                    LeerLineasContables = true,
                    LeerCotizaciones = true,
                    LeerComentarios = true,
                    LeerBoletos = true
                }, 
                out reserva);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="lineasContables"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerLineasContables(string pnr,
                                                 out CE_LineaContable[] lineasContables)
        {
            CE_Reserva reserva;

            var lrespuesta = Execute(
                new RQ_ObtenerReserva
                {
                    PNR = pnr,
                    LeerPasajeros = true,
                    LeerLineasContables = true
                }, 
                new[] { "ACCOUNTING_LINES" }, 
                out reserva);

            lineasContables = null;

            if (lrespuesta.Ok)
            {
                // actualizando respuesta
                lineasContables = reserva.LineasContables;
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="tarifasAlmancenadas"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerTarifasAlmacenadas(string pnr,
                                                    out CE_Cotizacion[] tarifasAlmancenadas)
        {
            CE_Reserva reserva;

            var lrespuesta = Execute(
                new RQ_ObtenerReserva
                {
                    PNR = pnr,
                    LeerPasajeros = true,
                    LeerItinerario = true,
                    LeerCotizaciones = true
                },  
                new[] { "PRICING_INFORMATION" }, 
                out reserva);

            tarifasAlmancenadas = null;

            if (lrespuesta.Ok)
            {
                // actualizando respuesta
                tarifasAlmancenadas = reserva.Cotizaciones;
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerComentarios(string pnr,
                                             out CE_Comentario[] comentarios)
        {
            CE_Reserva reserva;

            var lrespuesta = Execute(
                new RQ_ObtenerReserva
                {
                    PNR = pnr,
                    LeerComentarios = true
                }, 
                new[] { "REMARKS" }, 
                out reserva);

            comentarios = null;

            if (lrespuesta.Ok)
            {
                // actualizando respuesta
                comentarios = reserva.Comentarios;
            }

            return lrespuesta;
        }

        #endregion
    }
}
