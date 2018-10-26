using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Air_SellFromRecommendation.Request;
using AmadeusLib.Servicios.Air_SellFromRecommendation.Response;

namespace AmadeusLib.Air
{
    public sealed class AirSellFromRecommendation : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_AirSellFromRecommendation;

        private static readonly object _sync_AirSellFromRecommendation = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public AirSellFromRecommendation(EnumAplicaciones application,
                                         string codigoSeguimiento,
                                         bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        {
        }


        ~AirSellFromRecommendation()
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
        /// <param name="response"></param>
        /// <param name="estatus"></param>
        /// <returns></returns>
        private void ProcessResult(Air_SellFromRecommendationReply response, 
                                   out CE_Estatus estatus)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(ref CE_Session session)
        {
            Air_SellFromRecommendation lsellFromRecommendationRequest = null;
            Air_SellFromRecommendationReply lsellFromRecommendationResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                var linputItinerary = new List<string>();
                var linputItineraryDetailsEsRetorno = true;
                var lretorno = false;

                var litineraryDetails = new List<Air_SellFromRecommendationItineraryDetails>();

                foreach (var lcurrentItinerary in linputItinerary) 
                {
                    if (linputItineraryDetailsEsRetorno) // Si es retorno
                    {
                        if (!lretorno) 
                        {
                            //TODO: Preguntar como es el flujo Correcto
                            lretorno = true; // Al ingresar por primera vez se cambia a True
                        }
                    }

                    var lboardPointDetails = new Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationBoardPointDetails
                    {
                        trueLocationId = null //DepartureAirport
                    };

                    var lflightDate = new Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightDate
                    {
                        departureDate = null //Fecha auxiliar
                    };

                    var loffPointDetails = new Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationOffpointDetails
                    {
                        trueLocationId = null// Arrival Airport
                    };

                    var lcompanyDetail = new Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationCompanyDetails
                    {
                        marketingCompany = null //Marketing Airline
                    };

                    var lflightIdentification = new Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformationFlightIdentification
                    {
                        flightNumber = null, // flightNumber
                        bookingClass = null  // MarketingCabin
                    };

                    var ltravelProductInformation = new Air_SellFromRecommendationItineraryDetailsSegmentInformationTravelProductInformation
                    {
                        boardPointDetails = lboardPointDetails,
                        flightDate = lflightDate,
                        offpointDetails = loffPointDetails
                    };

                    var lrelatedProductInformation = new Air_SellFromRecommendationItineraryDetailsSegmentInformationRelatedproductInformation
                    {
                        quantity = 0, // Cantidad
                        statusCode = new[] { "NN" }
                    };

                    var lnewItineraryDetails = new Air_SellFromRecommendationItineraryDetails
                    {
                        segmentInformation = new[] 
                        {
                            new Air_SellFromRecommendationItineraryDetailsSegmentInformation
                            {
                                relatedproductInformation = lrelatedProductInformation,
                                travelProductInformation = ltravelProductInformation
                            }
                        }
                    };

                    litineraryDetails.Add(lnewItineraryDetails);
                }

                var lmessageActionActionDetails = new Air_SellFromRecommendationMessageActionDetails
                {
                    messageFunctionDetails = new Air_SellFromRecommendationMessageActionDetailsMessageFunctionDetails
                    {
                        messageFunction = "183",
                        additionalMessageFunction = new[] { "M1" }
                    }
                };

                var lmessageDetailsMessage = new Air_SellFromRecommendationItineraryDetailsMessage
                {
                    messageFunctionDetails = new Air_SellFromRecommendationItineraryDetailsMessageMessageFunctionDetails
                    {
                        messageFunction = "183"
                    }
                };

                // construyendo request
                lsellFromRecommendationRequest = new Air_SellFromRecommendation
                {
                    messageActionDetails = lmessageActionActionDetails,
                    itineraryDetails = litineraryDetails.ToArray()
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lsellFromRecommendationRequest, session }, CodigoSeguimiento);

                lock (_sync_AirSellFromRecommendation)
                {
                    lsellFromRecommendationResponse = Execute<Air_SellFromRecommendation, Air_SellFromRecommendationReply>(
                        WebServiceActionHeader4.AirSellFromRecommendation, ((TransactionType)session.AmadeusTransactionType), 
                        lsellFromRecommendationRequest, 
                        ref session, 
                        ref _serialiazer_AirSellFromRecommendation);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lsellFromRecommendationResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lsellFromRecommendationResponse, out lrespuesta);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, lsellFromRecommendationRequest, lsellFromRecommendationResponse }, CodigoSeguimiento);

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
