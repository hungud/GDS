using System;

namespace EntidadesGDS.General
{
    /// <summary>
    ///   Representa un Segmento
    /// </summary>
    /// <remarks>
    ///   ---
    /// </remarks>
    public class CE_Segmento
    {
        // =============================
        // auto propiedades

        #region "auto propiedades"

        public bool? Seleccionado { set; get; }
        public EnumTipoSegmento? TipoSegmento { get; set; }
        public int? NumeroSegmento { get; set; }
        public int? NumeroLinea { get; set; }
        public CE_Aerolinea Aerolinea { get; set; }
        public string NumeroVuelo { get; set; }
        public string ClaseReserva { get; set; }
        public string FechaSalida { get; set; }
        public string DiaSemanaSalida { get; set; }
        public string HoraSalida { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
        public CE_Ciudad CiudadSalida { get; set; }
        public string FechaLlegada { get; set; }
        public string DiaSemanaLlegada { get; set; }
        public string HoraLlegada { get; set; }
        public DateTime? FechaHoraLlegada { get; set; }
        public CE_Ciudad CiudadLlegada { get; set; }
        public string Status { get; set; }
        public int? CantidadAsientos { get; set; }
        public int? CantidadParadas { get; set; }
        public string CodigoReservaAerolinea { get; set; }
        public string LineaOperadora { get; set; }
        public bool EsSalida { get; set; }
        public string OperadoPor { set; get; }
        public bool? EsPasado { set; get; }
        public string BrandedFare { set; get; }

        #endregion
    }
}
