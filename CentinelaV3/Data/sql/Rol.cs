using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Rol
    {
        public Rol()
        {
            Tpermisos = new HashSet<Tpermisos>();
        }

        public int Rolid { get; set; }
        public string Rolnombre { get; set; }
        public DateTime? Rolfecha { get; set; }
        public string Roldescripcion { get; set; }
        public decimal Rolactivo { get; set; }

        public virtual ICollection<Tpermisos> Tpermisos { get; set; }
    }
}
