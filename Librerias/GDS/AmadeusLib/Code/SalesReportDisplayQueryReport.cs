using System;
using System.Linq;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Response;
using EntidadesGDS.General;
using EntidadesGDS.FormaPago;
using EntidadesGDS.Boleto;
using EntidadesGDS.Reporte.BoletosEmitidos;

using AmadeusLib.Base;
using AmadeusLib.Servicios.SalesReports_DisplayQueryReport.Request;

// alias
using NmRs = AmadeusLib.Servicios.SalesReports_DisplayQueryReport.Response;
using SalesReports_DisplayQueryReportReply2 = AmadeusLib.Servicios.SalesReports_DisplayQueryReport.Response.SalesReports_DisplayQueryReportReply;

namespace AmadeusLib
{
    public sealed class SalesReportDisplayQueryReport : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_SalesReportDisplayQueryReport;

        private static readonly object _sync_SalesReportDisplayQueryReport = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public SalesReportDisplayQueryReport(EnumAplicaciones application,
                                             string codigoSeguimiento,
                                             bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        {
        }

        ~SalesReportDisplayQueryReport()
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
        /// <param name="payment"></param>
        /// <param name="monetaryInformation"></param>
        /// <returns></returns>
        private CE_FormaPago[] ProcessPayments(NmRs.GeneralFopRepresentationType payment,
                                               NmRs.MonetaryInformationTypeI monetaryInformation)
        {
            if (payment != null)
            {
                return new[] {
                    new CE_FormaPago
                    {
                        Medio = payment.fopDescription.formOfPayment.type,
                        MontoPago = decimal.Parse(monetaryInformation.otherMonetaryDetails.ToList().Find(x => x.typeQualifier.Equals("T")).amount),         
                        MontoImpuestos = decimal.Parse(monetaryInformation.otherMonetaryDetails.ToList().Find(x => x.typeQualifier.Equals("TTX")).amount),         
                        MontoNeto = decimal.Parse(monetaryInformation.monetaryDetails.amount),         
                        CodigoMonedaPago = payment.monetaryInfo.monetaryDetails.currency
                    }
                };
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string ProcessOperationType(string type)
        {
            switch (type)
            {
                case "TKTT":
                case "TKTA":
                    return "TKT";
                    
                case "EMDS":
                case "CANN":
                    return "EMD";

                default:
                    return "TKT";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private CE_Boleto ProcessTicket(NmRs.SalesReports_DisplayQueryReportReplyQueryReportDataDetailsQueryReportDataOfficeGroupDocumentData item, string officeId)
        {
            return new CE_Boleto
            {
                Agente = new CE_Agente
                {
                    Iniciales = (((item.bookingAgent != null) && (item.bookingAgent.originIdentification != null))
                        ? item.bookingAgent.originIdentification.originatorId.Substring(4)
                        : null)
                },
                NumeroBoleto = item.documentNumber.documentDetails.number,
                Estatus = ("CANX/CANN".Contains(item.transactionDataDetails.transactionDetails.code) ? "VOID" : "ACTIVO"),
                Tipo = ProcessOperationType(item.transactionDataDetails.transactionDetails.code),
                Pseudo = officeId
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReportResponse"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private void ProcessResult(SalesReports_DisplayQueryReportReply2 salesReportResponse, 
                                   out CE_Response3<CE_ReporteVenta> result)
        {
            result = new CE_Response3<CE_ReporteVenta>();

            if ((salesReportResponse.errorGroup != null))
            {
                // actualizando respuesta (error)
                var errorDetails = salesReportResponse.errorGroup.errorOrWarningCodeDetails.errorDetails;
                var errorWarningDescription = salesReportResponse.errorGroup.errorWarningDescription;

                result.Estatus.RegistrarError(
                    string.Format(
                        "Error Code: {0} - Error Category: {1} - Descripcion: {2}", 
                        errorDetails.errorCode, errorDetails.errorCategory, 
                        string.Join("/", errorWarningDescription.freeText)));

                return;
            }

            var lreportGroup = salesReportResponse.queryReportDataDetails.queryReportDataOfficeGroup[0];

            var loficina = lreportGroup.requestorAgencyDetails.originatorDetails.inHouseIdentification1;

            result.Resultado = new CE_ReporteVenta
            {
                Cabecera = new CE_ReporteVenta_Cabecera
                {
                    Pseudo = loficina,
                    FechaCreacion = new DateTime(
                        int.Parse(salesReportResponse.queryReportDataDetails.dateDetails[0].dateTime.year),
                        int.Parse(salesReportResponse.queryReportDataDetails.dateDetails[0].dateTime.month),
                        int.Parse(salesReportResponse.queryReportDataDetails.dateDetails[0].dateTime.day))
                },
                Emisiones = lreportGroup
                    .documentData
                    .Where(document =>
                        "TKTT/TKTA/CANX/EMDS".Contains(document.transactionDataDetails.transactionDetails.code) &&
                        document.transactionDataDetails.transactionDetails.type.Equals("SALE", StringComparison.InvariantCultureIgnoreCase)
                    )
                    .Select(item => new CE_ReporteVenta_Emision
                    {
                        PNR = item.reservationInformation != null ? item.reservationInformation[0].controlNumber : string.Empty,
                        NombrePasajero = item.passengerName.paxDetails.surname,
                        Pagos = ProcessPayments(item.fopDetails, item.monetaryInformation),
                        Boleto = ProcessTicket(item, loficina)

                    }).ToArray()
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="officeId"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Response3<CE_ReporteVenta> Execute(string fecha,
                                                     string officeId,
                                                     ref CE_Session session)
        {

            SalesReports_DisplayQueryReport lsalesReportsDisplayQueryReportRequest = null;
            SalesReports_DisplayQueryReportReply2 lsalesReportsDisplayQueryReportReplyResponse = null;

            var lrespuesta = new CE_Response3<CE_ReporteVenta>();

            var liata = AmadeusUtility.GetIataByOfficeID(officeId);

            var lvaluesDate = fecha.Split('-');
            var lyear = lvaluesDate[0];
            var lmonth = lvaluesDate[1];
            var lday = lvaluesDate[2];

            try
            {
                // Construyendo request
                lsalesReportsDisplayQueryReportRequest = new SalesReports_DisplayQueryReport
                {
                    agencyDetails = new AdditionalBusinessSourceInformationTypeI
                    {
                        sourceType = new SourceTypeDetailsTypeI
                        {
                            sourceQualifier1 = "REP"
                        },
                        originatorDetails = new OriginatorIdentificationDetailsTypeI
                        {
                            originatorId = liata,
                            inHouseIdentification1 = officeId
                        }
                    },
                    requestOption = new SelectionDetailsTypeI
                    {
                        selectionDetails = new SelectionDetailsInformationTypeI
                        {
                            option = "SOF"
                        }
                    },
                    dateDetails = new StructuredDateTimeInformationType
                    {
                        businessSemantic = "S",
                        dateTime = new StructuredDateTimeType
                        {
                            day = lday,
                            month = lmonth,
                            year = lyear
                        }
                    }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lsalesReportsDisplayQueryReportRequest }, CodigoSeguimiento);

                lock (_sync_SalesReportDisplayQueryReport)
                {
                    // procesando solicitud
                    lsalesReportsDisplayQueryReportReplyResponse = Execute<SalesReports_DisplayQueryReport, SalesReports_DisplayQueryReportReply2>(
                        WebServiceActionHeader4.SalesReportsDisplayQueryReport,
                        ((TransactionType) session.AmadeusTransactionType),
                        lsalesReportsDisplayQueryReportRequest, 
                        ref session,
                        ref _serialiazer_SalesReportDisplayQueryReport);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lsalesReportsDisplayQueryReportReplyResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lsalesReportsDisplayQueryReportReplyResponse, out lrespuesta);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, fecha, officeId, lsalesReportsDisplayQueryReportRequest, lsalesReportsDisplayQueryReportReplyResponse, lrespuesta }, CodigoSeguimiento);

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
