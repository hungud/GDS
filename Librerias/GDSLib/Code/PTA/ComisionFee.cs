using System;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Generics;
using CoreWebLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Boleto;
using EntidadesGDS.ComisionFeePta;
using BaseDatosLib.Procedimientos;
using BaseDatosLib.Paquetes;

using GDSLib.Base;
using GDSLib.Utiles;

namespace GDSLib.PTA
{
    public sealed class ComisionFee : Common
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
        public ComisionFee(string codigoSeguimiento,
                           string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public ComisionFee(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~ComisionFee()
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
        /// <param name="reserva"></param>
        /// <param name="indiceCotizacion"></param>
        /// <param name="indiceLineaValidadora"></param>
        /// <returns></returns>
        private void PostCompletarCotizacion(CE_Reserva reserva,
                                             int indiceCotizacion,
                                             int indiceLineaValidadora)
        {
            using (var lpkgGdsModuloPnrPta = new PkgGdsModuloPnrPta(CodigoSeguimiento))
            {
                string liata;
                string lidEmpresa;

                // evaluando pseudo de emisión contra pseudo de cotización
                if (!reserva.Aplicacion.PseudoEmision.Trim().Equals(reserva.Cotizaciones[indiceCotizacion].Pseudo.Trim(), StringComparison.InvariantCultureIgnoreCase))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - EL PSEUDO DE EMISIÓN NO ES EL MISMO QUE EL PSEUDO DE COTIZACIÓN.", reserva.PNR));
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerIataEmpresa'", new { reserva.Aplicacion.TipoGds, reserva.Aplicacion.PseudoEmision }, CodigoSeguimiento);

                // buscando iata y id empresa
                lpkgGdsModuloPnrPta.GdsObtenerIataEmpresa(Conexion, Esquema, reserva.Aplicacion.TipoGds.Value, reserva.Aplicacion.PseudoEmision, out liata, out lidEmpresa);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerIataEmpresa'", new { liata, lidEmpresa }, CodigoSeguimiento);

                // evaluando si NO se obtuvo información de IATA e IdEmpresa
                if (string.IsNullOrWhiteSpace(liata) || string.IsNullOrWhiteSpace(lidEmpresa))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER INFORMACIÓN DE IATA Y/O ID EMPRESA.", reserva.PNR));
                }

                List<CE_Transportador> ltransportadores;

                // evaluando si la cotización no posee código de aerolinea
                if (string.IsNullOrWhiteSpace(reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea))
                {
                    if (string.IsNullOrWhiteSpace(reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].IdPrefijo))
                    {
                        // forzando excepción
                        throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE RECIBIO INFORMACIÓN DEL TRANPORTADOR.", reserva.PNR));
                    }

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTransportadoresPorPrefijo'", new { reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].IdPrefijo }, CodigoSeguimiento);

                    // buscando información del cambio/homologas/equivalentes para la linea validadora
                    ltransportadores = lpkgGdsModuloPnrPta.GdsObtenerTransportadoresPorPrefijo(
                        Conexion,
                        Esquema,
                        reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].IdPrefijo);

                }
                else
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTransportadores'", new { reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea }, CodigoSeguimiento);

                    // buscando información del cambio/homologas/equivalentes para la linea validadora
                    ltransportadores = lpkgGdsModuloPnrPta.GdsObtenerTransportadores(
                        Conexion,
                        Esquema,
                        reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerTransportadoresPorPrefijo'", new { ltransportadores }, CodigoSeguimiento);

                // evaluando si NO se obtuvo información de transportadores
                if ((ltransportadores == null) || (!ltransportadores.Any()))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER INFORMACIÓN DE TRANPORTADORES CAMBIOS, HOMOLOGAS Y EQUIVALENTES.", reserva.PNR));
                }

                // completando copia
                reserva.Cotizaciones[indiceCotizacion].Iata = liata;
                reserva.Cotizaciones[indiceCotizacion].IdEmpresa = lidEmpresa;
                reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea = ltransportadores.First().Cambio;
                reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Homologas =
                    Strings.ToArray(true, reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea, ltransportadores.First().Homologa);
                reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Equivalentes =
                    Strings.ToArray(true, reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea, ltransportadores.First().Equivalente);

                // evaluando si se posee la ciudad destino
                if (reserva.Cotizaciones[indiceCotizacion].CiudadDestino == null)
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE POSEE INFORMACIÓN DE LA CIUDAD DESTINO.", reserva.PNR));
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerCiudad'", new { reserva.Cotizaciones[indiceCotizacion].CiudadDestino.CodigoCiudadSegmento }, CodigoSeguimiento);

                // buscando información de la ciudad destino
                var lciudades = lpkgGdsModuloPnrPta.GdsObtenerCiudad(Conexion, Esquema, reserva.Cotizaciones[indiceCotizacion].CiudadDestino.CodigoCiudadSegmento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerCiudad'", new { lciudades }, CodigoSeguimiento);

                // evaluando si NO se obtuvo información de las ciudades de los segmentos
                if ((lciudades == null) || (!lciudades.Any()))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER INFORMACIÓN DE LAS CIUDADES.", reserva.PNR));
                }

                // completando copia
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdPais = lciudades[0].IdPais;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.NombrePais = lciudades[0].NombrePais;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdRegion = lciudades[0].IdRegion;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.NombreRegion = lciudades[0].NombreRegion;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdCiudad = lciudades[0].IdCiudad;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.NombreCiudad = lciudades[0].NombreCiudad;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.CiudadEquivalente = lciudades[0].CiudadEquivalente;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.NecesitaDocs = lciudades[0].NecesitaDocs;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.EsNacional = lciudades[0].EsNacional;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.EsAeropuerto = lciudades[0].EsAeropuerto;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.EsEstacionTren = lciudades[0].EsEstacionTren;
                reserva.Cotizaciones[indiceCotizacion].CiudadDestino.ProhibeEmision = lciudades[0].ProhibeEmision;

                // leyendo la representación literal del id del tipo de pasajero
                var lidTipoPasajero = reserva.Cotizaciones[indiceCotizacion].Tarifas.Select(t => t.TipoPasajero.IdTipoPasajero).Pipe(l => string.Join(",", l));

                // leyendo código de aerolinea transportadora
                var ltransportador = ((reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Codigo == EnumCodigoTarifa.PL) 
                    ? null 
                    : reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTipoPasajero'", new { reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Codigo, lidTipoPasajero, ltransportador }, CodigoSeguimiento);

                // buscando información de los tipo de pasajero
                var ltiposPasajero = lpkgGdsModuloPnrPta.GdsObtenerTipoPasajero(
                    Conexion,
                    Esquema,
                    reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Codigo.Value,
                    lidTipoPasajero,
                    ltransportador);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerTipoPasajero'", new { ltiposPasajero }, CodigoSeguimiento);

                // evaluando si NO se obtuvo información de los tipo de pasajero
                if ((ltiposPasajero == null) || (!ltiposPasajero.Any()))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER INFORMACIÓN DE LOS TIPO DE PASAJERO.", reserva.PNR));
                }

                // recorriendo tarifas
                foreach (var ltarifa in reserva.Cotizaciones[indiceCotizacion].Tarifas)
                {
                    // 
                    // HAY QUE MODIFICAR ESTO PARA CUANDO LOS TIPOS DE PASAJERO DEVUELVAN "ITX" PARA PRIVADAS
                    // DESPUES DE QUE SE AGREGUE LA NUEVA COLUMNA A LA TABLA Y SE MODIFIQUE EL PROCEDIMIENTO
                    // (SEGURAMENTE SE USARA EL EQUIVALE PARA CALZAR CON EL TIPO DE PASAJERO DE LA COTIZACION)
                    //

                    // filtrando tipo de pasajero
                    var ltipoPasajero = ltiposPasajero.Find(t => t.IdTipoPasajero.Equals(ltarifa.TipoPasajero.IdTipoPasajero, StringComparison.InvariantCultureIgnoreCase));

                    // completando copia
                    ltarifa.TipoPasajero.Equivale = ltipoPasajero.Equivale;
                    ltarifa.TipoPasajero.Pertenece = ltipoPasajero.Pertenece;
                    ltarifa.TipoPasajero.PerteneceAmadeus = ltipoPasajero.PerteneceAmadeus;
                    ltarifa.TipoPasajero.RequiereAsiento = ltipoPasajero.RequiereAsiento;
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnrPta.GdsObtenerTipoStock'", new { reserva.Aplicacion.TipoGds, reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Codigo, reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Tipo }, CodigoSeguimiento);

                // obteniendo tipo de stock
                reserva.Cotizaciones[indiceCotizacion].TipoStock = lpkgGdsModuloPnrPta.GdsObtenerTipoStock(
                    Conexion,
                    Esquema,
                    reserva.Aplicacion.TipoGds.Value,
                    reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Codigo.Value,
                    reserva.Cotizaciones[indiceCotizacion].TipoTarifa.Tipo.Value);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnrPta.GdsObtenerTipoStock'", new { reserva.Cotizaciones[indiceCotizacion].TipoStock }, CodigoSeguimiento);

                // evaluando si NO se obtuvo información del tipo de stock
                if (string.IsNullOrWhiteSpace(reserva.Cotizaciones[indiceCotizacion].TipoStock))
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER INFORMACIÓN DEL TIPO DE STOCK.", reserva.PNR));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="indiceCotizacion"></param>
        /// <returns></returns>
        private void PostCompletarSegmentos(CE_Reserva reserva,
                                            int indiceCotizacion)
        {
            var lencontro = false;

            // seleccionando segmentos con los que trabajar
            reserva.Cotizaciones[indiceCotizacion].Tarifas
                .SelectMany(t => t.BaseTarifaria, (parent, child) => child.NumeroSegmento)
                    .Distinct()
                        .ToList()
                            .ForEach(i =>
                            {
                                reserva.Itinerario.Segmentos.First(s => (s.NumeroSegmento == i)).Seleccionado = true;
                            });

            // actualizando la segmentos
            reserva.Itinerario.Segmentos
                .Where(s => (s.Seleccionado ?? false))
                    .ToList()
                        .ForEach(s =>
                        {
                            if (!lencontro)
                            {
                                s.EsSalida = true;
                                lencontro = s.CiudadLlegada.IdCiudad.Equals(reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdCiudad, StringComparison.InvariantCultureIgnoreCase);
                            }
                        });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="indiceCotizacion"></param>
        /// <param name="indiceLineaValidadora"></param>
        /// <returns></returns>
        private void PostCompletarItinerario(CE_Reserva reserva,
                                             int indiceCotizacion,
                                             int indiceLineaValidadora)
        {
            // filtrando segmentos seleccionados
            var lsegmentosSeleccionados = reserva.Itinerario.Segmentos.Where(s => (s.Seleccionado ?? false)).ToList();

            // completando copia
            reserva.Itinerario.TipoViaje =
                (lsegmentosSeleccionados.Last().CiudadLlegada.IdCiudad.Equals(reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdCiudad, StringComparison.InvariantCultureIgnoreCase)
                ? EnumTipoViaje.OW
                : EnumTipoViaje.RT);

            /* // borrar luego
            reserva.Itinerario.CodeShare = lsegmentosSeleccionados
                .Where(s => (!string.IsNullOrWhiteSpace(s.OperadoPor)))
                    .Select(s => s.OperadoPor)
                        .Where(o => (!reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Equivalentes.Any(x => x.Equals(o, StringComparison.InvariantCultureIgnoreCase))))
                            .Select(o => o).Pipe(e => string.Join(",", e));
            */

            reserva.Itinerario.CodeShare = lsegmentosSeleccionados
                .Where(s => (!string.IsNullOrWhiteSpace(s.OperadoPor)))
                    .Select(s => s.OperadoPor)
                        .Where(o => (!reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Equivalentes.Any(x => x.Contains(o))))
                            .Select(o => o).Pipe(e => string.Join(",", e));

            /* // borrar luego
            reserva.Itinerario.AerolineasAuxiliares = lsegmentosSeleccionados
                .Select(s => s.Aerolinea.CodigoAerolinea)
                    .Where(o => (!reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Homologas.Any(x => x.Equals(o, StringComparison.InvariantCultureIgnoreCase))))
                        .Select(o => o)
                            .Distinct()
                                .Pipe(e => string.Join(",", e));             
            */

            reserva.Itinerario.AerolineasAuxiliares = lsegmentosSeleccionados
                .Select(s => s.Aerolinea.CodigoAerolinea)
                    .Where(o => (!reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Homologas.Any(x => x.Contains(o))))
                        .Select(o => o)
                            .Distinct()
                                .Pipe(e => string.Join(",", e));

            reserva.Itinerario.TipoVuelo = (string.IsNullOrWhiteSpace(reserva.Itinerario.AerolineasAuxiliares) ? EnumTipoVuelo.ON : EnumTipoVuelo.OFF);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="indiceCotizacion"></param>
        /// <param name="indiceLineaValidadora"></param>
        /// <returns></returns>
        private void PostCompletarReserva(CE_Reserva reserva,
                                          int indiceCotizacion,
                                          int indiceLineaValidadora)
        {
            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.PostCompletarCotizacion'", new { indiceCotizacion, indiceLineaValidadora }, CodigoSeguimiento);

            // postcompletando cotización
            PostCompletarCotizacion(reserva, indiceCotizacion, indiceLineaValidadora);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.PostCompletarCotizacion'", CodigoSeguimiento);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.PostCompletarSegmentos'", new { indiceCotizacion }, CodigoSeguimiento);

            // postcompletando segmentos
            PostCompletarSegmentos(reserva, indiceCotizacion);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.PostCompletarSegmentos'", CodigoSeguimiento);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.PostCompletarItinerario'", new { indiceCotizacion, indiceLineaValidadora }, CodigoSeguimiento);

            // postcompletando itinerario
            PostCompletarItinerario(reserva, indiceCotizacion, indiceLineaValidadora);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.PostCompletarItinerario'", CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<CE_Concepto> PreInicializandoConceptosEvaluar()
        {
            return new List<CE_Concepto>
            {
                new CE_Concepto { IdConcepto = "1", Concepto = "FAREBASIS", Valor = null },
                new CE_Concepto { IdConcepto = "2", Concepto = "CLASE DE RESERVACION", Valor = null },
                new CE_Concepto { IdConcepto = "3", Concepto = "SUCURSAL", Valor = null },
                new CE_Concepto { IdConcepto = "4", Concepto = "TIPO DE STOCK", Valor = null },
                new CE_Concepto { IdConcepto = "5", Concepto = "1a LET FAREBASIS SAL", Valor = null },
                new CE_Concepto { IdConcepto = "6", Concepto = "CIUDAD ORIGEN", Valor = null },
                new CE_Concepto { IdConcepto = "7", Concepto = "CIUDAD REGRESO", Valor = null },
                new CE_Concepto { IdConcepto = "8", Concepto = "CIUDAD DESTINO", Valor = null },
                new CE_Concepto { IdConcepto = "9", Concepto = "PAIS DESTINO", Valor = null },
                new CE_Concepto { IdConcepto = "10", Concepto = "FECHA RETORNO", Valor = null },
                new CE_Concepto { IdConcepto = "11", Concepto = "1a LET.FAREBASIS RET", Valor = null },
                new CE_Concepto { IdConcepto = "12", Concepto = "TIPO DE PAX", Valor = null },
                new CE_Concepto { IdConcepto = "13", Concepto = "PAIS RETORNO", Valor = null },
                new CE_Concepto { IdConcepto = "14", Concepto = null, Valor = null },
                new CE_Concepto { IdConcepto = "15", Concepto = null, Valor = null },
                new CE_Concepto { IdConcepto = "16", Concepto = "CODE SHARE", Valor = null },
                new CE_Concepto { IdConcepto = "17", Concepto = "TIPO DE RUTA (C / I)", Valor = null },
                new CE_Concepto { IdConcepto = "18", Concepto = "UNICA REGULACION", Valor = null },
                new CE_Concepto { IdConcepto = "19", Concepto = "TIPO VUELO (ON/OFF)", Valor = null },
                new CE_Concepto { IdConcepto = "20", Concepto = "FECHA SALIDA", Valor = null },
                new CE_Concepto { IdConcepto = "21", Concepto = "PAIS ORIGEN", Valor = null },
                new CE_Concepto { IdConcepto = "22", Concepto = "L. AEREA AUXILIAR", Valor = null },
                new CE_Concepto { IdConcepto = "23", Concepto = "CODE SHARE - L.AEREA", Valor = null },
                new CE_Concepto { IdConcepto = "24", Concepto = "CLASE DE CABINA", Valor = null },
                new CE_Concepto { IdConcepto = "25", Concepto = "CANTIDAD FARE BASIS", Valor = null },
                new CE_Concepto { IdConcepto = "26", Concepto = "CLASE CABINA SALIDA", Valor = null },
                new CE_Concepto { IdConcepto = "27", Concepto = "CLASE CABINA RETORNO", Valor = null },
                new CE_Concepto { IdConcepto = "28", Concepto = "1a LET F.BASIS ALL", Valor = null },
                new CE_Concepto { IdConcepto = "29", Concepto = "PAIS TERMINO VIAJE", Valor = null },
                new CE_Concepto { IdConcepto = "30", Concepto = "CIUDAD TERMINO VIAJE", Valor = null },
                new CE_Concepto { IdConcepto = "31", Concepto = "REGION DE DESTINO", Valor = null },
                new CE_Concepto { IdConcepto = "32", Concepto = "REGION DE RETORNO", Valor = null },
                new CE_Concepto { IdConcepto = "33", Concepto = "CIUDAD AUXILIAR SAL", Valor = null },
                new CE_Concepto { IdConcepto = "34", Concepto = "CIUDAD AUXILIAR RET", Valor = null },
                new CE_Concepto { IdConcepto = "35", Concepto = "TIPO VIAJE (OW/RT)", Valor = null },
                new CE_Concepto { IdConcepto = "36", Concepto = "FORMA PAGO", Valor = null },
                new CE_Concepto { IdConcepto = "37", Concepto = "PAX CLERO", Valor = null },
                new CE_Concepto { IdConcepto = "38", Concepto = "TIPO PAX ESPECIAL", Valor = null },
                new CE_Concepto { IdConcepto = "39", Concepto = "ES REEMISION", Valor = null },
                new CE_Concepto { IdConcepto = "40", Concepto = "No DE VUELO", Valor = null },
                new CE_Concepto { IdConcepto = "41", Concepto = "PSEUDO", Valor = null },
                new CE_Concepto { IdConcepto = "42", Concepto = "IATA", Valor = null },
                new CE_Concepto { IdConcepto = "43", Concepto = "CLIENTE", Valor = null },
                new CE_Concepto { IdConcepto = "44", Concepto = "INCLUIR YQ", Valor = null },
                new CE_Concepto { IdConcepto = "45", Concepto = "No de VUELO SALIDA", Valor = null },
                new CE_Concepto { IdConcepto = "46", Concepto = "No de VUELO RETORNO", Valor = null },
                new CE_Concepto { IdConcepto = "47", Concepto = "CON RUC", Valor = null },
                new CE_Concepto { IdConcepto = "48", Concepto = "SUBCODIGO", Valor = null },
                new CE_Concepto { IdConcepto = "49", Concepto = "ACCOUNT CODE", Valor = null },
                new CE_Concepto { IdConcepto = "50", Concepto = "FB SIN TKT DESIG", Valor = null },
                new CE_Concepto { IdConcepto = "51", Concepto = "TKT EN CONJUNCION", Valor = null },
                new CE_Concepto { IdConcepto = "52", Concepto = "Ciudad CONEX Salida", Valor = null },
                new CE_Concepto { IdConcepto = "53", Concepto = "Ciudad CONEX Retorno", Valor = null },
                new CE_Concepto { IdConcepto = "54", Concepto = "CIUDAD CONEX APLICA", Valor = null },
                new CE_Concepto { IdConcepto = "55", Concepto = "TARIFAS CORPORATIVAS", Valor = null },
                new CE_Concepto { IdConcepto = "56", Concepto = "FB CON TKT DESIG", Valor = null },
                new CE_Concepto { IdConcepto = "57", Concepto = "Clase de RSV SALIDA", Valor = null },
                new CE_Concepto { IdConcepto = "58", Concepto = "Clase de RSV RETORNO", Valor = null },
                new CE_Concepto { IdConcepto = "59", Concepto = "Tipo de Cliente", Valor = null },
                new CE_Concepto { IdConcepto = "60", Concepto = "Fecha EMISION VIGENC", Valor = null },
                new CE_Concepto { IdConcepto = "62", Concepto = "Hora EMISION VIGENCI", Valor = null },
                new CE_Concepto { IdConcepto = "63", Concepto = "REGION ORIGEN", Valor = null },
                new CE_Concepto { IdConcepto = "64", Concepto = "REGION TERMINO VIAJE", Valor = null }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="indiceCotizacion"></param>
        /// <param name="indiceLineaValidadora"></param>
        /// <param name="conceptosEvaluar"></param>
        /// <returns></returns>
        private void PostInicializandoConceptosEvaluar(CE_Reserva reserva,
                                                       int indiceCotizacion,
                                                       int indiceLineaValidadora, 
                                                       out List<CE_Concepto> conceptosEvaluar)
        {
            List<CE_Concepto> lconceptosEvaluar = null;

            // filtrando segmentos seleccionados
            var lsegmentosSeleccionados = reserva.Itinerario.Segmentos.Where(s => (s.Seleccionado ?? false)).ToList();

            // contruyendo lista de clases (todas) y salida
            var lclases = lsegmentosSeleccionados.Select(s => s.ClaseReserva).Distinct().Pipe(e => string.Join(",", e));
            var lclaseSalida = lsegmentosSeleccionados.Where(s => s.EsSalida).Select(s => s.ClaseReserva).Distinct().Pipe(e => string.Join(",", e));

            // extrayendo ciudad y fecha de salida
            var lciudadSalida = lsegmentosSeleccionados.Where(s => s.EsSalida).Select(s => s.CiudadSalida).First();
            var lfechaSalida = lsegmentosSeleccionados.Where(s => s.EsSalida).Select(s => s.FechaSalida).First();

            // extrayendo ciudad final, auxiliar de salida y retorno
            var lciudadFinal = lsegmentosSeleccionados.Select(s => s.CiudadLlegada).Last();

            // extrayendo codigo ciudad auxiliar de salida
            var lcodigoCiudadAuxiliarSalida = lsegmentosSeleccionados
                .First(s => (s.EsSalida && reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Homologas
                    .Any(e => e.Contains(s.Aerolinea.CodigoAerolinea))))
                        .CiudadSalida.CodigoCiudadSegmento;

            // contruyendo lista de vuelos (todos) y salida
            var lvuelos = lsegmentosSeleccionados.Select(s => s.NumeroVuelo).Distinct().Pipe(e => string.Join(",", e));
            var lvuelosSalida = lsegmentosSeleccionados.Where(s => s.EsSalida).Select(s => s.NumeroVuelo).Distinct().Pipe(e => string.Join(",", e));

            // contruyendo lista de ciudades de conexion salida
            var lciudadesConexionSalida = lsegmentosSeleccionados
                .Where(s => (s.EsSalida && (!s.CiudadLlegada.IdCiudad.Equals(reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdCiudad, StringComparison.InvariantCultureIgnoreCase))))
                    .Select(s => s.CiudadLlegada.IdCiudad)
                        .Pipe(e => string.Join(",", e));

            CE_Ciudad lciudadRetorno = null;
            string lclaseRetorno = null;
            string lfechaRetorno = null;
            string lcodigoCiudadAuxiliarRetorno = null;
            string lvuelosRetono = null;
            string lciudadesConexionRetorno = null;

            // evaluando si existe algún segmento que no sea de salida
            if (lsegmentosSeleccionados.Any(s => (!s.EsSalida)))
            {
                // contruyendo lista de clases de retorno
                lclaseRetorno = lsegmentosSeleccionados.Where(s => (!s.EsSalida)).Select(s => s.ClaseReserva).Distinct().Pipe(e => string.Join(",", e));

                // extrayendo ciudad y fecha de retorno
                lciudadRetorno = lsegmentosSeleccionados.Where(s => (!s.EsSalida)).Select(s => s.CiudadSalida).First();
                lfechaRetorno = lsegmentosSeleccionados.Where(s => (!s.EsSalida)).Select(s => s.FechaSalida).First();

                // extrayendo codigo ciudad auxiliar de retorno
                lcodigoCiudadAuxiliarRetorno = lsegmentosSeleccionados
                    .First(s => ((!s.EsSalida) && reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].Homologas
                        .Any(e => e.Contains(s.Aerolinea.CodigoAerolinea))))
                            .CiudadLlegada.CodigoCiudadSegmento;

                // contruyendo lista de vuelos de retono
                lvuelosRetono = lsegmentosSeleccionados.Where(s => (!s.EsSalida)).Select(s => s.NumeroVuelo).Distinct().Pipe(e => string.Join(",", e));

                // contruyendo lista de ciudades de conexion retorno
                lciudadesConexionRetorno = lsegmentosSeleccionados
                    .Take(lsegmentosSeleccionados.Count - 1)
                        .Where(s => (!s.EsSalida))
                            .Select(s => s.CiudadLlegada.IdCiudad)
                                .Pipe(l => string.Join(",", l));
            }

            // construyendo lista de aerolineas auxiliares y code share
            var laerolineasAuxiliares = (string.IsNullOrWhiteSpace(reserva.Itinerario.AerolineasAuxiliares)
                ? reserva.Cotizaciones[indiceCotizacion].LineasValidadoras[indiceLineaValidadora].CodigoAerolinea
                : reserva.Itinerario.AerolineasAuxiliares.Split(',').Pipe(e => string.Join(",", e)));

            // contruyendo codeshare
            var lcodesShare = (string.IsNullOrWhiteSpace(reserva.Itinerario.CodeShare) 
                ? null 
                : reserva.Itinerario.CodeShare.Split(',').Pipe(e => string.Join(",", e)));

            // recorriendo tarifas
            foreach (var ltarifa in reserva.Cotizaciones[indiceCotizacion].Tarifas)
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.PreInicializandoConceptosEvaluar'", new { indiceCotizacion, indiceLineaValidadora, ltarifa }, CodigoSeguimiento);

                // pre inicializando conceptos a evaluar
                lconceptosEvaluar = PreInicializandoConceptosEvaluar();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.PreInicializandoConceptosEvaluar'", new { lconceptosEvaluar }, CodigoSeguimiento);

                // construyendo lista de farebasis
                var lfareBasis = ltarifa.BaseTarifaria.Select(bt => bt.BaseTarifaria).Distinct().Pipe(e => string.Join(",", e));

                // construyendo lista de farebasis desig
                var lfareBasisDesig = ltarifa.BaseTarifaria.Select(b => b.BaseTarifaria.Split('/')[0]).Distinct().Pipe(e => string.Join(",", e));

                // completando conceptos
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 1)).Valor = lfareBasis;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 2)).Valor = lclases;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 3)).Valor = reserva.Facturacion.IdSucursal.ToString();
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 4)).Valor = reserva.Cotizaciones[indiceCotizacion].TipoStock;

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 5)).Valor = (
                        from b in ltarifa.BaseTarifaria
                        join s in lsegmentosSeleccionados
                            on b.NumeroSegmento equals s.NumeroSegmento
                        where s.EsSalida
                        select b.BaseTarifaria.Substring(0, 1)
                    ).Distinct().Pipe(e => string.Join(",", e));

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 6)).Valor = lsegmentosSeleccionados.First().CiudadSalida.IdCiudad;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 7)).Valor = ((lciudadRetorno == null) ? null : lciudadRetorno.IdCiudad);
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 8)).Valor = reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdCiudad;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 9)).Valor = reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdPais;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 10)).Valor = (string.IsNullOrWhiteSpace(lfechaRetorno) ? null : Utilerias.ToValidDate(lfechaRetorno).ToString("dd-MM-yyyy"));

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 11)).Valor = (
                        from b in ltarifa.BaseTarifaria
                        join s in lsegmentosSeleccionados
                            on b.NumeroSegmento equals s.NumeroSegmento
                        where (!s.EsSalida)
                        select b.BaseTarifaria.Substring(0, 1)
                    ).Distinct().Pipe(e => string.Join(",", e));

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 12)).Valor = ltarifa.TipoPasajero.Equivale.Substring(0, 1);
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 13)).Valor = ((lciudadRetorno == null) ? null : lciudadRetorno.IdPais);
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 16)).Valor = (string.IsNullOrWhiteSpace(reserva.Itinerario.CodeShare) ? "NO" : "SI");
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 17)).Valor = ((reserva.Itinerario.TipoRuta == EnumTipoRutaItinerario.Nacional) ? "C" : "I");
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 18)).Valor = "1";
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 19)).Valor = reserva.Itinerario.TipoVuelo.ToString();
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 20)).Valor = Utilerias.ToValidDate(lfechaSalida).ToString("dd-MM-yyyy");
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 21)).Valor = lciudadSalida.IdPais;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 22)).Valor = laerolineasAuxiliares;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 23)).Valor = lcodesShare;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 24)).Valor = lclases;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 25)).Valor = lfareBasis.Split(',').Count().ToString();
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 26)).Valor = lclaseSalida;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 27)).Valor = lclaseRetorno;

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 28)).Valor = (
                        from b in ltarifa.BaseTarifaria
                        join s in lsegmentosSeleccionados
                            on b.NumeroSegmento equals s.NumeroSegmento
                        select b.BaseTarifaria.Substring(0, 1)
                    ).Distinct().Pipe(e => string.Join(",", e));

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 29)).Valor = lciudadFinal.IdPais;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 30)).Valor = lciudadFinal.IdCiudad;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 31)).Valor = reserva.Cotizaciones[indiceCotizacion].CiudadDestino.IdRegion;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 32)).Valor = ((lciudadRetorno == null) ? null : lciudadRetorno.IdRegion);
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 33)).Valor = lcodigoCiudadAuxiliarSalida;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 34)).Valor = lcodigoCiudadAuxiliarRetorno;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 35)).Valor = reserva.Itinerario.TipoViaje.ToString();
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 36)).Valor = ((reserva.TipoFormaPagoComision == EnumTipoFormaPagoComision.CASH) ? "CON" : ((reserva.TipoFormaPagoComision == EnumTipoFormaPagoComision.CARDCASH) ? "UCA" : "UTP"));
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 38)).Valor = ltarifa.TipoPasajero.IdTipoPasajero;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 39)).Valor = ((reserva.EsReemision ?? false)  ? "SI" : "NO");
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 40)).Valor = lvuelos;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 41)).Valor = reserva.Cotizaciones[indiceCotizacion].Pseudo;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 42)).Valor = reserva.Cotizaciones[indiceCotizacion].Iata;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 43)).Valor = reserva.Cliente.IdCliente.ToString();
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 45)).Valor = lvuelosSalida;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 46)).Valor = lvuelosRetono;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 47)).Valor = ((reserva.EmiteConRUC ?? false)  ? "SI" : "NO");
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 48)).Valor = (reserva.Cliente.IdSubCodigo.HasValue ? reserva.Cliente.IdSubCodigo.ToString() : null);
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 49)).Valor = (string.IsNullOrWhiteSpace(reserva.Cotizaciones[indiceCotizacion].AccountCode) 
                    ? null 
                    : reserva.Cotizaciones[indiceCotizacion].AccountCode.Trim());
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 50)).Valor = lfareBasisDesig;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 52)).Valor = lciudadesConexionSalida;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 53)).Valor = lciudadesConexionRetorno;

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 54)).Valor = (
                    string.IsNullOrWhiteSpace(lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 53)).Valor)
                    ? lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 52)).Valor
                    : Strings.ToDelimiterString(true, ",", lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 52)).Valor, lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 53)).Valor));

                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 55)).Valor = (string.IsNullOrWhiteSpace(reserva.Cotizaciones[indiceCotizacion].AccountCode) ? "NO" : "SI");
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 56)).Valor = lfareBasis;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 57)).Valor = lclaseSalida;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 58)).Valor = lclaseRetorno;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 59)).Valor = reserva.Cliente.IdTipoCliente;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 63)).Valor = lciudadSalida.IdRegion;
                lconceptosEvaluar.Find(c => (int.Parse(c.IdConcepto) == 64)).Valor = lciudadFinal.IdRegion;
            }

            // actualizando parametro de salida
            conceptosEvaluar = lconceptosEvaluar;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="iata"></param>
        /// <param name="transportador"></param>
        /// <param name="idCliente"></param>
        /// <param name="conceptosRequeridos"></param>
        /// <returns></returns>
        private bool InsertarEvaluacionComision(string pnr,
                                                string iata,
                                                string transportador,
                                                int idCliente,
                                                IEnumerable<CE_Concepto> conceptosRequeridos)
        {
            int lregistrosAfectados;

            // contruyendo lista de evaluaciones
            var levaluaciones =
                conceptosRequeridos
                    .Select((c, i) => new DT_TOURCODES_EVALUACION
                    {
                        ID_IATA = iata,
                        ID_CLIENTE = idCliente,
                        ID_TRANSPORTADOR = transportador,
                        CODIGO_RESERVA = pnr,
                        CORRELATIVO_EVALUACION = (i + 1),
                        CODIGO_CONCEPTO = int.Parse(c.IdConcepto),
                        VALOR = c.Valor,
                        FECHA_ALTA = DateTime.Now
                    }).ToArray();

            // serializando datos
            var levaluacionesXml = XmlHelper.XmlSerializerforOracle(levaluaciones, false, false);

            using (var lpkgGdsGeneric = new PkgGdsGeneric(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarConceptosComision'", new { levaluacionesXml }, CodigoSeguimiento);

                // insertando evaluaciones
                lpkgGdsGeneric.GdsInsertarConceptosComision(Conexion, Esquema, levaluacionesXml, out lregistrosAfectados);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarConceptosComision'", new { lregistrosAfectados }, CodigoSeguimiento);
            }

            return (lregistrosAfectados != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="conceptosRequeridos"></param>
        /// <returns></returns>
        private bool InsertarEvaluacionFee(string pnr,
                                           IEnumerable<CE_Concepto> conceptosRequeridos)
        {
            int lregistrosAfectados;

            // contruyendo lista de evaluaciones
            var levaluaciones =
                conceptosRequeridos
                    .Select((c, i) => new DT_TARIFABULK_EVALUACION
                    {
                        CODIGO_RESERVA = pnr,
                        CORRELATIVO_EVALUACION = (i + 1),
                        CODIGO_CONCEPTO = int.Parse(c.IdConcepto),
                        VALOR = c.Valor,
                        FECHA_ALTA = DateTime.Now
                    }).ToArray();

            // serializando datos
            var levaluacionesXml = XmlHelper.XmlSerializerforOracle(levaluaciones, false, false);

            using (var lpkgGdsGeneric = new PkgGdsGeneric(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarConceptosFee'", new { levaluacionesXml }, CodigoSeguimiento);

                // insertando evaluaciones
                lpkgGdsGeneric.GdsInsertarConceptosFee(Conexion, Esquema, levaluacionesXml, out lregistrosAfectados);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarConceptosFee'", new { lregistrosAfectados }, CodigoSeguimiento);
            }

            return (lregistrosAfectados != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="iata"></param>
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="idCliente"></param>
        /// <param name="idGrupo"></param>
        /// <param name="conceptosEvaluar"></param>
        /// <param name="tarifa"></param>
        /// <returns></returns>
        private void ProcesandoComision(string pnr,
                                        string iata,
                                        string transportador,
                                        string ciudadDestino,
                                        int idEmpresa,
                                        int idCliente,
                                        int idGrupo,
                                        IEnumerable<CE_Concepto> conceptosEvaluar,
                                        CE_Tarifa tarifa)
        {
            using (var lpkgGdsModuloComisionPta = new PkgGdsModuloComisionPta(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloComisionPta.GdsLimpiar'", new { pnr, transportador }, CodigoSeguimiento);

                // limpiando conceptos a evluar
                lpkgGdsModuloComisionPta.GdsLimpiarConceptos(Conexion, Esquema, pnr, transportador);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloComisionPta.GdsLimpiarConceptos'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloComisionPta.GdsLimpiarEvaluaciones'", new { pnr, transportador }, CodigoSeguimiento);

                // limpiando evaluaciones realizadas
                lpkgGdsModuloComisionPta.GdsLimpiarEvaluaciones(Conexion, Esquema, pnr, transportador);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloComisionPta.GdsLimpiarEvaluaciones'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'UpConceptosTourcodes.Ejecutar'", new { idEmpresa, transportador, iata, ciudadDestino, pnr, idGrupo }, CodigoSeguimiento);

                // preparando conceptos requeridos
                (new UpConceptosTourcodes(CodigoSeguimiento)).Ejecutar(Conexion, Esquema, idEmpresa, transportador, iata, ciudadDestino, pnr, idGrupo);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'UpConceptosTourcodes.Ejecutar'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloComisionPta.GdsObtenerConceptos'", new { pnr, transportador }, CodigoSeguimiento);

                // obteniendo conceptos requeridos
                var lconceptosRequeridos = lpkgGdsModuloComisionPta.GdsObtenerConceptos(Conexion, Esquema, pnr, transportador);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloComisionPta.GdsObtenerConceptos'", new { lconceptosRequeridos }, CodigoSeguimiento);

                // evaluando si se obtuvierón conceptos requeridos
                if ((lconceptosRequeridos != null) && lconceptosRequeridos.Any())
                {
                    // actualizando conceptos
                    lconceptosRequeridos.ForEach(c1 =>
                    {
                        var lconcepto = conceptosEvaluar.FirstOrDefault(c2 => (int.Parse(c2.IdConcepto) == int.Parse(c1.IdConcepto)));

                        if (lconcepto != null)
                        {
                            // actualizando valor del concepto
                            c1.Valor = (c1.EntreComillas.HasValue ? lconcepto.Valor.Quotes(false, ',') : lconcepto.Valor);
                        }
                    });

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.InsertarEvaluacionComision'", new { pnr, iata, transportador, idCliente, lconceptosRequeridos }, CodigoSeguimiento);

                    // evaluando si se pudo insertar los conceptos a evaluar
                    var lok = InsertarEvaluacionComision(pnr, iata, transportador, idCliente, lconceptosRequeridos);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.InsertarEvaluacionComision'", new { lok }, CodigoSeguimiento);

                    // evaluando si continuar
                    if (lok)
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'UpTourcodeEvaluacionV2.Ejecutar'", new { idEmpresa, pnr, idGrupo }, CodigoSeguimiento);

                        // evaluando las reglas
                        tarifa.ComisionPta = (new UpTourcodeEvaluacionV2(CodigoSeguimiento)).Ejecutar(Conexion, Esquema, idEmpresa, pnr, idGrupo);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'UpTourcodeEvaluacionV2.Ejecutar'", new { tarifa.ComisionPta }, CodigoSeguimiento);

                        // verificando si la evaluación de las reglas NO retorno un resultado
                        if (tarifa.ComisionPta != null)
                        {
                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloComisionPta.GdsObtenerAdicional'", new { pnr, idCliente, transportador }, CodigoSeguimiento);

                            // buscando si existe una comisión adicional
                            tarifa.ComisionPta.ComisionPtaAdicional = lpkgGdsModuloComisionPta.GdsObtenerAdicional(Conexion, Esquema, pnr, idCliente, transportador);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloComisionPta.GdsObtenerAdicional'", new { tarifa.ComisionPta.ComisionPtaAdicional }, CodigoSeguimiento);

                            // actualizando conceptos evaluados
                            tarifa.ComisionPta.ConceptosEvaluados = lconceptosRequeridos.ToArray();
                        }

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloComisionPta.GdsLimpiarConceptos'", new { pnr, transportador }, CodigoSeguimiento);

                        // limpiando conceptos evaluados
                        lpkgGdsModuloComisionPta.GdsLimpiarConceptos(Conexion, Esquema, pnr, transportador);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloComisionPta.GdsLimpiarConceptos'", CodigoSeguimiento);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloComisionPta.GdsLimpiarEvaluaciones'", new { pnr, transportador }, CodigoSeguimiento);

                        // limpiando evaluaciones realizadas
                        lpkgGdsModuloComisionPta.GdsLimpiarEvaluaciones(Conexion, Esquema, pnr, transportador);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloComisionPta.GdsLimpiarEvaluaciones'", CodigoSeguimiento);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="transportador"></param>
        /// <param name="ciudadDestino"></param>
        /// <param name="pseudoConsulta"></param>
        /// <param name="conceptosEvaluar"></param>
        /// <param name="tarifa"></param>
        /// <returns></returns>
        private void ProcesandoFee(string pnr,
                                   string transportador,
                                   string ciudadDestino,
                                   string pseudoConsulta,
                                   IEnumerable<CE_Concepto> conceptosEvaluar,
                                   CE_Tarifa tarifa)
        {
            using (var lpkgGdsModuloNoPublikdasPta = new PkgGdsModuloNoPublikdasPta(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarConceptos'", new { pnr, transportador }, CodigoSeguimiento);

                // limpiando conceptos a evluar
                lpkgGdsModuloNoPublikdasPta.GdsLimpiarConceptos(Conexion, Esquema, pnr, transportador);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarConceptos'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarEvaluaciones'", new { pnr }, CodigoSeguimiento);

                // limpiando evaluaciones realizadas
                lpkgGdsModuloNoPublikdasPta.GdsLimpiarEvaluaciones(Conexion, Esquema, pnr);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarEvaluaciones'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'UpConceptosTarifaBulk.Ejecutar'", new { transportador, ciudadDestino, pnr }, CodigoSeguimiento);

                // preparando conceptos requeridos
                (new UpConceptosTarifaBulk(CodigoSeguimiento)).Ejecutar(Conexion, Esquema, transportador, ciudadDestino, pnr);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'UpConceptosTarifaBulk.Ejecutar'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloNoPublikdasPta.GdsObtenerConceptos'", new { transportador }, CodigoSeguimiento);

                // obteniendo conceptos requeridos
                var lconceptosRequeridos = lpkgGdsModuloNoPublikdasPta.GdsObtenerConceptos(Conexion, Esquema, pnr, transportador);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloNoPublikdasPta.GdsObtenerConceptos'", new { lconceptosRequeridos },  CodigoSeguimiento);

                // evaluando si se obtuvierón conceptos requeridos
                if ((lconceptosRequeridos != null) && lconceptosRequeridos.Any())
                {
                    // actualizando conceptos
                    lconceptosRequeridos.ForEach(c1 =>
                    {
                        var lconcepto = conceptosEvaluar.FirstOrDefault(c2 => (int.Parse(c2.IdConcepto) == int.Parse(c1.IdConcepto)));

                        if (lconcepto != null)
                        {
                            // actualizando valor del concepto
                            c1.Valor = (c1.EntreComillas.Value ? lconcepto.Valor.Quotes(false, ',') : lconcepto.Valor);
                        }
                    });

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.InsertarEvaluacionFee'", new { pnr, lconceptosRequeridos }, CodigoSeguimiento);

                    // evaluando si se pudo insertar los conceptos a evaluar
                    var lok = InsertarEvaluacionFee(pnr, lconceptosRequeridos);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.InsertarEvaluacionFee'", new { lok }, CodigoSeguimiento);

                    // evaluando si continuar
                    if (lok)
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'UpTarifaBulkEvaluacion.Ejecutar'", new { transportador, ciudadDestino, pnr }, CodigoSeguimiento);

                        // evaluando las reglas
                        var lfees = (new UpTarifaBulkEvaluacion(CodigoSeguimiento)).Ejecutar(Conexion, Esquema, transportador, ciudadDestino, pnr);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'UpTarifaBulkEvaluacion.Ejecutar'", new { lfees }, CodigoSeguimiento);

                        // verificando si la evaluación de las retorno resultados
                        if ((lfees != null) && lfees.Any())
                        {
                            // filtrando el fee para el pseudo que consulta
                            tarifa.FeePta = lfees.Find(f => f.PseudoOficina.Equals(pseudoConsulta, StringComparison.InvariantCultureIgnoreCase));

                            if (tarifa.FeePta != null)
                            {
                                // actualizando conceptos evaluados
                                tarifa.FeePta.ConceptosEvaluados = lconceptosRequeridos.ToArray();
                            }
                        }

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarConceptos'", new { transportador, ciudadDestino, pnr }, CodigoSeguimiento);

                        // limpiando conceptos evaluados
                        lpkgGdsModuloNoPublikdasPta.GdsLimpiarConceptos(Conexion, Esquema, pnr, transportador);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarConceptos'", CodigoSeguimiento);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarEvaluaciones'", new { pnr }, CodigoSeguimiento);

                        // limpiando evaluaciones realizadas
                        lpkgGdsModuloNoPublikdasPta.GdsLimpiarEvaluaciones(Conexion, Esquema, pnr);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloNoPublikdasPta.GdsLimpiarEvaluaciones'", CodigoSeguimiento);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private void ProcesandoComisionesFees(CE_Reserva reserva)
        {
            List<CE_Concepto> lconceptosEvaluar;

            // obteniendo el indice de la cotizacion seleccionada
            var lindiceCotizacion = Array.FindIndex(reserva.Cotizaciones, l => (l.Seleccionada ?? false));

            // obteniendo el indice de la linea validadora seleccionada
            var lindiceLineaValidadora = Array.FindIndex(reserva.Cotizaciones[lindiceCotizacion].LineasValidadoras, l => (l.Seleccionada ?? false));

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.PostCompletarReserva'", new { lindiceCotizacion, lindiceLineaValidadora }, CodigoSeguimiento);

            // post completando reserva
            PostCompletarReserva(reserva, lindiceCotizacion, lindiceLineaValidadora);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.PostCompletarReserva'", CodigoSeguimiento);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.PostInicializandoConceptosEvaluar'", new { lindiceCotizacion, lindiceLineaValidadora }, CodigoSeguimiento);

            // post inicializando conceptos a evaluar
            PostInicializandoConceptosEvaluar(reserva, lindiceCotizacion, lindiceLineaValidadora, out lconceptosEvaluar);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.PostInicializandoConceptosEvaluar'", new { lconceptosEvaluar }, CodigoSeguimiento);

            // --

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

            // iniciando transacción
            Conexion.IniciarTransaccion();

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

            // inicializando propiedades
            reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].FeePta = null;
            reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].ComisionPta = null;

            // evaluando si es una tarifa privada
            if (reserva.Cotizaciones[lindiceCotizacion].TipoTarifa.Codigo == EnumCodigoTarifa.PV)
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ProcesandoFee'", CodigoSeguimiento);

                // procesando conceptos a evaluar para tarifa privada
                ProcesandoFee(
                    reserva.PNR,
                    reserva.Cotizaciones[lindiceCotizacion].LineasValidadoras[lindiceLineaValidadora].CodigoAerolinea,
                    reserva.Cotizaciones[lindiceCotizacion].CiudadDestino.IdCiudad,
                    reserva.Aplicacion.PseudoConsulta,
                    lconceptosEvaluar,
                    reserva.Cotizaciones[lindiceCotizacion].Tarifas[0]);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ProcesandoFee'", new { reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].FeePta }, CodigoSeguimiento);

                // evaluando si NO se obtuvo fee
                if (reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].FeePta == null)
                {
                    // forzando excepción
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER EL FEE.", reserva.PNR));
                }
            }

            // creando array de grupos
            var lgrupos = ((reserva.Cotizaciones[lindiceCotizacion].TipoTarifa.Codigo == EnumCodigoTarifa.PL)
                ? Strings.ToArray(true, reserva.Aplicacion.IdGrupo)
                : Strings.ToArray(true, reserva.Aplicacion.IdGrupo, reserva.Aplicacion.IdGrupoAuxiliar));

            // recorriendo grupos
            foreach (var lgrupo in lgrupos)
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ProcesandoComision'", new { lgrupo }, CodigoSeguimiento);

                // procesando conceptos a evaluar
                ProcesandoComision(
                    reserva.PNR,
                    reserva.Cotizaciones[lindiceCotizacion].Iata,
                    reserva.Cotizaciones[lindiceCotizacion].LineasValidadoras[lindiceLineaValidadora].CodigoAerolinea,
                    reserva.Cotizaciones[lindiceCotizacion].CiudadDestino.IdCiudad,
                    int.Parse(reserva.Cotizaciones[lindiceCotizacion].IdEmpresa),
                    reserva.Cliente.IdCliente.Value,
                    int.Parse(lgrupo),
                    lconceptosEvaluar,
                    reserva.Cotizaciones[lindiceCotizacion].Tarifas[0]);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ProcesandoComision'", new { reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].ComisionPta }, CodigoSeguimiento);

                // evaluando SI se obtuvo la comisión
                if (reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].ComisionPta != null)
                {
                    break;
                }
            }

            // para las tarifas publicadas evaluar si NO se obtuvo la comisión
            if (reserva.Cotizaciones[lindiceCotizacion].Tarifas[0].ComisionPta == null)
            {
                // forzando excepción
                throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE PUDO OBTENER LAS COMISIONES.", reserva.PNR));
            }

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.FinalizarTransaccion'", CodigoSeguimiento);

            // finalizando transacción
            Conexion.FinalizarTransaccion(false);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.FinalizarTransaccion'", CodigoSeguimiento);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ProcesandoPreVenta(CE_Reserva reserva,
                                             out CE_Reserva resultado,
                                             bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = null;

            try
            {
                if ((reserva.Cliente == null) || (!reserva.Cliente.IdCliente.HasValue))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO SE HA PROPORCIONADO EL DK DEL CLIENTE.", reserva.PNR));
                }

                // clonando reserva
                resultado = Advanced.ToCopy<CE_Reserva, CE_Reserva>(reserva);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ProcesandoComisionesFees'", new { resultado }, CodigoSeguimiento);

                // procesando comision fee
                ProcesandoComisionesFees(resultado);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ProcesandoComisionesFees'", new { resultado }, CodigoSeguimiento);

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { reserva, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { reserva, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="resultados"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ProcesandoPostVenta(CE_Reserva reserva,
                                              out CE_Reserva[] resultados,
                                              bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            try
            {
                resultados = null;

                if ((reserva.Cliente == null) || (!reserva.Cliente.IdCliente.HasValue))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - NO HA PROPORCIONADO EL DK DEL CLIENTE.", reserva.PNR));
                }

                // leyendo la cantidad de boletos seleccionados
                var lboletosSeleccionados = reserva.Boletos.Where(b => (b.Seleccionado ?? false)).ToList();

                // evaluando que existan boletos seleccionados
                if (lboletosSeleccionados.Any())
                {
                    // seleccionando la cotización y linea validadora de los boletos seleccionados
                    lboletosSeleccionados.ForEach(b =>
                    {
                        b.Cotizacion.Seleccionada = true;
                        b.Cotizacion.LineasValidadoras[0].Seleccionada = true;
                    });

                    // creando instancia para los resultados
                    resultados = new CE_Reserva[lboletosSeleccionados.Count];

                    // recorriendo boletos seleccionados
                    for (var li = 0; li < lboletosSeleccionados.Count; li++)
                    {
                        // clonando reserva
                        resultados[li] = Advanced.ToCopy<CE_Reserva, CE_Reserva>(reserva);

                        // actualizando cotizaciones en la copia
                        resultados[li].Cotizaciones = new CE_Cotizacion[1];
                        resultados[li].Cotizaciones[0] = Advanced.ToCopy<CE_Cotizacion, CE_Cotizacion>(lboletosSeleccionados[li].Cotizacion);

                        // limpiando cotización en el boelto original para que no sea clonado cuando se cree la copia
                        lboletosSeleccionados[li].Cotizacion = null;

                        // actualizando boletos en la copia
                        resultados[li].Boletos = new CE_Boleto[1];
                        resultados[li].Boletos[0] = Advanced.ToCopy<CE_Boleto, CE_Boleto>(lboletosSeleccionados[li]);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar '.ProcesandoComisionesFees'", new { li }, CodigoSeguimiento);

                        // procesando comision fee
                        ProcesandoComisionesFees(resultados[li]);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado '.ProcesandoComisionesFees'", new { li }, CodigoSeguimiento);
                    }

                    lboletosSeleccionados.Clear();
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { reserva, muteErrors }, CodigoSeguimiento);

                resultados = null;

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { reserva, muteErrors }, CodigoSeguimiento);

                resultados = null;

                // no silenciar errores
                if (!muteErrors)
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
