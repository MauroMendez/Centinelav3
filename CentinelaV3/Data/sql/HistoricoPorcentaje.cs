using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class HistoricoPorcentaje
    {
        public long HpAlumnoId { get; set; }
        public int HpPorcentaje { get; set; }
        public DateTime HpFechaInicio { get; set; }
        public DateTime? HpFechaFin { get; set; }
        public string HpAutorizadoPor { get; set; }

        public virtual Alumno HpAlumno { get; set; }
        public virtual Administrativos HpAutorizadoPorNavigation { get; set; }
    }
}
