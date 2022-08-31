using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class CatalogoCancelacion
    {
        public CatalogoCancelacion()
        {
            CancelacionCuenta = new HashSet<CancelacionCuenta>();
            CancelacionPagos = new HashSet<CancelacionPagos>();
        }

        public int CcanId { get; set; }
        public string CcanDescripcion { get; set; }
        public long CcanUsuid { get; set; }
        public DateTime CcanFechaRegistro { get; set; }
        public string CcanClave { get; set; }

        public virtual ICollection<CancelacionCuenta> CancelacionCuenta { get; set; }
        public virtual ICollection<CancelacionPagos> CancelacionPagos { get; set; }
    }
}
