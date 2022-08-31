using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ConvenioParcialidad
    {
        public int CpId { get; set; }
        public int CpConvenio { get; set; }
        public string CpDocLinea { get; set; }
        public decimal CpMontoPago { get; set; }
        public DateTime CpFechaPago { get; set; }
        public int CpEstatus { get; set; }
        public long CpUsuid { get; set; }
        public DateTime CpFechaRegistro { get; set; }

        public virtual Convenios CpConvenioNavigation { get; set; }
        public virtual EstatusList CpEstatusNavigation { get; set; }
    }
}
