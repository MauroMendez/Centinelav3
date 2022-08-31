using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class EgresadoHistorial
    {
        public long EhAlumnoId { get; set; }
        public decimal EhNivel { get; set; }
        public DateTime EhFechaIngresoNivel { get; set; }
        public DateTime EhFechaEgresoNivel { get; set; }
        public string EhAutorizadoPor { get; set; }

        public virtual Alumno EhAlumno { get; set; }
        public virtual Administrativos EhAutorizadoPorNavigation { get; set; }
    }
}
