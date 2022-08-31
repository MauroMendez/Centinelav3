using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Tbususesion
    {
        public long Idbusus { get; set; }
        public long Usuid { get; set; }
        public string Tbipaddresss { get; set; }
        public string Tbuso { get; set; }
        public string Tbucliente { get; set; }
        public DateTime Tbufechaegreso { get; set; }
        public DateTime TbufechaIngreso { get; set; }
        public string Tbucoordenadas { get; set; }
        public string TbipLocalAdress { get; set; }

        public virtual Usuario Usu { get; set; }
    }
}
