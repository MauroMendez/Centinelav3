using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Seguimiento
    {
        public long SeguimientosProspectoId { get; set; }
        public long? Usuid { get; set; }
        public int? SeguimientoEstatus { get; set; }
        public int SeguimientosPeriodo { get; set; }
        public DateTime? SeguimientosFechaProx { get; set; }
        public DateTime SeguimientosFecha { get; set; }
        public string SeguimientosObservaciones { get; set; }
        public long? GpProspectoId { get; set; }
        public int? TsId { get; set; }
        public bool SeguimientosEcho { get; set; }
        public string SeguimientosAcciones { get; set; }
        public DateTime? FechaSeguimiento { get; set; }
    }
}
