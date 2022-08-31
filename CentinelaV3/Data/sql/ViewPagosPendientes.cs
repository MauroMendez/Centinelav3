using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewPagosPendientes
    {
        public int DcpcId { get; set; }
        public int DcpcCuentaId { get; set; }
        public string DcpcDescripcion { get; set; }
        public string DcpcDocLinea { get; set; }
        public decimal DcpcImportePendiente { get; set; }
        public decimal DcpcImporteTotal { get; set; }
        public DateTime DcpcFechaVencimiento { get; set; }
        public int DcpcEstatus { get; set; }
        public int SlStatusId { get; set; }
        public string SlNombre { get; set; }
        public int CpcId { get; set; }
        public int CpcListaPrecio { get; set; }
        public string CpcAlumnoClave { get; set; }
        public int? CpcReferenciaCuenta { get; set; }
        public DateTime CpcFechaCreacion { get; set; }
        public decimal CpcImporteTotal { get; set; }
        public decimal CpcImportePendiente { get; set; }
        public int CpcAño { get; set; }
        public int CpcPeriodo { get; set; }
        public int CpcEstatus { get; set; }
        public long CpcUsuid { get; set; }
        public DateTime CpcFechaRegistro { get; set; }
        public int CpcUnidad { get; set; }
        public decimal CpcPrecioUnitario { get; set; }
    }
}
