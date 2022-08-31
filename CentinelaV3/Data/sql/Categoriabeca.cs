using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Categoriabeca
    {
        public Categoriabeca()
        {
            Becas = new HashSet<Becas>();
        }

        public int CategoriaId { get; set; }
        public string DescripcionCat { get; set; }
        public string ClaveCat { get; set; }

        public virtual ICollection<Becas> Becas { get; set; }
    }
}
