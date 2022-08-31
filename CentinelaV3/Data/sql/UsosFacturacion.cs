using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class UsosFacturacion
    {
        public UsosFacturacion()
        {
            DatosFacturacion = new HashSet<DatosFacturacion>();
        }

        public string UfUsoId { get; set; }
        public decimal? UfUso { get; set; }
        public string UfDescripcion { get; set; }

        public virtual ICollection<DatosFacturacion> DatosFacturacion { get; set; }
    }
}
