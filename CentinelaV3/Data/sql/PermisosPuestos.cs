using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PermisosPuestos
    {
        public int PpPuestoId { get; set; }
        public int PpPermiso { get; set; }
        public bool PpActivo { get; set; }

        public virtual Permisos PpPermisoNavigation { get; set; }
        public virtual Puestos PpPuesto { get; set; }
    }
}
