using System;
using System.Collections.Generic;
using System.Linq;

using CoreLib.Converter;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Response;
using EntidadesGDS.FormaPago;
using EntidadesGDS.Boleto;
using EntidadesGDS.General;
using EntidadesGDS.Reporte.BoletosEmitidos;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_DailySalesReportLLS_200;

namespace SabreLib
{
    public sealed class DailySalesReport : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="sesion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public DailySalesReport(EnumAplicaciones application,
                                CE_Session sesion,
                                string codigoSeguimiento)
            : base(WebServiceAction.DailySalesReport, application, sesion, codigoSeguimiento)
        {
        }

        ~DailySalesReport()
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
        /// <param name="value"></param>
        /// <returns></returns>
        private EnumTipoRutaItinerario ProcessTypeRoute(string value)
        {
            return (value.Equals("D", StringComparison.InvariantCultureIgnoreCase) ? EnumTipoRutaItinerario.Nacional : EnumTipoRutaItinerario.Internacional);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string ProcessIndicatorOne(string value)
        {
            // creando mapa
            var lmap = new Dictionary<string, string>
            {
                { "V", "VOID" },
                { "E", "REEMISION" },
                { "A", "REEMISION" }
            };

            // buscando en mapa
            return (lmap.Any(k => k.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase))
                ? lmap.First(k => k.Key.Equals(value, StringComparison.InvariantCultureIgnoreCase)).Value
                : "ACTIVO");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        private CE_FormaPago[] ProcessPayments(DailySalesReportRSSalesReportIssuanceDataPayment[] payment)
        {
            // evaluando si se recibierón pagos
            if ((payment != null) && (payment.Any()))
            {
                return payment
                    .Select(p => new CE_FormaPago
                    {
                        //Tipo = 
                        Medio = ProcessPaymentForm(p.Form.Value),
                        MontoPago = Extension.ConvertOrDefault<decimal?>(p.Form.Amount),
                        CodigoMonedaPago = p.Form.CurrencyCode
                    }).ToArray();
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="issuanceData"></param>
        /// <returns></returns>
        private CE_Boleto ProcessTicket(DailySalesReportRSSalesReportIssuanceData issuanceData)
        {
            // evaluando si se recibierón tickets
            if ((issuanceData.TicketingInfo != null) && (issuanceData.TicketingInfo.Any()))
            {
                var lindicatorOne = ProcessIndicatorOne(issuanceData.IndicatorOne);

                return new CE_Boleto
                {
                    EnConjuncion = Extension.ConvertOrDefault<int?>(issuanceData.TicketingInfo[0].ConjunctiveCount),
                    NumeroBoleto = issuanceData.TicketingInfo[0].eTicketNumber,
                    Estatus = lindicatorOne,
                    CuponesUsados = Extension.ConvertOrDefault<int?>(issuanceData.TicketingInfo[0].UsedCount),
                    Comision = Extension.ConvertOrDefault<decimal?>(issuanceData.Commission),
                    Agente = new CE_Agente { Iniciales = issuanceData.AgentSine.Substring(1) },
                    HoraEmision = issuanceData.IssueTime
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="response"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private void ProcessResult(DailySalesReportRS response,
                                   out CE_Response3<CE_ReporteVenta> result)
        {
            result = new CE_Response3<CE_ReporteVenta>();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                result.Estatus.RegistrarError(".DailySalesReportRQ return DailySalesReportRS null");

                return;
            }

            if ((response.ApplicationResults.Error != null) && (response.ApplicationResults.Error.Any()))
            {
                // actualizando respuesta (errors)
                result.Estatus.RegistrarErrores(
                    response.ApplicationResults.Error
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );

                return;
            }

            if ((response.ApplicationResults.Warning != null) && (response.ApplicationResults.Warning.Any()))
            {
                // actualizando respuesta (warnings)
                result.Estatus.RegistrarAlertas(
                    response.ApplicationResults.Warning
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );
            }

            if (response.ApplicationResults.status == CompletionCodes.Complete)
            {
                // actualizando respuesta
                result.Estatus.Ok = true;

                result.Resultado = new CE_ReporteVenta
                {
                    Cabecera = new CE_ReporteVenta_Cabecera
                    {
                        Pseudo = response.SalesReport.CreationDetails.Source.PseudoCityCode,
                        NombreAgencia = response.SalesReport.CreationDetails.Source.AgencyName,
                        FechaCreacion = DateStringSabre.ToValidDate(response.SalesReport.CreationDetails.Source.CreateDateTime, false)
                    },
                    Emisiones = response.SalesReport.IssuanceData
                        .Select(i => new CE_ReporteVenta_Emision
                        {
                            TipoDocumento = i.DocumentType,
                            TipoRuta = ProcessTypeRoute(i.DomesticInternational),
                            //HoraEmision = DateStringSabre.ToTimeSpan(i.IssueTime),
                            PNR = i.ItineraryRef,
                            Pagos = ProcessPayments(i.Payment),
                            NombrePasajero = i.PersonName,
                            Boleto = ProcessTicket(i)
                        }).ToArray()
                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudoQuery"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public CE_Response3<CE_ReporteVenta> Execute(string pseudoQuery,
                                                     string date)
        {
            DailySalesReportRQRequest ldailySalesReportRQRequest = null;
            DailySalesReportRQResponse ldailySalesReportRQResponse = null;

            var lrespuesta = new CE_Response3<CE_ReporteVenta>();

            try
            {
                // construyendo request
                ldailySalesReportRQRequest = new DailySalesReportRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    DailySalesReportRQ = new DailySalesReportRQ
                    {
                        SalesReport = new DailySalesReportRQSalesReport
                        {
                            PseudoCityCode = pseudoQuery,
                            StartDate = date               // formato esperado {0:yyyy-MM-dd}
                        },
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        TimeStamp = DateTime.UtcNow,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<DailySalesReportPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'DailySalesReportPortTypeChannel.DailySalesReportRQ'", null, new { ldailySalesReportRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    ldailySalesReportRQResponse = lservicio.DailySalesReportRQ(ldailySalesReportRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'DailySalesReportPortTypeChannel.DailySalesReportRQ'", null, new { ldailySalesReportRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(ldailySalesReportRQResponse.DailySalesReportRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, pseudoQuery, date, ldailySalesReportRQRequest, ldailySalesReportRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_ReporteVenta>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
