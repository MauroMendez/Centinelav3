using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class StatusHistorial
    {
        public long ShAlumnoId { get; set; }
        public int ShStatus { get; set; }
        public DateTime? ShFechaInicio { get; set; }
        public DateTime? ShFechaFin { get; set; }
        public string ShAutorizadoPor { get; set; }
        public long AlId { get; set; }
        public DateTime? ShFecha { get; set; }
        public TimeSpan? ShHora { get; set; }
        public string ShAnio { get; set; }
        public int PeriodosId { get; set; }
        public string ShComentario { get; set; }
        public string AlMatricula { get; set; }
    }
}
