using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Campana
    {
        public Campana()
        {
            Campanameta = new HashSet<Campanameta>();
            Ferias = new HashSet<Ferias>();
            GeneralesProspecto = new HashSet<GeneralesProspecto>();
        }

        public int Campid { get; set; }
        public short Campanio { get; set; }
        public short Campperiodo { get; set; }
        public DateTime Campfecini { get; set; }
        public DateTime Campfecfin { get; set; }
        public decimal Camppresupuesto { get; set; }
        public DateTime Campfecreg { get; set; }
        public long? Usuid { get; set; }
        public short Campmeta { get; set; }

        public virtual Usuario Usu { get; set; }
        public virtual ICollection<Campanameta> Campanameta { get; set; }
        public virtual ICollection<Ferias> Ferias { get; set; }
        public virtual ICollection<GeneralesProspecto> GeneralesProspecto { get; set; }
    }
}
