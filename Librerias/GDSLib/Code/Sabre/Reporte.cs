using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Reporte.BoletosEmitidos;
using SabreLib;

using GDSLib.Base;

namespace GDSLib.Sabre
{
    public sealed class Reporte : Common
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
        public Reporte(EnumAplicaciones aplicacion, 
                       string codigoSeguimiento,
                       string codigoEntorno,
                       CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        public Reporte()
        {
        }

        ~Reporte()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "ObtenerReporteVentas"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Response3<CE_ReporteVenta> ObtenerReporteVentas(RQ_ObtenerReporteVentas parametros)
        {
            CE_Response3<CE_ReporteVenta> lrespuesta;

            try
            {
                // instanciando objeto
                using (var ldailySalesReport = new DailySalesReport(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldailySalesReport.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    ldailySalesReport.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldailySalesReport.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldailySalesReport.Execute'", new { parametros.PseudoQuery, parametros.Date }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = ldailySalesReport.Execute(parametros.PseudoQuery, parametros.Date);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldailySalesReport.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Response3<CE_ReporteVenta>(ex);
            }

            return lrespuesta;
        }

        #endregion

        #endregion
    }
}
