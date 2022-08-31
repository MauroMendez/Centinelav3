using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PuestosHistorial
    {
        public string PhAdminId { get; set; }
        public decimal PhNivel { get; set; }
        public int PhPuestoId { get; set; }
        public float PhSueldo { get; set; }
        public DateTime PhFechaInicio { get; set; }
        public DateTime? PhFechaFin { get; set; }
        public int? PhRepotaA { get; set; }

        public virtual Administrativos PhAdmin { get; set; }
    }
}
