using System;
using System.Xml.Serialization;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Itinerario;

using AmadeusLib.Base;
using AmadeusLib.Servicios.Command_Cryptic.Request;
using AmadeusLib.Servicios.Command_Cryptic.Response;

namespace AmadeusLib.Herramientas
{
    public sealed class CommandCryptic : Common
    {
        // =============================
        // variables estaticas

        #region "variables estaticas"

        private static volatile XmlSerializer _serialiazer_CommandCryptic;

        private static readonly object _sync_CommandCryptic = new object();

        #endregion

        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public CommandCryptic(EnumAplicaciones application,
                              string codigoSeguimiento,
                              bool muteErrors = true)
            : base(application, codigoSeguimiento, muteErrors)
        {
        }

        ~CommandCryptic()
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
        private void ProcessResult(Command_CrypticReply response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.longTextString == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".CommandCryptic return Command_CrypticReply null");

                return;
            }

            // actualizando respuesta
            estatus.Ok = true;
            estatus.Registrar(response.longTextString.textStringDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comando"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus Execute(string comando,
                                  ref CE_Session session)
        {
            Command_Cryptic lcommandCrypticRequest = null;
            Command_CrypticReply lcommandCrypticReplyResponse = null;

            CE_Estatus lrespuesta;

            try
            {
                // construyendo request
                lcommandCrypticRequest = new Command_Cryptic
                {
                    longTextString = new Command_CrypticLongTextString
                    {
                        textStringDetails = comando
                    },
                    messageAction = new Command_CrypticMessageAction
                    {
                        messageFunctionDetails = new Command_CrypticMessageActionMessageFunctionDetails
                        {
                            messageFunction = "M"
                        }
                    }
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.Execute'", new { lcommandCrypticRequest }, CodigoSeguimiento);

                lock (_sync_CommandCryptic)
                {
                    // procesando solicitud
                    lcommandCrypticReplyResponse = Execute<Command_Cryptic, Command_CrypticReply>(
                        WebServiceActionHeader4.CommandCryptic, 
                        ((TransactionType) session.AmadeusTransactionType), 
                        lcommandCrypticRequest, 
                        ref session,
                        ref _serialiazer_CommandCryptic);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.Execute'", new { lcommandCrypticReplyResponse, session }, CodigoSeguimiento);

                // actualizando respuesta
                ProcessResult(lcommandCrypticReplyResponse, out lrespuesta);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, comando, lcommandCrypticRequest, lcommandCrypticReplyResponse }, CodigoSeguimiento);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rqDesplegarSegmento"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        public CE_Estatus DesplegarSegmento(RQ_DesplegarSegmento rqDesplegarSegmento, 
                                            ref CE_Session session)
        {
            return Execute(string.Format("DO{0}{1}/{2}", rqDesplegarSegmento.LineaAerea, rqDesplegarSegmento.NumeroVuelo, rqDesplegarSegmento.FechaVuelo), ref session);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus Ignorar(ref CE_Session session)
        {
            return Execute("IG", ref session);
        }

        #endregion
    }
}
