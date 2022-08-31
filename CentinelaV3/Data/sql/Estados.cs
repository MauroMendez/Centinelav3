using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Estados
    {
        public Estados()
        {
            Convenios = new HashSet<Convenios>();
            DatosFacturacion = new HashSet<DatosFacturacion>();
            GeneralesAlumno = new HashSet<GeneralesAlumno>();
            Municipios = new HashSet<Municipios>();
        }

        public int EstadosId { get; set; }
        public string EstadosNombre { get; set; }

        public virtual ICollection<Convenios> Convenios { get; set; }
        public virtual ICollection<DatosFacturacion> DatosFacturacion { get; set; }
        public virtual ICollection<GeneralesAlumno> GeneralesAlumno { get; set; }
        public virtual ICollection<Municipios> Municipios { get; set; }
    }
}
