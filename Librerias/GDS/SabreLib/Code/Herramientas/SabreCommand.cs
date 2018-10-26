using System;
using System.Threading;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;

using SabreLib.Base;
using SabreLib.Utiles;
using SabreLib.Sabre_SabreCommandLLS_181;

namespace SabreLib.Herramientas
{
    public sealed class SabreCommand : Common<Security, MessageHeader, SecurityUsernameToken, From, To, PartyId, Service, MessageData>
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
        public SabreCommand(EnumAplicaciones application,
                            CE_Session sesion,
                            string codigoSeguimiento,
                            bool muteErrors = true)
            : base(WebServiceAction.SabreCommand, application, sesion, codigoSeguimiento, muteErrors)
        {
        }

        ~SabreCommand()
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
        private void ProcessResult(SabreCommandLLSRS response,
                                   out CE_Estatus estatus)
        {
            estatus = new CE_Estatus();

            if ((response == null) || (response.Response == null))
            {
                // actualizando respuesta (error)
                estatus.RegistrarError(".SabreCommandLLSRQ return SabreCommandLLSRS null");

                return;
            }

            if ((response.ErrorRS != null) && (response.ErrorRS.Errors != null) &&
                (response.ErrorRS.Errors.Error != null))
            {
                // actualizando respuesta (errors)
                estatus.RegistrarError(string.Format("{0} - {1}", response.ErrorRS.Errors.Error.ErrorCode, response.ErrorRS.Errors.Error.ErrorMessage));

                return;
            }

            // actualizando respuesta
            estatus.Ok = true;
            estatus.Registrar(response.Response);

            // evaluando si realizar una pausa
            if (response.Response.Contains("EDITS IN PROGRESS....PLEASE WAIT...."))
            {
                // realizando una pausa
                Thread.Sleep(Configuracion.TimeSleepSeconds);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public CE_Estatus Execute(string comando)
        {
            SabreCommandLLSRQRequest1 lsabreCommandLLSRQRequest1 = null;
            SabreCommandLLSRQResponse lsabreCommandLLSRQResponse = null;

            var lrespuesta = new CE_Estatus();

            try
            {
                // construyendo request
                lsabreCommandLLSRQRequest1 = new SabreCommandLLSRQRequest1
                {
                    Security = Security,
                    MessageHeader = MessageHeader,
                    SabreCommandLLSRQ = new SabreCommandLLSRQ
                    {
                        EchoToken = "String",
                        AltLangID = "en-us",
                        PrimaryLangID = "en-us",
                        SequenceNmbr = "1",
                        Target = SabreCommandLLSRQTarget.Production,
                        TimeStamp = string.Format("{0:yyyy-MM-dd}T{0:hh:mm:ss}", DateTime.Now),
                        Version = WebServiceFileValueSabre.Version,
                        Request = new SabreCommandLLSRQRequest
                        {
                            CDATA = true,
                            Output = SabreCommandLLSRQRequestOutput.SDS,
                            HostCommand = comando
                        }                        
                    }
                };

                using (var lservicio = Configuracion.GetServiceModelClient<SabreCommandLLSPortTypeChannel>())
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'SabreCommandLLSPortTypeChannel.SabreCommandLLSRQ'", new { lsabreCommandLLSRQRequest1 }, CodigoSeguimiento);

                    // procesando solicitud
                    lsabreCommandLLSRQResponse = lservicio.SabreCommandLLSRQ(lsabreCommandLLSRQRequest1);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'SabreCommandLLSPortTypeChannel.SabreCommandLLSRQ'", new { lsabreCommandLLSRQResponse }, CodigoSeguimiento);

                    // actualizando respuesta
                    ProcessResult(lsabreCommandLLSRQResponse.SabreCommandLLSRS, out lrespuesta);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { MuteErrors, comando, lsabreCommandLLSRQRequest1, lsabreCommandLLSRQResponse, lrespuesta }, CodigoSeguimiento);

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
        /// <returns></returns>
        public CE_Estatus PseudoActual()
        {
            return Execute("*S");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hacia"></param>
        /// <returns></returns>
        public CE_Estatus CambiarPseudo(string hacia)
        {
            return Execute(string.Format("AAA{0}", hacia.Trim()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus FinalizarRecuperar()
        {
            return Execute("ER");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus DesplegarItinerario()
        {
            return Execute("*I");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus IgnorarRecuperar()
        {
            return Execute("IR");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus BorrarLineasContables()
        {
            return Execute(@"AC¤ALL");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus ExisteLineasContables()
        {
            return Execute("*PAC");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus BorrarLineaPrecioFutura()
        {
            return Execute(@"FP¤");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pasajero"></param>
        /// <returns></returns>
        public CE_Estatus InsertarFoid(CE_Pasajero pasajero)
        {
            if (string.IsNullOrWhiteSpace(pasajero.RUC))
            {
                return Execute(
                        string.Format(
                            @"3FOID/{0}{1}{2}",
                            ((pasajero.TipoDocumento == EnumTipoDocumento.DNI) ? "NI" : ((pasajero.TipoDocumento == EnumTipoDocumento.CarnetExtranjeria) ? "NICE" : "NIPP")),
                            pasajero.NumeroDocumento.Trim(),
                            pasajero.NumeroPasajero.Trim()
                        ));
            }

            return Execute(string.Format(@"3FOID/RUC{0}{1}", pasajero.RUC.Trim(), pasajero.NumeroPasajero.Trim()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarDk(string idCliente)
        {
            return Execute(string.Format(@"DK{0}", idCliente).Trim());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idSubCodigo"></param>
        /// <returns></returns>
        public CE_Estatus ActualizarSubCodigo(string idSubCodigo)
        {
            return Execute(string.Format(@"DK{0}", idSubCodigo).Trim());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus DesplegarTicket(string nroBoleto)
        {
            return Execute(string.Format("WETR*T{0}", nroBoleto));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus Release(string pseudoOrigen, string firma)
        {
            return Execute(string.Format(@"6¤TA/{0}-{1}", pseudoOrigen, firma));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CE_Estatus AnularTicket()
        {
            return Execute(string.Format("WETRV"));
        }
        #endregion
    }
}
