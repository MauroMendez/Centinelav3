using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewDeudoresPorAlumno
    {
        public decimal DcpcImportePendiente { get; set; }
        public int? ConId { get; set; }
        public int? ConEstatus { get; set; }
        public string CpcAlumnoClave { get; set; }
    }
}
