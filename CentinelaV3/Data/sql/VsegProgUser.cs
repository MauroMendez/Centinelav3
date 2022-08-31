using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VsegProgUser
    {
        public long SeguimientosProspectoId { get; set; }
        public long? GpProspectoId { get; set; }
        public DateTime SeguimientosFecha { get; set; }
        public string SeguimientosObservaciones { get; set; }
        public string SeguimientosAcciones { get; set; }
        public DateTime? FechaSeguimiento { get; set; }
        public long Usuid { get; set; }
        public string Usuusuario { get; set; }
        public string GpporsMat { get; set; }
        public string Prospecto { get; set; }
        public string GpTelefono { get; set; }
        public string GpCorreoElectronico { get; set; }
        public string Promotor { get; set; }
        public string AdminId { get; set; }
        public string Carrera { get; set; }
        public DateTime? SeguimientosFechaProx { get; set; }
        public bool SeguimientosEcho { get; set; }
        public int? TsId { get; set; }
        public string TsDescripcion { get; set; }
    }
}
