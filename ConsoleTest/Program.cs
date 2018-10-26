using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;
using CoreLib.Generics;
using CoreWebLib;
using RepositorioWebApi;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Comentario;

using EntidadesGDS.General;
using EntidadesGDS.Reporte.BoletosEmitidos;
using EntidadesGDS.Facturacion;
using EntidadesGDS.TarjetaCredito;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Queue;
using EntidadesGDS.Robot;
using EntidadesGDS.Robot.BoletosOADP;
using EntidadesGDS.Robot.BoletoPendientePago;
using EntidadesGDS.Reglas;


using EntidadesGDS.Boleto;
using EntidadesGDS.Clientes.eDestinos;
using CoreWebLib;

using CE_Estatus = EntidadesGDS.Base.CE_Estatus;
using CE_FormaPago = EntidadesGDS.FormaPago.CE_FormaPago;
using EnumAplicaciones = EntidadesGDS.EnumAplicaciones;
using EnumTipoDocumento = EntidadesGDS.EnumTipoDocumento;
using EnumTipoFormaPago = EntidadesGDS.EnumTipoFormaPago;
using RQ_ObtenerReglasEmision = EntidadesGDS.Reglas.RQ_ObtenerReglasEmision;

namespace ConsoleTest
{
    internal class Program
    {

        private static void Test_AcercaDe()
        {
            using (var lrepositorio = new RepositoryWebApi("Base.json"))
            {
                var lrespuesta = lrepositorio.GetObject("AcercaDe");

                // actualizando reserva
                Console.WriteLine(lrespuesta);
            }

            Console.Out.WriteLine("Finish Test_AcercaDe");
        }

