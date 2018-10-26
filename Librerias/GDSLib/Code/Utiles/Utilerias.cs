using System;
using System.Globalization;
using System.Text.RegularExpressions;

using CoreLib.Utils;

namespace GDSLib.Utiles
{
    internal static class Utilerias
    {
        // =============================
        // metodos estaticos

        #region "metodos estaticos"

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(string value)
        {
            // removiendo espacios de la cadena de entrada
            var lvalue = string.Format("{0}", value).Trim();

            // evaluando si NO existe un separador
            if (!lvalue.Contains(":"))
            {
                // completando valor de entrada
                lvalue = Regex.Replace(lvalue, "(.{2})", "$0:");
                lvalue = lvalue.Substring(0, (lvalue.Length - 1));
            }

            // extrayendo valores despues de completarlos
            var lvalues = string.Format("{0}:00:00", lvalue).Split(':');

            // retornando objeto de tiempo
            return new TimeSpan(int.Parse(lvalues[0]), int.Parse(lvalues[1]), int.Parse(lvalues[2]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToValidDate(string value)
        {
            // extrayendo dia y mes de la cadena de texto
            var ldia = int.Parse(value.Substring(0, 2));
            var lmes = DateTime2.MonthStringToNumber(value.Substring(2));

            // contruyendo fecha actual
            var lfechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            // construyendo fecha
            var lfechaTemporal = new DateTime(lfechaActual.Year, lmes, ldia, 0, 0, 0);

            // evaluando si la fecha es posible dentro del año en curso
            if ((lfechaTemporal > lfechaActual.AddDays(-1)) && (lfechaTemporal <= (new DateTime(DateTime.Now.Year, 12, 31, 0, 0, 0))))
            {
                return lfechaTemporal;
            }

            // evaluando si la fecha es posible dentro de 1 año
            return (((lfechaTemporal.AddYears(1) - lfechaActual).TotalDays <= 331) ? lfechaTemporal.AddYears(1) : lfechaTemporal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateB2BWallet"></param>
        /// <returns></returns>
        public static string ToValidDateString(string dateB2BWallet)
        {
            DateTime lresultado;

            // completando cadena que representa fecha
            var lfecha = string.Format("01{0}", dateB2BWallet);

            // realizando parseo
            DateTime.TryParseExact(lfecha, "ddMMyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out lresultado);

            // retornando resultado
            return lresultado.ToString("yyyy/MM");
        }

        #endregion
    }
}
