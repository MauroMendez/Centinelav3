using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class FaltasClase
    {
        public int FcMateriaId { get; set; }
        public long FcAlumnoId { get; set; }
        public DateTime FcFechaFalta { get; set; }
        public int FcFaltaId { get; set; }

        public virtual Alumno FcAlumno { get; set; }
        public virtual Materias FcMateria { get; set; }
    }
}
