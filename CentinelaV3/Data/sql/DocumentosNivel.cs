using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DocumentosNivel
    {
        public long IdDocumentoNivel { get; set; }
        public long IdDocumento { get; set; }
        public int NivelId { get; set; }
        public bool? DocCuadro { get; set; }
        public bool? DocInEstatus { get; set; }
        public int? DocOrden { get; set; }

        public virtual Documentos IdDocumentoNavigation { get; set; }
        public virtual Niveles Nivel { get; set; }
    }
}
