using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Vidstarjeta
    {
        public long RequestTarjetasId { get; set; }
        public long? RReferenciaId { get; set; }
        public string TarTransaccion { get; set; }
        public string TarState { get; set; }
        public string Alumno { get; set; }
    }
}
