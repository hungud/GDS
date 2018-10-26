using System;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base.Request;
using EntidadesGDS.Base.Response;
using EntidadesGDS.Reporte.BoletosEmitidos;
using AmadeusLib;

using GDSLib.Base;
using EntidadesGDS.Base;

namespace GDSLib.Amadeus
{
    public sealed class Reporte : Common2
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
        public Reporte(EnumAplicaciones? aplicacion,
                       string codigoSeguimiento,
                       string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno)
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

        #region "metodos"

        #region "ObtenerReporteVentas"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Response3<CE_ReporteVenta> ObtenerReporteVentas(RQ_ObtenerReporteVentas parametros, ref CE_Session session)
        {
            CE_Response3<CE_ReporteVenta> lrespuesta = null;

            try
            {
                // instanciando objeto
                using (var ldailySalesReport = new SalesReportDisplayQueryReport(Aplicacion.Value, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'ldailySalesReport.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'ldailySalesReport.Execute'", new { parametros.PseudoQuery, parametros.Date }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = ldailySalesReport.Execute(parametros.Date, parametros.PseudoQuery, ref session);

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
