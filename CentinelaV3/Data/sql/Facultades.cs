using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Facultades
    {
        public Facultades()
        {
            Carreras = new HashSet<Carreras>();
        }

        public decimal FacFacultadId { get; set; }
        public string FacNombre { get; set; }
        public string FacDescripcion { get; set; }

        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
