using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using CoreLib.Generics;
using CoreWebLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Boleto;
using EntidadesGDS.General;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Clientes.eDestinos;
using GDSLib.PTA;

// alias
using ItinerarioSabre = GDSLib.Sabre.Itinerario;
using HerramientaSabre = GDSLib.Sabre.Herramienta;
using ItinerarioAmadeus = GDSLib.Amadeus.Itinerario;
using HerramientaAmadeus = GDSLib.Amadeus.Herramienta;

namespace ServiciosGDS.Controllers.PTA
{
    public class ServicioClienteExternoController : BaseController
    {
        // =============================
        // metodos

        #region "metodos"

        private void CrearSesionSabre(EnumAplicaciones aplicacion,
                                      string codigoSeguimiento,
                                      string pnr,
                                      string pseudo,
                                      ref CE_Session sesion,
                                      ref CE_Estatus estatus)
        {
            // sessión de sabre
            sesion = new CE_Session
            {
                Pseudo = pseudo,
                ConversationId = codigoSeguimiento,
                SignatureUser = codigoSeguimiento
            };

            using (var lherramientaSabre = new HerramientaSabre(aplicacion, codigoSeguimiento, null, sesion))
            {
                // creando sesión
                estatus = lherramientaSabre.CrearSesion(ref sesion);

                // ¿continuar?
                if (estatus.Ok)
                {
                    bool lenCotextoCorrecto;

                    // actualizando sesion
                    lherramientaSabre.Sesion = sesion;

                    // comprobando contexto
                    estatus = lherramientaSabre.TripleadoEn(pseudo, out lenCotextoCorrecto);

                    // ¿continuar?
                    if (estatus.Ok && (!lenCotextoCorrecto))
                    {
                        CE_Session lsesion;

                        // cambiando de pseudo
                        estatus = lherramientaSabre.CambiarContexto(pseudo, out lsesion);

                        // ¿no continuar?
                        if (!estatus.Ok)
                        {
                            throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - CONTEXTO INÁLIDO.", pnr));
                        }

                        // actualizando sesion
                        sesion = lsesion;
                    }
                }
            }
        }

        private void ObtenerCotizacionesAmadeus(EnumAplicaciones aplicacion,
                                                string codigoSeguimiento,
                                                ref CE_Session sesion,
                                                out CE_Estatus estatus,
                                                ref CE_Reserva reservaRecuperada)
        {
            using (var litinerarioAmadeus = new ItinerarioAmadeus(aplicacion, codigoSeguimiento, null))
            {
                CE_Cotizacion[] lcotizacionesRecuperadas;

                // ejecutando recuperar cotizaciones
                estatus = litinerarioAmadeus.ObtenerCotizaciones(ref sesion, out lcotizacionesRecuperadas);

                // ¿continuar?
                if (estatus.Ok)
                {
                    // actualizando boletos (solo tickets electronicos)
                    reservaRecuperada.Boletos
                        .Where(b => ((!string.IsNullOrWhiteSpace(b.Tipo)) && b.Tipo.Equals("TE", StringComparison.InvariantCultureIgnoreCase)))
                        .ToList()
                        .ForEach(b =>
                        {
                            b.Cotizacion = lcotizacionesRecuperadas
                                .FirstOrDefault(c =>
                                    c.Tarifas[0].Pasajeros.Any(p => p.NumeroPasajero.Equals(b.Pasajero.NumeroPasajero)) &&
                                    c.Tarifas[0].BaseTarifaria.ToList().TrueForAll(b1 => b.Segmentos.Any(b2 => b2.NumeroSegmento.Equals(b1.NumeroSegmento)))
                                );
                        });
                }
            }
        }

