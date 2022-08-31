using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Rdeudores
    {
        public long Rd { get; set; }
        public DateTime Rdfecreg { get; set; }
        public DateTime? Rdtimereg { get; set; }
        public DateTime? Rdtimefin { get; set; }
    }
}
