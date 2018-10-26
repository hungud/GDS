using System;
using System.Collections.Generic;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Boleto;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;
using BaseDatosLib.Paquetes;
using AmadeusLib;
using AmadeusLib.PNR;
using AmadeusLib.Ticket;

using GDSLib.Base;
using System.Threading;

namespace GDSLib.Amadeus
{
    public sealed class Anulacion : Common2
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public Anulacion(EnumAplicaciones aplicacion,
                         string codigoSeguimiento,
                         string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno)
        {
        }

        public Anulacion()
        {
        }

        ~Anulacion()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        private CE_Estatus ActualizarEstadoRealBoletos(ref CE_Session session, string[] boletosAnulados, out CE_Boleto[] resultado)
        {
            var lrespuesta = new CE_Estatus();
            resultado = null;

            using (var lsalesReport = new SalesReportDisplayQueryReport(Aplicacion.Value, CodigoSeguimiento))
            {
                var reporteVenta = lsalesReport.Execute(DateTime.Now.ToString("yyyy-MM-dd"), session.Pseudo, ref session);

                if (reporteVenta.Estatus.Ok)
                {
                    lrespuesta.Ok = true;

                    resultado = reporteVenta.Resultado
                        .Emisiones
                        .Where(s => boletosAnulados.Contains(s.Boleto.NumeroBoleto))
                        .Select(s => s.Boleto)
                        .ToArray();
                }
            }
            return lrespuesta;
        }

