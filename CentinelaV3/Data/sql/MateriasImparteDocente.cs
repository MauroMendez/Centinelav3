using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class MateriasImparteDocente
    {
        public string MidDocenteId { get; set; }
        public int MidMateriaId { get; set; }

        public virtual Administrativos MidDocente { get; set; }
        public virtual Materias MidMateria { get; set; }
    }
}
