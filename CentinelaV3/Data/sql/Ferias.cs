using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Ferias
    {
        public Ferias()
        {
            GeneralesProspecto = new HashSet<GeneralesProspecto>();
        }

        public long Idferia { get; set; }
        public DateTime? Feriafechainicio { get; set; }
        public DateTime? Feriafechafin { get; set; }
        public int? Campid { get; set; }
        public long? Usuid { get; set; }
        public string Ferianombre { get; set; }

        public virtual Campana Camp { get; set; }
        public virtual Usuario Usu { get; set; }
        public virtual ICollection<GeneralesProspecto> GeneralesProspecto { get; set; }
    }
}
