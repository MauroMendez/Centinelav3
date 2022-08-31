using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class CatalogoSaltoPago
    {
        public int CsalId { get; set; }
        public string CsalDescripcion { get; set; }
        public long CsalUsuid { get; set; }
        public DateTime CsalFechaRegistro { get; set; }
    }
}