        private static CE_Reserva Test_PreCompletarReservaPL()
        {
            var MiReserva = new CE_Reserva
            {
                Aplicacion = new CE_Aplicacion
                {
                    TipoAplicacion = EnumAplicaciones.Turbo,
                    PseudoConsulta = "QF05",
                    TipoGds = EnumTipoGds.Sabre,
                    IdGrupo = "3"
                },
                Usuario = new CE_Usuario
                {
                    IdVendedorPta = "681",
                    InicialesFirma = "H1"
                },
                Cliente = new CE_Cliente
                {
                    IdCliente = 23571,
                    IdSubCodigo = 1 // nada con '0'
                },
                PNR = "JDPTVN",
                EmisionClero = "NO",
                EmiteConRUC = false,
                TipoFormaPagoComision = EnumTipoFormaPagoComision.CASH,
                EsReemision = false,
                Pasajeros = new[]
                {
                    new CE_Pasajero
                    {
                        NumeroPasajero = "1.1",
                        Apellido = "SANCHEZ",
                        Nombre = "HUGO",
                        TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ADT" }
                    }
                },
                Itinerario = new CE_Itinerario
                {
                    Segmentos = new[]
                    {
                        new CE_Segmento
                        {
                            NumeroSegmento = 1,
                            Aerolinea = new CE_Aerolinea {CodigoAerolinea = "LA"},
                            NumeroVuelo = "530",
                            ClaseReserva = "S",
                            FechaSalida = "03MAR",
                            DiaSemanaSalida = "6",
                            HoraSalida = "2345",
                            CiudadSalida = new CE_Ciudad {CodigoCiudadSegmento = "LIM"},
                            FechaLlegada = "04MAR",
                            DiaSemanaLlegada = "7",
                            HoraLlegada = "0715",
                            CiudadLlegada = new CE_Ciudad {CodigoCiudadSegmento = "JFK"},
                            Status = "HK",
                            CantidadAsientos = 1,
                            CodigoReservaAerolinea = "JDPTBD"
                        },
                        new CE_Segmento
                        {
                            NumeroSegmento = 2,
                            Aerolinea = new CE_Aerolinea {CodigoAerolinea = "LA"},
                            NumeroVuelo = "6576",
                            ClaseReserva = "S",
                            FechaSalida = "20MAR",
                            DiaSemanaSalida = "2",
                            HoraSalida = "1100",
                            CiudadSalida = new CE_Ciudad {CodigoCiudadSegmento = "EWR"},
                            //FechaLlegada = ,
                            //DiaSemanaLlegada = ,
                            HoraLlegada = "1408",
                            CiudadLlegada = new CE_Ciudad {CodigoCiudadSegmento = "MIA"},
                            Status = "HK",
                            CantidadAsientos = 1,
                            CodigoReservaAerolinea = "JDPTBD",
                            OperadoPor = "OPERATED BY AMERICAN AIRLINES FOR LATAM AIRLINES GROUP"
                        },
                        new CE_Segmento
                        {
                            NumeroSegmento = 3,
                            Aerolinea = new CE_Aerolinea {CodigoAerolinea = "LA"},
                            NumeroVuelo = "2467",
                            ClaseReserva = "S",
                            FechaSalida = "20MAR",
                            DiaSemanaSalida = "2",
                            HoraSalida = "1725",
                            CiudadSalida = new CE_Ciudad {CodigoCiudadSegmento = "MIA"},
                            HoraLlegada = "2220",
                            CiudadLlegada = new CE_Ciudad {CodigoCiudadSegmento = "LIM"},
                            Status = "HK",
                            CantidadAsientos = 1,
                            CodigoReservaAerolinea = "JDPTBD",
                            OperadoPor = "OPERATED BY LATAM AIRLINES PERU"
                        }
                    }
                },
                Facturacion = new CE_Facturacion { IdSucursal = 2, Punto = 14 }
            };

            var lrequest1 = new CE_Request2<CE_Reserva>
            {
                CodigosEntorno = "DESA/NMO/TBO",
                Parametros = MiReserva
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva>>("PreCompletarReserva", lrequest1);

                // actualizando reserva
                MiReserva = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_PreCompletarReserva");

            return MiReserva;
        }

        private static void Test_ProcesandoComisionesPL(CE_Reserva miReserva)
        {
            miReserva.Cotizaciones = new []
            {
                new CE_Cotizacion 
                {
                    NumeroPQ = 1,
                    Seleccionada = true,
                    UltimoDiaDeCompra = "05NOV/2359",
                    TotalCotizacion = decimal.Parse("2180.17"),
                    TipoTarifa = new CE_TipoTarifa { Tipo = EnumTipoTarifa.FV, Codigo = EnumCodigoTarifa.PL },
                    LineasValidadoras = new []
                    {
                        new CE_Aerolinea { Seleccionada = true, CodigoAerolinea = "LA" }, 
                    },
                    CiudadDestino = new CE_Ciudad {CodigoCiudadSegmento = "NYC"}, // FALTA USARLO
                    Pseudo = "QF05",
                    Tarifas = new[]
                    {
                        new CE_Tarifa
                        {
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ADT" }, // TAMPOCO SE HA USADO
                            Total = decimal.Parse("961.23"),
                            Neto = decimal.Parse("719.00"),
                            BaseTarifaria = new[]
                            {
                                new CE_BaseTarifaria {NumeroSegmento = 1, BaseTarifaria = "SLWSP98F"},
                                new CE_BaseTarifaria {NumeroSegmento = 2, BaseTarifaria = "SLXSP98F"},
                                new CE_BaseTarifaria {NumeroSegmento = 3, BaseTarifaria = "SLXSP98F"}
                            },
                            Impuestos = new[]
                            {
                                new CE_Impuesto {CodigoImpuesto = "PE", Importe = decimal.Parse("129.42")},
                                new CE_Impuesto {CodigoImpuesto = "DY", Importe = decimal.Parse("15.00")},
                                new CE_Impuesto {CodigoImpuesto = "HW", Importe = decimal.Parse("30.75")},
                                new CE_Impuesto {CodigoImpuesto = "US", Importe = decimal.Parse("36.00")},
                                new CE_Impuesto {CodigoImpuesto = "YC", Importe = decimal.Parse("5.50")},
                                new CE_Impuesto {CodigoImpuesto = "XY", Importe = decimal.Parse("7.00")},
                                new CE_Impuesto {CodigoImpuesto = "XA", Importe = decimal.Parse("3.96")},
                                new CE_Impuesto {CodigoImpuesto = "AY", Importe = decimal.Parse("5.60")},
                                new CE_Impuesto {CodigoImpuesto = "XF", Importe = decimal.Parse("9.00")}
                            }
                        }
                    }
                }   
            };

            var lrequest2 = new CE_Request2<CE_Reserva>
            {
                CodigosEntorno = "DESA/NMO/TBO",
                Parametros = miReserva
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva>>("ProcesandoComisionesFees", lrequest2);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ProcesandoComisiones");
        }

        private static CE_Reserva Test_PreCompletarReservaPV()
        {
            var MiReserva = new CE_Reserva
            {
                Aplicacion = new CE_Aplicacion
                {
                    TipoAplicacion = EnumAplicaciones.Turbo,
                    PseudoConsulta = "QF05",
                    TipoGds = EnumTipoGds.Sabre,
                    IdGrupo = "4"
                },
                Usuario = new CE_Usuario
                {
                    IdVendedorPta = "681",
                    InicialesFirma = "H1"
                },
                Cliente = new CE_Cliente
                {
                    IdCliente = 23571,
                    IdSubCodigo = 1 // nada con '0'
                },
                PNR = "XKWBQK",
                EmisionClero = "NO",
                EmiteConRUC = false,
                TipoFormaPagoComision = EnumTipoFormaPagoComision.CASH,
                EsReemision = false,
                Pasajeros = new[]
                {
                    new CE_Pasajero
                    {
                        NumeroPasajero = "1.1",
                        Apellido = "BARRENECHEA",
                        Nombre = "MILAGROS",
                        TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ITX" }
                    }
                },
                Itinerario = new CE_Itinerario
                {
                    Segmentos = new[]
                    {
                        new CE_Segmento
                        {
                            NumeroSegmento = 1,
                            Aerolinea = new CE_Aerolinea  {CodigoAerolinea = "AV" },
                            NumeroVuelo = "0148",
                            ClaseReserva = "Z",
                            FechaSalida = "15FEB",
                            DiaSemanaSalida = "4",
                            HoraSalida = "1025",
                            CiudadSalida = new CE_Ciudad { CodigoCiudadSegmento = "LIM" },
                            FechaLlegada = "15FEB",
                            DiaSemanaLlegada = "4",
                            HoraLlegada = "1320",
                            CiudadLlegada = new CE_Ciudad { CodigoCiudadSegmento = "CLO" },
                            Status = "HK",
                            CantidadAsientos = 1,
                            CodigoReservaAerolinea = "UEXSEC",
                            OperadoPor = "OPERATED BY /TRANS AMERICAN AIRLINES"
                        },
                        new CE_Segmento
                        {
                            NumeroSegmento = 2,
                            Aerolinea = new CE_Aerolinea { CodigoAerolinea = "AV" },
                            NumeroVuelo = "9734",
                            ClaseReserva = "P",
                            FechaSalida = "15FEB",
                            DiaSemanaSalida = "4",
                            HoraSalida = "1552",
                            CiudadSalida = new CE_Ciudad { CodigoCiudadSegmento = "CLO" },
                            FechaLlegada = "15FEB",
                            DiaSemanaLlegada = "4",
                            HoraLlegada = "1653",
                            CiudadLlegada = new CE_Ciudad { CodigoCiudadSegmento = "BOG" },
                            Status = "HK",
                            CantidadAsientos = 1,
                            CodigoReservaAerolinea = "UEXSEC",
                            OperadoPor = "OPERATED BY /AVIANCA"
                        },
                        new CE_Segmento
                        {
                            NumeroSegmento = 3,
                            Aerolinea = new CE_Aerolinea { CodigoAerolinea = "AV" },
                            NumeroVuelo = "0049",
                            ClaseReserva = "P",
                            FechaSalida = "18FEB",
                            DiaSemanaSalida = "7",
                            HoraSalida = "0534",
                            CiudadSalida = new CE_Ciudad { CodigoCiudadSegmento = "BOG" },
                            FechaLlegada = "18FEB",
                            DiaSemanaLlegada = "7",
                            HoraLlegada = "0834",
                            CiudadLlegada = new CE_Ciudad { CodigoCiudadSegmento = "LIM" },
                            Status = "HK",
                            CantidadAsientos = 1,
                            CodigoReservaAerolinea = "UEXSEC",
                            OperadoPor = "OPERATED BY /AVIANCA"
                        }
                    }
                },
                Facturacion = new CE_Facturacion { IdSucursal = 2, Punto = 14 }
            };

            var lrequest1 = new CE_Request2<CE_Reserva>
            {
                CodigosEntorno = "DESA/NMO/TBO",
                Parametros = MiReserva
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva>>("PreCompletarReserva", lrequest1);

                // actualizando reserva
                MiReserva = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_PreCompletarReserva");

            return MiReserva;
        }

        private static CE_Reserva Test_PreCompletarCliente(CE_Reserva reserva)
        {
            var lrequest1 = new CE_Request2<CE_Reserva>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "BRUC3",
                CodigosEntorno = "DESA/NMO/SCL",
                Parametros = reserva
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva>>("PreCompletarCliente", lrequest1);

                // actualizando reserva
                reserva = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_PreCompletarCliente");

            return reserva;
        }

        private static void Test_ProcesandoComisionesPV(CE_Reserva miReserva)
        {
            miReserva.Cotizaciones = new []
            {
                new CE_Cotizacion
                {
                    NumeroPQ = 1,
                    Seleccionada = true,
                    UltimoDiaDeCompra = "24NOV/0904",
                    TotalCotizacion = decimal.Parse("415.35"),
                    TipoTarifa = new CE_TipoTarifa { Tipo = EnumTipoTarifa.IT, Codigo = EnumCodigoTarifa.PV },
                    LineasValidadoras = new []
                    {
                        new CE_Aerolinea { Seleccionada = true, CodigoAerolinea = "AV" },
                    },
                    CiudadDestino = new CE_Ciudad { CodigoCiudadSegmento = "CLO" }, // FALTA USARLO
                    Pseudo = "HW57",
                    Tarifas = new[]
                    {
                        new CE_Tarifa
                        {
                            TipoPasajero = new CE_TipoPasajero {IdTipoPasajero = "ITX"}, // TAMPOCO SE HA USADO
                            Total = decimal.Parse("415.35"),
                            Neto = decimal.Parse("264.00"),
                            BaseTarifaria = new[]
                            {
                                new CE_BaseTarifaria {NumeroSegmento = 1, BaseTarifaria = "ZEF14TPE"},
                                new CE_BaseTarifaria {NumeroSegmento = 2, BaseTarifaria = "PEO14SIG/TAV"},
                                new CE_BaseTarifaria {NumeroSegmento = 3, BaseTarifaria = "PEO14SIG/TAV"}
                            },
                            Impuestos = new[]
                            {
                                new CE_Impuesto {CodigoImpuesto = "PE", Importe = decimal.Parse("47.52")},
                                new CE_Impuesto {CodigoImpuesto = "DY", Importe = decimal.Parse("15.00")},
                                new CE_Impuesto {CodigoImpuesto = "HW", Importe = decimal.Parse("30.75")},
                                new CE_Impuesto {CodigoImpuesto = "CO", Importe = decimal.Parse("43.08")},
                                new CE_Impuesto {CodigoImpuesto = "JS", Importe = decimal.Parse("15.00")}
                            }
                        }
                    }
                }
            };

            var lrequest2 = new CE_Request2<CE_Reserva>
            {
                CodigosEntorno = "DESA/NMO/TBO",
                Parametros = miReserva
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva>>("ProcesandoComisionesFees", lrequest2);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ProcesandoComisiones");
        }


        #region kiu
        private static void Test_ObtenerItinerarioKIU(string pnr)
        {
            var param = new CE_Request2<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Parametros = pnr // "WBRDOA - YDFVBT, XIVCJU, TWJUIL, RUQNHA, HWVFVI => de HUGO
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerarioKiu.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<string>, CE_Response3<CE_Reserva>>("Obtener", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerItinerario");
        }

        #endregion


        #region "Sabre"

        private static void Test_ObtenerReporteVentas(string sessionToken)
        {
            var param = new CE_Request3<RQ_ObtenerReporteVentas>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "W7H7",
                    Token = sessionToken,
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy"
                },
                Parametros = new RQ_ObtenerReporteVentas
                {
                    PseudoQuery = "QF05",
                    Date = "2018-01-05"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioReporteVentas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<RQ_ObtenerReporteVentas>, CE_Response3<CE_ReporteVenta>>("ObtenerReporteVentas", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerReporteVentas");
        }

        private static void Test_ObtenerListadoReservas(string sessionToken)
        {
            var param = new CE_Request3<RQ_QueueAccess>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "W7H7",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new RQ_QueueAccess
                {
                    Number = "100",
                    PseudoCityCode = "XX05"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioColas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<RQ_QueueAccess>, CE_Response3<CE_QueueAccess>>("ObtenerListadoReserva", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerListadoReservas");
        }

        private static void Test_ObtenerItinerario(string sessionToken,
                                                   string pnr)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "W7H7",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = pnr // "WBRDOA - YDFVBT, XIVCJU, TWJUIL, RUQNHA, HWVFVI => de HUGO
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<CE_Reserva>>("Obtener", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerItinerario");
        }

        private static void Test_ObtenerCompletarItinerario(string sessionToken,
                                                            string pnr, 
                                                            out CE_Reserva reserva)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "PROD/NMO/SCL",
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = pnr // "WBRDOA - YDFVBT, XIVCJU, TWJUIL, RUQNHA, HWVFVI => de HUGO
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<CE_Reserva>>("ObtenerCompletar", param);

                // actualizando reserva
                reserva = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerCompletarItinerario");
        }

        private static void Test_ObtenerLineasContables(string sessionToken)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = "ZHBZRF" // "WBRDOA - YDFVBT, XIVCJU, TWJUIL
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<CE_LineaContable[]>>("ObtenerLineasContables", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerLineasContables");
        }

        private static void Test_ObtenerTarifasAlmacenadas(string sessionToken)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = "ZHBZRF" // "WBRDOA - YDFVBT, XIVCJU, TWJUIL
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<CE_Cotizacion[]>>("ObtenerTarifasAlmacenadas", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerTarifasAlmacenadas");
        }

        private static void Test_ObtenerComentarios(string sessionToken)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = "ZHBZRF" // "WBRDOA - YDFVBT, XIVCJU, TWJUIL
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<CE_Comentario[]>>("ObtenerComentarios", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerTarifasAlmacenadas");
        }

        private static void Test_VerificarDocsFoids(string sessionToken)
        {
            var param = new CE_Request3<string[]>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                CodigosEntorno = "DESA/NMO/SCL",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new[] { "ECNXLZ", "1.1", "1/2" }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string[]>, CE_Response2>("VerificarDocsFoids", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_VerificarDocsFoids");
        }

        private static void Test_ActualizarFoidsAndDocs(string sessionToken,
                                                        string pnr,
                                                        CE_Pasajero lpasajero)
        {
            var param = new CE_Request3<CE_Reserva>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                CodigosEntorno = "DESA/NMO/SCL",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new CE_Reserva
                {
                    PNR = pnr,
                    Pasajeros = new [] { lpasajero }
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Reserva>, CE_Response2>("ActualizarFoidsAndDocs", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_ActualizarFoidsAndDocs");
        }

        private static void Test_ActualizarPasajeros(string sessionToken)
        {
            var param = new CE_Request3<RQ_ActualizarPasajeros>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new RQ_ActualizarPasajeros
                {
                    Pasajeros = new[]
                    {
                        new CE_Pasajero
                        {
                            NumeroPasajero = "1.1",
                            Apellido = "BARRENECHEA",
                            Nombre = "MILAGROS",
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ADT" }
                        }
                    }
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<RQ_ActualizarPasajeros>, CE_Response2>("ActualizarPasajeros", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_ActualizarPasajeros");
        }

        #endregion

        #region "Boletos"

        private static void Test_ObtenerBoletosPendientesPago()
        {
            var param = new CE_Request2<RQ_ObtenerBoletosPendientesPago>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "PROD/NMO/SCL",
                Parametros = new RQ_ObtenerBoletosPendientesPago
                {
                    TipoClienteAgencia = "01",
                    CondicionPagoCliente = "CON",
                    TipoClientePasajero = 99,
                    IdClientePasajero = 339,
                    IdEmpresaSucursal = 1,
                    MarcaEsConsolidador = 1,
                    ListaGds = "3,1,0",
                    ListaProveedoresBoletos = "6000",
                    //Fecha = 
                    AntesDeHora = "19:57"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioBoleto.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_ObtenerBoletosPendientesPago>, CE_Response1<CE_BoletoFacturado[]>>("ObtenerBoletosPendientesPago", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerBoletosPendientesPago");
        }

        //private static void Test_ObtenerBoletoFacturado()
        //{
        //    var param = new CE_Request2<RQ_ObtenerBoletoFacturado>
        //    {
        //        Aplicacion = EnumAplicaciones.Interagencia,
        //        CodigosEntorno = "PROD/NMO/SCL",
        //        Parametros = new RQ_ObtenerBoletoFacturado
        //        {
        //            TicketNumbre = "5946596185",
        //            IdEmpresaSucursal = 1,
        //            MarcaEsConsolidador = 1,
        //            ListaGds = "2",
        //            Fecha = "29/11/2017"
        //        }
        //    };

        //    using (var lrepositorio = new RepositoryWebApi("ServicioBoleto.json"))
        //    {
        //        var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_ObtenerBoletoFacturado>, CE_Response1<CE_BoletoFacturado>>("ObtenerBoletoFacturado", param);

        //        // actualizando reserva
        //        var salida = lrespuesta.Resultado;
        //    }

        //    Console.Out.WriteLine("Finish Test_ObtenerBoletoFacturado");
        //}

        private static void Test_ObtenerInterfaceProveedor()
        {
            var param = new CE_Request2<RQ_ObtenerInterfaceProveedor>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "DESA/NMO/SCL",
                Parametros = new RQ_ObtenerInterfaceProveedor
                {
                    PseudoConsulta = "QF05",
                    PseudoEmision = "QQ05"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioFacturacion.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_ObtenerInterfaceProveedor>, CE_Response1<CE_InterfaceProveedor>>("ObtenerInterfaceProveedor", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerInterfaceProveedor");
        }

        private static void Test_ObtenerSecuenciaReferencia()
        {
            var param = new CE_Request1
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "DESA/NMO/SCL"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioFacturacion.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request1, CE_Response1<CE_SecuenciaReferencia>>("ObtenerSecuenciaReferencia", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerSecuenciaReferencia");
        }

        /*
        private static void Test_ObtenerCorrelativoFacturacion()
        {
            var param = new CE_Request2<CE_Facturacion>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "DESA/NMO/SCL",
                Parametros = new CE_Facturacion
                {
                    Punto = 14,
                    IdSucursal = 2
                    //TipoComprobante = EnumTipoComprobanteFacturacion.BV
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioFacturacion.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Facturacion>, CE_Response1<CE_FacturaCabecera>>("ObtenerCorrelativoFacturacion", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerCorrelativoFacturacion");
        }
        */

        #endregion

        private static void Test_InsertarCuerpoBoleto()
        {
            var param = new CE_Request2<RQ_InsertaCuerpoOADP>
            {
                CodigosEntorno = "DESA/NMO/SCL",
                Parametros = new RQ_InsertaCuerpoOADP
                {
                    PCC = "QEH",
                    CodigoReserva = "N88EHU",
                    CodigoCliente = 20627,
                    NumeroBoleto = "5946596188",
                    TipoOadp = EnumTipoOADP.Voucher,
                    Correlativo = 1,
                    CuerpoDocumento = "ETKT                CREDIT CARD CHARGE FORM" + "\n" +
                                      "TACA PERU                          EZE/ASU       NUEVO MUNDO" + "\n" +
                                      "RUC20348858182 PAYABLEONLYINU      29NOV17       MIRAFLORES PE" + "\n" +
                                      "SDOLLARS/ /NON REF/CHNG FEE A                    91500312    N88EHU/1P" + "\n" +
                                      "VILLANUEVA/LIDIA" + "\n" +
                                      "SIGNATURE X" + "\n" +
                                      "I ACKNOWLEDGE PURCHASE OF TRANSPORTATION RELATED SERVICES AND/OR" + "\n" +
                                      "GOODS AND AM AWARE OF APPLICABLE RESTRICTIONS AND/OR PENALTIES" + "\n" +
                                      "ASSOCIATED WITH THE PURCHASE AS SHOWN ON THIS RECEIPT" + "\n" +
                                      "USD  187.00" + "\n" +
                                      "PE    33.66 DY    15.00    VI XXXX XXXX XXXX 3012PXXXX      APVL C 040494 XT   112.85" + "\n" +
                                      "USD  348.51    5235/    530 5946596185 4",
                
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioBoleto.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_InsertaCuerpoOADP>, CE_Response1<bool>>("InsertaCuerpoBoleto", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_InsertarCuerpoBoleto");
        }

        private static void Test_InsertaTurboPassengerReceipt()
        {
            var param = new CE_Request2<CE_TurboPassengerReceipt>
            {
                //"DESA/NMO/SCL"
                CodigosEntorno = "PROD/NMO/SCL",
                Parametros = new CE_TurboPassengerReceipt
                {
                    TicketNumber = "1111111111",
                    PnrCode = "PRUEBA",
                    DkNumber = 23571,
                    RucNumber = "10154516528",
                    Pcc = "AAAA",
                    CounterTA = "ROBOT",
                    CuerpoDocumento = "PRUEBA CUERPO DOCUMENTO",
                    PasajeroNombre = "HUGO",
                    PasajeroApellido = "SANCHEZ",
                    IdHeader = EnumHeaderPassengerReceipt.Boleto,
                    CounterEmail = "hugo.sanchez@expertiatravel.com",
                    FreqTravel = "123456789",
                    Ruta = ""

                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioBoleto.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_TurboPassengerReceipt>, CE_Response1<bool>>("InsertaTurboPassengerReceipt", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_InsertaTurboPassengerReceipt");
        }

        private static void Test_ProbarConexion()
        {
            var param = new CE_Request1
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "xxxx",
                CodigosEntorno = "DESA/NMO/SCL"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request1, CE_Response1<bool>>("ProbarConexion", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ProbarConexion");
        }

        private static void Test_AnadirComentarios(string sessionToken)
        {
            var param = new CE_Request3<CE_Comentario[]>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "W7H7",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new []
                {
                    new CE_Comentario { Texto = "Remarks General", Tipo = EnumTipoComentario.General  }, 
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Comentario[]>, CE_Response2>("AnadirComentarios", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_AnadirComentarios");
        }

        private static void Test_ActualizarComentarios(string sessionToken)
        {
            var param = new CE_Request3<CE_Comentario[]>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new[]
                {
                    new CE_Comentario { Id = 2, Texto = "Prueba ++", Tipo = EnumTipoComentario.General  }, 
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Comentario[]>, CE_Response2>("ActualizarComentarios", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_ActualizarComentarios");
        }

        private static void Test_BorrarComentarios(string sessionToken)
        {
            var param = new CE_Request3<int[]>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new []{ 1, 3, 4, 5 }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<int[]>, CE_Response2>("BorrarComentarios", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_BorrarComentarios");
        }

        private static void Test_BorrarComentariosPorRango(string sessionToken)
        {
            var param = new CE_Request3<RQ_BorrarRango>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new RQ_BorrarRango
                {
                    IdComentarioDesde = 2,
                    IdComentarioHasta = 3
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<RQ_BorrarRango>, CE_Response2>("BorrarComentariosPorRango", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_BorrarComentariosPorRango");
        }

        private static void Test_AsignarPerfilImpresora(string sessionToken)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                 Parametros = "10"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioHerramienta.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response2>("AsignarPerfilImpresora", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish AsignarPerfilImpresora");
        }

        private static void Test_SalirPerfilImpresora(string sessionToken)
        {
            var param = new CE_Request3<bool>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = true
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioHerramientas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<bool>, CE_Response2>("SalirPerfilImpresora", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_SalirPerfilImpresora");
        }

        private static void Test_AnadirArunk(string sessionToken)
        {
            var param = new CE_Request4
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request4, CE_Response2>("AnadirArunk", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_AnadirArunk");
        }

        private static void Test_AnadirServicioEspecial(string sessionToken)
        {
            var param = new CE_Request3<RQ_AnadirServicioEspecial>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "W7H7",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new RQ_AnadirServicioEspecial
                {
                    AmericanAirlines = false,
                    Pasajero = new CE_Pasajero
                    {
                        NumeroPasajero = "1.1",
                        Nombre = "BRUCE",
                        Apellido = "CHOY",
                        Sexo = EnumSexo.M,
                        FechaNacimiento = "1978-10-04",
                    }
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<RQ_AnadirServicioEspecial>, CE_Response2>("AnadirServicioEspecial", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_AnadirServicioEspecial");
        }

        #region "Reglas"

        private static void Test_ObtenerReglasTarjetaPTA()
        {
            var param = new CE_Request2<RQ_ObtenerReglasTarjetaPTA>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "bchoy",
                CodigosEntorno = "DESA/NMO/SCL", // "PROD/DNM/SCL"
                Parametros = new RQ_ObtenerReglasTarjetaPTA
                {
                    PNR = "PF3ECT",
                    IATA = "91500312",
                    Transportador = "4O",
                    CiudadDestino = "MEX",
                    ImporteReserva = new decimal(914.98), //decimal.Parse("50.42"),
                    Conceptos = new[]
                    {
                        new CE_Concepto {IdConcepto = "1", Valor = "71"},
                        new CE_Concepto {IdConcepto = "2", Valor = "'00'"},
                        new CE_Concepto {IdConcepto = "3", Valor = "29581"},
                        new CE_Concepto {IdConcepto = "4", Valor = "0"},
                        new CE_Concepto {IdConcepto = "5", Valor = "'4O'"},
                        new CE_Concepto {IdConcepto = "6", Valor = "'PUB'"},
                        new CE_Concepto {IdConcepto = "7", Valor = "'SI'"},
                        new CE_Concepto {IdConcepto = "8", Valor = "'NO'"},
                        new CE_Concepto {IdConcepto = "9", Valor = "1"},
                        new CE_Concepto {IdConcepto = "11", Valor = "'NO'"},
                        new CE_Concepto {IdConcepto = "12", Valor = "20422964739"}
                    }
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioTarjetaCredito.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_ObtenerReglasTarjetaPTA>, CE_Response1<CE_EvaluacionTarjetaPTA>>("ObtenerReglasTarjetaPTA", param);

                // actualizando reserva
                 var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerReglasTarjetaPTA");
        }

        private static void Test_B2BWallet()
        {
            //var param = new CE_Request2<B2BWalletGenerateRQ>
            //{
            //    Aplicacion = EnumAplicaciones.Interagencia,
            //    CodigoSeguimiento = "bchoy",
            //    Parametros = new B2BWalletGenerateRQ
            //    {
            //        Message = new MessageGenerateRQ
            //        {
            //            Data = new DataGenerateRQ
            //            {
            //               Amount = new decimal(125.036)
            //            }
            //        }
            //    }
            //};

            //using (var lrepositorio = new RepositoryWebApi("ServicioTarjetaCredito.json"))
            //{
            //    var lrespuesta = lrepositorio.UpdateT<CE_Request2<B2BWalletGenerateRQ>, CE_Response1<B2BWalletGenerateRS>>("B2BWalletGenerate", param);

            //    // actualizando reserva
            //    var salida = lrespuesta.Resultado;
            //}
            //*****



            //var param = new CE_Request2<B2BWalletListRQ>
            //{
            //    Aplicacion = EnumAplicaciones.Interagencia,
            //    CodigoSeguimiento = "bchoy",
            //    Parametros = new B2BWalletListRQ
            //    {
            //        Message = new MessageListRQ
            //        {
            //            Data = new DataListRQ
            //            {
            //                Type = "Prepaid2",
            //                //VendorCode = "CA",
            //                Period = new PeriodListRQ { Start = "2018-08-19", End = "2018-08-20" }
            //            }
            //        }
            //    }
            //};

            //using (var lrepositorio = new RepositoryWebApi("ServicioTarjetaCredito.json"))
            //{
            //    var lrespuesta = lrepositorio.UpdateT<CE_Request2<B2BWalletListRQ>, CE_Response1<B2BWalletListRS>>("B2BWalletList", param);

            //    // actualizando reserva
            //    var salida = lrespuesta.Resultado;
            //}
            //****** 



            //var param = new CE_Request2<B2BWalletUpdateRQ>
            //{
            //    Aplicacion = EnumAplicaciones.Interagencia,
            //    CodigoSeguimiento = "bchoy",
            //    Parametros = new B2BWalletUpdateRQ
            //    {
            //        Message = new MessageUpdateRQ
            //        {
            //            Data = new DataUpdateRQ
            //            {
            //                /*
            //                Reference = new []
            //                {
            //                    new ReferenceBase { Type = "External", Value = "0RAD_Qb7IAe6o6inK0vMCZCep" }, 
            //                    new ReferenceBase { Type = "Amadeus", Value = "22225ZE6" }
            //                },
            //                */
            //                Comment = "Prueba de Nuevo Mundo"
            //            }
            //        }
            //    }
            //};

            //using (var lrepositorio = new RepositoryWebApi("ServicioTarjetaCredito.json"))
            //{
            //    var lrespuesta = lrepositorio.UpdateT<CE_Request2<B2BWalletUpdateRQ>, CE_Response1<B2BWalletUpdateRS>>("B2BWalletUpdate", param);

            //    // actualizando reserva
            //    var salida = lrespuesta.Resultado;
            //}
            //****** 



            //var param = new CE_Request2<B2BWalletDetailRQ>
            //{
            //    Aplicacion = EnumAplicaciones.Interagencia,
            //    CodigoSeguimiento = "bchoy",
            //    Parametros = new B2BWalletDetailRQ
            //    {
            //        Message = new MessageDetailRQ
            //        {
            //            Data = new DataDetailRQ
            //            {
            //                Reference = new[]
            //                {
            //                    new ReferenceBase { Type = "External", Value = "0RAD_Qb7IAe6o6inK0vMCZCep" }, 
            //                    new ReferenceBase { Type = "Amadeus", Value = "22225ZE6" }
            //                }
            //            }
            //        }
            //    }
            //};

            //using (var lrepositorio = new RepositoryWebApi("ServicioTarjetaCredito.json"))
            //{
            //    var lrespuesta = lrepositorio.UpdateT<CE_Request2<B2BWalletDetailRQ>, CE_Response1<B2BWalletDetailRS>>("B2BWalleDetail", param);

            //    // actualizando reserva
            //    var salida = lrespuesta.Resultado;
            //}
            //****** 


            //var param = new CE_Request2<B2BWalletDeleteRQ>
            //{
            //    Aplicacion = EnumAplicaciones.Interagencia,
            //    CodigoSeguimiento = "bchoy",
            //    Parametros = new B2BWalletDeleteRQ
            //    {
            //        Message = new MessageDeleteRQ
            //        {
            //            Data = new DataDeleteRQ
            //            {
            //                Reference = new[]
            //                {
            //                    new ReferenceBase { Type = "External", Value = "0RAD_Qb7IAe6o6inK0vMCZCep" }, 
            //                    new ReferenceBase { Type = "Amadeus", Value = "22225ZE6" }
            //                },
            //                Comment = "Prueba #2 de Nuevo Mundo"
            //            }
            //        }
            //    }
            //};

            //using (var lrepositorio = new RepositoryWebApi("ServicioTarjetaCredito.json"))
            //{
            //    var lrespuesta = lrepositorio.UpdateT<CE_Request2<B2BWalletDeleteRQ>, CE_Response1<B2BWalletDeleteRS>>("B2BWalletDelete", param);

            //    // actualizando reserva
            //    var salida = lrespuesta.Resultado;
            //}

            Console.Out.WriteLine("Finish Test_B2BWallet");
        }

        private static void Test_ObtenerReglaNoPermiteTransportador()
        {
            var param = new CE_Request2<RQ_ObtenerReglasEmision>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "SQLIGQ",
                CodigosEntorno = "PROD/NMO/WEB",
                Parametros = new RQ_ObtenerReglasEmision
                {
                    IdTransportador = "AA",
                    Pseudo = "V70C",
                    Gds = 1
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioReglas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_ObtenerReglasEmision>, CE_Response1<bool>>("ObtenerReglaNoPermiteTransportador", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerReglaNoPermiteTransportador");
        }

        private static void Test_ObtenerListaPermiteTransportador()
        {
            var param = new CE_Request2<CE_ReglaEmision>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "bchoy",
                CodigosEntorno = "DESA/NMO/SCL",
                Parametros = new CE_ReglaEmision
                {
                    IdTransportador = "LP"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioReglas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_ReglaEmision>, CE_Response1<CE_ReglaEmision[]>>("ObtenerListaPermiteTransportador", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerListaPermiteTransportador");
        }

        private static void Test_AddDeletePermiteTransportador()
        {
            var param = new CE_Request2<CE_ReglaEmision>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "bchoy",
                CodigosEntorno = "DESA/NMO/SCL",
                Parametros = new CE_ReglaEmision
                {
                    IdTransportador = "XX",
                    Descripcion = "prueba",
                    Pseudo = "XXX",
                    Gds = "1",
                    EsPropio = "SI"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioReglas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_ReglaEmision>, CE_Response1<bool>>("AnadirPermiteTransportador", param);

                // actualizando reserva
                var salida = lrespuesta.Resultado;

                // ---

                lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_ReglaEmision>, CE_Response1<bool>>("EliminarPermiteTransportador", param);

                // actualizando reserva
                salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_AddDeletePermiteTransportador");
        }

        #endregion

        private static void Test_ObtenerReservaCotizacionCompletarProcesarComision(string pnr,
                                                                                   string sessionToken)
        {
            CE_Reserva lreserva;
            CE_Cotizacion lcotizacion;

            var param1 = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "PROD/NMO/SCL",
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = pnr
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<CE_Reserva>>("ObtenerCompletar", param1);

                // actualizando reserva
                lreserva = lrespuesta.Resultado;
            }

            // =========
            // =========
            // PARAMETROS QUE SE RECIBIRAN DESDE EL CLIENTE

            lreserva.Aplicacion.IdGrupo = "3";
            //lreserva.Aplicacion.PseudoConsulta = "QF05";
            lreserva.Aplicacion.PseudoEmision = "QF05";

            lreserva.Cotizaciones.First(c => (c.NumeroPQ == 1)).Seleccionada = true;
            lreserva.Cotizaciones.First(c => (c.NumeroPQ == 1)).TipoTarifa = new CE_TipoTarifa
            {
                Tipo = EnumTipoTarifa.FV, Codigo = EnumCodigoTarifa.PL
            };

            lreserva.Facturacion = new CE_Facturacion
            {
                IdSucursal = 2,
                Punto = 120
            };

            lreserva.Cliente = new CE_Cliente
            {
                IdCliente = 23571,
                IdSubCodigo = 5,
                IdTipoCliente = "01"
            };

            lreserva.TipoFormaPagoComision = EnumTipoFormaPagoComision.CASH;

            // =========
            // =========

            var lsegmentos = lreserva.Itinerario.Segmentos;
            lsegmentos[0].Seleccionado = true;
            lsegmentos[1].Seleccionado = true;
            var lpasajeros = lreserva.Pasajeros;
            lpasajeros[0].Seleccionado = true;

            var param2 = new CE_Request3<RQ_ObtenerCotizaciones>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new RQ_ObtenerCotizaciones
                {
                    CodigoMoneda = "USD",
                    Segmentos = lsegmentos,
                    Pasajeros = lpasajeros,
                    Reemision = false
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioItinerario.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<RQ_ObtenerCotizaciones>, CE_Response3<CE_Cotizacion>>("ObtenerCotizacion", param2);

                // actualizando reserva
                lcotizacion = lrespuesta.Resultado;
            }


            //// copiando valores del airpirce al PQ de reemision
            //var iCotizacion = Array.FindLastIndex(lreserva.Cotizaciones, c => (c.Reemision ?? false));

            //lreserva.Cotizaciones.ElementAt(iCotizacion).Seleccionada = true;
            //lreserva.Cotizaciones.ElementAt(iCotizacion).CiudadDestino = lcotizacion.CiudadDestino;
            //lreserva.Cotizaciones.ElementAt(iCotizacion).Tarifas = lcotizacion.Tarifas;

            // =========
            // =========

            var param3 = new CE_Request2<CE_Reserva>
            {
                CodigosEntorno = "PROD/NMO/TBO",
                Parametros = lreserva
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioGeneral.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva>>("ProcesandoComisionesFees", param3);

                // actualizando reserva
                var salida = lrespuesta.Resultado;
            }

            Console.Out.WriteLine("Finish Test_ObtenerReservaCotizacionCompletarProcesarComision");
        }

        private static void Test_CrearCerrarSesion()
        {
            var param = new CE_Request4
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "V7C0",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy"
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioHerramientas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request4, CE_Response2>("CrearSesion", param);

                // actualizando reserva
                param.Sesion.Token = lrespuesta.Sesion.Token;
            }

            using (var lrepositorio = new RepositoryWebApi("ServicioHerramientas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request4, CE_Response2>("CerrarSesion", param);

                // actualizando reserva
                var lresultado = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_CrearCerrarSesion");
        }

        private static void Test_CambiarContexto(string sessionToken)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "V7C0",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken
                },
                Parametros = "QF05"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioHerramientas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response2>("CambiarContexto", param);

                // actualizando reserva
                var lresultado = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_CambiarContexto");
        }

        private static void Test_ObtenerCompletarReemitir(string pnr,
                                                          string sessionToken)
        {
            var param = new CE_Request3<CE_Reserva>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "BRUC3",
                CodigosEntorno = "DESA/NMO/SCL",
                Sesion = new CE_Session
                {
                    Pseudo = "V70C",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new CE_Reserva
                {
                    PNR = pnr,
                    Usuario = new CE_Usuario { IdVendedorPta = "Q32" },
                    Aplicacion = new CE_Aplicacion
                    {
                        CodigoMoneda = "USD",
                        PseudoEmision = "QF05",
                        IdGrupo = "3" // 3 -PL , 4 y 3 (IdGrupoAuxiliar) PV
                    },
                    Cliente = new CE_Cliente
                    {
                        IdCliente = 23571,
                        NombreCliente = "PRUEBA TRAVEL",
                        IdPromotor = "08",
                        IdSubCodigo = 5,
                        IdTipoCliente = "01",
                        IdCondicionPago = "CON",
                    },
                    Itinerario = new CE_Itinerario
                    {
                        Segmentos = new[]
                        {
                            new CE_Segmento
                            {
                                NumeroSegmento = 1,
                                Seleccionado = true
                            }, 
                            new CE_Segmento
                            {
                                NumeroSegmento = 2,
                                Seleccionado = true
                            }
                        }
                    },
                    Pasajeros = new[]
                    {
                        new CE_Pasajero
                        {
                            Seleccionado = true,
                            NumeroPasajero = "1.1",
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ADT" },
                            TipoDocumento = EnumTipoDocumento.DNI,
                            NumeroDocumento = "42314574",
                            Sexo = EnumSexo.M,
                            FechaNacimiento = "1978-10-08"
                        }
                    },
                    Cotizaciones = new[]
                    {
                        new CE_Cotizacion
                        {
                            Seleccionada = true,
                            NumeroPQ = 6,
                            TipoTarifa = new CE_TipoTarifa
                            {
                                Codigo = EnumCodigoTarifa.PL,
                                Tipo = EnumTipoTarifa.FV
                            },
                        } 
                    },
                    Boletos = new[] { 
                        new CE_Boleto
                        {
                            Seleccionado = true,
                            NumeroBoleto = "0015156417418"
                        } 
                    },
                    Facturacion = new CE_Facturacion
                    {
                        Pagos = new[]
                        {
                            new CE_FormaPago
                            {
                                TipoFormaPago = EnumTipoFormaPago.CASH
                            } 
                        }
                    }
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioReemision.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Reserva>, CE_Response3<CE_Boleto[]>>("ObtenerCompletarCotizarReemitir", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_ObtenerCompletarReemitir");
        }

        /*
        private static void TestReemitir(string sessionToken,
                                         string pnr)
        {
            var param = new CE_Request3<CE_Reserva>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "BRUC3",
                CodigosEntorno = "DESA/NMO/SCL",
                Sesion = new CE_Session
                {
                    Pseudo = "W7H7",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new CE_Reserva
                {
                    PNR = pnr,
                    EsReemision = true,
                    Usuario = new CE_Usuario { IdVendedorPta = "Q32" },
                    Aplicacion = new CE_Aplicacion
                    {
                        CodigoMoneda = "USD",
                        PsuedoEmision = "QF05",
                        IdGrupo = "3" // 3 -PL , 4 y 3 (IdGrupoAuxiliar) PV
                    },
                    Cliente = new CE_Cliente
                    {
                        IdCliente = 23571,
                        NombreCliente = "PRUEBA TRAVEL",
                        IdPromotor = "08",
                        IdSubCodigo = 5,
                        IdTipoCliente = "01",
                        IdCondicionPago = "CON",
                    },
                    Itinerario = new CE_Itinerario
                    {
                        Segmentos = new[]
                        {
                            new CE_Segmento { Seleccionado = true, NumeroSegmento = 1 }, 
                            new CE_Segmento { Seleccionado = true, NumeroSegmento = 2 }
                        }
                    },
                    Pasajeros = new[]
                    {
                        new CE_Pasajero
                        {
                            Seleccionado = true,
                            NumeroPasajero = "1.1",
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ADT" },
                        }
                    },
                    Cotizaciones = new[]
                    {
                        new CE_Cotizacion
                        {
                            Seleccionada = true,
                            Reemision = true,
                            NumeroPQ = 2,
                            LineasValidadoras = new []
                            {
                                new CE_Aerolinea { Seleccionada = true, CodigoAerolinea = "AA" } 
                            },
                            TipoTarifa = new CE_TipoTarifa
                            {
                                Codigo = EnumCodigoTarifa.PL,
                                Tipo = EnumTipoTarifa.FV
                            },
                            Tarifas = new []
                            {
                                new CE_Tarifa
                                {
                                    ComisionPta = new CE_ComisionPta { PorcentajeComisionKP = 1 }
                                }, 
                            }
                        } 
                    },
                    Boletos = new[] 
                    { 
                        new CE_Boleto { Seleccionado = true, NumeroBoleto = "0015156493565" } 
                    },
                    Facturacion = new CE_Facturacion
                    {
                        Pagos = new[]
                        {
                            new CE_FormaPago { TipoFormaPago = EnumTipoFormaPago.CASH }
                            //new CE_FormaPago
                            //{
                            //    TipoFormaPago = EnumTipoFormaPago.CARD,
                            //    CodigoMonedaPago = "USD",
                            //    Medio = "AX",
                            //    Tarjeta = new CE_Tarjeta
                            //    {
                            //        Numero = "376644556677889",
                            //        FechaVencimiento = "2021-11"
                            //    }
                            //}
                        }
                    }
                }
            };

            var lgetNewPQ = false;

            if (lgetNewPQ)
            {
                using (var lrepositorio = new RepositoryWebApi("ServicioReemision.json"))
                {
                    var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Reserva>, CE_Response2>("GetNewPQ", param);

                    // actualizando reserva
                    var salida = lrespuesta;
                }
            }

            using (var lrepositorio = new RepositoryWebApi("ServicioReemision.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Reserva>, CE_Response3<CE_Boleto[]>>("TestReemitir", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish Test_ObtenerCompletarReemitir");
        }
        */

        /*
        private static void EjecutarModuloComercial(string pnr,
                                                    string sessionToken)
        {
            var param = new CE_Request3<CE_Reserva>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "BRUC3",
                CodigosEntorno = "DESA/NMO/SCL",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new CE_Reserva
                {
                    PNR = pnr,
                    EsReemision = true,
                    Usuario = new CE_Usuario { IdVendedorPta = "Q32" },
                    Aplicacion = new CE_Aplicacion
                    {
                        CodigoMoneda = "USD",
                        PsuedoEmision = "QF05",
                        IdGrupo = "3" // 3 -PL , 4 y 3 (IdGrupoAuxiliar) PV
                    },
                    Cliente = new CE_Cliente
                    {
                        IdCliente = 23571,
                        NombreCliente = "PRUEBA TRAVEL",
                        IdPromotor = "08",
                        IdSubCodigo = 5,
                        IdTipoCliente = "01",
                        IdCondicionPago = "CON",
                    },
                    Itinerario = new CE_Itinerario
                    {
                        Segmentos = new[]
                        {
                            new CE_Segmento { Seleccionado = true, NumeroSegmento = 1 }, 
                            new CE_Segmento { Seleccionado = true, NumeroSegmento = 2 }
                        }
                    },
                    Pasajeros = new[]
                    {
                        new CE_Pasajero
                        {
                            Seleccionado = true,
                            NumeroPasajero = "1.1",
                            TipoPasajero = new CE_TipoPasajero { IdTipoPasajero = "ADT" },
                        }
                    },
                    Cotizaciones = new[]
                    {
                        new CE_Cotizacion
                        {
                            Seleccionada = true,
                            LineasValidadoras = new []
                            {
                                new CE_Aerolinea { Seleccionada = true, CodigoAerolinea = "AA" } 
                            },
                            TipoTarifa = new CE_TipoTarifa
                            {
                                Codigo = EnumCodigoTarifa.PL,
                                Tipo = EnumTipoTarifa.FV
                            }
                        } 
                    },
                    Facturacion = new CE_Facturacion
                    {
                        IdSucursal = null
                    }
                }
            };

            var lgetNewPQ = false;

            using (var lrepositorio = new RepositoryWebApi("ServicioReemision.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Reserva>, CE_Response3<CE_Reserva>>("EjecutarModuloComercial", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish EjecutarModuloComercial");
        }
        */

        /*
        private static void ConfirmandoPQ(string sessionToken,
                                          string pnr)
        {
            var param = new CE_Request3<CE_Reserva>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "BRUC3",
                CodigosEntorno = "DESA/NMO/SCL",
                Sesion = new CE_Session
                {
                    Pseudo = "QF05",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken,
                },
                Parametros = new CE_Reserva
                {
                    PNR = pnr,
                    EmitirEMDPorCambioTarifa = true,
                    Cotizaciones = new[]
                    {
                        new CE_Cotizacion
                        {
                            Seleccionada = true,
                            Reemision = true,
                            NumeroPQ = 3,
                            TipoTarifa = new CE_TipoTarifa
                            {
                                Codigo = EnumCodigoTarifa.PL,
                                Tipo = EnumTipoTarifa.FV
                            }
                        } 
                    },
                    Facturacion = new CE_Facturacion
                    {
                        Pagos = new []
                        {
                            new CE_FormaPago
                            {
                                TipoFormaPago = EnumTipoFormaPago.CASH
                            }
                        }
                    }
                }
            };

            var lgetNewPQ = false;

            using (var lrepositorio = new RepositoryWebApi("ServicioReemision.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<CE_Reserva>, CE_Response2>("ConfirmarPQ", param);

                // actualizando reserva
                var salida = lrespuesta;
            }

            Console.Out.WriteLine("Finish ConfirmandoPQ");
        }
        */

        private static void TripleadoEn(string sessionToken)
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "brucechoy",
                Sesion = new CE_Session
                {
                    Pseudo = "V7C0",
                    ConversationId = "brucechoy",
                    SignatureUser = "brucechoy",
                    Token = sessionToken
                },
                Parametros = "QF05"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioHerramientas.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Response3<bool>>("TripleadoEn", param);

                // actualizando reserva
                var lresultado = lrespuesta;
            }

            Console.Out.WriteLine("Finish TripleadoEn");
        }

        /*
        private static void ObtenerDatosTarjetasSolicitud()
        {
            var param = new CE_Request2<RQ_TarjetaCreditoSolicitud>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "PROD/AWS/WEB",
                CodigoSeguimiento = "brucechoy",
                Parametros = new RQ_TarjetaCreditoSolicitud
                {
                     CodigoSolicitud = 364492,
                     PNR = "QUWORS",
                     IdCliente = 53791
                }
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioSolicitud.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<RQ_TarjetaCreditoSolicitud>, CE_Response1<CE_FormaPago>>("ObtenerDatosTarjetaSolicitud", param);

                // actualizando reserva
                var lresultado = lrespuesta;
            }

            Console.Out.WriteLine("Finish ObtenerDatosTarjetasSolicitus");
        }
        */

        /*
        private static void ObtenerDatosTarjetasSolicitudSoap()
        {
            var s = (new ServicioSolicitud.ServicioSolicitud()).ObtenerDatosTarjetaSolicitud(new CE_Request2OfRQ_TarjetaCreditoSolicitud
            {
                Aplicacion = ServicioSolicitud.EnumAplicaciones.SistemaCentral,
                CodigoSeguimiento = "LIMPE2390",
                CodigosEntorno = "PROD/AWS/SCL",
                Parametros = new ServicioSolicitud.RQ_TarjetaCreditoSolicitud
                {
                    PNR = "QXVCE8",
                    IdCliente = 10265,
                    CodigoSolicitud = 364752
                }
            });

            Console.Out.WriteLine("Finish ObtenerDatosTarjetasSolicitudSoap");
        }
        */

        // ##########################################
        // ##########################################

        /*
        private static void Test_Facturacion()
        {
            var linterface = new CE_Interface
            {
                Cabecera = JsonHelper.JsonDeserialize<CE_InterfaceGeneral>(false, @"d:\lcabecera.json"),
                Detalle = JsonHelper.JsonDeserialize<CE_InterfaceDetalle[]>(false, @"d:\llistaDetalles.json")
            };

            // contruyendo conceptos a evaluar
            var lcriterios = new CE_Request2<CE_Interface>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigoSeguimiento = "IKXFLB", // *** hasta que se genere un token del lado del servicio ***
                CodigosEntorno = "PROD/NMO/SCL",
                Parametros = linterface
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioFacturacion.json"))
            {
                // ejecutando servicio
                var lresultado = lrepositorio.UpdateT<CE_Request2<CE_Interface>, CE_Estatus>("ProcesarFacturacion", lcriterios);
            }
        }
        */

        public static void PoseePermisoParaRemitir()
        {
            var param = new CE_Request2<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                CodigosEntorno = "PROD/AWS/WEB",
                CodigoSeguimiento = "brucechoy",
                Parametros = "10796"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioSolicitud.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request2<string>, CE_Response1<bool>>("PoseePermisoParaRemitir", param);

                // actualizando reserva
                var lresultado = lrespuesta;
            }

            Console.Out.WriteLine("Finish TripleadoEn");
        }

        public static void PruebaAmadeus()
        {
            var param = new CE_Request3<string>
            {
                Aplicacion = EnumAplicaciones.Interagencia,
                //CodigosEntorno = "PROD/AWS/WEB",
                CodigoSeguimiento = "brucechoy++",
                Parametros = "khjkX"
            };

            using (var lrepositorio = new RepositoryWebApi("ServicioAmadeus.json"))
            {
                var lrespuesta = lrepositorio.UpdateT<CE_Request3<string>, CE_Estatus>("Ejecutar", param);

                // actualizando reserva
                var lresultado = lrespuesta;
            }

            Console.Out.WriteLine("Prueba de Amadeus");
        }

        public static void Test_eDestinos()
        {
            // para AMADEUS (eDestinos)
            var _PROCESO = new
            {
                PseudoEmision = "LIMPE21KN",    // LIMPE21KN / LIMPE2390
                TipoGds = EnumTipoGds.Amadeus,
                IdCliente = 59948,
                DQB = new []
                {
                    "O3IZP3","OJOQAK","OLJETO","OM4ITX","OS2AY8","OSCUJF","OSU3GJ","OVC5AG","OVMPBS","OW9L98","OWVC7I","OXEQNJ","OZYWI6",
                    "P2MSUU","P2PXP4","P36RZA","P5T9UQ","P6C5VK","P6MHHV","P6OHBA","P7FYWR","P7T5HE","P82SPL","P84QWT","P8BQR7","P8PAUJ",
                    "P99BV2","P9JVXS","P9OOPB","PA3CCX","PAYAK9","PAZKMC","PC3QU3","PCZZVS","PDF2GP","PDQGOP","PE4A5C","PECEWO","PEDRZV",
                    "PEUN72","PH77PM","PHSOST","PJSGTC","PJUYFV","PKBWP7","PLMA9T","PN2T4D","POUP3G","PQ3844","PQFRN5","PQJV2E","PR3SGH",
                    "PRH6DU","PRO3YS","PRU5LR","PSIEAB","PTQVWL","PV2BGC","PVB4EC","PVJ6ZI","PW3YJ2","PXAAVG","PXL35R","PXSI6Q","PZ4JA8",
                    "PZDY28","Q2NWM2","Q4RA6H","Q4W5F6","Q5B2PW","Q5S4WW","Q69KUR","Q6AHDE","Q6PTI6","Q6S2PG","Q72KZQ","Q766EJ","Q7MST6",
                    "Q894WW","Q8BA87","Q9DBLG","QAH3YW","QAM6BV","QB5IR4","QBHTV2","QD3BF9","QDBZJQ","QEPO4J","QFDZ64","QFZQ4P","QI5BA9",
                    "QJC85Z","R8XN2C","RBKFS7","RDK77C","RT39QY","RTCTR5","RTHPVS","RVWKQK","S55TEA","S5HMFZ","S5HXMO","S5XZYG","S6HZID",
                    "S7O58L","S844UO","S8GOD8","S8MCIF","S9B4F7","S9DUOV","S9W8SC","SCSLEK","SCZPVG","SFNUZT","SFZ3SN","SH6KP3","SJ5FDE",
                    "SJBIKX","SJP96M","SJVXZ3","SK8PTC","SKB2WM","SKPZWC","SLACVW","SLHYTR","SLV5SV","SMJDM4","SMJGHG","SMNHZU","SOKAOB",
                    "SOT5J9","SPEPTC","SPEUUZ","SPJYHX","SR8CRC","SRJRET","SRMGQS","SSDA7W","ST4MLL","SUPXZK","SVBM34","SW27NE","SXGJKV",
                    "T3GO5Z","TNWC5X","TS44A6","TS58ET","TXWFUJ","TZFPKQ","TZG3GR","TZIPJV","TZJYNO","U2YORD","U33TJC","U3R6MJ","U3RSZP",
                    "U3YBSF","U4GSWD","U58Y64","U5HDIB","U6SAO8","U7QPO7","UBJCC7","UBLCKV","UBUYE6","UBV59D","UC6Q7D","UCFEHQ","UEQT5C",
                    "UEREJ6","UHP8EY","UHWL9C","UI5KP2","UIO8TD","UJV259","UJYJG7","UK2MDB","UK2OON","UK8O32","UNBZPQ","UNJ9QK","UNZHRU",
                    "UOGXQ7","UOLE3A","UPVRIH","UQI7TP","URWHM2","UT3NKA","UU6ZMN","UY9KTJ","UYUJJ6","UZ5MFT","UZJVUP","V3JUKO","V5LTGN",
                    "V5NHUL","V6G8F8","V7CMWA","V8CB4V","V8N34U","V9JKTF","VC6NFC","VCJ5HD","VFSK32","VGFQKB","VGQASC"
                }
            } ;

            // "SQNU23" - PRIVADA QUE DEVUELVE PAX *F*CM -- falla linea validadora y no tiene ADT para CM en PV

            /*
            // para SABRE
            var _PROCESO = new
            {
                PseudoEmision = "O0ZJ",
                TipoGds = EnumTipoGds.Sabre,
                IdCliente = 59948,
                DQB = new[]
                {
                    "CCHMEA", "CXWBGA", "FEBUFN", "FHIOHP", "GOCKKW", "GZICIP", "HOZRJU", "HSGBDM", "JJFSSH", 
                    "JZCSTY", "KKLBQQ", "KPHGHA", "LCFZAA", "LDWHEM", "LMEBTF", "MTXQNZ", "MUWIHE", "OBIFHP", 
                    "QNLZZZ", "QPDISP", "QWGUBR"
                }
            };
            */

            var resultadoOK = new StringBuilder();
            var resultadoBAD = new StringBuilder();

            // recorriendo lista de pnrs
            for (var li = 0; li < _PROCESO.DQB.Length; li++)
            {
                // construyendo request
                var lrequest = new CE_Request2<CE_Reserva>
                {
                    Aplicacion = EnumAplicaciones.Pta,
                    CodigosEntorno = "PROD/NMO/SCL",
                    CodigoSeguimiento = "BCHOY-" + _PROCESO.DQB[li],
                    Parametros = new CE_Reserva
                    {
                        PNR = _PROCESO.DQB[li],
                        Aplicacion = new CE_Aplicacion
                        {
                            PseudoEmision = _PROCESO.PseudoEmision,
                            TipoGds = _PROCESO.TipoGds,
                            IdGrupo = "3",
                            IdGrupoAuxiliar = "3"
                        },
                        Cliente = new CE_Cliente
                        {
                            IdCliente = _PROCESO.IdCliente
                        },
                        Facturacion = new CE_Facturacion
                        {
			                IdSucursal = 2
                        }
                    }
                };

                try
                {
                    using (var lrepositorio = new RepositoryWebApi("ServicioClienteExterno.json"))
                    {
                        // ejecutando servicio
                        var lrespuesta = lrepositorio.UpdateT<CE_Request2<CE_Reserva>, CE_Response1<CE_Reserva[]>>("ProcesarBoletosFull", lrequest);

                        if (lrespuesta.Estatus.Ok)
                        {
                            // guardando resultado
                            JsonHelper.JsonSerializerExt(lrespuesta, false, string.Format(@"C:\Temp\OK_{0}.json", _PROCESO.DQB[li]), false);

                            lrespuesta.Resultado.ToList().ForEach(e =>
                            {
                                var lruta = lrespuesta.Resultado[0].Itinerario.Segmentos
                                    .Where(s1 => e.Boletos[0].Segmentos.Any(s2 => s2.NumeroSegmento .Equals(s1.NumeroSegmento)))
                                    .Select(s1 => string.Format("{0}-{1}", s1.CiudadSalida.IdCiudad, s1.CiudadLlegada.IdCiudad))
                                    .Pipe(s1 => string.Join("-", s1));

                                var lconceptos = e.Cotizaciones[0].Tarifas[0].ComisionPta.ConceptosEvaluados
                                    .Select(c => string.Format("ID='{0}' CONCEPTO='{1}' VALOR='{2}'", c.IdConcepto, c.Concepto, c.Valor))
                                    .Pipe(c => string.Join(" * ", c));

                                resultadoOK.AppendLine(
                                        string.Format(
                                            "{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}\t{13}", 
                                            e.PNR, 
                                            e.Boletos[0].NumeroBoleto, 
                                            e.Boletos[0].NumeroBoleto.Substring(3),
                                            lruta,
                                            e.Cotizaciones[0].CiudadDestino.IdCiudad,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.NumeroTarifario, 
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.NumeroComision,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.PorcentajeComisionKP,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.PorcentajeAgencia,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.PorcentajeFactorMeta,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.PorcentajeOver,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.PorcentajeOverNaceCancelado,
                                            e.Cotizaciones[0].Tarifas[0].ComisionPta.PorcentajeFfactorMetaYQ,
                                            lconceptos
                                        )
                                    );
                            });

                        }
                        else
                        {
                            // guardando resultado
                            JsonHelper.JsonSerializerExt(lrespuesta, false, string.Format(@"C:\Temp\BAD_{0}.json", _PROCESO.DQB[li]), false);

                            lrespuesta.Estatus.Mensajes.ToList().ForEach(m =>
                            {
                                resultadoBAD.AppendLine(
                                        string.Format(
                                            "{0}\t{1}\t{2}\t{3}",
                                            _PROCESO.DQB[li],
                                            lrespuesta.Estatus.Ok,
                                            m.Tipo,
                                            m.Valor)
                                    );
                            });
                        }

                        Console.Out.WriteLine("{0:T} [{1}/{2}] - PNR '{3}' - Estado Proceso: '{4}'", DateTime.Now, li, _PROCESO.DQB.Length, _PROCESO.DQB[li], lrespuesta.Estatus.Ok);
                    }

                }
                catch(Exception ex)
                {
                    Console.Out.WriteLine("PNR '{0}' - Error: '{1}'", _PROCESO.DQB[li], ex.Message);
                }
            }

            File.WriteAllText(@"C:\Temp\_GDS_OK.txt", resultadoOK.ToString());
            File.WriteAllText(@"C:\Temp\_GDS_BAD.txt", resultadoBAD.ToString());

            Console.Out.WriteLine("Prueba de Test_eDestinos");
        }

        private static void Main(string[] args)
        {
            //var lsessionToken = @"Shared/IDL:IceSess\/SessMgr:1\.0.IDL/Common/!ICESMS\/RESD!ICESMSLB\/RES.LB!-3160338233368010619!142387!0!2!E2E-1";

            //Test_ObtenerItinerarioKIU("XPIRLP");
            //Test_B2BWallet();
            //PruebaAmadeus();

            Test_eDestinos();

            Console.ReadKey();
        }
    }
}
