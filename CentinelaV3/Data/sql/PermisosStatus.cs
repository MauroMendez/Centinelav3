using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PermisosStatus
    {
        public int PsStatusId { get; set; }
        public int PsPermiso { get; set; }
        public bool PsActivo { get; set; }

        public virtual PermisosAlumnos PsPermisoNavigation { get; set; }
        public virtual EstatusList PsStatus { get; set; }
    }
}
