using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_DispalyTST.Request;
using AmadeusLib.Servicios.Ticket_DispalyTST.Response;

// alias
using Request2 = AmadeusLib.Servicios.Ticket_DispalyTST.Request;

namespace AmadeusLib.Ticket
{
    public sealed class TicketDisplayTST : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketDisplayTST;

        private static readonly object _sync_TicketDisplayTST = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketDisplayTST(EnumAplicaciones? application,
                                string codigoSeguimiento,
                                bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketDisplayTST()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region metodos

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identificadorPrecio"></param>
        /// <param name="calificadorTarifa"></param>
        /// <returns></returns>
        private CE_TipoTarifa ProcessRateType(string identificadorPrecio,
                                              string calificadorTarifa)
        {
            if ((calificadorTarifa + identificadorPrecio).Equals("FI", StringComparison.InvariantCultureIgnoreCase) || 
                calificadorTarifa.Equals("R", StringComparison.InvariantCultureIgnoreCase))
            {
                return new CE_TipoTarifa
                {
                    Codigo = EnumCodigoTarifa.PL,
                    Tipo = EnumTipoTarifa.FV
                };
            }

            if ((calificadorTarifa + identificadorPrecio).Equals("FF", StringComparison.InvariantCultureIgnoreCase))
            {
                return new CE_TipoTarifa
                {
                    Codigo = EnumCodigoTarifa.PV,
                    Tipo = EnumTipoTarifa.FV
                };
            }

            return new CE_TipoTarifa
            {
                Codigo = EnumCodigoTarifa.PV,
                Tipo = EnumTipoTarifa.IT
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <param name="cotizaciones"></param>
        /// <returns></returns>
        private void ProcessResult(Ticket_DisplayTSTReply response,
                                   out CE_Estatus estatus,
                                   out CE_Cotizacion[] cotizaciones)
        {
            estatus = new CE_Estatus();

            cotizaciones = null;

            if (response == null)
            {
                estatus.RegistrarError(".Execute return Ticket_DisplayTSTReply null");
                return;
            }

            if (response.errorGroup != null)
            {
                estatus.RegistrarErrores(response.errorGroup.errorWarningDescription.freeText);
                return;
            }

            if (response.fareList != null)
            {
                // actualizando respuesta
                estatus.Ok = true;

                var lcotizaciones = new List<CE_Cotizacion>(); 

                response.fareList.ToList().ForEach(f1 =>
                {
                    // construyendo tarifa
                    var ltarifa = new CE_Tarifa
                    {
                        TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = f1.statusInformation.firstStatusDetails.tstFlag },
                        Pasajeros = f1.paxSegReference
                            .Where(p => p.refQualifier.Equals("PT", StringComparison.InvariantCultureIgnoreCase))
                            .Select(p => new CE_Pasajero
                            {
                                NumeroPasajero = p.refNumber
                            }).ToArray(),
                        Neto = decimal.Parse(f1.fareDataInformation.fareDataSupInformation
                            .First(f2 => f2.fareDataQualifier.Equals("B", StringComparison.InvariantCultureIgnoreCase)).fareAmount),
                        Total = decimal.Parse(f1.fareDataInformation.fareDataSupInformation
                            .First(f2 => f2.fareDataQualifier.Equals("TFT", StringComparison.InvariantCultureIgnoreCase)).fareAmount),
                        BaseTarifaria = f1.segmentInformation
                            .Where(s1 => (s1.segmentReference != null))
                            .Select(s1 => new CE_BaseTarifaria
                            {
                                NumeroSegmento = int.Parse(s1.segmentReference.First(s2 => s2.refQualifier.Equals("S", StringComparison.InvariantCultureIgnoreCase)).refNumber),
                                BaseTarifaria = (s1.fareQualifier[0].fareBasisDetails.primaryCode + s1.fareQualifier[0].fareBasisDetails.fareBasisCode)
                            }).ToArray()
                    };

                    // evaluando que se obtengan impuestos (hay casos donde para 'INF' no los trae)
                    if ((f1.taxInformation != null) && f1.taxInformation.Any())
                    {
                        ltarifa.Impuestos = f1.taxInformation
                            .Where(t => t.amountDetails.fareDataMainInformation.fareDataQualifier.Equals("TAX", StringComparison.InvariantCultureIgnoreCase))
                            .Select(t => new CE_Impuesto
                            {
                                CodigoImpuesto = t.taxDetails.taxType.isoCountry,
                                Importe = decimal.Parse(t.amountDetails.fareDataMainInformation.fareAmount)
                            }).ToArray();
                    }

                    // construyendo cotización
                    lcotizaciones.Add(new CE_Cotizacion
                    {
                        NumeroPQ = int.Parse(f1.fareReference.uniqueReference),
                        Seleccionada = false,
                        TipoTarifa = ProcessRateType(f1.pricingInformation.tstInformation.tstIndicator, f1.fareDataInformation.fareDataMainInformation.fareDataQualifier),
                        LineasValidadoras = new[] { new CE_Aerolinea { CodigoAerolinea = f1.validatingCarrier.carrierInformation.carrierCode } },
                        //CiudadDestino =
                        TotalCotizacion = ltarifa.Total,
                        //Pseudo = 
                        Tarifas = new[] { ltarifa }
                    });
                });

                cotizaciones = lcotizaciones.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cotizaciones"></param>
        /// <returns></returns>
        public CE_Estatus Execute(ref CE_Session session,
                                  out CE_Cotizacion[] cotizaciones)
        {
            Ticket_DisplayTST lticketDisplayTSTRequest = null;
            Ticket_DisplayTSTReply lticketDisplayTSTReplyResponse = null;

            CE_Estatus lrespuesta;

            cotizaciones = null;

            try
            {
                // construyendo request
                lticketDisplayTSTRequest = new Ticket_DisplayTST
                {
                    displayMode = new Request2.CodedAttributeType
                    {
                        attributeDetails = new Request2.CodedAttributeInformationType
                        {
                            attributeType = "ALL"
                        }
                    }
                    //pnrLocatorData = new nsRQ.ReservationControlInformationTypeI
                    //{
                    //    reservationInformation = new nsRQ.ReservationControlInformationDetailsTypeI
                    //    {
                    //        controlNumber = string.Empty
                    //    }
                    //},
                    //psaInformation = new[] { 
                    //    new nsRQ.ReferencingDetailsTypeI
                    //    {
                    //        refNumber = string.Empty,
                    //        refQualifier = string.Empty
                    //    }
                    //},
                    //scrollingInformation = new nsRQ.ActionDetailsTypeI
                    //{
                    //    nextListInformation = new nsRQ.ReferenceTypeI 
                    //    {
                    //        remainingInformation = string.Empty,
                    //        remainingReference = string.Empty
                    //    }
                    //},
                    //tstReference = new[] { 
                    //    new nsRQ.ItemReferencesAndVersionsType
                    //    {
                    //        iDDescription = new nsRQ.UniqueIdDescriptionType
                    //        {
                    //            iDSequenceNumber = string.Empty
                    //        },
                    //        referenceType = string.Empty,
                    //        uniqueReference = string.Empty
                    //    }
                    //}
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketDisplayTSTRequest, session }, CodigoSeguimiento);

                lock (_sync_TicketDisplayTST)
                {
                    // procesando solicitud
                    lticketDisplayTSTReplyResponse = Execute<Ticket_DisplayTST, Ticket_DisplayTSTReply>(
                        WebServiceActionHeader4.TicketDisplayTST,
                        ((TransactionType)session.AmadeusTransactionType),
                        lticketDisplayTSTRequest,
                        ref session,
                        ref _serialiazer_TicketDisplayTST);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lticketCancelDocumentRS = lticketDisplayTSTReplyResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lticketDisplayTSTReplyResponse, out lrespuesta, out cotizaciones);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lticketDisplayTSTRequest, lticketDisplayTSTReplyResponse }, CodigoSeguimiento);

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
