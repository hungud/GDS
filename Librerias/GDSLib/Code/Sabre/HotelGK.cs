using System;
using System.Text.RegularExpressions;
using System.Linq;

using CustomLog;

using EntidadesGDS;
using EntidadesGDS.Base;
using EntidadesGDS.General;
using EntidadesGDS.Hotel;
using SabreLib.Herramientas;

using GDSLib.Base;
using GDSLib.Utiles;

namespace GDSLib.Sabre
{
    public sealed class HotelGK : Common
    {
        //private EnumAplicaciones? nullable;
        //private string p1;
        //private string p2;
        //private CE_Session cE_Session;
        //private RQ_SegmentoGK _HotelGK;

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
        public HotelGK(EnumAplicaciones? aplicacion,
                       string codigoSeguimiento,
                       string codigoEntorno,
                       CE_Session sesion)
            : base(aplicacion, codigoSeguimiento, codigoEntorno, sesion)
        {
        }

        public HotelGK()
        {
        }

        ~HotelGK()
        {
            Dispose(false);
        }

        #endregion

        // =============================
        // metodos

        #region "metodos"

        /*
        private bool evaluaMensaje(CE_Estatus status, string target)
        {
            return status.Mensajes != null && status.Mensajes[0].Valor.Substring(0, 1).Equals("*");
        }
        */

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CE_Estatus EliminarLineasContables()
        {
            var lrespuesta = new CE_Estatus(true);

            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                lsabreCommand.Prepare();

                lrespuesta = lsabreCommand.BorrarLineasContables();

                if (lrespuesta != null && lrespuesta.Ok)
                {
                    if (lrespuesta.Mensajes != null && !lrespuesta.Mensajes[0].Valor.Substring(0, 1).StartsWith("*"))
                    {
                        lrespuesta.Ok = false;
                        lrespuesta.RegistrarError("No se puede eliminar lineas contables");
                        //lrespuesta.Mensajes = new[] { new CE_Mensaje { Tipo = EnumTipoMensaje.Error, Valor = "No se puede eliminar lineas contables" } };
                    }
                }
            }

