using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DetalleEsquema
    {
        public int DetalleEsquemaId { get; set; }
        public int LpId { get; set; }
        public bool? DeMensualidad { get; set; }
        public bool? DeInscripcion { get; set; }

        public virtual ListaPrecios Lp { get; set; }
    }
}
