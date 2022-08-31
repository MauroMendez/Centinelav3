using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class NivelesHistorial
    {
        public long NhAlumnoId { get; set; }
        public decimal NhNivel { get; set; }
        public DateTime NhFechaInicio { get; set; }
        public DateTime? NhFechaFin { get; set; }
        public string NhAutorizadoPor { get; set; }

        public virtual Alumno NhAlumno { get; set; }
        public virtual Administrativos NhAutorizadoPorNavigation { get; set; }
    }
}
