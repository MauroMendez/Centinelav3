using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ConvenioHistorico
    {
        public int ChConvenioId { get; set; }
        public string ChMotivo { get; set; }
        public DateTime? ChFechaModificacion { get; set; }
        public DateTime? ChFechaCreacion { get; set; }
        public DateTime? ChFechaLimite { get; set; }
        public int? ConConvenioId { get; set; }
        public long? Usuid { get; set; }
        public string ChModificadoPor { get; set; }

        public virtual Convenios ConConvenio { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}
