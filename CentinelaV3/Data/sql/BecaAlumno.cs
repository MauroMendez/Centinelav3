using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class BecaAlumno
    {
        public BecaAlumno()
        {
            Becaalubitacora = new HashSet<Becaalubitacora>();
        }

        public long Beid { get; set; }
        public int? BecasId { get; set; }
        public long? Usuid { get; set; }
        public long? AlId { get; set; }
        public int? Beperiodo { get; set; }
        public short? Beanio { get; set; }
        public int Beinscrip { get; set; }
        public int Beparcialidades { get; set; }
        public string Conceptoid { get; set; }
        public int? Betipo { get; set; }
        public int? Beestatus { get; set; }
        public bool? Beconfirma { get; set; }
        public DateTime? Beconfecha { get; set; }

        public virtual Alumno Al { get; set; }
        public virtual Becas Becas { get; set; }
        public virtual EstatusList BeestatusNavigation { get; set; }
        public virtual EstatusList BetipoNavigation { get; set; }
        public virtual Usuario Usu { get; set; }
        public virtual ICollection<Becaalubitacora> Becaalubitacora { get; set; }
    }
}
