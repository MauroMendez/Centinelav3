using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class HistoricoPrecios
    {
        public int HpPrecioId { get; set; }
        public float HcMontoAnterior { get; set; }
        public DateTime HcFechaInicio { get; set; }
        public int HcFechaFin { get; set; }
        public string HcCambiadoPor { get; set; }

        public virtual Administrativos HcCambiadoPorNavigation { get; set; }
    }
}
