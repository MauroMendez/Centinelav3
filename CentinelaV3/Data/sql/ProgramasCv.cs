using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ProgramasCv
    {
        public ProgramasCv()
        {
            RegistrosCv = new HashSet<RegistrosCv>();
        }

        public int IdPrograma { get; set; }
        public string NombrePrograma { get; set; }
        public int Modalidad { get; set; }
        public int? MMateriaId { get; set; }
        public long ProgramaUser { get; set; }
        public DateTime ProgramaRegistro { get; set; }
        public bool ProgramaActivo { get; set; }
        public int? IdMoodle { get; set; }
        public int? ProgramaPadre { get; set; }

        public virtual Usuario ProgramaUserNavigation { get; set; }
        public virtual ICollection<RegistrosCv> RegistrosCv { get; set; }
    }
}
