using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Edificios
    {
        public Edificios()
        {
            Salones = new HashSet<Salones>();
        }

        public int EEdificioId { get; set; }
        public string ENombre { get; set; }
        public string EDescripcion { get; set; }

        public virtual ICollection<Salones> Salones { get; set; }
    }
}
