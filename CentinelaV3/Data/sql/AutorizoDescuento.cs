using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class AutorizoDescuento
    {
        public int AdPagoId { get; set; }
        public string AdAutorizadoPor { get; set; }
        public int AdDescuento { get; set; }
        public string AdComentario { get; set; }

        public virtual Administrativos AdAutorizadoPorNavigation { get; set; }
    }
}
