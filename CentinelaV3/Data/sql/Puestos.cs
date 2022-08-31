using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Puestos
    {
        public Puestos()
        {
            InversePuestosReportaANavigation = new HashSet<Puestos>();
        }

        public int PuestosId { get; set; }
        public string PuestosNombre { get; set; }
        public string PuestosDescripcion { get; set; }
        public int PuestosReportaA { get; set; }
        public int PuestosArea { get; set; }

        public virtual Areas PuestosAreaNavigation { get; set; }
        public virtual Puestos PuestosReportaANavigation { get; set; }
        public virtual ICollection<Puestos> InversePuestosReportaANavigation { get; set; }
    }
}
