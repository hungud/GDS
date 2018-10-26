using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Fare_MasterPricerTravelBoardSearch.Request;

// alias
using Fare_MasterPricerTravelBoardSearchReply2 = AmadeusLib.Servicios.Fare_MasterPricerTravelBoardSearch.Response.Fare_MasterPricerTravelBoardSearchReply;

namespace AmadeusLib.Fare
{
    // =============================
    // clases

    #region "clases"

    public class PassengerType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Passenger
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public PassengerType Type { get; set; }
        public bool Selected { get; set; }

        public bool EsInfante
        {
            get { return Type.Id.Equals("INF"); }
        }
    }

    public class PassengerSearch
    {
        public List<Passenger> Passengers { get; set; }
    }

    public class RQ_MasterPricerTravelBoard
    {
        public Passenger[] Passengers { get; set; }

        public bool EsFaceValue { get; set; }

        public List<string> LineasAereasBaneadas { get; set; }
    }

    public sealed class FareMasterPricerTravelBoardSearch : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_FareMasterPricerTravelBoardSearch;

        private static readonly object _sync_FareMasterPricerTravelBoardSearch = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public FareMasterPricerTravelBoardSearch(EnumAplicaciones? application,
                                                 string codigoSeguimiento,
                                                 bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~FareMasterPricerTravelBoardSearch()
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
        /// <returns></returns>
        public RQ_MasterPricerTravelBoard BuildRequest()
        {
            return new RQ_MasterPricerTravelBoard
            {
                Passengers = new[] 
                {
                    new Passenger
                    {
                        Id = "1.1",
                        Nombre = "Flavio Goni",
                        Type = new PassengerType
                        {
                            Id = "ADT",
                            Name = "ADULTO"
                        },
                        Selected = true
                    },

                    new Passenger
                    {
                        Id = "2.1",
                        Nombre = "Luis Luza",
                        Type = new PassengerType
                        {
                            Id = "ADT",
                            Name = "ADULTO"
                        },
                        Selected = false
                    }
                },
                EsFaceValue = false
            };
        }

        private TravellerDetailsType[] buildTravellers(Passenger[] passengers)
        {
            var ltravellersDetails = new List<TravellerDetailsType>();
            var ltravellerReferenceIT = new List<TravellerReferenceInformationType>();

            ltravellerReferenceIT.Add(new TravellerReferenceInformationType
            {
            });

            //var lpassengers = passengers.Where(s => !s.EsInfante).ToList();

            //Agregamos todos los pasajeros que no sean adultos
            var lcontador = 1;
            /*
            lpassengers.ForEach(lcurrentPassenger =>
            {
                ltravellersDetails.Add(new TravellerDetailsType { @ref = Convert.ToString(lcontador) });
                lcontador++;
            });
            */
            //Si existen infantes los agregamos
            /*var lpassengersInfantes = passengers.Where(s => s.EsInfante).ToList();
            if (lpassengersInfantes.Any()) 
            {
                ltravellersDetails.Add(new TravellerDetailsType { @ref = Convert.ToString(lcontador), infantIndicator = "1" });
            }
            */

            var lcantidadInfantes = passengers.Where(s => s.EsInfante).Count();
            var lcantidadAdultos = passengers.Count() - lcantidadInfantes;

            var lcontadorAuxiliar = 1;

            passengers
            .ToList()
            .ForEach(currentPassenger =>
            {
                var ltravellerDetail = new TravellerDetailsType();

                if (currentPassenger.EsInfante)
                {
                    ltravellerDetail.infantIndicator = "1";
                    ltravellerDetail.@ref = Convert.ToString(lcontadorAuxiliar);
                }
                else
                {
                    ltravellerDetail.@ref = Convert.ToString(lcontadorAuxiliar);
                }

                lcontadorAuxiliar++;

                ltravellersDetails.Add(ltravellerDetail);
            });

            return ltravellersDetails.ToArray();
        }

        private TravellerReferenceInformationType[] buildPaxReference(Passenger[] passengers,
                                                                      bool esFaceValue)
        {
            var typePassenger = passengers.GroupBy(s => new { s.Type.Id });

            var ltravellerReferenceITs = new List<TravellerReferenceInformationType>();

            foreach (Passenger passenger in passengers)
            {
                ltravellerReferenceITs.Add(new TravellerReferenceInformationType
                {
                    ptc = BuildPTCs(passenger, esFaceValue),
                    traveller = null
                });
            }

            return ltravellerReferenceITs.ToArray();
        }

        private string[] BuildPTCs(Passenger passenger, bool esFaceValue)
        {
            var lptcs = new List<string>();

            if (esFaceValue)
            {
                lptcs.Add(passenger.Type.Id.Equals("CNN") ? "CH" : passenger.Type.Id);

            }
            else
            {
                if (passenger.Type.Id.Equals("CNN"))
                {
                    lptcs.Add("INN");
                    lptcs.Add(passenger.Type.Id.Equals("CNN") ? "CH" : passenger.Type.Id);
                }
                else if (passenger.Type.Id.Equals("INF"))
                {
                    lptcs.Add("ITF");
                    lptcs.Add(passenger.Type.Id.Equals("CNN") ? "CH" : passenger.Type.Id);
                }
                else
                {
                    lptcs.Add(passenger.Type.Id.Equals("CNN") ? "CH" : passenger.Type.Id);
                }
            }

            return lptcs.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rqMasterPricer"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(RQ_MasterPricerTravelBoard rqMasterPricer, 
                                  ref CE_Session session)
        {
            Fare_MasterPricerTravelBoardSearch lfareMasterPricerTravelBoardSearchRequest = null;
            Fare_MasterPricerTravelBoardSearchReply2 lfareMasterPricerTravelBoardSearchReplyResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                var lrefPax = 1;

                var lpaxReference = new[]
                {
                    new TravellerReferenceInformationType
                    {
                        ptc = null,
                        traveller = buildTravellers(rqMasterPricer.Passengers)
                    }
                };

                var litinerary = new Fare_MasterPricerTravelBoardSearchItinerary[]
                {
                };

                var lnumberOfUnit = new NumberOfUnitDetailsType_191580C[]
                {
                };

                var lfareOptions = new Fare_MasterPricerTravelBoardSearchFareOptions
                {
                };

                var ltravelFlightInfo = new TravelFlightInformationType_165052S
                {
                };

                lfareMasterPricerTravelBoardSearchRequest = new Fare_MasterPricerTravelBoardSearch
                {
                    numberOfUnit = lnumberOfUnit,
                    itinerary = litinerary,
                    paxReference = lpaxReference,
                    fareOptions = lfareOptions,
                    travelFlightInfo = ltravelFlightInfo
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lfareMasterPricerTravelBoardSearchRequest, session }, CodigoSeguimiento);

                lock (_sync_FareMasterPricerTravelBoardSearch)
                {
                    // procesando solicitud
                    lfareMasterPricerTravelBoardSearchReplyResponse = Execute<Fare_MasterPricerTravelBoardSearch, Fare_MasterPricerTravelBoardSearchReply2>(
                        WebServiceActionHeader4.FareMasterPricerTravelBoardSearch,
                        ((TransactionType) session.AmadeusTransactionType),
                        lfareMasterPricerTravelBoardSearchRequest, 
                        ref session,
                        ref _serialiazer_FareMasterPricerTravelBoardSearch);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lfareMasterPricerTravelBoardSearchReplyResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lmasterPricerResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo("ERROR ejecutando '.Execute'", ex, new { MuteErrors, lfareMasterPricerTravelBoardSearchRequest, lfareMasterPricerTravelBoardSearchReplyResponse }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
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

    #endregion
}
