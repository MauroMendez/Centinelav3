using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class EsquemaPagoHistorial
    {
        public long EphAlumnoId { get; set; }
        public int EphFormasPagoId { get; set; }
        public DateTime EphFechaInicio { get; set; }
        public DateTime? EphFechaFin { get; set; }
        public float? FphMensualidadAnterior { get; set; }
        public string EphAutorizadoPor { get; set; }

        public virtual Alumno EphAlumno { get; set; }
        public virtual Administrativos EphAutorizadoPorNavigation { get; set; }
    }
}
