using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class HijosAdmin
    {
        public string HaAdminId { get; set; }
        public string HaNombre { get; set; }
        public string HaApp { get; set; }
        public string HaApm { get; set; }
        public DateTime HaFechaNac { get; set; }

        public virtual Administrativos HaAdmin { get; set; }
    }
}