        public CE_Estatus AnularBoletos(RQ_AnulacionBoleto request,
                                      out CE_Boleto[] boletosOut,
                                      ref CE_Session session)
        {

            Bitacora.Current.DebugAndInfo("Iniciando proceso de anulación", new { request.Reserva.PNR, request, session }, CodigoSeguimiento);

            var lrespuesta = new CE_Estatus(true);
            boletosOut = null;

            var lmensajesAlerta = new List<string>();
            var lerroresAnulacion = new List<string>();

            var lreserva = request.Reserva;

            try
            {
                if (lreserva.Aplicacion == null)
                {
                    throw new InternalException("No ha proporcionado los datos de Aplicación para la anulación");
                }

                if (lreserva.Usuario == null)
                {
                    throw new InternalException("No ha proporcionado los datos Usuario para anular los boletos");
                }

                if (lreserva.Boletos == null && (lreserva.Boletos.Count(p => (p.Seleccionado ?? false)) != 1))
                {
                    throw new InternalException("No ha proporcionado los boletos que desea anular");
                }

                if (session.Pseudo == null)
                {
                    throw new InternalException("No ha proporcionado el pseudo en el cual se debe abrir sesion");
                }

                // recuperar boletos seleccionados 
                var lboletosAAnular = lreserva.Boletos.Where(s => (s.Seleccionado ?? false)).ToArray();

                // recuperamos la lista de número boletos seleccionados a anular
                var lnumerosBoletosEnviadosAAnular = lboletosAAnular.Select(s => s.NumeroBoleto.Substring(3)).ToList();

                // si el pseudo de la session es distinto al pseudo del boleto a anular
                if (!session.Pseudo.Equals(lreserva.Boletos[0].Pseudo) && session.AmadeusTransactionType != EnumTransactionType.Start)
                {
                    CambiarOficinaDeSesion(lreserva.Boletos[0].Pseudo, ref session);
                }

                // recuperamos la reserva para validar que tenemos contexto para anular y eliminar los remarks
                lrespuesta = RecuperarReserva(lreserva.PNR, out lreserva, ref session);

                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo recuperar la reserva, no se tiene contexto para continuar con la anulación", lrespuesta.Mensajes);
                }

                // recorremos y anulamos los boletos enviados
                foreach (var lcurrentBoleto in lboletosAAnular)
                {
                    // despleagamos el ticket
                    bool lticketEsAnulado;
                    DesplegarTicket_ValidarSiTicketEsAnulado(lcurrentBoleto.NumeroBoleto, out lrespuesta, out lticketEsAnulado, ref session);

                    // si la respuesta no es ok
                    if (!lrespuesta.Ok)
                    {
                        lerroresAnulacion.Add(lcurrentBoleto.NumeroBoleto + " | " + string.Join("/", lrespuesta.Mensajes.Select(s => s.Valor)));
                        continue;
                    }

                    // si el ticket ya esta anulado
                    if (lticketEsAnulado)
                    {
                        lmensajesAlerta.Add(lcurrentBoleto.NumeroBoleto + " | El boleto ya se encuentra anulado.");
                        continue;
                    }

                    // anulacion del ticket
                    bool lanulacionCorrecta;
                    CancelarTicket(lcurrentBoleto.NumeroBoleto, lcurrentBoleto.Pseudo, out lrespuesta, out lanulacionCorrecta, ref session);


                    // si la respuesta no es ok
                    if (!lrespuesta.Ok)
                    {
                        lerroresAnulacion.Add(lcurrentBoleto.NumeroBoleto + " | " + string.Join("/", lrespuesta.Mensajes.Select(s => s.Valor)));
                        continue;
                    }

                    // si no se pudo anular el ticket
                    if (!lanulacionCorrecta)
                    {
                        lmensajesAlerta.Add(lcurrentBoleto.NumeroBoleto + " | No se pudo anular el boleto.");
                        continue;
                    }

                    CompletarInformacionFacturacion(lcurrentBoleto);

                    if (lcurrentBoleto.IdFile.HasValue)
                    {
                        ActualizarEstadosBoletoEnBD(lreserva, lcurrentBoleto, (int)request.Reserva.Aplicacion.TipoGds.Value);
                    }
                }

                // *** DESPLEGAMOS LOS TICKETS NUEVAMENTE PARA RETORNAR EL ESTADO REAL DE LOS BOLETOS  *** 
                boletosOut = ReprocesarEstadoTickets(lboletosAAnular.Select(s => s.NumeroBoleto).ToArray(), ref session);

                // *** RECUPERAMOS LA RESERVA PARA OBTENER CONTEXTO ***
                lrespuesta = RecuperarReserva(lreserva.PNR, out lreserva, ref session);

                // *** Si no podemos obtener la reserva retornamos ***
                if (!lrespuesta.Ok)
                {
                    Thread.Sleep(1000);

                    lrespuesta = RecuperarReserva(lreserva.PNR, out lreserva, ref session);

                    if (!lrespuesta.Ok) 
                    {
                        lrespuesta = new CE_Estatus(false);
                        lrespuesta.RegistrarAlerta("No se pudo recuperar la reserva para eliminar las lineas FA");
                        lrespuesta.Registrar(lmensajesAlerta);
                        lrespuesta.RegistrarAlertas(lerroresAnulacion);
                        return lrespuesta;
                    }
                }

                CompletarNumeroLinea(ref boletosOut, lreserva, request.Reserva);

                // ***
                // *** SI NO SE PRESENTARON MENSAJES DE ERROR AL PROCESAR LOS TICKET SE ASUME QUE ESTAN ANULADOS  *** 
                // ***
                if (lmensajesAlerta.Any() || lerroresAnulacion.Any())
                {
                    // VERIFICAMOS SI EXISTEN TICKETS VOID
                    var lboletosAnuladosCorrectamente = boletosOut.Where(s => s.Estatus.Equals("VOID")).ToList();

                    // Si la cantidad de boletos anulados es igual a la cantidad de boletos enviados a anular, 
                    // significa que los mensajes no interrumpieron el proceso de anulacion
                    if (lboletosAnuladosCorrectamente.Count() == boletosOut.Count())
                    {
                        lerroresAnulacion = new List<string>();
                        lrespuesta = new CE_Estatus(true);
                    }
                    else
                    {
                        // si existen boletos que se anularon correctamente los actualizamos
                        if (lboletosAnuladosCorrectamente.Any())
                        {
                            var lrespuestaAux = new CE_Estatus(true);
                            foreach (var lboleto in lboletosAnuladosCorrectamente)
                            {
                                // agregamos remarks de anulacion correcta!
                                AgregarRemarksAnulacion(lboletosAnuladosCorrectamente.Where(s => s.NumeroLinea != 0).Select(s => s.NumeroBoleto).ToArray(), out lrespuestaAux, ref session);

                                session.AmadeusTransactionType = EnumTransactionType.End;

                                // eliminamos elementos FA donde se encuentren los boletos anulados
                                EliminarElementosFA_BoletosAnulados(boletosOut.Select(s => Convert.ToString(s.NumeroLinea)).ToArray(), true, out lrespuestaAux, ref session);

                                // si no se eliminaron correctamente los elementos FA, continuamos con el flujo, no es transaccional!
                                if (!lrespuesta.Ok)
                                {
                                    Bitacora.Current.DebugAndInfo("Ocurrió un error al eliminar lineas FA", new { lrespuestaAux }, CodigoSeguimiento);
                                }
                            }
                        }

                        if (request.CancelarItinerario)
                        {
                            lrespuesta.RegistrarAlerta("No se anulará el itinerario porque se presentaron errores con la anulación de boletos...");
                        }

                        lrespuesta.Registrar(lmensajesAlerta);
                        lrespuesta.RegistrarAlertas(lerroresAnulacion);

                        return lrespuesta;
                    }
                }

                // ***
                // *** CONTINUAMOS EL FLUJO CON LOS BOLETOS ANULADOS ***
                // ***

                var lrespuestaAuxiliar = new CE_Estatus(true);
                // agregamos remarks de anulacion correcta!
                AgregarRemarksAnulacion(boletosOut.Where(s => s.NumeroLinea != 0).Select(s => s.NumeroBoleto).ToArray(), out lrespuestaAuxiliar, ref session);

                // solo registramos el error más no cortamos el flujo ya que no es transaccional el registro del remark
                if (!lrespuestaAuxiliar.Ok)
                {
                    lmensajesAlerta.Add(string.Join(" / ", lrespuestaAuxiliar.Mensajes.Select(s => s.Valor)));
                    Bitacora.Current.DebugAndInfo("Ocurrió un error al registrar remarks de anulacion", new { lrespuesta }, CodigoSeguimiento);
                }

                // necesario para ejecutar el PnrCancel, solo es true si solo desea anular boletos pero NO cancelar itinerario
                bool lejecutarEndTransaction = false;

                // si no desea cancelar el itinerario se realiza un endTransaction y se establece la sesion como una ultima transacción
                if (!request.CancelarItinerario)
                {
                    lejecutarEndTransaction = true;
                    session.AmadeusTransactionType = EnumTransactionType.End;
                }

                // eliminamos elementos FA donde se encuentren los boletos anulados
                EliminarElementosFA_BoletosAnulados(boletosOut.Select(s => Convert.ToString(s.NumeroLinea)).ToArray(), lejecutarEndTransaction, out lrespuestaAuxiliar, ref session);

                // si no se eliminaron correctamente los elementos FA, continuamos con el flujo, no es transaccional!
                if (!lrespuestaAuxiliar.Ok)
                {
                    lmensajesAlerta.Add(string.Join(" / ", lrespuestaAuxiliar.Mensajes.Select(s => s.Valor)));
                    Bitacora.Current.DebugAndInfo("Ocurrió un error al eliminar lineas FA", new { lrespuesta }, CodigoSeguimiento);
                }

                if (request.CancelarItinerario)
                {
                    session.AmadeusTransactionType = EnumTransactionType.End;
                    EliminarItinerario(out lrespuestaAuxiliar, ref session);

                    if (!lrespuesta.Ok)
                    {
                        lmensajesAlerta.Add(string.Join(" / ", lrespuestaAuxiliar.Mensajes.Select(s => s.Valor))); ;
                    }
                }

                lrespuesta.RegistrarAlertas(lmensajesAlerta);
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            finally
            {
                if (session != null && session.AmadeusTransactionType != EnumTransactionType.End)
                {
                    IgnorarTransaccion(ref session, true);
                }

                Bitacora.Current.DebugAndInfo("Finalizando proceso de anulación", new { request.Reserva.PNR, session }, CodigoSeguimiento);
            }
            return lrespuesta;
        }

