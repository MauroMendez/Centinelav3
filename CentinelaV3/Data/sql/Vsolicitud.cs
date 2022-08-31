using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Vsolicitud
    {
        public string RReferenciaId { get; set; }
        public string Alumno { get; set; }
        public string CodBarras { get; set; }
        public decimal EfectivoMonto { get; set; }
        public DateTime? FechaExpiro { get; set; }
        public string EfecState { get; set; }
        public long SolicitudId { get; set; }
    }
}