        private void LeyendoDespliegueBoletoSabre(int indiceBoleto, 
                                                  CE_Boleto boletoDesplegado,
                                                  ref CE_Reserva reservaRecuperada)
        {
            reservaRecuperada.Boletos[indiceBoleto].Pseudo = boletoDesplegado.Pseudo;
            reservaRecuperada.Boletos[indiceBoleto].Iata = boletoDesplegado.Iata;

            // actualizando los numero de segmento usando el historico donde se encuentran 
            // los numeros de linea de los segmentos asociados al boleto
            reservaRecuperada.Boletos[indiceBoleto].Segmentos =
                reservaRecuperada.Boletos[indiceBoleto].Segmentos
                    .Join(
                        reservaRecuperada.Itinerario.Segmentos,
                        left => left.NumeroLinea,
                        right => right.NumeroLinea,
                        (left, right) => right)
                    .Select(s => new CE_Segmento
                    {
                        NumeroSegmento = s.NumeroSegmento,
                        NumeroLinea = s.NumeroLinea
                    }).ToArray();

            if ((reservaRecuperada.Boletos[indiceBoleto].Pasajero == null) || 
                string.IsNullOrWhiteSpace(reservaRecuperada.Boletos[indiceBoleto].Pasajero.NumeroPasajero))
            {
                CE_Pasajero lpasajero = null;

                switch (reservaRecuperada.Pasajeros.Length)
                {
                    case 1:
                        lpasajero = reservaRecuperada.Pasajeros.First();
                        break;

                    default:
                        // evaluando como realizar la busqueda del pasajero
                        if (boletoDesplegado.Pasajero.TipoDocumento.HasValue && (!string.IsNullOrWhiteSpace(boletoDesplegado.Pasajero.NumeroDocumento)))
                        {
                            // buscando pasajero por tipo y número de documento
                            lpasajero = reservaRecuperada
                                .Pasajeros
                                .FirstOrDefault(p =>
                                    (p.TipoDocumento == boletoDesplegado.Pasajero.TipoDocumento) && 
                                    p.NumeroDocumento.Equals(boletoDesplegado.Pasajero.NumeroDocumento, StringComparison.InvariantCultureIgnoreCase));

                        }
                        else
                        {
                            // buscando pasajero por apellidos, nombres y tipo de pasajero
                            lpasajero = reservaRecuperada
                                .Pasajeros
                                .FirstOrDefault(p =>
                                    p.Apellido.Equals(boletoDesplegado.Pasajero.Apellido, StringComparison.InvariantCultureIgnoreCase) &&
                                    p.Nombre.Equals(boletoDesplegado.Pasajero.Nombre, StringComparison.InvariantCultureIgnoreCase) &&
                                    p.TipoPasajero.IdTipoPasajero.Equals(boletoDesplegado.Pasajero.TipoPasajero.IdTipoPasajero, StringComparison.InvariantCultureIgnoreCase));

                        }

                        break;
                }

                // ¿se pudo encontrar pasajero?
                if (lpasajero == null)
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - IMPOSIBLE IDENTIFICAR CORRECTAMENTE EL PASAJERO DEL BOLETO.", reservaRecuperada.PNR));
                }

                reservaRecuperada.Boletos[indiceBoleto].Pasajero = lpasajero;
            }

            reservaRecuperada.Boletos[indiceBoleto].CuponesUsados = boletoDesplegado.CuponesUsados;
            reservaRecuperada.Boletos[indiceBoleto].Reemision = boletoDesplegado.Reemision;
            reservaRecuperada.Boletos[indiceBoleto].Cotizacion = boletoDesplegado.Cotizacion;
            reservaRecuperada.Boletos[indiceBoleto].Pagos = boletoDesplegado.Pagos;
        }

        private void DesplegarBoleto(EnumAplicaciones aplicacion,
                                     EnumTipoGds tipoGds,
                                     string codigoSeguimiento,
                                     ref CE_Session sesion,
                                     ref CE_Estatus estatus,
                                     ref CE_Reserva reservaRecuperada)
        {
            if ((tipoGds == EnumTipoGds.Sabre) || (tipoGds == EnumTipoGds.Amadeus))
            {
                // creando lista de números de boletos a desplegar
                var lboletos = reservaRecuperada.Boletos
                    .Where(b => ((!string.IsNullOrWhiteSpace(b.Tipo)) && b.Tipo.Equals("TE", StringComparison.InvariantCultureIgnoreCase)))
                    .Select((b, i) => new { Index = i, b.NumeroBoleto })
                    .ToList();

                CE_Boleto lboletoDesplegado;

                switch (tipoGds)
                {
                    // sabre
                    case EnumTipoGds.Sabre:
                        using (var litinerarioSabre = new ItinerarioSabre(aplicacion, codigoSeguimiento, null, sesion))
                        {
                            // actualizando boletos (solo tickets)
                            foreach (var lboleto in lboletos)
                            {
                                // ejecutando desplegar boleto
                                estatus = litinerarioSabre.DesplegarBoleto(lboleto.NumeroBoleto, out lboletoDesplegado);

                                // ¿continuar?
                                if (estatus.Ok)
                                {
                                    // leyendo despliegue del boleto
                                    LeyendoDespliegueBoletoSabre(lboleto.Index, lboletoDesplegado, ref reservaRecuperada);
                                }
                            }
                        }
                        break;

                    // amadeus
                    case EnumTipoGds.Amadeus:
                        using (var litinerarioAmadeus = new ItinerarioAmadeus(aplicacion, codigoSeguimiento, null))
                        {
                            // actualizando boletos (solo tickets)
                            foreach (var lboleto in lboletos)
                            {
                                // ejecutando desplegar boleto
                                estatus = litinerarioAmadeus.DesplegarBoleto(lboleto.NumeroBoleto, ref sesion, out lboletoDesplegado);

                                // ¿continuar?
                                if (estatus.Ok)
                                {
                                    reservaRecuperada.Boletos[lboleto.Index].Pagos = lboletoDesplegado.Pagos;
                                }
                            }
                        }
                        break;
                }

            }
            else
            {
                throw new InternalException(string.Format("TIPO DE GDS '{0}' NO SOPORTADO.", tipoGds));
            }
        }

