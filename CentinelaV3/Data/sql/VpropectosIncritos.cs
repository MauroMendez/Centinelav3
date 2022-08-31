using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VpropectosIncritos
    {
        public long GpProspectoId { get; set; }
        public int GpEstatus { get; set; }
        public string SlDescripcion { get; set; }
        public string GpporsMat { get; set; }
        public string GpNombre { get; set; }
        public string GpApp { get; set; }
        public string GpApm { get; set; }
        public DateTime? Gppfecha { get; set; }
        public int Campid { get; set; }
        public short Campanio { get; set; }
        public short Campperiodo { get; set; }
        public string PeriodosNombre { get; set; }
        public string CarreraNombre { get; set; }
        public string CarreraClave { get; set; }
        public int GpModalidadInterez { get; set; }
    }
}
