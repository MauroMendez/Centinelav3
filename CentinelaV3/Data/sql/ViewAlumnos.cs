using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewAlumnos
    {
        public long AlId { get; set; }
        public string AlMatricula { get; set; }
        public DateTime AlFechaIngreso { get; set; }
        public string AlNombre { get; set; }
        public string AlApp { get; set; }
        public string AlApm { get; set; }
        public DateTime AlFechaNac { get; set; }
        public string AlCorreoInst { get; set; }
        public bool AlSexo { get; set; }
        public int AlAnoPeriodoActual { get; set; }
        public int? AlEsquemaPagoActual { get; set; }
        public int AlBecaActual { get; set; }
        public bool AlDocumentos { get; set; }
        public bool AlFactura { get; set; }
        public DateTime AlFechaInicioNivel { get; set; }
        public int AlCicloActual { get; set; }
        public string AlCurp { get; set; }
        public int AlBecaInscripcion { get; set; }
        public int AlDescPromocion { get; set; }
        public int AlPeriodoActual { get; set; }
        public long? AlCoutaAdmin { get; set; }
        public decimal? AlMontoDesc { get; set; }
        public int? AlCarrera { get; set; }
        public string CarreraClave { get; set; }
        public string CarreraNombre { get; set; }
        public int? NivelId { get; set; }
        public string NivelNombre { get; set; }
        public string NivelDescripcion { get; set; }
        public int AlStatusActual { get; set; }
        public string SlNombre { get; set; }
        public string SlDescripcion { get; set; }
        public int AlModalidadActual { get; set; }
        public string ModNombre { get; set; }
        public string ModDescripcion { get; set; }
    }
}
