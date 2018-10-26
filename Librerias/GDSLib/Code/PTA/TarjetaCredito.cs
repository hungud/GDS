using System;
using System.Collections.Generic;
using System.Linq;

using CoreWebLib;
using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.TarjetaCredito;
using EntidadesGDS.TarjetaCredito.B2BWallet;
using BaseDatosLib.Procedimientos;
using BaseDatosLib.Paquetes;
using AmadeusLib.B2B;
using AmadeusLib.Utiles;

using GDSLib.Base;
using GDSLib.Utiles;

namespace GDSLib.PTA
{
    public sealed class TarjetaCredito : Common
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
        public TarjetaCredito(EnumAplicaciones aplicacion,
                              string codigoSeguimiento,
                              string codigoEntorno)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, null)
        {
        }

        ~TarjetaCredito()
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
        /// <param name="evaluacionTarjetaPTA"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        private void ObtenerTarjetaAmadeus(RQ_ObtenerReglasTarjetaPTA parametros,
                                           ref CE_EvaluacionTarjetaPTA evaluacionTarjetaPTA,
                                           out CE_Estatus resultado)
        {
            using (var lservicioB2BWallet = new B2BWallet(Aplicacion.Value, CodigoSeguimiento))
            {
                // creando request
                var lrequest = new B2BWalletGenerateRQ();

                B2BWalletGenerateRS lresponse;

                // removiendo simbolo decimal del monto
                lrequest.Message.Data.Amount = parametros.ImporteReserva;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lservicioB2BWallet.Execute'", new { WebServiceAction.B2BWalletGenerate, lrequest }, CodigoSeguimiento);

                // ejecutando solicitud de tarjeta amadeus
                resultado = lservicioB2BWallet.Execute(WebServiceAction.B2BWalletGenerate, lrequest, out lresponse);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lservicioB2BWallet.Execute'", new { resultado }, CodigoSeguimiento);

                // evaluando si la ejecución se llevo acabo sin problemas
                if (resultado.Ok && (lresponse != null))
                {
                    // evaluando el resultado del llamado al servicio
                    if (bool.Parse(lresponse.Success.ToLower()))
                    {
                        evaluacionTarjetaPTA.CodigoTarjeta = lresponse.Message.Data.VendorCode;
                        evaluacionTarjetaPTA.MesAnioExpiracion = Utilerias.ToValidDateString(lresponse.Message.Data.Validity);
                        evaluacionTarjetaPTA.NumeroTarjeta = lresponse.Message.Data.PrimaryAccountNumber;
                        evaluacionTarjetaPTA.ReferenciaExterna = lresponse.Message.Data.Reference.First(r => r.Type.Equals("External", StringComparison.InvariantCultureIgnoreCase)).Value;
                        evaluacionTarjetaPTA.ReferenciaAmadeus = lresponse.Message.Data.Reference.First(r => r.Type.Equals("Amadeus", StringComparison.InvariantCultureIgnoreCase)).Value;

                        return;
                    }

                    resultado = new CE_Estatus
                    {
                        Ok = false,
                        Mensajes = lresponse.Message.Errors.Select(e => new CE_Mensaje(EnumTipoMensaje.Error, e.Value)).ToArray()
                    };
                }

                // actualizando evaluación de tarjeta
                evaluacionTarjetaPTA = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referenciaExterna"></param>
        /// <param name="referenciaAmadeus"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public void EliminarTarjetaAmadeus(string referenciaAmadeus,
                                            string referenciaExterna,
                                            out CE_Estatus resultado)
        {
            using (var lservicioB2BWallet = new B2BWallet(Aplicacion.Value, CodigoSeguimiento))
            {
                // creando request
                var lrequest = new B2BWalletDeleteRQ
                {
                    Message = new MessageDeleteRQ
                    {
                        Data = new DataDeleteRQ
                        {
                            Reference = new[] { 
                                new ReferenceBase{ Type = "External", Value = referenciaExterna },
                                new ReferenceBase{ Type = "Amadeus", Value = referenciaAmadeus }
                            }
                        }
                    }
                };

                B2BWalletDeleteRS lresponse;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lservicioB2BWallet.Execute'", new { WebServiceAction.B2BWalletDelete, lservicioB2BWallet }, CodigoSeguimiento);

                // ejecutando eliminación de tarjeta amadeus
                resultado = lservicioB2BWallet.Execute(WebServiceAction.B2BWalletDelete, lrequest, out lresponse);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lservicioB2BWallet.Execute'", new { lresponse }, CodigoSeguimiento);

                // evaluando si la ejecución se llevo acabo sin problemas
                if (resultado.Ok && lresponse != null)
                {
                    if (!bool.Parse(lresponse.Success.ToLower()))
                    {
                        resultado = new CE_Estatus
                        {
                            Ok = false,
                            Mensajes = lresponse.Message.Errors.Select(e => new CE_Mensaje(EnumTipoMensaje.Error, e.Value)).ToArray()
                        };
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="conceptosRequeridos"></param>
        private bool InsertarConceptosTarjetaCreditoPta(string pnr,
                                                        IEnumerable<CE_Concepto> conceptosRequeridos)
        {
            int lregistrosAfectados;

            // contruyendo lista de evaluaciones
            var levaluaciones = conceptosRequeridos
                .Select((c, i) => new DT_MPC_EVALUACION
                {
                    COD_RESERVA = pnr,
                    NUM_CORRELATIVO = (i + 1),
                    ID_CONCEPTO = int.Parse(c.IdConcepto),
                    VALOR = c.Valor,
                    FECHA_ALTA = DateTime.Now
                }).ToArray();

            // serializando datos
            var levaluacionesXml = XmlHelper.XmlSerializerforOracle(levaluaciones, false, false);

            using (var lpkgGdsGeneric = new PkgGdsGeneric(CodigoSeguimiento))
            {
                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsGeneric.GdsInsertarConceptosTarjetaCreditoPta'", new { levaluacionesXml }, CodigoSeguimiento);

                // insertando evaluaciones
                lpkgGdsGeneric.GdsInsertarConceptosTarjetaCreditoPta(Conexion, Esquema, levaluacionesXml, out lregistrosAfectados);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsGeneric.GdsInsertarConceptosTarjetaCreditoPta'", new { lregistrosAfectados }, CodigoSeguimiento);
            }

            return (lregistrosAfectados != 0);
        }


        private void PreRegistrarTarjeta(string pnr, 
                                      ref CE_EvaluacionTarjetaPTA evaluacionTarjetaPta,
                                      out CE_Estatus resultado, 
                                      out bool ok) 
        {
            ok = false;
            try
            {
                using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsPreRegistarEmisionB2B'", new { pnr, evaluacionTarjetaPta }, CodigoSeguimiento);

                    // pre-registrando tarjeta generada
                    var lsecuenciaID = lpkgGdsTarjetasCreditoPta
                        .GdsPreRegistarEmisionB2B(Conexion, Esquema, new CE_EmisionB2B
                        {
                            PNR = pnr,
                            ReferenciaAmadeus = evaluacionTarjetaPta.ReferenciaAmadeus,
                            ReferenciaExterna = evaluacionTarjetaPta.ReferenciaExterna,
                            NumeroTarjeta = evaluacionTarjetaPta.NumeroTarjeta,
                            IdRegla = evaluacionTarjetaPta.IdRegla,
                            IdTarjetaCreditoPTA = evaluacionTarjetaPta.IdTarjetaCreditoPTA
                        });

                    ok = lsecuenciaID > 0;

                    if (ok) 
                    {
                        evaluacionTarjetaPta.SecuenciaID = lsecuenciaID;
                    }

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsPreRegistarEmisionB2B'", new { lsecuenciaID }, CodigoSeguimiento);

                    // actualizando respuesta
                    resultado = new CE_Estatus(ok);
                }
            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { pnr, evaluacionTarjetaPta }, CodigoSeguimiento);

                // actualizando respuesta
                resultado = new CE_Estatus(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pnr"></param>
        /// <param name="evaluacionTarjetaPta"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        private void RegistrarTarjetaAmadeus(string pnr,
                                             CE_EvaluacionTarjetaPTA evaluacionTarjetaPta,
                                             out CE_Estatus resultado)
        {
            var lok = false;

            PreRegistrarTarjeta(pnr, ref evaluacionTarjetaPta, out resultado, out lok);

            // El código se refactorizó en el nuevo método RegistrarTarjeta() para ser reutilizado
            
            //try
            //{
            //    using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
            //    {
            //        // registrando eventos
            //        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsRegistarEmisionB2B'", new { pnr, evaluacionTarjetaPta }, CodigoSeguimiento);

            //        // pre-registrando tarjeta generada
            //        lok = lpkgGdsTarjetasCreditoPta
            //            .GdsPreRegistarEmisionB2B(Conexion, Esquema, new CE_EmisionB2B
            //            {
            //                PNR = pnr,
            //                ReferenciaAmadeus = evaluacionTarjetaPta.ReferenciaAmadeus,
            //                ReferenciaExterna = evaluacionTarjetaPta.ReferenciaExterna,
            //                NumeroTarjeta = evaluacionTarjetaPta.NumeroTarjeta,
            //                IdRegla = evaluacionTarjetaPta.IdRegla,
            //                IdTarjetaCreditoPTA = evaluacionTarjetaPta.IdTarjetaCreditoPTA
            //            });

            //        // registrando eventos
            //        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsRegistarEmisionB2B'", new { lok }, CodigoSeguimiento);

            //        // actualizando respuesta
            //        resultado = new CE_Estatus(lok);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    // registrando eventos
            //    Bitacora.Current.WarnAndInfo(ex, new { pnr, evaluacionTarjetaPta }, CodigoSeguimiento);

            //    // actualizando respuesta
            //    resultado = new CE_Estatus(ex);
            //}

            // en caso de no haberse podido registrar la tarjeta intentar eliminarla
            if (!lok)
            {
                try
                {
                    // eliminando tarjeta amadeus generada
                    EliminarTarjetaAmadeus(evaluacionTarjetaPta.ReferenciaAmadeus, evaluacionTarjetaPta.ReferenciaExterna, out resultado);

                    // actualizando respuesta
                    resultado = (resultado.Ok ? new CE_Estatus() : resultado);

                }
                catch (Exception ex)
                {
                    // registrando eventos
                    Bitacora.Current.WarnAndInfo(ex, new { pnr, evaluacionTarjetaPta }, CodigoSeguimiento);

                    // actualizando respuesta
                    resultado = new CE_Estatus(ex);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="resultado"></param>
        /// <param name="muteErrors"></param>
        /// <returns></returns>
        public CE_Estatus ObtenerReglasTarjetaPta(RQ_ObtenerReglasTarjetaPTA parametros,
                                                  out CE_EvaluacionTarjetaPTA resultado,
                                                  bool muteErrors = true)
        {

            var lestatus = new CE_Estatus(true);

            resultado = null;

            try
            {
                CE_EvaluacionTarjetaPTA levaluacionResultante = null;

                using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsLimpiarConceptos'", new { parametros.PNR }, CodigoSeguimiento);

                    // limpiando conceptos
                    lpkgGdsTarjetasCreditoPta.GdsLimpiarConceptos(Conexion, Esquema, parametros.PNR);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsLimpiarConceptos'", CodigoSeguimiento);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsLimpiarEvaluaciones'", new { parametros.PNR }, CodigoSeguimiento);

                    // limpiando evaluaciones
                    lpkgGdsTarjetasCreditoPta.GdsLimpiarEvaluaciones(Conexion, Esquema, parametros.PNR);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsLimpiarEvaluaciones'", CodigoSeguimiento);

                    string leco;

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'SpMpcConceptosTarjetaCred.Ejecutar'", new { parametros.PNR, parametros.IATA, parametros.Transportador, parametros.CiudadDestino }, CodigoSeguimiento);

                    // prepararando conceptos
                    var lcontinuar = (new SpMpcConceptosTarjetaCred(CodigoSeguimiento))
                        .Ejecutar(Conexion, Esquema, parametros.PNR, parametros.IATA, parametros.Transportador, parametros.CiudadDestino, out leco);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'SpMpcConceptosTarjetaCred.Ejecutar'", new { lcontinuar }, CodigoSeguimiento);

                    // evaluando si se pudierón preparar los conceptos
                    if (lcontinuar)
                    {
                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsObtenerConceptosTdc'", new { parametros.PNR, parametros.IATA }, CodigoSeguimiento);

                        // obteniendo conceptos
                        var lconceptosRequeridos = lpkgGdsTarjetasCreditoPta.GdsObtenerConceptosTdc(Conexion, Esquema, parametros.PNR, parametros.IATA);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsObtenerConceptosTdc'", new { lconceptosRequeridos }, CodigoSeguimiento);

                        // evaluando si NO se obtuvierón los conceptos requeridos
                        if ((lconceptosRequeridos == null) || (!lconceptosRequeridos.Any()))
                        {
                            // forzando excepción
                            throw new InternalException(string.Format("No se pudo obtener los conceptos requeridos - PNR: {0}", parametros.PNR));
                        }

                        // actualizando conceptos
                        lconceptosRequeridos.ForEach(c1 =>
                        {
                            var lconcepto = parametros.Conceptos.FirstOrDefault(c2 => (int.Parse(c2.IdConcepto) == int.Parse(c1.IdConcepto)));

                            if (lconcepto != null)
                            {
                                // actualizando valor del concepto
                                c1.Valor = lconcepto.Valor;
                            }
                        });

                        // actualizando criterios
                        parametros.Conceptos = lconceptosRequeridos.ToArray();

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Por ejecutar '.InsertarConceptosTarjetaCreditoPta'", new { parametros.PNR, lconceptosRequeridos }, CodigoSeguimiento);

                        // evaluando si se pudierón insertar los conceptos a evaluar
                        var lok = InsertarConceptosTarjetaCreditoPta(parametros.PNR, lconceptosRequeridos);

                        // registrando eventos
                        Bitacora.Current.DebugAndInfo("Ejecutado '.InsertarConceptosTarjetaCreditoPta'", new { lok }, CodigoSeguimiento);

                        // evaluando si continuar
                        if (lok)
                        {
                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'SpMpcEvaluaTarjetaCred.Ejecutar'", new { parametros.PNR, parametros.IATA, parametros.ImporteReserva }, CodigoSeguimiento);

                            // evaluando las reglas
                            levaluacionResultante = (new SpMpcEvaluaTarjetaCred(CodigoSeguimiento))
                                .Ejecutar(Conexion, Esquema, parametros.PNR, parametros.IATA, parametros.ImporteReserva.Value, out leco);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'SpMpcEvaluaTarjetaCred.Ejecutar'", new { levaluacionResultante }, CodigoSeguimiento);

                            // evaluando si la evaluación de las reglas NO retorno un resultado
                            if (levaluacionResultante == null)
                            {
                                // actualizando respuesta
                                lestatus.RegistrarAlerta(leco);

                            }
                            else
                            {
                                // evaluando si debe de solicitar una tarjeta usando el B2B2Wallet de amadeus
                                if (levaluacionResultante.NumeroTarjeta.Equals(Configuracion.B2BWalletEvaluationMark, StringComparison.InvariantCultureIgnoreCase))
                                {
                                    // evaluando la cantidad de pasajeros 
                                    if (parametros.CantidadPasajeros > Configuracion.B2BWalletMaximumPassengers)
                                    {
                                        // actualizando respuesta
                                        lestatus.RegistrarAlerta(string.Format("La cantidad de pasajeros es mayor a {0}, no califica para una emision B2B Wallet", Configuracion.B2BWalletMaximumPassengers));

                                        levaluacionResultante = null;

                                    }
                                    else
                                    {
                                        // registrando eventos
                                        Bitacora.Current.DebugAndInfo("Por ejecutar '.ObtenerTarjetaAmadeus'", new { parametros, levaluacionResultante }, CodigoSeguimiento);

                                        // obteniendo tarjeta amadeus
                                        ObtenerTarjetaAmadeus(parametros, ref levaluacionResultante, out lestatus);

                                        // evaluando que la generación se haya podido realizar sin problemas
                                        if (lestatus.Ok)
                                        {
                                            // registrando eventos
                                            Bitacora.Current.DebugAndInfo("Por ejecutar '.RegistrarTarjetaAmadeus'", new { parametros.PNR, levaluacionResultante }, CodigoSeguimiento);

                                            // registrando datos de la generación
                                            RegistrarTarjetaAmadeus(parametros.PNR, levaluacionResultante, out lestatus);

                                            // registrando eventos
                                            Bitacora.Current.DebugAndInfo("Ejecutado '.RegistrarTarjetaAmadeus'", new { lestatus }, CodigoSeguimiento);

                                            // evaluando si NO se pudo registrar la tarjeta generada
                                            if (!lestatus.Ok)
                                            {
                                                levaluacionResultante = null;
                                            }
                                        }
                                        // registrando eventos
                                        Bitacora.Current.DebugAndInfo("Ejecutado '.ObtenerTarjetaAmadeus'", new { levaluacionResultante, lestatus }, CodigoSeguimiento);
                                    }
                                }
                                else 
                                {
                                    // registrando eventos
                                    Bitacora.Current.DebugAndInfo("Por ejecutar '.RegistrarTarjeta'", new { parametros.PNR, levaluacionResultante }, CodigoSeguimiento);

                                    // registrando datos de la generación
                                    PreRegistrarTarjeta(parametros.PNR, ref levaluacionResultante, out lestatus, out lok);

                                    // registrando eventos
                                    Bitacora.Current.DebugAndInfo("Ejecutado '.RegistrarTarjeta'", new { lestatus }, CodigoSeguimiento);

                                    // evaluando si NO se pudo registrar la tarjeta generada
                                    if (!lestatus.Ok)
                                    {
                                        levaluacionResultante = null;
                                    }
                                }
                            }

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsLimpiarConceptos'", new { parametros.PNR }, CodigoSeguimiento);

                            // limpiando conceptos
                            lpkgGdsTarjetasCreditoPta.GdsLimpiarConceptos(Conexion, Esquema, parametros.PNR);

                            // registrando eventos
                            Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsLimpiarConceptos'", CodigoSeguimiento);

                            //// registrando eventos
                            //Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsLimpiarEvaluaciones'", new { parametros.PNR }, CodigoSeguimiento);

                            //// limpiando evaluaciones
                            //lpkgGdsTarjetasCreditoPta.GdsLimpiarEvaluaciones(Conexion, Esquema, parametros.PNR);

                            //// registrando eventos
                            //Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsLimpiarEvaluaciones'", CodigoSeguimiento);
                        }

                    }
                    else
                    {
                        // actualizando respuesta
                        lestatus.RegistrarAlerta(leco);
                    }
                }

                // actualizando respuesta
                resultado = levaluacionResultante;

            }
            catch (InternalException ex)
            {
                // registrando eventos
                Bitacora.Current.WarnAndInfo(ex, new { parametros, muteErrors }, CodigoSeguimiento);

                // no silenciar errores
                if (!muteErrors)
                {
                    throw;
                }

                // actualizando respuesta
                lestatus = new CE_Estatus(ex);

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
                lestatus = new CE_Estatus(ex);
            }

            return lestatus;
        }

        /// <summary>
        /// Inserta información de los boletos emitidos utilizando una tarjeta B2BWallet
        /// </summary>
        /// <param name="target">Información del boleto emitido con tarjeta</param>
        /// <param name="resultado">True si insertó correctamente, False en caso de error</param>
        /// <returns></returns>
        public CE_Estatus InsertarInformacionEmisionB2B(CE_EmisionB2B target,
                                                        out bool resultado)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = false;

            try
            {
                using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsRegistarEmisionB2B'", new { target }, CodigoSeguimiento);

                    // registrando tarjeta generada y usada
                    resultado = lpkgGdsTarjetasCreditoPta.GdsRegistarEmisionB2B(Conexion, Esquema, target);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsRegistarEmisionB2B'", new { resultado }, CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, new { target }, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public void ActualizarTarjetaGDS(RQ_ActualizacionTarjetaB2B target,
                                         out CE_Estatus resultado)
        {
            using (var lservicioB2BWallet = new B2BWallet(Aplicacion.Value, CodigoSeguimiento))
            {
                var lB2BWalletUpdateRQ = new B2BWalletUpdateRQ
                {
                    Message = new MessageUpdateRQ
                    {
                        Data = new DataUpdateRQ
                        {
                            Comment = target.Comentario,
                            Reference = new[] { 
                                new ReferenceBase{
                                    Type = "External",
                                    Value = target.ReferenciaExterna
                                },
                                new ReferenceBase{
                                    Type = "Amadeus",
                                    Value = target.ReferenciaAmadeus
                                }
                            }
                        }
                    }
                };

                B2BWalletUpdateRS lresponse;

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Por ejecutar 'lservicioB2BWallet.Execute'", new { WebServiceAction.B2BWalletUpdate, lB2BWalletUpdateRQ }, CodigoSeguimiento);

                resultado = lservicioB2BWallet.Execute(WebServiceAction.B2BWalletUpdate, lB2BWalletUpdateRQ, out lresponse);

                // registrando eventos
                Bitacora.Current.DebugAndInfo("Ejecutado 'lservicioB2BWallet.Execute'", new { resultado, lresponse }, CodigoSeguimiento);

                if (resultado.Ok && lresponse != null)
                {
                    if (!bool.Parse(lresponse.Success.ToLower()))
                    {
                        resultado = new CE_Estatus
                        {
                            Ok = false,
                            Mensajes = lresponse.Message.Errors.Select(e => new CE_Mensaje(EnumTipoMensaje.Error, e.Value)).ToArray()
                        };
                    }
                }
            }
        }

        /// <summary>
        /// Acutaliza el estado del boleto emitidos utilizando una tarjeta B2BWallet
        /// </summary>
        /// <param name="target">Información del boleto emitido con tarjeta</param>
        /// <param name="actualizacionOK">True si actualiza correctamente, False en caso de error</param>
        /// <returns></returns>
        public CE_Estatus ActualizarTarjetaB2BWallet(RQ_ActualizacionTarjetaB2B target,
                                                     out bool actualizacionOK)
        {
            var lrespuesta = new CE_Estatus(true);
            actualizacionOK = false;
            try
            {
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ActualizarTarjetaGDS'", new { target }, CodigoSeguimiento);
                ActualizarTarjetaGDS(target, out lrespuesta);
                Bitacora.Current.DebugAndInfo("Ejecutado '.ActualizarTarjetaGDS'", new { lrespuesta }, CodigoSeguimiento);
                
                var lstatus = 2;
                if(!lrespuesta.Ok && lrespuesta.Mensajes.Any(s => s.Valor.Contains("34740 - VIRTUAL CARD ALREADY DELETED")))
                {
                    lstatus = 3;
                    Bitacora.Current.DebugAndInfo("La tarjeta ya fue eliminada, solo se actualizará el estado de los boletos'", new { target }, CodigoSeguimiento);
                    lrespuesta = new CE_Estatus(true);
                }
                
                if (lrespuesta.Ok)
                {
                    UpdateInfoBD(target, lstatus, out actualizacionOK);
                    if (!actualizacionOK) 
                    {
                        return new CE_Estatus(new InternalException(string.Format(" Ocurrió un error al eliminar la tarjeta B2B Wallet en la base de datos, perteneciente a la reserva {0}", target.PNR)));
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, new { target }, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }


        public CE_Estatus ActualizarEmisionAnulada(CE_EmisionB2B target,
                                                      out bool actualizacionOK)
        {
            var lrespuesta = new CE_Estatus(true);
            actualizacionOK = false;
            try
            {
                Bitacora.Current.DebugAndInfo("Por ejecutar '.ActualizarEmisionesAnuladas'", new { target }, CodigoSeguimiento);

                using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
                {
                    target.Anulado = 1;  //Actualizando estado a Anulado

                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsActualizarEmisionB2B'", new { target }, CodigoSeguimiento);
                    actualizacionOK = lpkgGdsTarjetasCreditoPta.GdsActualizarEmisionB2B(Conexion, Esquema, target);
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsActualizarEmisionB2B'", new { actualizacionOK }, CodigoSeguimiento);   
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, new { target }, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }


        private void UpdateInfoBD(RQ_ActualizacionTarjetaB2B target, int status, out bool actualizacionOK)
        {
            actualizacionOK = false;

            using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento)) 
            {
                Conexion.IniciarTransaccion();

                foreach (var currentBoleto in target.Boletos)
                {
                    var lemision = new CE_EmisionB2B
                    {
                        PNR = target.PNR,
                        NumeroBoleto = currentBoleto.NumeroBoleto,
                        MontoTotalBoleto = currentBoleto.MontoBoleto,
                        Comentario = target.Comentario,
                        Status = status
                    };

                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsActualizarEmisionB2B'", new { lemision }, CodigoSeguimiento);
                    actualizacionOK = lpkgGdsTarjetasCreditoPta.GdsActualizarEmisionB2B(Conexion, Esquema, lemision);
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsActualizarEmisionB2B'", new { actualizacionOK }, CodigoSeguimiento);
                    if (!actualizacionOK)
                    {
                        Conexion.FinalizarTransaccion(true);
                    }
                };
                Conexion.FinalizarTransaccion(false);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="resultado"></param>
        /// <returns></returns>
        public CE_Estatus EliminarTarjetasB2BWallet(RQ_ActualizacionTarjetaB2B target,
                                                    out bool resultado)
        {
            var lrespuesta = new CE_Estatus(true);
            resultado = false;
            try
            {
                Bitacora.Current.DebugAndInfo("Por ejecutar '.EliminarTarjetaGDS'", new { target }, CodigoSeguimiento);
                EliminarTarjetaAmadeus(target.ReferenciaAmadeus, target.ReferenciaExterna, out lrespuesta);
                if (!lrespuesta.Ok && lrespuesta.Mensajes.Any(s => s.Valor.Contains("34740 - VIRTUAL CARD ALREADY DELETED")))
                {
                    Bitacora.Current.DebugAndInfo("La tarjeta ya fue eliminada, solo se actualizará el estado de los boletos'", new { target }, CodigoSeguimiento);
                    lrespuesta = new CE_Estatus(true);
                }
   
                Bitacora.Current.DebugAndInfo("Ejecutado '.EliminarTarjetaGDS'", new { lrespuesta }, CodigoSeguimiento);
                if (lrespuesta.Ok)
                {
                    //Tarjeta No encontrada en nuestra tabla, solo se registrará las referencias y estado anulado!
                    if (target.PNR.Equals("XXXXXX"))
                    {
                        lrespuesta = InsertarInformacionEmisionB2B(new CE_EmisionB2B
                        {
                            PNR = target.PNR,
                            ReferenciaExterna = target.ReferenciaExterna,
                            ReferenciaAmadeus = target.ReferenciaAmadeus,
                            Status = 3
                        }, out resultado);
                    }
                    else 
                    {
                        UpdateInfoBD(target, 3, out resultado);
                        if (!resultado)
                        {
                            return new CE_Estatus(new InternalException(string.Format(" Ocurrió un error al eliminar la tarjeta B2B Wallet en la base de datos, perteneciente a la reserva {0}", target.PNR)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, new { target }, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        /// <summary>
        /// Acutaliza el estado del boleto emitidos utilizando una tarjeta B2BWallet
        /// </summary>
        /// <param name="resultado">True si actualiza correctamente, False en caso de error</param>
        /// <returns></returns>
        public CE_Estatus ObtenerEmisionesB2BPendientesActualizacion(out List<CE_EmisionB2B> resultado)
        {
            var lrespuesta = new CE_Estatus(true);

            resultado = null;

            try
            {
                using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
                {
                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsObtenerEmisionB2BPendientes'", CodigoSeguimiento);

                    resultado = lpkgGdsTarjetasCreditoPta.GdsObtenerEmisionB2BPendientes(Conexion, Esquema);

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsObtenerEmisionB2BPendientes'", CodigoSeguimiento);
                }

            }
            catch (Exception ex)
            {
                // registrando eventos
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);

                // actualizando respuesta
                lrespuesta = new CE_Estatus(ex);
            }

            return lrespuesta;
        }

        

        /// <summary>
        /// Acutaliza el estado del boleto emitidos utilizando una tarjeta B2BWallet
        /// </summary>
        /// <param name="resultado">True si actualiza correctamente, False en caso de error</param>
        /// <returns></returns>
        public CE_Estatus ObtenerEmisionesB2BPorFecha(string[] fechas, out List<CE_EmisionB2B> resultado)
        {
            var lrespuesta = new CE_Estatus(true);
            resultado = null;
            try
            {
                using (var lpkgGdsTarjetasCreditoPta = new PkgGdsTarjetasCreditoPta(CodigoSeguimiento))
                {
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lpkgGdsTarjetasCreditoPta.GdsObtenerEmisionB2BPorFecha'", CodigoSeguimiento);
                    resultado = lpkgGdsTarjetasCreditoPta.GdsObtenerEmisionB2BPorFecha(Conexion, Esquema, fechas[0], fechas[1]);
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lpkgGdsTarjetasCreditoPta.GdsObtenerEmisionB2BPorFecha'", CodigoSeguimiento);
                }
            }
            catch (Exception ex)
            {
                Bitacora.Current.ErrorAndInfo(ex, null, CodigoSeguimiento);
                lrespuesta = new CE_Estatus(ex);
            }
            return lrespuesta;
        }

        #endregion
    }

     
}
