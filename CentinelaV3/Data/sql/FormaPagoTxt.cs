using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class FormaPagoTxt
    {
        public int FptId { get; set; }
        public int FptFormaPago { get; set; }
        public string FptDescripcionTxt { get; set; }
        public long FptUsuid { get; set; }
        public DateTime FptFechaRegistro { get; set; }

        public virtual FormaPago FptFormaPagoNavigation { get; set; }
    }
}
