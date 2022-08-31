using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Campanameta
    {
        public int Campid { get; set; }
        public long? Usuid { get; set; }
        public int Cmid { get; set; }
        public int? Cmmeta { get; set; }
        public DateTime Cmfecini { get; set; }
        public DateTime Cmfecfin { get; set; }

        public virtual Campana Camp { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}
