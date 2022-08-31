using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class ActivoPara
    {
        public int ApCuentaId { get; set; }
        public int? ApEmpresa { get; set; }

        public virtual CuentaBancaria ApCuenta { get; set; }
        public virtual Empresas ApEmpresaNavigation { get; set; }
    }
}
