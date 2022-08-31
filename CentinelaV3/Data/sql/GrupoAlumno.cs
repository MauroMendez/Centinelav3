using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class GrupoAlumno
    {
        public int GaGrupoId { get; set; }
        public long GaAlumnoId { get; set; }

        public virtual Alumno GaAlumno { get; set; }
        public virtual Grupos GaGrupo { get; set; }
    }
}
