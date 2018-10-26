using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CustomLog;

using EntidadesGDS.Robot;

using BaseDatosLib.Base;
using EntidadesGDS.Models.Robot;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsRobotAnulaciones : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <returns></returns>
        public PkgGdsRobotAnulaciones(string codigoSeguimiento,
                                      Conexion conexion,
                                      string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_ROBOT_ANULACIONES")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsRobotAnulaciones(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsRobotAnulaciones()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "GdsBoletosPendientesDePago"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="tipoClienteAgencia"></param>
        /// <param name="condicionPagoCliente"></param>
        /// <param name="tipoClientePasajero"></param>
        /// <param name="idClientePasajero"></param>
        /// <param name="idEmpresaSucursal"></param>
        /// <param name="marcaEsConsolidador"></param>
        /// <param name="listaGds"></param>
        /// <param name="listaProveedoresBoletos"></param>
        /// <param name="fecha"></param>
        /// <param name="antesDeHora"></param>
        /// <returns></returns>
        public List<CE_BoletoFacturado> GdsBoletosPendientesDePago(Conexion conexion,
                                                                   string esquema,
                                                                   string tipoClienteAgencia,
                                                                   string condicionPagoCliente,
                                                                   int tipoClientePasajero,
                                                                   int idClientePasajero,
                                                                   int idEmpresaSucursal,
                                                                   int marcaEsConsolidador,
                                                                   string listaGds,
                                                                   string listaProveedoresBoletos,
                                                                   string fecha,
                                                                   string antesDeHora)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_tipoclienteagencia", ParameterType.Varchar2, ParameterDirection.Input,  tipoClienteAgencia, 20));
                lparametros.Add(new Parametro("p_condicionpagocliente", ParameterType.Varchar2, ParameterDirection.Input, condicionPagoCliente, 20));
                lparametros.Add(new Parametro("p_tipoclientepasajero", ParameterType.Int32, ParameterDirection.Input, tipoClientePasajero));
                lparametros.Add(new Parametro("p_idclientepasajero", ParameterType.Int32, ParameterDirection.Input, idClientePasajero));
                lparametros.Add(new Parametro("p_idempresasucursal", ParameterType.Int32, ParameterDirection.Input, idEmpresaSucursal));
                lparametros.Add(new Parametro("p_marcaesconsolidador", ParameterType.Int32, ParameterDirection.Input, marcaEsConsolidador));
                lparametros.Add(new Parametro("p_listagds", ParameterType.Varchar2, ParameterDirection.Input, listaGds, 40));
                lparametros.Add(new Parametro("p_listaproveedores", ParameterType.Varchar2, ParameterDirection.Input, listaProveedoresBoletos, 40));
                lparametros.Add(new Parametro("p_fecha", ParameterType.Varchar2, ParameterDirection.Input, fecha, 10));
                lparametros.Add(new Parametro("p_antesdehora", ParameterType.Varchar2, ParameterDirection.Input, antesDeHora, 10));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_BOLETOS_PENDIENTES_DE_PAGO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_BoletoFacturado>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        public List<CE_BoletoFacturado> GdsBoletosRobotAnulacion(Conexion conexion,
                                                                 string esquema,
                                                                 string fecha,
                                                                 int gds,
                                                                 string proveedores)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_Fecha", ParameterType.Varchar2, ParameterDirection.Input, fecha, 20));
                lparametros.Add(new Parametro("p_GDS", ParameterType.Int32, ParameterDirection.Input, gds));
                lparametros.Add(new Parametro("p_Proveedores", ParameterType.Varchar2, ParameterDirection.Input, proveedores, 50));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_BOLETOS_ROBOT_ANULACION");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_BoletoFacturado>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoClienteAgencia"></param>
        /// <param name="condicionPagoCliente"></param>
        /// <param name="tipoClientePasajero"></param>
        /// <param name="idClientePasajero"></param>
        /// <param name="idEmpresaSucursal"></param>
        /// <param name="marcaEsConsolidador"></param>
        /// <param name="listaGds"></param>
        /// <param name="listaProveedoresBoletos"></param>
        /// <param name="fecha"></param>
        /// <param name="antesDeHora"></param>
        /// <returns></returns>
        public List<CE_BoletoFacturado> GdsBoletosPendientesDePago(string tipoClienteAgencia,
                                                                   string condicionPagoCliente,
                                                                   int tipoClientePasajero,
                                                                   int idClientePasajero,
                                                                   int idEmpresaSucursal,
                                                                   int marcaEsConsolidador,
                                                                   string listaGds,
                                                                   string listaProveedoresBoletos,
                                                                   string fecha,
                                                                   string antesDeHora)
        {
            return GdsBoletosPendientesDePago(
                Conexion,
                Esquema,
                tipoClienteAgencia,
                condicionPagoCliente,
                tipoClientePasajero,
                idClientePasajero,
                idEmpresaSucursal,
                marcaEsConsolidador,
                listaGds,
                listaProveedoresBoletos,
                fecha,
                antesDeHora);
        }

        #endregion

        #region "GdsBoletosSinergia"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pseudo"></param>
        /// <param name="pnr"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<CE_BoletoSinergia> GdsBoletosSinergia(Conexion conexion,
                                                          string esquema,
                                                          string pseudo,
                                                          string pnr,
                                                          string fecha)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, pseudo, 20));
                lparametros.Add(new Parametro("p_pnr", ParameterType.Varchar2, ParameterDirection.Input, pnr, 20));
                lparametros.Add(new Parametro("p_fecha", ParameterType.Varchar2, ParameterDirection.Input, fecha, 10));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_BOLETOS_SINERGIA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_BoletoSinergia>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <param name="pnr"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public List<CE_BoletoSinergia> GdsBoletosSinergia(string pseudo,
                                                          string pnr,
                                                          string fecha)
        {
            return GdsBoletosSinergia(Conexion, Esquema, pseudo, pnr, fecha);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool GdsActualizarEstadoBoletoAnulado(Conexion conexion,
                                                     string esquema,
                                                     RQ_AnulaBoletoPTA request)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_numero_de_boleto", ParameterType.Varchar2, ParameterDirection.Input, request.NumeroBoleto, 255));
                lparametros.Add(new Parametro("p_cod_reserva", ParameterType.Varchar2, ParameterDirection.Input, request.PNR, 255));
                lparametros.Add(new Parametro("p_quien_anula", ParameterType.Varchar2, ParameterDirection.Input, request.IdVendedorAnula, 255));
                lparametros.Add(new Parametro("p_id_motivo_anulacion", ParameterType.Varchar2, ParameterDirection.Input, request.IdMotivoAnulacion, 255));
                lparametros.Add(new Parametro("p_fc_void_a_cliente", ParameterType.Int32, ParameterDirection.Input, request.FacturarVoidACliente));
                lparametros.Add(new Parametro("p_Autoriza_no_cobro_void", ParameterType.Varchar2, ParameterDirection.Input, request.AutorizaNoCobroVOID, 255));
                lparametros.Add(new Parametro("p_ConReposicion", ParameterType.Varchar2, ParameterDirection.Input, request.ConReposicion, 255));
                lparametros.Add(new Parametro("p_ROWSAFFECTED", ParameterType.Int32, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_ANULAR_BOLETO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultado y evaluando si NO se realizo la inserción
                return ((lparametros.Find("p_ROWSAFFECTED").Valor != null) && (int.Parse(lparametros.Find("p_ROWSAFFECTED").Valor.ToString()) > 0));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="idGDS"></param>
        /// <returns></returns>
        public List<CE_PseudoGDS> GdsObtenerPseudos(Conexion conexion,
                                                    string esquema,
                                                    int idGDS)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_gds", ParameterType.Int32, ParameterDirection.Input, idGDS));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_PSEUDOS");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_PseudoGDS>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }


        #endregion
    }
}
