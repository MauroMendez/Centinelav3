using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DatosParticipantes
    {
        public long Dpid { get; set; }
        public DateTime DpfechaReg { get; set; }
        public byte[] Dpfoto { get; set; }
        public string Dpip { get; set; }
        public byte[] Dpident { get; set; }
        public byte[] DptermyCond { get; set; }
        public string DpnomTutor { get; set; }
        public string DpappTutor { get; set; }
        public string DpapmTutor { get; set; }
        public string DpcelTutor { get; set; }
        public string DpnomEme { get; set; }
        public string DpappEme { get; set; }
        public string DpapmEme { get; set; }
        public string DpcelEme { get; set; }
        public long GpProspectoId { get; set; }
        public byte[] Dpgafete { get; set; }
    }
}
