using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PlanesEstudio
    {
        public PlanesEstudio()
        {
            Carreras = new HashSet<Carreras>();
        }

        public int? PeAnio { get; set; }
        public string PeNombre { get; set; }
        public DateTime? PeFeReg { get; set; }
        public long? Usuid { get; set; }
        public string PeIp { get; set; }
        public int PeId { get; set; }

        public virtual Usuario Usu { get; set; }
        public virtual ICollection<Carreras> Carreras { get; set; }
    }
}
