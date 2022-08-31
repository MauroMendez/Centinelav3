using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Vusuario
    {
        public long Usuid { get; set; }
        public int Rolid { get; set; }
        public string Usuusuario { get; set; }
        public string Usupassword { get; set; }
        public string Usutipo { get; set; }
        public long? Usuidtipo { get; set; }
        public string Usukey { get; set; }
        public bool Usuactivo { get; set; }
        public short? UsumoodleP { get; set; }
        public short? UsumoodleL { get; set; }
        public short? UsumoodleM { get; set; }
        public string Usumovil { get; set; }
        public byte[] Usuimage { get; set; }
        public DateTime? UsulastChange { get; set; }
        public long Idbusus { get; set; }
        public DateTime TbufechaIngreso { get; set; }
        public string Tbucoordenadas { get; set; }
        public string Tbipaddresss { get; set; }
    }
}
