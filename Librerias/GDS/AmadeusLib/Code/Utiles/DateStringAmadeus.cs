using System;
using System.Linq;
using System.Text.RegularExpressions;

using CoreLib.Utils;

namespace AmadeusLib.Utiles
{
    internal static class DateStringAmadeus
    {
        // =============================
        // metodos estaticos

        #region "metodos estaticos"

        public static TimeSpan? ToTimeSpan(string value)
        {
            TimeSpan? ltiempo = null;

            // removiendo espacios de la cadena de entrada
            var lvalue = string.Format("{0}", value).Trim();

            // evaluando si es una cadena valida
            if (!string.IsNullOrWhiteSpace(lvalue))
            {
                // evaluando si NO existe un separador
                if (!lvalue.Contains(":"))
                {
                    // completando valor de entrada
                    lvalue = Regex.Replace(lvalue, "(.{2})", "$0:");
                    lvalue = lvalue.Substring(0, (lvalue.Length - 1));
                }

                // extrayendo valores despues de completarlos
                var lvalues = string.Format("{0}:00:00", lvalue).Split(':');

                // contruyendo un objeto de tiempo
                ltiempo = new TimeSpan(int.Parse(lvalues[0]), int.Parse(lvalues[1]), int.Parse(lvalues[2]));
            }

            return ltiempo;
        }

        public static DateTime? ToValidDate(string value,
                                            bool isForItinerary)
        {
            DateTime? lfecha = null;

            // removiendo espacios de la cadena de entrada
            var lvalue = string.Format("{0}", value).Trim();

            // evaluando si es una cadena valida
            if (!string.IsNullOrWhiteSpace(lvalue))
            {
                TimeSpan? ltiempo = null;
                string[] lvalores;

                // buscando tiempo en la cadena de entrada
                var lencontrado = Regex.Match(lvalue, @"T\d{2}:\d{2}$");

                // evaluando si se pudo hallar un valor de tiempo
                if (lencontrado.Success)
                {
                    // diviendo valor de tiempo
                    lvalores = lencontrado.Value.Replace("T", string.Empty).Split(':');

                    // construyendo un objeto de tiempo
                    ltiempo = new TimeSpan(int.Parse(lvalores[0]), int.Parse(lvalores[1]), 0);
                }

                // contruyendo un objeto de fecha (actual)
                lfecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

                // removiendo el tiempo si estuviese presente en la cadena de entrada
                lvalue = (string.IsNullOrWhiteSpace(lencontrado.Value) ? lvalue : lvalue.Replace(lencontrado.Value, string.Empty));

                // buscando un valor de fecha (ddmmyy)
                var lesFecha = Regex.Match(lvalue, @"^(\d{2})(\d{2})(\d{2})$");

                // evaluando si se pudo hallar un valor de fecha (ddmmyy)
                if (lesFecha.Success)
                {
                    // construyendo un objeto fecha
                    var lfechaTemporal = new DateTime(lfecha.Value.Year, int.Parse(lesFecha.Groups[2].Value), int.Parse(lesFecha.Groups[1].Value), 0, 0, 0);

                    // evaluando si la fecha esperada es para un boleto
                    if (isForItinerary)
                    {
                        // evaluando si la fecha NO es posible dentro del año en curso
                        if (!((lfechaTemporal > lfecha.Value.AddDays(-1)) && (lfechaTemporal <= (new DateTime(DateTime.Now.Year, 12, 31, 0, 0, 0)))))
                        {
                            // actualizando fecha temporal dependiendo de la evaluación de si la fecha es posible dentro de 1 año
                            lfechaTemporal = (((lfechaTemporal.AddYears(1) - lfecha.Value).TotalDays <= 331) ? lfechaTemporal.AddYears(1) : lfechaTemporal);
                        }
                    }

                    // construyendo un objeto de fecha
                    lfecha = new DateTime(lfechaTemporal.Year, int.Parse(lesFecha.Groups[2].Value), int.Parse(lesFecha.Groups[1].Value), 0, 0, 0);
                }

                // evaluando si se pudo obtener un time
                if (ltiempo != null)
                {
                    lfecha = lfecha.Value.AddHours(ltiempo.Value.Hours);
                    lfecha = lfecha.Value.AddMinutes(ltiempo.Value.Minutes);
                }
            }

            return lfecha;
        }

        public static DateTime? ToValidBirthdate(string value)
        {
            DateTime? lfecha = null;

            // removiendo espacios de la cadena de entrada
            var lvalue = string.Format("{0}", value).Trim();

            // evaluando si es una cadena valida
            if (!string.IsNullOrWhiteSpace(lvalue))
            {
                // buscando fecha con formato "ddMMMYY" o "ddmmyyyy"
                var lencontrado = Regex.Match(lvalue, @"^(\d{2})(\d{2}|\D{3})(\d{4}|\d{2})$");

                // evaluando si se pudo hallar un valor de fecha "ddMMMYY"
                if (lencontrado.Success)
                {
                    var lmes = (lencontrado.Groups[2].Value.All(char.IsDigit) ? int.Parse(lencontrado.Groups[2].Value) : DateTime2.MonthStringToNumber(lencontrado.Groups[2].Value));

                    if (lencontrado.Groups[3].Value.Length == 4)
                    {
                        // construyendo un objeto de fecha
                        lfecha = new DateTime(int.Parse(lencontrado.Groups[3].Value), lmes, int.Parse(lencontrado.Groups[1].Value), 0, 0, 0);

                    }
                    else
                    {
                        // contruyendo un objeto de fecha (actual)
                        var ldiferencia = (int.Parse(DateTime.Now.Year.ToString().Substring(2, 2)) - int.Parse(lencontrado.Groups[3].Value));

                        // construyendo un objeto de fecha
                        lfecha = new DateTime(int.Parse(((ldiferencia < 0) ? "19" : "20") + lencontrado.Groups[3].Value), lmes, int.Parse(lencontrado.Groups[1].Value), 0, 0, 0);
                    }
                }
            }

            return lfecha;
        }

        public static string ToValidBirthdate(string value,
                                              string formato)
        {
            var lfecha = ToValidBirthdate(value);

            if (lfecha.HasValue)
            {
                return lfecha.Value.ToString(formato);
            }

            return null;
        }

        public static string ToValidStringDateGds(DateTime ldate)
        {
            return string.Format("{0:dd}{1}", ldate, DateTime2.MonthNumberToString(ldate.Month)[0]);
        }

        public static string ToValidStringTimeGds(DateTime ldate)
        {
            return ldate.ToString("HH:mm");
        }

        #endregion
    }
}
