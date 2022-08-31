using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DocumentoBitacora
    {
        public long IdBitacora { get; set; }
        public long IdDocumento { get; set; }
        public int NivelId { get; set; }
        public long? Usuid { get; set; }
        public string NombreDocBit { get; set; }
        public string NombreCuadroBit { get; set; }
        public bool? DocCuadroBit { get; set; }
        public bool? DocInEstatusBit { get; set; }
        public int? DocOrdenBit { get; set; }
        public DateTime FechaBit { get; set; }
        public string CambioTipoBit { get; set; }
        public string ComentarioBit { get; set; }
        public string Ipbit { get; set; }

        public virtual Documentos IdDocumentoNavigation { get; set; }
        public virtual Niveles Nivel { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}
