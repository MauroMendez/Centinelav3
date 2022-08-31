using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class RegistroChecador
    {
        public int RcId { get; set; }
        public long RcAdminNumeroEmpleado { get; set; }
        public DateTime RcFechaRegistro { get; set; }
        public TimeSpan RcHoraRegistro { get; set; }
    }
}
