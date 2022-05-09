﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace CentinelaV3.Data.sql
{
    public partial class AlumnoPagos
    {
        public AlumnoPagos()
        {
            DetallePago = new HashSet<DetallePago>();
        }

        public int ApPagoId { get; set; }
        public long? ApAlumnoId { get; set; }
        public string ApAlumnoClave { get; set; }
        public int ApCuentaBancaria { get; set; }
        public int ApMetodoPago { get; set; }
        public int ApFormaPagoId { get; set; }
        public int? ApMoneda { get; set; }
        public decimal ApImportePendiente { get; set; }
        public decimal ApImporteTotal { get; set; }
        public long? ApReferenciaId { get; set; }
        public string ApReferencia { get; set; }
        public string ApReferenciaBancaria { get; set; }
        public string ApNoAprobacion { get; set; }
        public DateTime ApFechaCreacion { get; set; }
        public DateTime ApFechaContable { get; set; }
        public DateTime ApFechaBancaria { get; set; }
        public string ApObservaciones { get; set; }
        public int ApEstatus { get; set; }
        public long ApUsuid { get; set; }
        public DateTime ApFechaRegistro { get; set; }

        public virtual Alumno ApAlumno { get; set; }
        public virtual EstatusList ApEstatusNavigation { get; set; }
        public virtual Referencias ApReferenciaNavigation { get; set; }
        public virtual ICollection<DetallePago> DetallePago { get; set; }
    }
}