using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewPagoAlumno
    {
        public int CpcAño { get; set; }
        public int CpcPeriodo { get; set; }
        public int CpcEstatus { get; set; }
        public int CpcListaPrecio { get; set; }
        public int LpConcepto { get; set; }
        public int ConId { get; set; }
        public string ConClave { get; set; }
        public string DcpcDoclinea { get; set; }
        public string CpcAlumnoClave { get; set; }
    }
}
