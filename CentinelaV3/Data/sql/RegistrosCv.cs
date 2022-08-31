using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class RegistrosCv
    {
        public RegistrosCv()
        {
            FirmaReglamentosCv = new HashSet<FirmaReglamentosCv>();
        }

        public int IdRegistroCv { get; set; }
        public string NombresCv { get; set; }
        public string ApPaternoCv { get; set; }
        public string ApMaternoCv { get; set; }
        public string EmailCv { get; set; }
        public string UsuarioCv { get; set; }
        public string PasswordCv { get; set; }
        public int? IdPrograma { get; set; }
        public int? ModalidadCv { get; set; }
        public string TelefonoCv { get; set; }
        public DateTime FechaRegistroCv { get; set; }
        public DateTime? FechaActivacionCv { get; set; }
        public bool ActivoCv { get; set; }

        public virtual ProgramasCv IdProgramaNavigation { get; set; }
        public virtual ICollection<FirmaReglamentosCv> FirmaReglamentosCv { get; set; }
    }
}
