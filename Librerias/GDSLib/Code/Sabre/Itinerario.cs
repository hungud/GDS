using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Comentario;
using EntidadesGDS.General;
using EntidadesGDS.Facturacion;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Boleto;
using SabreLib;
using SabreLib.Remark;
using SabreLib.lItinerary;
using SabreLib.Transaction;
using SabreLib.Herramientas;

using GDSLib.Base;
using GDSLib.Utiles;
using GDSLib.PTA;

namespace GDSLib.Sabre
{
    public sealed class Itinerario : Common
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
                          string codigoEntorno,
                          CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
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

        // CAMBIAR FIRMA
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="reserva"></param>
        /// <param name="completar"></param>
        /// <returns></returns>
        public CE_Estatus Obtener(string pnr,
                                  out CE_Reserva reserva,
                                  bool completar = false)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var ltravelItineraryRead = new TravelItineraryRead(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ltravelItineraryRead.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.ObtenerItinerario'", new { pnr }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = ltravelItineraryRead.ObtenerItinerario(pnr, out reserva);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.ObtenerItinerario'", new { lrespuesta }, CodigoSeguimiento);

                    // evaluando si se pudo recuperar la reserva y si debe ser completada
                    if ((lrespuesta.Ok) && completar)
                    {
                        // pre completando reserva
                        reserva.Aplicacion = new CE_Aplicacion
                        {
                            TipoAplicacion = Aplicacion,
                            TipoGds = EnumTipoGds.Sabre
                        };

                        // completando reserva
                        using (var lgeneral = new General(CodigoSeguimiento, CodigoEntorno))
                        {
                            lgeneral.Conexion = Conexion;
                            lgeneral.Esquema = Esquema;

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lgeneral.PreCompletarReserva'", new { reserva }, CodigoSeguimiento);

                            // ejecutando funcionalidad y actualizando respuesta
                            lgeneral.PreCompletarReserva(reserva);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lgeneral.PreCompletarReserva'", new { lrespuesta }, CodigoSeguimiento);
                        }
                    }
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { pnr, completar }, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pnr, completar }, CodigoSeguimiento);

                reserva = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
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
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var ltravelItineraryRead = new TravelItineraryRead(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ltravelItineraryRead.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.ObtenerLineasContables'", new { pnr }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = ltravelItineraryRead.ObtenerLineasContables(pnr, out lineasContables);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.ObtenerLineasContables'", new { lineasContables, lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pnr }, CodigoSeguimiento);

                lineasContables = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="tarifasAlmacenadas"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerTarifasAlmacenadas(string pnr,
                                                    out CE_Cotizacion[] tarifasAlmacenadas)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var ltravelItineraryRead = new TravelItineraryRead(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ltravelItineraryRead.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.ObtenerTarifasAlmacenadas'", new { pnr }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = ltravelItineraryRead.ObtenerTarifasAlmacenadas(pnr, out tarifasAlmacenadas);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.ObtenerTarifasAlmacenadas'", new { tarifasAlmacenadas, lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pnr }, CodigoSeguimiento);

                tarifasAlmacenadas = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <param name="boleto"></param>
        /// <returns></returns>
        public CE_Estatus DesplegarBoleto(string numeroBoleto,
                                          out CE_Boleto boleto)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lticketCoupon = new TicketCoupon(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lticketCoupon.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lticketCoupon.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lticketCoupon.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lticketCoupon.Execute'", new { numeroBoleto }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = lticketCoupon.Execute(numeroBoleto, out boleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lticketCoupon.Execute'", new { lrespuesta }, CodigoSeguimiento);
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
        /// <returns></returns>
        public CE_Estatus AnadirArunk()
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var larunk = new Arunk(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'larunk.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    larunk.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'larunk.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'larunk.Execute'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = larunk.Execute();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'larunk.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #region "Comentarios"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerComentarios(string pnr,
                                             out CE_Comentario[] comentarios)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var ltravelItineraryRead = new TravelItineraryRead(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ltravelItineraryRead.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryRead.ObtenerComentarios'", new { pnr }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = ltravelItineraryRead.ObtenerComentarios(pnr, out comentarios);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryRead.ObtenerComentarios'", new { lrespuesta, comentarios }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pnr }, CodigoSeguimiento);

                comentarios = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public CE_Estatus AnadirComentarios(CE_Comentario[] comentarios)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var laddRemark = new AddRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'laddRemark.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    laddRemark.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'laddRemark.Execute'", new { comentarios }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = laddRemark.Execute(comentarios);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { comentarios }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarComentarios(CE_Comentario[] comentarios)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lmodifyRemark = new ModifyRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lmodifyRemark.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Actualizar'", new { comentarios }, CodigoSeguimiento);

                    // recuperando reserva
                    lrespuesta = lmodifyRemark.Actualizar(comentarios);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Actualizar'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { comentarios }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idComentarios"></param>
        /// <returns></returns>
        public CE_Estatus BorrarComentarios(int[] idComentarios)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lmodifyRemark = new ModifyRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lmodifyRemark.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Borrar'", new { idComentarios }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lmodifyRemark.Borrar(idComentarios);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Borrar'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { idComentarios }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Estatus BorrarComentariosPorRango(RQ_BorrarRango request)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lmodifyRemark = new ModifyRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lmodifyRemark.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.BorrarPorRango'", new { request.IdComentarioDesde, request.IdComentarioHasta }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lmodifyRemark.BorrarPorRango(request.IdComentarioDesde.Value, request.IdComentarioHasta.Value);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.BorrarPorRango'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion

        #region "Docs & Foids"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="listaSegmentos"></param>
        /// <param name="pasajeroSeleccionado"></param>
        /// <returns></returns>
        public void VerificarDocsFoids(CE_Reserva reserva,
                                       string[] listaSegmentos,
                                       ref CE_Pasajero pasajeroSeleccionado)
        {
            // evaluando los parametros recibidos
            if (pasajeroSeleccionado == null)
            {
                throw new InternalException("El número de Pasajero proporcionado es Incorrecto");
            }

            // extrayendo segmentos seleccionados
            var lsegmentosSeleccionados = reserva.Itinerario.Segmentos.Where(s1 => listaSegmentos.Any(s2 => (s1.NumeroSegmento == int.Parse(s2)))).ToList();

            // buscando si algún segmento necesita foid
            pasajeroSeleccionado.NecesitaFoids = lsegmentosSeleccionados.Any(s => s.Aerolinea.NecesitaFoid.Value);

            // buscando si algún segmento necesita docs
            pasajeroSeleccionado.NecesitaDocs = lsegmentosSeleccionados.Any(s => (s.CiudadSalida.NecesitaDocs.Value || s.CiudadLlegada.NecesitaDocs.Value));

            // ++ EVLUAR DEL LADO DEL CLIENTE SI YA SE POSEE DATOS NO SOLICITARLOS ++
            //// evaluando si se necesita foid
            //if (pasajeroSeleccionado.NecesitaFoids.Value)
            //{
            //    pasajeroSeleccionado.NecesitaFoids = ((!pasajeroSeleccionado.TipoDocumento.HasValue) || string.IsNullOrWhiteSpace(pasajeroSeleccionado.NumeroDocumento));
            //}

            //// evaluando si se necesita docs
            //if (pasajeroSeleccionado.NecesitaDocs.Value)
            //{
            //    pasajeroSeleccionado.NecesitaDocs = (
            //            (!pasajeroSeleccionado.Sexo.HasValue) || (pasajeroSeleccionado.TipoPasajero == null) 
            //                || string.IsNullOrWhiteSpace(pasajeroSeleccionado.TipoPasajero.IdTipoPasajero) || string.IsNullOrWhiteSpace(pasajeroSeleccionado.NumeroDocumento)
            //        );
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="pasajeroSeleccionado"></param>
        /// <returns></returns>
        public CE_Estatus VerificarDocsFoids(string[] parametros,
                                             out CE_Pasajero pasajeroSeleccionado)
        {
            CE_Estatus lrespuesta;

            pasajeroSeleccionado = null;

            try
            {
                CE_Reserva lreserva;

                // evaluando los parametros recibidos
                if ((parametros == null) || (parametros.Count() != 3) || parametros.Any(string.IsNullOrWhiteSpace))
                {
                    throw new InternalException("Los Parametros recibidos son inválidos en cantidad (<> 3) o en valor (nulos)");
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Obtener'", new { parametros_0 = parametros[0] }, CodigoSeguimiento);

                // recuperando reserva y completandola
                lrespuesta = Obtener(parametros[0], out lreserva, true);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Obtener'", new { lrespuesta, lreserva }, CodigoSeguimiento);

                // evaluando si se pudo rescatar y completar la reserva
                if (lrespuesta.Ok)
                {
                    // preparando lista de segmentos a seleccionar
                    var llistaSegmentos = parametros[2].Replace(";", "/").Split('/');

                    // extrayendo pasajero indicado
                    pasajeroSeleccionado = lreserva.Pasajeros.FirstOrDefault(p => p.NumeroPasajero.Equals(parametros[1]));

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.VerificarDocsFoids'", new { lreserva, llistaSegmentos, pasajeroSeleccionado }, CodigoSeguimiento);

                    // verifiando los docs y foids
                    VerificarDocsFoids(lreserva, llistaSegmentos, ref pasajeroSeleccionado);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.VerificarDocsFoids'", new { pasajeroSeleccionado }, CodigoSeguimiento);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { parametros }, CodigoSeguimiento);

                pasajeroSeleccionado = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);

                pasajeroSeleccionado = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anadirFoids"></param>
        /// <param name="anadirDocs"></param>
        /// <param name="segmentosAmericanAirlines"></param>
        /// <param name="segmentosOtrasAerolineas"></param>
        /// <param name="pasajero"></param>
        /// <returns></returns>
        private CE_Estatus InsertarFoidsAndDocs(bool anadirFoids,
                                                bool anadirDocs,
                                                bool segmentosAmericanAirlines,
                                                bool segmentosOtrasAerolineas,
                                                CE_Pasajero pasajero)
        {
            var lrespuesta = new CE_Estatus(true);

            try
            {
                // evaluando si continuar con la insercción de los foids
                if (anadirFoids)
                {
                    // instanciando objeto
                    using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.Prepare'", CodigoSeguimiento);

                        // preparar servicio
                        lsabreCommand.Prepare();

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.Prepare'", CodigoSeguimiento);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.InsertarFoid'", new { pasajero }, CodigoSeguimiento);

                        // insertando foid
                        lrespuesta = lsabreCommand.InsertarFoid(pasajero);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.InsertarFoid'", new { lrespuesta }, CodigoSeguimiento);

                        // evaluando si la operación NO se llevo acabo correctamente / actualziando estatus
                        if (lrespuesta.Ok && (!lrespuesta.Mensajes.Any(m => m.Valor.Contains("*"))))
                        {
                            lrespuesta.Ok = false;
                        }
                    }
                }

                // evaluando si continuar con la insercción de los docs
                if (lrespuesta.Ok && anadirDocs)
                {
                    // instanciando objeto
                    using (var lspecialService = new SpecialService(Aplicacion.Value, Sesion, CodigoSeguimiento))
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lspecialService.Prepare'", CodigoSeguimiento);

                        // preparar servicio
                        lspecialService.Prepare();

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lspecialService.Prepare'", CodigoSeguimiento);

                        if (segmentosAmericanAirlines)
                        {
                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lspecialService.InsertarDocs'", new { esAmericanAirlines = true, pasajero }, CodigoSeguimiento);

                            // insertando doc
                            lrespuesta = lspecialService.InsertarDocs(true, pasajero);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lspecialService.InsertarDocs'", new { lrespuesta }, CodigoSeguimiento);
                        }

                        if (lrespuesta.Ok && segmentosOtrasAerolineas)
                        {
                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lspecialService.InsertarDocs'", new { esAmericanAirlines = true, pasajero }, CodigoSeguimiento);

                            // insertando doc
                            lrespuesta = lspecialService.InsertarDocs(false, pasajero);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lspecialService.InsertarDocs'", new { lrespuesta }, CodigoSeguimiento);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { anadirFoids, anadirDocs, segmentosAmericanAirlines, segmentosOtrasAerolineas }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarFoidsAndDocs(CE_Reserva parametros)
        {
            var lrespuesta = new CE_Estatus(false);

            try
            {
                // evaluando los parametros recibidos en la reserva
                if ((parametros == null) || (parametros.Pasajeros == null) || (parametros.Pasajeros.Count(p => (p.Seleccionado ?? false)) != 1))
                {
                    throw new InternalException("El Pasajero recibido en la reserva es inválido o no ha seleccionado uno unicamente");
                }

                // extrayendo pasajero seleccionado
                var lpasajeroSeleccionado = parametros.Pasajeros.First(p => p.Seleccionado.Value);

                //// evaluando los valores del pasajero seleccionado
                //if (string.IsNullOrWhiteSpace(lpasajeroSeleccionado.NumeroPasajero) || (lpasajeroSeleccionado.TipoDocumento == null)
                //    || string.IsNullOrWhiteSpace(lpasajeroSeleccionado.NumeroDocumento) || (lpasajeroSeleccionado.Sexo == null) || string.IsNullOrWhiteSpace(lpasajeroSeleccionado.FechaNacimiento))
                //{
                //    throw new InternalException("No ha proporcionado todos los datos del Pasajero seleccionado requeridos para actualizar los Foids y Docs");
                //}

                CE_Reserva lreserva;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Obtener'", new { parametros.PNR, completar = true }, CodigoSeguimiento);

                // recuperando reserva
                lrespuesta = Obtener(parametros.PNR, out lreserva, true);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Obtener'", new { lrespuesta, lreserva }, CodigoSeguimiento);

                // evaluando si se pudo rescatar y completar la reserva
                if (lrespuesta.Ok)
                {
                    // extrayendo pasajero actual de la reserva recuperada
                    var lpasajeroActual = lreserva.Pasajeros.First(p => p.NumeroPasajero.Equals(lpasajeroSeleccionado.NumeroPasajero));

                    // actualizando nombres y apellidos al pasajero seleccionado
                    lpasajeroSeleccionado.Nombre = lpasajeroActual.Nombre;
                    lpasajeroSeleccionado.Apellido = lpasajeroActual.Apellido;

                    // evaluando si se va a necesitar foids o docs
                    var lanadirFoids = lreserva.Itinerario.Segmentos.Any(s => s.Aerolinea.NecesitaFoid.Value);
                    var lanadirDocs = lreserva.Itinerario.Segmentos.Any(s => (s.CiudadSalida.NecesitaDocs.Value || s.CiudadLlegada.NecesitaDocs.Value));

                    // evaluando si exiten servicios especiales
                    if (lreserva.ServiciosEspeciales != null)
                    {
                        if (lanadirFoids)
                        {
                            // buscando que NO exista ningún foid para el pasajero actual
                            lanadirFoids = (!lreserva.ServiciosEspeciales.Any(s => (s.Pasajero.NumeroPasajero.Equals(lpasajeroSeleccionado.NumeroPasajero) && (s.Tipo == EnumSpecialServiceInfoType.FOID))));
                        }

                        if (lanadirDocs)
                        {
                            // buscando que NO exista ningún doc para el pasajero actual
                            lanadirDocs = (!lreserva.ServiciosEspeciales.Any(s => (s.Pasajero.NumeroPasajero.Equals(lpasajeroSeleccionado.NumeroPasajero) && (s.Tipo == EnumSpecialServiceInfoType.DOCS))));
                        }
                    }

                    if (lanadirFoids || lanadirDocs)
                    {
                        // buscando si existe algun segmento con aerolinea american airlines
                        var lsegmentosAmericanAirlines = lreserva.Itinerario.Segmentos.Any(s => s.Aerolinea.CodigoAerolinea.Equals("AA", StringComparison.InvariantCultureIgnoreCase));

                        // buscando si existe algun segmento con aerolinea diferente a american airlines
                        var lsegmentosOtrasAerolineas = lreserva.Itinerario.Segmentos.Any(s => (!s.Aerolinea.CodigoAerolinea.Equals("AA", StringComparison.InvariantCultureIgnoreCase)));

                        // obteniendo la cantidad de intentos que se debe de realizar la operación
                        var lintentos = Configuracion.RetriesOfExecution;

                        // ciclo para realizar la operación
                        for (var lr = 1; lr <= lintentos; lr++)
                        {
                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar '.InsertarFoidsAndDocs'", new { lanadirFoids, lanadirDocs, lsegmentosAmericanAirlines, lsegmentosOtrasAerolineas, lpasajeroSeleccionado }, CodigoSeguimiento);

                            // insertando foids y docs
                            lrespuesta = InsertarFoidsAndDocs(lanadirFoids, lanadirDocs, lsegmentosAmericanAirlines, lsegmentosOtrasAerolineas, lpasajeroSeleccionado);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado '.InsertarFoidsAndDocs'", new { lrespuesta }, CodigoSeguimiento);

                            // evaluando si romper ejecución
                            if (!lrespuesta.Ok)
                            {
                                break;
                            }

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar '.GuardarCambios'", CodigoSeguimiento);

                            // guardando cambios
                            lrespuesta = GuardarCambios();

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado '.GuardarCambios'", new { lrespuesta }, CodigoSeguimiento);

                            // evaluando si romper ejecución
                            if (!lrespuesta.Ok)
                            {
                                break;
                            }

                            // evaluando si se presento cambios simultaneos
                            if (lrespuesta.Mensajes.Any(m => m.Valor.Contains("SIMULTANEOUS CHANGES")))
                            {
                                // registrando eventos
                                Bitacora.Current.DebugAndInfo("Por ejecutar '.IgnorarCambiosRecuperar'", CodigoSeguimiento);

                                // ignorar y recuperar
                                lrespuesta = IgnorarCambiosRecuperar();

                                // registrando eventos
                                Bitacora.Current.DebugAndInfo("Ejecutado '.IgnorarCambiosRecuperar'", new { lrespuesta }, CodigoSeguimiento);

                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { parametros }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarPasajeros(RQ_ActualizarPasajeros request)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var ltravelItineraryModifyInfo = new TravelItineraryModifyInfo(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryModifyInfo.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ltravelItineraryModifyInfo.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryModifyInfo.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ltravelItineraryModifyInfo.Execute'", new { request }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = ltravelItineraryModifyInfo.Execute(request);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ltravelItineraryModifyInfo.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CE_Estatus GuardarCambios()
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lendTransaction = new EndTransaction(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lendTransaction.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lendTransaction.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lendTransaction.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lendTransaction.Firmar'", CodigoSeguimiento);

                    // firmar y cerrar
                    lrespuesta = lendTransaction.Firmar();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lendTransaction.Prepare'", new { lrespuesta }, CodigoSeguimiento);

                    // evaluando si la operación SI se ejecuto correctamente
                    if (lrespuesta.Ok)
                    {
                        // instanciando objeto
                        using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
                        {
                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.Prepare'", CodigoSeguimiento);

                            // preparar servicio
                            lsabreCommand.Prepare();

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.Prepare'", CodigoSeguimiento);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.FinalizarRecuperar'", CodigoSeguimiento);

                            // finalizar y recuperar
                            lrespuesta = lsabreCommand.FinalizarRecuperar();

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.FinalizarRecuperar'", new { lrespuesta }, CodigoSeguimiento);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CE_Estatus IgnorarCambiosRecuperar()
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lsabreCommand.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.IgnorarRecuperar'", CodigoSeguimiento);

                    // insertando foid
                    lrespuesta = lsabreCommand.IgnorarRecuperar();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.IgnorarRecuperar'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="cotizacion"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerCotizacion(RQ_ObtenerCotizaciones parametros,
                                            out CE_Cotizacion cotizacion)
        {
            CE_Estatus lrespuesta;

            cotizacion = null;

            try
            {
                // instanciando objeto
                using (var lairPrice = new AirPrice(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lairPrice.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lairPrice.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lairPrice.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lairPrice.Execute'", new { parametros }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lairPrice.Execute(parametros, out cotizacion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lairPrice.Execute'", new { lrespuesta, cotizacion }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
