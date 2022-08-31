using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class PorcentageBecaHistoricoProspecto
    {
        public string PbhpAlumnoId { get; set; }
        public int PbhpPorcentaje { get; set; }
        public int? PbhpBecaId { get; set; }
        public DateTime PbhpFecha { get; set; }
        public string PbhpCambioPor { get; set; }

        public virtual Administrativos PbhpCambioPorNavigation { get; set; }
    }
}
