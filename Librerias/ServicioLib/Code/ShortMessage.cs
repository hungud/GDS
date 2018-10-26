using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using CoreWebLib;
using CustomLog;
using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Servicio;

using ServicioLib.Base;
using ServicioLib.Utiles;

namespace ServicioLib
{
    public sealed class ShortMessage : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public ShortMessage(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~ShortMessage()
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
        /// <param name="servidor"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="tituloRemitente"></param>
        /// <param name="contenido"></param>
        /// <param name="destinatario"></param>
        /// <returns></returns>
        private string SendShortMessage(string servidor,
                                        string usuario,
                                        string contrasena,
                                        string tituloRemitente,
                                        string contenido,
                                        string destinatario)
        {
            string lmensaje = null;

            try
            {
                // creando instancia de cliente para llamado al servicio
                var lservicio = WebRequest.Create(
                        string.Format(
                            "{0}/cgi-bin/exec?cmd=api_queue_sms&username=lyric_api&password=lyric_api&content={1}-{2}&destination={3}&api_version=0.08&channel=8",
                            servidor,
                            contenido,
                            tituloRemitente,
                            destinatario)
                    );

                // complementando cliente
                lservicio.Method = "GET";
                lservicio.Proxy = new WebProxy { Credentials = new NetworkCredential(usuario, contrasena) };
                lservicio.Credentials = new NetworkCredential(usuario, contrasena);
                lservicio.ContentType = "application/x-www-form-urlencoded";

                // realizando envio del sms
                var lrespuesta = (new StreamReader(lservicio.GetResponse().GetResponseStream())).ReadToEnd();

                // evaluando respuesta
                dynamic lresultado = JsonHelper.JsonDeserializeAnonymous(lrespuesta, false);

                // enviando si el sms pudo ser enviado
                if (!((bool) lresultado.success))
                {
                    lmensaje = string.Format("Enviando SMS al destinatario '{0}' el servicio retorno: '{1}'", destinatario, lresultado.success);
                }

            }
            catch (Exception ex)
            {
                // contruyendo mensaje de respuesta
                lmensaje = string.Format("Enviando SMS al detinatario '{0}' se presento el error:\n\n{1}", destinatario, ex.Message);
            }

            return lmensaje;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="muteErrors"></param>
        public CE_Estatus Send(RQ_SendShortMessage parametros,
                               bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            try
            {
                // registrando evento
                Bitacora.Current.Debug("Parametros recibidos", new { parametros }, CodigoSeguimiento);

                List<string> lresultados = null;

                // extrayendo credenciales
                var lcredentials = Configuracion.GetShortMessageCredentials(parametros.Acronym);

                // recorriendo arrayd de números a quien enviar el mensaje
                foreach (var lrecipient in parametros.Recipients)
                {
                    // registrando evento
                    Bitacora.Current.Debug("Por ejecutar '.SendShortMessage'", new { lrecipient }, CodigoSeguimiento);

                    // enviando mensaje
                    var lresultado = SendShortMessage(
                            lcredentials.Server, 
                            lcredentials.User, 
                            lcredentials.Password,
                            parametros.SenderTitle,
                            parametros.Content,
                            lrecipient);

                    // registrando evento
                    Bitacora.Current.Debug("Ejecutado '.SendShortMessage'", new { lresultado }, CodigoSeguimiento);

                    // evaluando el resultado obtenido
                    if (!string.IsNullOrWhiteSpace(lresultado))
                    {
                        lresultados = (lresultados ?? new List<string>());

                        // actualizando los resultados
                        lresultados.Add(lresultado);
                    }
                }

                if (lresultados != null)
                {
                    // actualizando respuesta
                    lrespuesta.Ok = (parametros.Recipients.Count() != lresultados.Count());
                    lrespuesta.Mensajes = lresultados
                        .Select(r => new CE_Mensaje
                        {
                            Tipo = (lrespuesta.Ok ? EnumTipoMensaje.Alerta : EnumTipoMensaje.Error),
                            Valor = r
                        }).ToArray();
                }

                // registrando evento
                Bitacora.Current.Info("Ejecutado '.SendShortMessage'", new { parametros.Recipients, lresultados }, CodigoSeguimiento);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors, lrespuesta }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
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
