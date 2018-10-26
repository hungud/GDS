using System;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Models.Robot;
using BaseDatosLib.Paquetes;

using GDSLib.Base;
using GDSLib.Utiles;

namespace GDSLib.PTA
{
    public sealed class General : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public General(string codigoSeguimiento,
                       string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public General(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~General()
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
        /// <param name="ciudadObtenida"></param>
        /// <param name="actualizar"></param>
        /// <returns></returns>
        private void PreCompletarCiudad(CE_Ciudad ciudadObtenida,
                                        CE_Ciudad actualizar)
        {
            // completando ciudad
            actualizar.IdPais = ciudadObtenida.IdPais;
            actualizar.NombrePais = ciudadObtenida.NombrePais;
            actualizar.IdRegion = ciudadObtenida.IdRegion;
            actualizar.NombreRegion = ciudadObtenida.NombreRegion;
            actualizar.IdCiudad = ciudadObtenida.IdCiudad;
            actualizar.NombreCiudad = ciudadObtenida.NombreCiudad;
            actualizar.CiudadEquivalente = ciudadObtenida.CiudadEquivalente;
            actualizar.NecesitaDocs = ciudadObtenida.NecesitaDocs;
            actualizar.EsNacional = ciudadObtenida.EsNacional;
            actualizar.EsAeropuerto = ciudadObtenida.EsAeropuerto;
            actualizar.EsEstacionTren = ciudadObtenida.EsEstacionTren;
            actualizar.ProhibeEmision = ciudadObtenida.ProhibeEmision;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="segmento"></param>
        /// <returns></returns>
        private void PreCompletarOperadoPor(CE_Reserva reserva,
                                            CE_Segmento segmento)
        {
            using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
            {
                // evaluando si buscar el operado por
                if (!string.IsNullOrWhiteSpace(segmento.OperadoPor))
                {
                    // evaluando si la reserva es de SABRE
                    if (reserva.Aplicacion.TipoGds == EnumTipoGds.Sabre)
                    {
                        if (segmento.OperadoPor.IndexOf(" FOR ", 0, StringComparison.InvariantCultureIgnoreCase) != -1)
                        {
                            segmento.OperadoPor = segmento.OperadoPor.Split(new[] { " FOR " }, StringSplitOptions.None)[0];
                        }

                        segmento.OperadoPor = segmento.OperadoPor.Replace("OPERATED BY ", string.Empty).Trim();
                        segmento.OperadoPor = (segmento.OperadoPor.Equals("AMERICAN AIRLINES", StringComparison.InvariantCultureIgnoreCase) ? "AA" : segmento.OperadoPor.Replace("/", string.Empty));
                    }

                    List<CE_Transportador> ltransportadores;

                    // evaluando si posiblemente se ha proporcionado un codigo de transportador
                    if (segmento.OperadoPor.Trim().Length == 2)
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTransportadores'", new { segmento.OperadoPor }, CodigoSeguimiento);

                        // No se pudo obtener información de Tranportadores Cambio, Homologas y Equivalentes
                        ltransportadores = lpkgGdsModuloPnrPta.GdsObtenerTransportadores(Conexion, Esquema, segmento.OperadoPor);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerTransportadores'", new { ltransportadores }, CodigoSeguimiento);

                    }
                    else
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTransportadorAsoc'", new { segmento.OperadoPor }, CodigoSeguimiento);

                        // buscando información del transportador asociado
                        ltransportadores = lpkgGdsModuloPnrPta.GdsObtenerTransportadorAsoc(Conexion, Esquema, segmento.OperadoPor);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerTransportadorAsoc'", new { ltransportadores }, CodigoSeguimiento);
                    }

                    // evaluando si NO se obtuvo información de transportadores
                    if ((ltransportadores == null) || (!ltransportadores.Any()))
                    {
                        // forzando excepción
                        throw new InternalException(string.Format("No se pudo obtener información del Tranportador - PNR: {0}", reserva.PNR));
                    }

                    // completando copia
                    segmento.OperadoPor = (string.IsNullOrWhiteSpace(ltransportadores.First().Cambio) ? ltransportadores.First().IdTransportador : ltransportadores.First().Cambio);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="informacionCiudades"></param>
        /// <returns></returns>
        private void PreCompletarSegmentos(CE_Reserva reserva,
                                           List<CE_Ciudad> informacionCiudades)
        {
            using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
            {
                // recorriendo segmentos
                foreach (var lsegmento in reserva.Itinerario.Segmentos)
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTransportadores'", new { lsegmento.Aerolinea.CodigoAerolinea }, CodigoSeguimiento);

                    // buscando información del cambio/homologas/equivalentes para la linea validadora
                    var ltransportadores = lpkgGdsModuloPnrPta.GdsObtenerTransportadores(Conexion, Esquema, lsegmento.Aerolinea.CodigoAerolinea);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerTransportadores'", new { ltransportadores }, CodigoSeguimiento);

                    // evaluando si NO se obtuvo información de transportadores
                    if ((ltransportadores == null) || (!ltransportadores.Any()))
                    {
                        // forzando excepción
                        throw new InternalException(string.Format("No se pudo obtener información de Tranportadores Cambios, Homologas y Equivalentes - PNR: {0}", reserva.PNR));
                    }

                    // filtrando ciudad de salida
                    var lciudad = informacionCiudades.Find(c => c.CodigoCiudadSegmento.Equals(lsegmento.CiudadSalida.CodigoCiudadSegmento, StringComparison.InvariantCultureIgnoreCase));

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarCiudad'", new { lciudad, lsegmento.CiudadSalida }, CodigoSeguimiento);

                    // completando ciudad de salida
                    PreCompletarCiudad(lciudad, lsegmento.CiudadSalida);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarCiudad'", CodigoSeguimiento);

                    // filtrando ciudad de llegada
                    lciudad = informacionCiudades.Find(c => c.CodigoCiudadSegmento.Equals(lsegmento.CiudadLlegada.CodigoCiudadSegmento, StringComparison.InvariantCultureIgnoreCase));

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarCiudad'", new { lciudad, lsegmento.CiudadLlegada }, CodigoSeguimiento);

                    // completando ciudad de llegada
                    PreCompletarCiudad(lciudad, lsegmento.CiudadLlegada);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarCiudad'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarOperadoPor'", CodigoSeguimiento);

                    // completando operador por
                    PreCompletarOperadoPor(reserva, lsegmento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarOperadoPor'", CodigoSeguimiento);

                    // actualizando el indicador de necesita foid
                    lsegmento.Aerolinea.NecesitaFoid = ltransportadores[0].NecesitaFoid;

                    // transformando fechas y horas
                    var lfecha = Utilerias.ToValidDate(lsegmento.FechaSalida);
                    var lhora = Utilerias.ToTimeSpan(lsegmento.HoraSalida);

                    lsegmento.FechaHoraSalida = lfecha.Add(lhora);

                    // transformando fechas y horas
                    lfecha = Utilerias.ToValidDate(lsegmento.FechaLlegada);
                    lhora = Utilerias.ToTimeSpan(lsegmento.HoraLlegada);

                    lsegmento.FechaHoraLlegada = lfecha.Add(lhora);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void PreCompletarItinerario(CE_Reserva reserva)
        {
            // completando copia
            reserva.Itinerario.TipoRuta = (reserva.Itinerario.Segmentos
                .Any(s => ((!s.CiudadSalida.IdPais.Equals("PE", StringComparison.InvariantCultureIgnoreCase)) || (!s.CiudadLlegada.IdPais.Equals("PE", StringComparison.InvariantCultureIgnoreCase))))
                    ? EnumTipoRutaItinerario.Internacional
                    : EnumTipoRutaItinerario.Nacional);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        public void PreCompletarReserva(CE_Reserva reserva)
        {
            if ((reserva.Itinerario == null) || (reserva.Itinerario.Segmentos == null) || (!reserva.Itinerario.Segmentos.Any()))
            {
                // forzando excepción
                throw new InternalException("La Reserva no posee itineario que completar");
            }

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarCliente'", CodigoSeguimiento);

            PreCompletarCliente(reserva.Cliente);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarCliente'", CodigoSeguimiento);

            using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
            {
                // extrayendo codigo de ciudades a buscar
                var lcodigosCiudades = reserva.Itinerario.Segmentos
                    .Select(
                        s => new[] { s.CiudadSalida.CodigoCiudadSegmento, s.CiudadLlegada.CodigoCiudadSegmento })
                    .SelectMany(a => a)
                    .Distinct()
                    .Pipe(l => string.Join(",", l));

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerCiudad'", new { lcodigosCiudades }, CodigoSeguimiento);

                // buscando información de las ciudades de los segmentos
                var lciudades = lpkgGdsModuloPnrPta.GdsObtenerCiudad(Conexion, Esquema, lcodigosCiudades);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerCiudad'", new { lciudades }, CodigoSeguimiento);

                // evaluando si NO se obtuvo información completa de las ciudades de los segmentos
                if ((lciudades == null) || (lciudades.Count != lcodigosCiudades.Split(',').Length))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("No se pudo obtener información completa de las Ciudades: '{0}'", lcodigosCiudades));
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarSegmentos'", CodigoSeguimiento);

                // pre completando segmentos
                PreCompletarSegmentos(reserva, lciudades);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarSegmentos'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarItinerario'", CodigoSeguimiento);

                // pre completando itinerario
                PreCompletarItinerario(reserva);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarItinerario'", CodigoSeguimiento);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public void PreCompletarCliente(CE_Cliente cliente)
        {
            // evaluando si se recibio información pacial del cliente
            if ((cliente != null) && cliente.IdCliente.HasValue && cliente.IdSubCodigo.HasValue)
            {
                using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerCliente'", new { cliente.IdCliente, cliente.IdSubCodigo }, CodigoSeguimiento);

                    // buscando información del cliente
                    var lcliente = lpkgGdsModuloPnrPta.GdsObtenerCliente(Conexion, Esquema, cliente.IdCliente.Value, cliente.IdSubCodigo);

                    // evaluando si NO se obtuvo información del cliente
                    if (lcliente == null)
                    {
                        // forzando excepción
                        throw new InternalException("No se pudo obtener información del Cliente");
                    }

                    // completando copia
                    cliente.NombreCliente = lcliente.NombreCliente;
                    cliente.IdSubCodigo = lcliente.IdSubCodigo;
                    cliente.IdTipoCliente = lcliente.IdTipoCliente;
                    cliente.IdCondicionPago = lcliente.IdCondicionPago;
                    cliente.IdPromotor = lcliente.IdPromotor;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus PreCompletarReserva(CE_Reserva parametros,
                                              out CE_Reserva resultado,
                                              bool muteErrors = true)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                // clonando reserva
                resultado = Advanced.ToCopy<CE_Reserva, CE_Reserva>(parametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.PreCompletarReserva'", new { resultado }, CodigoSeguimiento);

                // precompletando reserva
                PreCompletarReserva(resultado);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.PreCompletarReserva'", new { resultado }, CodigoSeguimiento);

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idGDS"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerPseudosGDS(int idGDS,
                                            out List<CE_PseudoGDS> resultado)
        {
            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsRobotAnulaciones = new PkgGdsRobotAnulaciones(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsRobotAnulaciones.GdsObtenerPseudos'", new { idGDS }, CodigoSeguimiento);

                    // ejecutando procedimiento
                    resultado = lpkgGdsRobotAnulaciones.GdsObtenerPseudos(Conexion, Esquema, idGDS);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsRobotAnulaciones.GdsObtenerPseudos'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { idGDS }, CodigoSeguimiento);

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        #endregion
    }
}
