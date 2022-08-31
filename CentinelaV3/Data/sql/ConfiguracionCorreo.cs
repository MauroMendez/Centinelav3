using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ConfiguracionCorreo
    {
        public int CoId { get; set; }
        public string CoDescripcion { get; set; }
        public string CoCorreoEnvio { get; set; }
        public string CoPassEnvio { get; set; }
        public string CoKey { get; set; }
        public string CoServidorSmtp { get; set; }
        public int CoPuertoSmtp { get; set; }
        public int CoModuloId { get; set; }
        public int? CoNivelId { get; set; }
        public DateTime CoFechaRegistro { get; set; }
        public long CoUsuid { get; set; }

        public virtual Modulo CoModulo { get; set; }
        public virtual Niveles CoNivel { get; set; }
    }
}
