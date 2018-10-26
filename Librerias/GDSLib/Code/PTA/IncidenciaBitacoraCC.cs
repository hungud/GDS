using System;

using CustomLog;

using EntidadesGDS.Base;
using EntidadesGDS.Incidencia;
using BaseDatosLib.Paquetes;
using BaseDatosLib.PaquetesWeb;

using GDSLib.Base;
using ServicioLib;
using System.Collections.Generic;
using System.Text;
using EntidadesGDS.Servicio;

namespace GDSLib.PTA
{
    public sealed class IncidenciaBitacoraCC : Common
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
        public IncidenciaBitacoraCC(string codigoSeguimiento,
                                    string codigoEntorno)
            : base(codigoSeguimiento, codigoEntorno)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public IncidenciaBitacoraCC(string codigoSeguimiento)
            : base(codigoSeguimiento)
        {
        }

        ~IncidenciaBitacoraCC()
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
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus RegistrarIncidenciaBitacoraCC(CE_BitacoraCC parametros,
                                                        out bool resultado,
                                                        bool muteErrors = true)
        {
            var lrespuesta = new CE_Estatus(true);

            const string lesquemaAppWebs = "APPWEBS";

            resultado = false;

            try
            {
                CE_UsuarioWeb lusuarioWeb;

                using (var lpkgGdsModuloIncidenciasWeb = new PkgGdsModuloIncidenciasWeb(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloIncidenciasWeb.GdsObtenerDatosUsuarioWeb'", new { lesquemaAppWebs, parametros.IdVendedor }, CodigoSeguimiento);

                    lusuarioWeb = lpkgGdsModuloIncidenciasWeb.GdsObtenerDatosUsuarioWeb(Conexion, lesquemaAppWebs, parametros.IdVendedor);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloIncidenciasWeb.GdsObtenerDatosUsuarioWeb'", new { lusuarioWeb }, CodigoSeguimiento);
                }

                if (lusuarioWeb != null)
                {
                    // set datos del usuario web en el request
                    parametros.UsuarioWeb = lusuarioWeb;
                    
                    using (var lpkgGdsModuloIncidencias = new PkgGdsModuloIncidencias(CodigoSeguimiento))
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloIncidencias.GdsInsertarBitacoraCC'", new { parametros }, CodigoSeguimiento);

                        resultado = lpkgGdsModuloIncidencias.GdsInsertarBitacoraCC(Conexion, Esquema, parametros);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloIncidencias.GdsInsertarBitacoraCC'", new { resultado }, CodigoSeguimiento);
                    }

                }
                else 
                {
                    string[] arrayErrores = { string.Format("El usuario {0} no existe en la base de datos web.", parametros.UsuarioWebLogin) };

                    // actualizando respuesta
                    lrespuesta.Ok = false;
                    lrespuesta.RegistrarErrores(arrayErrores);
                }

            }
            catch (Exception ex) 
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

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
        /// <param name="template"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string ReplaceParameters(string template, 
                                         Dictionary<string, string> parameters)
        {
            var data = new StringBuilder();

            data.Append(template);

            foreach (var parameter in parameters)
            {
                data.Replace(parameter.Key, parameter.Value);
            }

            return data.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="plantilla"></param>
        /// <returns></returns>
        private string ConstruirCuerpoCorreo(CE_BitacoraCC target, 
                                             string plantilla) 
        {
            var parameters = new Dictionary<string, string>
            {
                {"$cliente", string.Format("{0} - {1}", target.Cliente.IdCliente, target.Cliente.NombreCliente)},
                {"$asunto", target.OcurTema},
                {"$solicitante", target.Solicitante},
                {"$aprobador", target.Aprobador},
                {"$centroCosto", target.CentroCosto},
                {"$motivoViajes", target.MotivoViaje},
                {"$reservaYtickets", target.OcurDescripcion},
                {"$agente", target.NombreAgente},
                {"$ordenServicio", target.OrdenServicio}
            };

            return ReplaceParameters(plantilla, parameters);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        private void completarInformacion(ref CE_BitacoraCC target) {
            using (var lpkgGdsGeneral = new PkgGdsGeneral(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneral.ObtenerVendedorPorUsuarioWeb'", new { target.UsuarioWebLogin }, CodigoSeguimiento);

                var lvendedor = lpkgGdsGeneral.ObtenerVendedorPorUsuarioWeb(Conexion, Esquema, target.UsuarioWebLogin);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneral.ObtenerVendedorPorUsuarioWeb'", new { lvendedor }, CodigoSeguimiento);

                target.NombreAgente = lvendedor.Nombre;
                target.CorreoAgente = lvendedor.Correo;
            }

            using (var lpkgGdsModuloPnr = new PkgGdsModuloPnrPta(CodigoSeguimiento)) 
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsModuloPnr.GdsObtenerCliente'", new { target.Dk }, CodigoSeguimiento);

                var lcliente = lpkgGdsModuloPnr.GdsObtenerCliente(Conexion, Esquema, target.Dk.Value, 0);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsModuloPnr.GdsObtenerCliente'", new { lcliente }, CodigoSeguimiento);

                target.Cliente = lcliente;
            }

            if (string.IsNullOrEmpty(target.OcurDescripcion))
            {
                target.OcurDescripcion = "-";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="plantilla"></param>
        /// <returns></returns>
        public void EnviarConfirmacionRegistro(CE_BitacoraCC target, 
                                               string plantilla) {
           completarInformacion(ref target);
           
           var lhtml = ConstruirCuerpoCorreo(target, plantilla);

           var lgestorEmail = new EmailMessage(CodigoSeguimiento);

           var lemailMessage = new RQ_SendEmailMessage
           {
               To = new[] { target.CorreoAgente },
               CC = new[] { "fconterno@nmviajes.com", "lbonelli@nmviajes.com", "mfelices@nmviajes.com", "ysteinmann@nmviajes.com" },
               Content = lhtml,
               Subject =  string.Format("Incidencia {0} - DK: {1}", target.Cliente.NombreCliente, target.Dk),
               From = "Bitacora@nmviajes.com"
           };

           lgestorEmail.Send(lemailMessage);
        }

        #endregion
    }
}
