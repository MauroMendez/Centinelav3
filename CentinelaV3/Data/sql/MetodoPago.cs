using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class MetodoPago
    {
        public MetodoPago()
        {
            AlumnoPagos = new HashSet<AlumnoPagos>();
        }

        public int MpMetodoId { get; set; }
        public string MpClave { get; set; }
        public string MpDescripcion { get; set; }

        public virtual ICollection<AlumnoPagos> AlumnoPagos { get; set; }
    }
}
