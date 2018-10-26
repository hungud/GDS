using System.Collections.Generic;
using System.Data;

using OracleLib;
using OracleLib.Base;
using CoreLib.Generics;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.Boleto;
using EntidadesGDS.General;
using EntidadesGDS.Facturacion;

using BaseDatosLib.Base;

namespace BaseDatosLib.Paquetes
{
    public sealed class PkgGdsModuloPnrPta : Common
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
        public PkgGdsModuloPnrPta(string codigoSeguimiento,
                                  Conexion conexion,
                                  string esquema)
            : base(codigoSeguimiento, conexion, esquema, "PKG_GDS_MODULO_PNR_PTA")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoSeguimiento"></param>
        /// <returns></returns>
        public PkgGdsModuloPnrPta(string codigoSeguimiento)
            : this(codigoSeguimiento, null, null)
        {
        }

        ~PkgGdsModuloPnrPta()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        #region "GdsObtenerIataEmpresa"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="gds"></param>
        /// <param name="pseudo"></param>
        /// <param name="iata"></param>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public void GdsObtenerIataEmpresa(Conexion conexion,
                                          string esquema,
                                          EnumTipoGds gds,
                                          string pseudo,
                                          out string iata,
                                          out string idEmpresa)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_gds", ParameterType.Int32, ParameterDirection.Input, ((int) gds)));
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, pseudo, 255));
                lparametros.Add(new Parametro("p_iata", ParameterType.Varchar2, ParameterDirection.Output, null, 255));
                lparametros.Add(new Parametro("p_idempresa", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_IATA_EMPRESA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // leyendo resultados
                iata = lparametros.Find("p_iata").Valor.TrimOrNull();
                idEmpresa = lparametros.Find("p_idempresa").Valor.TrimOrNull();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gds"></param>
        /// <param name="pseudo"></param>
        /// <param name="iata"></param>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public void GdsObtenerIataEmpresa(EnumTipoGds gds,
                                          string pseudo,
                                          out string iata,
                                          out string idEmpresa)
        {
            GdsObtenerIataEmpresa(Conexion, Esquema, gds, pseudo, out iata, out idEmpresa);
        }

        #endregion

        #region "GdsObtenerTipoStock"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="gds"></param>
        /// <param name="codigoTarifa"></param>
        /// <param name="tipoTarifa"></param>
        /// <returns></returns>
        public string GdsObtenerTipoStock(Conexion conexion,
                                          string esquema,
                                          EnumTipoGds gds,
                                          EnumCodigoTarifa codigoTarifa,
                                          EnumTipoTarifa tipoTarifa)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_gds", ParameterType.Int32, ParameterDirection.Input, ((int) gds)));
                lparametros.Add(new Parametro("p_codigotarifa", ParameterType.Varchar2, ParameterDirection.Input, codigoTarifa.ToString(), 255));
                lparametros.Add(new Parametro("p_tipotarifa", ParameterType.Varchar2, ParameterDirection.Input, tipoTarifa.ToString(), 255));
                lparametros.Add(new Parametro("p_tipostock", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TIPO_STOCK");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // retornando resultado
                return lparametros.Find("p_tipostock").Valor.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gds"></param>
        /// <param name="codigoTarifa"></param>
        /// <param name="tipoTarifa"></param>
        /// <returns></returns>
        public string GdsObtenerTipoStock(EnumTipoGds gds,
                                          EnumCodigoTarifa codigoTarifa,
                                          EnumTipoTarifa tipoTarifa)
        {
            return GdsObtenerTipoStock(Conexion, Esquema, gds, codigoTarifa, tipoTarifa);
        }

        #endregion

        #region "GdsObtenerTransportadores"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public List<CE_Transportador> GdsObtenerTransportadores(Conexion conexion,
                                                                string esquema,
                                                                string transportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TRANSPORTADORES");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_Transportador>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public List<CE_Transportador> GdsObtenerTransportadores(string transportador)
        {
            return GdsObtenerTransportadores(Conexion, Esquema, transportador);
        }

        #endregion

        #region "GdsObtenerTransportadorAsoc"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="nombreTranportador"></param>
        /// <returns></returns>
        public List<CE_Transportador> GdsObtenerTransportadorAsoc(Conexion conexion,
                                                                  string esquema,
                                                                  string nombreTranportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_nombretransportador", ParameterType.Varchar2, ParameterDirection.Input, nombreTranportador, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TRANSPORTADOR_ASOC");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_Transportador>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreTranportador"></param>
        /// <returns></returns>
        public List<CE_Transportador> GdsObtenerTransportadorAsoc(string nombreTranportador)
        {
            return GdsObtenerTransportadorAsoc(Conexion, Esquema, nombreTranportador);
        }

        #endregion

        #region "GdsObtenerTransportadoresPorPrefijo"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="prefijoTransportador"></param>
        /// <returns></returns>
        public List<CE_Transportador> GdsObtenerTransportadoresPorPrefijo(Conexion conexion,
                                                                          string esquema,
                                                                          string prefijoTransportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_prefijo", ParameterType.Varchar2, ParameterDirection.Input, prefijoTransportador, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBT_TRANSPORTADORES_X_PREF");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_Transportador>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefijoTransportador"></param>
        /// <returns></returns>
        public List<CE_Transportador> GdsObtenerTransportadoresPorPrefijo(string prefijoTransportador)
        {
            return GdsObtenerTransportadores(Conexion, Esquema, prefijoTransportador);
        }

        #endregion

        #region "GdsObtenerCliente"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="idCliente"></param>
        /// <param name="subCodigo"></param>
        /// <returns></returns>
        public CE_Cliente GdsObtenerCliente(Conexion conexion,
                                            string esquema,
                                            int idCliente,
                                            int? subCodigo)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, idCliente));
                lparametros.Add(new Parametro("p_idsubCodigo", ParameterType.Int32, ParameterDirection.Input, subCodigo));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_CLIENTE");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_Cliente>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="subCodigo"></param>
        /// <returns></returns>
        public CE_Cliente GdsObtenerCliente(int idCliente,
                                            int subCodigo)
        {
            return GdsObtenerCliente(Conexion, Esquema, idCliente, subCodigo);
        }

        #endregion

        #region "GdsObtenerTipoPasajero"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="codigoTarifa"></param>
        /// <param name="tipoPasajero"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public List<CE_TipoPasajero> GdsObtenerTipoPasajero(Conexion conexion,
                                                            string esquema,
                                                            EnumCodigoTarifa codigoTarifa,
                                                            string tipoPasajero,
                                                            string transportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_tipotarifa", ParameterType.Varchar2, ParameterDirection.Input, codigoTarifa.ToString(), 255));
                lparametros.Add(new Parametro("p_idtipopasajero", ParameterType.Varchar2, ParameterDirection.Input, tipoPasajero, 255));
                lparametros.Add(new Parametro("p_transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TIPO_PASAJERO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_TipoPasajero>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoTarifa"></param>
        /// <param name="tipoPasajero"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public List<CE_TipoPasajero> GdsObtenerTipoPasajero(EnumCodigoTarifa codigoTarifa,
                                                            string tipoPasajero,
                                                            string transportador)
        {
            return GdsObtenerTipoPasajero(Conexion, Esquema, codigoTarifa, tipoPasajero, transportador);
        }

        #endregion

        #region "GdsObtenerCiudad"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="codigoCiudad"></param>
        /// <returns></returns>
        public List<CE_Ciudad> GdsObtenerCiudad(Conexion conexion,
                                                string esquema,
                                                string codigoCiudad)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_codigociudad", ParameterType.Varchar2, ParameterDirection.Input, codigoCiudad, 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_CIUDAD");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_Ciudad>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoCiudad"></param>
        /// <returns></returns>
        public List<CE_Ciudad> GdsObtenerCiudad(string codigoCiudad)
        {
            return GdsObtenerCiudad(Conexion, Esquema, codigoCiudad);
        }

        #endregion

        #region "GdsObtenerTtipoStock"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public int GdsObtenerTtipoStock(Conexion conexion,
                                        string esquema,
                                        string transportador)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("transportador", ParameterType.Varchar2, ParameterDirection.Input, transportador, 255));
                lparametros.Add(new Parametro("p_repeticiones", ParameterType.Int32, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_TIPO_STOCK");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // retornando resultado
                return int.Parse(lparametros.Find("p_repeticiones").Valor.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transportador"></param>
        /// <returns></returns>
        public int GdsObtenerTtipoStock(string transportador)
        {
            return GdsObtenerTtipoStock(Conexion, Esquema, transportador);
        }

        #endregion

        #region "GdsObtenerInterfaceProv"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pseudoConsulta"></param>
        /// <param name="pseudoEmision"></param>
        /// <returns></returns>
        public CE_InterfaceProveedor GdsObtenerInterfaceProv(Conexion conexion,
                                                             string esquema,
                                                             string pseudoConsulta,
                                                             string pseudoEmision)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pseudoconsulta", ParameterType.Varchar2, ParameterDirection.Input, pseudoConsulta));
                lparametros.Add(new Parametro("p_pseudoemision", ParameterType.Varchar2, ParameterDirection.Input, pseudoEmision));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_INTERFACE_PROV");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultado
                    var lresultado = ToNew<CE_InterfaceProveedor>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudoConsulta"></param>
        /// <param name="pseudoEmision"></param>
        /// <returns></returns>
        public CE_InterfaceProveedor GdsObtenerInterfaceProv(string pseudoConsulta,
                                                             string pseudoEmision)
        {
            return GdsObtenerInterfaceProv(Conexion, Esquema, pseudoConsulta, pseudoEmision);
        }

        #endregion

        #region "GdsObtenerPerfilImpresora"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        public string GdsObtenerPerfilImpresora(Conexion conexion,
                                                string esquema,
                                                string pseudo)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_pseudo", ParameterType.Varchar2, ParameterDirection.Input, pseudo, 255));
                lparametros.Add(new Parametro("p_perfil", ParameterType.Varchar2, ParameterDirection.Output, null, 255));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_PERFIL_IMPRESORA");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                conexion.Ejecutar(lprocedimiento, null, ref lparametros);

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // retornando resultado
                return lparametros.Find("p_perfil").Valor.TrimOrNull();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        public string GdsObtenerPerfilImpresora(string pseudo)
        {
            return GdsObtenerPerfilImpresora(Conexion, Esquema, pseudo);
        }

        #endregion

        #region "GdsObtenerFileBoleto"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        public List<CE_Boleto> GdsObtenerFileBoleto(Conexion conexion,
                                                    string esquema,
                                                    string[] boletos)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_boleto", ParameterType.Varchar2, ParameterDirection.Input, string.Join(",", boletos) , 255));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_FILE_BOLETO");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToList<CE_Boleto>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boletos"></param>
        /// <returns></returns>
        public List<CE_Boleto> GdsObtenerFileBoleto(string[] boletos)
        {
            return GdsObtenerFileBoleto(Conexion, Esquema, boletos);
        }

        #endregion

        #region "GdsObtenerFranquiciaConfig"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="esquema"></param>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public CE_FranquiciaConfig GdsObtenerFranquiciaConfig(Conexion conexion,
                                                              string esquema,
                                                              int idCliente)
        {
            Parametros lparametros;

            using (lparametros = new Parametros())
            {
                // contruyendo parametros
                lparametros.Add(new Parametro("p_idcliente", ParameterType.Int32, ParameterDirection.Input, idCliente));
                lparametros.Add(new Parametro("p_cursor", ParameterType.RefCursor, ParameterDirection.Output, null));

                // nombre de procedimiento
                var lprocedimiento = string.Format("{0}.{1}.{2}", esquema, NombrePaquete, "GDS_OBTENER_FRANQUICIA_CONFIG");

                // registrando eventos
                Bitacora.Current.DebugAndInfo(string.Format("Por Ejecutar procedimiento '{0}'", lprocedimiento), new { lparametros = lparametros.ToString() }, CodigoSeguimiento);

                // ejecutando operación
                using (var ldatos = conexion.Obtener(CommandType.StoredProcedure, lprocedimiento, null, ref lparametros))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo(string.Format("Ejecutado procedimiento '{0}'", lprocedimiento), CodigoSeguimiento);

                    // extrayendo resultados
                    var lresultado = ToNew<CE_FranquiciaConfig>(ldatos);

                    // cerrando datos
                    ldatos.Close();

                    return lresultado;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="esquema"></param>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public CE_FranquiciaConfig GdsObtenerFranquiciaConfig(string esquema,
                                                              int idCliente)
        {
            return GdsObtenerFranquiciaConfig(Conexion, Esquema, idCliente);
        }

        #endregion

        #endregion
    }
}
