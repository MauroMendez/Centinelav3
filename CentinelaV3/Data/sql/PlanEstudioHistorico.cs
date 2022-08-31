using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PlanEstudioHistorico
    {
        public long PehAlumnoId { get; set; }
        public int PehPlanId { get; set; }
        public DateTime PehFechaInicio { get; set; }
        public DateTime? PehFechaFin { get; set; }
        public string PehAutorizadoPor { get; set; }

        public virtual Alumno PehAlumno { get; set; }
        public virtual Administrativos PehAutorizadoPorNavigation { get; set; }
    }
}
