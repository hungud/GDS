using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using CoreLib.Generics;
using CoreLib.Converter;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.FormaPago;
using EntidadesGDS.Boleto;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Ticket_ProcessETicket.Request;
using AmadeusLib.Servicios.Ticket_ProcessETicket.Response;
using EntidadesGDS.General;

namespace AmadeusLib.Ticket
{
    public sealed class TicketProcessETicket : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_TicketProcessETicket;

        private static readonly object _sync_TicketProcessETicket = new object();

        #endregion

        // =============================
        // constantes

        #region "constantes"

        private const string CODIGO_FUNCIONALIDAD_DESPLIEGUE = "131";

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public TicketProcessETicket(EnumAplicaciones application,
                                    string codigoSeguimiento,
                                    bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        {
        }

        ~TicketProcessETicket()
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
        /// <param name="pagos"></param>
        /// <returns></returns>
        private CE_FormaPago[] ProcessPayments(Ticket_ProcessETicketReplyDocumentGroupFop pagos)
        {
            var lresult = new List<CE_FormaPago>();

            var lfops = new List<Ticket_ProcessETicketReplyDocumentGroupFopFormOfPayment>
            {
                pagos.formOfPayment
            };

            if ((pagos.otherFormOfPayment != null) && pagos.otherFormOfPayment.Any())
            {
                // truco para unificar tipos
                lfops.AddRange(pagos.otherFormOfPayment.Select(Advanced.ToCopy<Ticket_ProcessETicketReplyDocumentGroupFopOtherFormOfPayment, Ticket_ProcessETicketReplyDocumentGroupFopFormOfPayment>));
            }

            lfops.ForEach(f =>
            {
                // "CA"
                if (f.type.Equals("CA", StringComparison.InvariantCultureIgnoreCase))
                {
                    lresult.Add(new CE_FormaPago
                    {
                        TipoFormaPago = EnumTipoFormaPago.CASH,
                        Medio = f.type,
                        MontoPago = Extension.ConvertOrDefault<decimal?>(f.amount)
                    });
                }

                // "CC"
                if (f.type.Equals("CC", StringComparison.InvariantCultureIgnoreCase))
                {
                    lresult.Add(new CE_FormaPago
                    {
                        TipoFormaPago = EnumTipoFormaPago.CARD,
                        Medio = f.vendorCode,
                        Tarjeta = new CE_Tarjeta
                        {
                            Numero = f.creditCardNumber,
                            FechaVencimiento = f.expiryDate,
                            CodigoAprobacion = f.approvalCode
                        },
                        MontoPago = Extension.ConvertOrDefault<decimal?>(f.amount)
                    });
                }
            });

            return lresult.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void PreProcessResult(Ticket_ProcessETicketReply response, 
                                      out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if (response == null)
            {
                estatus.RegistrarError(".Execute return Ticket_ProcessETicketReply null");
                return;
            }

            if (response.errorInfo != null)
            {
                estatus.RegistrarError(response.errorInfo.errorDetails.errorCode);
                return;
            }

            if (response.documentGroup != null)
            {
                // actualizando respuesta
                estatus.Ok = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        private void PostProcessResult(Ticket_ProcessETicketReply response,
                                       string numeroBoleto,
                                       out CE_Boleto boleto)
        {
            // contruyendo boleto base
            boleto = new CE_Boleto
            {
                NumeroBoleto = numeroBoleto,
                //Pseudo = 
                Iata = string.Format("{0}", response.documentGroup[0].originatorInfo.originIdentification.originatorId),

                // aqui puede estar la respuesta a ciudad destino -- CHEQUEAR LUEGO CON UNA RESERVA COMPLEJA
                //Segmentos = response.documentGroup[0].originDestination.origin y response.documentGroup[0].originDestination.destination

                // solo he podido visualizar una 'T' por lo que no se sabe de las demás posibilidades
                //Estatus = 

                // construyendo pagos
                Pagos = ProcessPayments(response.documentGroup[0].fop)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="codigoFuncionalidadEjecutar"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private CE_Estatus Execute(ref CE_Session session,
                                   string numeroBoleto,
                                   string codigoFuncionalidadEjecutar,
                                   out Ticket_ProcessETicketReply response)
        {
            Ticket_ProcessETicket lticketProcessETicketRequest = null;

            var lrespuesta = new CE_Estatus();

            response = null;

            try
            {
                // construyendo request
                lticketProcessETicketRequest = new Ticket_ProcessETicket
                {
                    msgActionDetails = new Ticket_ProcessETicketMsgActionDetails
                    {
                        messageFunctionDetails = new Ticket_ProcessETicketMsgActionDetailsMessageFunctionDetails
                        {
                            messageFunction = codigoFuncionalidadEjecutar
                        }
                    },
                    ticketInfoGroup = new[] 
                    {
                        new Ticket_ProcessETicketTicketInfoGroup
                        {
                            ticket = new Ticket_ProcessETicketTicketInfoGroupTicket
                            {
                                documentDetails = new Ticket_ProcessETicketTicketInfoGroupTicketDocumentDetails
                                {
                                    number = numeroBoleto
                                }
                            }
                        }
                    }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lticketProcessETicketRequest }, CodigoSeguimiento);

                lock (_sync_TicketProcessETicket)
                {
                    // procesando solicitud
                    response = Execute<Ticket_ProcessETicket, Ticket_ProcessETicketReply>(
                        WebServiceActionHeader4.TicketProcessETicket,
                        ((TransactionType)session.AmadeusTransactionType),
                        lticketProcessETicketRequest,
                        ref session,
                        ref _serialiazer_TicketProcessETicket);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { response, session }, CodigoSeguimiento);

                // pre procesar respuesta
                PreProcessResult(response, out lrespuesta);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, numeroBoleto, lticketProcessETicketRequest, response, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                response = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        public CE_Estatus DesplegarBoleto(ref CE_Session session,
                                          string numeroBoleto,
                                          out CE_Boleto boleto)
        {
            Ticket_ProcessETicketReply llticketProcessETicketReplyResponse;

            boleto = null;

            var lrespuesta = Execute(ref session, numeroBoleto, CODIGO_FUNCIONALIDAD_DESPLIEGUE, out llticketProcessETicketReplyResponse);

            if (lrespuesta.Ok)
            {
                PostProcessResult(llticketProcessETicketReplyResponse, numeroBoleto, out boleto);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="ticketAnulado"></param>
        /// <returns></returns>
        public CE_Estatus TicketEsAnulado(ref CE_Session session,
                                          string numeroBoleto,
                                          out bool ticketAnulado)
        {
            ticketAnulado = false;

            Ticket_ProcessETicketReply lticketReply;

            var lrespuesta = Execute(ref session, numeroBoleto, CODIGO_FUNCIONALIDAD_DESPLIEGUE, out lticketReply);

            if (lrespuesta.Ok)
            {
                const string lcodigoEstatusAnulado = "V";

                var ldocumentGroup = lticketReply.documentGroup;

                ticketAnulado = (ldocumentGroup != null
                                && ldocumentGroup[0].ticketInfoGroup != null
                                && ldocumentGroup[0].ticketInfoGroup[0].couponInfoGroup != null
                                && ldocumentGroup[0].ticketInfoGroup[0].couponInfoGroup[0].couponInfo.couponDetails.cpnStatus.Equals(lcodigoEstatusAnulado));
            }

            return lrespuesta;
        }

        #endregion
    }
}
