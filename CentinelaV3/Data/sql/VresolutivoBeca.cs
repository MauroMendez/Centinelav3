using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VresolutivoBeca
    {
        public long Beid { get; set; }
        public short? Beanio { get; set; }
        public int? Beperiodo { get; set; }
        public int Beinscrip { get; set; }
        public int Beparcialidades { get; set; }
        public int? Beestatus { get; set; }
        public string BecasClave { get; set; }
        public string BecasNombre { get; set; }
        public string AlMatricula { get; set; }
        public string AlNombre { get; set; }
        public string AlApp { get; set; }
        public string AlApm { get; set; }
        public string CarreraNombre { get; set; }
        public string NivelNombre { get; set; }
        public string NivelDescripcion { get; set; }
        public string PeriodosNombre { get; set; }
        public string CarreraClave { get; set; }
        public int PeriodosId { get; set; }
        public long? AlId { get; set; }
        public int? BecasId { get; set; }
    }
}
