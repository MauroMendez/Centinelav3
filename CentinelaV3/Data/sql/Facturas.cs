using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Facturas
    {
        public int FFacturaId { get; set; }
        public string FRfc { get; set; }
        public int FPagoId { get; set; }
        public DateTime FFecha { get; set; }
        public DateTime FFechaContable { get; set; }
        public float FIva { get; set; }
        public float FTotal { get; set; }
        public string FUso { get; set; }
        public bool FCancelado { get; set; }

        public virtual AlumnoPagos FPago { get; set; }
    }
}
