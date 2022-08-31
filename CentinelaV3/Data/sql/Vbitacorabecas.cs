using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Vbitacorabecas
    {
        public short Ccbbid { get; set; }
        public long Beid { get; set; }
        public string AlMatricula { get; set; }
        public short? Ccbbanio { get; set; }
        public int? Ccbbperiodo { get; set; }
        public int? Ccbbinscrip { get; set; }
        public int? Ccbbparcial { get; set; }
        public string BecasClave { get; set; }
        public string BecasNombre { get; set; }
        public int? DescProm { get; set; }
        public string Usuusuario { get; set; }
        public DateTime? Ccbbfecha { get; set; }
        public string SlDescripcion { get; set; }
    }
}
