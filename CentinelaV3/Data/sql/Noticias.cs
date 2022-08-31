using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Noticias
    {
        public int Noticiaid { get; set; }
        public DateTime? Noticiafec { get; set; }
        public string Noticiausu { get; set; }
        public string Noticiacont { get; set; }
        public string Noticiatitulo { get; set; }
        public byte[] Noticiafile { get; set; }
        public int Noticiatipo { get; set; }
        public DateTime Noticiafecfin { get; set; }
        public DateTime Noticiafecini { get; set; }
        public short? Noticiaimportante { get; set; }
        public short? Noticiapermanente { get; set; }
        public string Noticiadivision { get; set; }
        public int? ModuloId { get; set; }
        public string Noticiafilenombre { get; set; }
        public string Noticiatipo1 { get; set; }
    }
}
