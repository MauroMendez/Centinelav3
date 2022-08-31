using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            AlumnoPagos = new HashSet<AlumnoPagos>();
            FormaPagoTxt = new HashSet<FormaPagoTxt>();
        }

        public int FpId { get; set; }
        public string FpClave { get; set; }
        public string FpDescripcion { get; set; }
        public bool? FpActivaManual { get; set; }
        public long FpUsuid { get; set; }
        public DateTime FpFechaRegistro { get; set; }

        public virtual ICollection<AlumnoPagos> AlumnoPagos { get; set; }
        public virtual ICollection<FormaPagoTxt> FormaPagoTxt { get; set; }
    }
}
