using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class DatosFacturacion
    {
        public string DfRfc { get; set; }
        public string DfNombre { get; set; }
        public string DfApp { get; set; }
        public string DfApm { get; set; }
        public string DfCalle { get; set; }
        public string DfNoExt { get; set; }
        public string DfNoInt { get; set; }
        public string DfColonia { get; set; }
        public int? DfEstado { get; set; }
        public int? DfMunicipio { get; set; }
        public string DfUso { get; set; }
        public string DfEmail { get; set; }
        public long AlId { get; set; }
        public string DfDireccion { get; set; }
        public string DfCodPos { get; set; }
        public bool? DfTipoPersona { get; set; }

        public virtual Estados DfEstadoNavigation { get; set; }
        public virtual Municipios DfMunicipioNavigation { get; set; }
        public virtual UsosFacturacion DfUsoNavigation { get; set; }
    }
}
