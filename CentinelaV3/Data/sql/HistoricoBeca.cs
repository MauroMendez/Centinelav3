using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class HistoricoBeca
    {
        public long HbAlumnoId { get; set; }
        public int HbBecaId { get; set; }
        public DateTime HbFechaInicio { get; set; }
        public DateTime? HbFechaFin { get; set; }
        public string HbAutorizadoPor { get; set; }

        public virtual Alumno HbAlumno { get; set; }
        public virtual Administrativos HbAutorizadoPorNavigation { get; set; }
    }
}
