using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class HistoricoPlanesEstudio
    {
        public int HpeId { get; set; }
        public string HpeClaveOficial { get; set; }
        public string HpeNombre { get; set; }
        public string HpeDescripcion { get; set; }
        public decimal HpeCosto { get; set; }
        public bool HpeActivo { get; set; }
        public DateTime HpeFechaCreacion { get; set; }
        public decimal HpeCreditos { get; set; }
        public decimal HpeMaterias { get; set; }
        public decimal HpeFacultad { get; set; }
        public int HpeNivel { get; set; }
        public DateTime HpeFechaModificacion { get; set; }
        public string HpeRvoe { get; set; }
        public DateTime? HpeRvoeCreacion { get; set; }
        public string HpeAutorizadoPor { get; set; }

        public virtual Administrativos HpeAutorizadoPorNavigation { get; set; }
    }
}
