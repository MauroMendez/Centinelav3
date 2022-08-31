using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewPagosRegistrados
    {
        public long RReferenciaId { get; set; }
        public int ApPagoId { get; set; }
        public long ApAlumnoId { get; set; }
        public string AlMatricula { get; set; }
        public string ApAlumnoClave { get; set; }
        public string NivelNombre { get; set; }
        public string MpDescripcion { get; set; }
        public string FpDescripcion { get; set; }
        public decimal ApImporteTotal { get; set; }
        public decimal ApImportePendiente { get; set; }
        public string ApReferencia { get; set; }
        public string ApReferenciaBancaria { get; set; }
        public DateTime ApFechaCreacion { get; set; }
        public DateTime ApFechaContable { get; set; }
        public DateTime ApFechaBancaria { get; set; }
        public string ApObservaciones { get; set; }
        public int ApEstatus { get; set; }
        public DateTime? ApFechaRegistro { get; set; }
        public string CbNombreCuenta { get; set; }
        public int CbCuentaId { get; set; }
    }
}
