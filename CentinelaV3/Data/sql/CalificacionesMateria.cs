using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class CalificacionesMateria
    {
        public int CmGrupoId { get; set; }
        public long CmAlumnoId { get; set; }
        public int CmMateriaId { get; set; }
        public int CmTipoCalificacion { get; set; }
        public float CmCalificacion { get; set; }
        public int CmMomento { get; set; }

        public virtual Alumno CmAlumno { get; set; }
        public virtual Grupos CmGrupo { get; set; }
        public virtual Materias CmMateria { get; set; }
        public virtual TipoCalificaciones CmTipoCalificacionNavigation { get; set; }
    }
}
