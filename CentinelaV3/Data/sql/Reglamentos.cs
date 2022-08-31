using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Reglamentos
    {
        public Reglamentos()
        {
            FirmaReglamentosCv = new HashSet<FirmaReglamentosCv>();
        }

        public int Reglamentoid { get; set; }
        public int? NivelId { get; set; }
        public string Reglamentonom { get; set; }
        public byte[] Reglamentodoc { get; set; }
        public string Reglamentotipo { get; set; }
        public short Reglamentoact { get; set; }
        public short? Reglamentoorden { get; set; }
        public long Usuid { get; set; }
        public DateTime Reglamentoregistro { get; set; }
        public byte[] ReglamentoText { get; set; }

        public virtual Niveles Nivel { get; set; }
        public virtual Usuario Usu { get; set; }
        public virtual ICollection<FirmaReglamentosCv> FirmaReglamentosCv { get; set; }
    }
}
