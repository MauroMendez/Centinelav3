using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DetalleReferencia
    {
        public int DrId { get; set; }
        public long DrReferencia { get; set; }
        public int DrCuentaDetalle { get; set; }
        public decimal DrMontoAplicado { get; set; }
        public long DrUsuid { get; set; }
        public DateTime DrFechaRegistro { get; set; }

        public virtual DetalleCuentaPorCobrar DrCuentaDetalleNavigation { get; set; }
        public virtual Referencias DrReferenciaNavigation { get; set; }
    }
}
