using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_QueueCountLLS_220;

namespace SabreLib.Queue
{
    public sealed class QueueCount : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public QueueCount(EnumAplicaciones application,
                          CE_Session sesion,
                          string codigoSeguimiento,
                          bool muteErrors = true)
            : base(WebServiceAction.QueueCount, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~QueueCount()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /*
        public void Execute()
        {
            QueueCountRQ lqueueCountRQ = null;
            QueueCountRS lqueueCountRS = null;

            CE_Mensaje lrespuesta;

            try
            {
                // construyendo request
                lqueueCountRQ = new QueueCountRQ
                {
                    TimeStamp = DateTime.Now,
                    Version = WebServiceFileValueSabre.Version,
                    ReturnHostCommand = true,
                    QueueInfo = new QueueCountRQQueueInfo
                    {
                        
                    }
                };

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { _signatureUser, Security, MessageHeader, command, lsabreCommandLLSRQ, lsabreCommandLLSRS }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Mensaje(false, EnumTipoMensaje.Error, ex.Message);
            }
        }
        */

        #endregion
    }
}
