using System;
using System.Text;
using System.IO;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Models.General;
using EntidadesGDS.General;
using EntidadesGDS.Servicio;
using BaseDatosLib.Paquetes;
using ServicioLib;

using GDSLib.Base;
using GDSLib.Utiles;
using System.Collections.Generic;

namespace GDSLib.PTA
{
    public sealed class SabreRedApp : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <returns></returns>
        public SabreRedApp(string codigoSeguimiento,
                                    string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        public SabreRedApp(EnumAplicaciones? aplicacion, string codigoSeguimiento,
                                    string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, null)
        {
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public SabreRedApp(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~SabreRedApp()
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
        /// <param name="parametro"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus RegistrarInformacionSesion(CE_InformacionSesion parametro,
                                                     out string resultado,
                                                     bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = string.Empty;

            try
            {
                using (var lpkgGdsSabreRed = new PkgGdsSabreRed(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSabreRed.GdsAlmacenarInformacionSesion'", new { parametro }, CodigoSeguimiento);

                    resultado = lpkgGdsSabreRed.GdsAlmacenarInformacionSesion(Conexion, Esquema, parametro);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSabreRed.GdsAlmacenarInformacionSesion'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametro, muteErrors }, CodigoSeguimiento);

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


        public CE_Estatus ObtenerInformacionVendedor(string idVendedor,
                                                     out CE_Vendedor resultado)
        {
            var lrespuesta = new CE_Estatus(true);
            resultado = null;
            try
            {
                using (var lpkgGdsGeneral = new PkgGdsGeneral(CodigoSeguimiento))
                {
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSabreRed.ObtenerInformacionVendedor'", new { idVendedor }, CodigoSeguimiento);
                    resultado = lpkgGdsGeneral.ObtenerVendedorPorID(Conexion, Esquema, idVendedor);
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSabreRed.ObtenerInformacionVendedor'", new { resultado }, CodigoSeguimiento);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, new { idVendedor }, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }



        public CE_Estatus ObtenerInformacionVendedores( out List<CE_Vendedor> resultado)
        {
            var lrespuesta = new CE_Estatus(true);
            resultado = null;
            try
            {
                using (var lpkgGdsGeneral = new PkgGdsGeneral(CodigoSeguimiento))
                {
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSabreRed.ObtenerVendedores'", CodigoSeguimiento);
                    resultado = lpkgGdsGeneral.ObtenerVendedores(Conexion, Esquema);
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSabreRed.ObtenerVendedores'", new { resultado }, CodigoSeguimiento);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fechaCreacion"></param>
        /// <returns></returns>
        private bool FechaCreacionExpirada(string fechaCreacion) 
        {
            var ldateCreacion = DateTime.Parse(fechaCreacion);
            var ldateActual = DateTime.Now;
            var result = ldateActual.Subtract(ldateCreacion);

            return result.Hours > 0; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerInformacionSesion(string parametro,
                                                   out CE_InformacionSesion resultado,
                                                   bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsSabreRed = new PkgGdsSabreRed(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsSabreRed.GdsObtenerInformacionSesion('", new { parametro }, CodigoSeguimiento);

                    resultado = lpkgGdsSabreRed.GdsObtenerInformacionSesion(Conexion, Esquema, parametro);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsSabreRed.GdsObtenerInformacionSesion('", new { resultado }, CodigoSeguimiento);

                    if (resultado != null) 
                    {
                        var tokenExpirada = FechaCreacionExpirada(resultado.FechaCreacion);

                        if (tokenExpirada) 
                        {
                            lrespuesta.Mensajes = new[] { new CE_Mensaje { Valor = "El Token ha expirado!", Tipo = EnumTipoMensaje.Error} };
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametro, muteErrors }, CodigoSeguimiento);

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametro"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus EnviarConfirmacionUsoEAU(string parametro,
                                                   out bool resultado)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = false;

            try
            {
                var lgestorEmail = new EmailMessage(CodigoSeguimiento);

                var lemailMessage = new RQ_SendEmailMessage
                {
                    To = new[] { "flavio.goni@expertiatravel.com", "luis.luza@expertiatravel.com", "hugo.sanchez@expertiatravel.com" },
                    Content = parametro,
                    Subject = string.Format("Agencia utilizando {0} EAU!" , Aplicacion.ToString()),
                    From = "avisos_eau@expertiatravel.com"
                };

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lgestorEmail.Send'", new { lemailMessage }, CodigoSeguimiento);

                lgestorEmail.Send(lemailMessage);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lgestorEmail.Send'", CodigoSeguimiento);

                resultado = true;

            }
            catch (Exception ex) 
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametro }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCarpeta"></param>
        /// <returns></returns>
        private void crearDirectorioSiNoExiste(string strCarpeta)
        {
            if (!Directory.Exists(strCarpeta))
            {
                var info = Directory.CreateDirectory(strCarpeta);

                Console.WriteLine("==> I <==");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivoExterno"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus AlmacenarArchivosLog(CE_ArchivoExterno archivoExterno,
                                               out bool resultado) 
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = false;

            try
            {
                var lcontenido = (archivoExterno.Contenido ?? Encoding.ASCII.GetBytes(archivoExterno.ContenidoCadena));

                if (lcontenido != null)
                {
                    var rutaBase = string.Format(Configuracion.RutaBaseLogApps, Aplicacion.ToString().ToUpper(), archivoExterno.Fecha, archivoExterno.Firma, archivoExterno.HostName);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.crearDirectorioSiNoExiste'", new { rutaBase }, CodigoSeguimiento);

                    crearDirectorioSiNoExiste(rutaBase);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.crearDirectorioSiNoExiste'", CodigoSeguimiento);

                    var rutaArchivo = string.Format("{0}\\{1}", rutaBase, archivoExterno.Nombre);

                    if (File.Exists(rutaArchivo))
                    {
                        File.Delete(rutaArchivo);
                    }

                    File.WriteAllBytes(rutaArchivo, lcontenido);

                    resultado = File.Exists(rutaArchivo);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { archivoExterno }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
