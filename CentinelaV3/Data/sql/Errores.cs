using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Errores
    {
        public long IdError { get; set; }
        public long? Usuid { get; set; }
        public string ErrorMod { get; set; }
        public string ErrorDesc { get; set; }
        public string ErrorEstate { get; set; }
        public string ErrorProcedure { get; set; }

        public virtual Usuario Usu { get; set; }
    }
}
