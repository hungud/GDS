using BaseDatosLib.Paquetes;
using CustomLog;
using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Boleto;
using EntidadesGDS.Comentario;
using EntidadesGDS.General;
using EntidadesGDS.Models.Robot;
using EntidadesGDS.Reporte.BoletosEmitidos;
using GDSLib.Base;
using GDSLib.PTA;
using SabreLib.Herramientas;
using SabreLib.Remark;
using SabreLib.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSLib.Sabre
{
    public class Anulacion : Common
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
        public Anulacion(EnumAplicaciones aplicacion,
                               string codigoSeguimiento,
                               string codigoEntorno,
                               CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        public Anulacion()
        {
        }

        #endregion

        // =============================
        // metodos

        #region metodos

        #region AnularBoletos()
        public CE_Estatus AnularBoletos(RQ_AnulacionBoleto parametros,
                                     out CE_Boleto[] boletosOut)
        {
            var lrespuesta = new CE_Estatus(true);
            boletosOut = null;

            var lpseudoCreacion = string.Empty;

            // acumulador de errores solo del proceso de anulación
            var lerroresAnulacion = new List<string>();

            try
            {
                // boletos marcados para anulación
                var lboletosAAnular = parametros.Reserva.Boletos.Where(s => (s.Seleccionado ?? false)).ToArray();

                // agrupamos boletos marcados por pseudo emisión
                var lboletosAgrupadosPorPseudo = lboletosAAnular
                    .GroupBy(gs => new { Pseudo = gs.Pseudo })
                    .Select(s => new
                    {
                        Pseudo = s.Key.Pseudo,
                        Boletos = lboletosAAnular.Where(x => x.Pseudo.Equals(s.Key.Pseudo)).ToArray()
                    });

                // recorremos las agrupaciones de boletos por pseudo
                foreach (var lcurrentAgrupacion in lboletosAgrupadosPorPseudo)
                {
                    // ignoramos transacciones anteriores
                    var lestatusIgnore = IgnorarTransaccion();

                    #region GeneracionNuevoToken
                    // si el token está expirado generamos uno nuevo
                    if (!lestatusIgnore.Ok && lestatusIgnore.Mensajes.Any(s => s.Valor.Contains("Invalid or Expired binary security token:")))
                    {
                        var lcurrentSesion = Sesion;
                        var lestatusCreacion = CrearSession(ref lcurrentSesion);

                        // lanzamos exception no podemos continuar con token expirado
                        if (!lestatusCreacion.Ok) 
                        {
                            throw new InternalException("Token expirado. No se pudo recuperar una nueva sesion.");    
                        }

                        // actualizamos la sesion con el token nuevo
                        Sesion = lcurrentSesion;
                    }

                    #endregion
                    
                    #region CambioContexto
                    // validamos si necesitamos cambiar el contexto
                    bool lnecesitaCambioContexto;
                    VerificarSiNecesitaCambioContexto(lcurrentAgrupacion.Pseudo, out lnecesitaCambioContexto);

                    if (lnecesitaCambioContexto)
                    {
                        CambiarContexto(lcurrentAgrupacion.Pseudo);
                    }
                    #endregion

                    // recuperamos la reserva para ubicarnos en contexto
                    CE_Reserva lreservaRecuperada;
                    lrespuesta = RecuperarReserva(parametros.Reserva.PNR, out lreservaRecuperada);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lrespuesta.Ok)
                    {
                        throw new InternalException("No se pudo recuperar la Reserva", lrespuesta.Mensajes);
                    }

                    // recorremos y anulamos los boletos del pseudo actual
                    foreach (var lcurrentBoleto in lcurrentAgrupacion.Boletos)
                    {
                        var lrespuestaAnulacion = AnularPorNumeroBoleto(parametros.Reserva.PNR, lcurrentBoleto.NumeroBoleto);

                        if (lrespuestaAnulacion.Ok)
                        {
                            // recuperamos informacion de facturacion en la base de datos
                            CompletarInformacionFacturacion(lcurrentBoleto);

                            if (lcurrentBoleto.IdFile.HasValue)
                            {
                                // actualizaciones post anulaciones en base de datos
                                ActualizarEstadosBoletoEnBD(parametros.Reserva, lcurrentBoleto, (int)parametros.Reserva.Aplicacion.TipoGds.Value);
                            }

                            // actualizamos el estado, será verificado mas adelante
                            lcurrentBoleto.Estatus = "VOID";
                        }
                        else
                        {
                            lerroresAnulacion.AddRange(lrespuestaAnulacion.Mensajes.Select(s => s.Valor).ToList());
                        }
                    }

                    // cerramos la transaccion
                    FinalizarTransaccion();
                }


                var lreserva = parametros.Reserva;

                // realizamos reporte diario para actualizar el estado real de los boletos
                ActualizarEstadoRealTickets(ref lreserva);

                // recuperamos la reserva para tener contexto y agregar remarks
                CE_Reserva lreservaAuxiliar;
                RecuperarReserva(parametros.Reserva.PNR, out lreservaAuxiliar);

                // actualizamos valores de referencia
                lreserva.Referencia = lreservaAuxiliar.Referencia;

                // filtramos boletos anulados
                var lboletosAnulados = lreserva.Boletos.Where(s => (s.Seleccionado ?? false) && s.Estatus.Equals("VOID"))
                                                        .Select(s => s.NumeroBoleto).ToArray();

                // agregamos comentarios de anulacion
                AnadirComentariosAnulacion(lboletosAnulados, parametros.Reserva.Usuario.IdVendedorPta);

                // realizamos el release de los boletos 
                RealizarRelease(parametros.Reserva);

                // finalizamos la transaccion
                FinalizarTransaccion();

                // si llego hasta aca la respuesta es true y asigna los boletos enviados con el nuevo estado
                lrespuesta.Ok = true;
                boletosOut = lreserva.Boletos;

            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex);
                lrespuesta = new CE_Estatus(ex);
            }
            finally 
            {
                lrespuesta.RegistrarErrores(lerroresAnulacion);
            }
            return lrespuesta;
        }

        #endregion AnularBoletos()


        #region RealizarRelease()
        public CE_Estatus RealizarRelease(CE_Reserva reserva) 
        {
            var lrespuesta = new CE_Estatus();

            var lpseudos = ObtenerPseudos((int)EnumTipoGds.Sabre);

            if (lpseudos != null && lpseudos.Any()) 
            {
                // si no es pseudo de la empresa 
                if (!lpseudos.Any(s => s.IdPseudo.Equals(reserva.Referencia.PseudoCreacion, StringComparison.InvariantCultureIgnoreCase))) 
                {
                    lrespuesta = Release(reserva.Referencia.PseudoCreacion, reserva.Usuario.InicialesFirma);
                }
            }
            return lrespuesta;
        }

        #endregion RealizarRelease()

        public List<CE_PseudoGDS> ObtenerPseudos(int GDS) 
        {
            var lresultado = new List<CE_PseudoGDS>();
            
            using (var lgeneral = new General(CodigoSeguimiento, CodigoEntorno))
            {
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lgeneral.Prepare'", new { GDS }, CodigoSeguimiento);

                lgeneral.Prepare();

                Bitacora.Current.DebugAndInfo("Ejecutado 'lgeneral.Prepare'", new { GDS }, CodigoSeguimiento);

                Bitacora.Current.DebugAndInfo("Por ejecutar 'lgeneral.ObtenerPseudosGDS'", new { GDS }, CodigoSeguimiento);

                lgeneral.ObtenerPseudosGDS(GDS, out lresultado);

                Bitacora.Current.DebugAndInfo("Por ejecutar 'lgeneral.ObtenerPseudosGDS'", new { GDS }, CodigoSeguimiento);

            }
            return lresultado;
        }

        
            
        #region Pseudos()



        #endregion

        #region VerificarSiNecesitaCambioContexto
        public CE_Estatus VerificarSiNecesitaCambioContexto(string pseudo, out bool necesitaCambioContexto)
        {
            var lrespuesta = new CE_Estatus();

            necesitaCambioContexto = true;

            using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {
                bool lestaTripleado;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.TripleadoEn'", new { pseudo }, CodigoSeguimiento);

                // verificando la reserva
                lrespuesta = lherramienta.TripleadoEn(pseudo, out lestaTripleado);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.TripleadoEn'", new { lrespuesta, lestaTripleado }, CodigoSeguimiento);


                if (lestaTripleado)
                {
                    necesitaCambioContexto = false;
                }
            }

            return lrespuesta;
        }
        #endregion VerificarSiNecesitaCambioContexto

        #region CambiarContexto
        public void CambiarContexto(string pseudoTarget)
        {
            using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.CambiarContexto'", new { pseudoTarget }, CodigoSeguimiento);

                CE_Session lsession;

                // cambiando de pseudo
                var lrespuesta = lherramienta.CambiarContexto(pseudoTarget, out lsession);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.CambiarContexto'", new { lrespuesta, lsession }, CodigoSeguimiento);

                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo Comprobar el cambio de Pseudo", lrespuesta.Mensajes);
                }
                // Asignando nuevo token en session
                Sesion = lsession;
            }
        }
        #endregion CambiarContexto

        #region CrearSession()

        public CE_Estatus CrearSession(ref CE_Session session) 
        {
            var lrespuesta = new CE_Estatus();
            try
            {
                // limpiamos el antiguo token
                session.Token = null;

                using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, null))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lherramienta.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.Prepare'", CodigoSeguimiento);

                    Bitacora.Current.DebugAndInfo("Por Ejecutar 'lherramienta.CrearSesion'", new { session }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lherramienta.CrearSesion(ref session);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.CrearSesion'", new { lrespuesta, session }, CodigoSeguimiento);

                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.Error(ex, new { session, lrespuesta });
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }


        #endregion CrearSession

        #region AnularPorNumeroBoleto()
        public CE_Estatus AnularPorNumeroBoleto(string pnr, string numeroBoleto) 
        {
            var lrespuesta = new CE_Estatus();
            try
            {
                // desplegamos el ticket
                var ldespliegueTicket = DesplegarTicket(numeroBoleto);
                if (!ldespliegueTicket.Ok) 
                {
                    lrespuesta.RegistrarError(numeroBoleto + "|" + string.Join("/", ldespliegueTicket.Mensajes.Select(s => s.Valor)));
                    return lrespuesta;
                }

                // validamos el mensaje de error
                if(ldespliegueTicket.Mensajes.Any(r => r.Valor.Contains("UNABLE TO PROCESS CONTACT SABRE")))
                {
                    // si no puede procesar retornamos
                    lrespuesta.RegistrarError(numeroBoleto + "|" + string.Join("/", ldespliegueTicket.Mensajes.Select(s => s.Valor)));
                    return lrespuesta;
                }

                // validamos que se un ticket electronico 
                if (ldespliegueTicket.Mensajes.Any(r => r.Valor.Contains("TKT:" + numeroBoleto)) && 
                    ldespliegueTicket.Mensajes.Any(r => r.Valor.Contains("ELECTRONIC TICKET RECORD")))
                {
                    // validamos que no se encuentre anulado en el GDS
                    if (ldespliegueTicket.Mensajes.Any(r => r.Valor.Contains("VOID")))
                    {
                        lrespuesta.RegistrarError(numeroBoleto + " | Ticket se encontraba anulado.");
                        return lrespuesta;
                    }
                }
                else 
                {
                    // si no es un ticket electronico retornamos el error con estatus false
                    lrespuesta.RegistrarError(numeroBoleto + "|" + string.Join("/", ldespliegueTicket.Mensajes.Select(s => s.Valor)));
                    return lrespuesta;
                }


                bool lanulacionCorrecta;
                var lrespuestaAnulacion = CancelarTicket(pnr, numeroBoleto, out lanulacionCorrecta);

                if (!lrespuestaAnulacion.Ok)
                {
                    lrespuesta.RegistrarError(numeroBoleto + " | " + string.Join("/", lrespuestaAnulacion.Mensajes.Select(s => s.Valor)));
                    return lrespuesta;
                }

                if (!lanulacionCorrecta)
                {
                    lrespuesta.RegistrarError(numeroBoleto + " | No se pudo anular el boleto. " + string.Join("/", lrespuestaAnulacion.Mensajes.Select(s => s.Valor)));
                    return lrespuesta;
                }

                lrespuesta.Ok = true;
            }
            catch (Exception ex) 
            {
                Bitacora.Current.ErrorAndInfo(ex, new { pnr, numeroBoleto }, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        #endregion AnularPorNumeroBoleto()

        #region ActualizarEstadoRealTickets()
        public void ActualizarEstadoRealTickets(ref CE_Reserva reserva)
        {
            var lpnr = reserva.PNR;

            var lpseudos = reserva.Boletos
                            .Where(s => s.Seleccionado ?? false)
                            .Select(s => s.Pseudo)
                            .Distinct().ToArray();

            foreach (var lpseudo in lpseudos) 
            {
                var lrespuesta = new Reporte(Aplicacion.Value, CodigoSeguimiento, CodigoEntorno, Sesion)
                                    .ObtenerReporteVentas(new RQ_ObtenerReporteVentas
                                    {
                                        Date = DateTime.Now.ToString("yyyy-MM-dd"),
                                        PseudoQuery = lpseudo
                                    });

                if (lrespuesta.Estatus.Ok)
                {
                    foreach (var lboleto in reserva.Boletos) 
                    {
                        var lboletoEnDQB = lrespuesta.Resultado.Emisiones
                                                    .Where(s => s.PNR.Equals(lpnr) && s.Boleto.NumeroBoleto.Equals(lboleto.NumeroBoleto)).FirstOrDefault();

                        if (lboletoEnDQB != null) 
                        {
                            lboleto.Estatus = lboletoEnDQB.Boleto.Estatus;            
                        }
                    }
                }
            }
        }

        #endregion ActualizarEstadoRealTickets()

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
        private CE_Estatus CancelarTicket(string pnr, string numeroBoleto, out bool cancelacionCorrecta)
        {
            var lrespuesta = new CE_Estatus();
            cancelacionCorrecta = false;

            var lrespuestaPrimeraEjecucion = ExecuteWETRV(numeroBoleto);

            if (lrespuestaPrimeraEjecucion.Ok)
            {
                if (lrespuestaPrimeraEjecucion.Mensajes.Any(m => m.Valor.Contains("REENTER IF")))
                {
                    var lrespuestaSegundaEjecucion = ExecuteWETRV(numeroBoleto);

                    if (lrespuestaSegundaEjecucion.Ok)
                    {
                        if (lrespuestaSegundaEjecucion.Mensajes.Any(m => m.Valor.Contains("OK")))
                        {
                            lrespuesta.Ok = true;
                            cancelacionCorrecta = true;
                        }
                        else
                        {
                            lrespuesta.RegistrarErrores(lrespuestaSegundaEjecucion.Mensajes.Select(s => s.Valor).ToArray());
                        }
                    }
                }
                else
                {
                    lrespuesta.RegistrarErrores(lrespuestaPrimeraEjecucion.Mensajes.Select(s => s.Valor).ToArray());
                }
            }
            else
            {
                if (lrespuestaPrimeraEjecucion.Mensajes.Any(m => m.Valor.Contains("ENTRY REQUIRES PNR-DISPLAY PNR AND RETRY")))
                {
                    CE_Reserva lreservaRecuperada;
                    RecuperarReserva(pnr, out lreservaRecuperada);
                    CancelarTicket(pnr, numeroBoleto, out cancelacionCorrecta);
                }
                else 
                {
                    lrespuesta.RegistrarErrores(lrespuestaPrimeraEjecucion.Mensajes.Select(s => s.Valor).ToArray());
                }
            }
            return lrespuesta;
        }
        #endregion

        #region ExecuteWETRV()
        public CE_Estatus ExecuteWETRV(string numeroBoleto)
        {
            var lestatus = new CE_Estatus();

            using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.AnularTicket'", new { numeroBoleto }, CodigoSeguimiento);

                // desplegando Ticket
                lestatus = lherramienta.AnularTicket(numeroBoleto);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.AnularTicket'", new { numeroBoleto, lestatus }, CodigoSeguimiento);
            }

            return lestatus;
        }

        #endregion ExecuteWETRV

        #region AnadirComentariosAnulacion()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facturaCabecera"></param>
        /// <param name="facturaCliente"></param>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        private CE_Estatus AnadirComentariosAnulacion(string[] nroBoletosAnulados, string codigoVendedor)
        {
            CE_Estatus lrespuesta;

            // instanciando objeto
            using (var laddRemark = new AddRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'laddRemark.Prepare'", CodigoSeguimiento);

                // preparar servicio
                laddRemark.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Prepare'", CodigoSeguimiento);


                var lcomentarios = nroBoletosAnulados.Select(lcurrentBoleto => new CE_Comentario
                                                {
                                                    Tipo = EnumTipoComentario.Historical,
                                                    Texto = string.Format("*** Boleto {0} Anulado Por {1}, Usuario {2}  ", lcurrentBoleto, Aplicacion, codigoVendedor)
                                                }).ToArray();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por Ejecutar 'laddRemark.Execute'", new { lcomentarios }, CodigoSeguimiento);

                // ejecutando funcionalidad
                lrespuesta = laddRemark.Execute(lcomentarios);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Execute'", new { lrespuesta }, CodigoSeguimiento);

            }

            return lrespuesta;
        }

        #endregion AnadirComentariosAnulacion

        #region DesplegarTicket()
        public CE_Estatus DesplegarTicket(string numeroBoleto)
        {
            var lestatus = new CE_Estatus(true);

            using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.DesplegarTicket'", new { numeroBoleto }, CodigoSeguimiento);

                // desplegando Ticket
                lestatus = lherramienta.DesplegarTicket(numeroBoleto);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.DesplegarTicket'", new { numeroBoleto, lestatus }, CodigoSeguimiento);

            }
            return lestatus;
        }
        #endregion DesplegarTicket

        #region RecuperarReserva()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="completar"></param>
        /// <param name="reservaRecuperada"></param>
        /// <returns></returns>
        private CE_Estatus RecuperarReserva(string pnr,
                                            out CE_Reserva reservaRecuperada)
        {
            using (var litinerario = new Itinerario(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {
                litinerario.Conexion = Conexion;
                litinerario.Esquema = Esquema;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por Ejecutar 'litinerario.Obtener'", new { pnr }, CodigoSeguimiento);

                // recuperando y completando reserva
                var lrespuesta = litinerario.Obtener(pnr, out reservaRecuperada, false);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'litinerario.Obtener'", new { lrespuesta, reservaRecuperada }, CodigoSeguimiento);

                return lrespuesta;
            }
        }
        #endregion RecuperarReserva

        #region IgnorarTransaccion()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        private CE_Estatus IgnorarTransaccion()
        {
            var lrespuesta = new CE_Estatus();
            try
            {
                // instanciando objeto
                using (var lignoreTransaction = new IgnoreTransaction(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lignoreTransaction.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lignoreTransaction.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lignoreTransaction.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lignoreTransaction.Execute'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lignoreTransaction.Execute();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lignoreTransaction.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        #endregion IgnorarTransaccion

        #region FinalizarTransaccion()
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cerrar"></param>
        /// <returns></returns>
        private CE_Estatus FinalizarTransaccion()
        {
            CE_Estatus lrespuesta;

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
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lendTransaction.FirmarCerrar' | 'lendTransaction.Firmar'", CodigoSeguimiento);

                // evaluando que funcionalidad ejecutar
                lrespuesta = lendTransaction.FirmarCerrar();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lendTransaction.FirmarCerrar' | 'lendTransaction.Firmar'", new { lrespuesta }, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        #endregion FinalizarTransaccion


        #region Release()
        public CE_Estatus Release(string pseudoOrigen, string firma )
        {
            var lestatus = new CE_Estatus(true);

            using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.Release'", new { pseudoOrigen, firma }, CodigoSeguimiento);

                // desplegando Ticket
                lestatus = lherramienta.Release(pseudoOrigen, firma);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.Release'", new { lestatus }, CodigoSeguimiento);

            }
            return lestatus;
        }
        #endregion Release

        #endregion metodos
    }
}
