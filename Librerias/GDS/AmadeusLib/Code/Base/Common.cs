using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

using CoreLib.Generics;
using CoreLib.Converter;
using CoreWebLib;
using CustomLog;

using AmadeusLATAM.B2BWallet.Amadeus;
using AmadeusLATAM.B2BWallet.Amadeus.Enum;
using AmadeusLATAM.B2BWallet.Amadeus.Model;
using AmadeusLATAM.B2BWallet.Common.Utility;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Boleto;
using EntidadesGDS.Itinerario;
using EntidadesGDS.FormaPago;

using AmadeusLib.Utiles;
using AmadeusLib.Herramientas;
using AmadeusLib.Servicios.PNR_Reply.Response;

namespace AmadeusLib.Base
{
    public class Common : IDisposable
    {
        // =============================
        // variables

        #region "variables"

        private bool _disposing;

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
        protected Common(EnumAplicaciones application,
                         string codigoSeguimiento,
                         bool muteErrors = true)
        {
            Application = application;
            CodigoSeguimiento = codigoSeguimiento;
            MuteErrors = muteErrors;

            // registrando evento
            Bitacora.Current.Debug("Parametros recibidos", new { Application, MuteErrors }, CodigoSeguimiento);
        }

        ~Common()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposing)
            {
                if (disposing)
                {
                    CodigoSeguimiento = null;
                }
            }