        private void CompletarNumeroLinea(ref CE_Boleto[] boletosOut, CE_Reserva reservaRecuperada, CE_Reserva reservaRQ)
        {
            var lnumerosBoletosEnviadosAAnular = reservaRQ.Boletos
                                                        .Where(s => (s.Seleccionado ?? false))
                                                        .Select(s => s.NumeroBoleto)
                                                        .ToArray();

            var lboletosYNumeroReferencia = reservaRecuperada.Boletos
                                      .Where(s => lnumerosBoletosEnviadosAAnular.Contains(s.NumeroBoleto))
                                      .Select(s => new { s.NumeroLinea, s.NumeroBoleto })
                                      .ToList();

            foreach (var lboleto in boletosOut) 
            {
                if (lboletosYNumeroReferencia.Any(s => s.NumeroBoleto.Equals(lboleto.NumeroBoleto))) {
                    lboleto.NumeroLinea = lboletosYNumeroReferencia.Find(s => s.NumeroBoleto.Equals(lboleto.NumeroBoleto)).NumeroLinea;
                }
            }

        }

        private CE_Boleto[] ReprocesarEstadoTickets(string[] numerosBoleto, ref CE_Session session)
        {
            var lout = new List<CE_Boleto>();

            foreach (var lboleto in numerosBoleto)
            {
                bool lticketEsAnulado;
                CE_Estatus lrespuesta;

                DesplegarTicket_ValidarSiTicketEsAnulado(lboleto, out lrespuesta, out lticketEsAnulado, ref session);

                lout.Add(new CE_Boleto
                {
                    NumeroBoleto = lboleto,
                    Estatus = lticketEsAnulado ? "VOID" : "ACTIVO"
                });
            }
            return lout.ToArray();
        }


