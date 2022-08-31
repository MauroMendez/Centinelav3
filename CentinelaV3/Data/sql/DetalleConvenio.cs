using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DetalleConvenio
    {
        public int DcId { get; set; }
        public int DcConvenio { get; set; }
        public int DcCuentaDetalle { get; set; }
        public long DcUsuid { get; set; }
        public DateTime DcFechaRegistro { get; set; }

        public virtual Convenios DcConvenioNavigation { get; set; }
        public virtual DetalleCuentaPorCobrar DcCuentaDetalleNavigation { get; set; }
    }
}
