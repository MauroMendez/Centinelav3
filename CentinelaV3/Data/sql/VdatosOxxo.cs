using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VdatosOxxo
    {
        public long GpProspectoId { get; set; }
        public string GpporsMat { get; set; }
        public string GpCorreoElectronico { get; set; }
        public double? GpImporte { get; set; }
        public int Idcarrera { get; set; }
        public string CarreraClave { get; set; }
        public string CarreraNombre { get; set; }
        public int? NivelId { get; set; }
        public string NivelDescripcion { get; set; }
        public string NivelNombre { get; set; }
    }
}
