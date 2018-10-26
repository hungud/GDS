using System;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_QueuePlaceLLS_204;

namespace SabreLib.Queue
{
    public sealed class QueuePlace : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public QueuePlace(EnumAplicaciones application,
                          CE_Session sesion,
                          string codigoSeguimiento,
                          bool muteErrors = true)
            : base(WebServiceAction.QueuePlace, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~QueuePlace()
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
            QueuePlaceRQ lqueuePlaceRQ = null;
            QueuePlaceRS lqueuePlaceRS = null;

            CE_Mensaje lrespuesta;

            try
            {
                // construyendo request
                lqueuePlaceRQ = new QueuePlaceRQ
                {
                    TimeStamp = DateTime.Now,
                    Version = WebServiceFileValueSabre.Version,
                    ReturnHostCommand = true,
                    QueueInfo = new QueuePlaceRQQueueInfo
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
