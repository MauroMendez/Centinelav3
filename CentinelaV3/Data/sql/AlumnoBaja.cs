using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class AlumnoBaja
    {
        public long AbAlumnoId { get; set; }
        public DateTime? AbFechaIngreso { get; set; }
        public DateTime AbFechaBaja { get; set; }
        public int AbTipoBaja { get; set; }
        public string AbMotivoBaja { get; set; }
        public string AbBajaPor { get; set; }
        public string AbAutorizacion1 { get; set; }
        public string AbAutorizacion2 { get; set; }
        public string AbAutorizacion3 { get; set; }
        public string AbAutorizacion4 { get; set; }

        public virtual Alumno AbAlumno { get; set; }
        public virtual Administrativos AbAutorizacion1Navigation { get; set; }
        public virtual Administrativos AbAutorizacion2Navigation { get; set; }
        public virtual Administrativos AbAutorizacion3Navigation { get; set; }
        public virtual Administrativos AbAutorizacion4Navigation { get; set; }
        public virtual Administrativos AbBajaPorNavigation { get; set; }
    }
}
