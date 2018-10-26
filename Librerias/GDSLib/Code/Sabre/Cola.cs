using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Queue;
using SabreLib.Queue;

using GDSLib.Base;

namespace GDSLib.Sabre
{
    public sealed class Cola : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacion"></param>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="codigoEntorno"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public Cola(EnumAplicaciones aplicacion, 
                    string codigoSeguimiento,
                    string codigoEntorno,
                    CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        public Cola()
        {
        }

        ~Cola()
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
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Response3<CE_QueueAccess> ObtenerListadoReserva(CE_Request3<RQ_QueueAccess> request)
        {
            CE_Response3<CE_QueueAccess> lrespuesta;

            try
            {
                // instanciando objeto
                using (var lqueueAccess = new QueueAccess(request.Aplicacion.Value, request.Sesion, request.CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lqueueAccess.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lqueueAccess.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lqueueAccess.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lqueueAccess.ObtenerListadoReserva'", new { request.Parametros.PseudoCityCode, request.Parametros.Number }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lqueueAccess.ObtenerListadoReserva(null, null, request.Parametros.PseudoCityCode, request.Parametros.Number, null, true);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lqueueAccess.ObtenerListadoReserva'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { request }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_QueueAccess>(ex);
            }

            return lrespuesta;
        }

        #endregion
    }
}