        private void RecuperarReserva(EnumAplicaciones aplicacion,
                                      EnumTipoGds tipoGds, 
                                      string codigoSeguimiento,
                                      CE_Reserva parametros,
                                      ref CE_Session sesion,
                                      ref CE_Estatus estatus,
                                      out CE_Reserva reservaRecuperada)
        {
            reservaRecuperada = null;

            switch (tipoGds)
            {
                // sabre
                case EnumTipoGds.Sabre:
                    // creando sesión y validando contexto
                    CrearSesionSabre(aplicacion, codigoSeguimiento, parametros.PNR, parametros.Aplicacion.PseudoEmision, ref sesion, ref estatus);

                    // ¿continuar?
                    if (estatus.Ok)
                    {
                        using (var litinerarioSabre = new ItinerarioSabre(aplicacion, codigoSeguimiento, null, sesion))
                        {
                            // ejecutando recuperar reserva
                            estatus = litinerarioSabre.Obtener(parametros.PNR, out reservaRecuperada);
                        }
                    }
                    break;

                // amadeus
                case EnumTipoGds.Amadeus:
                    using (var litinerarioAmadeus = new ItinerarioAmadeus(aplicacion, codigoSeguimiento, null))
                    {
                        // sessión de amadeus
                        sesion = new CE_Session
                        {
                            AmadeusTransactionType = EnumTransactionType.Start,    // ¿EnumTransactionType.Stateless?
                            Pseudo = parametros.Aplicacion.PseudoEmision,
                            Environment = EnumEnvironment.Prod
                        };

                        // ejecutando recuperar reserva
                        estatus = litinerarioAmadeus.Obtener(
                            new RQ_ObtenerReserva
                            {
                                PNR = parametros.PNR,
                                LeerPasajeros = true,
                                LeerItinerario = true,
                                BuscarOperadoPor = true,
                                LeerLineasContables = true,
                                LeerCotizaciones = true,
                                LeerBoletos = true
                            },
                            out reservaRecuperada,
                            ref sesion);
                    }
                    break;

                // otros
                default:
                    throw new InternalException(string.Format("TIPO DE GDS '{0}' NO SOPORTADO.", tipoGds));
            }

            // ¿continuar?
            if (estatus.Ok)
            {
                // evaluando reserva recuperada
                if (reservaRecuperada == null)
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO SE RECUPERO CORRECTAMENTE.", parametros.PNR));
                }

                // PARA SABRE ESTOS DATOS SON NECESARIOS PARA CUANDO SE COMPARE LOS PASAJEROS CON EL DESPLIEGUE DE LOS BOLETOS
                // evaluando pasajeros recuperados
                if ((reservaRecuperada.Pasajeros == null) ||
                    (reservaRecuperada.Pasajeros.Any(p => ((!p.TipoDocumento.HasValue) || string.IsNullOrWhiteSpace(p.NumeroDocumento)))))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - PASAJEROS SIN DOCUMENTOS DE IDENTIDAD.", parametros.PNR));
                }

