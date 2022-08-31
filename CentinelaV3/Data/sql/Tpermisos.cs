using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Tpermisos
    {
        public int IdPermiso { get; set; }
        public int Rolid { get; set; }
        public int IdPantalla { get; set; }
        public int ModuloId { get; set; }
        public DateTime? PermisoFecha { get; set; }
        public decimal TipoPermiso { get; set; }

        public virtual Pantalla IdPantallaNavigation { get; set; }
        public virtual Modulo Modulo { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