        #region EliminarElementosFA_BoletosAnulados()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="lnumerosLineaElementosFA"></param>
        /// <param name="ejecutarEndTransaction"></param>
        /// <param name="estatus"></param>
        private void EliminarElementosFA_BoletosAnulados(string[] lnumerosLineaElementosFA, bool ejecutarEndTransaction, out CE_Estatus estatus, ref CE_Session session)
        {
            lnumerosLineaElementosFA = lnumerosLineaElementosFA.Where(s => !s.Equals("0")).ToArray();

            using (var lpnrCancel = new PnrCancel(Aplicacion, CodigoSeguimiento))
            {
                bool lresultadoEjecucion;
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpnrCancel.CancelarElementosItinerario'", new { lnumerosLineaElementosFA, ejecutarEndTransaction, session }, CodigoSeguimiento);
                estatus = lpnrCancel.CancelarElementosItinerario(lnumerosLineaElementosFA, ref session, out lresultadoEjecucion, ejecutarEndTransaction);
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpnrCancel.CancelarElementosItinerario'", new { lnumerosLineaElementosFA, ejecutarEndTransaction, session, estatus }, CodigoSeguimiento);
            }
        }
        #endregion

        #region EliminarItinerario()
        private void EliminarItinerario(out CE_Estatus estatus, ref CE_Session session)
        {
            using (var lpnrCancel = new PnrCancel(Aplicacion, CodigoSeguimiento))
            {
                bool lresultadoEjecucion;
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpnrCancel.CancelarElementosItinerario'", new { session }, CodigoSeguimiento);
                estatus = lpnrCancel.CancelarTodoItinerario(ref session, out lresultadoEjecucion);
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpnrCancel.CancelarElementosItinerario'", new { session }, CodigoSeguimiento);
            }
        }
        #endregion

        #region AgregarRemarksAnulacion()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="boletosAnulados"></param>
        /// <param name="estatus"></param>
        private void AgregarRemarksAnulacion(string[] boletosAnulados, out CE_Estatus estatus, ref CE_Session session)
        {
            estatus = new CE_Estatus();

            var ltextos = boletosAnulados.Select(lcurrentBoleto =>
            {
                if (Aplicacion == EnumAplicaciones.RobotAnulaciones)
                {
                    return string.Format("I* Boleto {0} Anulado Por Robot de Anulaciones", lcurrentBoleto);
                }
                else
                {
                    return string.Format("I* Boleto {0} Anulado Por EasyVOID", lcurrentBoleto);
                }
            }).ToArray();

            using (var lpnrAddMultiElements = new PnrAddMultiElements(Aplicacion, CodigoSeguimiento))
            {
                Bitacora.Current.DebugAndInfo("Por Ejecutar 'lticketCancelDocument.Execute'", new { ltextos, session }, CodigoSeguimiento);

                estatus = lpnrAddMultiElements.AddMiscellaneousRemarks(ref session, ltextos);

                Bitacora.Current.DebugAndInfo("Por Ejecutar 'lticketCancelDocument.Execute'", new { ltextos, estatus }, CodigoSeguimiento);
            }
        }
        #endregion