            _disposing = true;
        }

        #endregion

        // =============================
        // auto propiedades

        #region "auto propiedades"

        public EnumAplicaciones Application { private set; get; }
        public string CodigoSeguimiento { private set; get; }
        public bool MuteErrors { private set; get; }

        //*** ELIMINAR ESTA LINEA CUANDO SE SUBA A PRODUCCIÓN ****
        private string _xmlRequestForLog; 

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "UpdateSession"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeTransaction"></param>
        /// <param name="currentSession"></param>
        /// <param name="sessionModel"></param>
        /// <returns></returns>
        private void UpdateSessionBefore(TransactionType typeTransaction,
                                         ref CE_Session currentSession,
                                         ref SessionWSModel sessionModel)
        {
            if (((typeTransaction == TransactionType.InSeries) || (typeTransaction == TransactionType.End))
                && (currentSession != null))
            {
                ++currentSession.SequenceNumber;

                sessionModel.SessionId = currentSession.ConversationId;
                sessionModel.SequenceNumber = currentSession.SequenceNumber;
                sessionModel.SecurityToken = currentSession.Token;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeTransaction"></param>
        /// <param name="sessionModel"></param>
        /// <param name="newSession"></param>
        /// <returns></returns>
        private void UpdateSessionAfter(TransactionType typeTransaction,
                                        ref SessionWSModel sessionModel,
                                        ref CE_Session newSession)
        {

            var lcurrentPseudo = newSession.Pseudo;
            var lcurrentEnvironment = newSession.Environment;

            if (typeTransaction == TransactionType.Start)
            {
                newSession = new CE_Session
                {
                    Token = sessionModel.SecurityToken,
                    SequenceNumber = sessionModel.SequenceNumber,
                    ConversationId = sessionModel.SessionId,
                    AmadeusTransactionType = EnumTransactionType.InSeries,
                    Pseudo = lcurrentPseudo,
                    Environment = lcurrentEnvironment
                };
            }
            else if(typeTransaction == TransactionType.End) 
            {
                newSession = null;
            }

        }

        #endregion

        #region "Process"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionModel"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        private void ProcessSessionModel(ref SessionWSModel sessionModel, 
                                         CE_Session session)
        {
            var lcredentials = AmadeusUtility.GetCredentials(Application, session.Environment);

            var lxmlRequest = string.Empty;

            var lofficeId = (string.IsNullOrEmpty(session.Pseudo) ? lcredentials.OfficeId : session.Pseudo);

            sessionModel.WSAP = lcredentials.WSAP;
            sessionModel.EndPoint = lcredentials.EndPoint;

            switch (sessionModel.TransactionStatusCode)
            {
                case TransactionStatusCodeEnum.Start:
                case TransactionStatusCodeEnum.Stateless:
                    sessionModel.UserID = lcredentials.UserId;
                    sessionModel.OfficeID = lofficeId;
                    sessionModel.BinaryData = lcredentials.BinaryData;
                    lxmlRequest = SOAPHeader4_0.GenerateVerbRequestLogin(sessionModel);
                    break;

                case TransactionStatusCodeEnum.InSeries:
                case TransactionStatusCodeEnum.End:
                    lxmlRequest = SOAPHeader4_0.GenerateVerbRequestInProcess(sessionModel);
                    break;
            }

            _xmlRequestForLog = lxmlRequest;

            sessionModel.XmlRequest = XDocument.Parse(lxmlRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionReserva"></param>
        /// <returns></returns>
        private CE_ReservaReferencia ProcessRpInformation(PNR_ReplySecurityInformationSecondRpInformation informacionReserva)
        {
            var lfechaCreacion = DateStringAmadeus.ToValidDate(informacionReserva.creationDate, true);
            var lhoraCreacion = DateStringAmadeus.ToTimeSpan(informacionReserva.creationTime);

            return new CE_ReservaReferencia
            {
                PseudoCreacion = informacionReserva.creationOfficeId,
                IdAgente = informacionReserva.agentSignature,
                FechaCreacion = DateStringAmadeus.ToValidStringDateGds(lfechaCreacion.Value),
                HoraCreacion = lhoraCreacion.Value.ToString(@"hh\:mm"),
                FechaHoraCreacion = lfechaCreacion.Value.Add(lhoraCreacion.Value)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionCliente"></param>
        /// <returns></returns>
        private CE_Cliente ProcessElementsCustomer(PNR_ReplyDataElementsMaster informacionCliente)
        {
            if ((informacionCliente != null) && (informacionCliente.dataElementsIndiv != null) && informacionCliente.dataElementsIndiv.Any())
            {
                var ldk = informacionCliente.dataElementsIndiv
                    .Where(s => (
                        (s.elementManagementData.reference.qualifier.Equals("OT", StringComparison.InvariantCultureIgnoreCase)) &&
                        (s.elementManagementData.segmentName.Equals("RM", StringComparison.InvariantCultureIgnoreCase)) &&
                        (s.miscellaneousRemarks != null) &&
                        (s.miscellaneousRemarks.remarks.type.Equals("RM", StringComparison.InvariantCultureIgnoreCase)) &&
                        (s.miscellaneousRemarks.remarks.freetext.StartsWith("DK*", StringComparison.InvariantCultureIgnoreCase))))
                    .Select(s => s.miscellaneousRemarks.remarks.freetext.Substring(3))
                    .FirstOrDefault();

                if (!string.IsNullOrWhiteSpace(ldk))
                {
                    return new CE_Cliente { IdCliente = int.Parse(ldk) };
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionPasajeros"></param>
        /// <returns></returns>
        private CE_Pasajero[] ProcessTravellerInfo(PNR_ReplyTravellerInfo[] informacionPasajeros)
        {
            // evaluando si se recibio los datos de los pasajeros
            if ((informacionPasajeros != null) && informacionPasajeros.Any(t => (t.elementManagementPassenger != null)))
            {
                var lresult = informacionPasajeros
                    .Where(t => (
                        (t.elementManagementPassenger != null) &&
                        (t.elementManagementPassenger.reference.qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase))))
                    .SelectMany(p1 => p1.passengerData, (parent1, child1) => new
                    {
                        NumeroLinea = parent1.elementManagementPassenger.lineNumber,           // valor en el GDS
                        NumeroPasajero = parent1.elementManagementPassenger.reference.number,  // el id interno del servicio
                        child1
                    })
                    .SelectMany(c1 => c1.child1.travellerInformation.passenger, (parent2, child2) => new
                    {
                        parent2.NumeroLinea,
                        parent2.NumeroPasajero,
                        FechaNacimiento = (
                            (string.IsNullOrWhiteSpace(child2.type) || child2.type.Equals("ADT", StringComparison.InvariantCultureIgnoreCase))
                            ? null
                            : (((parent2.child1.dateOfBirth != null) && (parent2.child1.dateOfBirth.dateAndTimeDetails != null)) ? parent2.child1.dateOfBirth.dateAndTimeDetails.date : null)),
                        Nombre = child2.firstName,
                        Apellido = parent2.child1.travellerInformation.traveller.surname,
                        TipoPasajero = (string.IsNullOrWhiteSpace(child2.type) ? "ADT" : child2.type),
                    })
                    .Select(r =>
                    {
                        string lfechaNacimiento = null;

                        // evaluando si se se puede y se debe leer la fecha de nacimiento
                        if (r.FechaNacimiento != null)
                        {
                            lfechaNacimiento = DateStringAmadeus.ToValidBirthdate(r.FechaNacimiento, "dd/MM/yyyy");
                        }

                        return new CE_Pasajero
                        {
                            NumeroLinea = ((int)r.NumeroLinea),
                            NumeroPasajero = r.NumeroPasajero,
                            Nombre = r.Nombre,
                            Apellido = r.Apellido,
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = r.TipoPasajero },
                            FechaNacimiento = lfechaNacimiento
                        };
                    })
                    .ToArray();

                return (lresult.Any() ? lresult : null);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private EnumTipoDocumento ProcessPassengerDocumentType(string texto)
        {
            if (texto.Contains("CE"))
            {
                return EnumTipoDocumento.CarnetExtranjeria;
            }

            if (texto.Contains("PP") || texto.StartsWith("P", StringComparison.InvariantCultureIgnoreCase))
            {
                return EnumTipoDocumento.Pasaporte;
            }

            return EnumTipoDocumento.DNI;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionBoletos"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void UpdatePassengers(PNR_ReplyDataElementsMaster informacionBoletos,
                                      CE_Reserva reserva)
        {
            var ladd = 0;

            // actualizando infantes
            reserva.Pasajeros
                .Where(p => p.TipoPasajero.IdTipoPasajero.Equals("INF", StringComparison.InvariantCultureIgnoreCase))
                .ToList()
                .ForEach(p =>
                {
                    ladd++;
                    p.NumeroLinea = (reserva.Pasajeros[(reserva.Pasajeros.Length - 1)].NumeroLinea + ladd);
                });

            if ((informacionBoletos != null) && (informacionBoletos.dataElementsIndiv != null) && informacionBoletos.dataElementsIndiv.Any())
            {
                reserva.Pasajeros
                    .ToList()
                    .ForEach(p =>
                    {
                        // evaluando el tipo de pasajero
                        if (!p.TipoPasajero.IdTipoPasajero.Equals("INF", StringComparison.InvariantCultureIgnoreCase))
                        {
                            // extrayendo foid
                            var lfoid = informacionBoletos.dataElementsIndiv
                                .FirstOrDefault(s => (
                                    s.elementManagementData.reference.qualifier.Equals("OT", StringComparison.InvariantCultureIgnoreCase) &&
                                    s.elementManagementData.segmentName.Equals("SSR", StringComparison.InvariantCultureIgnoreCase) &&
                                    s.serviceRequest.ssr.type.Equals("FOID", StringComparison.InvariantCultureIgnoreCase)) &&
                                    (s.serviceRequest != null) &&
                                    s.referenceForDataElement[0].number.Equals(p.NumeroPasajero)
                                );

                            if (lfoid != null)
                            {
                                // extrayendo datos con expresión regular
                                var lexpresion = Regex.Match(lfoid.serviceRequest.ssr.freeText[0], Configuracion.GetRegularExpression("UpdatePassengers.Foid"));

                                if (lexpresion.Success)
                                {
                                    p.TipoDocumento = ProcessPassengerDocumentType(lexpresion.Groups[1].Value);
                                    p.NumeroDocumento = lexpresion.Groups[2].Value;
                                }
                            }

                            // extrayendo docs
                            var ldocs = informacionBoletos.dataElementsIndiv
                                .FirstOrDefault(s => (
                                    (s.elementManagementData.reference != null) &&
                                    s.elementManagementData.reference.qualifier.Equals("OT", StringComparison.InvariantCultureIgnoreCase) &&
                                    s.elementManagementData.segmentName.Equals("SSR", StringComparison.InvariantCultureIgnoreCase) &&
                                    s.serviceRequest.ssr.type.Equals("DOCS", StringComparison.InvariantCultureIgnoreCase)) &&
                                    (s.serviceRequest != null) &&
                                    s.referenceForDataElement[0].number.Equals(p.NumeroPasajero)
                                );

                            if (ldocs != null)
                            {
                                // extrayendo datos con expresión regular
                                var lexpresion = Regex.Match(ldocs.serviceRequest.ssr.freeText[0], Configuracion.GetRegularExpression("UpdatePassengers.Docs"));

                                if (lexpresion.Success)
                                {
                                    p.FechaNacimiento = DateStringAmadeus.ToValidBirthdate(lexpresion.Groups[1].Value, "dd/MM/yyyy");
                                    p.Sexo = ((EnumSexo) Enum.Parse(typeof(EnumSexo), lexpresion.Groups[2].Value));
                                }
                            }
                        }

                        // extrayendo nuevo documento
                        var lnewDocument = informacionBoletos.dataElementsIndiv
                            .FirstOrDefault(d =>
                            {
                                var lok = false;

                                if (d.elementManagementData.reference.qualifier.Equals("OT", StringComparison.InvariantCultureIgnoreCase) &&
                                    d.elementManagementData.segmentName.Equals("FS", StringComparison.InvariantCultureIgnoreCase) &&
                                        d.otherDataFreetext[0].freetextDetail.type.Equals("17"))
                                {
                                    if (d.referenceForDataElement == null)
                                    {
                                        lok = (reserva.Pasajeros.Length == 1);

                                    }
                                    else
                                    {
                                        if (d.referenceForDataElement[0].qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase) &&
                                            d.referenceForDataElement[0].number.Equals(p.NumeroPasajero))
                                        {
                                            lok = true;

                                            if (p.TipoPasajero.IdTipoPasajero.Equals("INF", StringComparison.InvariantCultureIgnoreCase))
                                            {
                                                lok = d.otherDataFreetext[0].longFreetext.StartsWith("INF", StringComparison.InvariantCultureIgnoreCase);
                                            }
                                        }
                                    }
                                }

                                return lok;
                            });

                        if (lnewDocument != null)
                        {
                            // extrayendo datos con expresión regular
                            var lexpresion = Regex.Match(lnewDocument.otherDataFreetext[0].longFreetext, Configuracion.GetRegularExpression("UpdatePassengers.Documents"));

                            if (lexpresion.Success)
                            {
                                if (lexpresion.Groups[2].Value.Equals("RUC", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    p.RUC = lexpresion.Groups[3].Value;

                                }
                                else
                                {
                                    p.TipoDocumento = ProcessPassengerDocumentType(lexpresion.Groups[2].Value);
                                    p.NumeroDocumento = lexpresion.Groups[3].Value;
                                }
                            }
                        }
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lineaAerea"></param>
        /// <param name="numeroVuelo"></param>
        /// <param name="fechaVuelo"></param>
        /// <param name="ciudadOrigen"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        private string ProcessOperatedBy(string lineaAerea,
                                         string numeroVuelo,
                                         string fechaVuelo,
                                         string ciudadOrigen,
                                         string ciudadDestino,
                                         ref CE_Session session)
        {
            // instanciando objeto
            using (var lcommandCryptic = new CommandCryptic(Application, CodigoSeguimiento, MuteErrors))
            {
                // ejecutando despliegue del segmento
                var lresult = lcommandCryptic.DesplegarSegmento(
                    new RQ_DesplegarSegmento
                    {
                        LineaAerea = lineaAerea,
                        NumeroVuelo = numeroVuelo,
                        FechaVuelo = fechaVuelo
                    },
                    ref session);

                if (lresult.Ok)
                {
                    var lsegmentoDesplegadoSinEspacios = Regex.Replace(lresult.Mensajes[0].Valor, Configuracion.GetRegularExpression("PnrRetrieve.OperatedByStep1"), string.Empty);

                    var lmatchOperatedBy = Regex.Match(lsegmentoDesplegadoSinEspacios, string.Format(Configuracion.GetRegularExpression("PnrRetrieve.OperatedByStep2"), ciudadOrigen, ciudadDestino), RegexOptions.Multiline);

                    if (lmatchOperatedBy.Success)
                    {
                        var laerolineaOperadora = lmatchOperatedBy.Groups[3].Value.Trim();

                        // quitamos los ultimos 2 dígitos
                        laerolineaOperadora = laerolineaOperadora.Substring(0, laerolineaOperadora.Length - 2);

                        var lmatch = Regex.Match(laerolineaOperadora, Configuracion.GetRegularExpression("PnrRetrieve.OperatedByStep3"));

                        return (lmatch.Success ? lmatch.Groups[1].Value : laerolineaOperadora).Trim();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionItinerario"></param>
        /// <param name="buscarOperadoPor"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        private CE_Itinerario ProcessOriginDestinationDetails(PNR_ReplyOriginDestinationDetails[] informacionItinerario,
                                                              bool buscarOperadoPor,
                                                              ref CE_Session session)
        {
            if ((informacionItinerario != null) && informacionItinerario.Any())
            {
                var litineraryInfo = informacionItinerario[0].itineraryInfo
                    .Where(i => (
                        i.elementManagementItinerary.segmentName.Equals("AIR", StringComparison.InvariantCultureIgnoreCase) &&
                        (i.relatedProduct != null) &&
                        i.relatedProduct.status.Any(s => (!s.Equals("UN", StringComparison.InvariantCultureIgnoreCase)))))
                    .ToArray();

                if (litineraryInfo.Any())
                {
                    var lsegmentos = new List<CE_Segmento>();

                    // recorriendo itinerario
                    for (var li = 0; li < litineraryInfo.Length; li++)
                    {
                        var lfechaSalida = DateStringAmadeus.ToValidDate(litineraryInfo[li].travelProduct.product.depDate, true);
                        var lfechaLlegada = DateStringAmadeus.ToValidDate(litineraryInfo[li].travelProduct.product.arrDate, true);

                        string loperadoPor = null;

                        // evaluando si leer (buscar) el operador por
                        if ((litineraryInfo[li].itineraryReservationInfo != null) && buscarOperadoPor)
                        {
                            // buscando el operado por
                            loperadoPor = ProcessOperatedBy(
                                    litineraryInfo[li].itineraryReservationInfo.reservation.companyId,
                                    litineraryInfo[li].travelProduct.productDetails.identification,
                                    DateStringAmadeus.ToValidStringDateGds(lfechaSalida.Value),
                                    litineraryInfo[li].travelProduct.boardpointDetail.cityCode,
                                    litineraryInfo[li].travelProduct.offpointDetail.cityCode,
                                    ref session
                                );
                        }

                        lsegmentos.Add(new CE_Segmento
                        {
                            NumeroLinea = ((int) litineraryInfo[li].elementManagementItinerary.lineNumber),
                            NumeroSegmento = int.Parse(litineraryInfo[li].elementManagementItinerary.reference.number),
                            Aerolinea = new CE_Aerolinea
                            {
                                CodigoAerolinea = ((litineraryInfo[li].itineraryReservationInfo == null) ? null : litineraryInfo[li].itineraryReservationInfo.reservation.companyId)
                            },
                            NumeroVuelo = litineraryInfo[li].travelProduct.productDetails.identification,
                            ClaseReserva = litineraryInfo[li].travelProduct.productDetails.classOfService,
                            FechaSalida = DateStringAmadeus.ToValidStringDateGds(lfechaSalida.Value),
                            DiaSemanaSalida = lfechaSalida.Value.DayOfWeek.ToString("D"),
                            HoraSalida = DateStringAmadeus.ToTimeSpan(litineraryInfo[li].travelProduct.product.depTime).Value.ToString(@"hh\:mm"),
                            CiudadSalida = new CE_Ciudad { CodigoCiudadSegmento = litineraryInfo[li].travelProduct.boardpointDetail.cityCode },
                            FechaLlegada = DateStringAmadeus.ToValidStringDateGds(lfechaLlegada.Value),
                            DiaSemanaLlegada = lfechaLlegada.Value.DayOfWeek.ToString("D"),
                            HoraLlegada = DateStringAmadeus.ToTimeSpan(litineraryInfo[li].travelProduct.product.arrTime).Value.ToString(@"hh\:mm"),
                            CiudadLlegada = new CE_Ciudad { CodigoCiudadSegmento = litineraryInfo[li].travelProduct.offpointDetail.cityCode },
                            Status = litineraryInfo[li].relatedProduct.status[0],
                            CantidadAsientos = ((int) litineraryInfo[li].relatedProduct.quantity),
                            CodigoReservaAerolinea = ((litineraryInfo[li].itineraryReservationInfo == null) ? null : litineraryInfo[li].itineraryReservationInfo.reservation.controlNumber),
                            OperadoPor = loperadoPor
                        });
                    }

                    return new CE_Itinerario
                    {
                        Segmentos = lsegmentos.ToArray()
                    };
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="segmentosAsociados"></param>
        /// <param name="identificadorTarifa"></param>
        /// <returns></returns>
        private CE_TipoTarifa ProcessRateType(PNR_ReplyTstDataSelection[] segmentosAsociados,
                                              string identificadorTarifa)
        {
            var ltarifa = new CE_TipoTarifa
            {
                Codigo = ((segmentosAsociados[0].option + segmentosAsociados[1].option).Equals("NF", StringComparison.InvariantCultureIgnoreCase) ? EnumCodigoTarifa.PV : EnumCodigoTarifa.PL),
                Tipo = (identificadorTarifa.Equals("F", StringComparison.InvariantCultureIgnoreCase) ? EnumTipoTarifa.FV : EnumTipoTarifa.IT)
            };

            return ltarifa;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="preciosItinerario"></param>
        /// <param name="segmentos"></param>
        /// <param name="pasajero"></param>
        /// <param name="indicadorPasajero"></param>
        /// <param name="lpseudo"></param>
        /// <param name="lineaValidadora"></param>
        /// <param name="roundTrip"></param>
        /// <param name="existeImpuestoReemisionLan"></param>
        /// <returns></returns>
        private CE_Cotizacion ProcessTstData(PNR_ReplyTstData[] preciosItinerario,
                                             CE_Segmento[] segmentos,
                                             CE_Pasajero pasajero,
                                             string pnr,
                                             string indicadorPasajero,
                                             string lpseudo,
                                             string lineaValidadora,
                                             bool roundTrip,
                                             out bool existeImpuestoReemisionLan)
        {
            var lcotizacion = preciosItinerario
                .Where(p => (
                    p.referenceForTstData.Any(r =>
                        (r.qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase) && r.number.Equals(pasajero.NumeroPasajero))) &&
                    p.tstFreetext.Any(t =>
                        (t.freetextDetail.type.Equals("41") && t.longFreetext.Equals(indicadorPasajero, StringComparison.InvariantCultureIgnoreCase)))))
                .Select(d =>
                {
                    // ciudad destino por defecto
                    var lciudadDestino = segmentos[(segmentos.Length - 1)].CiudadLlegada.CodigoCiudadSegmento;

                    // evaluando si el itinerario es un ida y vuelta
                    if (roundTrip)
                    {
                        // reduciendo la estructura de los farebasis
                        var lfarebasis = d.fareBasisInfo
                            .Select((f, index) => new
                            {
                                index, 
                                connection = string.Format("{0}", f.connection), 
                                f.primaryCode, 
                                f.fareBasis
                            })
                            .ToList();

                        // obteniendo la cantidad de distintas letras que existen
                        var lconnections = d.fareBasisInfo
                            .Where(f => (!string.IsNullOrWhiteSpace(f.connection)))
                            .GroupBy(f => f.connection)
                            .Select(g => new
                            {
                                connection = g.Key, 
                                count = g.Count(), 
                                indexs = lfarebasis.Where(f => f.connection.Equals(g.Key)).Select(f => f.index).ToArray()
                            })
                            .ToList();

                        int? lindiceCiudadDestino = null;

                        // ¿una sola letra 'O' u 'X'?
                        if (lconnections.Count == 1)
                        {
                            lindiceCiudadDestino = (lconnections[0].indexs[0] - ((lconnections[0].count == 1) ? 1 : 0));

                        }
                        else
                        {
                            // recorriendo estrucura resumida de farebasis
                            lfarebasis
                                .Where(f => (!string.IsNullOrWhiteSpace(f.connection)))
                                .ToList()
                                .ForEach(f =>
                                {
                                    // ¿es letra 'O'?
                                    if (f.connection.Equals("O", StringComparison.InvariantCultureIgnoreCase) && (!lindiceCiudadDestino.HasValue))
                                    {
                                        // ¿es letra 'X'?
                                        if ((f.index < (lfarebasis.Count - 1)) && lfarebasis[f.index + 1].connection.Equals("X", StringComparison.InvariantCultureIgnoreCase))
                                        {
                                            lindiceCiudadDestino = (f.index - 1);
                                        }
                                    }
                                });
                        }

                        // evaluando si se pudo hallar el indice de la ciudad destino en los segmentos
                        if (!lindiceCiudadDestino.HasValue)
                        {
                            // forzando excepción
                            throw new InternalException(string.Format("No se puede determinar la ciudad destino - PNR: {0}", pnr));
                        }

                        lciudadDestino = segmentos[lindiceCiudadDestino.Value].CiudadLlegada.CodigoCiudadSegmento;
                    }

                    // construyendo tarifa
                    var ltarifa = new CE_Tarifa
                    {
                        TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = pasajero.TipoPasajero.IdTipoPasajero },
                        Pasajeros = new[] { new CE_Pasajero { NumeroPasajero = pasajero.NumeroPasajero } },
                        Neto = decimal.Parse(d.fareData.monetaryInfo.First(m => m.qualifier.Equals("F", StringComparison.InvariantCultureIgnoreCase)).amount),
                        Total = decimal.Parse(d.fareData.monetaryInfo.First(m => m.qualifier.Equals("T", StringComparison.InvariantCultureIgnoreCase)).amount),
                        Impuestos = d.fareData.taxFields
                            .Select(t => new CE_Impuesto
                            {
                                CodigoImpuesto = t.taxCountryCode,
                                Importe = decimal.Parse(t.taxAmount)
                            }).ToArray(),
                        BaseTarifaria = d.fareBasisInfo
                            .Select((f, i) => new CE_BaseTarifaria
                            {
                                NumeroSegmento = segmentos[i].NumeroSegmento,
                                BaseTarifaria = (f.primaryCode + f.fareBasis),
                            }).ToArray()
                    };

                    return new CE_Cotizacion
                    {
                        NumeroPQ = int.Parse(d.tstGeneralInformation.generalInformation.tstReferenceNumber),
                        Seleccionada = false,
                        TipoTarifa = ProcessRateType(d.segmentAssociation, d.fareData.issueIdentifier),
                        LineasValidadoras = new[] { new CE_Aerolinea { CodigoAerolinea = lineaValidadora } },
                        CiudadDestino = new CE_Ciudad { CodigoCiudadSegmento = lciudadDestino },
                        TotalCotizacion = ltarifa.Total,
                        Pseudo = lpseudo,
                        Tarifas = new[] { ltarifa },
                    };
                })
                .First();

            // evaluando si existe un impuesto por EMD de LAN
            existeImpuestoReemisionLan = lcotizacion.Tarifas.Any(t => 
                t.Impuestos.Any(i => 
                    i.CodigoImpuesto.Equals("OD", StringComparison.InvariantCultureIgnoreCase)));

            return lcotizacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="informacionBoletos"></param>
        /// <param name="preciosItinerario"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private CE_Boleto[] ProcessTicketing(RQ_ObtenerReserva parametros,
                                             PNR_ReplyDataElementsMaster informacionBoletos,
                                             PNR_ReplyTstData[] preciosItinerario,
                                             CE_Reserva reserva)
        {
            if ((informacionBoletos != null) && (informacionBoletos.dataElementsIndiv != null) && informacionBoletos.dataElementsIndiv.Any())
            {
                // obteniendo lineas validadoras
                var llineasValidadoras = informacionBoletos.dataElementsIndiv
                    .Where(d => (
                        d.elementManagementData.segmentName.Equals("FV", StringComparison.InvariantCultureIgnoreCase) &&
                        d.otherDataFreetext[0].freetextDetail.type.Equals("P18", StringComparison.InvariantCultureIgnoreCase)))
                    .SelectMany(c => c.referenceForDataElement.Where(r => r.qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase)), (parent, child) =>
                    {
                        // extrayendo datos con expresión regular
                        var lexpresion = Regex.Match(parent.otherDataFreetext[0].longFreetext, Configuracion.GetRegularExpression("PnrRetrieve.ValidatorLine"));

                        return new
                        {
                            NumeroPasajero = child.number,
                            ExpTipoPasajero = lexpresion.Groups[1].Value,
                            LineaValidadora = lexpresion.Groups[2].Value
                        };
                    })
                    .ToArray();

                var lresult = new List<CE_Boleto>();

                // boletos
                informacionBoletos.dataElementsIndiv
                    .Where(d => (
                        d.elementManagementData.segmentName.Equals("FA", StringComparison.InvariantCultureIgnoreCase) &&
                        d.otherDataFreetext[0].freetextDetail.type.Equals("P06", StringComparison.InvariantCultureIgnoreCase)))
                    .ToList()
                    .ForEach(d =>
                    {
                        // extrayendo datos con expresión regular
                        var lexpresion = Regex.Match(d.otherDataFreetext[0].longFreetext, Configuracion.GetRegularExpression("PnrRetrieve.Ticketing2"));

                        // buscando si el boleto ya fue recolectado
                        var lindiceBoleto = lresult.FindIndex(b => (
                                b.NumeroBoleto.Equals((lexpresion.Groups[2].Value + lexpresion.Groups[3].Value), StringComparison.InvariantCultureIgnoreCase) &&
                                b.Estatus.Equals("ACTIVO", StringComparison.InvariantCultureIgnoreCase))
                            );

                        // buscando si el boleto ya se registro
                        if (lindiceBoleto != -1)
                        {
                            lresult.RemoveAt(lindiceBoleto);
                        }

                        // obteniendo pasajero asociado
                        var lpasajero = reserva.Pasajeros
                            .First(p => (
                                p.NumeroPasajero.Equals(d.referenceForDataElement.First(r => r.qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase)).number) &&
                                ((!lexpresion.Groups[1].Value.Equals("INF", StringComparison.InvariantCultureIgnoreCase)) || p.TipoPasajero.IdTipoPasajero.Equals("INF", StringComparison.InvariantCultureIgnoreCase)))
                            );

                        CE_Segmento[] lsegmentos = null;
                        CE_Cotizacion lcotizacion = null;

                        var lexisteImpuestoReemisionLan = false;

                        // evaluando que no sea un EMD (DT)
                        if (!Advanced.In(lexpresion.Groups[5].Value, "DT", "EV"))
                        {
                            // obteniendo segmentos asociados al boleto
                            var lsegmentosBoleto =
                                d.referenceForDataElement
                                .Where(r => r.qualifier.Equals("ST", StringComparison.InvariantCultureIgnoreCase))
                                .Select(r => new { r.number })
                                .Join(reserva.Itinerario.Segmentos, left => int.Parse(left.number), right => right.NumeroSegmento, (left, right) => right)
                                .OrderBy(o => o.NumeroLinea)           // ES SUMAMENTE IMPORTANTE ORDENAR LOS SEGMENTOS AQUI!!
                                .ToArray();

                            // evaluando si el itinerario es una ida y vuelta
                            var lroundTrip = ((lsegmentosBoleto.Length > 1) &&
                                lsegmentosBoleto[0].CiudadSalida.CodigoCiudadSegmento.Equals(lsegmentosBoleto[(lsegmentosBoleto.Length - 1)].CiudadLlegada.CodigoCiudadSegmento, StringComparison.InvariantCultureIgnoreCase));

                            string llineaValidadora;

                            // evaluando de donde leer la linea validadora (caso boleto emitido por aerolinea)
                            if (llineasValidadoras.Any())
                            {
                                // obteniendo la linea validadora asociada al pasajero
                                llineaValidadora = llineasValidadoras.First(l => 
                                    (l.NumeroPasajero.Equals(lpasajero.NumeroPasajero) && (lexpresion.Groups[1].Value.Equals(l.ExpTipoPasajero, StringComparison.InvariantCultureIgnoreCase))))
                                        .LineaValidadora;

                            }
                            else
                            {
                                llineaValidadora = lexpresion.Groups[6].Value;
                            }

                            // evaluando si leer las cotizaciones
                            if (parametros.LeerCotizaciones && (preciosItinerario != null))
                            {
                                // obteniendo cotización asociada
                                lcotizacion = ProcessTstData(
                                    preciosItinerario,
                                    lsegmentosBoleto,
                                    lpasajero,
                                    reserva.PNR,
                                    lexpresion.Groups[1].Value,
                                    lexpresion.Groups[8].Value,
                                    llineaValidadora,
                                    lroundTrip,
                                    out lexisteImpuestoReemisionLan);
                            }

                            // leyendo segmentos asociados
                            lsegmentos = lsegmentosBoleto
                                .Select(s => new CE_Segmento
                                {
                                    NumeroSegmento = s.NumeroSegmento,
                                    NumeroLinea = s.NumeroLinea,
                                }).ToArray();
                        }

                        lresult.Add(
                            new CE_Boleto
                            {
                                Pseudo = lexpresion.Groups[8].Value,
                                Iata = lexpresion.Groups[9].Value,
                                NumeroBoleto = (lexpresion.Groups[2].Value + lexpresion.Groups[3].Value),
                                Segmentos = lsegmentos,
                                Pasajero = new CE_Pasajero
                                {
                                    NumeroPasajero = lpasajero.NumeroPasajero,
                                    NumeroLinea = lpasajero.NumeroLinea,
                                    TipoPasajero = lpasajero.TipoPasajero
                                },
                                Tipo = (lexpresion.Groups[5].Value.Equals("DT", StringComparison.InvariantCultureIgnoreCase) ? "EMD" : "TE"),          // actualizado de 'TKT' a 'TE' para que sea unificado con la lectura de sabre
                                Estatus = (lexpresion.Groups[5].Value.Equals("EV", StringComparison.InvariantCultureIgnoreCase) ? "VOID" : "ACTIVO"),
                                Reemision = (lexpresion.Groups[5].Value.Equals("DT", StringComparison.InvariantCultureIgnoreCase) || lexisteImpuestoReemisionLan),
                                FechaEmision = lexpresion.Groups[7].Value,
                                EnConjuncion = (string.IsNullOrWhiteSpace(lexpresion.Groups[4].Value) ? ((int?) null) : 1),
                                NumeroBoletoEnConjuncion = (string.IsNullOrWhiteSpace(lexpresion.Groups[4].Value) ? null : lexpresion.Groups[7].Value),
                                Cotizacion = lcotizacion,
                                NumeroLinea = int.Parse(d.elementManagementData.reference.number)
                            });
                    });

                // leyendo boletos reemitidos en "FO"
                var lboletosReemitidos = informacionBoletos.dataElementsIndiv
                    .Where(d => (
                        d.elementManagementData.segmentName.Equals("FO", StringComparison.InvariantCultureIgnoreCase) &&
                        d.otherDataFreetext[0].freetextDetail.type.Equals("45")))
                    .ToList();

                // HAY QUE TENER MUY PRESENTE DE QUE NO HAY FORMA DE RELACIONAR LOS BOLETOS QUE VIENEN EN "FO" CON LOS DE "FA", DADO ESTO SE 
                // MARCAN TODOS LOS BOLETOS COMO DEL "FA COMO REEMISION"
                // evaluando si encontraron boletos reemitidos en "FO"
                if (lboletosReemitidos.Any())
                {
                    // en conversaciones con Hugo Sanchez y Rosa Cardenas el 11/04/2018 si se consiguen boletos en "FO" los todos los boletos
                    // leidos en "FA" se marcan cono reemisiones
                    lresult.ForEach(b => b.Reemision = true);
                }

                // procesando boletos reemitidos en "FO"
                lboletosReemitidos
                    .ForEach(d =>
                    {
                        // extrayendo datos con expresión regular
                        var lexpresion = Regex.Match(d.otherDataFreetext[0].longFreetext, Configuracion.GetRegularExpression("PnrRetrieve.Ticketing1"));

                        // buscando si el boleto ya fue recolectado
                        var lindiceBoleto = lresult.FindIndex(b => (
                                b.NumeroBoleto.Equals((lexpresion.Groups[2].Value + lexpresion.Groups[3].Value), StringComparison.InvariantCultureIgnoreCase) &&
                                b.Estatus.Equals("ACTIVO", StringComparison.InvariantCultureIgnoreCase))
                            );

                        // buscando si el boleto ya se registro
                        if (lindiceBoleto != -1)
                        {
                            lresult.RemoveAt(lindiceBoleto);
                        }

                        // obteniendo pasajero asociado
                        var lpasajero = reserva.Pasajeros
                            .First(p => (
                                p.NumeroPasajero.Equals(d.referenceForDataElement.First(r => r.qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase)).number) &&
                                ((!lexpresion.Groups[1].Value.Equals("INF", StringComparison.InvariantCultureIgnoreCase)) || p.TipoPasajero.IdTipoPasajero.Equals("INF", StringComparison.InvariantCultureIgnoreCase)))
                            );

                        // obteniendo segmentos asociados al boleto
                        var lsegmentosBoleto =
                            d.referenceForDataElement
                            .Where(r => r.qualifier.Equals("ST", StringComparison.InvariantCultureIgnoreCase))
                            .Select(r => new { r.number })
                            .Join(reserva.Itinerario.Segmentos, left => int.Parse(left.number), right => right.NumeroSegmento, (left, right) => right).ToArray();

                        lresult.Add(
                            new CE_Boleto
                            {
                                Iata = lexpresion.Groups[5].Value,
                                NumeroBoleto = (lexpresion.Groups[2].Value + lexpresion.Groups[3].Value),
                                Segmentos = lsegmentosBoleto
                                    .Select(s => new CE_Segmento
                                    {
                                        NumeroSegmento = s.NumeroSegmento,
                                        NumeroLinea = s.NumeroLinea,
                                    }).ToArray(),
                                Pasajero = new CE_Pasajero
                                {
                                    NumeroPasajero = lpasajero.NumeroPasajero,
                                    NumeroLinea = lpasajero.NumeroLinea,
                                    TipoPasajero = lpasajero.TipoPasajero
                                },
                                FechaEmision = lexpresion.Groups[4].Value
                            });
                    });

                return (lresult.Any() ? lresult.ToArray() : null);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="informacionBoletos"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void UpdateTickets(PNR_ReplyDataElementsMaster informacionBoletos,
                                   CE_Reserva reserva)
        {
            if ((informacionBoletos != null) && (informacionBoletos.dataElementsIndiv != null) && informacionBoletos.dataElementsIndiv.Any())
            {
                reserva.Boletos
                    .ToList()
                    .ForEach(b =>
                    {
                        // extrayendo pago
                        var lpago = informacionBoletos.dataElementsIndiv
                            .FirstOrDefault(d => (
                                d.elementManagementData.segmentName.Equals("FP", StringComparison.InvariantCultureIgnoreCase) &&
                                d.elementManagementData.reference.qualifier.Equals("OT", StringComparison.InvariantCultureIgnoreCase) &&
                                (d.otherDataFreetext != null) &&
                                d.otherDataFreetext[0].freetextDetail.type.Equals("16") &&
                                (d.referenceForDataElement != null) &&
                                d.referenceForDataElement.Any(r => (r.qualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase) && r.number.Equals(b.Pasajero.NumeroPasajero))) &&
                                d.otherDataFreetext[0].longFreetext.StartsWith(
                                    (b.Pasajero.TipoPasajero.IdTipoPasajero.Equals("INF", StringComparison.InvariantCultureIgnoreCase) ? "INF" : "PAX"),
                                    StringComparison.InvariantCultureIgnoreCase))
                            );

                        if (lpago != null)
                        {
                            var lpagos = new List<CE_FormaPago>();

                            // extrayendo datos (tarjetas de crédito) con expresión regular
                            var lexpresion = Regex.Match(lpago.otherDataFreetext[0].longFreetext, Configuracion.GetRegularExpression("PnrRetrieve.Payments.Card"));

                            if (lexpresion.Success && (lexpresion.Groups.Count > 0))
                            {
                                if (string.Format("{0}", lexpresion.Groups[1].Value).Equals("CC", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    CE_Tarjeta ltarjeta = null;

                                    if ((!string.IsNullOrWhiteSpace(lexpresion.Groups[4].Value)) || 
                                        (!string.IsNullOrWhiteSpace(lexpresion.Groups[5].Value)) || 
                                            (!string.IsNullOrWhiteSpace(lexpresion.Groups[10].Value)))
                                    {
                                        ltarjeta = new CE_Tarjeta
                                        {
                                            Numero = lexpresion.Groups[4].Value,
                                            FechaVencimiento = lexpresion.Groups[5].Value,
                                            CodigoAprobacion = lexpresion.Groups[10].Value
                                        };
                                    }

                                    lpagos.Add(new CE_FormaPago
                                    {
                                        TipoFormaPago = EnumTipoFormaPago.CARD,
                                        Medio = lexpresion.Groups[2].Value,
                                        Tarjeta = ltarjeta,
                                        CodigoMonedaPago = lexpresion.Groups[7].Value,
                                        MontoPago = Extension.ConvertOrDefault<decimal?>(lexpresion.Groups[8].Value)
                                    });
                                }
                            }

                            // extrayendo datos (tarjetas de crédito) con expresión regular
                            lexpresion = Regex.Match(lpago.otherDataFreetext[0].longFreetext, Configuracion.GetRegularExpression("PnrRetrieve.Payments.Cash"));

                            if (lexpresion.Success && (lexpresion.Groups.Count > 0))
                            {
                                if (string.Format("{0}", lexpresion.Groups[1].Value).Equals("CASH", StringComparison.InvariantCultureIgnoreCase))
                                {
                                    lpagos.Add(new CE_FormaPago
                                    {
                                        TipoFormaPago = EnumTipoFormaPago.CASH,
                                        CodigoMonedaPago = lexpresion.Groups[2].Value,
                                        MontoPago = Extension.ConvertOrDefault<decimal?>(lexpresion.Groups[3].Value)
                                    });
                                }
                            }

                            b.Pagos = lpagos.ToArray();
                        }
                    });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="parametros"></param>
        /// <param name="session"></param>
        /// <param name="estatus"></param>
        /// <param name="reserva"></param>
        /// <returns></returns>
        protected void ProcessResult(PNR_Reply response,
                                     RQ_ObtenerReserva parametros,
                                     ref CE_Session session,
                                     out CE_Estatus estatus,
                                     out CE_Reserva reserva)
        {
            estatus = new CE_Estatus();
            reserva = null;

            if (response == null)
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".Execute return PNR_Reply null");

                return;
            }

            if (response.generalErrorInfo != null)
            {
                // actualizando respuesta (errors)
                estatus.RegistrarErrores(response.generalErrorInfo.SelectMany(s => s.messageErrorText.text));

                return;
            }

            // actualizando respuesta
            estatus.Ok = true;

            reserva = new CE_Reserva
            {
                PNR = parametros.PNR,

                // construyendo información adicional de la reserva
                Referencia = ProcessRpInformation(response.securityInformation.secondRpInformation),

                // construyendo información de cliente
                Cliente = ProcessElementsCustomer(response.dataElementsMaster)
            };

            // evaluando si leer pasajeros
            if (parametros.LeerPasajeros)
            {
                // construyendo lista de pasajeros
                reserva.Pasajeros = ProcessTravellerInfo(response.travellerInfo);

                // actualizando pasajeros
                UpdatePassengers(response.dataElementsMaster, reserva);
            }

            // evaluando si leer los segmentos
            if (parametros.LeerItinerario)
            {
                // construyendo lista de segmentos
                reserva.Itinerario = ProcessOriginDestinationDetails(response.originDestinationDetails, parametros.BuscarOperadoPor, ref session);

                // evaluando si se han cargado segmentos sin codigo de reserva de la aerolinea
                if ((reserva.Itinerario != null) && (reserva.Itinerario.Segmentos != null)
                    && reserva.Itinerario.Segmentos.Any(s => string.IsNullOrWhiteSpace(s.CodigoReservaAerolinea)))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("No se encontro código de reserva de la aerolinea - PNR: {0}", parametros.PNR));
                }

                // ###### EVALUAR SI EXISTE ITINERARIO ######

                // evaluando si leer los boletos
                if (parametros.LeerPasajeros && parametros.LeerBoletos)
                {
                    // construyendo lista de boletos
                    reserva.Boletos = ProcessTicketing(parametros, response.dataElementsMaster, response.tstData, reserva);

                    // evaluando si leer las lineas contables (pagos)
                    if ((reserva.Boletos != null) && (reserva.Boletos.Any()) && parametros.LeerLineasContables)
                    {
                        // actualizando boletos
                        UpdateTickets(response.dataElementsMaster, reserva);
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="webServiceActionHeader"></param>
        /// <param name="typeTransaction"></param>
        /// <param name="request"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        protected TResult Execute<TRequest, TResult>(WebServiceActionHeader4 webServiceActionHeader,
                                                     TransactionType typeTransaction,
                                                     TRequest request,
                                                     ref CE_Session session,
                                                     ref XmlSerializer serializer)
            where TRequest : class
            where TResult : class
        {
            var ltypeTransaction = typeTransaction;

            if (((typeTransaction == TransactionType.InSeries) || (typeTransaction == TransactionType.End)) && (session == null))
            {
                ltypeTransaction = TransactionType.Start;
            }

            var lserviceInformation = AmadeusUtility.GetServiceInformation(webServiceActionHeader);

            var lsessionModel = new SessionWSModel
            {
                TypePasswordEncryption = lserviceInformation.TypePasswordEncryption,
                AmadeusService = lserviceInformation.Action,
                TransactionStatusCode = ((TransactionStatusCodeEnum)ltypeTransaction),
                GetSessionData = true,
                XmlRequest = AmadeusUtility.ToDocument(request)
            };

            // actualizacion sesión
            UpdateSessionBefore(typeTransaction, ref session, ref lsessionModel);

            // procesar modelo de sesión
            ProcessSessionModel(ref lsessionModel, session);

            SOAPHeader4_0.ExecuteSOAPRequest(ref lsessionModel);

            // actualizacion sesión
            UpdateSessionAfter(typeTransaction, ref lsessionModel, ref session);

            // leyendo cuerpo de la respuesta
            var ldocResponse = XMLUtility.GetBody(lsessionModel.XmlResponse);

            // escribiendo payload del response
            var ldocStringXml = ldocResponse.ToString();

            AmadeusUtility.SaveLog(lsessionModel, _xmlRequestForLog, "RQ");
            AmadeusUtility.SaveLog(lsessionModel, lsessionModel.XmlResponse.ToString(), "RS");

            if (lsessionModel.Successful)
            {
                // retornando objeto resultado
                return XmlHelper.XmlDeserialize<TResult>(ldocStringXml, true, true, ref serializer);
            }

            throw new InternalException("No se ejecuto el servicio! XmlError: " + ldocStringXml);
        }

        #endregion
    }
}
