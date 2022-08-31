using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class EscolaridadAdmin
    {
        public string EscAdminId { get; set; }
        public string EscTitulo { get; set; }
        public string EscDescripcion { get; set; }
        public DateTime EscFechaInicio { get; set; }
        public DateTime EscFechaFin { get; set; }
        public string EscCedula { get; set; }

        public virtual Administrativos EscAdmin { get; set; }
    }
}
