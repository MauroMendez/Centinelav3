using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class TiposDocumentos
    {
        public int DocId { get; set; }
        public string DocNombre { get; set; }
        public string DocDescripcion { get; set; }
        public bool DocObligatorio { get; set; }
        public int? DocTipoPers { get; set; }
        public int? ModuloId { get; set; }

        public virtual TipoPersonas DocTipoPersNavigation { get; set; }
        public virtual Modulo Modulo { get; set; }
    }
}
