using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Ravisodeudores
    {
        public long AlId { get; set; }
        public string AlMatricula { get; set; }
        public string AdNombre { get; set; }
        public string AdaPaterno { get; set; }
        public string AdaMaterno { get; set; }
        public string AdEmail { get; set; }
        public int? Addivision { get; set; }
        public string Div { get; set; }
        public int? AdCarrera { get; set; }
        public string Carre { get; set; }
    }
}
