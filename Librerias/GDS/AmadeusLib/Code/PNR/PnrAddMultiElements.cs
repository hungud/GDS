using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using AmadeusLib.Base;
using AmadeusLib.Servicios.PNR_AddMultiElements.Request;
using AmadeusLib.Servicios.PNR_Reply.Response;

namespace AmadeusLib.PNR
{
    public sealed class PnrAddMultiElements : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_PnrAddMultiElements;

        private static readonly object _sync_PnrAddMultiElements = new object();

        #endregion

        // =============================
        // constantes

        #region "constantes"

        private const string TYPE_REMARK_CONFIDENTIAL = "RC";
        private const string TYPE_REMARK_INVOICE = "RI";
        private const string TYPE_REMARK_MISCELLANEOUS = "RM";

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public PnrAddMultiElements(EnumAplicaciones? application,
                           string codigoSeguimiento,
                           bool muteErrors = true)
            : base(application.Value, codigoSeguimiento, muteErrors)
        {
        }


        ~PnrAddMultiElements()
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
        /// <param name="target"></param>
        /// <returns></returns>
        private PNR_AddMultiElementsDataElementsMasterDataElementsIndiv BuildElementReceiveFrom(string target = "Easy-Web")
        {
            const string CODIGO_RECIBIDO_POR = "RF";
            const string CODIGO_TIPO_INFORMACION_RECIBIDO_POR = "P22";

            return new PNR_AddMultiElementsDataElementsMasterDataElementsIndiv
            {
                elementManagementData = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementData
                {
                    segmentName = CODIGO_RECIBIDO_POR
                },
                freetextData = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextData
                {
                    freetextDetail = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivFreetextDataFreetextDetail
                    {
                        subjectQualifier = "3",
                        type = CODIGO_TIPO_INFORMACION_RECIBIDO_POR
                    },
                    longFreetext = target
                }
            };
        }

        #region AddMiscellaneousRemarks

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textos"></param>
        /// <returns></returns>
        private List<PNR_AddMultiElementsDataElementsMasterDataElementsIndiv> BuildElementsMiscellaneousRemark(string[] textos)
        {
            var listElements = new List<PNR_AddMultiElementsDataElementsMasterDataElementsIndiv>();
            var lauxIndex = 0;

            foreach (var texto in textos)
            {
                ++lauxIndex;

                listElements.Add(
                    new PNR_AddMultiElementsDataElementsMasterDataElementsIndiv
                    {
                        elementManagementData = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementData
                        {
                            segmentName = "RM",
                            reference = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivElementManagementDataReference
                            {
                                qualifier = "OT",
                                number = Convert.ToString(lauxIndex)
                            }
                        },
                        miscellaneousRemark = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemark
                        {
                            remarks = new PNR_AddMultiElementsDataElementsMasterDataElementsIndivMiscellaneousRemarkRemarks
                            {
                                freetext = texto,
                                type = TYPE_REMARK_MISCELLANEOUS
                            }
                        }
                    }
                );
            }

            return listElements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="texto"></param>
        /// <param name="recibidoPor"></param>
        /// <returns></returns>
        public CE_Estatus AddMiscellaneousRemarks(ref CE_Session session, 
                                                  string texto, 
                                                  string recibidoPor = "Easy-Web") 
        {
            return AddMiscellaneousRemarks(ref session, new[] { texto }, recibidoPor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="texto"></param>
        /// <param name="recibidoPor"></param>
        /// <returns></returns>
        public CE_Estatus AddMiscellaneousRemarks(ref CE_Session session, 
                                                  string[] texto, 
                                                  string recibidoPor = "Easy-Web")
        {
            var laction = 11;
            var lrespuesta = new CE_Estatus();

            var ldataElements = BuildElementsMiscellaneousRemark(texto);
            ldataElements.Add(BuildElementReceiveFrom(recibidoPor));

            var lpnrAddMultiElementsRQ = new PNR_AddMultiElements
            {
                dataElementsMaster = new PNR_AddMultiElementsDataElementsMaster
                {
                    dataElementsIndiv = ldataElements.ToArray(),
                    marker1 = new PNR_AddMultiElementsDataElementsMasterMarker1()
                },
                pnrActions = new decimal[] { laction }
            };

            lrespuesta = Execute(ref session, lpnrAddMultiElementsRQ);

            return lrespuesta;
        }

        #endregion AddMiscellaneousRemarks

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="pnrAddMultiElementsRQ"></param>
        /// <returns></returns>
        private CE_Estatus Execute(ref CE_Session session, 
                                   PNR_AddMultiElements pnrAddMultiElementsRQ)
        {
            PNR_Reply lpnrReplyRS = null;

            CE_Estatus lrespuesta;

            try
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { pnrAddMultiElementsRQ, session }, CodigoSeguimiento);

                lock (_sync_PnrAddMultiElements)
                {
                    // procesando solicitud
                    lpnrReplyRS = Execute<PNR_AddMultiElements, PNR_Reply>(
                        WebServiceActionHeader4.PNRAddMultiElements,
                        ((TransactionType) session.AmadeusTransactionType),
                        pnrAddMultiElementsRQ, 
                        ref session,
                        ref _serialiazer_PnrAddMultiElements);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lpnrReplyRS, session }, CodigoSeguimiento);

                // actualizando respuesta
                //ProcessResult(lpnrReplyRS, out lrespuesta);
                lrespuesta = new CE_Estatus { Ok = true };

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, pnrAddMultiElementsRQ, lpnrReplyRS }, CodigoSeguimiento);

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
