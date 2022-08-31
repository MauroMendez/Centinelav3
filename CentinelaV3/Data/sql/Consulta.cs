using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Consulta
    {
        public int CConsultaId { get; set; }
        public string CPacienteId { get; set; }
        public string CDiagnostico { get; set; }
        public string CReceta { get; set; }
        public decimal CPeso { get; set; }
        public DateTime CFecha { get; set; }
        public DateTime? CProximaCita { get; set; }

        public virtual DatosMedicos CPaciente { get; set; }
    }
}
