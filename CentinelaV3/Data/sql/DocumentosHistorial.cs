using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DocumentosHistorial
    {
        public long DhPersonaId { get; set; }
        public int DhDocumentoId { get; set; }
        public int DhEstatus { get; set; }
        public DateTime DhFechaCompromiso { get; set; }
        public DateTime? DhFechaEntrega { get; set; }
        public string DhAtendio { get; set; }
        public byte[] DhDocumento { get; set; }

        public virtual Administrativos DhAtendioNavigation { get; set; }
        public virtual Administrativos DhPersona { get; set; }
        public virtual Alumno DhPersonaNavigation { get; set; }
    }
}
