using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Kardex
    {
        public string KAlumnoId { get; set; }
        public int KGrupoId { get; set; }
        public int KMateriaId { get; set; }
        public decimal KCalificacionFinal { get; set; }
        public string KObservaciones { get; set; }
        public DateTime KFechaRegistro { get; set; }
        public int KPeriodo { get; set; }
        public int KAno { get; set; }
        public int KCiclo { get; set; }

        public virtual Grupos KGrupo { get; set; }
        public virtual Materias KMateria { get; set; }
    }
}
