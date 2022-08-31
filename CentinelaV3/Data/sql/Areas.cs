using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Areas
    {
        public Areas()
        {
            Puestos = new HashSet<Puestos>();
        }

        public int AreaId { get; set; }
        public string AreaNombre { get; set; }
        public string AreaDescripcion { get; set; }
        public int? AreaPadre { get; set; }

        public virtual ICollection<Puestos> Puestos { get; set; }
    }
}
