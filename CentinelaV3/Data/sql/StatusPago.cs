using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class StatusPago
    {
        public StatusPago()
        {
            AlumnoPo = new HashSet<AlumnoPo>();
        }

        public int SpStatusId { get; set; }
        public string SpNombre { get; set; }
        public string SpDescripcion { get; set; }

        public virtual ICollection<AlumnoPo> AlumnoPo { get; set; }
    }
}
