using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class InscritosUsuario
    {
        public long Usuid { get; set; }
        public string Promotor { get; set; }
        public int? Inscritos { get; set; }
        public int Campid { get; set; }
    }
}
