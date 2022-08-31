using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DetalleCuentaPorCobrar
    {
        public DetalleCuentaPorCobrar()
        {
            DetalleCancelacionPago = new HashSet<DetalleCancelacionPago>();
            DetalleConvenio = new HashSet<DetalleConvenio>();
            DetallePago = new HashSet<DetallePago>();
            DetalleReferencia = new HashSet<DetalleReferencia>();
            InverseDcpcReferenciaCuentaDetalleNavigation = new HashSet<DetalleCuentaPorCobrar>();
        }

        public int DcpcId { get; set; }
        public int DcpcCuentaId { get; set; }
        public string DcpcDescripcion { get; set; }
        public string DcpcDocLinea { get; set; }
        public decimal DcpcImporteTotal { get; set; }
        public decimal DcpcImportePendiente { get; set; }
        public DateTime DcpcFechaVencimiento { get; set; }
        public DateTime? DcpcFechaCierreCuenta { get; set; }
        public int? DcpcReferenciaCuentaDetalle { get; set; }
        public int DcpcEstatus { get; set; }
        public long DcpcUsuid { get; set; }
        public DateTime DcpcFechaRegistro { get; set; }
        public int DcpcUnidadAux { get; set; }
        public decimal DdcpcPrecioUnitarioAux { get; set; }
        public int DcpcUnidad { get; set; }
        public decimal DcpcPrecioUnitario { get; set; }

        public virtual CuentasPorCobrar DcpcCuenta { get; set; }
        public virtual EstatusList DcpcEstatusNavigation { get; set; }
        public virtual DetalleCuentaPorCobrar DcpcReferenciaCuentaDetalleNavigation { get; set; }
        public virtual ICollection<DetalleCancelacionPago> DetalleCancelacionPago { get; set; }
        public virtual ICollection<DetalleConvenio> DetalleConvenio { get; set; }
        public virtual ICollection<DetallePago> DetallePago { get; set; }
        public virtual ICollection<DetalleReferencia> DetalleReferencia { get; set; }
        public virtual ICollection<DetalleCuentaPorCobrar> InverseDcpcReferenciaCuentaDetalleNavigation { get; set; }
    }
}
