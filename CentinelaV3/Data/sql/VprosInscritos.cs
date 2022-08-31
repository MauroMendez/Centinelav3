using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class VprosInscritos
    {
        public long GpProspectoId { get; set; }
        public long Usuid { get; set; }
        public string Gpmatricula { get; set; }
        public string GpporsMat { get; set; }
        public string Promotor { get; set; }
        public DateTime? Gppfecha { get; set; }
        public string NombreCompleto { get; set; }
        public string GpTelefono { get; set; }
        public string GpCorreoElectronico { get; set; }
        public int Idcarrera { get; set; }
        public string Carrera { get; set; }
        public int GpModalidadInterez { get; set; }
        public string ModDescripcion { get; set; }
        public int Campid { get; set; }
        public string Periodo { get; set; }
        public long Idferia { get; set; }
        public string Ferianombre { get; set; }
        public int GpEstatus { get; set; }
        public string Estatus { get; set; }
    }
}
