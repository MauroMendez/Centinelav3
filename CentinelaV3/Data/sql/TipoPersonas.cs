using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class TipoPersonas
    {
        public TipoPersonas()
        {
            TiposDocumentos = new HashSet<TiposDocumentos>();
        }

        public int TpId { get; set; }
        public string TpNombre { get; set; }
        public string TpDescripcion { get; set; }

        public virtual ICollection<TiposDocumentos> TiposDocumentos { get; set; }
    }
}
