using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Transfpayu
    {
        public int IdTran { get; set; }
        public DateTime TranFecha { get; set; }
        public string TranCorigen { get; set; }
        public string TranCdestino { get; set; }
        public string TranTitular { get; set; }
        public decimal TranMonto { get; set; }
        public string TranTipocuenta { get; set; }
        public string TranTipotran { get; set; }
        public string TranEstatus { get; set; }
    }
}
