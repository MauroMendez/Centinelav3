using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Grupos
    {
        public int GGrupoId { get; set; }
        public string GNombre { get; set; }
        public int GPeriodo { get; set; }
        public int GAno { get; set; }
        public int GNivel { get; set; }
        public DateTime GFechaInicio { get; set; }
        public DateTime GFechaFin { get; set; }
        public int GCapacidad { get; set; }

        public virtual Niveles GNivelNavigation { get; set; }
        public virtual Periodos GPeriodoNavigation { get; set; }
    }
}
