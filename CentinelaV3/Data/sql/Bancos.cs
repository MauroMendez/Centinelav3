using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Bancos
    {
        public Bancos()
        {
            CuentaBancaria = new HashSet<CuentaBancaria>();
        }

        public int BancoBancoId { get; set; }
        public string BancoNombre { get; set; }
        public byte[] BancoLogotipo { get; set; }
        public string BancoClave { get; set; }
        public long? BancoUsuid { get; set; }
        public DateTime? BancoFechaRegistro { get; set; }

        public virtual ICollection<CuentaBancaria> CuentaBancaria { get; set; }
    }
}
