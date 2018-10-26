using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Boleto;
using EntidadesGDS.Models.Itinerario;
using AmadeusLib.PNR;
using AmadeusLib.Ticket;

using GDSLib.Base;
using GDSLib.PTA;

namespace GDSLib.Amadeus
{
    public sealed class Itinerario : Common2
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
        /// <param name="sesion"></param>
        /// <returns></returns>
        public Itinerario(EnumAplicaciones aplicacion,
                       string codigoSeguimiento,
                       string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno)
        {
        }

        public Itinerario()
        {
        }

        ~Itinerario()
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
        /// <param name="request"></param>
        /// <param name="reserva"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Obtener(RQ_ObtenerReserva request,
                                  out CE_Reserva reserva,
                                  ref CE_Session session)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lpnrRetrieve = new PnrRetrieve(Aplicacion.Value, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'PnrRetrieve.Execute'", CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = lpnrRetrieve.Execute(request, out reserva, ref session);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'PnrRetrieve.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="salida"></param>
        /// <returns></returns>
        public CE_Estatus ModuloComercialPostVenta(CE_Reserva request,
                                                   out CE_Reserva[] salida)
        {
            CE_Estatus lrespuesta;

            try
            {
                // modulo comercial
                using (var lcomisionFee = new ComisionFee(CodigoSeguimiento, CodigoEntorno))
                {
                    lcomisionFee.Conexion = Conexion;
                    lcomisionFee.Esquema = Esquema;

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lgeneral.PreCompletarReserva'", new { request }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lcomisionFee.ProcesandoPostVenta(request, out salida);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lgeneral.PreCompletarReserva'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                salida = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }


        private CE_Estatus RecuperarReserva(string pnr, 
                                            out CE_Reserva reserva, 
                                            bool full, 
                                            ref CE_Session session)
        {
            using (var litinerario = new Itinerario(Aplicacion.Value, CodigoSeguimiento, CodigoEntorno))
            {
                litinerario.Prepare();

                Bitacora.Current.DebugAndInfo("Por Ejecutar 'litinerario.RecuperarReserva'", new { pnr, session }, CodigoSeguimiento);

                var lrqReserva = new RQ_ObtenerReserva
                {
                    PNR = pnr
                };

                if (full) {
                    lrqReserva.LeerBoletos = true;
                    lrqReserva.LeerPasajeros = true;
                    lrqReserva.LeerItinerario = true;
                    lrqReserva.BuscarOperadoPor = false;
                }

                var lrespuesta = litinerario.Obtener(lrqReserva, out reserva, ref session);

                Bitacora.Current.DebugAndInfo("Ejecutado 'litinerario.RecuperarReserva'", new { pnr, session, reserva }, CodigoSeguimiento);

                return lrespuesta;
            }
        }

        public CE_Estatus CancelarItinerario(RQ_PnrCancel request, 
                                             out CE_Reserva reserva, 
                                             ref CE_Session session) 
        {
            var lrespuesta = new CE_Estatus(true);

            try
            {
                if (!request.CancelarTodoItinerario && request.NumeroLineasACancelar == null)
                {
                    throw new InternalException("No ha proporcionado información sobre el/los elementos del itinerario que desea cancelar");
                }

                // si envían PNR se recuperara
                if (!string.IsNullOrEmpty(request.PNR)) 
                {
                    CE_Reserva lreservaAux;
                    lrespuesta = RecuperarReserva(request.PNR, out lreservaAux, true, ref session);

                    if (!lrespuesta.Ok) 
                    {
                        throw new InternalException("No se pudo recuperar para continuar con la anulación del itinerario", lrespuesta.Mensajes);
                    }

                    if (lreservaAux.Itinerario == null) 
                    {
                        throw new InternalException("La reserva no tiene segmentos");
                    }

                }

                // instanciando objeto
                using (var lpnrCancel = new PnrCancel(Aplicacion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpnrCancel.CancelarSegmentosItinerario'", new { request }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    bool lcancelacionOk;

                    if (request.CancelarTodoItinerario)
                    {
                        lpnrCancel.CancelarTodoItinerario(ref session, out lcancelacionOk);
                    }
                    else 
                    {
                        lpnrCancel.CancelarSegmentosItinerario(request.NumeroLineasACancelar, ref session, out lcancelacionOk, true);
                    }
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpnrCancel.CancelarSegmentosItinerario'", new { lrespuesta }, CodigoSeguimiento);
                }

                if (request.CerrarSesion) 
                {
                    session.AmadeusTransactionType = EnumTransactionType.End;
                }

                // recuperando reserva para validar segmentos anulados
                RecuperarReserva(request.PNR, out reserva, true, ref session);

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <param name="sesion"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        public CE_Estatus DesplegarBoleto(string numeroBoleto,
                                          ref CE_Session sesion,
                                          out CE_Boleto boleto)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lticketProcessETicket = new TicketProcessETicket(Aplicacion.Value, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lticketProcessETicket.DesplegarTicket'", new { sesion }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lticketProcessETicket.DesplegarBoleto(ref sesion, numeroBoleto, out boleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lticketProcessETicket.DesplegarTicket'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { numeroBoleto }, CodigoSeguimiento);

                boleto = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="cotizaciones"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerCotizaciones(ref CE_Session session,
                                              out CE_Cotizacion[] cotizaciones)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lticketDisplayTst = new TicketDisplayTST(Aplicacion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lticketDisplayTst.Execute'", new { session }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lticketDisplayTst.Execute(ref session, out cotizaciones);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lticketDisplayTst.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { session }, CodigoSeguimiento);

                cotizaciones = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
