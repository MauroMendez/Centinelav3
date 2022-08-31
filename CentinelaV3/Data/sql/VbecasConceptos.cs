using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VbecasConceptos
    {
        public int ConId { get; set; }
        public string ConClave { get; set; }
        public int BecasId { get; set; }
        public string BecasClave { get; set; }
        public int LpId { get; set; }
        public string LpDescripcion { get; set; }
    }
}
