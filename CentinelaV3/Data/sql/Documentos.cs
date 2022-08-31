using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Documentos
    {
        public Documentos()
        {
            DocumentoAlumno = new HashSet<DocumentoAlumno>();
            DocumentoBitacora = new HashSet<DocumentoBitacora>();
            DocumentosNivel = new HashSet<DocumentosNivel>();
        }

        public long IdDocumento { get; set; }
        public string NombreDoc { get; set; }
        public string NomCuadroDoc { get; set; }

        public virtual ICollection<DocumentoAlumno> DocumentoAlumno { get; set; }
        public virtual ICollection<DocumentoBitacora> DocumentoBitacora { get; set; }
        public virtual ICollection<DocumentosNivel> DocumentosNivel { get; set; }
    }
}
