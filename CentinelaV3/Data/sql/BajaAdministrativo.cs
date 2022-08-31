using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class BajaAdministrativo
    {
        public string BaAdminId { get; set; }
        public DateTime BaFechaImicio { get; set; }
        public DateTime BaFechaBaja { get; set; }
        public string BaMotivo { get; set; }
        public bool BaReccomendado { get; set; }

        public virtual Administrativos BaAdmin { get; set; }
    }
}
