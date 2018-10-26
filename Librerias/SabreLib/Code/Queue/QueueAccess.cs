using System;
using System.Linq;

using CoreLib.Converter;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Queue;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_QueueAccessLLS_208;

namespace SabreLib.Queue
{
    public sealed class QueueAccess : Common<Security1, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public QueueAccess(EnumAplicaciones application,
                           CE_Session sesion,
                           string codigoSeguimiento,
                           bool muteErrors = true)
            : base(WebServiceAction.QueueAccess, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~QueueAccess()
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
        /// <param name="colas"></param>
        /// <returns></returns>
        private void ProcessResult(QueueAccessRS response,
                                   out CE_Response3<CE_QueueAccess> colas)
        {
            colas = new CE_Response3<CE_QueueAccess>();

            if ((response == null) || (response.ApplicationResults == null))
            {
                // actualizando respuesta (error)
                colas.Estatus.RegistrarError(".QueueAccessRQ return QueueAccessRS null");

                return;
            }

            if ((response.ApplicationResults.Error != null) && (response.ApplicationResults.Error.Any()))
            {
                // actualizando respuesta (errors)
                colas.Estatus.RegistrarErrores(
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
                colas.Estatus.RegistrarAlertas(
                    response.ApplicationResults.Warning
                        .SelectMany(w => w.SystemSpecificResults)
                            .SelectMany(s => s.Message)
                                .Select(m => string.Format("{0} - {1}", m.code, m.Value))
                    );
            }

            if (response.ApplicationResults.status == CompletionCodes.Complete)
            {
                // actualizando respuesta
                colas.Estatus.Ok = true;

                if (response.Line != null)
                {
                    colas.Resultado = new CE_QueueAccess
                    {
                        QueueReservas = response.Line
                            .Select(l =>
                            {
                                // evaluando valores pseudo y agente
                                var lpseudoCityCode = ((l.POS != null) && (l.POS.Source != null) ? l.POS.Source.PseudoCityCode : null);
                                var lagentSine = ((l.POS != null) && (l.POS.Source != null) ? l.POS.Source.AgentSine : null);

                                return new CE_QueueReserva
                                {
                                    DateTime = DateStringSabre.ToValidDate(l.DateTime, false),
                                    Group = l.Group,
                                    Number = Extension.ConvertOrDefault<int>(l.Number),
                                    PseudoCityCode = lpseudoCityCode,
                                    AgentSine = lagentSine,
                                    UniqueID = l.UniqueID.ID
                                };
                            }).ToArray()
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumQueueNavigation"></param>
        /// <param name="enumQueueDirection"></param>
        /// <param name="pseudoCityCode"></param>
        /// <param name="number"></param>
        /// <param name="plus"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        private CE_Response3<CE_QueueAccess> Execute(string enumQueueNavigation,
                                                     string enumQueueDirection,
                                                     string pseudoCityCode,
                                                     string number,
                                                     string plus,
                                                     bool lista)
        {
            QueueAccessRQRequest lqueueAccessRQRequest = null;
            QueueAccessRQResponse lqueueAccessRQResponse = null;

            QueueAccessRQNavigation lnavigation = null;

            var lrespuesta = new CE_Response3<CE_QueueAccess>();

            try
            {
                // construyendo request
                if ((!string.IsNullOrWhiteSpace(enumQueueNavigation)) && (!string.IsNullOrWhiteSpace(enumQueueDirection)))
                {
                    // forzando excepción
                    throw new InternalException("No es posible combinar QueueNavigation con QueueDirection");
                }
              
                if (enumQueueNavigation!= null) 
                {
                    lnavigation = new QueueAccessRQNavigation
                    {
                        Action = (QueueAccessRQNavigationAction) Enum.Parse(typeof(QueueAccessRQNavigationAction), enumQueueNavigation)
                    };
                }

                if (enumQueueDirection != null)
                {
                    lnavigation = new QueueAccessRQNavigation
                    {
                        Direction = new QueueAccessRQNavigationDirection
                        {
                            Action = (QueueAccessRQNavigationDirectionAction) Enum.Parse(typeof(QueueAccessRQNavigationDirectionAction), enumQueueDirection),
                            Plus = plus
                        }
                    };
                }

                lqueueAccessRQRequest = new QueueAccessRQRequest
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    QueueAccessRQ = new QueueAccessRQ
                    {
                        TimeStamp = DateTime.Now,
                        TimeStampSpecified = true,
                        Version = WebServiceFileValueSabre.Version,
                        ReturnHostCommand = true,
                        ReturnHostCommandSpecified = true,
                        Navigation = lnavigation,
                        QueueIdentifier = new QueueAccessRQQueueIdentifier
                        {
                            PseudoCityCode = pseudoCityCode,
                            Number = number,
                            List = new QueueAccessRQQueueIdentifierList { Ind = lista }
                        }
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<QueueAccessPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Por ejecutar 'QueueAccessPortTypeChannel.QueueAccessRQ'", null, new { lqueueAccessRQRequest }, CodigoSeguimiento);

                    // procesando solicitud
                    lqueueAccessRQResponse = lservicio.QueueAccessRQ(lqueueAccessRQRequest);

                    // registrando eventos
                    Bitacora.Current.InfoAnd(PartnerLevel.Debug, "Ejecutado 'QueueAccessPortTypeChannel.QueueAccessRQ'", null, new { lqueueAccessRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lqueueAccessRQResponse.QueueAccessRS, out lrespuesta);
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Warn, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, enumQueueNavigation, enumQueueDirection, pseudoCityCode, number, plus, lista, lqueueAccessRQRequest,  lqueueAccessRQResponse,  lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_QueueAccess>(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.InfoAnd(PartnerLevel.Error, "ERROR ejecutando '.Execute'", ex, new { MuteErrors, enumQueueNavigation, enumQueueDirection, pseudoCityCode, number, plus, lista, lqueueAccessRQRequest, lqueueAccessRQResponse, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!MuteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_QueueAccess>(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumQueueNavigation"></param>
        /// <param name="enumQueueDirection"></param>
        /// <param name="pseudoCityCode"></param>
        /// <param name="number"></param>
        /// <param name="plus"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public CE_Response3<CE_QueueAccess> ObtenerListadoReserva(string enumQueueNavigation,
                                                                  string enumQueueDirection,
                                                                  string pseudoCityCode,
                                                                  string number,
                                                                  string plus,
                                                                  bool lista)
        {
            return Execute(enumQueueNavigation, enumQueueDirection, pseudoCityCode, number, plus, lista);
        }

        #endregion
    }
}