        #region CompletarInformacionFacturacion()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="boleto"></param>
        private void CompletarInformacionFacturacion(CE_Boleto boleto)
        {
            using (var lpkgGdsBoletos = new PkgGdsRobotBoletos(CodigoSeguimiento, Conexion, Esquema))
            {
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsBoletos.GdsBoletoFacturado'", new { boleto.NumeroBoleto }, CodigoSeguimiento);

                var lticket = lpkgGdsBoletos.GdsBoletoFacturado(boleto.NumeroBoleto.Substring(3));

                if (lticket != null)
                {
                    boleto.IdEmpresa = lticket.IdEmpresa;
                    boleto.IdFile = int.Parse(lticket.IdFile);
                    boleto.IdSucursal = int.Parse(lticket.IdSucursal);
                }

                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsBoletos.GdsBoletoFacturado'", new { boleto.NumeroBoleto, lticket }, CodigoSeguimiento);
            }
        }
        #endregion

        #region CancelarTicket()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="numeroBoleto"></param>
        /// <param name="oficina"></param>
        /// <param name="estatus"></param>
        /// <param name="cancelacionCorrecta"></param>
        private void CancelarTicket(string numeroBoleto, string oficina, out CE_Estatus estatus, out bool cancelacionCorrecta, ref CE_Session session)
        {
            estatus = new CE_Estatus();
            using (var lticketCancelDocument = new TicketCancelDocument(Aplicacion, CodigoSeguimiento))
            {
                Bitacora.Current.DebugAndInfo("Por Ejecutar 'lticketCancelDocument.Execute'", new { numeroBoleto, session }, CodigoSeguimiento);

                estatus = lticketCancelDocument.Execute(ref session, oficina, numeroBoleto, out cancelacionCorrecta);

                Bitacora.Current.DebugAndInfo("Por Ejecutar 'lticketCancelDocument.Execute'", new { numeroBoleto, session }, CodigoSeguimiento);
            }
        }
        #endregion

        #region DesplegarTicket_ValidarSiTicketEsAnulado()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <param name="estatus"></param>
        /// <param name="ticketAnulado"></param>
        /// <param name="session"></param>
        /// <param name="?"></param>
        private void DesplegarTicket_ValidarSiTicketEsAnulado(string numeroBoleto, out CE_Estatus estatus, out bool ticketAnulado, ref CE_Session session)
        {
            ticketAnulado = false;
            estatus = new CE_Estatus();
            using (var ltickectProcessETicket = new TicketProcessETicket(Aplicacion.Value, CodigoSeguimiento))
            {
                Bitacora.Current.DebugAndInfo("Por Ejecutar 'ltickectProcessETicket.TicketEsAnulado'", new { numeroBoleto, session }, CodigoSeguimiento);

                estatus = ltickectProcessETicket.TicketEsAnulado(ref session, numeroBoleto, out ticketAnulado);

                Bitacora.Current.DebugAndInfo("Ejecutado 'ltickectProcessETicket.TicketEsAnulado'", new { numeroBoleto, ticketAnulado, session }, CodigoSeguimiento);
            }
        }
        #endregion

        #region CambiarOficinaSesion()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetOficina"></param>
        /// <param name="session"></param>
        private void CambiarOficinaDeSesion(string targetOficina, ref CE_Session session)
        {
            IgnorarTransaccion(ref session, true);

            Bitacora.Current.DebugAndInfo("Cambiando de oficina", new { targetOficina }, CodigoSeguimiento);
            session = new CE_Session
            {
                AmadeusTransactionType = EnumTransactionType.Start,
                Pseudo = targetOficina
            };
        }
        #endregion CambiarOficinaSesion()

