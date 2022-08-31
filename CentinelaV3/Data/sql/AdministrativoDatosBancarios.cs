using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class AdministrativoDatosBancarios
    {
        public string AdbAdminid { get; set; }
        public int AdbBanco { get; set; }
        public string AdbClabe { get; set; }
        public string AdbCuenta { get; set; }

        public virtual Administrativos AdbAdmin { get; set; }
    }
}
