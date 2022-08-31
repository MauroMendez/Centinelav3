using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Rdeudoresdiario
    {
        public long Rdid { get; set; }
        public int Rdaluid { get; set; }
        public decimal Rdpedindiente { get; set; }
        public int? Rddivision { get; set; }
        public string Div { get; set; }
        public string Rdapaterno { get; set; }
        public string Rdamaterno { get; set; }
        public string Rdnombre { get; set; }
        public string Rdemail { get; set; }
        public int? Rdcarid { get; set; }
        public string Carrera { get; set; }
        public string Rdnocontrol { get; set; }
        public string Rdgrado { get; set; }
        public string Rdgrupo { get; set; }
        public string RdemailT { get; set; }
        public int? RdnoConceptos { get; set; }
        public int? Rdbcid { get; set; }
        public string Beca { get; set; }
        public decimal? Rdbeparcialidades { get; set; }
        public decimal? Rdbeinscrip { get; set; }
        public string Rdbedesc { get; set; }
        public string Rdtutor { get; set; }
        public int? Rdconvenio { get; set; }
        public DateTime? Rdconvinicio { get; set; }
        public DateTime? Rdconvfin { get; set; }
        public string Rdtelefono { get; set; }
        public long? Rdestatus { get; set; }
        public string Estatus { get; set; }
        public string Rdconceptosdesc { get; set; }
    }
}
