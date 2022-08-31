using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewRptpagosConceptos
    {
        public int CpcId { get; set; }
        public string AlMatricula { get; set; }
        public string AlNombre { get; set; }
        public string NivelNombre { get; set; }
        public string CarreraClave { get; set; }
        public int? AlSemestre { get; set; }
        public string AlGrupo { get; set; }
        public string ConDescripcion { get; set; }
        public int ConTipoConcepto { get; set; }
        public DateTime? ApFechaRegistro { get; set; }
        public decimal ApImporteTotal { get; set; }
        public string FpClave { get; set; }
        public string FpDescripcion { get; set; }
        public int LpId { get; set; }
        public string ConClave { get; set; }
    }
}
