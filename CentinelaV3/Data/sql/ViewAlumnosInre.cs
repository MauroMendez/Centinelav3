using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ViewAlumnosInre
    {
        public string AlMatricula { get; set; }
        public string AlApp { get; set; }
        public string AlApm { get; set; }
        public string AlNombre { get; set; }
        public string NivelNombre { get; set; }
        public string CarreraClave { get; set; }
        public string BecasClave { get; set; }
        public string BecasDescripcion { get; set; }
        public int AlBecaInscripcion { get; set; }
        public int AlBecaParcialidad { get; set; }
        public int? AlSemestre { get; set; }
        public string AlGrupo { get; set; }
        public string GaTelefonoAlumno { get; set; }
        public string GaTelefonoTutor { get; set; }
        public string GaCorreoAlternativo { get; set; }
        public string GpTelefono { get; set; }
        public string GpCorreoElectronico { get; set; }
        public int AlStatusActual { get; set; }
        public int CpcPeriodo { get; set; }
        public int CpcAño { get; set; }
    }
}
