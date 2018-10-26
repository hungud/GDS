using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using SabreLib.Herramientas;

using GDSLib.Base;

namespace GDSLib.Sabre
{
    public sealed class Herramienta : Common
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
        public Herramienta(EnumAplicaciones aplicacion, 
                           string codigoSeguimiento,
                           string codigoEntorno,
                           CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        public Herramienta()
        {
        }

        ~Herramienta()
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
        /// <param name="sesion"></param>
        /// <returns></returns>
        public CE_Estatus CrearSesion(ref CE_Session sesion)
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lsessionCreate = new SessionCreate(Aplicacion.Value, sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsessionCreate.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lsessionCreate.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsessionCreate.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsessionCreate.Execute'", CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lsessionCreate.Execute(ref sesion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsessionCreate.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus CerrarSesion()
        {
            CE_Estatus lrespuesta;

            try
            {
                // instanciando objeto
                using (var lsessionClose = new SessionClose(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsessionClose.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lsessionClose.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsessionClose.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsessionClose.Execute'", CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lsessionClose.Execute();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsessionClose.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public CE_Estatus CambiarContexto(string pseudo,
                                          out CE_Session sesion)
        {
            CE_Estatus lrespuesta;

            sesion = null;

            try
            {
                // instanciando objeto
                using (var lcontextChange = new ContextChange(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lcontextChange.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lcontextChange.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lcontextChange.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lcontextChange.Execute'", new { pseudo }, CodigoSeguimiento);

                    // ejecutando funcionalidad y actualizando respuesta
                    lrespuesta = lcontextChange.Execute(pseudo, out sesion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lcontextChange.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, CodigoSeguimiento);

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
        public CE_Response2 AsignarPerfilImpresora(CE_Request3<string> request)
        {
            var lrespuesta =  new CE_Response2();

            try
            {
                // instanciando objeto
                using (var ldesignatePrinter = new DesignatePrinter(request.Aplicacion.Value, request.Sesion, request.CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldesignatePrinter.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ldesignatePrinter.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldesignatePrinter.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldesignatePrinter.AsignarPerfilImpresora'", new { request.Parametros }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta.Estatus = ldesignatePrinter.AsignarPerfilImpresora(request.Parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldesignatePrinter.AsignarPerfilImpresora'", new { lrespuesta.Estatus }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Response2 SalirPerfilImpresora(CE_Request3<bool> request)
        {
            var lrespuesta = new CE_Response2();

            try
            {
                // instanciando objeto
                using (var ldesignatePrinter = new DesignatePrinter(request.Aplicacion.Value, request.Sesion, request.CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldesignatePrinter.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ldesignatePrinter.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldesignatePrinter.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldesignatePrinter.SalirPerfilImpresora'", new { request.Parametros }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta.Estatus = ldesignatePrinter.SalirPerfilImpresora(request.Parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldesignatePrinter.SalirPerfilImpresora'", new { lrespuesta.Estatus }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Response2(ex);
            }

            return lrespuesta;
        }

        #region "SabreCommand"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public CE_Estatus EjecutarComando(string comando)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.Execute'", new { comando }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.Execute(comando);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { comando }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus PseudoActual()
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.PseudoActual'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.PseudoActual();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.PseudoActual'", new { lrespuesta }, CodigoSeguimiento);
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
        /// <param name="pseudo"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus TripleadoEn(string pseudo,
                                      out bool resultado)
        {
            CE_Estatus lrespuesta;

            resultado = false;

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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.PseudoActual'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.PseudoActual();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.PseudoActual'", new { lrespuesta }, CodigoSeguimiento);

                    if (lrespuesta.Ok)
                    {
                        resultado = lrespuesta.Mensajes[0].Valor.Substring(0, pseudo.Length).Equals(pseudo, StringComparison.InvariantCultureIgnoreCase);
                    }
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pseudo }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hacia"></param>
        /// <returns></returns>
        public CE_Estatus CambiarPseudo(string hacia)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.CambiarPseudo'", new { hacia }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.CambiarPseudo(hacia);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.CambiarPseudo'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { hacia }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus FinalizarRecuperar()
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.FinalizarRecuperar'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.FinalizarRecuperar();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.FinalizarRecuperar'", new { lrespuesta }, CodigoSeguimiento);
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
        public CE_Estatus IgnorarRecuperar()
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

                    // ejecutando funcionalidad
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
        /// <returns></returns>
        public CE_Estatus BorrarLineasContables()
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.BorrarLineasContables'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.BorrarLineasContables();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.BorrarLineasContables'", new { lrespuesta }, CodigoSeguimiento);
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
        public CE_Estatus BorrarLineaPrecioFutura()
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.BorrarLineaPrecioFutura'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.BorrarLineaPrecioFutura();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.BorrarLineaPrecioFutura'", new { lrespuesta }, CodigoSeguimiento);
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
        /// <param name="pasajero"></param>
        /// <returns></returns>
        public CE_Estatus InsertarFoid(CE_Pasajero pasajero)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.InsertarFoid'", new { pasajero }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.InsertarFoid(pasajero);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.InsertarFoid'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pasajero }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarDk(string idCliente)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.ActualizarDk'", new { idCliente }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.ActualizarDk(idCliente);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.ActualizarDk'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { idCliente }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSubCodigo"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarSubCodigo(string idSubCodigo)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.ActualizarSubCodigo'", new { idSubCodigo }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.ActualizarSubCodigo(idSubCodigo);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.ActualizarSubCodigo'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { idSubCodigo }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        public CE_Estatus DesplegarTicket(string numeroBoleto)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.DesplegarTicket'", new { numeroBoleto }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.DesplegarTicket(numeroBoleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.ActualizarSubCodigo'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { numeroBoleto }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        public CE_Estatus AnularTicket(string numeroBoleto)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.AnularTicket'", new { numeroBoleto }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.AnularTicket();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.ActualizarSubCodigo'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { numeroBoleto }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }


        public CE_Estatus Release(string pseudoOrigen, string firma)
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
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.AnularTicket'", new { pseudoOrigen, firma }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lsabreCommand.Release(pseudoOrigen, firma);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.ActualizarSubCodigo'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { pseudoOrigen, firma }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion

        #endregion
    }
}
