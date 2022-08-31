using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ModificacionesEsquemaPago
    {
        public int MepEsquemaId { get; set; }
        public string MepEpNombre { get; set; }
        public string MepEpDescripcion { get; set; }
        public decimal MepEpMensualidades { get; set; }
        public decimal MepEpDiaLimite { get; set; }
        public decimal? MepEpPenalizacion { get; set; }
        public DateTime MepFechaModificacion { get; set; }
        public string MepModificadoPor { get; set; }

        public virtual Administrativos MepModificadoPorNavigation { get; set; }
    }
}
