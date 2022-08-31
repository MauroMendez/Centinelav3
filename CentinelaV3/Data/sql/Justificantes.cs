using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Justificantes
    {
        public string JJustificanteId { get; set; }
        public string JAlumnoId { get; set; }
        public DateTime JFechaInicio { get; set; }
        public DateTime JFechaFin { get; set; }
        public int JTipoJustificante { get; set; }
        public int JFaltaId { get; set; }

        public virtual DatosMedicos JAlumno { get; set; }
    }
}
