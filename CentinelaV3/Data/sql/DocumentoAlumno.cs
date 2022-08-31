using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DocumentoAlumno
    {
        public long IdDocumentoAl { get; set; }
        public long AlId { get; set; }
        public long IdDocumento { get; set; }
        public int Addcestatus { get; set; }

        public virtual EstatusList AddcestatusNavigation { get; set; }
        public virtual Alumno Al { get; set; }
        public virtual Documentos IdDocumentoNavigation { get; set; }
    }
}
