using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewAlumnosConPagoActual
    {
        public string CpcAlumnoClave { get; set; }
        public int AlAnoPeriodoActual { get; set; }
        public int AlPeriodoActual { get; set; }
        public int CpcPeriodo { get; set; }
        public int CpcAño { get; set; }
    }
}