            return lrespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ExisteLineaContable()
        {
            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                lsabreCommand.Prepare();

                var lrespuesta = lsabreCommand.ExisteLineasContables();

                return lrespuesta.Ok && lrespuesta.Mensajes[0].Valor.Contains("ACCOUNTING DATA");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="ultimoSegmentoGK"></param>
        /// <param name="lrespuesta"></param>
        /// <returns></returns>
        private void EnviarSegmentoGK(RQ_SegmentoGK request, 
                                      out string ultimoSegmentoGK, 
                                      out CE_Estatus lrespuesta)
        {
            lrespuesta = new CE_Estatus(true);

            ultimoSegmentoGK = string.Empty;

            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                lsabreCommand.Prepare();

                var lsegmentoGk = BuildLineaSegmentoGk(request);

                var lrespuestaSegmentoGk = lsabreCommand.Execute(lsegmentoGk);

                if (lrespuestaSegmentoGk.Ok && lrespuestaSegmentoGk.Mensajes[0].Valor.StartsWith("SEG"))
                {
                    lrespuesta = lsabreCommand.DesplegarItinerario();

                    var lultimoSegmentoGkRegistrado = lrespuesta.Mensajes[0].Valor.Split('\n')
                                    .Where(mensaje => mensaje.Trim().Contains("HHT"))
                                    .Select(r => int.Parse(r.Trim().Substring(0,2))).Max();

                    ultimoSegmentoGK = lultimoSegmentoGkRegistrado.ToString();
                    lrespuesta = new CE_Estatus("ok");

                }
                else
                {
                    if (lrespuestaSegmentoGk.Mensajes[0].Valor.Contains("DTE"))
                    {
                        lrespuesta = new CE_Estatus("Las fechas seleccionadas no pueden ser procesadas");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="numeroSegmentoGK"></param>
        /// <param name="lrespuesta"></param>
        /// <returns></returns>
        private void EnviarLineasContables(RQ_SegmentoGK request, 
                                           string numeroSegmentoGK, 
                                           out CE_Estatus lrespuesta)
        {
            lrespuesta = new CE_Estatus(true);

            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                lsabreCommand.Prepare();

                if (request.TipoHabitacion.Equals("SGL") && (request.Pasajeros.Count > 1))
                {
                    foreach (var currentPasajero in request.Pasajeros)
                    {
                        var llineaContable = BuildLineaContable(request, request.Pasajeros.Count, numeroSegmentoGK);

                        var lrespuestaLineaContable = lsabreCommand.Execute(llineaContable);

                        if (lrespuestaLineaContable.Ok && lrespuestaLineaContable.Mensajes[0].Valor.StartsWith("*"))
                        {
                            lrespuesta = new CE_Estatus("ok");
                        }
                    }

                }
                else
                {
                    var llineaContable = BuildLineaContable(request, request.Pasajeros.Count, numeroSegmentoGK);
                    var lrespuestaLineaContable = lsabreCommand.Execute(llineaContable);

                    if (lrespuestaLineaContable.Ok && lrespuestaLineaContable.Mensajes[0].Valor.StartsWith("*"))
                    {
                        lrespuesta = new CE_Estatus("ok");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="observacion"></param>
        /// <returns></returns>
        private void EscribeRemarkObservacion(string observacion)
        {
            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
            {
                lsabreCommand.Prepare();

                lsabreCommand.Execute("5.OBSERVACION/" + observacion);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ciudad"></param>
        /// <returns></returns>
        private string getIdCiudad(CE_Ciudad ciudad)
        {
            var match = Regex.Match(ciudad.IdCiudad, "[A-Z]{3}", RegexOptions.IgnoreCase);

            return (match.Success ? ciudad.IdCiudad : (ciudad.NombreCiudad.Length > 20 ? ciudad.NombreCiudad.Substring(0, 20) : ciudad.NombreCiudad));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private string parseDate(string fecha)
        {
            //var date = DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            var date = DateTime.Parse(fecha);
            return date.ToString("ddMMM").ToUpper();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="monto"></param>
        /// <returns></returns>
        private string parseDecimal(decimal monto)
        {
            return string.Format("{0:0.00}", monto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string BuildLineaSegmentoGk(RQ_SegmentoGK request)
        {
            return string.Format(@"0HHTAAGK{0}{1}IN{2}-OUT{3}/{4} {5}/{6}/{7}{8}/G/SI-¤{9}¥{10} {11}¥FONE {12}¥RC/{13}¤PN {14}-FP{15}-MFEE{16}/CF-{17}",
                    request.Pasajeros.Count(),
                    getIdCiudad(request.Ciudad),
                    parseDate(request.FechaInicioReserva),
                    parseDate(request.FechaFinReserva),
                    request.Hotel.CodigoCadenaHotelera,
                    request.Hotel.Nombre,
                    request.TipoHabitacion.Valor,
                    parseDecimal(request.MontoTotal),
                    request.Moneda,
                    request.Hotel.Direccion,
                    request.Ciudad.NombreCiudad,
                    request.Ciudad.IdPais,
                    request.Hotel.Telefono,
                    request.TipoTarifa,
                    request.Hotel.IdHotel,
                    request.PagoEn,
                    parseDecimal(request.MontoFEE),
                    request.CodigoReservaHotel
                    );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cantidadPasajeros"></param>
        /// <param name="nroSegmentoGK"></param>
        /// <returns></returns>
        private string BuildLineaContable(RQ_SegmentoGK request, 
                                          int cantidadPasajeros, 
                                          string nroSegmentoGK)
        {
            return string.Format("ACHHT{0}/VENDOR/VCH{1}/P0/{2}/{3}/D{4}/ALL/CA/{5}",
                nroSegmentoGK,
                request.CodigoReservaHotel,
                parseDecimal(request.MontoTotal),
                parseDecimal(request.MontoImpuestos),
                parseDecimal(request.MontoImpuestosAdicionales),
                cantidadPasajeros
                );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Estatus ProcesarSegmentoGK(RQ_SegmentoGK request)
        {
            var lrespuesta = new CE_Estatus();

            try
            {
                if (ExisteLineaContable())
                {
                    var estatus = EliminarLineasContables();

                    if (!estatus.Ok)
                    {
                        return estatus;
                    }
                }

                string lnumeroSegmentoGk;

                EnviarSegmentoGK(request, out lnumeroSegmentoGk, out lrespuesta);

                if (lrespuesta.Mensajes[0].Valor.Equals("ok"))
                {
                    EnviarLineasContables(request, lnumeroSegmentoGk, out lrespuesta);

                    if (lrespuesta.Mensajes[0].Valor.Equals("ok"))
                    {
                        if (!string.IsNullOrWhiteSpace(request.Observacion))
                        {
                            EscribeRemarkObservacion(request.Observacion);
                        }

                        if (ExisteLineaContable())
                        {
                            using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
                            {
                                lsabreCommand.Prepare();
                                lsabreCommand.Execute("6TURBO");
                                lrespuesta = lsabreCommand.FinalizarRecuperar();

                                var lprimerMensaje = lrespuesta.Mensajes[0].Valor.Split('\n')[0];

                                if (lprimerMensaje.Equals(request.CodigoReserva) || lprimerMensaje.Contains("NO CHANGES MADE TO PNR"))
                                {

                                    var voucher = new VoucherHotel()
                                    {
                                        _SegmentoHotel = request
                                    };

                                    voucher.buildVoucher();

                                    lrespuesta = lsabreCommand.Execute("DIN");

                                    if (lrespuesta.Ok && lrespuesta.Mensajes[0].Valor.Contains("INVOICED"))
                                    {

                                        //NO CHANGES MADE TO PNR
                                    }
                                }
                            }
                        }
                    }
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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CE_Estatus ExisteLineasContables()
        {
            CE_Estatus lrespuesta;

            try
            {
                using (var lsabreCommand = new SabreCommand(Aplicacion.Value, Sesion, CodigoSeguimiento))
                {
                    lsabreCommand.Prepare();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Por ejecutar 'lsabreCommand.ExisteLineasContables'", CodigoSeguimiento);

                    lrespuesta = lsabreCommand.ExisteLineasContables();

                    // registrando eventos
                    Bitacora.Current.DebugAndInfo("Ejecutado 'lsabreCommand.ExisteLineasContables'", new { lrespuesta }, CodigoSeguimiento);
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

        #endregion
    }
}
