using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ExpProfecional
    {
        public string EpAdminId { get; set; }
        public string EpEmpleoAnterior { get; set; }
        public string EpDescripcion { get; set; }
        public DateTime EpFechaInicio { get; set; }
        public DateTime EpFechaFin { get; set; }

        public virtual Administrativos EpAdmin { get; set; }
    }
}
