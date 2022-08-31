using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewReporteConvenios
    {
        public int ConId { get; set; }
        public string AlMatricula { get; set; }
        public string AlNombre { get; set; }
        public string AlApp { get; set; }
        public string AlApm { get; set; }
        public string NivelNombre { get; set; }
        public string CarreraClave { get; set; }
        public int CpcAño { get; set; }
        public string PeriodosNombre { get; set; }
        public DateTime ConFechaCreacion { get; set; }
        public DateTime ConFechaInicio { get; set; }
        public DateTime ConFechaFin { get; set; }
        public int SlStatusId { get; set; }
        public string SlDescripcion { get; set; }
        public string BecasClave { get; set; }
        public string BecasNombre { get; set; }
        public int Beinscrip { get; set; }
        public int Beparcialidades { get; set; }
        public int DcpcId { get; set; }
        public string ConClave { get; set; }
        public string DcpcDescripcion { get; set; }
        public decimal DcpcImportePendiente { get; set; }
        public int ConEstatus { get; set; }
    }
}
