using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Salones
    {
        public int SSalonId { get; set; }
        public string SNombre { get; set; }
        public int SEdificio { get; set; }
        public string SDescripcion { get; set; }

        public virtual Edificios SEdificioNavigation { get; set; }
    }
}