                // evaluando segmentos recuperados
                if ((reservaRecuperada.Itinerario == null) ||
                    (reservaRecuperada.Itinerario.Segmentos == null) ||
                        (!reservaRecuperada.Itinerario.Segmentos.Any()) ||
                            reservaRecuperada.Itinerario.Segmentos.Any(s => string.Format("{0}", s.Status).Equals("HX", StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - SEGMENTOS INVÁLIDOS.", parametros.PNR));
                }

                // evaluando boletos recuperados
                if ((reservaRecuperada.Boletos == null) ||
                    (!reservaRecuperada.Boletos.Any(b => string.Format("{0}", b.Tipo).Equals("TE", StringComparison.InvariantCultureIgnoreCase))) ||
                        (!reservaRecuperada.Boletos.Any(b => string.Format("{0}", b.Estatus).Equals("ACTIVO", StringComparison.InvariantCultureIgnoreCase))))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - BOLETOS INVÁLIDOS.", parametros.PNR));
                }

                switch (tipoGds)
                {
                    // sabre
                    case EnumTipoGds.Sabre:
                        // desplegando boletos
                        DesplegarBoleto(aplicacion, tipoGds, codigoSeguimiento, ref sesion, ref estatus, ref reservaRecuperada);
                        break;

                    // amadeus
                    case EnumTipoGds.Amadeus:
                        // desplegando boletos
                        DesplegarBoleto(aplicacion, tipoGds, codigoSeguimiento, ref sesion, ref estatus, ref reservaRecuperada);

                        // ¿continuar?
                        if (estatus.Ok)
                        {
                            // evaluando cotizaciones de boletos recuperados
                            if (reservaRecuperada.Boletos.All(b => (b.Cotizacion == null)))
                            {
                                // obteniendo cotizaciones de los boletos
                                ObtenerCotizacionesAmadeus(aplicacion, codigoSeguimiento, ref sesion, out estatus, ref reservaRecuperada);
                            }
                        }
                        break;

                    // otros
                    default:
                        throw new InternalException(string.Format("TIPO DE GDS '{0}' NO SOPORTADO.", tipoGds));
                }

                // evaluando boletos recuperados
                if (reservaRecuperada.Boletos.Any(b => (b.Reemision ?? false)))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - POSEE AL MENOS UNA REEMISIÓN.", parametros.PNR));
                }
            }
        }

        private void CerrarSesion(EnumAplicaciones aplicacion,
                                  EnumTipoGds tipoGds, 
                                  string codigoSeguimiento,
                                  ref CE_Session sesionActual,
                                  ref CE_Estatus estatus)
        {
            try
            {
                if ((sesionActual != null) && (!string.IsNullOrWhiteSpace(sesionActual.Token)))
                {
                    CE_Estatus lestatus;

                    switch (tipoGds)
                    {
                        // sabre
                        case EnumTipoGds.Sabre:
                            lestatus = (new HerramientaSabre(aplicacion, codigoSeguimiento, null, sesionActual).CerrarSesion());
                            break;

                        // amadeus
                        case EnumTipoGds.Amadeus:
                            sesionActual.AmadeusTransactionType = EnumTransactionType.End;

                            // cerrando sesión
                            lestatus = (new HerramientaAmadeus(aplicacion, codigoSeguimiento, null)).Ignorar(ref sesionActual);
                            break;

                        // otros
                        default:
                            throw new InternalException(string.Format("TIPO DE GDS '{0}' NO SOPORTADO.", tipoGds));
                    }

                    if (lestatus != null)
                    {
                        if (lestatus.Ok)
                        {
                            sesionActual = null;

                        }
                        else
                        {
                            // actualizando respuesta
                            estatus.RegistrarErrores(lestatus.Mensajes.Select(m => m.Valor).ToList());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.ErrorAndInfo(ex, new { aplicacion, tipoGds, sesionActual, estatus }, codigoSeguimiento);

                // actualizando respuesta
                estatus.RegistrarError(ex.Message);
            }
        }

        private string ProcesarCiudadDestino(string pnr,
                                             CE_Segmento[] segmentos)
        {
            // ONE WAY
            // ¿la ciudad de salida del 1er segmento resultado es diferente a la ciudad de llegada del último segmento resultado?  
            if (!segmentos.First().CiudadSalida.IdCiudad.Equals(segmentos.Last().CiudadLlegada.IdCiudad, StringComparison.InvariantCultureIgnoreCase))
            {
                return segmentos.Last().CiudadLlegada.IdCiudad;
            }

            // ROUND TRIP
            // ¿la cantidad de segmentos a procesar es un número par?
            if ((segmentos.Length % 2) == 0)
            {
                // ¿si la cantidad de segmentos a procesar es 2? copiar la lista de segmentos en resultado
                var lresultado = ((segmentos.Length == 2) ? segmentos.ToList() : new List<CE_Segmento>());

                // ¿la cantidad de segmentos a procesar es mayor a 2?
                if (segmentos.Length > 2)
                {
                    // dividiendo los segmentos en 2 grupos
                    var lcountGroups = (segmentos.Length / 2);

                    // ciclo para procesar los 2 grupos
                    for (var lgroup = 0; lgroup < 2; lgroup++)
                    {
                        // separando segmentos del grupo
                        var lsegmentos = segmentos.Skip((lgroup * lcountGroups)).Take(lcountGroups).ToList();

                        // ¿la ciudad de salida del 1er segmento es igual a la ciudad de llegada del último segmento del grupo?
                        if (lsegmentos.First().CiudadSalida.IdCiudad.Equals(lsegmentos.Last().CiudadLlegada.IdCiudad, StringComparison.InvariantCultureIgnoreCase))
                        {
                            throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - ITINERARIO COMPLEJO.", pnr));
                        }

                        // recorriendo segmentos en pasos de a 2
                        for (var lstep = 0; lstep < (lsegmentos.Count - 1); lstep++)
                        {
                            // ¿la ciudad de llegada del segmento actual es diferente a la ciudad de salida del segmento siguiente al actual?
                            if (!lsegmentos[lstep].CiudadLlegada.IdCiudad.Equals(lsegmentos[(lstep + 1)].CiudadSalida.IdCiudad, StringComparison.InvariantCultureIgnoreCase))
                            {
                                throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - ITINERARIO COMPLEJO.", pnr));
                            }
                        }

                        // agregando segmento resumen a resultado
                        lresultado.Add(new CE_Segmento
                        {
                            CiudadSalida = lsegmentos.First().CiudadSalida,
                            CiudadLlegada = lsegmentos.Last().CiudadLlegada
                        });
                    }
                }

                // ¿la ciudad de llegada del 1er segmento resultado es diferente a la ciudad de salida del último segmento resultado?
                if (!lresultado.First().CiudadLlegada.IdCiudad.Equals(lresultado.Last().CiudadSalida.IdCiudad, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - ITINERARIO COMPLEJO.", pnr));
                }

                return lresultado.First().CiudadLlegada.IdCiudad;
            }

            throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - ITINERARIO COMPLEJO.", pnr));
        }

        private void ProcesarBoletos(EnumAplicaciones aplicacion,
                                     EnumTipoGds tipoGds,
                                     string codigoSeguimiento,
                                     string codigoEntorno,
                                     CE_Reserva parametros,
                                     Guid guid,
                                     ref CE_Session session,
                                     ref CE_Estatus estatus,
                                     out CE_Reserva[] resultado)
        {
            CE_Reserva lreservaRecuperada;

            resultado = null;

            // registrando eventos
            Bitacora.Current.Debug("INICIANDO PROCESAMIENTO", new { aplicacion, tipoGds, codigoEntorno, parametros, session, guid }, codigoSeguimiento);

            // recuperando reserva
            RecuperarReserva(aplicacion, tipoGds, codigoSeguimiento, parametros, ref session, ref estatus, out lreservaRecuperada);

            // ¿continuar?
            if (estatus.Ok)
            {
                var lalertas = new List<string>();

                // actualizando reserva recuperada con parametros recibidos
                lreservaRecuperada.Aplicacion = parametros.Aplicacion;
                lreservaRecuperada.Aplicacion.TipoAplicacion = aplicacion;
                lreservaRecuperada.Cliente = (lreservaRecuperada.Cliente ?? parametros.Cliente);
                lreservaRecuperada.Facturacion = parametros.Facturacion;

                using (var lgeneral = new General(codigoSeguimiento, codigoEntorno))
                {
                    CE_Reserva lreservaPreCompletada;

                    // preparando ejecución
                    lgeneral.Prepare();

                    // ejecutando precompletar reserva
                    estatus = lgeneral.PreCompletarReserva(lreservaRecuperada, out lreservaPreCompletada);

                    // ¿continuar?
                    if (estatus.Ok)
                    {
                        // procesando boletos de la reserva precompletada
                        lreservaPreCompletada.Boletos
                            .Where(b => (
                                string.Format("{0}", b.Tipo).Equals("TE", StringComparison.InvariantCultureIgnoreCase) &&
                                string.Format("{0}", b.Estatus).Equals("ACTIVO", StringComparison.InvariantCultureIgnoreCase)))
                            .ToList()
                            .ForEach(b1 =>
                            {
                                // evaluando si algún boleto no tiene cotización asociada
                                if (b1.Cotizacion == null)
                                {
                                    throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - EL BOLETO '{1}' NO POSEE COTIZACIÓN.", parametros.PNR, b1.NumeroBoleto));
                                }

                                // completando información de segmentos
                                b1.Segmentos = b1.Segmentos
                                    .Join(
                                        lreservaPreCompletada.Itinerario.Segmentos,
                                        left => left.NumeroSegmento,
                                        right => right.NumeroSegmento,
                                        (left, right) => right)
                                    .Select(Advanced.ToCopy<CE_Segmento, CE_Segmento>)
                                    .ToArray();

                                // evaluando si los segmentos poseen una ciudad prohibida para emisión
                                if (b1.Segmentos.Any(s => ((s.CiudadSalida.ProhibeEmision ?? false) || (s.CiudadLlegada.ProhibeEmision ?? false))) ||
                                    string.Format("{0}", lreservaPreCompletada.Cliente.IdCliente).Equals(Configuracion.VoidTestForDKeDestinos))
                                {
                                    // registrando alerta
                                    lalertas.Add(string.Format("El BOLETO '{0}' DE LA RESERVA '{1}' NO PUEDE SER PROCESADA POR REGLA DE PTA - CIUDAD PROHIBIDA PARA EMISIÓN.", b1.NumeroBoleto, parametros.PNR));

                                    // ########################################################
                                    // MARCANDO BOLETOS PARA FLAVIO
                                    lreservaRecuperada.Boletos.First(b2 => b2.NumeroBoleto.Equals(b1.NumeroBoleto, StringComparison.InvariantCultureIgnoreCase)).Seleccionado = true;
                                    // ########################################################

                                }
                                else
                                {
                                    // ########################################################
                                    // EVALUANDO REGLAS GDS Y FORZANDO SELECCION CIUDAD DESTINO

                                    if ((!b1.Cotizacion.TipoTarifa.Codigo.HasValue) || (b1.Cotizacion.TipoTarifa.Codigo.Value != EnumCodigoTarifa.PL))
                                    {
                                        throw new InternalException(string.Format("LA RESERVA '{0}' NO PUEDE SER PROCESADA POR REGLA DE GDS - TARIFA INVÁLIDA.", parametros.PNR));
                                    }

                                    // intentando encontrar la ciudad destino y seleccionando boleto
                                    b1.Cotizacion.CiudadDestino = new CE_Ciudad { CodigoCiudadSegmento = ProcesarCiudadDestino(parametros.PNR, b1.Segmentos) };
                                    b1.Cotizacion.Pseudo = parametros.Aplicacion.PseudoEmision;
                                    b1.Seleccionado = true;
                                    // ########################################################
                                }
                            });

                        // ########################################################
                        // EVALUANDO SI HAY MARCADOS BOLETOS PARA ANULACION
                        if (lreservaRecuperada.Boletos.Any(b => (b.Seleccionado ?? false)))
                        {
                            // construyendo nombre de archivo
                            var larchivoAnulacion = string.Format(@"{0}\{1}-{2}.json", Configuracion.VoidDirectoryeDestinos, parametros.PNR, guid);

                            // creando archivo para anulación
                            JsonHelper.JsonSerializerExt(lreservaRecuperada, false, larchivoAnulacion, Configuracion.UseImpertsonateeDestinos);
                        }
                        // ########################################################

                        // ¿continuar?
                        if (lreservaPreCompletada.Boletos.Any(b => (b.Seleccionado ?? false)))
                        {
                            using (var lmoduloComercial = new ComisionFee(codigoSeguimiento, codigoEntorno))
                            {
                                lmoduloComercial.Conexion = lgeneral.Conexion;
                                lmoduloComercial.Esquema = lgeneral.Esquema;

                                // ejecutando el modulo comercial
                                estatus = lmoduloComercial.ProcesandoPostVenta(lreservaPreCompletada, out resultado);
                            }
                        }
                    }
                }

                // actualizando respuesta
                estatus.RegistrarAlertas(lalertas);
            }

            // registrando eventos
            Bitacora.Current.Debug("FINALIZANDO PROCESAMIENTO", new { session, estatus, resultado, lreservaRecuperada }, codigoSeguimiento);
        }

        #endregion

        // =============================
        // HttpPost

        #region "HttpPost"

        [HttpPost]
        [ActionName("ProcesarBoletosFull")]
        public CE_Response1<CE_Reserva[]> ProcesarBoletosFull(CE_Request2<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response1<CE_Reserva[]>();

            CE_Session lsesionActual = null;
            CE_Estatus lestatus = null;

            var lguid = Guid.NewGuid();

            try
            {
                CE_Reserva[] lresultado;

                // procesando boletos
                ProcesarBoletos(
                    request.Aplicacion.Value, 
                    request.Parametros.Aplicacion.TipoGds.Value,
                    request.CodigoSeguimiento, 
                    request.CodigosEntorno, 
                    request.Parametros,
                    lguid,
                    ref lsesionActual, 
                    ref lestatus, 
                    out lresultado);

                lrespuesta.Estatus = lestatus;
                lrespuesta.Resultado = lresultado;

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Reserva[]>(ex);

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.ErrorAndInfo(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_Reserva[]>(ex);

            }
            finally
            {
                // cerrando sesión
                CerrarSesion(request.Aplicacion.Value, request.Parametros.Aplicacion.TipoGds.Value, request.CodigoSeguimiento, ref lsesionActual, ref lestatus);
            }

            // ########################################################
            // CREANDO ARCHIVO DE HISTORICO

            // construyendo nombre de archivo
            var larchivoHistorico = string.Format(@"{0}\{1}-{2}.json", Configuracion.EchoDirectoryeDestinos, request.Parametros.PNR, lguid);

            // creando archivo para historico
            JsonHelper.JsonSerializerExt(lrespuesta, false, larchivoHistorico, Configuracion.UseImpertsonateeDestinos);
            // ########################################################

            return lrespuesta;
        }

        [HttpPost]
        [ActionName("ProcesarBoletosMinus")]
        public CE_Response1<CE_ProcesarBoletos[]> ProcesarBoletosMinus(CE_Request2<CE_Reserva> request)
        {
            var lrespuesta = new CE_Response1<CE_ProcesarBoletos[]>();

            CE_Session lsesionActual = null;
            CE_Estatus lestatus = null;

            var lguid = Guid.NewGuid();

            try
            {
                CE_Reserva[] lresultado;

                // procesando boletos
                ProcesarBoletos(
                    request.Aplicacion.Value,
                    request.Parametros.Aplicacion.TipoGds.Value,
                    request.CodigoSeguimiento, 
                    request.CodigosEntorno, 
                    request.Parametros,
                    lguid,
                    ref lsesionActual, 
                    ref lestatus, 
                    out lresultado);

                lrespuesta.Estatus = lestatus;

                // evaluando si existen resultados que filtrar
                if (lresultado != null)
                {
                    lrespuesta.Resultado = lresultado
                        .Select(r => new CE_ProcesarBoletos
                        {
                            NumeroBoleto = r.Boletos[0].NumeroBoleto,
                            TipoTarifa = r.Cotizaciones[0].TipoTarifa,
                            CiudadDestino = r.Cotizaciones[0].CiudadDestino,
                            ComisionPta = r.Cotizaciones[0].Tarifas[0].ComisionPta,
                            FeePta = r.Cotizaciones[0].Tarifas[0].FeePta
                        }).ToArray();
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_ProcesarBoletos[]>(ex);

            }
            catch (Exception ex)
            {
                // registrando evento
                Bitacora.Current.ErrorAndInfo(ex, new { request });

                // actualizando respuesta
                lrespuesta = new CE_Response1<CE_ProcesarBoletos[]>(ex);

            }
            finally
            {
                // cerrando sesión
                CerrarSesion(request.Aplicacion.Value, request.Parametros.Aplicacion.TipoGds.Value, request.CodigoSeguimiento, ref lsesionActual, ref lestatus);
            }

            // ########################################################
            // CREANDO ARCHIVO DE HISTORICO

            // construyendo nombre de archivo
            var larchivoHistorico = string.Format(@"{0}\{1}-{2}.json", Configuracion.EchoDirectoryeDestinos, request.Parametros.PNR, lguid);

            // creando archivo para historico
            JsonHelper.JsonSerializerExt(lrespuesta, false, larchivoHistorico, Configuracion.UseImpertsonateeDestinos);
            // ########################################################

            return lrespuesta;
        }

        #endregion
    }
}
