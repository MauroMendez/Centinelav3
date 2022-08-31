using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Vidsolicitud
    {
        public long SolicitudId { get; set; }
        public string EfectivoSignature { get; set; }
        public string Alumno { get; set; }
        public string RReferenciaId { get; set; }
    }
}
