using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ClasesGrupo
    {
        public int CgGrupoId { get; set; }
        public int CgMateriaId { get; set; }
        public string CgDoceteId { get; set; }
        public int? CgHoarioId { get; set; }
        public int? CgSalonId { get; set; }

        public virtual Administrativos CgDocete { get; set; }
        public virtual Materias CgMateria { get; set; }
    }
}
