using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

using CoreWebLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Facturacion;
using EntidadesGDS.Itinerario;
using EntidadesGDS.Boleto;
using EntidadesGDS.Comentario;
using BaseDatosLib.Paquetes;

using SabreLib;
using SabreLib.Herramientas;
using SabreLib.Remark;
using SabreLib.lItinerary;
using SabreLib.Transaction;
using SabreLib.AirTicket;

using GDSLib.Base;
using GDSLib.Utiles;
using GDSLib.PTA;

namespace GDSLib.Sabre
{
    public sealed class Reemision : Common
    {
        // =============================
        // constructores y destructores

        #region "constructores y destructores"

        public Reemision(EnumAplicaciones aplicacion, 
                         string codigoSeguimiento,
                         string codigoEntorno,
                         CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        ~Reemision()
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
        /// <param name="pnr"></param>
        /// <param name="completar"></param>
        /// <param name="reservaRecuperada"></param>
        /// <returns></returns>
        private CE_Estatus RecuperarReserva(string pnr,
                                            bool completar,
                                            out CE_Reserva reservaRecuperada)
        {
            using (var litinerario = new Itinerario(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
            {
                litinerario.Conexion = Conexion;
                litinerario.Esquema = Esquema;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por Ejecutar 'litinerario.Obtener'", new { pnr, completar }, CodigoSeguimiento);

                // recuperando y completando reserva
                var lrespuesta = litinerario.Obtener(pnr, out reservaRecuperada, completar);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'litinerario.Obtener'", new { lrespuesta, reservaRecuperada }, CodigoSeguimiento);

                return lrespuesta;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private void IgnorarTransaccion()
        {
            try
            {
                // instanciando objeto
                using (var lignoreTransaction = new IgnoreTransaction(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lignoreTransaction.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lignoreTransaction.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lignoreTransaction.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lignoreTransaction.Execute'", CodigoSeguimiento);

                    // ejecutando funcionalidad
                    var lrespuesta = lignoreTransaction.Execute();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lignoreTransaction.Execute'", new { lrespuesta }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroBoleto"></param>
        /// <param name="fileBoleto"></param>
        /// <returns></returns>
        private CE_Estatus BuscarFileBoleto(string numeroBoleto,
                                            out CE_Boleto fileBoleto)
        {
            CE_Estatus lrespuesta;

            using (var lboleto = new Boleto(CodigoSeguimiento))
            {
                lboleto.Conexion = Conexion;
                lboleto.Esquema = Esquema;

                CE_Boleto[] lfileBoleto;

                var lnumeroBoleto = numeroBoleto.Substring(3, 10);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lboleto.ObtenerFileBoleto'", new { lnumeroBoleto }, CodigoSeguimiento);

                // obteniendo file de boelto
                lrespuesta = lboleto.ObtenerFileBoleto(new[] { lnumeroBoleto }, out lfileBoleto, false);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lboleto.ObtenerFileBoleto'", new { lrespuesta }, CodigoSeguimiento);

                // leyendo respuesta
                fileBoleto = (((lfileBoleto != null) && lfileBoleto.Any()) ? lfileBoleto[0] : null);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        private CE_FacturaCabecera ExtraerCabeceraFacturacion(CE_Reserva reserva,
                                                              string numeroBoleto)
        {
            CE_FacturaCabecera lresultado = null;

            // buscando en la lista de comentarios
            var lcomentariosFacturacion = reserva.Comentarios
                .Where(c =>
                {
                    if (c.Tipo == EnumTipoComentario.General)
                    {
                        // buscando expresión
                        var lencontrado = Regex.Match(c.Texto, Configuracion.GetRegularExpression("ComentarioFacturacion"));

                        // evaluando si se encontro una coincidencia
                        if (lencontrado.Success)
                        {
                            // evaluando si se boleto a remitir esta presente en el comentario
                            return lencontrado.Groups[6].Value.Equals(numeroBoleto, StringComparison.InvariantCultureIgnoreCase);
                        }
                    }

                    return false;

                })
                .FirstOrDefault();

            if (lcomentariosFacturacion != null)
            {
                // extrayendo grupos
                var lgrupos = Regex.Match(lcomentariosFacturacion.Texto, Configuracion.GetRegularExpression("ComentarioFacturacion"));

                // ejemplos:
                // FACT/FC/0003/FC/002/62921/0123456789012`
                // Group 1.	5-7	`FC`
                // Group 2.	8-12	`0003` -- de agencia
                // Group 3.	13-15	`FC`
                // Group 4.	16-19	`002` -- de nm ** esto lo unico que necesitamos
                // Group 5.	20-25	`62921`
                // Group 6.	26-39	`0123456789012` -- numero de boleto

                lresultado = new CE_FacturaCabecera
                {
                    TipoComprobante = ((EnumTipoComprobanteFacturacion) Enum.Parse(typeof(EnumTipoComprobanteFacturacion), lgrupos.Groups[3].Value)),
                    NumeroSerie = lgrupos.Groups[4].Value,
                    IdFacturaCabecera = lgrupos.Groups[5].Value
                };
            }

            return lresultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="cotizacion"></param>
        /// <param name="facturacionCabecera"></param>
        /// <param name="secuenciaReferencia"></param>
        /// <param name="filetoBoleto"></param>
        /// <returns></returns>
        private bool InsertarInterface(CE_Reserva reserva,
                                       CE_Cotizacion cotizacion, 
                                       CE_FacturaCabecera facturacionCabecera,
                                       CE_SecuenciaReferencia secuenciaReferencia,
                                       CE_Boleto filetoBoleto)
        {
            // -- CABECERA

            // buscando pasajero del PQ (¡¡¡ VERIFICAR SI HABRA SOLO 1 TARIFA CON 1 PASAJERO !!!)
            var lpasajero = reserva.Pasajeros.First(p => p.NumeroPasajero.Equals(cotizacion.Tarifas[0].Pasajeros[0].NumeroPasajero));

            var lcabecera = new CE_InterfaceGeneral
            {
                ID_REFERENCIA = secuenciaReferencia.Referencia,
                ID_SECUENCIA = secuenciaReferencia.Secuencia,

                ID_FILE = filetoBoleto.IdFile,
                ID_FILE_REFERENCIA = null, // filetoBoleto.IdFileReferencia ++  EN ESTE MOMENTO ESTA ENVIANDOSE NULL xq aqui va el FILE para CONDOR
                ID_PUNTO_FACTURAR = filetoBoleto.IdPunto,
                ID_SUCURSAL_FACTURAR = filetoBoleto.IdSucursal,
                ID_COTIZACION = null, // filetoBoleto.IdSucursal ++ POR LO CONVERSADO CON FLAVIO ES NULL xq aqui va el FILE de AGCORP

                ID_CLIENTE = reserva.Cliente.IdCliente,
                ID_SUBCODIGO = reserva.Cliente.IdSubCodigo,
                ID_MONEDA = "USD",
                COD_RESERVA = reserva.PNR,
                //TIPO_DOCUMENTO_IDENTIDAD_A_FC = // DNI / CE / PAS / RUC
                //NUMERO_DOCUMENTO_A_FC = // Numero de  DNI / CE / PAS / RUC
                //NOMBRE_A_FC = reserva.Cliente.NombreCliente,
                //DIRECCION_A_FC = 
                ID_PSEUDO_CITY = reserva.Aplicacion.PseudoEmision,
                ID_EMPRESA = 1, // NUEVOMUNDO
                ID_SUCURSAL = 0,
                TRAE_FCOMISION = 1,
                ID_GDS = 1,
                COMO_EMITIO = 26, // esto se puede obtener luego usando la aplicacion y el uindicador en la reserva de 'esReemision'
                COMO_SOLICITO = 8,
                
                NO_IMPRIME_COMPROBANTE = 1,
                ID_CIUDAD_DESTINO = cotizacion.CiudadDestino.IdCiudad,
                //TEXTO_FC_1 = // PARA REEMISION NO SE UTILIZA
                //TEXTO_FC_2 = // PARA REEMISION NO SE UTILIZA
                //TEXTO_FC_3 = // PARA REEMISION NO SE UTILIZA
                //TEXTO_FC_4 = // PARA REEMISION NO SE UTILIZA
                //TEXTO_FC_5 = // PARA REEMISION NO SE UTILIZA
                /////// CODIGO_VENDEDORWEB = reserva.Cliente.IdVendedorWeb

                //NOMBRES = lpasajero.Nombre, ++ // PARA REEMISION NO SE UTILIZA
                //APELLIDO_PATERNO = lpasajero.Apellido, ++ // PARA REEMISION NO SE UTILIZA
                //NOMBRE_A_FC = string.Format("{0}/{1}", lpasajero.Apellido, lpasajero.Nombre), ++ // PARA REEMISION NO SE UTILIZA
                //TIPO_DOCUMENTO_IDENTIDAD_A_FC = null, ++ // PARA REEMISION NO SE UTILIZA
                //NUMERO_DOCUMENTO_A_FC = lpasajero.NumeroDocumento, ++ // PARA REEMISION NO SE UTILIZA

                FECHA_DE_ALTA = DateTime.Now,
                EMISION_AUTONOMA = 0,
            };

            // evaluando el tipo de tarifa
            switch (cotizacion.TipoTarifa.Codigo)
            {
                case EnumCodigoTarifa.PL:
                    lcabecera.ID_TIPO_DE_COMPROBANTE = "DC";
                    break;

                case EnumCodigoTarifa.PV:
                    lcabecera.ID_TIPO_DE_COMPROBANTE = facturacionCabecera.TipoComprobante.ToString();
                    lcabecera.NUMERO_SERIE = int.Parse(facturacionCabecera.NumeroSerie);
                    lcabecera.ID_FACTURA_CABEZA = int.Parse(facturacionCabecera.IdFacturaCabecera);

                    // ejemplo:  F002/62921 
                    //ID_TIPO_DE_COMPROBANTE = "FC",
                    //NUMERO_SERIE = 002   ---int.Parse(facturacionCabecera.NumeroSerie),
                    //ID_FACTURA_CABEZA =  62921 ----int.Parse(facturacionCabecera.IdFacturaCabecera),
                    break;
            }

            if (lpasajero.TipoDocumento.HasValue)
            {
                lcabecera.TIPO_DOCUMENTO_IDENTIDAD_A_FC =
                    ((lpasajero.TipoDocumento.Value == EnumTipoDocumento.DNI)
                        ? "DNI"
                        : (lpasajero.TipoDocumento.Value == EnumTipoDocumento.Pasaporte) ? "PAS" : "CE");
            }

            var lpagos = reserva.Facturacion.Pagos;

            // buscando forma de pago tarjeta
            var lpagoTarjeta = reserva.Facturacion.Pagos.FirstOrDefault(p => p.TipoFormaPago == EnumTipoFormaPago.CARD);

            if (lpagoTarjeta != null)
            {
                lcabecera.ID_FORMA_DE_PAGO = ((lpagos.Count() == 2) ? "MFP" : lpagos.Any(f => (f.TipoFormaPago == EnumTipoFormaPago.CASH)) ? "CA" : "CC");
                lcabecera.NOMBRE_TITULAR_TARJETA = lpagoTarjeta.Tarjeta.NombreTitular;

                lcabecera.TIPO_DOC_TITULAR_TARJETA =
                    ((lpagoTarjeta.Tarjeta.TipoDocumentoTitular.Value == EnumTipoDocumento.DNI)
                    ? "DNI"
                    : (lpagoTarjeta.Tarjeta.TipoDocumentoTitular.Value == EnumTipoDocumento.Pasaporte) ? "PAS" : "CE");

                lcabecera.NRO_DOC_TITULAR_TARJETA = lpagoTarjeta.Tarjeta.NumeroDocumentoTitular;
                lcabecera.ID_PAIS_EMISION_TARJETA = lpagoTarjeta.Tarjeta.PaisEmision;
                lcabecera.NOMBRE_BANCO_TARJETA = lpagoTarjeta.Tarjeta.NombreBanco;
            }

            // -- DETALLE

            // error con CE_InterfaceDetalle[] evitar y validar arrays
            var ldetalle = new List<CE_InterfaceDetalle>
            {
                new CE_InterfaceDetalle
                {
                    ID_REFERENCIA = secuenciaReferencia.Referencia,
                    ID_SECUENCIA = secuenciaReferencia.Secuencia,
                    ID_GRUPO = ((cotizacion.TipoTarifa.Codigo == EnumCodigoTarifa.PL) ? 3 : 4),

                    ID_PROVEEDOR_GDS = filetoBoleto.IdProveedor, // chequear en doble interfaz

                    //NUMERO_DE_BOLETO = long.Parse(lboleto.NumeroBoleto), -- NO VA 
                    ID_PAX = int.Parse(lpasajero.NumeroPasajero.Substring(0, 1)), // NUMERO DE PASAJERO (EJMPLO: PARA EL CASO DE SABRE 2.1 SOLO SE TOMA EL 2)
                    TIPO_DESCUENTO = "P",
                    COD_RESERVA_LAEREA = reserva.PNR,
                    EN_PNR = 1,
                    ES_TOURCODE_AUTOMATICO = ((cotizacion.TipoTarifa.Codigo == EnumCodigoTarifa.PL) ? 1 : 0),
                    ES_WAIVER = 0,
                    ES_IT = ((cotizacion.TipoTarifa.Codigo == EnumCodigoTarifa.PL) ? 0 : 1),
                    TARIFA_AUXILIAR = ((cotizacion.TipoTarifa.Codigo == EnumCodigoTarifa.PL) ? null : cotizacion.Tarifas[0].FeePta.FeeMaximo.Value.ToString("##.###")) 
                }
            };

            /*
            // evaluando el tipo de tarifa
            if (cotizacion.TipoTarifa.Codigo == EnumCodigoTarifa.PV)
            {
                ldetalle[0].TARIFA_AUXILIAR = cotizacion.Tarifas[0].FeePta.FeeMaximo;
            }
            */

            var lcabeceraXml = XmlHelper.XmlSerializerforOracle(lcabecera, false, false);
            var ldetalleXml = XmlHelper.XmlSerializerforOracle(ldetalle, false, false);

            bool lok;

            using (var lpkgGdsGeneric = new PkgGdsGeneric(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

                Conexion.IniciarTransaccion();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.IniciarTransaccion'", CodigoSeguimiento);

                int lregistrosAfectados;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarFacturacionCabecera'", new { lcabeceraXml }, CodigoSeguimiento);

                // insertando cabecera
                lpkgGdsGeneric.GdsInsertarFacturacionCabecera(Conexion, Esquema, lcabeceraXml, out lregistrosAfectados);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarFacturacionCabecera'", new { lregistrosAfectados }, CodigoSeguimiento);

                lok = (lregistrosAfectados > 0);

                if (lok)
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarFacturacionDetalle'", new { ldetalleXml }, CodigoSeguimiento);

                    // insertando detalle
                    lpkgGdsGeneric.GdsInsertarFacturacionDetalle(Conexion, Esquema, ldetalleXml, out lregistrosAfectados);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarFacturacionDetalle'", new { lregistrosAfectados }, CodigoSeguimiento);

                    lok = (lregistrosAfectados > 0);
                }

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'Conexion.FinalizarTransaccion'", CodigoSeguimiento);

                Conexion.FinalizarTransaccion((!lok));

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'Conexion.FinalizarTransaccion'", new { lok }, CodigoSeguimiento);
            }

            return lok;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="cotizacion"></param>
        /// <param name="fileBoleto"></param>
        /// <param name="facturacionCabecera"></param>
        /// <param name="secuenciaReferencia"></param>
        /// <returns></returns>
        private bool InsertarInformacionInterface(CE_Reserva reserva,
                                                  CE_Cotizacion cotizacion,
                                                  CE_Boleto fileBoleto,  
                                                  ref CE_FacturaCabecera facturacionCabecera,
                                                  out CE_SecuenciaReferencia secuenciaReferencia)
        {
            using (var lfacturacion = new Facturacion(CodigoSeguimiento))
            {
                lfacturacion.Conexion = Conexion;
                lfacturacion.Esquema = Esquema;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lfacturacion.ObtenerSecuenciaReferencia'", CodigoSeguimiento);

                // obteniendo secuencia referencia
                lfacturacion.ObtenerSecuenciaReferencia(out secuenciaReferencia);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lfacturacion.ObtenerSecuenciaReferencia'", new { secuenciaReferencia }, CodigoSeguimiento);

                // evaluando si no se ha proporcionado los correlativos de facturación
                if (((cotizacion.TipoTarifa.Codigo == EnumCodigoTarifa.PV) && (cotizacion.TipoTarifa.Tipo == EnumTipoTarifa.IT))
                    && (facturacionCabecera == null))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lfacturacion.ObtenerCorrelativoFacturacion'", new { reserva.Facturacion.Punto, reserva.Facturacion.IdSucursal, reserva.Facturacion.Cabecera.TipoComprobante }, CodigoSeguimiento);

                    // obteniendo secuencia referencia
                    lfacturacion.ObtenerCorrelativoFacturacion(
                        reserva.Facturacion.Punto.Value,
                        reserva.Facturacion.IdSucursal.Value,
                        reserva.Facturacion.Cabecera.TipoComprobante.Value,
                        out facturacionCabecera);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lfacturacion.ObtenerCorrelativoFacturacion'", new { facturacionCabecera }, CodigoSeguimiento);
                }
            }

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar '.InsertarInterface'", new { reserva, cotizacion, facturacionCabecera, secuenciaReferencia, fileBoleto }, CodigoSeguimiento);

            // insertar interface general y detalle
            var lrespuesta = InsertarInterface(reserva, cotizacion, facturacionCabecera, secuenciaReferencia, fileBoleto);

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado '.InsertarInterface'", new { lrespuesta }, CodigoSeguimiento);

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="facturaCabecera"></param>
        /// <param name="facturaCliente"></param>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        private CE_Estatus AnadirComentarioFacturacion(CE_FacturaCabecera facturaCabecera,
                                                       CE_FacturaCliente facturaCliente,
                                                       string numeroBoleto)
        {
            CE_Estatus lrespuesta;

            // instanciando objeto
            using (var laddRemark = new AddRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'laddRemark.Prepare'", CodigoSeguimiento);

                // preparar servicio
                laddRemark.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Prepare'", CodigoSeguimiento);

                // ejecutando funcionalidad
                lrespuesta = laddRemark.Execute(new[]
                {
                    new CE_Comentario
                    {
                        Tipo = EnumTipoComentario.General,
                        Texto = string.Format(
                            "FACT/{0}/{1}/{2}/{3}/{4}/{5}", 
                                facturaCliente.TipoComprobante,
                                facturaCliente.NumeroComprobante,
                                facturaCabecera.TipoComprobante,
                                facturaCabecera.NumeroSerie,
                                facturaCabecera.IdFacturaCabecera,
                                numeroBoleto
                            )
                    }
                });
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <returns></returns>
        private CE_Estatus BorrarComentariosSecuenciaReferencia(CE_Reserva reserva)
        {
            var lrespuesta = new CE_Estatus(false);

            // filtrando lista
            var lcomentariosSecuenciaReferencia = reserva.Comentarios
                .Where(c => ((c.Tipo == EnumTipoComentario.General) && c.Texto.Contains(@"X/-REF")))
                    .Select(c => c.RPH.Value)
                        .ToArray();

            // evaluando si se encontrarón comentarios de secuencia referencia
            if (lcomentariosSecuenciaReferencia.Any())
            {
                // instanciando objeto
                using (var lmodifyRemark = new ModifyRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lmodifyRemark.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Borrar'", new { lcomentariosSecuenciaReferencia }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lmodifyRemark.Borrar(lcomentariosSecuenciaReferencia);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Borrar'", new { lrespuesta }, CodigoSeguimiento);
                }
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reserva"></param>
        /// <param name="numeroBoleto"></param>
        /// <returns></returns>
        private CE_Estatus BorrarComentariosFacturacion(CE_Reserva reserva,
                                                        string numeroBoleto)
        {
            var lrespuesta = new CE_Estatus(false);

            // buscando en la lista de comentarios
            var lcomentariosFacturacion = reserva.Comentarios
                .Where(c =>
                {
                    if (c.Tipo == EnumTipoComentario.General)
                    {
                        // buscando expresión
                        var lencontrado = Regex.Match(c.Texto, Configuracion.GetRegularExpression("ComentarioFacturacion"));

                        // evaluando si se encontro una coincidencia
                        if (lencontrado.Success)
                        {
                            // evaluando si se boleto a remitir esta presente en el comentario
                            return lencontrado.Groups[6].Value.Equals(numeroBoleto, StringComparison.InvariantCultureIgnoreCase);
                        }
                    }

                    return false;

                })
                .Select(c => c.RPH.Value)
                    .ToArray();

            // evaluando si se encontrarón comentarios de facturacion
            if (lcomentariosFacturacion.Any())
            {
                // instanciando objeto
                using (var lmodifyRemark = new ModifyRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lmodifyRemark.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmodifyRemark.Borrar'", new { lcomentariosFacturacion }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lmodifyRemark.Borrar(lcomentariosFacturacion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmodifyRemark.Borrar'", new { lrespuesta }, CodigoSeguimiento);
                }
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CE_Estatus BorrarLineaPrecioFutura()
        {
            CE_Estatus lrespuesta;

            // instanciando objeto
            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.Prepare'", CodigoSeguimiento);

                // preparar servicio
                lsabreCommand.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.Prepare'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.BorrarLineaPrecioFutura'", CodigoSeguimiento);

                // ejecutando funcionalidad
                lrespuesta = lsabreCommand.BorrarLineaPrecioFutura();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.BorrarLineaPrecioFutura'", new { lrespuesta }, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoTipotarifa"></param>
        /// <param name="reserva"></param>
        /// <param name="seleccionarPasajero"></param>
        /// <returns></returns>
        private CE_Estatus ModificarDocumentoPasajero(EnumCodigoTarifa codigoTipotarifa, 
                                                      CE_Reserva reserva,
                                                      int seleccionarPasajero)
        {
            CE_Estatus lrespuesta;

            // instanciando objeto
            using (var lyravelItineraryModifyInfo = new TravelItineraryModifyInfo(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lyravelItineraryModifyInfo.Prepare'", CodigoSeguimiento);

                // preparar servicio
                lyravelItineraryModifyInfo.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lyravelItineraryModifyInfo.Prepare'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lyravelItineraryModifyInfo.Execute'", new { reserva.Cliente, pasajero = reserva.Pasajeros[seleccionarPasajero], codigoTipotarifa, reserva.Facturacion }, CodigoSeguimiento);

                // ejecutando funcionalidad
                lrespuesta = lyravelItineraryModifyInfo.Execute(
                    new RQ_ActualizarPasajeros
                    {
                        IdCliente = reserva.Cliente.IdCliente,
                        Pasajeros = new [] { reserva.Pasajeros[seleccionarPasajero] },
                        NumeroComprobante = ((codigoTipotarifa == EnumCodigoTarifa.PL)
                            ? null
                            : string.Format("{0}{1}", reserva.Facturacion.Cliente.TipoComprobante, reserva.Facturacion.Cliente.NumeroComprobante))
                    });

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lyravelItineraryModifyInfo.Execute'", new { lrespuesta }, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="secuenciaReferencia"></param>
        /// <returns></returns>
        private CE_Estatus AnadirComentarioSecuenciaReferencia(CE_SecuenciaReferencia secuenciaReferencia)
        {
            CE_Estatus lrespuesta;

            // instanciando objeto
            using (var laddRemark = new AddRemark(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'laddRemark.Prepare'", CodigoSeguimiento);

                // preparar servicio
                laddRemark.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Prepare'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'laddRemark.Execute'", new { EnumTipoComentario.General, secuenciaReferencia }, CodigoSeguimiento);

                // ejecutando funcionalidad
                lrespuesta = laddRemark.Execute(new[]
                {
                    new CE_Comentario
                    {
                        Tipo = EnumTipoComentario.General,
                        Texto = string.Format("X/-REF*{0}/{1}", secuenciaReferencia.Referencia, secuenciaReferencia.Secuencia)
                    }
                });

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'laddRemark.Execute'", new { lrespuesta }, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cerrar"></param>
        /// <returns></returns>
        private CE_Estatus GrabarCambios(bool cerrar)
        {
            CE_Estatus lrespuesta;

            // instanciando objeto
            using (var lendTransaction = new EndTransaction(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lendTransaction.Prepare'", CodigoSeguimiento);

                // preparar servicio
                lendTransaction.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lendTransaction.Prepare'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lendTransaction.FirmarCerrar' | 'lendTransaction.Firmar'", new { cerrar }, CodigoSeguimiento);

                // evaluando que funcionalidad ejecutar
                lrespuesta = (cerrar ? lendTransaction.FirmarCerrar() : lendTransaction.Firmar());

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lendTransaction.FirmarCerrar' | 'lendTransaction.Firmar'", new { lrespuesta }, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns></returns>
        private string ObtenerPerfilImpresora(string pseudo)
        {
            // registrando eventos
            Bitacora.Current.DebugAndInfo("Por ejecutar 'PkgGdsModuloPnrPta.GdsObtenerPerfilImpresora'", new { pseudo }, CodigoSeguimiento);

            var lperfilImpresora = (new PkgGdsModuloPnrPta(CodigoSeguimiento).GdsObtenerPerfilImpresora(Conexion, Esquema, pseudo));

            // registrando eventos
            Bitacora.Current.DebugAndInfo("Ejecutado 'PkgGdsModuloPnrPta.GdsObtenerPerfilImpresora'", new { lperfilImpresora }, CodigoSeguimiento);

            return lperfilImpresora.Replace("PPS", string.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="perfilImpresora"></param>
        /// <param name="reserva"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        private CE_Estatus EjecutarReemision(string perfilImpresora,
                                             CE_Reserva reserva,
                                             out CE_Boleto[] boletos)
        {
            CE_Estatus lrespuesta;

            using (var lenhancedAirTicket = new EnhancedAirTicket(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lenhancedAirTicket.Prepare'", CodigoSeguimiento);

                // preparar servicio
                lenhancedAirTicket.Prepare();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lenhancedAirTicket.Prepare'", CodigoSeguimiento);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lenhancedAirTicket.Reemitir'", new { perfilImpresora, reserva }, CodigoSeguimiento);

                // ejecutando funcionalidad
                lrespuesta = lenhancedAirTicket.Reemitir(perfilImpresora, reserva, out boletos);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lenhancedAirTicket.Reemitir'", new { lrespuesta }, CodigoSeguimiento);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="salida"></param>
        /// <returns></returns>
        public CE_Estatus EjecutarModuloComercial(CE_Reserva parametros,
                                                  out CE_Reserva salida)
        {
            CE_Estatus lrespuesta;

            salida = null;

            try
            {
                if (parametros.Aplicacion == null)
                {
                    throw new InternalException("No ha proporcionado los datos de Aplicación");
                }

                if (parametros.Cliente == null)
                {
                    throw new InternalException("No ha proporcionado los datos Cliente");
                }

                if ((parametros.Pasajeros == null) || (parametros.Pasajeros.Count(p => (p.Seleccionado ?? false)) != 1))
                {
                    throw new InternalException("No ha proporcionado un único Pasajero seleccionado");
                }

                if ((parametros.Itinerario == null) || (parametros.Itinerario.Segmentos == null) || (!parametros.Itinerario.Segmentos.Any(p => (p.Seleccionado ?? false))))
                {
                    throw new InternalException("No ha proporcionado ningún Segmento seleccionado");
                }

                if ((parametros.Cotizaciones == null) || (parametros.Cotizaciones.Count(c => (c.Seleccionada ?? false)) != 1))
                {
                    throw new InternalException("No ha proporcionado un única Cotización seleccionada");
                }

                // ====

                // **
                // ** INICIANDO RECUPERAR lA RESERVA Y COMPLETAR CON LOS PARAMETROS **
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.RecuperarReserva'", new { parametros.PNR  }, CodigoSeguimiento);

                CE_Reserva lreservaIniclal;

                // recuperando y completando reserva
                lrespuesta = RecuperarReserva(parametros.PNR, true, out lreservaIniclal);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.RecuperarReserva'", new { lrespuesta, lreservaIniclal }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo recuperar y completar la Reserva", lrespuesta.Mensajes);
                }

                // **
                // ** ACTUALIZANDO LA RESERVA OBTENIDA Y COMPLETADA CON LOS PARAMETROS RECIBIDOS **
                // **

                lreservaIniclal.Aplicacion = parametros.Aplicacion;
                lreservaIniclal.Aplicacion.TipoGds = EnumTipoGds.Sabre;

                lreservaIniclal.Cliente = new CE_Cliente
                {
                    IdCliente = parametros.Cliente.IdCliente,
                    NombreCliente = parametros.Cliente.NombreCliente,
                    IdPromotor = parametros.Cliente.IdPromotor,
                    IdSubCodigo = parametros.Cliente.IdSubCodigo,
                    IdTipoCliente = parametros.Cliente.IdTipoCliente,
                    IdCondicionPago = parametros.Cliente.IdCondicionPago
                };

                // obteniendo pasajero seleccionado de los parametros - #1
                var lpasajeroSeleccionado = parametros.Pasajeros.First(p => (p.Seleccionado ?? false));

                // buscando indice de pasajero a seleccionar en la reserva
                var lseleccionarPasajero = Array.FindIndex(lreservaIniclal.Pasajeros, p => p.NumeroPasajero.Equals(lpasajeroSeleccionado.NumeroPasajero));

                lreservaIniclal.Pasajeros[lseleccionarPasajero].Seleccionado = true;

                // obteniendo cotizacion seleccionada de los parametros
                var lcotizacionSeleccionada = parametros.Cotizaciones.First(c => (c.Seleccionada ?? false));

                // actualizando los segmentos seleccionados en la reserva obtenida
                lreservaIniclal.Itinerario.Segmentos = 
                    lreservaIniclal.Itinerario.Segmentos.Select(s1 =>
                    {
                        if (parametros.Itinerario.Segmentos.Any(s2 => ((s2.Seleccionado ?? false) && s2.NumeroSegmento.Equals(s1.NumeroSegmento))))
                        {
                            s1.Seleccionado = true;
                        }

                        return s1;
                    }).ToArray();

                lreservaIniclal.Facturacion = parametros.Facturacion;

                // **
                // ** VERIFICANDO DOCS Y DOCS **
                // **

                using (var litinerario = new Itinerario(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
                {
                    // extrayendo segmentos seleccionados
                    var llistaSegmentos = lreservaIniclal.Itinerario.Segmentos.Where(s => (s.Seleccionado ?? false)).Select(s => s.NumeroSegmento.ToString()).ToArray();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'litinerario.VerificarDocsFoids'", new { lreservaIniclal, llistaSegmentos }, CodigoSeguimiento);

                    // realizando verificacion
                    litinerario.VerificarDocsFoids(lreservaIniclal, llistaSegmentos, ref lreservaIniclal.Pasajeros[lseleccionarPasajero]);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'litinerario.VerificarDocsFoids'", CodigoSeguimiento);
                }

                // **
                // ** REALIZANDO COTIZACION **
                // **

                CE_Cotizacion lcotizacion;

                using (var litinerario = new Itinerario(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
                {
                    litinerario.Conexion = Conexion;
                    litinerario.Esquema = Esquema;

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'litinerario.ObtenerCotizacion'", new { lcotizacionSeleccionada.LineasValidadoras[0].CodigoAerolinea, parametros }, CodigoSeguimiento);

                    // cotizando
                    lrespuesta = litinerario.ObtenerCotizacion(
                        new RQ_ObtenerCotizaciones
                        {
                            LineaValidadora = lcotizacionSeleccionada.LineasValidadoras[0].CodigoAerolinea,
                            CodigoMoneda = parametros.Aplicacion.CodigoMoneda,
                            Reemision = true,
                            Pasajeros = parametros.Pasajeros,
                            Segmentos = parametros.Itinerario.Segmentos
                        },
                        out lcotizacion);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'litinerario.ObtenerCotizacion'", new { lrespuesta, lcotizacion }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lrespuesta.Ok)
                    {
                        throw new InternalException("No se pudo realizar la cotización para esta Reemisión", lrespuesta.Mensajes);
                    }

                    lcotizacion.Seleccionada = true;
                    lcotizacion.TipoTarifa = lcotizacionSeleccionada.TipoTarifa;
                    lcotizacion.LineasValidadoras[0].Seleccionada = true;
                }

                var lcotizaciones = lreservaIniclal.Cotizaciones.ToList();
                lcotizaciones.Add(lcotizacion);
                
                var lreservaFinal = lreservaIniclal;
                lreservaFinal.Cotizaciones = lcotizaciones.ToArray();

                // **
                // ** MODULO COMERCIAL
                // **

                using (var lmoduloComercial = new ComisionFee(CodigoSeguimiento))
                {
                    lmoduloComercial.Conexion = Conexion;
                    lmoduloComercial.Esquema = Esquema;

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lmoduloComercial.ProcesandoComisionesFees'", new { lreservaIniclal }, CodigoSeguimiento);

                    // ejecutando modulo comercial (comisiones y/o fee)
                    lrespuesta = lmoduloComercial.ProcesandoPreVenta(lreservaIniclal, out lreservaFinal);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lmoduloComercial.ProcesandoComisionesFees'", new { lrespuesta, lreservaFinal }, CodigoSeguimiento);
                }

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo ejecutar el Módulo Comercial para la Reserva", lrespuesta.Mensajes);
                }

                salida = lreservaFinal;

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                salida = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, salida }, CodigoSeguimiento);

                salida = null;

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public CE_Estatus ConfirmarPQ(CE_Reserva parametros)
        {
            CE_Estatus lrespuesta;

            try
            {
                // **
                // ** REALIZANDO CONFIRMACION DE PQ **

                // instanciando objeto
                using (var lautomatedExchanges = new AutomatedExchanges(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lautomatedExchanges.Prepare'", CodigoSeguimiento);

                    // preparar servicio
                    lautomatedExchanges.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lautomatedExchanges.Prepare'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lautomatedExchanges.Confirmar'", new { parametros }, CodigoSeguimiento);

                    // ejecutando funcionalidad
                    lrespuesta = lautomatedExchanges.Confirmar(parametros);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lautomatedExchanges.Confirmar'", new { lrespuesta }, CodigoSeguimiento);
                }

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo Confirmar el PQ", lrespuesta.Mensajes);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="boletos"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerCompletarReemitir(CE_Reserva parametros,
                                                   out CE_Boleto[] boletos)
        {
            CE_Estatus lrespuesta = null;
            CE_Reserva lreservaIniclal = null;

            var lignorar = false;
            var lignorarErrores = false;

            boletos = null;

            try
            {
                if (parametros.Aplicacion == null)
                {
                    throw new InternalException("No ha proporcionado los datos de Aplicación para esta Reemisión");
                }

                if (parametros.Cliente == null)
                {
                    throw new InternalException("No ha proporcionado los datos Cliente para esta Reemisión");
                }

                if (parametros.Usuario == null)
                {
                    throw new InternalException("No ha proporcionado los datos Usuario para esta Reemisión");
                }

                if ((parametros.Pasajeros == null) || (parametros.Pasajeros.Count(p => (p.Seleccionado ?? false)) != 1))
                {
                    throw new InternalException("No ha proporcionado un único Pasajero seleccionado para esta Reemisión");
                }

                if ((parametros.Itinerario == null) || (parametros.Itinerario.Segmentos == null) || (!parametros.Itinerario.Segmentos.Any(p => (p.Seleccionado ?? false))))
                {
                    throw new InternalException("No ha proporcionado ningún Segmento seleccionado para esta Reemisión");
                }

                if ((parametros.Cotizaciones == null) || (parametros.Cotizaciones.Count(c => (c.Seleccionada ?? false)) != 1))
                {
                    throw new InternalException("No ha proporcionado un única Cotización seleccionada para esta Reemisión");
                }

                if ((parametros.Boletos == null) || (parametros.Boletos.Count(p => (p.Seleccionado ?? false)) != 1))
                {
                    throw new InternalException("No ha proporcionado un único Boleto seleccionado para esta Reemisión");
                }

                // ====

                // **
                // ** CAMBIANDO PSEUDO - TRIPLEANDO **
                // **

                using (var lherramienta = new Herramienta(Aplicacion.Value, CodigoSeguimiento, null, Sesion))
                {
                    bool lestaTripleado;

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.TripleadoEn'", new { parametros.Aplicacion.PseudoEmision }, CodigoSeguimiento);

                    // cambiando de pseudo
                    lrespuesta = lherramienta.TripleadoEn(parametros.Aplicacion.PseudoEmision, out lestaTripleado);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.TripleadoEn'", new { lrespuesta, lestaTripleado }, CodigoSeguimiento);

                    if (!lrespuesta.Ok)
                    {
                        throw new InternalException("No se pudo Comprobar el cambio de Pseudo", lrespuesta.Mensajes);
                    }

                    // evaluando que no este actualmente tripleado en el pseudo de emisión
                    if (!lestaTripleado)
                    {
                        CE_Session lsession;

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lherramienta.CambiarContexto'", new { parametros.Aplicacion.PseudoEmision }, CodigoSeguimiento);

                        // cambiando de pseudo
                        lrespuesta = lherramienta.CambiarContexto(parametros.Aplicacion.PseudoEmision, out lsession);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lherramienta.CambiarContexto'", new { lrespuesta, lsession }, CodigoSeguimiento);

                        // evaluando si la operación NO se pudo llevar acabo
                        if (!lrespuesta.Ok)
                        {
                            throw new InternalException("No se pudo Cambiar de Pseudo", lrespuesta.Mensajes);
                        }

                        // actualizando session
                        Sesion = lsession;
                    }
                }

                // ===

                // **
                // ** RECUPERANDO lA RESERVA Y COMPLETAR CON LOS PARAMETROS **
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.RecuperarReserva'", new { parametros.PNR, completar = true }, CodigoSeguimiento);

                // recuperando y completando reserva
                lrespuesta = RecuperarReserva(parametros.PNR, true, out lreservaIniclal);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.RecuperarReserva'", new { lrespuesta, lreservaIniclal }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo recuperar y completar la Reserva", lrespuesta.Mensajes);
                }

                // ===

                // **
                // ** ACTUALIZANDO LA RESERVA OBTENIDA Y COMPLETADA CON LOS PARAMETROS RECIBIDOS **
                // **

                lreservaIniclal.EsReemision = true;
                lreservaIniclal.EmitirEMDPorCambioTarifa = true;
                lreservaIniclal.Aplicacion = parametros.Aplicacion;
                lreservaIniclal.Aplicacion.TipoGds = EnumTipoGds.Sabre;

                lreservaIniclal.Usuario = new CE_Usuario
                {
                    IdVendedorPta = parametros.Usuario.IdVendedorPta
                };

                lreservaIniclal.Cliente = new CE_Cliente
                {
                    IdCliente = parametros.Cliente.IdCliente,
                    NombreCliente = parametros.Cliente.NombreCliente,
                    IdPromotor = parametros.Cliente.IdPromotor,
                    IdSubCodigo = parametros.Cliente.IdSubCodigo,
                    IdTipoCliente = parametros.Cliente.IdTipoCliente,
                    IdCondicionPago = parametros.Cliente.IdCondicionPago
                };

                // obteniendo pasajero seleccionado de los parametros
                var lpasajeroSeleccionado = parametros.Pasajeros.First(p => (p.Seleccionado ?? false));

                // buscando indice de pasajero a seleccionar en la reserva
                var lseleccionarPasajero = Array.FindIndex(lreservaIniclal.Pasajeros, p => p.NumeroPasajero.Equals(lpasajeroSeleccionado.NumeroPasajero));

                lreservaIniclal.Pasajeros[lseleccionarPasajero].Seleccionado = true;
                lreservaIniclal.Pasajeros[lseleccionarPasajero].TipoPasajero = lpasajeroSeleccionado.TipoPasajero;
                lreservaIniclal.Pasajeros[lseleccionarPasajero].TipoDocumento = lpasajeroSeleccionado.TipoDocumento;
                lreservaIniclal.Pasajeros[lseleccionarPasajero].NumeroDocumento = lpasajeroSeleccionado.NumeroDocumento;
                lreservaIniclal.Pasajeros[lseleccionarPasajero].Sexo = lpasajeroSeleccionado.Sexo;
                lreservaIniclal.Pasajeros[lseleccionarPasajero].FechaNacimiento = lpasajeroSeleccionado.FechaNacimiento;
                lreservaIniclal.Pasajeros[lseleccionarPasajero].RUC = lpasajeroSeleccionado.RUC;

                // obteniendo cotizacion seleccionada de los parametros
                var lcotizacionSeleccionada = parametros.Cotizaciones.First(c => (c.Seleccionada ?? false));

                // buscando la última cotización de reemisión con número de pq identico al parametro recibido
                var lseleccionarCotizacion =
                    lreservaIniclal.Cotizaciones.ToList()
                        .FindLastIndex(
                            c => ((c.Reemision ?? false) && c.NumeroPQ.Equals(lcotizacionSeleccionada.NumeroPQ)));

                if (lseleccionarCotizacion < 0)
                {
                    throw new InternalException("El número de Cotización proporcionada es inválida, vuelva a realizar la cotización");
                }

                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Seleccionada = true;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Reemision = true;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Iata = parametros.Cotizaciones[0].Iata;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].IdEmpresa = parametros.Cotizaciones[0].IdEmpresa;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Pseudo = parametros.Cotizaciones[0].Pseudo;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].LineasValidadoras = parametros.Cotizaciones[0].LineasValidadoras;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].CiudadDestino = parametros.Cotizaciones[0].CiudadDestino;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoStock = parametros.Cotizaciones[0].TipoStock;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoTarifa = parametros.Cotizaciones[0].TipoTarifa;

                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Tarifas[0].BaseTarifaria = parametros.Cotizaciones[0].Tarifas[0].BaseTarifaria;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Tarifas[0].CantidadTipoPasajero = parametros.Cotizaciones[0].Tarifas[0].CantidadTipoPasajero;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Tarifas[0].ComisionPta = parametros.Cotizaciones[0].Tarifas[0].ComisionPta;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Tarifas[0].FeePta = parametros.Cotizaciones[0].Tarifas[0].FeePta;
                lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Tarifas[0].TipoPasajero = parametros.Cotizaciones[0].Tarifas[0].TipoPasajero;

                // obteniendo boleto seleccionado de los parametros
                var lboletoSeleccionado = parametros.Boletos.First(p => (p.Seleccionado ?? false));

                // buscando indice de boleto a seleccionar en la reserva
                var lseleccionarBoleto = Array.FindIndex(lreservaIniclal.Boletos, p => p.NumeroBoleto.Equals(lboletoSeleccionado.NumeroBoleto));

                lreservaIniclal.Boletos[lseleccionarBoleto].Seleccionado = true;
                lreservaIniclal.Facturacion = parametros.Facturacion;

                if (!lreservaIniclal.Aplicacion.PseudoEmision.Trim().Equals(lreservaIniclal.Cotizaciones[lseleccionarCotizacion].Pseudo.Trim(), StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new InternalException("El Pseudo de Emisión no es el mismo que el Pseudo de Cotización");
                }

                // ===

                // **
                // ** BUSCANDO FILE DE BOLETO SELECCIONADO **
                // **

                CE_Boleto lfileBoleto;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.BuscarFileBoleto'", new { lboletoSeleccionado.NumeroBoleto }, CodigoSeguimiento);

                // buscando file de boleto
                lrespuesta = BuscarFileBoleto(lboletoSeleccionado.NumeroBoleto, out lfileBoleto);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.BuscarFileBoleto'", new { lrespuesta, lfileBoleto }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if ((!lrespuesta.Ok) || (lfileBoleto == null))
                {
                    throw new InternalException("El Boleto Orgiinal no se encuentra facturado, DEBE de realizar la Facturación antes de la Reemisión", lrespuesta.Mensajes);
                }

                // ===

                // **
                // ** VERIFICANDO SI EXISTEN COMENTARIOS DE FACTURACIÓN EN LA RESERVA
                // **

                CE_FacturaCabecera lfacturacionCabecera = null;

                // si la reserva es privada se busca si existe un comentario con los datos de facturación
                if (lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoTarifa.Codigo == EnumCodigoTarifa.PV)
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.ExtraerCabeceraFacturacion'", new { lreservaIniclal, lboletoSeleccionado.NumeroBoleto }, CodigoSeguimiento);

                    // extrayendo los datos de facturación
                    lfacturacionCabecera = ExtraerCabeceraFacturacion(lreservaIniclal, lboletoSeleccionado.NumeroBoleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.ExtraerCabeceraFacturacion'", new { lfacturacionCabecera }, CodigoSeguimiento);
                }

                // ===

                // **
                // ** INSERTANDO INTERFACES
                // **

                CE_SecuenciaReferencia lsecuenciaReferencia;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'InsertarInformacionInterface.Execute'", new { lreservaIniclal, cotizacion = lreservaIniclal.Cotizaciones[lseleccionarCotizacion], lfileBoleto }, CodigoSeguimiento);

                // insertando interfaces
                var lok = InsertarInformacionInterface(
                    lreservaIniclal,
                    lreservaIniclal.Cotizaciones[lseleccionarCotizacion],
                    lfileBoleto,
                    ref lfacturacionCabecera,
                    out lsecuenciaReferencia);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.InsertarInformacionInterface'", new { lok, lsecuenciaReferencia }, CodigoSeguimiento);

                if (!lok)
                {
                    throw new InternalException("No se pudo insertar la información de Interfaces para la Reserva", lrespuesta.Mensajes);
                }

                // si la reserva es privada se actualiza inmediatamente la reserva para guardar los datos de facturación
                if (lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoTarifa.Codigo == EnumCodigoTarifa.PV)
                {
                    // ===

                    // **
                    // ** ANADIR COMENTARIOS DE FACTURACION
                    // **

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.AnadirComentarioFacturacion'", new { lfacturacionCabecera, lreservaIniclal.Facturacion.Cliente, lboletoSeleccionado.NumeroBoleto }, CodigoSeguimiento);

                    // insertar comentario de facturacion
                    lrespuesta = AnadirComentarioFacturacion(lfacturacionCabecera, lreservaIniclal.Facturacion.Cliente, lboletoSeleccionado.NumeroBoleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.AnadirComentarioFacturacion'", new { lrespuesta }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lrespuesta.Ok)
                    {
                        throw new InternalException("No se pudo insertar el Comentario de facturacion", lrespuesta.Mensajes);
                    }

                    // ===

                    // **
                    // ** GRABAR CAMBIOS
                    // **

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.GrabarCambios'", new { cerrar = false }, CodigoSeguimiento);

                    lrespuesta = GrabarCambios(false);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.GrabarCambios'", new { lrespuesta }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lrespuesta.Ok)
                    {
                        throw new InternalException("No se pudo Firmar la transacción", lrespuesta.Mensajes);
                    }
                }

                // ===

                // **
                // ** BORRAR COMENTARIOS DE SECUENCIA REFERENCIA
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.BorrarComentariosSecuenciaReferencia'", new { lreservaIniclal }, CodigoSeguimiento);

                // borrando los comentarios de secuencia referencia
                lrespuesta = BorrarComentariosSecuenciaReferencia(lreservaIniclal);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.BorrarComentariosSecuenciaReferencia'", new { lrespuesta }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo borrar los Comentarios de Secuencia Referencia", lrespuesta.Mensajes);
                }

                // ===

                // **
                // ** BORRAR LINEAS PRECIO FUTURA
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.BorrarLineaPrecioFutura'", CodigoSeguimiento);

                // borrar linea de precio futura
                lrespuesta = BorrarLineaPrecioFutura();

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.BorrarLineaPrecioFutura'", new { lrespuesta }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo borrar la Linea de Precio Futura", lrespuesta.Mensajes);
                }

                // ===

                // a partir de aqui se puede ignorar
                lignorar = true;

                // **
                // ** MODIFICAR DOCUMENTOS PASAJEROS
                // **

                // evaluando si se puede modificar el documento del pasajero
                if ((lreservaIniclal.Pasajeros[lseleccionarPasajero].TipoDocumento.HasValue 
                    && (!string.IsNullOrWhiteSpace(lreservaIniclal.Pasajeros[lseleccionarPasajero].NumeroDocumento)))
                        || (!string.IsNullOrWhiteSpace(lreservaIniclal.Pasajeros[lseleccionarPasajero].RUC)))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.ModificarDocumentoPasajero'", new { lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoTarifa.Codigo, lreservaIniclal, lseleccionarPasajero }, CodigoSeguimiento);

                    // modificando documento de pasajero (tipo documento / # documento )
                    lrespuesta = ModificarDocumentoPasajero(lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoTarifa.Codigo.Value, lreservaIniclal, lseleccionarPasajero);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.ModificarDocumentoPasajero'", new { lrespuesta }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lrespuesta.Ok)
                    {
                        throw new InternalException("No se pudo actualizar los Pasajeros", lrespuesta.Mensajes);
                    }
                }

                // ===

                // **
                // ** ANADIR COMENTARIOS DE SECUENCIA REFERENCIA
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.AnadirComentarioSecuenciaReferencia'", new { lsecuenciaReferencia }, CodigoSeguimiento);

                // insertar comentario secuencia referencia
                lrespuesta = AnadirComentarioSecuenciaReferencia(lsecuenciaReferencia);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.AnadirComentarioSecuenciaReferencia'", new { lrespuesta }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo insertar el Comentario de Secuencia Referencia", lrespuesta.Mensajes);
                }

                // ===

                // a partir de aqui no se puede ignorar
                lignorar = false;

                // **
                // ** GRABAR CAMBIOS
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.GrabarCambios'", new { cerrar = true }, CodigoSeguimiento);

                lrespuesta = GrabarCambios(true);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.GrabarCambios'", new { lrespuesta }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo Firmar y Cerrar la transacción", lrespuesta.Mensajes);
                }

                // ===

                // **
                // ** OBTENER PERFIL DE IMPRESORA
                // **

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ObtenerPerfilImpresora'", new { lreservaIniclal.Aplicacion.PseudoEmision }, CodigoSeguimiento);

                // obteniendo perfil de impresora
                var lperfilImpresora = ObtenerPerfilImpresora(lreservaIniclal.Aplicacion.PseudoEmision);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.ObtenerPerfilImpresora'", new { lperfilImpresora }, CodigoSeguimiento);

                // ===

                // **
                // ** EJECUTAR REMISION
                // **

                CE_Boleto[] lboletosEmitidos;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar '.EjecutarReemision'", new { lperfilImpresora, lreservaIniclal }, CodigoSeguimiento);

                // confirmando la reemisión
                lrespuesta = EjecutarReemision(lperfilImpresora, lreservaIniclal, out lboletosEmitidos);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado '.EjecutarReemision'", new { lrespuesta, lboletosEmitidos }, CodigoSeguimiento);

                // evaluando si la operación NO se pudo llevar acabo
                if (!lrespuesta.Ok)
                {
                    throw new InternalException("No se pudo Realizar la Reemisión", lrespuesta.Mensajes);
                }

                lrespuesta.Ok = true;
                boletos = lboletosEmitidos;


                // SI NO TENGO MONTO DE REEMISION NO ENTRO A ESTA SECCION


                // si la reserva es privada se debe borrar el comentario de facturacion
                if (lreservaIniclal.Cotizaciones[lseleccionarCotizacion].TipoTarifa.Codigo == EnumCodigoTarifa.PV)
                {
                    // indicando que de aqui en adelante los errores presentados no afectaran la respuesta
                    lignorarErrores = true;

                    // ===

                    // **
                    // ** RECUPERANDO lA RESERVA **
                    // **

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.RecuperarReserva'", new { parametros.PNR }, CodigoSeguimiento);

                    // recuperando y completando reserva
                    var lotraRespuesta = RecuperarReserva(parametros.PNR, false, out lreservaIniclal);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.RecuperarReserva'", new { lotraRespuesta, lreservaIniclal }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lotraRespuesta.Ok)
                    {
                        throw new InternalException("No se pudo borrar los Comentarios de Facturación", lrespuesta.Mensajes);
                    }

                    // ===

                    // **
                    // ** BORRANDO COMENTARIO DE FACTURACION **
                    // **

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.BorrarComentariosFacturacion'", new { lreservaIniclal, lboletoSeleccionado.NumeroBoleto }, CodigoSeguimiento);

                    // borrando comentario de facturación
                    lotraRespuesta = BorrarComentariosFacturacion(lreservaIniclal, lboletoSeleccionado.NumeroBoleto);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.BorrarComentariosFacturacion'", new { lotraRespuesta }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lotraRespuesta.Ok)
                    {
                        throw new InternalException("No se pudo borrar los Comentarios de Facturación", lrespuesta.Mensajes);
                    }

                    // **
                    // ** GRABAR CAMBIOS
                    // **

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.GrabarCambios'", new { cerrar = true }, CodigoSeguimiento);

                    lotraRespuesta = GrabarCambios(true);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.GrabarCambios'", new { lrespuesta }, CodigoSeguimiento);

                    // evaluando si la operación NO se pudo llevar acabo
                    if (!lotraRespuesta.Ok)
                    {
                        throw new InternalException("No se pudo Firmar y Cerrar la transacción para guardar el borrado del Comentario de Facturación", lrespuesta.Mensajes);
                    }
                }

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { parametros, lignorarErrores }, CodigoSeguimiento);

                if (!lignorarErrores)
                {
                    boletos = null;

                    // actualizando respuesta
                    lrespuesta = new CE_Estatus(ex);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { parametros, lignorarErrores }, CodigoSeguimiento);

                if (!lignorarErrores)
                {
                    boletos = null;

                    // actualizando respuesta
                    lrespuesta = new CE_Estatus(ex);
                }

            }
            finally
            {
                // evaluando si se puede 
                if (lignorar)
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar '.IgnorarTransaccion'", CodigoSeguimiento);

                    IgnorarTransaccion();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado '.IgnorarTransaccion'", CodigoSeguimiento);
                }
            }

            return lrespuesta;
        }

        #endregion
    }
}
