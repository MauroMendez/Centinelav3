using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PeriodoHistorico
    {
        public long PhAlumnoId { get; set; }
        public int PhPeriodo { get; set; }
        public int PhAnoperiodo { get; set; }
        public DateTime PhFechaInicio { get; set; }
        public DateTime? PhFechaFin { get; set; }
        public string PhAutorizadoPor { get; set; }

        public virtual Alumno PhAlumno { get; set; }
        public virtual Administrativos PhAutorizadoPorNavigation { get; set; }
    }
}
