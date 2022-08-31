using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DatosP
    {
        public long GpProspectoId { get; set; }
        public string GpporsMat { get; set; }
        public string GpNombre { get; set; }
        public string GpApp { get; set; }
        public string GpApm { get; set; }
        public int Campid { get; set; }
        public short Campanio { get; set; }
        public short Campperiodo { get; set; }
        public double? GpImporte { get; set; }
        public string GpObservaciones { get; set; }
        public int GpSemestre { get; set; }
        public long Usuid { get; set; }
        public string AdminNombre { get; set; }
        public string AdminApp { get; set; }
        public string AdminApm { get; set; }
        public int Idcarrera { get; set; }
        public string CarreraClave { get; set; }
        public string CarreraNombre { get; set; }
        public int GpModalidadInterez { get; set; }
        public string ModDescripcion { get; set; }
        public string NivelNombre { get; set; }
        public string NivelDescripcion { get; set; }
        public long SolicitudId { get; set; }
        public string CodBarras { get; set; }
        public DateTime? FechaExpiro { get; set; }
        public string EfecError { get; set; }
        public DateTime? EfecOperationDate { get; set; }
        public int GpBeca { get; set; }
        public int GpBecaInscripcion { get; set; }
        public int GpPorcentajeBeca { get; set; }
        public int? GpDescPromocion { get; set; }
    }
}
