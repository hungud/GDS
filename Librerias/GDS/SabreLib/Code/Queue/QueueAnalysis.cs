using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_QueueAnalysisLLS_200;

namespace SabreLib.Queue
{
    public sealed class QueueAnalysis : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public QueueAnalysis(EnumAplicaciones application,
                             CE_Session sesion,
                             string codigoSeguimiento,
                             bool muteErrors = true)
            : base(WebServiceAction.QueueAnalysis, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~QueueAnalysis()
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
            QueueAnalysisRQ lqueueAnalysisRQ = null;
            QueueAnalysisRS lqueueAnalysisRS = null;

            CE_Mensaje lrespuesta;

            try
            {
                // construyendo request
                lqueueAnalysisRQ = new QueueAnalysisRQ
                {
                    TimeStamp = string.Format("{0:yyyy-MM-dd}T{0:hh:mm:ss}", DateTime.Now),
                    Version = WebServiceFileValueSabre.Version,
                    ReturnHostCommand = true,
                    QueueInfo = new QueueAnalysisRQQueueInfo
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
