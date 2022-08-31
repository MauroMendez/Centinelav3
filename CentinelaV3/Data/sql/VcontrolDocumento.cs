using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VcontrolDocumento
    {
        public int NivelId { get; set; }
        public string NivelDescripcion { get; set; }
        public long IdDocumento { get; set; }
        public string NombreDoc { get; set; }
        public bool? DocInEstatus { get; set; }
        public int Addcestatus { get; set; }
        public long AlId { get; set; }
        public long IdDocumentoAl { get; set; }
    }
}
