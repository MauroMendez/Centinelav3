using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class AlergiaPaciente
    {
        public string ApPacienteId { get; set; }
        public int ApAlergiaId { get; set; }

        public virtual DatosMedicos ApPaciente { get; set; }
    }
}
