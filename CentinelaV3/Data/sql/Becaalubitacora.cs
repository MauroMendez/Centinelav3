﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class Becaalubitacora
    {
        public long Beid { get; set; }
        public short Ccbbid { get; set; }
        public long? Usuid { get; set; }
        public long? AlId { get; set; }
        public int? Ccbbperiodo { get; set; }
        public short? Ccbbanio { get; set; }
        public int? Ccbbinscrip { get; set; }
        public int? Ccbbparcial { get; set; }
        public int? BecasId { get; set; }
        public int? Ccbbmovimiento { get; set; }
        public DateTime? Ccbbfecha { get; set; }
        public string Ccbbmaquina { get; set; }
        public int? DescProm { get; set; }

        public virtual Alumno Al { get; set; }
        public virtual BecaAlumno Be { get; set; }
        public virtual Becas Becas { get; set; }
        public virtual EstatusList CcbbmovimientoNavigation { get; set; }
        public virtual Usuario Usu { get; set; }
    }
}