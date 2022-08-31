using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Pantalla
    {
        public Pantalla()
        {
            Tpermisos = new HashSet<Tpermisos>();
        }

        public int IdPantalla { get; set; }
        public int ModuloId { get; set; }
        public string PantallaNombre { get; set; }
        public string PantallaDesc { get; set; }
        public string PantallaUrl { get; set; }
        public DateTime? PantallaFecha { get; set; }
        public short? PantallaSid { get; set; }
        public string PantallaSimbolo { get; set; }

        public virtual Modulo Modulo { get; set; }
        public virtual ICollection<Tpermisos> Tpermisos { get; set; }
    }
}