        #region IgnorarTransaccion()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        private void IgnorarTransaccion(ref CE_Session session, bool cerrarSesion = false)
        {
            using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, CodigoEntorno))
            {
                if (cerrarSesion)  session.AmadeusTransactionType = EnumTransactionType.End;

                Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.Ignorar'", new { session }, CodigoSeguimiento);

                var lstatus = lherramienta.Ignorar(ref session);

                Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.Ignorar'", new { session }, CodigoSeguimiento);

                if (!lstatus.Ok)
                {
                    throw new InternalException("No se pudo ignorar la transaccion", lstatus.Mensajes);
                }
            }
        }
        #endregion IgnorarTransaccion()

        #region RecuperaReserva()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="reserva"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        private CE_Estatus RecuperarReserva(string pnr, out CE_Reserva reserva, ref CE_Session session)
        {
            reserva = null;
            using (var litinerario = new Itinerario(Aplicacion.Value, CodigoSeguimiento, CodigoEntorno))
            {
                litinerario.Prepare();

                Bitacora.Current.DebugAndInfo("Por Ejecutar 'litinerario.RecuperarReserva'", new { pnr, session }, CodigoSeguimiento);

                var lrespuesta = litinerario.Obtener(new RQ_ObtenerReserva
                {
                    PNR = pnr,
                    LeerBoletos = true,
                    LeerPasajeros = true,
                    LeerItinerario = true,
                    BuscarOperadoPor = false
                }, out reserva, ref session);

                Bitacora.Current.DebugAndInfo("Ejecutado 'litinerario.RecuperarReserva'", new { pnr, session, reserva }, CodigoSeguimiento);

                return lrespuesta;
            }
        }

        #endregion RecuperaReserva()

        #region ActualizarEstadosBoletoEnBD()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="boleto"></param>
        /// <param name="idGDS"></param>
        private void ActualizarEstadosBoletoEnBD(CE_Reserva reserva, CE_Boleto boleto, int idGDS)
        {
            const string CODIGO_ANULADO_A_SOLICITUD_CLIENTE = "01";
            const string CODIGO_ANULADO_POR_FALTA_PAGO = "06";
            try
            {
                using (var lpkgAnulacion = new PkgGdsAnulacion(CodigoSeguimiento, Conexion, Esquema))
                {
                    var ltextoFile = string.Empty;
                    var lmotivoAnulacion = string.Empty;

                    if (Aplicacion == EnumAplicaciones.RobotAnulaciones)
                    {
                        ltextoFile = string.Format("TKT* {0} FUE ANULADO POR {1}", boleto.NumeroBoleto, Aplicacion.Value);
                        lmotivoAnulacion = CODIGO_ANULADO_POR_FALTA_PAGO;
                    }
                    else
                    {
                        ltextoFile = string.Format("TKT* {0}  FUE ANULADO VIA WEB POR: {1}", boleto.NumeroBoleto, reserva.Usuario.IdVendedorPta);
                        lmotivoAnulacion = CODIGO_ANULADO_A_SOLICITUD_CLIENTE;
                    }

                    var lboletoPax = new CE_BoletoPax
                    {
                        CodReserva = reserva.PNR,
                        NumeroBoleto = boleto.NumeroBoleto.Substring(3),
                        Proveedor = boleto.IdProveedor ?? 0,
                        QuienAnula = reserva.Usuario.IdVendedorPta,
                        MotivoAnulacion = lmotivoAnulacion,
                        FacturarAnulacionAlCliente = 1,
                        SinRefacturarPorAnulacion = 0,
                        NumeroFile = boleto.IdFile ?? 0,
                        IdEmpresa = boleto.IdEmpresa ?? 0,
                        IdSucursal = boleto.IdSucursal ?? 0,
                        TextoFile = ltextoFile,
                        IdVendedor = reserva.Usuario.IdVendedorPta
                    };

                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lpkgAnulacion.lanuladoCorrectamenteEnPTA'", new { boleto }, CodigoSeguimiento);
                    bool lanuladoCorrectamenteEnPTA = lpkgAnulacion.GdsActualizaBoletoPaxVoid(lboletoPax);

                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lpkgAnulacion.GdsIinsertaTextoFile'", new { boleto }, CodigoSeguimiento);
                    bool ltextoInsertadoCorrectamente = lpkgAnulacion.GdsIinsertaTextoFile(lboletoPax);

                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lpkgAnulacion.GdsActualizarEmisionWebVoid'", new { boleto }, CodigoSeguimiento);
                    lpkgAnulacion.GdsActualizarEmisionWebVoid(lboletoPax);

                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lpkgAnulacion.GdsActualizarPnrConfirmacionVoid'", new { boleto }, CodigoSeguimiento);
                    lpkgAnulacion.GdsActualizarPnrConfirmacionVoid(reserva.PNR, idGDS);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, new { boleto }, CodigoSeguimiento);
            }
        }
        #endregion ActualizarEstadosBoletoEnBD()

        #endregion
    }
}
