using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Periodos
    {
        public Periodos()
        {
            Alumno = new HashSet<Alumno>();
            Grupos = new HashSet<Grupos>();
        }

        public int PeriodosId { get; set; }
        public string PeriodosNombre { get; set; }

        public virtual ICollection<Alumno> Alumno { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
    }
}
