using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Boleta
    {
        public int BGrupoId { get; set; }
        public string BAlumnoId { get; set; }
        public int BMateriaId { get; set; }
        public int BMomento { get; set; }
        public float BCalificacion { get; set; }
        public DateTime BFechaRegistro { get; set; }

        public virtual Grupos BGrupo { get; set; }
        public virtual Materias BMateria { get; set; }
        public virtual Momento BMomentoNavigation { get; set; }
    }
}
