using System;

using CoreWebLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.TarjetaCredito.B2BWallet;

using AmadeusLib.Base;
using AmadeusLib.Utiles;
using AmadeusLib.Amadeus_B2BWallet_1AWS;

namespace AmadeusLib.B2B
{
    public sealed class B2BWallet : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="application"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public B2BWallet(EnumAplicaciones application,
                         string codigoSeguimiento,
                         bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        {
        }

        ~B2BWallet()
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
        /// <param name="updateRequest"></param>
        /// <param name="withRequest"></param>
        /// <returns></returns>
        private void CompleteRequest(B2BWalletGenerateRQ updateRequest,
                                     B2BWalletGenerateRQ withRequest)
        {
            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.MessageID))
            {
                updateRequest.Message.Data.MessageID = withRequest.Message.Data.MessageID.Trim();
            }

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.VendorCode))
            {
                updateRequest.Message.Data.VendorCode = withRequest.Message.Data.VendorCode.Trim().ToUpper();
            }

            updateRequest.Message.Data.Amount = withRequest.Message.Data.Amount;

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.CurrencyCode))
            {
                updateRequest.Message.Data.CurrencyCode = withRequest.Message.Data.CurrencyCode.Trim().ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.EndDate))
            {
                updateRequest.Message.Data.EndDate = withRequest.Message.Data.EndDate;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <param name="withRequest"></param>
        /// <returns></returns>
        private void CompleteRequest(B2BWalletDetailRQ updateRequest,
                                     B2BWalletDetailRQ withRequest)
        {
            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.MessageID))
            {
                updateRequest.Message.Data.MessageID = withRequest.Message.Data.MessageID.Trim();
            }

            updateRequest.Message.Data.Reference = withRequest.Message.Data.Reference;

            if ((withRequest.Message.Data.Display != null) && string.IsNullOrWhiteSpace(withRequest.Message.Data.Display.Full))
            {
                updateRequest.Message.Data.Display = new Display { Full = withRequest.Message.Data.Display.Full.Trim().ToLower() };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <param name="withRequest"></param>
        /// <returns></returns>
        private void CompleteRequest(B2BWalletUpdateRQ updateRequest,
                                     B2BWalletUpdateRQ withRequest)
        {
            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.MessageID))
            {
                updateRequest.Message.Data.MessageID = withRequest.Message.Data.MessageID.Trim();
            }

            updateRequest.Message.Data.Reference = withRequest.Message.Data.Reference;
            updateRequest.Message.Data.Comment = withRequest.Message.Data.Comment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <param name="withRequest"></param>
        /// <returns></returns>
        private void CompleteRequest(B2BWalletDeleteRQ updateRequest,
                                     B2BWalletDeleteRQ withRequest)
        {
            updateRequest.Message.Data.Reference = withRequest.Message.Data.Reference;
            updateRequest.Message.Data.Comment = withRequest.Message.Data.Comment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateRequest"></param>
        /// <param name="withRequest"></param>
        /// <returns></returns>
        private void CompleteRequest(B2BWalletListRQ updateRequest,
                                     B2BWalletListRQ withRequest)
        {
            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.MessageID))
            {
                updateRequest.Message.Data.MessageID = withRequest.Message.Data.MessageID.Trim();
            }

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.Type))
            {
                updateRequest.Message.Data.Type = withRequest.Message.Data.Type.Trim();
            }

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.VendorCode))
            {
                updateRequest.Message.Data.VendorCode = withRequest.Message.Data.VendorCode.Trim().ToUpper();
            }

            updateRequest.Message.Data.Period = withRequest.Message.Data.Period;

            if ((withRequest.Message.Data.AmountRange != null) && 
                ((!string.IsNullOrWhiteSpace(withRequest.Message.Data.AmountRange.Min)) || (!string.IsNullOrWhiteSpace(withRequest.Message.Data.AmountRange.Max))))
            {
                updateRequest.Message.Data.AmountRange = new AmountRangeListRQ
                {
                    Min = withRequest.Message.Data.AmountRange.Min.Trim(),
                    Max = withRequest.Message.Data.AmountRange.Max.Trim()
                };
            }

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.CurrencyCode))
            {
                updateRequest.Message.Data.CurrencyCode = withRequest.Message.Data.CurrencyCode.Trim().ToUpper();
            }

            if (!string.IsNullOrWhiteSpace(withRequest.Message.Data.CardStatus))
            {
                updateRequest.Message.Data.CardStatus = withRequest.Message.Data.CardStatus.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="parameters"></param>
        /// <param name="result"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus Execute<TIn, TOut>(WebServiceAction operation, 
                                             TIn parameters,
                                             out TOut result,
                                             bool muteErrors = true)
            where TIn : class
            where TOut : class
 
        {
            var lstatus = new CE_Estatus(true);

            string lrequestXml = null;
            string lresponseXml = null;

            result = null;

            try
            {
                using (var lservice = Configuracion.GetServiceModelClient<IB2BWallet_1AWSChannel>())
                {
                    TIn lrequest;

                    // cargando archivo de configuracion de servicios
                    using (var lwebServiceFileValueAmadeus = new WebServiceFileValueAmadeus<TIn>(operation))
                    {
                        // leyendo objeto que representa el request original
                        lrequest = lwebServiceFileValueAmadeus.Request;

                        if (typeof(TIn) == typeof(B2BWalletGenerateRQ))
                        {
                            // actualizando el request
                            CompleteRequest(lrequest as B2BWalletGenerateRQ, parameters as B2BWalletGenerateRQ);
                        }

                        if (typeof(TIn) == typeof(B2BWalletDetailRQ))
                        {
                            // actualizando el request
                            CompleteRequest(lrequest as B2BWalletDetailRQ, parameters as B2BWalletDetailRQ);
                        }

                        if (typeof(TIn) == typeof(B2BWalletUpdateRQ))
                        {
                            // actualizando el request
                            CompleteRequest(lrequest as B2BWalletUpdateRQ, parameters as B2BWalletUpdateRQ);
                        }

                        if (typeof(TIn) == typeof(B2BWalletDeleteRQ))
                        {
                            // actualizando el request
                            CompleteRequest(lrequest as B2BWalletDeleteRQ, parameters as B2BWalletDeleteRQ);
                        }

                        if (typeof(TIn) == typeof(B2BWalletListRQ))
                        {
                            // actualizando el request
                            CompleteRequest(lrequest as B2BWalletListRQ, parameters as B2BWalletListRQ);
                        }
                    }

                    // construyendo representación string xml del request
                    lrequestXml = XmlHelper.XmlSerializer(lrequest, true, true, true, false, "Request");

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'IB2BWallet_1AWSChannel.ProcessRequest'", null, new { lrequestXml }, CodigoSeguimiento);

                    // ejecutando servicio y leyendo string xml del response
                    lresponseXml = lservice.ProcessRequest(lrequestXml);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'IB2BWallet_1AWSChannel.ProcessRequest'", null, new { lresponseXml }, CodigoSeguimiento);

                    // contruyendo objeto que representa el response
                    result = XmlHelper.XmlDeserialize<TOut>(lresponseXml, true, false, typeof(TOut).Name);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando 'IB2BWallet_1AWSChannel.ProcessRequest'", ex, new { MuteErrors, parameters, result, lrequestXml, lresponseXml }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                result = null;

                // actualizando respuesta
                lstatus = new CE_Estatus(ex);
            }

            return lstatus;
        }

        #endregion
    }
}
