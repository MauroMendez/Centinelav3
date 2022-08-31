using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class FirmaReglamentosCv
    {
        public int IdFirmaCv { get; set; }
        public int IdRegistroCv { get; set; }
        public int Reglamentoid { get; set; }
        public DateTime FechaFirma { get; set; }
        public string Cliente { get; set; }
        public string Ipfirma { get; set; }
        public string CoorFirma { get; set; }

        public virtual RegistrosCv IdRegistroCvNavigation { get; set; }
        public virtual Reglamentos Reglamento { get; set; }
    }
}
