using System;
using System.Text;
using System.Linq;
using System.Net;
using System.Net.Mail;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Servicio;

using ServicioLib.Base;
using ServicioLib.Utiles;
using System.IO;

namespace ServicioLib
{
    public sealed class EmailMessage : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public EmailMessage(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~EmailMessage()
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
        /// <param name="port"></param>
        /// <param name="usuario"></param>
        /// <param name="contrasena"></param>
        /// <param name="de"></param>
        /// <param name="para"></param>
        /// <param name="conCopia"></param>
        /// <param name="conCopiaOculta"></param>
        /// <param name="asunto"></param>
        /// <param name="contenido"></param>
        /// <returns></returns>
        private void SendEmail(string servidor,
                               int? port,
                               string usuario,
                               string contrasena,
                               string de,
                               string[] para,
                               string[] conCopia,
                               string[] conCopiaOculta,
                               string asunto,
                               string contenido,
                               byte[] attachment = null,
                               RQ_SendEmailMessageAttachment[] attachments = null)
        {
            using (var lcorreo = new MailMessage())
            {
                using (var lcliente = new SmtpClient())
                {
                    // complementando cliente
                    lcliente.Host = servidor;

                    if (port.HasValue && (port.Value > 0))
                    {
                        lcliente.Port = port.Value;
                    }

                    if (!string.IsNullOrWhiteSpace(usuario))
                    {
                        lcliente.Credentials = new NetworkCredential(usuario, contrasena);
                    }

                    lcorreo.From = new MailAddress(de);

                    para
                        .Where(p => (!string.IsNullOrWhiteSpace(p)))
                            .ToList()
                                .ForEach(p => lcorreo.To.Add(p));

                    if ((conCopia != null) && conCopia.Any())
                    {
                        conCopia
                            .Where(c => (!string.IsNullOrWhiteSpace(c)))
                                .ToList()
                                    .ForEach(c => lcorreo.CC.Add(new MailAddress(c)));
                    }

                    if ((conCopiaOculta != null) && conCopiaOculta.Any())
                    {
                        conCopiaOculta
                            .Where(c => (!string.IsNullOrWhiteSpace(c)))
                                .ToList()
                                    .ForEach(c => lcorreo.Bcc.Add(new MailAddress(c)));
                    }

                    lcorreo.BodyEncoding = Encoding.UTF8;
                    lcorreo.IsBodyHtml = true;
                    lcorreo.Subject = asunto.Trim();
                    lcorreo.Body = contenido;

                    if (attachment != null) 
                    {
                        var lattach = new Attachment(new MemoryStream(attachment), "ReporteEmisiones.xlsx");
                        lcorreo.Attachments.Add(lattach);
                    }

                    if (attachments != null) 
                    {
                        attachments
                            .ToList()
                            .ForEach(a => lcorreo.Attachments.Add(new Attachment(new MemoryStream(a.FileBytes), a.FileName)));
                    }

                    // realizando envio del correo
                    lcliente.Send(lcorreo);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="muteErrors"></param>
        public CE_Estatus Send(RQ_SendEmailMessage parametros,
                               bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            try
            {
                // registrando evento
                Bitacora.Current.Debug("Parametros recibidos", new { parametros }, CodigoSeguimiento);

                // extrayendo credenciales
                var lcredentials = Configuracion.GetEmailMessageCredentials(parametros.Acronym);

                var lbcc = parametros.BCC;

                // evaluando si complementar lista de copia oculta
                if ((lcredentials.BCC != null) && lcredentials.BCC.Any())
                {
                    lbcc = (((lbcc != null) && lbcc.Any()) ? lcredentials.BCC.Union(lbcc).ToArray() : lcredentials.BCC);
                }


                var lfrom = lcredentials.From ?? parametros.From;

                // registrando evento
                Bitacora.Current.Debug("Por ejecutar '.SendEmail'", new { lbcc }, CodigoSeguimiento);

                // enviando mensaje
                SendEmail(
                    lcredentials.Server,
                    lcredentials.Port, 
                    lcredentials.User, 
                    lcredentials.Password,
                    lfrom,
                    parametros.To,
                    parametros.CC,
                    lbcc,
                    parametros.Subject,
                    parametros.Content, 
                    parametros.Attachment,
                    parametros.Attachments);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.SendEmail'", new { parametros.To }, CodigoSeguimiento);

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
