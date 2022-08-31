using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class CancelacionCuenta
    {
        public int CanId { get; set; }
        public int CanCuentaId { get; set; }
        public int CanTipoCancelacion { get; set; }
        public DateTime CanFechaCancelacion { get; set; }
        public string CanComentario { get; set; }
        public long CanUsuid { get; set; }
        public DateTime CanFechaRegistro { get; set; }

        public virtual CuentasPorCobrar CanCuenta { get; set; }
        public virtual CatalogoCancelacion CanTipoCancelacionNavigation { get; set; }
    }
}
