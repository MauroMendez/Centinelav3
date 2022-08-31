using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class CatalogoConceptos
    {
        public CatalogoConceptos()
        {
            Becas = new HashSet<Becas>();
            ListaPrecios = new HashSet<ListaPrecios>();
        }

        public int ConId { get; set; }
        public string ConClave { get; set; }
        public int ConTipoConcepto { get; set; }
        public string ConDescripcion { get; set; }
        public bool ConRequisitoInscripcion { get; set; }
        public long ConUsuid { get; set; }
        public DateTime ConFechaRegistro { get; set; }

        public virtual ICollection<Becas> Becas { get; set; }
        public virtual ICollection<ListaPrecios> ListaPrecios { get; set; }
    }
}
