using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DetalleCancelacionPago
    {
        public int DcId { get; set; }
        public int DcCancelacionId { get; set; }
        public int DcPagoId { get; set; }
        public int DcCuentaDetalle { get; set; }
        public string DcDocLinea { get; set; }
        public decimal DcImporteAplicado { get; set; }
        public decimal DcImportePendiente { get; set; }
        public bool? DcSaldoCreado { get; set; }
        public long DcUsuid { get; set; }
        public DateTime DcFechaRegistro { get; set; }

        public virtual CancelacionPagos DcCancelacion { get; set; }
        public virtual DetalleCuentaPorCobrar DcCuentaDetalleNavigation { get; set; }
        public virtual AlumnoPagos DcPago { get; set; }
    }
}
