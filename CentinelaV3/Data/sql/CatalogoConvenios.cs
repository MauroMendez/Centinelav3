using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class CatalogoConvenios
    {
        public CatalogoConvenios()
        {
            Convenios = new HashSet<Convenios>();
        }

        public int CconvId { get; set; }
        public string CconvDescripcion { get; set; }
        public long CconvUsuid { get; set; }
        public DateTime CconvFechaRegistro { get; set; }

        public virtual ICollection<Convenios> Convenios { get; set; }
    }
}
