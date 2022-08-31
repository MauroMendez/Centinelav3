using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Modalidades
    {
        public Modalidades()
        {
            Alumno = new HashSet<Alumno>();
            Carreras = new HashSet<Carreras>();
        }

        public int ModModalidadId { get; set; }
        public string ModNombre { get; set; }
        public string ModDescripcion { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
