using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Horarios
    {
        public int HHorarioId { get; set; }
        public int HHoraInicio { get; set; }
        public int HMinutoInicio { get; set; }
        public int HHoraFin { get; set; }
        public int HMinutoFin { get; set; }
    }
}
