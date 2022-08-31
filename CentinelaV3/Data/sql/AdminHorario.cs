using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class AdminHorario
    {
        public string AhAdminId { get; set; }
        public int AhTipoHorarioId { get; set; }
        public int? AhPuestoId { get; set; }
        public int AhDia { get; set; }
        public int AhHoraInicio { get; set; }
        public int AhMinutoInicio { get; set; }
        public int AhHoraFin { get; set; }
        public int AhMinutoFin { get; set; }

        public virtual Administrativos AhAdmin { get; set; }
    }
}
