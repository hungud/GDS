using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Fare_InstantTravelBoardSearch.Request;

// alias
using Fare_InstantTravelBoardSearchReply2 = AmadeusLib.Servicios.Fare_InstantTravelBoardSearch.Response.Fare_InstantTravelBoardSearchReply;

namespace AmadeusLib.Fare
{
    public sealed class FareInstantTravelBoardSearch : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_FareInstantTravelBoardSearch;

        private static readonly object _sync_FareInstantTravelBoardSearch = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public FareInstantTravelBoardSearch(EnumAplicaciones? application,
                                            string codigoSeguimiento,
                                            bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }

        ~FareInstantTravelBoardSearch()
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
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(ref CE_Session session, string fecha)
        {
            Fare_InstantTravelBoardSearch lfareInstantTravelBoardRequest = null;
            Fare_InstantTravelBoardSearchReply2 lfareInstantTravelBoardResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                lfareInstantTravelBoardRequest = new Fare_InstantTravelBoardSearch
                {
                    numberOfUnit = new[] 
                    {
                        new NumberOfUnitDetailsType_270113C
                        {
                            numberOfUnits = "1",
                            typeOfUnit = "PX"
                        }
                        //,
                        //new NumberOfUnitDetailsType_270113C
                        //{
                        //    numberOfUnits = "50",
                        //    typeOfUnit = "RC"
                        //}
                    },
                    paxReference = new[] 
                    {
                        new TravellerReferenceInformationType
                        {
                            ptc = new[] { "IIT", "PFA", "NEG" },
                            traveller = new[] {
                                new TravellerDetailsType
                                {
                                    @ref = "1"
                                }
                               
                             
                            }
                        }
                        //,
                        //new TravellerReferenceInformationType
                        //{
                        //    ptc = new[] { "INF" },
                        //    traveller = new [] {
                        //        new TravellerDetailsType 
                        //        {
                        //            @ref = "1",
                        //            infantIndicator = "1"
                        //        }
                        //    }
                        //}
                    },
                    fareOptions = new Fare_InstantTravelBoardSearchFareOptions
                    {
                        pricingTickInfo = new PricingTicketingDetailsType
                        {
                            pricingTicketing = new[] { "RP", "RU" }
                        }
                    },
                    itinerary = new[] 
                    {
                        new Fare_InstantTravelBoardSearchItinerary
                        {
                            requestedSegmentRef = new OriginAndDestinationRequestType
                            {
                                segRef = "1"
                            },
                            departureLocalization = new DepartureLocationType
                            {
                                departurePoint = new ArrivalLocationDetailsType_120834C
                                {
                                    locationId = "LIM"
                                }
                            },
                            arrivalLocalization = new ArrivalLocalizationType
                            {
                                arrivalPointDetails = new ArrivalLocationDetailsType
                                {
                                    locationId = "MIA",
                                }
                            },
                            timeDetails = new DateAndTimeInformationType_181295S
                            {
                                firstDateTimeDetail = new DateAndTimeDetailsTypeI
                                {
                                    date = "120918"
                                }
                            }
                        },
                        new Fare_InstantTravelBoardSearchItinerary
                        {
                            requestedSegmentRef = new OriginAndDestinationRequestType
                            {
                                segRef = "2"
                            },
                            departureLocalization = new DepartureLocationType
                            {
                                departurePoint = new ArrivalLocationDetailsType_120834C
                                {
                                    locationId = "MIA"
                                }
                            },
                            arrivalLocalization = new ArrivalLocalizationType
                            {
                                arrivalPointDetails = new ArrivalLocationDetailsType
                                {
                                    locationId = "LIM"
                                }
                            },
                            timeDetails = new DateAndTimeInformationType_181295S
                            {
                                firstDateTimeDetail = new DateAndTimeDetailsTypeI
                                {
                                    date = "121018"
                                }
                            }
                        }
                    },
                    officeIdDetails = new[] 
                    {
                        new Fare_InstantTravelBoardSearchOfficeIdDetails
                        {
                            officeIdInformation = new UserIdentificationType
                            {
                              officeIdentification = new OriginatorIdentificationDetailsTypeI
                                {
                                    agentSignin = "LIMPE31ZS"
                                }
                            }
                        }
                    }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lfareInstantTravelBoardRequest, session }, CodigoSeguimiento);

                lock (_sync_FareInstantTravelBoardSearch)
                {
                    // procesando solicitud
                    lfareInstantTravelBoardResponse = Execute<Fare_InstantTravelBoardSearch, Fare_InstantTravelBoardSearchReply2>(
                        WebServiceActionHeader4.FareInstantTravelBoardSearch,
                        ((TransactionType)session.AmadeusTransactionType),
                        lfareInstantTravelBoardRequest,
                        ref session,
                        ref _serialiazer_FareInstantTravelBoardSearch);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lfareInstantTravelBoardResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lfareInstantTravelBoardResponse, out lrespuesta);
                lrespuesta = null;

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lfareInstantTravelBoardRequest, lfareInstantTravelBoardResponse }, CodigoSeguimiento);

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
}
