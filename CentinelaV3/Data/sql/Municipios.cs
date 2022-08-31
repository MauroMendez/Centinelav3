using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Municipios
    {
        public Municipios()
        {
            DatosFacturacion = new HashSet<DatosFacturacion>();
            GeneralesAlumno = new HashSet<GeneralesAlumno>();
        }

        public int MunicipiosId { get; set; }
        public string MunicipiosNombre { get; set; }
        public int MunicipioEstado { get; set; }

        public virtual Estados MunicipioEstadoNavigation { get; set; }
        public virtual ICollection<DatosFacturacion> DatosFacturacion { get; set; }
        public virtual ICollection<GeneralesAlumno> GeneralesAlumno { get; set; }
    }
}
