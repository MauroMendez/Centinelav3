using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CentinelaV3.Data.sql
{
    public partial class Intererpv3testContext : DbContext
    {
        public Intererpv3testContext()
        {
        }

        public Intererpv3testContext(DbContextOptions<Intererpv3testContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=74.208.235.157;Initial Catalog=InterERPv3P;User ID=sa;Password=Root.inter2020!;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        public virtual DbSet<ActivoPara> ActivoPara { get; set; }
        public virtual DbSet<AdminHorario> AdminHorario { get; set; }
        public virtual DbSet<AdministrativoDatosBancarios> AdministrativoDatosBancarios { get; set; }
        public virtual DbSet<Administrativos> Administrativos { get; set; }
        public virtual DbSet<AlergiaPaciente> AlergiaPaciente { get; set; }
        public virtual DbSet<Alergias> Alergias { get; set; }
        public virtual DbSet<Alumno> Alumno { get; set; }
        public virtual DbSet<AlumnoBaja> AlumnoBaja { get; set; }
        public virtual DbSet<AlumnoPagos> AlumnoPagos { get; set; }
        public virtual DbSet<AlumnoPo> AlumnoPo { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<AutorizoDescuento> AutorizoDescuento { get; set; }
        public virtual DbSet<BajaAdministrativo> BajaAdministrativo { get; set; }
        public virtual DbSet<Bancos> Bancos { get; set; }
        public virtual DbSet<BecaAlumno> BecaAlumno { get; set; }
        public virtual DbSet<Becaalubitacora> Becaalubitacora { get; set; }
        public virtual DbSet<Becas> Becas { get; set; }
        public virtual DbSet<BitacoraDetalle> BitacoraDetalle { get; set; }
        public virtual DbSet<BitacoraGral> BitacoraGral { get; set; }
        public virtual DbSet<Boleta> Boleta { get; set; }
        public virtual DbSet<CalificacionesMateria> CalificacionesMateria { get; set; }
        public virtual DbSet<Campana> Campana { get; set; }
        public virtual DbSet<Campanameta> Campanameta { get; set; }
        public virtual DbSet<CancelacionCuenta> CancelacionCuenta { get; set; }
        public virtual DbSet<CancelacionPagos> CancelacionPagos { get; set; }
        public virtual DbSet<Carreras> Carreras { get; set; }
        public virtual DbSet<CarrerasInteres> CarrerasInteres { get; set; }
        public virtual DbSet<CatalogoCancelacion> CatalogoCancelacion { get; set; }
        public virtual DbSet<CatalogoConceptos> CatalogoConceptos { get; set; }
        public virtual DbSet<CatalogoConvenios> CatalogoConvenios { get; set; }
        public virtual DbSet<CatalogoSaltoPago> CatalogoSaltoPago { get; set; }
        public virtual DbSet<Categoriabeca> Categoriabeca { get; set; }
        public virtual DbSet<ClasesGrupo> ClasesGrupo { get; set; }
        public virtual DbSet<ConfiguracionCorreo> ConfiguracionCorreo { get; set; }
        public virtual DbSet<ConfiguracionPagos> ConfiguracionPagos { get; set; }
        public virtual DbSet<Consulta> Consulta { get; set; }
        public virtual DbSet<ContactoProspecto> ContactoProspecto { get; set; }
        public virtual DbSet<ConvenioHistorico> ConvenioHistorico { get; set; }
        public virtual DbSet<ConvenioParcialidad> ConvenioParcialidad { get; set; }
        public virtual DbSet<Convenios> Convenios { get; set; }
        public virtual DbSet<CuentaBancaria> CuentaBancaria { get; set; }
        public virtual DbSet<CuentasPorCobrar> CuentasPorCobrar { get; set; }
        public virtual DbSet<DatosFacturacion> DatosFacturacion { get; set; }
        public virtual DbSet<DatosMedicos> DatosMedicos { get; set; }
        public virtual DbSet<DatosP> DatosP { get; set; }
        public virtual DbSet<DatosParticipantes> DatosParticipantes { get; set; }
        public virtual DbSet<DetalleCancelacionPago> DetalleCancelacionPago { get; set; }
        public virtual DbSet<DetalleConvenio> DetalleConvenio { get; set; }
        public virtual DbSet<DetalleCuentaPorCobrar> DetalleCuentaPorCobrar { get; set; }
        public virtual DbSet<DetalleEsquema> DetalleEsquema { get; set; }
        public virtual DbSet<DetallePago> DetallePago { get; set; }
        public virtual DbSet<DetalleReferencia> DetalleReferencia { get; set; }
        public virtual DbSet<DocumentoAlumno> DocumentoAlumno { get; set; }
        public virtual DbSet<DocumentoBitacora> DocumentoBitacora { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<DocumentosGenerales> DocumentosGenerales { get; set; }
        public virtual DbSet<DocumentosHistorial> DocumentosHistorial { get; set; }
        public virtual DbSet<DocumentosNivel> DocumentosNivel { get; set; }
        public virtual DbSet<Edificios> Edificios { get; set; }
        public virtual DbSet<EgresadoHistorial> EgresadoHistorial { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Errores> Errores { get; set; }
        public virtual DbSet<EscolaridadAdmin> EscolaridadAdmin { get; set; }
        public virtual DbSet<Escuelas> Escuelas { get; set; }
        public virtual DbSet<Escuelasf> Escuelasf { get; set; }
        public virtual DbSet<EsquemaPago> EsquemaPago { get; set; }
        public virtual DbSet<EsquemaPagoHistorial> EsquemaPagoHistorial { get; set; }
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<EstatusList> EstatusList { get; set; }
        public virtual DbSet<ExisteP> ExisteP { get; set; }
        public virtual DbSet<ExpProfecional> ExpProfecional { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<Facultades> Facultades { get; set; }
        public virtual DbSet<FaltasClase> FaltasClase { get; set; }
        public virtual DbSet<Ferias> Ferias { get; set; }
        public virtual DbSet<FirmaReglamentosCv> FirmaReglamentosCv { get; set; }
        public virtual DbSet<Folio> Folio { get; set; }
        public virtual DbSet<FormaPago> FormaPago { get; set; }
        public virtual DbSet<FormaPagoTxt> FormaPagoTxt { get; set; }
        public virtual DbSet<GeneralesAdministrativos> GeneralesAdministrativos { get; set; }
        public virtual DbSet<GeneralesAlumno> GeneralesAlumno { get; set; }
        public virtual DbSet<GeneralesProspecto> GeneralesProspecto { get; set; }
        public virtual DbSet<GrupoAlumno> GrupoAlumno { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<HijosAdmin> HijosAdmin { get; set; }
        public virtual DbSet<HistoricoBeca> HistoricoBeca { get; set; }
        public virtual DbSet<HistoricoPlanesEstudio> HistoricoPlanesEstudio { get; set; }
        public virtual DbSet<HistoricoPorcentaje> HistoricoPorcentaje { get; set; }
        public virtual DbSet<HistoricoPrecios> HistoricoPrecios { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Iadministrativos> Iadministrativos { get; set; }
        public virtual DbSet<InscritosUsuario> InscritosUsuario { get; set; }
        public virtual DbSet<Justificantes> Justificantes { get; set; }
        public virtual DbSet<Kardex> Kardex { get; set; }
        public virtual DbSet<ListaPrecios> ListaPrecios { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<MateriasImparteDocente> MateriasImparteDocente { get; set; }
        public virtual DbSet<MediosContacto> MediosContacto { get; set; }
        public virtual DbSet<MediosDifusion> MediosDifusion { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Modalidades> Modalidades { get; set; }
        public virtual DbSet<ModificacionesEsquemaPago> ModificacionesEsquemaPago { get; set; }
        public virtual DbSet<Modulo> Modulo { get; set; }
        public virtual DbSet<Momento> Momento { get; set; }
        public virtual DbSet<Monedas> Monedas { get; set; }
        public virtual DbSet<MoodleKey> MoodleKey { get; set; }
        public virtual DbSet<Municipios> Municipios { get; set; }
        public virtual DbSet<Nacionalidades> Nacionalidades { get; set; }
        public virtual DbSet<Niveles> Niveles { get; set; }
        public virtual DbSet<NivelesHistorial> NivelesHistorial { get; set; }
        public virtual DbSet<Noticias> Noticias { get; set; }
        public virtual DbSet<PagoTarjeta> PagoTarjeta { get; set; }
        public virtual DbSet<PagosRegistradosFitness> PagosRegistradosFitness { get; set; }
        public virtual DbSet<Pantalla> Pantalla { get; set; }
        public virtual DbSet<PeriodoHistorico> PeriodoHistorico { get; set; }
        public virtual DbSet<Periodos> Periodos { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PermisosAlumnos> PermisosAlumnos { get; set; }
        public virtual DbSet<PermisosPuestos> PermisosPuestos { get; set; }
        public virtual DbSet<PermisosStatus> PermisosStatus { get; set; }
        public virtual DbSet<PlanEstudioHistorico> PlanEstudioHistorico { get; set; }
        public virtual DbSet<PlanesEstudio> PlanesEstudio { get; set; }
        public virtual DbSet<PorcentageBecaHistoricoProspecto> PorcentageBecaHistoricoProspecto { get; set; }
        public virtual DbSet<ProgramasCv> ProgramasCv { get; set; }
        public virtual DbSet<Puestos> Puestos { get; set; }
        public virtual DbSet<PuestosHistorial> PuestosHistorial { get; set; }
        public virtual DbSet<Query> Query { get; set; }
        public virtual DbSet<Ravisodeudores> Ravisodeudores { get; set; }
        public virtual DbSet<Rcobranza> Rcobranza { get; set; }
        public virtual DbSet<Rdeudores> Rdeudores { get; set; }
        public virtual DbSet<Rdeudoresdiario> Rdeudoresdiario { get; set; }
        public virtual DbSet<Referencias> Referencias { get; set; }
        public virtual DbSet<RegistroChecador> RegistroChecador { get; set; }
        public virtual DbSet<RegistrosCv> RegistrosCv { get; set; }
        public virtual DbSet<Reglamentos> Reglamentos { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<RpayuRegistro> RpayuRegistro { get; set; }
        public virtual DbSet<Salones> Salones { get; set; }
        public virtual DbSet<Seguimiento> Seguimiento { get; set; }
        public virtual DbSet<SolicitudPago> SolicitudPago { get; set; }
        public virtual DbSet<StatusHistorial> StatusHistorial { get; set; }
        public virtual DbSet<StatusPago> StatusPago { get; set; }
        public virtual DbSet<Tbusuario> Tbusuario { get; set; }
        public virtual DbSet<Tbususesion> Tbususesion { get; set; }
        public virtual DbSet<TipoBajaAlumno> TipoBajaAlumno { get; set; }
        public virtual DbSet<TipoBecas> TipoBecas { get; set; }
        public virtual DbSet<TipoCalificaciones> TipoCalificaciones { get; set; }
        public virtual DbSet<TipoHorario> TipoHorario { get; set; }
        public virtual DbSet<TipoPagoAdmin> TipoPagoAdmin { get; set; }
        public virtual DbSet<TipoPersonas> TipoPersonas { get; set; }
        public virtual DbSet<TipoSeguimiento> TipoSeguimiento { get; set; }
        public virtual DbSet<TiposDocumentos> TiposDocumentos { get; set; }
        public virtual DbSet<TiposJustificante> TiposJustificante { get; set; }
        public virtual DbSet<Tpermisos> Tpermisos { get; set; }
        public virtual DbSet<Transfpayu> Transfpayu { get; set; }
        public virtual DbSet<UsosFacturacion> UsosFacturacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<VbecasConceptos> VbecasConceptos { get; set; }
        public virtual DbSet<Vbitacorabecas> Vbitacorabecas { get; set; }
        public virtual DbSet<VcontrolDocumento> VcontrolDocumento { get; set; }
        public virtual DbSet<VdatosOxxo> VdatosOxxo { get; set; }
        public virtual DbSet<VexisteM> VexisteM { get; set; }
        public virtual DbSet<Vexistecbeca> Vexistecbeca { get; set; }
        public virtual DbSet<VhistorialEstatusAl> VhistorialEstatusAl { get; set; }
        public virtual DbSet<Vidsolicitud> Vidsolicitud { get; set; }
        public virtual DbSet<Vidstarjeta> Vidstarjeta { get; set; }
        public virtual DbSet<ViewAlumnos> ViewAlumnos { get; set; }
        public virtual DbSet<ViewAlumnosConPagoActual> ViewAlumnosConPagoActual { get; set; }
        public virtual DbSet<ViewAlumnosInre> ViewAlumnosInre { get; set; }
        public virtual DbSet<ViewCuentasConvenio> ViewCuentasConvenio { get; set; }
        public virtual DbSet<ViewDeudores> ViewDeudores { get; set; }
        public virtual DbSet<ViewDeudoresPorAlumno> ViewDeudoresPorAlumno { get; set; }
        public virtual DbSet<ViewPagoAlumno> ViewPagoAlumno { get; set; }
        public virtual DbSet<ViewPagosPendientes> ViewPagosPendientes { get; set; }
        public virtual DbSet<ViewPagosRegistrados> ViewPagosRegistrados { get; set; }
        public virtual DbSet<ViewReporteConvenios> ViewReporteConvenios { get; set; }
        public virtual DbSet<ViewReportesCrm> ViewReportesCrm { get; set; }
        public virtual DbSet<ViewRptpagosConceptos> ViewRptpagosConceptos { get; set; }
        public virtual DbSet<VincritosCamp> VincritosCamp { get; set; }
        public virtual DbSet<VincritosUsu> VincritosUsu { get; set; }
        public virtual DbSet<VpropectosIncritos> VpropectosIncritos { get; set; }
        public virtual DbSet<VprosInscritos> VprosInscritos { get; set; }
        public virtual DbSet<VprosUsu> VprosUsu { get; set; }
        public virtual DbSet<VprospIndividual> VprospIndividual { get; set; }
        public virtual DbSet<Vprospectos> Vprospectos { get; set; }
        public virtual DbSet<VrepFormEspCrm> VrepFormEspCrm { get; set; }
        public virtual DbSet<VresolutivoBeca> VresolutivoBeca { get; set; }
        public virtual DbSet<VsegProgUser> VsegProgUser { get; set; }
        public virtual DbSet<VsegTProgUser> VsegTProgUser { get; set; }
        public virtual DbSet<Vsolicitud> Vsolicitud { get; set; }
        public virtual DbSet<VsolicitudPo> VsolicitudPo { get; set; }
        public virtual DbSet<Vusuario> Vusuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivoPara>(entity =>
            {
                entity.HasKey(e => e.ApCuentaId)
                    .HasName("PK__ActivoPa__D4990761F0328759");

                entity.Property(e => e.ApCuentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("AP_CuentaID");

                entity.Property(e => e.ApEmpresa).HasColumnName("AP_Empresa");

                entity.HasOne(d => d.ApCuenta)
                    .WithOne(p => p.ActivoPara)
                    .HasForeignKey<ActivoPara>(d => d.ApCuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActivoPar__AP_Cu__4865BE2A");

                entity.HasOne(d => d.ApEmpresaNavigation)
                    .WithMany(p => p.ActivoPara)
                    .HasForeignKey(d => d.ApEmpresa)
                    .HasConstraintName("FK__ActivoPar__AP_Em__477199F1");
            });

            modelBuilder.Entity<AdminHorario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AhAdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AH_AdminID");

                entity.Property(e => e.AhDia).HasColumnName("AH_DIa");

                entity.Property(e => e.AhHoraFin).HasColumnName("AH_HoraFin");

                entity.Property(e => e.AhHoraInicio).HasColumnName("AH_HoraInicio");

                entity.Property(e => e.AhMinutoFin).HasColumnName("AH_MinutoFin");

                entity.Property(e => e.AhMinutoInicio).HasColumnName("AH_MinutoInicio");

                entity.Property(e => e.AhPuestoId).HasColumnName("AH_PuestoID");

                entity.Property(e => e.AhTipoHorarioId).HasColumnName("AH_TipoHorarioID");

                entity.HasOne(d => d.AhAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.AhAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AdminHora__AH_Ad__308E3499");
            });

            modelBuilder.Entity<AdministrativoDatosBancarios>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdbAdminid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADB_ADMINID");

                entity.Property(e => e.AdbBanco).HasColumnName("ADB_Banco");

                entity.Property(e => e.AdbClabe)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("ADB_Clabe")
                    .IsFixedLength();

                entity.Property(e => e.AdbCuenta)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("ADB_Cuenta")
                    .IsFixedLength();

                entity.HasOne(d => d.AdbAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.AdbAdminid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__ADB_A__1209AD79");
            });

            modelBuilder.Entity<Administrativos>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK__Administ__4A300117972291EB");

                entity.HasIndex(e => e.AdminNumeroEmpleado, "UQ__Administ__F846E4A63925D3D4")
                    .IsUnique();

                entity.Property(e => e.AdminId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_ID");

                entity.Property(e => e.AdminActivo).HasColumnName("Admin_Activo");

                entity.Property(e => e.AdminApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_APM");

                entity.Property(e => e.AdminApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_APP");

                entity.Property(e => e.AdminCelular)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Celular")
                    .IsFixedLength();

                entity.Property(e => e.AdminCorreo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Correo");

                entity.Property(e => e.AdminCurp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_CURP");

                entity.Property(e => e.AdminExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Extension");

                entity.Property(e => e.AdminFechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("Admin_FechaIngreso");

                entity.Property(e => e.AdminFechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Admin_FechaNacimiento");

                entity.Property(e => e.AdminNacionalidad).HasColumnName("Admin_Nacionalidad");

                entity.Property(e => e.AdminNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Nombre");

                entity.Property(e => e.AdminNumeroEmpleado).HasColumnName("Admin_NumeroEmpleado");

                entity.Property(e => e.AdminRfc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_RFC");

                entity.Property(e => e.AdminTipoPago).HasColumnName("Admin_TipoPago");

                entity.Property(e => e.AreaId).HasColumnName("Area_ID");
            });

            modelBuilder.Entity<AlergiaPaciente>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ApAlergiaId).HasColumnName("AP_AlergiaID");

                entity.Property(e => e.ApPacienteId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AP_PacienteID");

                entity.HasOne(d => d.ApPaciente)
                    .WithMany()
                    .HasForeignKey(d => d.ApPacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlergiaPa__AP_Pa__589C25F3");
            });

            modelBuilder.Entity<Alergias>(entity =>
            {
                entity.HasKey(e => e.AAlergiaId)
                    .HasName("PK__Alergias__1FECA27C2C5FD68B");

                entity.Property(e => e.AAlergiaId)
                    .ValueGeneratedNever()
                    .HasColumnName("A_AlergiaID");

                entity.Property(e => e.AAlergia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("A_Alergia")
                    .IsFixedLength();

                entity.Property(e => e.ADescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("A_Descripcion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.AlId)
                    .HasName("PK__Alumno__7FB33DA0B046CBAF");

                entity.HasIndex(e => e.AlId, "UQ__Alumno__7FB33DA1CA9DD9EA")
                    .IsUnique();

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.AlAnoPeriodoActual).HasColumnName("AL_AnoPeriodoActual");

                entity.Property(e => e.AlApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APM");

                entity.Property(e => e.AlApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APP");

                entity.Property(e => e.AlBecaActual).HasColumnName("AL_BecaActual");

                entity.Property(e => e.AlBecaInscripcion).HasColumnName("AL_Beca_inscripcion");

                entity.Property(e => e.AlBecaParcialidad).HasColumnName("AL_Beca_parcialidad");

                entity.Property(e => e.AlCarrera).HasColumnName("AL_Carrera");

                entity.Property(e => e.AlCicloActual).HasColumnName("AL_CicloActual");

                entity.Property(e => e.AlCorreoInst)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_CorreoInst");

                entity.Property(e => e.AlCoutaAdmin).HasColumnName("Al_CoutaAdmin");

                entity.Property(e => e.AlCurp)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("AL_CURP");

                entity.Property(e => e.AlDescPromocion).HasColumnName("AL_Desc_promocion");

                entity.Property(e => e.AlDocumentos).HasColumnName("AL_Documentos");

                entity.Property(e => e.AlEsquemaPagoActual).HasColumnName("AL_EsquemaPagoActual");

                entity.Property(e => e.AlFactura).HasColumnName("AL_Factura");

                entity.Property(e => e.AlFechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("AL_FechaIngreso");

                entity.Property(e => e.AlFechaInicioNivel)
                    .HasColumnType("date")
                    .HasColumnName("AL_FechaInicioNivel");

                entity.Property(e => e.AlFechaNac)
                    .HasColumnType("date")
                    .HasColumnName("AL_FechaNac");

                entity.Property(e => e.AlGrupo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AL_Grupo")
                    .IsFixedLength();

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.AlModalidadActual).HasColumnName("AL_ModalidadActual");

                entity.Property(e => e.AlMontoDesc)
                    .HasColumnType("decimal(17, 2)")
                    .HasColumnName("Al_MontoDesc");

                entity.Property(e => e.AlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.AlPeriodoActual).HasColumnName("AL_PeriodoActual");

                entity.Property(e => e.AlSemestre).HasColumnName("AL_Semestre");

                entity.Property(e => e.AlSexo).HasColumnName("AL_Sexo");

                entity.Property(e => e.AlStatusActual).HasColumnName("AL_StatusActual");

                entity.HasOne(d => d.AlCarreraNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.AlCarrera)
                    .HasConstraintName("FK_Alumno_Carrera");

                entity.HasOne(d => d.AlEsquemaPagoActualNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.AlEsquemaPagoActual)
                    .HasConstraintName("FK__Alumno__AL_Esque__0A688BB1");

                entity.HasOne(d => d.AlModalidadActualNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.AlModalidadActual)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Alumno__AL_Modal__047AA831");

                entity.HasOne(d => d.AlPeriodoActualNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.AlPeriodoActual)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumno_Periodo");

                entity.HasOne(d => d.AlStatusActualNavigation)
                    .WithMany(p => p.Alumno)
                    .HasForeignKey(d => d.AlStatusActual)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Alumno_Estatus");
            });

            modelBuilder.Entity<AlumnoBaja>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AbAlumnoId).HasColumnName("AB_AlumnoID");

                entity.Property(e => e.AbAutorizacion1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AB_Autorizacion1");

                entity.Property(e => e.AbAutorizacion2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AB_Autorizacion2");

                entity.Property(e => e.AbAutorizacion3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AB_Autorizacion3");

                entity.Property(e => e.AbAutorizacion4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AB_Autorizacion4");

                entity.Property(e => e.AbBajaPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AB_BajaPor");

                entity.Property(e => e.AbFechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("AB_FechaBaja");

                entity.Property(e => e.AbFechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("AB FechaIngreso");

                entity.Property(e => e.AbMotivoBaja)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("AB_MotivoBaja")
                    .IsFixedLength();

                entity.Property(e => e.AbTipoBaja).HasColumnName("AB_TipoBaja");

                entity.HasOne(d => d.AbAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.AbAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlumnoBaj__AB_Al__28ED12D1");

                entity.HasOne(d => d.AbAutorizacion1Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.AbAutorizacion1)
                    .HasConstraintName("FK__AlumnoBaj__AB_Au__2BC97F7C");

                entity.HasOne(d => d.AbAutorizacion2Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.AbAutorizacion2)
                    .HasConstraintName("FK__AlumnoBaj__AB_Au__2CBDA3B5");

                entity.HasOne(d => d.AbAutorizacion3Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.AbAutorizacion3)
                    .HasConstraintName("FK__AlumnoBaj__AB_Au__2DB1C7EE");

                entity.HasOne(d => d.AbAutorizacion4Navigation)
                    .WithMany()
                    .HasForeignKey(d => d.AbAutorizacion4)
                    .HasConstraintName("FK__AlumnoBaj__AB_Au__2EA5EC27");

                entity.HasOne(d => d.AbBajaPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AbBajaPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlumnoBaj__AB_Ba__2AD55B43");
            });

            modelBuilder.Entity<AlumnoPagos>(entity =>
            {
                entity.HasKey(e => e.ApPagoId)
                    .HasName("PK__AlumnoPa__643B99A242ABABF3");

                entity.Property(e => e.ApPagoId).HasColumnName("AP_PagoID");

                entity.Property(e => e.ApAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AP_AlumnoClave");

                entity.Property(e => e.ApAlumnoId).HasColumnName("AP_AlumnoID");

                entity.Property(e => e.ApCuentaBancaria).HasColumnName("Ap_CuentaBancaria");

                entity.Property(e => e.ApEstatus).HasColumnName("AP_Estatus");

                entity.Property(e => e.ApFechaBancaria)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaBancaria");

                entity.Property(e => e.ApFechaContable)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaContable");

                entity.Property(e => e.ApFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaCreacion");

                entity.Property(e => e.ApFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("AP_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ApFormaPagoId).HasColumnName("AP_FormaPagoID");

                entity.Property(e => e.ApImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImportePendiente");

                entity.Property(e => e.ApImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImporteTotal");

                entity.Property(e => e.ApMetodoPago).HasColumnName("AP_MetodoPago");

                entity.Property(e => e.ApMoneda).HasColumnName("AP_Moneda");

                entity.Property(e => e.ApNoAprobacion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AP_NoAprobacion");

                entity.Property(e => e.ApObservaciones).HasColumnName("AP_Observaciones");

                entity.Property(e => e.ApReferencia)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AP_Referencia");

                entity.Property(e => e.ApReferenciaBancaria)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AP_ReferenciaBancaria");

                entity.Property(e => e.ApReferenciaId).HasColumnName("AP_ReferenciaID");

                entity.Property(e => e.ApUsuid).HasColumnName("AP_Usuid");

                entity.HasOne(d => d.ApAlumno)
                    .WithMany(p => p.AlumnoPagos)
                    .HasForeignKey(d => d.ApAlumnoId)
                    .HasConstraintName("FK__AlumnoPag__AP_Al__01D345B0");

                entity.HasOne(d => d.ApCuentaBancariaNavigation)
                    .WithMany(p => p.AlumnoPagos)
                    .HasForeignKey(d => d.ApCuentaBancaria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlumnoPagos_CuentaBancaria");

                entity.HasOne(d => d.ApEstatusNavigation)
                    .WithMany(p => p.AlumnoPagos)
                    .HasForeignKey(d => d.ApEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlumnoPagos_EstatusList");

                entity.HasOne(d => d.ApFormaPago)
                    .WithMany(p => p.AlumnoPagos)
                    .HasForeignKey(d => d.ApFormaPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlumnoPagos_FormaPago");

                entity.HasOne(d => d.ApMetodoPagoNavigation)
                    .WithMany(p => p.AlumnoPagos)
                    .HasForeignKey(d => d.ApMetodoPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlumnoPagos_MetodoPago");

                entity.HasOne(d => d.ApReferenciaNavigation)
                    .WithMany(p => p.AlumnoPagos)
                    .HasForeignKey(d => d.ApReferenciaId)
                    .HasConstraintName("FK_AlumnoPagos_Referencias");
            });

            modelBuilder.Entity<AlumnoPo>(entity =>
            {
                entity.HasKey(e => e.ApoSolicitud)
                    .HasName("PK__AlumnoPO__44F64EB20822A5F8");

                entity.ToTable("AlumnoPO");

                entity.Property(e => e.ApoSolicitud)
                    .ValueGeneratedNever()
                    .HasColumnName("APO_Solicitud");

                entity.Property(e => e.ApoAluid).HasColumnName("APO_ALUId");

                entity.Property(e => e.ApoAsociado).HasColumnName("APO_Asociado");

                entity.Property(e => e.ApoAutorizacion).HasColumnName("APO_Autorizacion");

                entity.Property(e => e.ApoBanco)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APO_Banco")
                    .IsFixedLength();

                entity.Property(e => e.ApoCodBarras)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APO_CodBarras")
                    .IsFixedLength();

                entity.Property(e => e.ApoDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("APO_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.ApoError)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("APO_Error")
                    .IsFixedLength();

                entity.Property(e => e.ApoEstatus).HasColumnName("APO_Estatus");

                entity.Property(e => e.ApoFasocio)
                    .HasColumnType("datetime")
                    .HasColumnName("APO_FAsocio");

                entity.Property(e => e.ApoFexpiro)
                    .HasColumnType("datetime")
                    .HasColumnName("APO_FExpiro");

                entity.Property(e => e.ApoFreg)
                    .HasColumnType("date")
                    .HasColumnName("APO_FReg");

                entity.Property(e => e.ApoMeses).HasColumnName("APO_Meses");

                entity.Property(e => e.ApoMetodoPago).HasColumnName("APO_MetodoPago");

                entity.Property(e => e.ApoNivelCuenta).HasColumnName("APO_NivelCuenta");

                entity.Property(e => e.ApoOrden)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("APO_Orden")
                    .IsFixedLength();

                entity.Property(e => e.ApoRcodigo).HasColumnName("APO_RCodigo");

                entity.Property(e => e.ApoReferencia).HasColumnName("APO_Referencia");

                entity.Property(e => e.ApoRespuesta)
                    .IsUnicode(false)
                    .HasColumnName("APO_Respuesta");

                entity.Property(e => e.ApoTansaccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("APO_Tansaccion")
                    .IsFixedLength();

                entity.Property(e => e.ApoUsuid).HasColumnName("APO_USUId");

                entity.HasOne(d => d.ApoEstatusNavigation)
                    .WithMany(p => p.AlumnoPo)
                    .HasForeignKey(d => d.ApoEstatus)
                    .HasConstraintName("FK__AlumnoPO__APO_Es__4924D839");

                entity.HasOne(d => d.ApoReferenciaNavigation)
                    .WithMany(p => p.AlumnoPo)
                    .HasForeignKey(d => d.ApoReferencia)
                    .HasConstraintName("FK__AlumnoPO__APO_Re__4A18FC72");
            });

            modelBuilder.Entity<Areas>(entity =>
            {
                entity.HasKey(e => e.AreaId)
                    .HasName("PK__Areas__4256772E3D357FA9");

                entity.Property(e => e.AreaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Area_ID");

                entity.Property(e => e.AreaDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Area_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.AreaNombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Area_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.AreaPadre).HasColumnName("Area_Padre");
            });

            modelBuilder.Entity<AutorizoDescuento>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AD_AutorizadoPor");

                entity.Property(e => e.AdComentario)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AD_Comentario")
                    .IsFixedLength();

                entity.Property(e => e.AdDescuento).HasColumnName("AD_Descuento");

                entity.Property(e => e.AdPagoId).HasColumnName("AD_PagoID");

                entity.HasOne(d => d.AdAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AdAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AutorizoD__AD_Au__17C286CF");
            });

            modelBuilder.Entity<BajaAdministrativo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BaAdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BA_AdminID");

                entity.Property(e => e.BaFechaBaja)
                    .HasColumnType("date")
                    .HasColumnName("BA_FechaBaja");

                entity.Property(e => e.BaFechaImicio)
                    .HasColumnType("date")
                    .HasColumnName("BA_FechaImicio");

                entity.Property(e => e.BaMotivo)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BA_Motivo")
                    .IsFixedLength();

                entity.Property(e => e.BaReccomendado).HasColumnName("BA_Reccomendado");

                entity.HasOne(d => d.BaAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.BaAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BajaAdmin__BA_Ad__27F8EE98");
            });

            modelBuilder.Entity<Bancos>(entity =>
            {
                entity.HasKey(e => e.BancoBancoId);

                entity.HasIndex(e => e.BancoBancoId, "UQ__Bancos__4AD7644AC3DB64A0")
                    .IsUnique();

                entity.Property(e => e.BancoBancoId).HasColumnName("Banco_BancoID");

                entity.Property(e => e.BancoClave)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Banco_Clave");

                entity.Property(e => e.BancoFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("Banco_FechaRegistro");

                entity.Property(e => e.BancoLogotipo)
                    .HasColumnType("image")
                    .HasColumnName("Banco_Logotipo");

                entity.Property(e => e.BancoNombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Banco_Nombre");

                entity.Property(e => e.BancoUsuid).HasColumnName("Banco_Usuid");
            });

            modelBuilder.Entity<BecaAlumno>(entity =>
            {
                entity.HasKey(e => e.Beid)
                    .HasName("ccbeca_pkey");

                entity.ToTable("becaAlumno");

                entity.Property(e => e.Beid).HasColumnName("beid");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.Beanio).HasColumnName("beanio");

                entity.Property(e => e.BecasId).HasColumnName("Becas_ID");

                entity.Property(e => e.Beconfecha)
                    .HasColumnType("date")
                    .HasColumnName("beconfecha");

                entity.Property(e => e.Beconfirma).HasColumnName("beconfirma");

                entity.Property(e => e.Beestatus).HasColumnName("beestatus");

                entity.Property(e => e.Beinscrip).HasColumnName("beinscrip");

                entity.Property(e => e.Beparcialidades).HasColumnName("beparcialidades");

                entity.Property(e => e.Beperiodo).HasColumnName("beperiodo");

                entity.Property(e => e.Betipo).HasColumnName("betipo");

                entity.Property(e => e.Conceptoid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("conceptoid");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Al)
                    .WithMany(p => p.BecaAlumno)
                    .HasForeignKey(d => d.AlId)
                    .HasConstraintName("FK_becaAlumno_Alumno");

                entity.HasOne(d => d.Becas)
                    .WithMany(p => p.BecaAlumno)
                    .HasForeignKey(d => d.BecasId)
                    .HasConstraintName("FK_becaAlumno_becas");

                entity.HasOne(d => d.BeestatusNavigation)
                    .WithMany(p => p.BecaAlumnoBeestatusNavigation)
                    .HasForeignKey(d => d.Beestatus)
                    .HasConstraintName("FK__becaAlumno__EstatusList");

                entity.HasOne(d => d.BetipoNavigation)
                    .WithMany(p => p.BecaAlumnoBetipoNavigation)
                    .HasForeignKey(d => d.Betipo)
                    .HasConstraintName("FK_becatipo_EstatusList");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.BecaAlumno)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_becaAlumno_usuario");
            });

            modelBuilder.Entity<Becaalubitacora>(entity =>
            {
                entity.HasKey(e => e.Ccbbid);

                entity.ToTable("becaalubitacora");

                entity.Property(e => e.Ccbbid).HasColumnName("ccbbid");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.BecasId).HasColumnName("Becas_ID");

                entity.Property(e => e.Beid).HasColumnName("beid");

                entity.Property(e => e.Ccbbanio).HasColumnName("ccbbanio");

                entity.Property(e => e.Ccbbfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ccbbfecha");

                entity.Property(e => e.Ccbbinscrip).HasColumnName("ccbbinscrip");

                entity.Property(e => e.Ccbbmaquina)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ccbbmaquina");

                entity.Property(e => e.Ccbbmovimiento).HasColumnName("ccbbmovimiento");

                entity.Property(e => e.Ccbbparcial).HasColumnName("ccbbparcial");

                entity.Property(e => e.Ccbbperiodo).HasColumnName("ccbbperiodo");

                entity.Property(e => e.DescProm).HasColumnName("desc_prom");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Al)
                    .WithMany(p => p.Becaalubitacora)
                    .HasForeignKey(d => d.AlId)
                    .HasConstraintName("FK_becaalubitacora_alumno");

                entity.HasOne(d => d.Becas)
                    .WithMany(p => p.Becaalubitacora)
                    .HasForeignKey(d => d.BecasId)
                    .HasConstraintName("FK_becaalubitacora_becas");

                entity.HasOne(d => d.Be)
                    .WithMany(p => p.Becaalubitacora)
                    .HasForeignKey(d => d.Beid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_becaalubitacora_becaAlumno");

                entity.HasOne(d => d.CcbbmovimientoNavigation)
                    .WithMany(p => p.Becaalubitacora)
                    .HasForeignKey(d => d.Ccbbmovimiento)
                    .HasConstraintName("FK_becaalubitacora_EstatusList");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Becaalubitacora)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_becaalubitacora_usuario");
            });

            modelBuilder.Entity<Becas>(entity =>
            {
                entity.Property(e => e.BecasId).HasColumnName("Becas_ID");

                entity.Property(e => e.BecasActiva).HasColumnName("Becas_Activa");

                entity.Property(e => e.BecasClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Clave");

                entity.Property(e => e.BecasDescripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Descripcion");

                entity.Property(e => e.BecasNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Nombre");

                entity.Property(e => e.BecasProm).HasColumnName("Becas_prom");

                entity.Property(e => e.BecasResponsable)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Responsable");

                entity.Property(e => e.CategoriaId).HasColumnName("Categoria_id");

                entity.Property(e => e.ConId).HasColumnName("Con_id");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Becas)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK_Becas_Categoria");

                entity.HasOne(d => d.Con)
                    .WithMany(p => p.Becas)
                    .HasForeignKey(d => d.ConId)
                    .HasConstraintName("FK_Becas_Conceptos");
            });

            modelBuilder.Entity<BitacoraDetalle>(entity =>
            {
                entity.HasKey(e => e.Bgdid)
                    .HasName("PK__Bitacora__6F8133A1B8300917");

                entity.Property(e => e.Bgdid).HasColumnName("BGDId");

                entity.Property(e => e.Bgdcampanaid).HasColumnName("BGDCampanaid");

                entity.Property(e => e.BgdcomentarioM)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BGDComentarioM");

                entity.Property(e => e.BgddireccionIp)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BGDDireccionIP");

                entity.Property(e => e.BgdestadoAct)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BGDEstadoAct");

                entity.Property(e => e.BgdestadoAnt)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BGDEstadoAnt");

                entity.Property(e => e.Bgdpantalla)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("BGDPantalla");

                entity.Property(e => e.Bgdrol).HasColumnName("BGDRol");

                entity.Property(e => e.Bgdusuid).HasColumnName("BGDUsuid");

                entity.Property(e => e.Bgid).HasColumnName("BGId");

                entity.HasOne(d => d.Bg)
                    .WithMany(p => p.BitacoraDetalle)
                    .HasForeignKey(d => d.Bgid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BitacoraDe__BGId__15A53433");
            });

            modelBuilder.Entity<BitacoraGral>(entity =>
            {
                entity.HasKey(e => e.Bgid)
                    .HasName("PK__Bitacora__C7B26F9694803F69");

                entity.Property(e => e.Bgid).HasColumnName("BGId");

                entity.Property(e => e.Bgalumno).HasColumnName("BGAlumno");

                entity.Property(e => e.Bgcomentario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BGComentario");

                entity.Property(e => e.Bgfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("BGFecha");

                entity.Property(e => e.BgmodoloId).HasColumnName("BGModoloId");

                entity.Property(e => e.Bgproceso)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BGProceso");

                entity.Property(e => e.BgtipoMov)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("BGTipoMov");
            });

            modelBuilder.Entity<Boleta>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BAlumnoId)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("B_AlumnoID")
                    .IsFixedLength();

                entity.Property(e => e.BCalificacion).HasColumnName("B_Calificacion");

                entity.Property(e => e.BFechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("B_FechaRegistro");

                entity.Property(e => e.BGrupoId).HasColumnName("B_GrupoID");

                entity.Property(e => e.BMateriaId).HasColumnName("B_MateriaID");

                entity.Property(e => e.BMomento).HasColumnName("B_Momento");

                entity.HasOne(d => d.BGrupo)
                    .WithMany()
                    .HasForeignKey(d => d.BGrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Boleta__B_GrupoI__66EA454A");

                entity.HasOne(d => d.BMateria)
                    .WithMany()
                    .HasForeignKey(d => d.BMateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Boleta__B_Materi__1A69E950");

                entity.HasOne(d => d.BMomentoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.BMomento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Boleta__B_Moment__1C5231C2");
            });

            modelBuilder.Entity<CalificacionesMateria>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CmAlumnoId).HasColumnName("CM_AlumnoID");

                entity.Property(e => e.CmCalificacion).HasColumnName("CM_Calificacion");

                entity.Property(e => e.CmGrupoId).HasColumnName("CM_GrupoID");

                entity.Property(e => e.CmMateriaId).HasColumnName("CM_MateriaID");

                entity.Property(e => e.CmMomento).HasColumnName("CM_Momento");

                entity.Property(e => e.CmTipoCalificacion).HasColumnName("CM_TipoCalificacion");

                entity.HasOne(d => d.CmAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.CmAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calificac__CM_Al__65F62111");

                entity.HasOne(d => d.CmGrupo)
                    .WithMany()
                    .HasForeignKey(d => d.CmGrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calificac__CM_Gr__6501FCD8");

                entity.HasOne(d => d.CmMateria)
                    .WithMany()
                    .HasForeignKey(d => d.CmMateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calificac__CM_Ma__0EF836A4");

                entity.HasOne(d => d.CmTipoCalificacionNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CmTipoCalificacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Calificac__CM_Ti__3BFFE745");
            });

            modelBuilder.Entity<Campana>(entity =>
            {
                entity.HasKey(e => e.Campid)
                    .HasName("PK_campaña");

                entity.ToTable("campana");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Campanio).HasColumnName("campanio");

                entity.Property(e => e.Campfecfin)
                    .HasColumnType("date")
                    .HasColumnName("campfecfin");

                entity.Property(e => e.Campfecini)
                    .HasColumnType("date")
                    .HasColumnName("campfecini");

                entity.Property(e => e.Campfecreg)
                    .HasColumnType("datetime")
                    .HasColumnName("campfecreg");

                entity.Property(e => e.Campmeta).HasColumnName("campmeta");

                entity.Property(e => e.Campperiodo).HasColumnName("campperiodo");

                entity.Property(e => e.Camppresupuesto)
                    .HasColumnType("decimal(17, 2)")
                    .HasColumnName("camppresupuesto");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Campana)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_campaña_usuario");
            });

            modelBuilder.Entity<Campanameta>(entity =>
            {
                entity.HasKey(e => e.Cmid)
                    .HasName("PK_campañameta");

                entity.ToTable("campanameta");

                entity.Property(e => e.Cmid).HasColumnName("cmid");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Cmfecfin)
                    .HasColumnType("date")
                    .HasColumnName("cmfecfin");

                entity.Property(e => e.Cmfecini)
                    .HasColumnType("date")
                    .HasColumnName("cmfecini");

                entity.Property(e => e.Cmmeta).HasColumnName("cmmeta");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Camp)
                    .WithMany(p => p.Campanameta)
                    .HasForeignKey(d => d.Campid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_campañameta_campaña");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Campanameta)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_campañameta_usuario");
            });

            modelBuilder.Entity<CancelacionCuenta>(entity =>
            {
                entity.HasKey(e => e.CanId);

                entity.Property(e => e.CanId).HasColumnName("Can_ID");

                entity.Property(e => e.CanComentario)
                    .IsUnicode(false)
                    .HasColumnName("Can_Comentario");

                entity.Property(e => e.CanCuentaId).HasColumnName("Can_CuentaID");

                entity.Property(e => e.CanFechaCancelacion)
                    .HasColumnType("date")
                    .HasColumnName("Can_FechaCancelacion");

                entity.Property(e => e.CanFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("Can_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CanTipoCancelacion).HasColumnName("Can_TipoCancelacion");

                entity.Property(e => e.CanUsuid).HasColumnName("Can_Usuid");

                entity.HasOne(d => d.CanCuenta)
                    .WithMany(p => p.CancelacionCuenta)
                    .HasForeignKey(d => d.CanCuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CancelacionCuenta_CuentaPorCobrar");

                entity.HasOne(d => d.CanTipoCancelacionNavigation)
                    .WithMany(p => p.CancelacionCuenta)
                    .HasForeignKey(d => d.CanTipoCancelacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CancelacionCuenta_TipoCancelacion");
            });

            modelBuilder.Entity<CancelacionPagos>(entity =>
            {
                entity.HasKey(e => e.CpCanId)
                    .HasName("PK__Cancelac__C49BB1681A230611");

                entity.Property(e => e.CpCanId).HasColumnName("CP_CanId");

                entity.Property(e => e.CpCancelacion).HasColumnName("CP_Cancelacion");

                entity.Property(e => e.CpComentario)
                    .IsUnicode(false)
                    .HasColumnName("CP_Comentario");

                entity.Property(e => e.CpFechaCancelacion)
                    .HasColumnType("date")
                    .HasColumnName("CP_FechaCancelacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CpFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CP_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CpPagoId).HasColumnName("CP_PagoId");

                entity.Property(e => e.CpTipoCancelacion).HasColumnName("CP_TipoCancelacion");

                entity.Property(e => e.CpUsuid).HasColumnName("CP_Usuid");

                entity.HasOne(d => d.CpPago)
                    .WithMany(p => p.CancelacionPagos)
                    .HasForeignKey(d => d.CpPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cancelaci__CP_Pa__18B6AB08");

                entity.HasOne(d => d.CpTipoCancelacionNavigation)
                    .WithMany(p => p.CancelacionPagos)
                    .HasForeignKey(d => d.CpTipoCancelacion)
                    .HasConstraintName("FK_CancelacionPagos_TipoCancelacion");
            });

            modelBuilder.Entity<Carreras>(entity =>
            {
                entity.HasKey(e => e.Idcarrera);

                entity.Property(e => e.Idcarrera)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCarrera");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraIp).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.CarreraRevoe).HasMaxLength(50);

                entity.Property(e => e.FacFacultadId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("FAC_FacultadID");

                entity.Property(e => e.ModModalidadId).HasColumnName("Mod_ModalidadID");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.PeId).HasColumnName("PE_ID");

                entity.Property(e => e.TempId).HasColumnName("tempId");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.FacFacultad)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.FacFacultadId)
                    .HasConstraintName("FK_Carreras_Facultades");

                entity.HasOne(d => d.ModModalidad)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.ModModalidadId)
                    .HasConstraintName("FK_Carreras_Modalidades");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.NivelId)
                    .HasConstraintName("FK_Carreras_Niveles");

                entity.HasOne(d => d.Pe)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.PeId)
                    .HasConstraintName("FK_Carreras_PlanesEstudio");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Carreras)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_Carreras_usuario");
            });

            modelBuilder.Entity<CarrerasInteres>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CiAlumnoId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CI_AlumnoID")
                    .IsFixedLength();

                entity.Property(e => e.CiCarreraId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CI_CarreraID")
                    .IsFixedLength();

                entity.Property(e => e.CiPrioridad).HasColumnName("CI_Prioridad");
            });

            modelBuilder.Entity<CatalogoCancelacion>(entity =>
            {
                entity.HasKey(e => e.CcanId);

                entity.Property(e => e.CcanId).HasColumnName("CCan_ID");

                entity.Property(e => e.CcanClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CCan_Clave")
                    .IsFixedLength();

                entity.Property(e => e.CcanDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CCan_Descripcion");

                entity.Property(e => e.CcanFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CCan_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CcanUsuid).HasColumnName("CCan_Usuid");
            });

            modelBuilder.Entity<CatalogoConceptos>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("PK_Conceptos");

                entity.Property(e => e.ConId).HasColumnName("Con_ID");

                entity.Property(e => e.ConClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Con_Clave");

                entity.Property(e => e.ConDescripcion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Con_Descripcion");

                entity.Property(e => e.ConFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("Con_FechaRegistro");

                entity.Property(e => e.ConRequisitoInscripcion).HasColumnName("Con_RequisitoInscripcion");

                entity.Property(e => e.ConTipoConcepto).HasColumnName("Con_TipoConcepto");

                entity.Property(e => e.ConUsuid).HasColumnName("Con_Usuid");
            });

            modelBuilder.Entity<CatalogoConvenios>(entity =>
            {
                entity.HasKey(e => e.CconvId);

                entity.Property(e => e.CconvId).HasColumnName("CConv_ID");

                entity.Property(e => e.CconvDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CConv_Descripcion");

                entity.Property(e => e.CconvFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CConv_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CconvUsuid).HasColumnName("CConv_Usuid");
            });

            modelBuilder.Entity<CatalogoSaltoPago>(entity =>
            {
                entity.HasKey(e => e.CsalId);

                entity.Property(e => e.CsalId).HasColumnName("CSal_ID");

                entity.Property(e => e.CsalDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CSal_Descripcion");

                entity.Property(e => e.CsalFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CSal_FechaRegistro");

                entity.Property(e => e.CsalUsuid).HasColumnName("CSal_Usuid");
            });

            modelBuilder.Entity<Categoriabeca>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK_Cat_tipobeca");

                entity.Property(e => e.CategoriaId)
                    .ValueGeneratedNever()
                    .HasColumnName("Categoria_ID");

                entity.Property(e => e.ClaveCat)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Clave_cat");

                entity.Property(e => e.DescripcionCat)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Descripcion_cat");
            });

            modelBuilder.Entity<ClasesGrupo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CgDoceteId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CG_DoceteID");

                entity.Property(e => e.CgGrupoId).HasColumnName("CG_GrupoID");

                entity.Property(e => e.CgHoarioId).HasColumnName("CG_HoarioID");

                entity.Property(e => e.CgMateriaId).HasColumnName("CG_MateriaID");

                entity.Property(e => e.CgSalonId).HasColumnName("CG_SalonID");

                entity.HasOne(d => d.CgDocete)
                    .WithMany()
                    .HasForeignKey(d => d.CgDoceteId)
                    .HasConstraintName("FK__ClasesGru__CG_Do__6319B466");

                entity.HasOne(d => d.CgMateria)
                    .WithMany()
                    .HasForeignKey(d => d.CgMateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClasesGru__CG_Ma__0D0FEE32");
            });

            modelBuilder.Entity<ConfiguracionCorreo>(entity =>
            {
                entity.HasKey(e => e.CoId);

                entity.Property(e => e.CoId).HasColumnName("CO_ID");

                entity.Property(e => e.CoCorreoEnvio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CO_CorreoEnvio");

                entity.Property(e => e.CoDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CO_Descripcion");

                entity.Property(e => e.CoFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CO_FechaRegistro");

                entity.Property(e => e.CoKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CO_Key");

                entity.Property(e => e.CoModuloId).HasColumnName("CO_ModuloID");

                entity.Property(e => e.CoNivelId).HasColumnName("CO_NivelID");

                entity.Property(e => e.CoPassEnvio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CO_PassEnvio");

                entity.Property(e => e.CoPuertoSmtp).HasColumnName("CO_PuertoSmtp");

                entity.Property(e => e.CoServidorSmtp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CO_ServidorSmtp");

                entity.Property(e => e.CoUsuid).HasColumnName("CO_Usuid");

                entity.HasOne(d => d.CoModulo)
                    .WithMany(p => p.ConfiguracionCorreo)
                    .HasForeignKey(d => d.CoModuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConfiguracionCorreo_Modulo");

                entity.HasOne(d => d.CoNivel)
                    .WithMany(p => p.ConfiguracionCorreo)
                    .HasForeignKey(d => d.CoNivelId)
                    .HasConstraintName("FK_ConfiguracionCorreo_Nivel");
            });

            modelBuilder.Entity<ConfiguracionPagos>(entity =>
            {
                entity.HasKey(e => e.ConfId);

                entity.Property(e => e.ConfId)
                    .ValueGeneratedNever()
                    .HasColumnName("Conf_ID");

                entity.Property(e => e.ConfAño).HasColumnName("Conf_Año");

                entity.Property(e => e.ConfDiaVencimiento).HasColumnName("Conf_DiaVencimiento");

                entity.Property(e => e.ConfPeriodo).HasColumnName("Conf_Periodo");

                entity.Property(e => e.ConfRecargos).HasColumnName("Conf_Recargos");
            });

            modelBuilder.Entity<Consulta>(entity =>
            {
                entity.HasKey(e => e.CConsultaId)
                    .HasName("PK__Consulta__464A27DE22E78910");

                entity.Property(e => e.CConsultaId)
                    .ValueGeneratedNever()
                    .HasColumnName("C_ConsultaID");

                entity.Property(e => e.CDiagnostico)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("C_Diagnostico")
                    .IsFixedLength();

                entity.Property(e => e.CFecha)
                    .HasColumnType("date")
                    .HasColumnName("C_Fecha");

                entity.Property(e => e.CPacienteId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("C_PacienteID");

                entity.Property(e => e.CPeso)
                    .HasColumnType("numeric(3, 2)")
                    .HasColumnName("C_Peso");

                entity.Property(e => e.CProximaCita)
                    .HasColumnType("date")
                    .HasColumnName("C_ProximaCita");

                entity.Property(e => e.CReceta)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("C_Receta")
                    .IsFixedLength();

                entity.HasOne(d => d.CPaciente)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.CPacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Consulta__C_Paci__5A846E65");
            });

            modelBuilder.Entity<ContactoProspecto>(entity =>
            {
                entity.HasKey(e => e.ContId);

                entity.Property(e => e.ApmC)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apmC");

                entity.Property(e => e.AppC)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("appC");

                entity.Property(e => e.CelC)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("celC");

                entity.Property(e => e.EmailC)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emailC");

                entity.Property(e => e.FechaR)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaR");

                entity.Property(e => e.GpprospectoId).HasColumnName("GPProspectoId");

                entity.Property(e => e.NombreC)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreC");

                entity.Property(e => e.TelC)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("telC");

                entity.Property(e => e.TipoC).HasColumnName("tipoC");

                entity.HasOne(d => d.Gpprospecto)
                    .WithMany(p => p.ContactoProspecto)
                    .HasForeignKey(d => d.GpprospectoId)
                    .HasConstraintName("FK_ContactoProspecto");
            });

            modelBuilder.Entity<ConvenioHistorico>(entity =>
            {
                entity.HasKey(e => e.ChConvenioId);

                entity.Property(e => e.ChConvenioId).HasColumnName("CH_ConvenioID");

                entity.Property(e => e.ChFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("CH_FechaCreacion");

                entity.Property(e => e.ChFechaLimite)
                    .HasColumnType("date")
                    .HasColumnName("CH_FechaLimite");

                entity.Property(e => e.ChFechaModificacion)
                    .HasColumnType("date")
                    .HasColumnName("CH_FechaModificacion");

                entity.Property(e => e.ChModificadoPor)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CH_ModificadoPor")
                    .IsFixedLength();

                entity.Property(e => e.ChMotivo)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("CH_Motivo")
                    .IsFixedLength();

                entity.Property(e => e.ConConvenioId).HasColumnName("Con_ConvenioID");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.ConConvenio)
                    .WithMany(p => p.ConvenioHistorico)
                    .HasForeignKey(d => d.ConConvenioId)
                    .HasConstraintName("FK_ConvenioHistorico_Convenios");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.ConvenioHistorico)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_ConvenioHistorico_usuario");
            });

            modelBuilder.Entity<ConvenioParcialidad>(entity =>
            {
                entity.HasKey(e => e.CpId);

                entity.Property(e => e.CpId).HasColumnName("CP_Id");

                entity.Property(e => e.CpConvenio).HasColumnName("CP_Convenio");

                entity.Property(e => e.CpDocLinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("CP_DocLinea")
                    .IsFixedLength();

                entity.Property(e => e.CpEstatus).HasColumnName("CP_Estatus");

                entity.Property(e => e.CpFechaPago)
                    .HasColumnType("date")
                    .HasColumnName("CP_FechaPago");

                entity.Property(e => e.CpFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CP_FechaRegistro");

                entity.Property(e => e.CpMontoPago)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CP_MontoPago");

                entity.Property(e => e.CpUsuid).HasColumnName("CP_Usuid");

                entity.HasOne(d => d.CpConvenioNavigation)
                    .WithMany(p => p.ConvenioParcialidad)
                    .HasForeignKey(d => d.CpConvenio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConvenioParcialidad_Convenio");

                entity.HasOne(d => d.CpEstatusNavigation)
                    .WithMany(p => p.ConvenioParcialidad)
                    .HasForeignKey(d => d.CpEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConvenioParcialidad_EstatusList");
            });

            modelBuilder.Entity<Convenios>(entity =>
            {
                entity.HasKey(e => e.ConId)
                    .HasName("PK__Convenio__B8A6CE66C47DFDE6");

                entity.Property(e => e.ConId).HasColumnName("Con_ID");

                entity.Property(e => e.ConAlid).HasColumnName("Con_Alid");

                entity.Property(e => e.ConCelSub)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Con_CelSub");

                entity.Property(e => e.ConComentario)
                    .IsUnicode(false)
                    .HasColumnName("Con_Comentario");

                entity.Property(e => e.ConDireccionSub)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("Con_DireccionSub");

                entity.Property(e => e.ConDocumentoId).HasColumnName("Con_DocumentoID");

                entity.Property(e => e.ConEmailSub)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Con_EmailSub");

                entity.Property(e => e.ConEstatus).HasColumnName("Con_Estatus");

                entity.Property(e => e.ConEstutor).HasColumnName("Con_Estutor");

                entity.Property(e => e.ConExtension).HasColumnName("Con_Extension");

                entity.Property(e => e.ConFaceSub)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Con_FaceSub");

                entity.Property(e => e.ConFechaCierre)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaCierre");

                entity.Property(e => e.ConFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaCreacion");

                entity.Property(e => e.ConFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaFin");

                entity.Property(e => e.ConFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaInicio");

                entity.Property(e => e.ConFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("Con_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ConNombreSub)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Con_NombreSub");

                entity.Property(e => e.ConNumeroExtension).HasColumnName("Con_NumeroExtension");

                entity.Property(e => e.ConReferenciaConvenio).HasColumnName("Con_ReferenciaConvenio");

                entity.Property(e => e.ConTelefnoSub)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Con_TelefnoSub");

                entity.Property(e => e.ConTipoConvenio).HasColumnName("Con_TipoConvenio");

                entity.Property(e => e.ConUsuid).HasColumnName("Con_Usuid");

                entity.Property(e => e.EstadosId).HasColumnName("Estados_ID");

                entity.HasOne(d => d.ConAl)
                    .WithMany(p => p.Convenios)
                    .HasForeignKey(d => d.ConAlid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Convenios_Alumno");

                entity.HasOne(d => d.ConDocumento)
                    .WithMany(p => p.Convenios)
                    .HasForeignKey(d => d.ConDocumentoId)
                    .HasConstraintName("FK_Convenios_DocumentosGenerales");

                entity.HasOne(d => d.ConEstatusNavigation)
                    .WithMany(p => p.Convenios)
                    .HasForeignKey(d => d.ConEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Convenios_EstatusList");

                entity.HasOne(d => d.ConReferenciaConvenioNavigation)
                    .WithMany(p => p.InverseConReferenciaConvenioNavigation)
                    .HasForeignKey(d => d.ConReferenciaConvenio)
                    .HasConstraintName("FK_Convenios_Convenios");

                entity.HasOne(d => d.ConTipoConvenioNavigation)
                    .WithMany(p => p.Convenios)
                    .HasForeignKey(d => d.ConTipoConvenio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Convenios_TipoConvenios");

                entity.HasOne(d => d.Estados)
                    .WithMany(p => p.Convenios)
                    .HasForeignKey(d => d.EstadosId)
                    .HasConstraintName("FK__Convenios__Estad__34C9A528");
            });

            modelBuilder.Entity<CuentaBancaria>(entity =>
            {
                entity.HasKey(e => e.CbCuentaId)
                    .HasName("PK__CuentaBa__11271B3E05A2532A");

                entity.Property(e => e.CbCuentaId)
                    .ValueGeneratedNever()
                    .HasColumnName("CB_CuentaId");

                entity.Property(e => e.CbBancoId).HasColumnName("CB_BancoID");

                entity.Property(e => e.CbBeneficiario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CB_Beneficiario");

                entity.Property(e => e.CbClabe)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("CB_Clabe");

                entity.Property(e => e.CbConvenio)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CB_Convenio");

                entity.Property(e => e.CbCuenta)
                    .IsRequired()
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CB_Cuenta");

                entity.Property(e => e.CbEmpresa).HasColumnName("CB_Empresa");

                entity.Property(e => e.CbFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CB_FechaRegistro");

                entity.Property(e => e.CbNombreCuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CB_NombreCuenta");

                entity.Property(e => e.CbPagoLinea).HasColumnName("CB_PagoLinea");

                entity.Property(e => e.CbPagoManual).HasColumnName("CB_PagoManual");

                entity.Property(e => e.CbPagoReferenciado).HasColumnName("CB_PagoReferenciado");

                entity.Property(e => e.CbUsuid).HasColumnName("CB_Usuid");

                entity.HasOne(d => d.CbBanco)
                    .WithMany(p => p.CuentaBancaria)
                    .HasForeignKey(d => d.CbBancoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CuentaBan__CB_Ba__3CBF0154");

                entity.HasOne(d => d.CbEmpresaNavigation)
                    .WithMany(p => p.CuentaBancaria)
                    .HasForeignKey(d => d.CbEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CuentaBan__CB_Em__4589517F");
            });

            modelBuilder.Entity<CuentasPorCobrar>(entity =>
            {
                entity.HasKey(e => e.CpcId);

                entity.Property(e => e.CpcId).HasColumnName("CPC_ID");

                entity.Property(e => e.CpcAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPC_AlumnoClave");

                entity.Property(e => e.CpcAlumnoId).HasColumnName("CPC_AlumnoID");

                entity.Property(e => e.CpcAño).HasColumnName("CPC_Año");

                entity.Property(e => e.CpcEstatus).HasColumnName("CPC_Estatus");

                entity.Property(e => e.CpcFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("CPC_FechaCreacion");

                entity.Property(e => e.CpcFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CPC_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_ImportePendiente");

                entity.Property(e => e.CpcImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_ImporteTotal");

                entity.Property(e => e.CpcListaPrecio).HasColumnName("CPC_ListaPrecio");

                entity.Property(e => e.CpcPeriodo).HasColumnName("CPC_Periodo");

                entity.Property(e => e.CpcPrecioUnitario)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_PrecioUnitario");

                entity.Property(e => e.CpcReferenciaCuenta).HasColumnName("CPC_ReferenciaCuenta");

                entity.Property(e => e.CpcUnidad).HasColumnName("CPC_Unidad");

                entity.Property(e => e.CpcUsuid).HasColumnName("CPC_Usuid");

                entity.HasOne(d => d.CpcAlumno)
                    .WithMany(p => p.CuentasPorCobrar)
                    .HasForeignKey(d => d.CpcAlumnoId)
                    .HasConstraintName("FK_CuentasPorCobrar_Alumno");

                entity.HasOne(d => d.CpcEstatusNavigation)
                    .WithMany(p => p.CuentasPorCobrar)
                    .HasForeignKey(d => d.CpcEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuentasPorCobrar_EstatusList");

                entity.HasOne(d => d.CpcListaPrecioNavigation)
                    .WithMany(p => p.CuentasPorCobrar)
                    .HasForeignKey(d => d.CpcListaPrecio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CuentasPorCobrar_ListaPrecio");

                entity.HasOne(d => d.CpcReferenciaCuentaNavigation)
                    .WithMany(p => p.InverseCpcReferenciaCuentaNavigation)
                    .HasForeignKey(d => d.CpcReferenciaCuenta)
                    .HasConstraintName("FK_CuentasPorCobrar_CuentasPorCobrar");
            });

            modelBuilder.Entity<DatosFacturacion>(entity =>
            {
                entity.HasKey(e => new { e.DfRfc, e.AlId })
                    .HasName("PK__DatosFac__59E0E2488EBC0A05");

                entity.Property(e => e.DfRfc)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("DF_RFC")
                    .IsFixedLength();

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.DfApm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF_APM")
                    .IsFixedLength();

                entity.Property(e => e.DfApp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF_APP")
                    .IsFixedLength();

                entity.Property(e => e.DfCalle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DF_Calle");

                entity.Property(e => e.DfCodPos)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DF_CodPos");

                entity.Property(e => e.DfColonia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DF_Colonia");

                entity.Property(e => e.DfDireccion)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DF_Direccion");

                entity.Property(e => e.DfEmail)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("DF_Email");

                entity.Property(e => e.DfEstado).HasColumnName("DF_Estado");

                entity.Property(e => e.DfMunicipio).HasColumnName("DF_Municipio");

                entity.Property(e => e.DfNoExt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DF_NoExt");

                entity.Property(e => e.DfNoInt)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DF_NoInt");

                entity.Property(e => e.DfNombre)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DF_Nombre");

                entity.Property(e => e.DfTipoPersona).HasColumnName("DF_TipoPersona");

                entity.Property(e => e.DfUso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DF_Uso")
                    .IsFixedLength();

                entity.HasOne(d => d.DfEstadoNavigation)
                    .WithMany(p => p.DatosFacturacion)
                    .HasForeignKey(d => d.DfEstado)
                    .HasConstraintName("FK__DatosFact__DF_Es__4B0D20AB");

                entity.HasOne(d => d.DfMunicipioNavigation)
                    .WithMany(p => p.DatosFacturacion)
                    .HasForeignKey(d => d.DfMunicipio)
                    .HasConstraintName("FK__DatosFact__DF_Mu__4C0144E4");

                entity.HasOne(d => d.DfUsoNavigation)
                    .WithMany(p => p.DatosFacturacion)
                    .HasForeignKey(d => d.DfUso)
                    .HasConstraintName("FK__DatosFact__DF_Us__4CF5691D");
            });

            modelBuilder.Entity<DatosMedicos>(entity =>
            {
                entity.HasKey(e => e.DmPacienteId)
                    .HasName("PK__DatosMed__7FABE20EA514A74F");

                entity.Property(e => e.DmPacienteId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DM_PacienteID");

                entity.Property(e => e.DmAlergico).HasColumnName("DM_Alergico");

                entity.Property(e => e.DmCirugias)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("DM_Cirugias")
                    .IsFixedLength();

                entity.Property(e => e.DmDiabetes).HasColumnName("DM_Diabetes");

                entity.Property(e => e.DmEstatura)
                    .HasColumnType("numeric(2, 2)")
                    .HasColumnName("DM_Estatura");

                entity.Property(e => e.DmFuma).HasColumnName("DM_Fuma");

                entity.Property(e => e.DmHijos).HasColumnName("DM_Hijos");

                entity.Property(e => e.DmHipertension).HasColumnName("DM_Hipertension");

                entity.Property(e => e.DmMascotas).HasColumnName("DM_Mascotas");

                entity.Property(e => e.DmPeso)
                    .HasColumnType("numeric(3, 2)")
                    .HasColumnName("DM_Peso");

                entity.Property(e => e.DmTatuajes).HasColumnName("DM_Tatuajes");

                entity.Property(e => e.DmTipoSangre)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("DM_TipoSangre")
                    .IsFixedLength();

                entity.Property(e => e.DmToma).HasColumnName("DM_Toma");

                entity.HasOne(d => d.DmPaciente)
                    .WithOne(p => p.DatosMedicos)
                    .HasForeignKey<DatosMedicos>(d => d.DmPacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DatosMedi__DM_Pa__4A4E069C");
            });

            modelBuilder.Entity<DatosP>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("datosP");

                entity.Property(e => e.AdminApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_APM");

                entity.Property(e => e.AdminApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_APP");

                entity.Property(e => e.AdminNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Nombre");

                entity.Property(e => e.Campanio).HasColumnName("campanio");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Campperiodo).HasColumnName("campperiodo");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.CodBarras)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfecError)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("efecError");

                entity.Property(e => e.EfecOperationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("efecOperationDate");

                entity.Property(e => e.FechaExpiro).HasColumnType("datetime");

                entity.Property(e => e.GpApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APM");

                entity.Property(e => e.GpApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APP");

                entity.Property(e => e.GpBeca).HasColumnName("GP_Beca");

                entity.Property(e => e.GpBecaInscripcion).HasColumnName("GP_BecaInscripcion");

                entity.Property(e => e.GpDescPromocion).HasColumnName("GP_DescPromocion");

                entity.Property(e => e.GpImporte).HasColumnName("GP_Importe");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_Nombre");

                entity.Property(e => e.GpObservaciones)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("GP_observaciones");

                entity.Property(e => e.GpPorcentajeBeca).HasColumnName("GP_PorcentajeBeca");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpSemestre).HasColumnName("GP_Semestre");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.ModDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.SolicitudId).HasColumnName("solicitudId");

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<DatosParticipantes>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DpapmEme)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DPApmEme");

                entity.Property(e => e.DpapmTutor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DPApmTutor");

                entity.Property(e => e.DpappEme)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DPAppEme");

                entity.Property(e => e.DpappTutor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DPAppTutor");

                entity.Property(e => e.DpcelEme)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DPCelEme");

                entity.Property(e => e.DpcelTutor)
                    .HasMaxLength(10)
                    .HasColumnName("DPCelTutor")
                    .IsFixedLength();

                entity.Property(e => e.DpfechaReg)
                    .HasColumnType("datetime")
                    .HasColumnName("DPFechaReg");

                entity.Property(e => e.Dpfoto)
                    .IsRequired()
                    .HasColumnName("DPFoto");

                entity.Property(e => e.Dpgafete).HasColumnName("DPGafete");

                entity.Property(e => e.Dpid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DPId");

                entity.Property(e => e.Dpident)
                    .IsRequired()
                    .HasColumnName("DPIdent");

                entity.Property(e => e.Dpip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DPIp");

                entity.Property(e => e.DpnomEme)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DPNomEme");

                entity.Property(e => e.DpnomTutor)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DPNomTutor");

                entity.Property(e => e.DptermyCond)
                    .IsRequired()
                    .HasColumnName("DPTermyCond");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");
            });

            modelBuilder.Entity<DetalleCancelacionPago>(entity =>
            {
                entity.HasKey(e => e.DcId);

                entity.Property(e => e.DcId).HasColumnName("DC_ID");

                entity.Property(e => e.DcCancelacionId).HasColumnName("DC_CancelacionId");

                entity.Property(e => e.DcCuentaDetalle).HasColumnName("DC_CuentaDetalle");

                entity.Property(e => e.DcDocLinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DC_DocLinea")
                    .IsFixedLength();

                entity.Property(e => e.DcFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("DC_FechaRegistro");

                entity.Property(e => e.DcImporteAplicado)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DC_ImporteAplicado");

                entity.Property(e => e.DcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DC_ImportePendiente");

                entity.Property(e => e.DcPagoId).HasColumnName("DC_PagoID");

                entity.Property(e => e.DcSaldoCreado).HasColumnName("DC_SaldoCreado");

                entity.Property(e => e.DcUsuid).HasColumnName("DC_Usuid");

                entity.HasOne(d => d.DcCancelacion)
                    .WithMany(p => p.DetalleCancelacionPago)
                    .HasForeignKey(d => d.DcCancelacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCancelacionPago_CancelacionPago");

                entity.HasOne(d => d.DcCuentaDetalleNavigation)
                    .WithMany(p => p.DetalleCancelacionPago)
                    .HasForeignKey(d => d.DcCuentaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCancelacionPago_DetalleCuentaCobrar");

                entity.HasOne(d => d.DcPago)
                    .WithMany(p => p.DetalleCancelacionPago)
                    .HasForeignKey(d => d.DcPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleCancelacionPago_Pago");
            });

            modelBuilder.Entity<DetalleConvenio>(entity =>
            {
                entity.HasKey(e => e.DcId)
                    .HasName("PK__DetalleC__1533DFF8F865B507");

                entity.Property(e => e.DcId).HasColumnName("DC_ID");

                entity.Property(e => e.DcConvenio).HasColumnName("DC_Convenio");

                entity.Property(e => e.DcCuentaDetalle).HasColumnName("DC_CuentaDetalle");

                entity.Property(e => e.DcFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("DC_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DcUsuid).HasColumnName("DC_Usuid");

                entity.HasOne(d => d.DcConvenioNavigation)
                    .WithMany(p => p.DetalleConvenio)
                    .HasForeignKey(d => d.DcConvenio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleCo__DC_Co__3BCADD1B");

                entity.HasOne(d => d.DcCuentaDetalleNavigation)
                    .WithMany(p => p.DetalleConvenio)
                    .HasForeignKey(d => d.DcCuentaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleConvenio_DetalleCuentaCobrar");
            });

            modelBuilder.Entity<DetalleCuentaPorCobrar>(entity =>
            {
                entity.HasKey(e => e.DcpcId);

                entity.Property(e => e.DcpcId).HasColumnName("DCPC_ID");

                entity.Property(e => e.DcpcCuentaId).HasColumnName("DCPC_CuentaId");

                entity.Property(e => e.DcpcDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_Descripcion");

                entity.Property(e => e.DcpcDocLinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_DocLinea");

                entity.Property(e => e.DcpcEstatus).HasColumnName("DCPC_Estatus");

                entity.Property(e => e.DcpcFechaCierreCuenta)
                    .HasColumnType("date")
                    .HasColumnName("DCPC_FechaCierreCuenta");

                entity.Property(e => e.DcpcFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("DCPC_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DcpcFechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("DCPC_FechaVencimiento");

                entity.Property(e => e.DcpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImportePendiente");

                entity.Property(e => e.DcpcImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImporteTotal");

                entity.Property(e => e.DcpcPrecioUnitario)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_PrecioUnitario");

                entity.Property(e => e.DcpcReferenciaCuentaDetalle).HasColumnName("DCPC_ReferenciaCuentaDetalle");

                entity.Property(e => e.DcpcUnidad).HasColumnName("DCPC_Unidad");

                entity.Property(e => e.DcpcUnidadAux).HasColumnName("DCPC_UnidadAux");

                entity.Property(e => e.DcpcUsuid).HasColumnName("DCPC_Usuid");

                entity.Property(e => e.DdcpcPrecioUnitarioAux)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DDCPC_PrecioUnitarioAux");

                entity.HasOne(d => d.DcpcCuenta)
                    .WithMany(p => p.DetalleCuentaPorCobrar)
                    .HasForeignKey(d => d.DcpcCuentaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_CuentasPorCobrar");

                entity.HasOne(d => d.DcpcEstatusNavigation)
                    .WithMany(p => p.DetalleCuentaPorCobrar)
                    .HasForeignKey(d => d.DcpcEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstatusEE");

                entity.HasOne(d => d.DcpcReferenciaCuentaDetalleNavigation)
                    .WithMany(p => p.InverseDcpcReferenciaCuentaDetalleNavigation)
                    .HasForeignKey(d => d.DcpcReferenciaCuentaDetalle)
                    .HasConstraintName("FK_DetalleCuentaPorCobrar_DetalleCuentaPorCobrar");
            });

            modelBuilder.Entity<DetalleEsquema>(entity =>
            {
                entity.Property(e => e.DeInscripcion).HasColumnName("DE_Inscripcion");

                entity.Property(e => e.DeMensualidad).HasColumnName("DE_Mensualidad");

                entity.Property(e => e.LpId).HasColumnName("LP_ID");

                entity.HasOne(d => d.Lp)
                    .WithMany(p => p.DetalleEsquema)
                    .HasForeignKey(d => d.LpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEsquema_ListaPrecios");
            });

            modelBuilder.Entity<DetallePago>(entity =>
            {
                entity.HasKey(e => e.DpId);

                entity.Property(e => e.DpId).HasColumnName("DP_ID");

                entity.Property(e => e.DpCuentaDetalle).HasColumnName("DP_CuentaDetalle");

                entity.Property(e => e.DpDocLinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DP_DocLinea")
                    .IsFixedLength();

                entity.Property(e => e.DpFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("DP_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DpImporteAplicado)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DP_ImporteAplicado");

                entity.Property(e => e.DpImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DP_ImportePendiente");

                entity.Property(e => e.DpPagoId).HasColumnName("DP_PagoID");

                entity.Property(e => e.DpSaldoCreado).HasColumnName("DP_SaldoCreado");

                entity.Property(e => e.DpUsuid).HasColumnName("DP_Usuid");

                entity.HasOne(d => d.DpCuentaDetalleNavigation)
                    .WithMany(p => p.DetallePago)
                    .HasForeignKey(d => d.DpCuentaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallePago_CuentaDetalle");

                entity.HasOne(d => d.DpPago)
                    .WithMany(p => p.DetallePago)
                    .HasForeignKey(d => d.DpPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetallePa__DP_Pa__00DF2177");
            });

            modelBuilder.Entity<DetalleReferencia>(entity =>
            {
                entity.HasKey(e => e.DrId);

                entity.Property(e => e.DrId).HasColumnName("DR_ID");

                entity.Property(e => e.DrCuentaDetalle).HasColumnName("DR_CuentaDetalle");

                entity.Property(e => e.DrFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("DR_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DrMontoAplicado)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DR_MontoAplicado");

                entity.Property(e => e.DrReferencia).HasColumnName("DR_Referencia");

                entity.Property(e => e.DrUsuid).HasColumnName("DR_Usuid");

                entity.HasOne(d => d.DrCuentaDetalleNavigation)
                    .WithMany(p => p.DetalleReferencia)
                    .HasForeignKey(d => d.DrCuentaDetalle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleReferencia_DetalleCuenta");

                entity.HasOne(d => d.DrReferenciaNavigation)
                    .WithMany(p => p.DetalleReferencia)
                    .HasForeignKey(d => d.DrReferencia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleReferencia_Referencia");
            });

            modelBuilder.Entity<DocumentoAlumno>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoAl)
                    .HasName("PK__Document__44116204B31E3467");

                entity.Property(e => e.Addcestatus).HasColumnName("ADDCEstatus");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.HasOne(d => d.AddcestatusNavigation)
                    .WithMany(p => p.DocumentoAlumno)
                    .HasForeignKey(d => d.Addcestatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__ADDCE__5C37ACAD");

                entity.HasOne(d => d.Al)
                    .WithMany(p => p.DocumentoAlumno)
                    .HasForeignKey(d => d.AlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__AL_ID__3CBF0154");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.DocumentoAlumno)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__IdDoc__5E1FF51F");
            });

            modelBuilder.Entity<DocumentoBitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora)
                    .HasName("PK__Document__ED3A1B132C37DF1F");

                entity.Property(e => e.CambioTipoBit)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComentarioBit)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaBit).HasColumnType("datetime");

                entity.Property(e => e.Ipbit)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("IPBit");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NombreCuadroBit)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDocBit)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.DocumentoBitacora)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__IdDoc__5F141958");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.DocumentoBitacora)
                    .HasForeignKey(d => d.NivelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__Nivel__60083D91");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.DocumentoBitacora)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK__Documento__usuid__408F9238");
            });

            modelBuilder.Entity<Documentos>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("PK__Document__E52073472F2511AC");

                entity.Property(e => e.NomCuadroDoc)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreDoc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DocumentosGenerales>(entity =>
            {
                entity.HasKey(e => e.Dgid);

                entity.Property(e => e.Dgid)
                    .ValueGeneratedNever()
                    .HasColumnName("DGId");

                entity.Property(e => e.DgAtendio).HasColumnName("DG_Atendio");

                entity.Property(e => e.DgComentario)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("DG_Comentario");

                entity.Property(e => e.DgDocRoute)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DG_DocRoute");

                entity.Property(e => e.DgDocumento).HasColumnName("DG_Documento");

                entity.Property(e => e.DgEstatus).HasColumnName("DG_Estatus");

                entity.Property(e => e.DgFecReg)
                    .HasColumnType("date")
                    .HasColumnName("DG_FecReg");

                entity.Property(e => e.DgNombre)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DG_Nombre");

                entity.Property(e => e.DgPersonaId).HasColumnName("DG_PersonaID");

                entity.Property(e => e.DgTipoDoc).HasColumnName("DG_TipoDoc");

                entity.Property(e => e.DgTipoPers).HasColumnName("DG_TipoPers");
            });

            modelBuilder.Entity<DocumentosHistorial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DhAtendio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DH_Atendio");

                entity.Property(e => e.DhDocumento)
                    .HasMaxLength(1)
                    .HasColumnName("DH_Documento");

                entity.Property(e => e.DhDocumentoId).HasColumnName("DH_DocumentoID");

                entity.Property(e => e.DhEstatus).HasColumnName("DH_Estatus");

                entity.Property(e => e.DhFechaCompromiso)
                    .HasColumnType("date")
                    .HasColumnName("DH_Fecha Compromiso");

                entity.Property(e => e.DhFechaEntrega)
                    .HasColumnType("date")
                    .HasColumnName("DH_Fecha Entrega");

                entity.Property(e => e.DhPersonaId).HasColumnName("DH_PersonaID");

                entity.HasOne(d => d.DhAtendioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.DhAtendio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__DH_At__6AEFE058");

                entity.HasOne(d => d.DhPersona)
                    .WithMany()
                    .HasPrincipalKey(p => p.AdminNumeroEmpleado)
                    .HasForeignKey(d => d.DhPersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__DH_Pe__38EE7070");

                entity.HasOne(d => d.DhPersonaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.DhPersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__DH_Pe__7755B73D");
            });

            modelBuilder.Entity<DocumentosNivel>(entity =>
            {
                entity.HasKey(e => e.IdDocumentoNivel)
                    .HasName("PK__Document__3D890FF5DAA677D0");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.HasOne(d => d.IdDocumentoNavigation)
                    .WithMany(p => p.DocumentosNivel)
                    .HasForeignKey(d => d.IdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__IdDoc__64CCF2AE");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.DocumentosNivel)
                    .HasForeignKey(d => d.NivelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documento__Nivel__65C116E7");
            });

            modelBuilder.Entity<Edificios>(entity =>
            {
                entity.HasKey(e => e.EEdificioId)
                    .HasName("PK__Edificio__E0F179107107D721");

                entity.Property(e => e.EEdificioId)
                    .ValueGeneratedNever()
                    .HasColumnName("E_EdificioID");

                entity.Property(e => e.EDescripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("E_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.ENombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("E_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<EgresadoHistorial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EhAlumnoId).HasColumnName("EH_AlumnoID");

                entity.Property(e => e.EhAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EH_AutorizadoPor");

                entity.Property(e => e.EhFechaEgresoNivel)
                    .HasColumnType("date")
                    .HasColumnName("EH_FechaEgresoNivel");

                entity.Property(e => e.EhFechaIngresoNivel)
                    .HasColumnType("date")
                    .HasColumnName("EH_FechaIngresoNivel");

                entity.Property(e => e.EhNivel)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("EH_Nivel");

                entity.HasOne(d => d.EhAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.EhAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EgresadoH__EH_Al__336AA144");

                entity.HasOne(d => d.EhAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EhAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EgresadoH__EH_Au__44952D46");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Empresas__2623598B84EDFCE2");

                entity.Property(e => e.EmpId).HasColumnName("Emp_ID");

                entity.Property(e => e.EmpDir)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Dir");

                entity.Property(e => e.EmpNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Emp_Nombre");

                entity.Property(e => e.EmpRfc)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("Emp_RFC");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_Empresas_usuario");
            });

            modelBuilder.Entity<Errores>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ErrorDesc)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("error_desc");

                entity.Property(e => e.ErrorEstate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("error_estate");

                entity.Property(e => e.ErrorMod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("error_mod")
                    .IsFixedLength();

                entity.Property(e => e.ErrorProcedure)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("error_procedure");

                entity.Property(e => e.IdError)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_error");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Usu)
                    .WithMany()
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_Errores_usuario");
            });

            modelBuilder.Entity<EscolaridadAdmin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EscAdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Esc_AdminID");

                entity.Property(e => e.EscCedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Esc_Cedula")
                    .IsFixedLength();

                entity.Property(e => e.EscDescripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Esc_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.EscFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("Esc_FechaFin");

                entity.Property(e => e.EscFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Esc_FechaInicio");

                entity.Property(e => e.EscTitulo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Esc_Titulo")
                    .IsFixedLength();

                entity.HasOne(d => d.EscAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.EscAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Escolarid__Esc_A__73852659");
            });

            modelBuilder.Entity<Escuelas>(entity =>
            {
                entity.Property(e => e.EscuelasId)
                    .ValueGeneratedNever()
                    .HasColumnName("Escuelas_ID");

                entity.Property(e => e.EscuelasEstado).HasColumnName("Escuelas_Estado");

                entity.Property(e => e.EscuelasNombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Escuelas_Nombre");
            });

            modelBuilder.Entity<Escuelasf>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EscuelasEstado).HasColumnName("Escuelas_Estado");

                entity.Property(e => e.EscuelasId).HasColumnName("Escuelas_ID");

                entity.Property(e => e.EscuelasNombre)
                    .IsUnicode(false)
                    .HasColumnName("Escuelas_Nombre");
            });

            modelBuilder.Entity<EsquemaPago>(entity =>
            {
                entity.HasKey(e => e.EpId)
                    .HasName("PK__EsquemaP__94F6E55150BF78B9");

                entity.HasIndex(e => e.EpId, "UQ__EsquemaP__94F6E5500331AC2A")
                    .IsUnique();

                entity.Property(e => e.EpId).HasColumnName("EP_ID");

                entity.Property(e => e.EpDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EP_Descripcion");

                entity.Property(e => e.EpDiaVencimiento).HasColumnName("EP_DiaVencimiento");

                entity.Property(e => e.EpFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("EP_FechaInicio");

                entity.Property(e => e.EpFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("EP_FechaRegistro");

                entity.Property(e => e.EpInscripcion).HasColumnName("EP_Inscripcion");

                entity.Property(e => e.EpListaPrecio).HasColumnName("EP_ListaPrecio");

                entity.Property(e => e.EpMontoInscripcion)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("EP_MontoInscripcion");

                entity.Property(e => e.EpMontoMensualidad)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("EP_MontoMensualidad");

                entity.Property(e => e.EpNoInscripciones).HasColumnName("EP_NoInscripciones");

                entity.Property(e => e.EpNoMensualidades).HasColumnName("EP_NoMensualidades");

                entity.Property(e => e.EpUsuid).HasColumnName("EP_Usuid");

                entity.HasOne(d => d.EpListaPrecioNavigation)
                    .WithMany(p => p.EsquemaPago)
                    .HasForeignKey(d => d.EpListaPrecio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EsquemaPago_ListaPrecios");
            });

            modelBuilder.Entity<EsquemaPagoHistorial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EphAlumnoId).HasColumnName("EPH_AlumnoID");

                entity.Property(e => e.EphAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EPH_AutorizadoPor");

                entity.Property(e => e.EphFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("EPH_FechaFin");

                entity.Property(e => e.EphFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("EPH_FechaInicio");

                entity.Property(e => e.EphFormasPagoId).HasColumnName("EPH_FormasPagoID");

                entity.Property(e => e.FphMensualidadAnterior).HasColumnName("FPH MensualidadAnterior");

                entity.HasOne(d => d.EphAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.EphAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EsquemaPa__EPH_A__0B5CAFEA");

                entity.HasOne(d => d.EphAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.EphAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EsquemaPa__EPH_A__43A1090D");
            });

            modelBuilder.Entity<Estados>(entity =>
            {
                entity.Property(e => e.EstadosId)
                    .ValueGeneratedNever()
                    .HasColumnName("Estados_ID");

                entity.Property(e => e.EstadosNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Estados_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<EstatusList>(entity =>
            {
                entity.HasKey(e => e.SlStatusId)
                    .HasName("PK__EstatusList");

                entity.Property(e => e.SlStatusId).HasColumnName("SL_StatusID");

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");

                entity.Property(e => e.SlModulo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SL_Modulo");

                entity.Property(e => e.SlModuloId).HasColumnName("SL_ModuloID");

                entity.Property(e => e.SlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SL_Nombre");
            });

            modelBuilder.Entity<ExisteP>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ExisteP");

                entity.Property(e => e.GpProspectoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");
            });

            modelBuilder.Entity<ExpProfecional>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EpAdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EP_AdminID");

                entity.Property(e => e.EpDescripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EP_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.EpEmpleoAnterior)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EP_EmpleoAnterior")
                    .IsFixedLength();

                entity.Property(e => e.EpFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("EP_FechaFin");

                entity.Property(e => e.EpFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("EP_FechaInicio");

                entity.HasOne(d => d.EpAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.EpAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExpProfec__EP_Ad__7849DB76");
            });

            modelBuilder.Entity<Facturas>(entity =>
            {
                entity.HasKey(e => e.FFacturaId)
                    .HasName("PK__Facturas__065425F8D780DEA7");

                entity.HasIndex(e => e.FPagoId, "UQ__Facturas__61FA755B490653B7")
                    .IsUnique();

                entity.Property(e => e.FFacturaId)
                    .ValueGeneratedNever()
                    .HasColumnName("F_FacturaID");

                entity.Property(e => e.FCancelado).HasColumnName("F_Cancelado");

                entity.Property(e => e.FFecha)
                    .HasColumnType("date")
                    .HasColumnName("F_Fecha");

                entity.Property(e => e.FFechaContable)
                    .HasColumnType("date")
                    .HasColumnName("F_FechaContable");

                entity.Property(e => e.FIva).HasColumnName("F_IVA");

                entity.Property(e => e.FPagoId).HasColumnName("F_PagoID");

                entity.Property(e => e.FRfc)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("F_RFC")
                    .IsFixedLength();

                entity.Property(e => e.FTotal).HasColumnName("F_Total");

                entity.Property(e => e.FUso)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("F_Uso")
                    .IsFixedLength();

                entity.HasOne(d => d.FPago)
                    .WithOne(p => p.Facturas)
                    .HasForeignKey<Facturas>(d => d.FPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Facturas__F_Pago__03BB8E22");
            });

            modelBuilder.Entity<Facultades>(entity =>
            {
                entity.HasKey(e => e.FacFacultadId)
                    .HasName("PK__Facultad__E240B8DEF078F9AC");

                entity.Property(e => e.FacFacultadId)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("FAC_FacultadID");

                entity.Property(e => e.FacDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FAC_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.FacNombre)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("FAC_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<FaltasClase>(entity =>
            {
                entity.HasKey(e => e.FcFaltaId)
                    .HasName("PK__FaltasCl__6C542B4E00B861D9");

                entity.Property(e => e.FcFaltaId)
                    .ValueGeneratedNever()
                    .HasColumnName("FC_FaltaID");

                entity.Property(e => e.FcAlumnoId).HasColumnName("FC_AlumnoID");

                entity.Property(e => e.FcFechaFalta)
                    .HasColumnType("date")
                    .HasColumnName("FC_FechaFalta");

                entity.Property(e => e.FcMateriaId).HasColumnName("FC_MateriaID");

                entity.HasOne(d => d.FcAlumno)
                    .WithMany(p => p.FaltasClase)
                    .HasForeignKey(d => d.FcAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FaltasCla__FC_Al__00AA174D");

                entity.HasOne(d => d.FcMateria)
                    .WithMany(p => p.FaltasClase)
                    .HasForeignKey(d => d.FcMateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FaltasCla__FC_Ma__0E04126B");
            });

            modelBuilder.Entity<Ferias>(entity =>
            {
                entity.HasKey(e => e.Idferia)
                    .HasName("tpferias_pkey");

                entity.ToTable("ferias");

                entity.Property(e => e.Idferia).HasColumnName("idferia");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Feriafechafin)
                    .HasColumnType("date")
                    .HasColumnName("feriafechafin");

                entity.Property(e => e.Feriafechainicio)
                    .HasColumnType("date")
                    .HasColumnName("feriafechainicio");

                entity.Property(e => e.Ferianombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ferianombre");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Camp)
                    .WithMany(p => p.Ferias)
                    .HasForeignKey(d => d.Campid)
                    .HasConstraintName("FK_ferias_campaña");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Ferias)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_ferias_usuario");
            });

            modelBuilder.Entity<FirmaReglamentosCv>(entity =>
            {
                entity.HasKey(e => e.IdFirmaCv);

                entity.ToTable("FirmaReglamentosCV");

                entity.Property(e => e.IdFirmaCv).HasColumnName("IdFirmaCV");

                entity.Property(e => e.Cliente)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CoorFirma)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFirma).HasColumnType("datetime");

                entity.Property(e => e.IdRegistroCv).HasColumnName("IdRegistroCV");

                entity.Property(e => e.Ipfirma)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IPFirma");

                entity.Property(e => e.Reglamentoid).HasColumnName("reglamentoid");

                entity.HasOne(d => d.IdRegistroCvNavigation)
                    .WithMany(p => p.FirmaReglamentosCv)
                    .HasForeignKey(d => d.IdRegistroCv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FirmaReglamentosCV_RegistrosCV");

                entity.HasOne(d => d.Reglamento)
                    .WithMany(p => p.FirmaReglamentosCv)
                    .HasForeignKey(d => d.Reglamentoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FirmaReglamentosCV_Reglamentos");
            });

            modelBuilder.Entity<Folio>(entity =>
            {
                entity.Property(e => e.FolioId)
                    .ValueGeneratedNever()
                    .HasColumnName("Folio_id");

                entity.Property(e => e.FolioAlu).HasColumnName("Folio_alu");

                entity.Property(e => e.FolioAluDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Folio_alu_date");

                entity.Property(e => e.FolioAluUsuid).HasColumnName("Folio_alu_usuid");

                entity.Property(e => e.FolioPrs).HasColumnName("Folio_prs");

                entity.Property(e => e.FolioPrsDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Folio_prs_date");

                entity.Property(e => e.FolioPrsUsuid).HasColumnName("Folio_prs_usuid");
            });

            modelBuilder.Entity<FormaPago>(entity =>
            {
                entity.HasKey(e => e.FpId)
                    .HasName("PK__FormaPag__3DE1AB13ADB20D2D");

                entity.Property(e => e.FpId).HasColumnName("FP_ID");

                entity.Property(e => e.FpActivaManual).HasColumnName("FP_ActivaManual");

                entity.Property(e => e.FpClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FP_Clave");

                entity.Property(e => e.FpDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FP_Descripcion");

                entity.Property(e => e.FpFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FP_FechaRegistro");

                entity.Property(e => e.FpUsuid).HasColumnName("FP_Usuid");
            });

            modelBuilder.Entity<FormaPagoTxt>(entity =>
            {
                entity.HasKey(e => e.FptId);

                entity.Property(e => e.FptId).HasColumnName("FPT_ID");

                entity.Property(e => e.FptDescripcionTxt)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FPT_DescripcionTxt");

                entity.Property(e => e.FptFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("FPT_FechaRegistro");

                entity.Property(e => e.FptFormaPago).HasColumnName("FPT_FormaPago");

                entity.Property(e => e.FptUsuid).HasColumnName("FPT_Usuid");

                entity.HasOne(d => d.FptFormaPagoNavigation)
                    .WithMany(p => p.FormaPagoTxt)
                    .HasForeignKey(d => d.FptFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FormaPagoTxt_FormaPago");
            });

            modelBuilder.Entity<GeneralesAdministrativos>(entity =>
            {
                entity.HasKey(e => e.GaAdminId)
                    .HasName("PK__Generale__5F1223DFEEA53CEB");

                entity.Property(e => e.GaAdminId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GA_AdminID");

                entity.Property(e => e.GaCell)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GA_Cell")
                    .IsFixedLength();

                entity.Property(e => e.GaColonia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GA_Colonia")
                    .IsFixedLength();

                entity.Property(e => e.GaCorreoAlterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GA_CorreoAlterno")
                    .IsFixedLength();

                entity.Property(e => e.GaCp).HasColumnName("GA_CP");

                entity.Property(e => e.GaDomicilio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GA_Domicilio")
                    .IsFixedLength();

                entity.Property(e => e.GaEstado).HasColumnName("GA_Estado");

                entity.Property(e => e.GaMunicipio).HasColumnName("GA_Municipio");

                entity.Property(e => e.GaTelefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GA_Telefono")
                    .IsFixedLength();

                entity.HasOne(d => d.GaAdmin)
                    .WithOne(p => p.GeneralesAdministrativos)
                    .HasForeignKey<GeneralesAdministrativos>(d => d.GaAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Generales__GA_Ad__70A8B9AE");
            });

            modelBuilder.Entity<GeneralesAlumno>(entity =>
            {
                entity.HasKey(e => e.GaAlumnoId)
                    .HasName("PK__Generale__D988B5F2D7DB48D2");

                entity.Property(e => e.GaAlumnoId).HasColumnName("GA_AlumnoID");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.GaApmtutor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GA_APMTutor")
                    .IsFixedLength();

                entity.Property(e => e.GaApptutor)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GA_APPTutor")
                    .IsFixedLength();

                entity.Property(e => e.GaCalle)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GA_Calle")
                    .IsFixedLength();

                entity.Property(e => e.GaCorreoAlternativo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GA_CorreoAlternativo")
                    .IsFixedLength();

                entity.Property(e => e.GaEstado).HasColumnName("GA_Estado");

                entity.Property(e => e.GaFechaNac)
                    .HasColumnType("date")
                    .HasColumnName("GA_FechaNac");

                entity.Property(e => e.GaMunicipio).HasColumnName("GA_Municipio");

                entity.Property(e => e.GaNombreTutor)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GA_NombreTutor")
                    .IsFixedLength();

                entity.Property(e => e.GaNueroExt)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GA_NueroExt")
                    .IsFixedLength();

                entity.Property(e => e.GaNumeroInterior)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GA_NumeroInterior")
                    .IsFixedLength();

                entity.Property(e => e.GaTelefonoAlumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GA_TelefonoAlumno")
                    .IsFixedLength();

                entity.Property(e => e.GaTelefonoCasa)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GA_TelefonoCasa")
                    .IsFixedLength();

                entity.Property(e => e.GaTelefonoTutor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GA_TelefonoTutor")
                    .IsFixedLength();

                entity.HasOne(d => d.Al)
                    .WithMany(p => p.GeneralesAlumno)
                    .HasForeignKey(d => d.AlId)
                    .HasConstraintName("FK_GeneralesAlumno_Alumno");

                entity.HasOne(d => d.GaEstadoNavigation)
                    .WithMany(p => p.GeneralesAlumno)
                    .HasForeignKey(d => d.GaEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Generales__GA_Es__603D47BB");

                entity.HasOne(d => d.GaMunicipioNavigation)
                    .WithMany(p => p.GeneralesAlumno)
                    .HasForeignKey(d => d.GaMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Generales__GA_Mu__61316BF4");
            });

            modelBuilder.Entity<GeneralesProspecto>(entity =>
            {
                entity.HasKey(e => e.GpProspectoId)
                    .HasName("PK__Generale__72CF6E6085270666");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.GpApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APM");

                entity.Property(e => e.GpApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APP");

                entity.Property(e => e.GpBeca).HasColumnName("GP_Beca");

                entity.Property(e => e.GpBecaInscripcion).HasColumnName("GP_BecaInscripcion");

                entity.Property(e => e.GpBecaOfrecidaPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_BecaOfrecidaPor");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpCoutaAdmin).HasColumnName("GP_CoutaAdmin");

                entity.Property(e => e.GpCp).HasColumnName("GP_CP");

                entity.Property(e => e.GpDescPromocion).HasColumnName("GP_DescPromocion");

                entity.Property(e => e.GpDifusion).HasColumnName("GP_Difusion");

                entity.Property(e => e.GpDireccion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("GP_Direccion");

                entity.Property(e => e.GpEdad).HasColumnName("GP_Edad");

                entity.Property(e => e.GpEscuelaPros).HasColumnName("GP_EscuelaPros");

                entity.Property(e => e.GpEstado).HasColumnName("GP_Estado");

                entity.Property(e => e.GpEstatus).HasColumnName("GP_Estatus");

                entity.Property(e => e.GpFechaFirReg)
                    .HasColumnType("datetime")
                    .HasColumnName("GP_FechaFirReg");

                entity.Property(e => e.GpFirmaContra).HasColumnName("GP_FirmaContra");

                entity.Property(e => e.GpImporte).HasColumnName("GP_Importe");

                entity.Property(e => e.GpModPago).HasColumnName("GP_ModPago");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpMontoDesc)
                    .HasColumnType("decimal(17, 2)")
                    .HasColumnName("GP_MontoDesc");

                entity.Property(e => e.GpNacionalidad).HasColumnName("GP_Nacionalidad");

                entity.Property(e => e.GpNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_Nombre");

                entity.Property(e => e.GpNumDocExtra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_NumDocExtra");

                entity.Property(e => e.GpObservaciones)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("GP_observaciones");

                entity.Property(e => e.GpPorcentajeBeca).HasColumnName("GP_PorcentajeBeca");

                entity.Property(e => e.GpSemestre).HasColumnName("GP_Semestre");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.GpTermyCond).HasColumnName("GP_TermyCond");

                entity.Property(e => e.GpTipDocExtra).HasColumnName("GP_TipDocExtra");

                entity.Property(e => e.GpUsuValBeca).HasColumnName("GP_UsuValBeca");

                entity.Property(e => e.GpValBecaFecha)
                    .HasColumnType("date")
                    .HasColumnName("GP_ValBecaFecha");

                entity.Property(e => e.Gpmatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPMatricula");

                entity.Property(e => e.Gppfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GPPFecha");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.Idferia).HasColumnName("idferia");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Camp)
                    .WithMany(p => p.GeneralesProspecto)
                    .HasForeignKey(d => d.Campid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("campanaRestriccion");

                entity.HasOne(d => d.GpEstatusNavigation)
                    .WithMany(p => p.GeneralesProspecto)
                    .HasForeignKey(d => d.GpEstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralesProspecto_Estatus");

                entity.HasOne(d => d.IdcarreraNavigation)
                    .WithMany(p => p.GeneralesProspecto)
                    .HasForeignKey(d => d.Idcarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralesProspecto_IDCarrera");

                entity.HasOne(d => d.IdferiaNavigation)
                    .WithMany(p => p.GeneralesProspecto)
                    .HasForeignKey(d => d.Idferia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralesProspecto_Feria");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.GeneralesProspecto)
                    .HasForeignKey(d => d.Usuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GeneralesProspecto_Usuario");
            });

            modelBuilder.Entity<GrupoAlumno>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.GaAlumnoId).HasColumnName("GA_AlumnoID");

                entity.Property(e => e.GaGrupoId).HasColumnName("GA_GrupoID");

                entity.HasOne(d => d.GaAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.GaAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GrupoAlum__GA_Al__019E3B86");

                entity.HasOne(d => d.GaGrupo)
                    .WithMany()
                    .HasForeignKey(d => d.GaGrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GrupoAlum__GA_Gr__373B3228");
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.GGrupoId)
                    .HasName("PK__Grupos__B33C90E0ED6C6074");

                entity.Property(e => e.GGrupoId)
                    .ValueGeneratedNever()
                    .HasColumnName("G_GrupoID");

                entity.Property(e => e.GAno).HasColumnName("G_Ano");

                entity.Property(e => e.GCapacidad).HasColumnName("G_Capacidad");

                entity.Property(e => e.GFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("G_FechaFin");

                entity.Property(e => e.GFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("G_FechaInicio");

                entity.Property(e => e.GNivel).HasColumnName("G_Nivel");

                entity.Property(e => e.GNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("G_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.GPeriodo).HasColumnName("G_Periodo");

                entity.HasOne(d => d.GNivelNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.GNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grupos__G_Nivel__382F5661");

                entity.HasOne(d => d.GPeriodoNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.GPeriodo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Grupos__G_Period__36470DEF");
            });

            modelBuilder.Entity<HijosAdmin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HaAdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HA_AdminID");

                entity.Property(e => e.HaApm)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HA_APM")
                    .IsFixedLength();

                entity.Property(e => e.HaApp)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HA_APP")
                    .IsFixedLength();

                entity.Property(e => e.HaFechaNac)
                    .HasColumnType("date")
                    .HasColumnName("HA_FechaNac");

                entity.Property(e => e.HaNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HA_Nombre")
                    .IsFixedLength();

                entity.HasOne(d => d.HaAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.HaAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HijosAdmi__HA_Ad__7D0E9093");
            });

            modelBuilder.Entity<HistoricoBeca>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HbAlumnoId).HasColumnName("HB_AlumnoID");

                entity.Property(e => e.HbAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HB_AutorizadoPor");

                entity.Property(e => e.HbBecaId).HasColumnName("HB_BecaID");

                entity.Property(e => e.HbFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("HB_FechaFin");

                entity.Property(e => e.HbFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("HB_FechaInicio");

                entity.HasOne(d => d.HbAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.HbAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__HB_Al__7FEAFD3E");

                entity.HasOne(d => d.HbAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.HbAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__HB_Au__40C49C62");
            });

            modelBuilder.Entity<HistoricoPlanesEstudio>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HpeActivo).HasColumnName("HPE_Activo");

                entity.Property(e => e.HpeAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HPE_AutorizadoPor");

                entity.Property(e => e.HpeClaveOficial)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HPE_ClaveOficial")
                    .IsFixedLength();

                entity.Property(e => e.HpeCosto)
                    .HasColumnType("numeric(6, 2)")
                    .HasColumnName("HPE_Costo");

                entity.Property(e => e.HpeCreditos)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("HPE_Creditos");

                entity.Property(e => e.HpeDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("HPE_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.HpeFacultad)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("HPE_Facultad");

                entity.Property(e => e.HpeFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("HPE_FechaCreacion");

                entity.Property(e => e.HpeFechaModificacion)
                    .HasColumnType("date")
                    .HasColumnName("HPE_FechaModificacion");

                entity.Property(e => e.HpeId).HasColumnName("HPE_ID");

                entity.Property(e => e.HpeMaterias)
                    .HasColumnType("numeric(3, 0)")
                    .HasColumnName("HPE_Materias");

                entity.Property(e => e.HpeNivel).HasColumnName("HPE_Nivel");

                entity.Property(e => e.HpeNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HPE_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.HpeRvoe)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("HPE_Rvoe")
                    .IsFixedLength();

                entity.Property(e => e.HpeRvoeCreacion)
                    .HasColumnType("date")
                    .HasColumnName("HPE_RvoeCreacion");

                entity.HasOne(d => d.HpeAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.HpeAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__HPE_A__075714DC");
            });

            modelBuilder.Entity<HistoricoPorcentaje>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HpAlumnoId).HasColumnName("HP_AlumnoID");

                entity.Property(e => e.HpAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HP_AutorizadoPor");

                entity.Property(e => e.HpFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("HP_FechaFin");

                entity.Property(e => e.HpFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("HP_FechaInicio");

                entity.Property(e => e.HpPorcentaje).HasColumnName("HP_Porcentaje");

                entity.HasOne(d => d.HpAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.HpAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__HP_Al__0C50D423");

                entity.HasOne(d => d.HpAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.HpAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__HP_Au__41B8C09B");
            });

            modelBuilder.Entity<HistoricoPrecios>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HcCambiadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("HC_CambiadoPor");

                entity.Property(e => e.HcFechaFin).HasColumnName("HC_FechaFin");

                entity.Property(e => e.HcFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("HC_FechaInicio");

                entity.Property(e => e.HcMontoAnterior).HasColumnName("HC_MontoAnterior");

                entity.Property(e => e.HpPrecioId).HasColumnName("HP_PrecioID");

                entity.HasOne(d => d.HcCambiadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.HcCambiadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historico__HC_Ca__251C81ED");
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.HasKey(e => e.HHorarioId)
                    .HasName("PK__Horarios__18B92BD25DAF88A6");

                entity.Property(e => e.HHorarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("H_HorarioID");

                entity.Property(e => e.HHoraFin).HasColumnName("H_HoraFIn");

                entity.Property(e => e.HHoraInicio).HasColumnName("H_HoraInicio");

                entity.Property(e => e.HMinutoFin).HasColumnName("H_MinutoFin");

                entity.Property(e => e.HMinutoInicio).HasColumnName("H_MinutoInicio");
            });

            modelBuilder.Entity<Iadministrativos>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IAdministrativos");

                entity.Property(e => e.AdminActivo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Activo");

                entity.Property(e => e.AdminApm)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_APM");

                entity.Property(e => e.AdminApp)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_APP");

                entity.Property(e => e.AdminCorreo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Correo");

                entity.Property(e => e.AdminCurp)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_CURP");

                entity.Property(e => e.AdminExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Extension");

                entity.Property(e => e.AdminFechaIngreso)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_FechaIngreso");

                entity.Property(e => e.AdminFechaNacimiento)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_FechaNacimiento");

                entity.Property(e => e.AdminId)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_ID");

                entity.Property(e => e.AdminNacionalidad)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Nacionalidad");

                entity.Property(e => e.AdminNombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Nombre");

                entity.Property(e => e.AdminNumeroEmpleado)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_NumeroEmpleado");

                entity.Property(e => e.AdminRfc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_RFC");

                entity.Property(e => e.AdminSexo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminTipoPago)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Admin_TipoPago");
            });

            modelBuilder.Entity<InscritosUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("InscritosUsuario");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Promotor)
                    .IsRequired()
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<Justificantes>(entity =>
            {
                entity.HasKey(e => e.JJustificanteId)
                    .HasName("PK__Justific__D856112D26F5B05C");

                entity.Property(e => e.JJustificanteId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("J_JustificanteID")
                    .IsFixedLength();

                entity.Property(e => e.JAlumnoId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("J_AlumnoID");

                entity.Property(e => e.JFaltaId).HasColumnName("J_FaltaID");

                entity.Property(e => e.JFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("J_FechaFin");

                entity.Property(e => e.JFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("J_FechaInicio");

                entity.Property(e => e.JTipoJustificante).HasColumnName("J_TipoJustificante");

                entity.HasOne(d => d.JAlumno)
                    .WithMany(p => p.Justificantes)
                    .HasForeignKey(d => d.JAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Justifica__J_Alu__02925FBF");
            });

            modelBuilder.Entity<Kardex>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.KAlumnoId)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("K_AlumnoID")
                    .IsFixedLength();

                entity.Property(e => e.KAno).HasColumnName("K_Ano");

                entity.Property(e => e.KCalificacionFinal)
                    .HasColumnType("numeric(2, 2)")
                    .HasColumnName("K_CalificacionFinal");

                entity.Property(e => e.KCiclo).HasColumnName("K_Ciclo");

                entity.Property(e => e.KFechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("K_FechaRegistro");

                entity.Property(e => e.KGrupoId).HasColumnName("K_GrupoID");

                entity.Property(e => e.KMateriaId).HasColumnName("K_MateriaID");

                entity.Property(e => e.KObservaciones)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("K_Observaciones")
                    .IsFixedLength();

                entity.Property(e => e.KPeriodo).HasColumnName("K_Periodo");

                entity.HasOne(d => d.KGrupo)
                    .WithMany()
                    .HasForeignKey(d => d.KGrupoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Kardex__K_GrupoI__1A69E950");

                entity.HasOne(d => d.KMateria)
                    .WithMany()
                    .HasForeignKey(d => d.KMateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Kardex__K_Materi__147C05D0");
            });

            modelBuilder.Entity<ListaPrecios>(entity =>
            {
                entity.HasKey(e => e.LpId)
                    .HasName("PK__ListaPre__14A20AC92A2AFC96");

                entity.Property(e => e.LpId).HasColumnName("LP_ID");

                entity.Property(e => e.LpCarrera).HasColumnName("LP_Carrera");

                entity.Property(e => e.LpConcepto).HasColumnName("LP_Concepto");

                entity.Property(e => e.LpDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LP_Descripcion");

                entity.Property(e => e.LpFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("LP_FechaFin");

                entity.Property(e => e.LpFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("LP_FechaInicio");

                entity.Property(e => e.LpFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("LP_FechaRegistro");

                entity.Property(e => e.LpGeneracion).HasColumnName("LP_Generacion");

                entity.Property(e => e.LpMonto)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("LP_Monto");

                entity.Property(e => e.LpNivel).HasColumnName("LP_Nivel");

                entity.Property(e => e.LpParcialidades).HasColumnName("LP_Parcialidades");

                entity.Property(e => e.LpUsuid).HasColumnName("LP_Usuid");

                entity.HasOne(d => d.LpCarreraNavigation)
                    .WithMany(p => p.ListaPrecios)
                    .HasForeignKey(d => d.LpCarrera)
                    .HasConstraintName("FK_ListaPrecios_Carrera");

                entity.HasOne(d => d.LpConceptoNavigation)
                    .WithMany(p => p.ListaPrecios)
                    .HasForeignKey(d => d.LpConcepto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ListaPrecios_Concepto");

                entity.HasOne(d => d.LpNivelNavigation)
                    .WithMany(p => p.ListaPrecios)
                    .HasForeignKey(d => d.LpNivel)
                    .HasConstraintName("FK_ListaPrecios_Nivel");
            });

            modelBuilder.Entity<Materias>(entity =>
            {
                entity.HasKey(e => e.MMateriaId)
                    .HasName("PK__Materias__2599B3649074D6D4");

                entity.Property(e => e.MMateriaId)
                    .ValueGeneratedNever()
                    .HasColumnName("M_MateriaID");

                entity.Property(e => e.MClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("M_Clave")
                    .IsFixedLength();

                entity.Property(e => e.MCreditos).HasColumnName("M_Creditos");

                entity.Property(e => e.MDescripcio)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("M_Descripcio")
                    .IsFixedLength();

                entity.Property(e => e.MNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("M_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.MNumeroHoras)
                    .HasColumnType("numeric(2, 1)")
                    .HasColumnName("M_NumeroHoras");

                entity.Property(e => e.MOptativa).HasColumnName("M_Optativa");

                entity.Property(e => e.MOrdenMateria)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("M_OrdenMateria");

                entity.Property(e => e.MPlanEstudio)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("M_PlanEstudio")
                    .IsFixedLength();

                entity.Property(e => e.MPreRequisito)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("M_PreRequisito")
                    .IsFixedLength();

                entity.Property(e => e.MSemestre).HasColumnName("M_Semestre");
            });

            modelBuilder.Entity<MateriasImparteDocente>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MidDocenteId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MID_DocenteID");

                entity.Property(e => e.MidMateriaId).HasColumnName("MID_MateriaID");

                entity.HasOne(d => d.MidDocente)
                    .WithMany()
                    .HasForeignKey(d => d.MidDocenteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MateriasI__MID_D__3552E9B6");

                entity.HasOne(d => d.MidMateria)
                    .WithMany()
                    .HasForeignKey(d => d.MidMateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MateriasI__MID_M__10E07F16");
            });

            modelBuilder.Entity<MediosContacto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mediosContacto$");

                entity.Property(e => e.MdDescripcion)
                    .HasMaxLength(100)
                    .HasColumnName("MD_Descripcion");

                entity.Property(e => e.MdId).HasColumnName("MD_ID");

                entity.Property(e => e.MdNombre)
                    .HasMaxLength(50)
                    .HasColumnName("MD_Nombre");
            });

            modelBuilder.Entity<MediosDifusion>(entity =>
            {
                entity.HasKey(e => e.MdId)
                    .HasName("PK__MediosDi__0A957D64F41B890E");

                entity.Property(e => e.MdId)
                    .ValueGeneratedNever()
                    .HasColumnName("MD_ID");

                entity.Property(e => e.MdDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MD_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.MdNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MD_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<MetodoPago>(entity =>
            {
                entity.HasKey(e => e.MpMetodoId)
                    .HasName("PK__MetodoPa__CAEFC6A964E1DD82");

                entity.Property(e => e.MpMetodoId).HasColumnName("MP_MetodoID");

                entity.Property(e => e.MpClave)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MP_Clave");

                entity.Property(e => e.MpDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MP_Descripcion");
            });

            modelBuilder.Entity<Modalidades>(entity =>
            {
                entity.HasKey(e => e.ModModalidadId)
                    .HasName("PK__Modalida__0FD6A1B7517618BD");

                entity.Property(e => e.ModModalidadId)
                    .ValueGeneratedNever()
                    .HasColumnName("Mod_ModalidadID");

                entity.Property(e => e.ModDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.ModNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ModificacionesEsquemaPago>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MepEpDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("MEP_EP_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.MepEpDiaLimite)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("MEP_EP_DiaLimite");

                entity.Property(e => e.MepEpMensualidades)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("MEP_EP_Mensualidades");

                entity.Property(e => e.MepEpNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MEP_EP_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.MepEpPenalizacion)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("MEP_EP_Penalizacion");

                entity.Property(e => e.MepEsquemaId).HasColumnName("MEP_EsquemaID");

                entity.Property(e => e.MepFechaModificacion)
                    .HasColumnType("date")
                    .HasColumnName("MEP_FechaModificacion");

                entity.Property(e => e.MepModificadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MEP_ModificadoPor");

                entity.HasOne(d => d.MepModificadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MepModificadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Modificac__MEP_M__2704CA5F");
            });

            modelBuilder.Entity<Modulo>(entity =>
            {
                entity.Property(e => e.ModuloDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModuloFecha).HasColumnType("datetime");

                entity.Property(e => e.ModuloNombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ModuloSimbolo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Modulo)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_Tmodulo_Tusuario");
            });

            modelBuilder.Entity<Momento>(entity =>
            {
                entity.HasKey(e => e.MMomentoId)
                    .HasName("PK__Momento__E761A6EBE5E103D0");

                entity.Property(e => e.MMomentoId)
                    .ValueGeneratedNever()
                    .HasColumnName("M_MomentoID");

                entity.Property(e => e.MDescripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("M_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.MNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("M_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Monedas>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.MMonedaId, "UQ__Monedas__14FC4B7519D2F8B8")
                    .IsUnique();

                entity.Property(e => e.MDescripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("M_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.MMonedaId).HasColumnName("M_MonedaID");
            });

            modelBuilder.Entity<MoodleKey>(entity =>
            {
                entity.HasKey(e => e.IdMoodleKey);

                entity.Property(e => e.MoodleFechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.MoodleKey1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MoodleKey");

                entity.Property(e => e.MoodleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.MoodleKey)
                    .HasForeignKey(d => d.NivelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoodleKey_Niveles");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.MoodleKey)
                    .HasForeignKey(d => d.Usuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MoodleKey_usuario");
            });

            modelBuilder.Entity<Municipios>(entity =>
            {
                entity.Property(e => e.MunicipiosId)
                    .ValueGeneratedNever()
                    .HasColumnName("Municipios_ID");

                entity.Property(e => e.MunicipioEstado).HasColumnName("Municipio_Estado");

                entity.Property(e => e.MunicipiosNombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Municipios_Nombre")
                    .IsFixedLength();

                entity.HasOne(d => d.MunicipioEstadoNavigation)
                    .WithMany(p => p.Municipios)
                    .HasForeignKey(d => d.MunicipioEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Municipio__Munic__1FEDB87C");
            });

            modelBuilder.Entity<Nacionalidades>(entity =>
            {
                entity.Property(e => e.NacionalidadesId)
                    .ValueGeneratedNever()
                    .HasColumnName("Nacionalidades_ID");

                entity.Property(e => e.NacionalidadesNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nacionalidades_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Niveles>(entity =>
            {
                entity.HasKey(e => e.NivelId)
                    .HasName("PK__Niveles__CF8BC6D04FFE64A4");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<NivelesHistorial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.NhAlumnoId).HasColumnName("NH_AlumnoID");

                entity.Property(e => e.NhAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NH_AutorizadoPor");

                entity.Property(e => e.NhFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("NH_FechaFin");

                entity.Property(e => e.NhFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("NH_FechaInicio");

                entity.Property(e => e.NhNivel)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("NH_Nivel");

                entity.HasOne(d => d.NhAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.NhAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NivelesHi__NH_Al__04AFB25B");

                entity.HasOne(d => d.NhAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.NhAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__NivelesHi__NH_Au__42ACE4D4");
            });

            modelBuilder.Entity<Noticias>(entity =>
            {
                entity.HasKey(e => e.Noticiaid);

                entity.Property(e => e.Noticiaid).HasColumnName("noticiaid");

                entity.Property(e => e.Noticiacont)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("noticiacont");

                entity.Property(e => e.Noticiadivision)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("noticiadivision");

                entity.Property(e => e.Noticiafec)
                    .HasColumnType("datetime")
                    .HasColumnName("noticiafec");

                entity.Property(e => e.Noticiafecfin)
                    .HasColumnType("date")
                    .HasColumnName("noticiafecfin");

                entity.Property(e => e.Noticiafecini)
                    .HasColumnType("date")
                    .HasColumnName("noticiafecini");

                entity.Property(e => e.Noticiafile).HasColumnName("noticiafile");

                entity.Property(e => e.Noticiafilenombre)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("noticiafilenombre");

                entity.Property(e => e.Noticiaimportante).HasColumnName("noticiaimportante");

                entity.Property(e => e.Noticiapermanente).HasColumnName("noticiapermanente");

                entity.Property(e => e.Noticiatipo).HasColumnName("noticiatipo");

                entity.Property(e => e.Noticiatipo1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("noticiatipo1");

                entity.Property(e => e.Noticiatitulo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("noticiatitulo");

                entity.Property(e => e.Noticiausu)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("noticiausu");
            });

            modelBuilder.Entity<PagoTarjeta>(entity =>
            {
                entity.HasKey(e => e.RequestTarjetasId)
                    .HasName("PK__PagoTarj__156D8010F2E88C4F");

                entity.Property(e => e.RequestTarjetasId).HasColumnName("requestTarjetasId");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Asociadot).HasColumnName("asociadot");

                entity.Property(e => e.FEstatus)
                    .HasColumnType("datetime")
                    .HasColumnName("fEstatus");

                entity.Property(e => e.RReferenciaId).HasColumnName("R_ReferenciaID");

                entity.Property(e => e.TAccountNivel).HasColumnName("tAccountNivel");

                entity.Property(e => e.TBanco)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("tBanco")
                    .IsFixedLength();

                entity.Property(e => e.TDescription)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tDescription")
                    .IsFixedLength();

                entity.Property(e => e.TMedioPago).HasColumnName("tMedioPago");

                entity.Property(e => e.TMonth).HasColumnName("tMonth");

                entity.Property(e => e.TMonto)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("tMonto");

                entity.Property(e => e.TPayerName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tPayerName")
                    .IsFixedLength();

                entity.Property(e => e.TRespuesta)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("tRespuesta");

                entity.Property(e => e.TSignature)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tSignature")
                    .IsFixedLength();

                entity.Property(e => e.TTerminacion)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("tTerminacion");

                entity.Property(e => e.TarAuthorizationCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tarAuthorizationCode")
                    .IsFixedLength();

                entity.Property(e => e.TarCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tarCode")
                    .IsFixedLength();

                entity.Property(e => e.TarEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tarEmail")
                    .IsFixedLength();

                entity.Property(e => e.TarError)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tarError")
                    .IsFixedLength();

                entity.Property(e => e.TarOperationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tarOperationDate");

                entity.Property(e => e.TarOrden)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tarOrden")
                    .IsFixedLength();

                entity.Property(e => e.TarPaymentNetworkResponseCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tarPaymentNetworkResponseCode")
                    .IsFixedLength();

                entity.Property(e => e.TarResponseCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tarResponseCode")
                    .IsFixedLength();

                entity.Property(e => e.TarResponseMessage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tarResponseMessage");

                entity.Property(e => e.TarState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tarState")
                    .IsFixedLength();

                entity.Property(e => e.TarTransaccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tarTransaccion")
                    .IsFixedLength();

                entity.Property(e => e.TarTrazabilityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tarTrazabilityCode")
                    .HasDefaultValueSql("('NULL')")
                    .IsFixedLength();

                entity.Property(e => e.TdeviceSessionId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tdeviceSessionId")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PagosRegistradosFitness>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PagosRegistradosFitness");

                entity.Property(e => e.AlMatricula)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.ApAlumnoClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AP_AlumnoClave");

                entity.Property(e => e.ApAlumnoId).HasColumnName("AP_AlumnoID");

                entity.Property(e => e.ApEstatus).HasColumnName("AP_Estatus");

                entity.Property(e => e.ApFechaBancaria)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaBancaria");

                entity.Property(e => e.ApFechaContable)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaContable");

                entity.Property(e => e.ApFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaCreacion");

                entity.Property(e => e.ApFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("AP_FechaRegistro");

                entity.Property(e => e.ApImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImportePendiente");

                entity.Property(e => e.ApImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImporteTotal");

                entity.Property(e => e.ApObservaciones)
                    .IsRequired()
                    .HasColumnName("AP_Observaciones");

                entity.Property(e => e.ApPagoId).HasColumnName("AP_PagoID");

                entity.Property(e => e.ApReferencia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AP_Referencia");

                entity.Property(e => e.ApReferenciaBancaria)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AP_ReferenciaBancaria");

                entity.Property(e => e.CbCuentaId).HasColumnName("CB_CuentaId");

                entity.Property(e => e.CbNombreCuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CB_NombreCuenta");

                entity.Property(e => e.ConDescripcion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Con_Descripcion");

                entity.Property(e => e.FpDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FP_Descripcion");

                entity.Property(e => e.MpDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MP_Descripcion");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre");

                entity.Property(e => e.RReferenciaId).HasColumnName("R_ReferenciaID");
            });

            modelBuilder.Entity<Pantalla>(entity =>
            {
                entity.HasKey(e => e.IdPantalla)
                    .HasName("PK_Tpantalla");

                entity.ToTable("pantalla");

                entity.Property(e => e.PantallaDesc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PantallaFecha).HasColumnType("datetime");

                entity.Property(e => e.PantallaNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PantallaSimbolo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PantallaUrl)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.Pantalla)
                    .HasForeignKey(d => d.ModuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tpantalla_Tmodulo");
            });

            modelBuilder.Entity<PeriodoHistorico>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PhAlumnoId).HasColumnName("PH_AlumnoID");

                entity.Property(e => e.PhAnoperiodo).HasColumnName("PH_Anoperiodo");

                entity.Property(e => e.PhAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PH_AutorizadoPor");

                entity.Property(e => e.PhFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("PH_FechaFIn");

                entity.Property(e => e.PhFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("PH_FechaInicio");

                entity.Property(e => e.PhPeriodo).HasColumnName("PH_Periodo");

                entity.HasOne(d => d.PhAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.PhAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PeriodoHi__PH_Al__10216507");

                entity.HasOne(d => d.PhAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PhAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PeriodoHi__PH_Au__3DE82FB7");
            });

            modelBuilder.Entity<Periodos>(entity =>
            {
                entity.Property(e => e.PeriodosId)
                    .ValueGeneratedNever()
                    .HasColumnName("Periodos_ID");

                entity.Property(e => e.PeriodosNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Periodos_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.PPermisoId)
                    .HasName("PK__Permisos__DDBD92F9620FD4D0");

                entity.Property(e => e.PPermisoId)
                    .ValueGeneratedNever()
                    .HasColumnName("P_PermisoID");

                entity.Property(e => e.PDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("P_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("P_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PermisosAlumnos>(entity =>
            {
                entity.HasKey(e => e.PaPermisoId)
                    .HasName("PK__Permisos__50F3E0AFD05D2015");

                entity.Property(e => e.PaPermisoId)
                    .ValueGeneratedNever()
                    .HasColumnName("PA_PermisoID");

                entity.Property(e => e.PaDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PA_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.PaNombre)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PA_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PermisosPuestos>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PpActivo).HasColumnName("PP_Activo");

                entity.Property(e => e.PpPermiso).HasColumnName("PP_Permiso");

                entity.Property(e => e.PpPuestoId).HasColumnName("PP_PuestoID");

                entity.HasOne(d => d.PpPermisoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PpPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PermisosP__PP_Pe__25A691D2");

                entity.HasOne(d => d.PpPuesto)
                    .WithMany()
                    .HasForeignKey(d => d.PpPuestoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PermisosP__PP_Pu__269AB60B");
            });

            modelBuilder.Entity<PermisosStatus>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PsActivo).HasColumnName("PS_Activo");

                entity.Property(e => e.PsPermiso).HasColumnName("PS_Permiso");

                entity.Property(e => e.PsStatusId).HasColumnName("PS_StatusID");

                entity.HasOne(d => d.PsPermisoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PsPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PermisosS__PS_Pe__278EDA44");

                entity.HasOne(d => d.PsStatus)
                    .WithMany()
                    .HasForeignKey(d => d.PsStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PermisosS__PS_St__5B78929E");
            });

            modelBuilder.Entity<PlanEstudioHistorico>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PehAlumnoId).HasColumnName("PEH_AlumnoID");

                entity.Property(e => e.PehAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PEH_AutorizadoPor");

                entity.Property(e => e.PehFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("PEH_FechaFin");

                entity.Property(e => e.PehFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("PEH_FechaInicio");

                entity.Property(e => e.PehPlanId).HasColumnName("PEH_PlanID");

                entity.HasOne(d => d.PehAlumno)
                    .WithMany()
                    .HasForeignKey(d => d.PehAlumnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanEstud__PEH_A__09746778");

                entity.HasOne(d => d.PehAutorizadoPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PehAutorizadoPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlanEstud__PEH_A__3FD07829");
            });

            modelBuilder.Entity<PlanesEstudio>(entity =>
            {
                entity.HasKey(e => e.PeId);

                entity.Property(e => e.PeId)
                    .ValueGeneratedNever()
                    .HasColumnName("PE_ID");

                entity.Property(e => e.PeAnio).HasColumnName("PE_ANIO");

                entity.Property(e => e.PeFeReg)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_FE_REG");

                entity.Property(e => e.PeIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PE_IP");

                entity.Property(e => e.PeNombre)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("PE_NOMBRE");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.PlanesEstudio)
                    .HasForeignKey(d => d.Usuid)
                    .HasConstraintName("FK_PlanesEstudio_usuario");
            });

            modelBuilder.Entity<PorcentageBecaHistoricoProspecto>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PbhpAlumnoId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PBHP_AlumnoID")
                    .IsFixedLength();

                entity.Property(e => e.PbhpBecaId).HasColumnName("PBHP_BecaID");

                entity.Property(e => e.PbhpCambioPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PBHP_CAmbioPor");

                entity.Property(e => e.PbhpFecha)
                    .HasColumnType("date")
                    .HasColumnName("PBHP_Fecha");

                entity.Property(e => e.PbhpPorcentaje).HasColumnName("PBHP_Porcentaje");

                entity.HasOne(d => d.PbhpCambioPorNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.PbhpCambioPor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Porcentag__PBHP___57A801BA");
            });

            modelBuilder.Entity<ProgramasCv>(entity =>
            {
                entity.HasKey(e => e.IdPrograma)
                    .HasName("PK_ProgramaCV");

                entity.ToTable("ProgramasCV");

                entity.Property(e => e.MMateriaId).HasColumnName("M_MateriaID");

                entity.Property(e => e.NombrePrograma)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramaRegistro).HasColumnType("datetime");

                entity.HasOne(d => d.ProgramaUserNavigation)
                    .WithMany(p => p.ProgramasCv)
                    .HasForeignKey(d => d.ProgramaUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProgramaCV_usuario");
            });

            modelBuilder.Entity<Puestos>(entity =>
            {
                entity.Property(e => e.PuestosId)
                    .ValueGeneratedNever()
                    .HasColumnName("Puestos_ID");

                entity.Property(e => e.PuestosArea).HasColumnName("Puestos_Area");

                entity.Property(e => e.PuestosDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Puestos_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.PuestosNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Puestos_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.PuestosReportaA).HasColumnName("Puestos_ReportaA");

                entity.HasOne(d => d.PuestosAreaNavigation)
                    .WithMany(p => p.Puestos)
                    .HasForeignKey(d => d.PuestosArea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Puestos__Puestos__13BCEBC1");

                entity.HasOne(d => d.PuestosReportaANavigation)
                    .WithMany(p => p.InversePuestosReportaANavigation)
                    .HasForeignKey(d => d.PuestosReportaA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Puestos__Puestos__2E3BD7D3");
            });

            modelBuilder.Entity<PuestosHistorial>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.PhAdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PH_AdminID");

                entity.Property(e => e.PhFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("PH_FechaFin ");

                entity.Property(e => e.PhFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("PH_FechaInicio");

                entity.Property(e => e.PhNivel)
                    .HasColumnType("numeric(2, 0)")
                    .HasColumnName("PH_Nivel");

                entity.Property(e => e.PhPuestoId).HasColumnName("PH_PuestoID");

                entity.Property(e => e.PhRepotaA).HasColumnName("PH_RepotaA");

                entity.Property(e => e.PhSueldo).HasColumnName("PH_Sueldo");

                entity.HasOne(d => d.PhAdmin)
                    .WithMany()
                    .HasForeignKey(d => d.PhAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PuestosHi__PH_Ad__756D6ECB");
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.GpApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APM");

                entity.Property(e => e.GpApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APP");

                entity.Property(e => e.GpBeca).HasColumnName("GP_Beca");

                entity.Property(e => e.GpBecaInscripcion).HasColumnName("GP_BecaInscripcion");

                entity.Property(e => e.GpBecaOfrecidaPor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_BecaOfrecidaPor");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpCp).HasColumnName("GP_CP");

                entity.Property(e => e.GpDescPromocion).HasColumnName("GP_DescPromocion");

                entity.Property(e => e.GpDifusion).HasColumnName("GP_Difusion");

                entity.Property(e => e.GpDireccion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("GP_Direccion");

                entity.Property(e => e.GpEdad).HasColumnName("GP_Edad");

                entity.Property(e => e.GpEscuelaPros).HasColumnName("GP_EscuelaPros");

                entity.Property(e => e.GpEstado).HasColumnName("GP_Estado");

                entity.Property(e => e.GpEstatus).HasColumnName("GP_Estatus");

                entity.Property(e => e.GpFechaFirReg)
                    .HasPrecision(3)
                    .HasColumnName("GP_FechaFirReg");

                entity.Property(e => e.GpFirmaContra).HasColumnName("GP_FirmaContra");

                entity.Property(e => e.GpImporte).HasColumnName("GP_Importe");

                entity.Property(e => e.GpModPago).HasColumnName("GP_ModPago");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpNacionalidad).HasColumnName("GP_Nacionalidad");

                entity.Property(e => e.GpNombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_Nombre");

                entity.Property(e => e.GpNumDocExtra)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_NumDocExtra");

                entity.Property(e => e.GpObservaciones)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("GP_observaciones");

                entity.Property(e => e.GpPorcentajeBeca).HasColumnName("GP_PorcentajeBeca");

                entity.Property(e => e.GpSemestre).HasColumnName("GP_Semestre");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.GpTermyCond).HasColumnName("GP_TermyCond");

                entity.Property(e => e.GpTipDocExtra).HasColumnName("GP_TipDocExtra");

                entity.Property(e => e.GpUsuValBeca).HasColumnName("GP_UsuValBeca");

                entity.Property(e => e.GpValBecaFecha)
                    .HasColumnType("date")
                    .HasColumnName("GP_ValBecaFecha");

                entity.Property(e => e.Gpmatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPMatricula");

                entity.Property(e => e.Gppfecha)
                    .HasPrecision(3)
                    .HasColumnName("GPPFecha");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.Idferia).HasColumnName("idferia");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.CarreraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Carrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Carrera");

                entity.HasOne(d => d.IdcarreraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Idcarrera)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("IDCarrera");
            });

            modelBuilder.Entity<Ravisodeudores>(entity =>
            {
                entity.HasKey(e => e.AlId)
                    .HasName("PK__RAvisode__7FB33DA00D1F6839");

                entity.ToTable("RAvisodeudores");

                entity.Property(e => e.AlId)
                    .ValueGeneratedNever()
                    .HasColumnName("AL_ID");

                entity.Property(e => e.AdEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdaMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdaPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AlMatricula)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.Carre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CARRE");

                entity.Property(e => e.Div)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rcobranza>(entity =>
            {
                entity.HasKey(e => e.Rcid)
                    .HasName("PK__RCobranz__45CAE2F1560402F7");

                entity.ToTable("RCobranza");

                entity.Property(e => e.Rcid)
                    .ValueGeneratedNever()
                    .HasColumnName("RCId");

                entity.Property(e => e.Rcfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("RCFecha");

                entity.Property(e => e.RcfechaCorte)
                    .HasColumnType("datetime")
                    .HasColumnName("RCFechaCorte");
            });

            modelBuilder.Entity<Rdeudores>(entity =>
            {
                entity.HasKey(e => e.Rd)
                    .HasName("PK__RDeudore__321537CC2A2B3BC4");

                entity.ToTable("RDeudores");

                entity.Property(e => e.Rd).HasColumnName("RD");

                entity.Property(e => e.Rdfecreg)
                    .HasColumnType("datetime")
                    .HasColumnName("RDFecreg");

                entity.Property(e => e.Rdtimefin)
                    .HasColumnType("datetime")
                    .HasColumnName("RDTimefin");

                entity.Property(e => e.Rdtimereg)
                    .HasColumnType("datetime")
                    .HasColumnName("RDTimereg")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Rdeudoresdiario>(entity =>
            {
                entity.HasKey(e => new { e.Rdid, e.Rdaluid })
                    .HasName("PK__RDeudore__458CE898C8128093");

                entity.ToTable("RDeudoresdiario");

                entity.Property(e => e.Rdid).HasColumnName("RDId");

                entity.Property(e => e.Rdaluid).HasColumnName("RDAluid");

                entity.Property(e => e.Beca)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Carrera)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Div)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rdamaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RDAMaterno");

                entity.Property(e => e.Rdapaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RDAPaterno");

                entity.Property(e => e.Rdbcid).HasColumnName("RDBcid");

                entity.Property(e => e.Rdbedesc)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("RDBedesc");

                entity.Property(e => e.Rdbeinscrip)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("RDBeinscrip");

                entity.Property(e => e.Rdbeparcialidades)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("RDBEParcialidades");

                entity.Property(e => e.Rdcarid).HasColumnName("RDCARID");

                entity.Property(e => e.Rdconceptosdesc)
                    .IsUnicode(false)
                    .HasColumnName("RDConceptosdesc");

                entity.Property(e => e.Rdconvenio).HasColumnName("RDConvenio");

                entity.Property(e => e.Rdconvfin)
                    .HasColumnType("date")
                    .HasColumnName("RDConvfin");

                entity.Property(e => e.Rdconvinicio)
                    .HasColumnType("date")
                    .HasColumnName("RDConvinicio");

                entity.Property(e => e.Rddivision).HasColumnName("RDDivision");

                entity.Property(e => e.Rdemail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RDEmail");

                entity.Property(e => e.RdemailT)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RDEmailT");

                entity.Property(e => e.Rdestatus).HasColumnName("RDEstatus");

                entity.Property(e => e.Rdgrado)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("RDGrado");

                entity.Property(e => e.Rdgrupo)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("RDGrupo");

                entity.Property(e => e.RdnoConceptos).HasColumnName("RDNoConceptos");

                entity.Property(e => e.Rdnocontrol)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RDNOControl");

                entity.Property(e => e.Rdnombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RDNombre");

                entity.Property(e => e.Rdpedindiente)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("RDPedindiente");

                entity.Property(e => e.Rdtelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("RDTelefono");

                entity.Property(e => e.Rdtutor)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("RDTutor");
            });

            modelBuilder.Entity<Referencias>(entity =>
            {
                entity.HasKey(e => e.RReferenciaId)
                    .HasName("PK__Referenc__FCFD776577C0E0F8");

                entity.Property(e => e.RReferenciaId).HasColumnName("R_ReferenciaID");

                entity.Property(e => e.RAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("R_AlumnoClave");

                entity.Property(e => e.RAlumnoId).HasColumnName("R_AlumnoID");

                entity.Property(e => e.RFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("R_FechaCreacion");

                entity.Property(e => e.RFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("R_FechaInicio");

                entity.Property(e => e.RFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("R_FechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RFechaVigencia)
                    .HasColumnType("date")
                    .HasColumnName("R_FechaVigencia");

                entity.Property(e => e.RReferencia)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("R_Referencia");

                entity.Property(e => e.RReferenciaStatus).HasColumnName("R_ReferenciaStatus");

                entity.Property(e => e.RTotalReferencia)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("R_TotalReferencia");

                entity.Property(e => e.RUsuid).HasColumnName("R_Usuid");

                entity.HasOne(d => d.RAlumno)
                    .WithMany(p => p.Referencias)
                    .HasForeignKey(d => d.RAlumnoId)
                    .HasConstraintName("FK_Referencias_Alumno");

                entity.HasOne(d => d.RReferenciaStatusNavigation)
                    .WithMany(p => p.Referencias)
                    .HasForeignKey(d => d.RReferenciaStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Referencias_EstatusList");
            });

            modelBuilder.Entity<RegistroChecador>(entity =>
            {
                entity.HasKey(e => e.RcId)
                    .HasName("PK__Registro__70918C0838D91053");

                entity.Property(e => e.RcId)
                    .ValueGeneratedNever()
                    .HasColumnName("RC_ID");

                entity.Property(e => e.RcAdminNumeroEmpleado).HasColumnName("RC_AdminNumeroEmpleado");

                entity.Property(e => e.RcFechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("RC_FechaRegistro");

                entity.Property(e => e.RcHoraRegistro).HasColumnName("RC_HoraRegistro");
            });

            modelBuilder.Entity<RegistrosCv>(entity =>
            {
                entity.HasKey(e => e.IdRegistroCv);

                entity.ToTable("RegistrosCV");

                entity.Property(e => e.IdRegistroCv).HasColumnName("Id_RegistroCV");

                entity.Property(e => e.ActivoCv).HasColumnName("ActivoCV");

                entity.Property(e => e.ApMaternoCv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AP_MaternoCV");

                entity.Property(e => e.ApPaternoCv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AP_PaternoCV");

                entity.Property(e => e.EmailCv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EmailCV");

                entity.Property(e => e.FechaActivacionCv)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaActivacionCV");

                entity.Property(e => e.FechaRegistroCv)
                    .HasColumnType("datetime")
                    .HasColumnName("FechaRegistroCV");

                entity.Property(e => e.ModalidadCv).HasColumnName("ModalidadCV");

                entity.Property(e => e.NombresCv)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NombresCV");

                entity.Property(e => e.PasswordCv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PasswordCV");

                entity.Property(e => e.TelefonoCv)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TelefonoCV");

                entity.Property(e => e.UsuarioCv)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("UsuarioCV");

                entity.HasOne(d => d.IdProgramaNavigation)
                    .WithMany(p => p.RegistrosCv)
                    .HasForeignKey(d => d.IdPrograma)
                    .HasConstraintName("FK_RegistrosCV_ProgramaCV");
            });

            modelBuilder.Entity<Reglamentos>(entity =>
            {
                entity.HasKey(e => e.Reglamentoid)
                    .HasName("tareglamento_pkey");

                entity.Property(e => e.Reglamentoid).HasColumnName("reglamentoid");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.ReglamentoText).HasColumnName("reglamentoText");

                entity.Property(e => e.Reglamentoact).HasColumnName("reglamentoact");

                entity.Property(e => e.Reglamentodoc)
                    .IsRequired()
                    .HasColumnName("reglamentodoc");

                entity.Property(e => e.Reglamentonom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("reglamentonom")
                    .IsFixedLength();

                entity.Property(e => e.Reglamentoorden).HasColumnName("reglamentoorden");

                entity.Property(e => e.Reglamentoregistro)
                    .HasColumnType("datetime")
                    .HasColumnName("reglamentoregistro");

                entity.Property(e => e.Reglamentotipo)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("reglamentotipo")
                    .IsFixedLength();

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Nivel)
                    .WithMany(p => p.Reglamentos)
                    .HasForeignKey(d => d.NivelId)
                    .HasConstraintName("FK_Reglamentos_Niveles");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Reglamentos)
                    .HasForeignKey(d => d.Usuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reglamentos_usuario");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.Property(e => e.Rolid).HasColumnName("ROLId");

                entity.Property(e => e.Rolactivo)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("ROLActivo");

                entity.Property(e => e.Roldescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLDescripcion");

                entity.Property(e => e.Rolfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ROLFecha");

                entity.Property(e => e.Rolnombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLNombre");
            });

            modelBuilder.Entity<RpayuRegistro>(entity =>
            {
                entity.ToTable("RPayuRegistro");

                entity.Property(e => e.RpayuRegistroId).HasColumnName("RPayuRegistroId");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Salones>(entity =>
            {
                entity.HasKey(e => e.SSalonId)
                    .HasName("PK__Salones__9739E02064849337");

                entity.Property(e => e.SSalonId)
                    .ValueGeneratedNever()
                    .HasColumnName("S_SalonID");

                entity.Property(e => e.SDescripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("S_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.SEdificio).HasColumnName("S_Edificio");

                entity.Property(e => e.SNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("S_Nombre")
                    .IsFixedLength();

                entity.HasOne(d => d.SEdificioNavigation)
                    .WithMany(p => p.Salones)
                    .HasForeignKey(d => d.SEdificio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salones__S_Edifi__39AD8A7F");
            });

            modelBuilder.Entity<Seguimiento>(entity =>
            {
                entity.HasKey(e => e.SeguimientosProspectoId)
                    .HasName("PK_Seguimientos");

                entity.Property(e => e.SeguimientosProspectoId).HasColumnName("Seguimientos_ProspectoID");

                entity.Property(e => e.FechaSeguimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_seguimiento");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.SeguimientoEstatus).HasColumnName("seguimiento_estatus");

                entity.Property(e => e.SeguimientosAcciones)
                    .IsUnicode(false)
                    .HasColumnName("Seguimientos_acciones");

                entity.Property(e => e.SeguimientosEcho).HasColumnName("Seguimientos_echo");

                entity.Property(e => e.SeguimientosFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Seguimientos_Fecha");

                entity.Property(e => e.SeguimientosFechaProx)
                    .HasColumnType("date")
                    .HasColumnName("Seguimientos_fecha_prox");

                entity.Property(e => e.SeguimientosObservaciones)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Seguimientos_Observaciones");

                entity.Property(e => e.SeguimientosPeriodo).HasColumnName("Seguimientos_Periodo");

                entity.Property(e => e.TsId).HasColumnName("TS_ID");

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<SolicitudPago>(entity =>
            {
                entity.HasKey(e => e.SolicitudId)
                    .HasName("PK__Solicitu__1B36B2FCEA2BC932");

                entity.Property(e => e.SolicitudId).HasColumnName("solicitudId");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("alumno");

                entity.Property(e => e.CodBarras)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionE)
                    .IsRequired()
                    .HasMaxLength(2255)
                    .IsUnicode(false);

                entity.Property(e => e.EfecCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecCode");

                entity.Property(e => e.EfecError)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("efecError");

                entity.Property(e => e.EfecOperationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("efecOperationDate");

                entity.Property(e => e.EfecOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecOrder");

                entity.Property(e => e.EfecPendingReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecPendingReason");

                entity.Property(e => e.EfecResponseCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecResponseCode");

                entity.Property(e => e.EfecState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("efecState");

                entity.Property(e => e.EfecTransaccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("efecTransaccion");

                entity.Property(e => e.EfectivoAccountNivel).HasColumnName("efectivoAccountNivel");

                entity.Property(e => e.EfectivoEmailBuyer)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("efectivoEmailBuyer");

                entity.Property(e => e.EfectivoMetodoPago).HasColumnName("efectivoMetodoPago");

                entity.Property(e => e.EfectivoMonto)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("efectivoMonto");

                entity.Property(e => e.EfectivoRespuesta)
                    .HasMaxLength(2255)
                    .IsUnicode(false)
                    .HasColumnName("efectivoRespuesta");

                entity.Property(e => e.EfectivoSignature)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("efectivoSignature");

                entity.Property(e => e.EfectrazabilityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efectrazabilityCode");

                entity.Property(e => e.ErrorRedPago)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEstatus)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEstatus");

                entity.Property(e => e.FechaExpiro).HasColumnType("datetime");

                entity.Property(e => e.RReferenciaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("R_ReferenciaID");

                entity.Property(e => e.RefPayu)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StatusHistorial>(entity =>
            {
                entity.HasKey(e => e.ShAlumnoId);

                entity.Property(e => e.ShAlumnoId).HasColumnName("SH_Alumno ID");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.PeriodosId).HasColumnName("Periodos_ID");

                entity.Property(e => e.ShAnio)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SH_Anio");

                entity.Property(e => e.ShAutorizadoPor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SH_AutorizadoPor");

                entity.Property(e => e.ShComentario)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("SH_Comentario");

                entity.Property(e => e.ShFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("SH_Fecha");

                entity.Property(e => e.ShFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("SH_FechaFIn");

                entity.Property(e => e.ShFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("SH_FechaInicio");

                entity.Property(e => e.ShHora).HasColumnName("SH_Hora");

                entity.Property(e => e.ShStatus).HasColumnName("SH_Status");
            });

            modelBuilder.Entity<StatusPago>(entity =>
            {
                entity.HasKey(e => e.SpStatusId)
                    .HasName("PK__StatusPa__94DC51FCC9166A97");

                entity.Property(e => e.SpStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("SP_StatusID");

                entity.Property(e => e.SpDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SP_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.SpNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SP_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Tbusuario>(entity =>
            {
                entity.HasKey(e => e.Idbit);

                entity.ToTable("TBusuario");

                entity.Property(e => e.Tbuaccion)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("TBUaccion");

                entity.Property(e => e.Tbufecha)
                    .HasColumnType("datetime")
                    .HasColumnName("TBUfecha");

                entity.Property(e => e.Tbuipadress)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("TBUIpadress");

                entity.Property(e => e.Tbuso)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TBUSO");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.Tbusuario)
                    .HasForeignKey(d => d.ModuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBusuario_Tmodulo");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Tbusuario)
                    .HasForeignKey(d => d.Usuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBusuario_Tusuario");
            });

            modelBuilder.Entity<Tbususesion>(entity =>
            {
                entity.HasKey(e => e.Idbusus);

                entity.ToTable("TBususesion");

                entity.Property(e => e.TbipLocalAdress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TBIpLocalAdress");

                entity.Property(e => e.Tbipaddresss)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TBIpaddresss");

                entity.Property(e => e.Tbucliente)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TBUCliente");

                entity.Property(e => e.Tbucoordenadas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TBUCoordenadas");

                entity.Property(e => e.TbufechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("TBUfechaIngreso");

                entity.Property(e => e.Tbufechaegreso)
                    .HasColumnType("datetime")
                    .HasColumnName("TBUfechaegreso");

                entity.Property(e => e.Tbuso)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TBUSO");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.HasOne(d => d.Usu)
                    .WithMany(p => p.Tbususesion)
                    .HasForeignKey(d => d.Usuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBususesion_Tusuario");
            });

            modelBuilder.Entity<TipoBajaAlumno>(entity =>
            {
                entity.HasKey(e => e.TbaBajaId)
                    .HasName("PK__TipoBaja__532304166F068A37");

                entity.Property(e => e.TbaBajaId)
                    .ValueGeneratedNever()
                    .HasColumnName("TBA_BajaID");

                entity.Property(e => e.TbaDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TBA_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TbaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TBA_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoBecas>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tipo_becas");

                entity.Property(e => e.Bcclave)
                    .HasMaxLength(50)
                    .HasColumnName("bcclave");

                entity.Property(e => e.Bcdesc)
                    .HasMaxLength(100)
                    .HasColumnName("bcdesc");

                entity.Property(e => e.Bcid)
                    .HasMaxLength(50)
                    .HasColumnName("bcid");

                entity.Property(e => e.Bctipo)
                    .HasMaxLength(50)
                    .HasColumnName("bctipo");
            });

            modelBuilder.Entity<TipoCalificaciones>(entity =>
            {
                entity.HasKey(e => e.TcTipoCalificacionId)
                    .HasName("PK__TipoCali__EA9C2942483792FC");

                entity.Property(e => e.TcTipoCalificacionId)
                    .ValueGeneratedNever()
                    .HasColumnName("TC_TipoCalificacionID");

                entity.Property(e => e.TcCalificacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TC_Calificacion")
                    .IsFixedLength();

                entity.Property(e => e.TcDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TC_Descripcion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoHorario>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.ThHorarioId, "UQ__TipoHora__4063D8E479A191B1")
                    .IsUnique();

                entity.Property(e => e.ThDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TH_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.ThHorarioId).HasColumnName("TH_HorarioID");

                entity.Property(e => e.ThNombre)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TH_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoPagoAdmin>(entity =>
            {
                entity.HasKey(e => e.TpaId)
                    .HasName("PK__TipoPago__2E73554213B7C6C8");

                entity.Property(e => e.TpaId)
                    .ValueGeneratedNever()
                    .HasColumnName("TPA_ID");

                entity.Property(e => e.TpaDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TPA_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TpaNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TPA_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoPersonas>(entity =>
            {
                entity.HasKey(e => e.TpId)
                    .HasName("PK__TipoPers__8106F224E6F16B0D");

                entity.Property(e => e.TpId)
                    .ValueGeneratedNever()
                    .HasColumnName("TP_Id");

                entity.Property(e => e.TpDescripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TP_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TpNombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("TP_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoSeguimiento>(entity =>
            {
                entity.HasKey(e => e.TsId)
                    .HasName("PK__TipoSegu__D128865AF3CF2A13");

                entity.Property(e => e.TsId).HasColumnName("TS_ID");

                entity.Property(e => e.TsDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TS_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TsNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TS_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TiposDocumentos>(entity =>
            {
                entity.HasKey(e => e.DocId);

                entity.Property(e => e.DocId).HasColumnName("Doc_ID");

                entity.Property(e => e.DocDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.DocNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.DocObligatorio).HasColumnName("Doc_Obligatorio");

                entity.Property(e => e.DocTipoPers).HasColumnName("Doc_TipoPers");

                entity.HasOne(d => d.DocTipoPersNavigation)
                    .WithMany(p => p.TiposDocumentos)
                    .HasForeignKey(d => d.DocTipoPers)
                    .HasConstraintName("FK_TiposDocumentos_TipoPersonas");

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.TiposDocumentos)
                    .HasForeignKey(d => d.ModuloId)
                    .HasConstraintName("FK_TiposDocumentos_Modulo");
            });

            modelBuilder.Entity<TiposJustificante>(entity =>
            {
                entity.HasKey(e => e.TjTipoId)
                    .HasName("PK__TiposJus__0B0EFFAC6BC2756A");

                entity.Property(e => e.TjTipoId)
                    .ValueGeneratedNever()
                    .HasColumnName("TJ_TipoID");

                entity.Property(e => e.TjDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TJ_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TjNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TJ_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Tpermisos>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);

                entity.Property(e => e.PermisoFecha).HasColumnType("datetime");

                entity.Property(e => e.Rolid).HasColumnName("ROLId");

                entity.Property(e => e.TipoPermiso).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.IdPantallaNavigation)
                    .WithMany(p => p.Tpermisos)
                    .HasForeignKey(d => d.IdPantalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tpermisos_Tpantalla");

                entity.HasOne(d => d.Modulo)
                    .WithMany(p => p.Tpermisos)
                    .HasForeignKey(d => d.ModuloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tpermisos_Tmodulo");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Tpermisos)
                    .HasForeignKey(d => d.Rolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tpermisos_Trol");
            });

            modelBuilder.Entity<Transfpayu>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.IdTran).HasColumnName("id_tran");

                entity.Property(e => e.TranCdestino)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tran_cdestino");

                entity.Property(e => e.TranCorigen)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tran_corigen");

                entity.Property(e => e.TranEstatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tran_estatus");

                entity.Property(e => e.TranFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("tran_fecha");

                entity.Property(e => e.TranMonto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("tran_monto");

                entity.Property(e => e.TranTipocuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tran_tipocuenta");

                entity.Property(e => e.TranTipotran)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tran_tipotran");

                entity.Property(e => e.TranTitular)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tran_titular");
            });

            modelBuilder.Entity<UsosFacturacion>(entity =>
            {
                entity.HasKey(e => e.UfUsoId)
                    .HasName("PK__UsosFact__D0CF0C3A409647C8");

                entity.Property(e => e.UfUsoId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("UF_UsoID")
                    .IsFixedLength();

                entity.Property(e => e.UfDescripcion)
                    .HasMaxLength(220)
                    .IsUnicode(false)
                    .HasColumnName("UF_Descripcion");

                entity.Property(e => e.UfUso)
                    .HasColumnType("decimal(30, 0)")
                    .HasColumnName("UF_Uso");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Usuid)
                    .HasName("PK_Tusuario");

                entity.ToTable("usuario");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.Property(e => e.Rolid).HasColumnName("ROLId");

                entity.Property(e => e.Usuactivo).HasColumnName("USUactivo");

                entity.Property(e => e.Usuequipo)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USUEquipo");

                entity.Property(e => e.Usuidtipo).HasColumnName("USUidtipo");

                entity.Property(e => e.Usuimage)
                    .HasColumnType("image")
                    .HasColumnName("USUImage");

                entity.Property(e => e.Usuip)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUIp");

                entity.Property(e => e.Usukey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUKey");

                entity.Property(e => e.UsulastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("USULastChange");

                entity.Property(e => e.UsumoodleL).HasColumnName("USUMoodleL");

                entity.Property(e => e.UsumoodleM).HasColumnName("USUMoodleM");

                entity.Property(e => e.UsumoodleP).HasColumnName("USUMoodleP");

                entity.Property(e => e.Usumovil)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USUMovil");

                entity.Property(e => e.Usupassword)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USUpassword");

                entity.Property(e => e.Usupid)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("USUPid");

                entity.Property(e => e.Ususession)
                    .HasColumnType("datetime")
                    .HasColumnName("USUsession");

                entity.Property(e => e.Usutipo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USUtipo")
                    .IsFixedLength();

                entity.Property(e => e.Usuusuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUusuario")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VbecasConceptos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vbecas_conceptos");

                entity.Property(e => e.BecasClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Clave");

                entity.Property(e => e.BecasId).HasColumnName("Becas_ID");

                entity.Property(e => e.ConClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Con_Clave");

                entity.Property(e => e.ConId).HasColumnName("Con_ID");

                entity.Property(e => e.LpDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LP_Descripcion");

                entity.Property(e => e.LpId).HasColumnName("LP_ID");
            });

            modelBuilder.Entity<Vbitacorabecas>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vbitacorabecas");

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.BecasClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Clave");

                entity.Property(e => e.BecasNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Nombre");

                entity.Property(e => e.Beid).HasColumnName("beid");

                entity.Property(e => e.Ccbbanio).HasColumnName("ccbbanio");

                entity.Property(e => e.Ccbbfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ccbbfecha");

                entity.Property(e => e.Ccbbid).HasColumnName("ccbbid");

                entity.Property(e => e.Ccbbinscrip).HasColumnName("ccbbinscrip");

                entity.Property(e => e.Ccbbparcial).HasColumnName("ccbbparcial");

                entity.Property(e => e.Ccbbperiodo).HasColumnName("ccbbperiodo");

                entity.Property(e => e.DescProm).HasColumnName("desc_prom");

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");

                entity.Property(e => e.Usuusuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUusuario")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VcontrolDocumento>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VControlDocumento");

                entity.Property(e => e.Addcestatus).HasColumnName("ADDCEstatus");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NombreDoc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VdatosOxxo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VDatosOxxo");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpImporte).HasColumnName("GP_Importe");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VexisteM>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VExisteM");

                entity.Property(e => e.GpProspectoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("GP_ProspectoID");

                entity.Property(e => e.Gpmatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPMatricula");
            });

            modelBuilder.Entity<Vexistecbeca>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vexistecbeca");

                entity.Property(e => e.ConClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Con_Clave");

                entity.Property(e => e.ConId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Con_ID");

                entity.Property(e => e.ConTipoConcepto).HasColumnName("Con_TipoConcepto");
            });

            modelBuilder.Entity<VhistorialEstatusAl>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VHistorialEstatusAl");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.BgdcomentarioM)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BGDComentarioM");

                entity.Property(e => e.Campanio).HasColumnName("campanio");

                entity.Property(e => e.Fecha)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Hora)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodosNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Periodos_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");

                entity.Property(e => e.Usuusuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUusuario")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vidsolicitud>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIdsolicitud");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("alumno");

                entity.Property(e => e.EfectivoSignature)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("efectivoSignature");

                entity.Property(e => e.RReferenciaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("R_ReferenciaID");

                entity.Property(e => e.SolicitudId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("solicitudId");
            });

            modelBuilder.Entity<Vidstarjeta>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIdstarjeta");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.RReferenciaId).HasColumnName("R_ReferenciaID");

                entity.Property(e => e.RequestTarjetasId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("requestTarjetasId");

                entity.Property(e => e.TarState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tarState")
                    .IsFixedLength();

                entity.Property(e => e.TarTransaccion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tarTransaccion")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ViewAlumnos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewAlumnos");

                entity.Property(e => e.AlAnoPeriodoActual).HasColumnName("AL_AnoPeriodoActual");

                entity.Property(e => e.AlApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APM");

                entity.Property(e => e.AlApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APP");

                entity.Property(e => e.AlBecaActual).HasColumnName("AL_BecaActual");

                entity.Property(e => e.AlBecaInscripcion).HasColumnName("AL_Beca_inscripcion");

                entity.Property(e => e.AlCarrera).HasColumnName("AL_Carrera");

                entity.Property(e => e.AlCicloActual).HasColumnName("AL_CicloActual");

                entity.Property(e => e.AlCorreoInst)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_CorreoInst");

                entity.Property(e => e.AlCoutaAdmin).HasColumnName("Al_CoutaAdmin");

                entity.Property(e => e.AlCurp)
                    .IsRequired()
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("AL_CURP");

                entity.Property(e => e.AlDescPromocion).HasColumnName("AL_Desc_promocion");

                entity.Property(e => e.AlDocumentos).HasColumnName("AL_Documentos");

                entity.Property(e => e.AlEsquemaPagoActual).HasColumnName("AL_EsquemaPagoActual");

                entity.Property(e => e.AlFactura).HasColumnName("AL_Factura");

                entity.Property(e => e.AlFechaIngreso)
                    .HasColumnType("date")
                    .HasColumnName("AL_FechaIngreso");

                entity.Property(e => e.AlFechaInicioNivel)
                    .HasColumnType("date")
                    .HasColumnName("AL_FechaInicioNivel");

                entity.Property(e => e.AlFechaNac)
                    .HasColumnType("date")
                    .HasColumnName("AL_FechaNac");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.AlModalidadActual).HasColumnName("AL_ModalidadActual");

                entity.Property(e => e.AlMontoDesc)
                    .HasColumnType("decimal(17, 2)")
                    .HasColumnName("Al_MontoDesc");

                entity.Property(e => e.AlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.AlPeriodoActual).HasColumnName("AL_PeriodoActual");

                entity.Property(e => e.AlSexo).HasColumnName("AL_Sexo");

                entity.Property(e => e.AlStatusActual).HasColumnName("AL_StatusActual");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.ModDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.ModNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");

                entity.Property(e => e.SlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SL_Nombre");
            });

            modelBuilder.Entity<ViewAlumnosConPagoActual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewAlumnosConPagoActual");

                entity.Property(e => e.AlAnoPeriodoActual).HasColumnName("AL_AnoPeriodoActual");

                entity.Property(e => e.AlPeriodoActual).HasColumnName("AL_PeriodoActual");

                entity.Property(e => e.CpcAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPC_AlumnoClave");

                entity.Property(e => e.CpcAño).HasColumnName("cpc_año");

                entity.Property(e => e.CpcPeriodo).HasColumnName("cpc_periodo");
            });

            modelBuilder.Entity<ViewAlumnosInre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewAlumnosINRE");

                entity.Property(e => e.AlApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APM");

                entity.Property(e => e.AlApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APP");

                entity.Property(e => e.AlBecaInscripcion).HasColumnName("AL_Beca_inscripcion");

                entity.Property(e => e.AlBecaParcialidad).HasColumnName("AL_Beca_parcialidad");

                entity.Property(e => e.AlGrupo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AL_Grupo");

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.AlNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.AlSemestre).HasColumnName("AL_Semestre");

                entity.Property(e => e.AlStatusActual).HasColumnName("AL_StatusActual");

                entity.Property(e => e.BecasClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Clave");

                entity.Property(e => e.BecasDescripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Descripcion");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CpcAño).HasColumnName("cpc_año");

                entity.Property(e => e.CpcPeriodo).HasColumnName("cpc_periodo");

                entity.Property(e => e.GaCorreoAlternativo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GA_CorreoAlternativo");

                entity.Property(e => e.GaTelefonoAlumno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GA_TelefonoAlumno");

                entity.Property(e => e.GaTelefonoTutor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GA_TelefonoTutor");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre");
            });

            modelBuilder.Entity<ViewCuentasConvenio>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewCuentasConvenio");

                entity.Property(e => e.CpcAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPC_AlumnoClave");

                entity.Property(e => e.CpcAlumnoId).HasColumnName("CPC_AlumnoID");

                entity.Property(e => e.CpcAño).HasColumnName("CPC_Año");

                entity.Property(e => e.CpcEstatus).HasColumnName("CPC_Estatus");

                entity.Property(e => e.CpcFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("CPC_FechaCreacion");

                entity.Property(e => e.CpcFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CPC_FechaRegistro");

                entity.Property(e => e.CpcId).HasColumnName("CPC_ID");

                entity.Property(e => e.CpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_ImportePendiente");

                entity.Property(e => e.CpcImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_ImporteTotal");

                entity.Property(e => e.CpcListaPrecio).HasColumnName("CPC_ListaPrecio");

                entity.Property(e => e.CpcPeriodo).HasColumnName("CPC_Periodo");

                entity.Property(e => e.CpcPrecioUnitario)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_PrecioUnitario");

                entity.Property(e => e.CpcReferenciaCuenta).HasColumnName("CPC_ReferenciaCuenta");

                entity.Property(e => e.CpcUnidad).HasColumnName("CPC_Unidad");

                entity.Property(e => e.CpcUsuid).HasColumnName("CPC_Usuid");

                entity.Property(e => e.DcpcCuentaId).HasColumnName("DCPC_CuentaId");

                entity.Property(e => e.DcpcDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_Descripcion");

                entity.Property(e => e.DcpcDocLinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_DocLinea");

                entity.Property(e => e.DcpcEstatus).HasColumnName("DCPC_Estatus");

                entity.Property(e => e.DcpcFechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("DCPC_FechaVencimiento");

                entity.Property(e => e.DcpcId).HasColumnName("DCPC_ID");

                entity.Property(e => e.DcpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImportePendiente");

                entity.Property(e => e.DcpcImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImporteTotal");
            });

            modelBuilder.Entity<ViewDeudores>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDeudores");

                entity.Property(e => e.AlApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APM");

                entity.Property(e => e.AlApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APP");

                entity.Property(e => e.AlCorreoInst)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Al_CorreoInst");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Al_Matricula");

                entity.Property(e => e.AlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.AlSemestre).HasColumnName("AL_Semestre");

                entity.Property(e => e.AlStatusActual).HasColumnName("AL_StatusActual");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.DcpcDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_Descripcion");

                entity.Property(e => e.GaCorreoAlternativo)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("GA_CorreoAlternativo")
                    .IsFixedLength();

                entity.Property(e => e.GaTelefonoTutor)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GA_TelefonoTutor")
                    .IsFixedLength();

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.Pendiente).HasColumnType("numeric(38, 2)");

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");
            });

            modelBuilder.Entity<ViewDeudoresPorAlumno>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewDeudoresPorAlumno");

                entity.Property(e => e.ConEstatus).HasColumnName("Con_Estatus");

                entity.Property(e => e.ConId).HasColumnName("Con_ID");

                entity.Property(e => e.CpcAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPC_AlumnoClave");

                entity.Property(e => e.DcpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImportePendiente");
            });

            modelBuilder.Entity<ViewPagoAlumno>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewPagoAlumno");

                entity.Property(e => e.ConClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Con_clave");

                entity.Property(e => e.ConId).HasColumnName("CON_id");

                entity.Property(e => e.CpcAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPC_AlumnoClave");

                entity.Property(e => e.CpcAño).HasColumnName("cpc_año");

                entity.Property(e => e.CpcEstatus).HasColumnName("CPC_Estatus");

                entity.Property(e => e.CpcListaPrecio).HasColumnName("CPC_ListaPrecio");

                entity.Property(e => e.CpcPeriodo).HasColumnName("cpc_periodo");

                entity.Property(e => e.DcpcDoclinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_doclinea");

                entity.Property(e => e.LpConcepto).HasColumnName("LP_Concepto");
            });

            modelBuilder.Entity<ViewPagosPendientes>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewPagosPendientes");

                entity.Property(e => e.CpcAlumnoClave)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CPC_AlumnoClave");

                entity.Property(e => e.CpcAño).HasColumnName("CPC_Año");

                entity.Property(e => e.CpcEstatus).HasColumnName("CPC_Estatus");

                entity.Property(e => e.CpcFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("CPC_FechaCreacion");

                entity.Property(e => e.CpcFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("CPC_FechaRegistro");

                entity.Property(e => e.CpcId).HasColumnName("CPC_ID");

                entity.Property(e => e.CpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_ImportePendiente");

                entity.Property(e => e.CpcImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_ImporteTotal");

                entity.Property(e => e.CpcListaPrecio).HasColumnName("CPC_ListaPrecio");

                entity.Property(e => e.CpcPeriodo).HasColumnName("CPC_Periodo");

                entity.Property(e => e.CpcPrecioUnitario)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("CPC_PrecioUnitario");

                entity.Property(e => e.CpcReferenciaCuenta).HasColumnName("CPC_ReferenciaCuenta");

                entity.Property(e => e.CpcUnidad).HasColumnName("CPC_Unidad");

                entity.Property(e => e.CpcUsuid).HasColumnName("CPC_Usuid");

                entity.Property(e => e.DcpcCuentaId).HasColumnName("DCPC_CuentaId");

                entity.Property(e => e.DcpcDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_Descripcion");

                entity.Property(e => e.DcpcDocLinea)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_DocLinea");

                entity.Property(e => e.DcpcEstatus).HasColumnName("DCPC_Estatus");

                entity.Property(e => e.DcpcFechaVencimiento)
                    .HasColumnType("date")
                    .HasColumnName("DCPC_FechaVencimiento");

                entity.Property(e => e.DcpcId).HasColumnName("DCPC_ID");

                entity.Property(e => e.DcpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImportePendiente");

                entity.Property(e => e.DcpcImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImporteTotal");

                entity.Property(e => e.SlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SL_Nombre");

                entity.Property(e => e.SlStatusId).HasColumnName("SL_StatusID");
            });

            modelBuilder.Entity<ViewPagosRegistrados>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewPagosRegistrados");

                entity.Property(e => e.AlMatricula)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.ApAlumnoClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AP_AlumnoClave");

                entity.Property(e => e.ApAlumnoId).HasColumnName("AP_AlumnoID");

                entity.Property(e => e.ApEstatus).HasColumnName("AP_Estatus");

                entity.Property(e => e.ApFechaBancaria)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaBancaria");

                entity.Property(e => e.ApFechaContable)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaContable");

                entity.Property(e => e.ApFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaCreacion");

                entity.Property(e => e.ApFechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("AP_FechaRegistro");

                entity.Property(e => e.ApImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImportePendiente");

                entity.Property(e => e.ApImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImporteTotal");

                entity.Property(e => e.ApObservaciones)
                    .IsRequired()
                    .HasColumnName("AP_Observaciones");

                entity.Property(e => e.ApPagoId).HasColumnName("AP_PagoID");

                entity.Property(e => e.ApReferencia)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AP_Referencia");

                entity.Property(e => e.ApReferenciaBancaria)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AP_ReferenciaBancaria");

                entity.Property(e => e.CbCuentaId).HasColumnName("CB_CuentaId");

                entity.Property(e => e.CbNombreCuenta)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CB_NombreCuenta");

                entity.Property(e => e.FpDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FP_Descripcion");

                entity.Property(e => e.MpDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MP_Descripcion");

                entity.Property(e => e.NivelNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.RReferenciaId).HasColumnName("R_ReferenciaID");
            });

            modelBuilder.Entity<ViewReporteConvenios>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewReporteConvenios");

                entity.Property(e => e.AlApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APM");

                entity.Property(e => e.AlApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APP");

                entity.Property(e => e.AlMatricula)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.AlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.BecasClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Clave");

                entity.Property(e => e.BecasNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Nombre");

                entity.Property(e => e.Beinscrip).HasColumnName("beinscrip");

                entity.Property(e => e.Beparcialidades).HasColumnName("beparcialidades");

                entity.Property(e => e.CarreraClave)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ConClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Con_Clave");

                entity.Property(e => e.ConEstatus).HasColumnName("Con_Estatus");

                entity.Property(e => e.ConFechaCreacion)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaCreacion");

                entity.Property(e => e.ConFechaFin)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaFin");

                entity.Property(e => e.ConFechaInicio)
                    .HasColumnType("date")
                    .HasColumnName("Con_FechaInicio");

                entity.Property(e => e.ConId).HasColumnName("CON_ID");

                entity.Property(e => e.CpcAño).HasColumnName("CPC_Año");

                entity.Property(e => e.DcpcDescripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DCPC_Descripcion");

                entity.Property(e => e.DcpcId).HasColumnName("DCPC_ID");

                entity.Property(e => e.DcpcImportePendiente)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("DCPC_ImportePendiente");

                entity.Property(e => e.NivelNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre");

                entity.Property(e => e.PeriodosNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Periodos_Nombre");

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");

                entity.Property(e => e.SlStatusId).HasColumnName("SL_StatusID");
            });

            modelBuilder.Entity<ViewReportesCrm>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewReportesCRM");

                entity.Property(e => e.BecasNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Nombre");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.EstadosNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Estados_Nombre");

                entity.Property(e => e.GpApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APM");

                entity.Property(e => e.GpApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APP");

                entity.Property(e => e.GpBeca).HasColumnName("GP_Beca");

                entity.Property(e => e.GpBecaInscripcion).HasColumnName("GP_BecaInscripcion");

                entity.Property(e => e.GpDescPromocion).HasColumnName("GP_DescPromocion");

                entity.Property(e => e.GpDifusion).HasColumnName("GP_Difusion");

                entity.Property(e => e.GpEstado).HasColumnName("GP_Estado");

                entity.Property(e => e.GpNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_Nombre");

                entity.Property(e => e.GpPorcentajeBeca).HasColumnName("GP_PorcentajeBeca");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpSemestre).HasColumnName("GP_Semestre");

                entity.Property(e => e.Gpmatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPMatricula");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.MdNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MD_Nombre");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre");

                entity.Property(e => e.Periodo)
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Promotor)
                    .IsRequired()
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<ViewRptpagosConceptos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewRPTPagosConceptos");

                entity.Property(e => e.AlGrupo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AL_Grupo")
                    .IsFixedLength();

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.AlNombre)
                    .IsRequired()
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.AlSemestre).HasColumnName("AL_Semestre");

                entity.Property(e => e.ApFechaRegistro)
                    .HasColumnType("date")
                    .HasColumnName("AP_FechaRegistro");

                entity.Property(e => e.ApImporteTotal)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("AP_ImporteTotal");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.ConClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Con_Clave");

                entity.Property(e => e.ConDescripcion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("Con_Descripcion");

                entity.Property(e => e.ConTipoConcepto).HasColumnName("Con_TipoConcepto");

                entity.Property(e => e.CpcId).HasColumnName("CPC_ID");

                entity.Property(e => e.FpClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FP_Clave");

                entity.Property(e => e.FpDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FP_Descripcion");

                entity.Property(e => e.LpId).HasColumnName("LP_ID");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VincritosCamp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIncritosCamp");

                entity.Property(e => e.Campana).HasColumnName("campana");

                entity.Property(e => e.InscritosCampana).HasColumnName("inscritosCampana");
            });

            modelBuilder.Entity<VincritosUsu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VIncritosUSU");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.InscritosUsu).HasColumnName("inscritosUSU");

                entity.Property(e => e.Promotor).HasColumnName("promotor");
            });

            modelBuilder.Entity<VpropectosIncritos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VPropectosIncritos");

                entity.Property(e => e.Campanio).HasColumnName("campanio");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Campperiodo).HasColumnName("campperiodo");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.GpApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APM");

                entity.Property(e => e.GpApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APP");

                entity.Property(e => e.GpEstatus).HasColumnName("GP_Estatus");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_Nombre");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.Gppfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GPPFecha");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.PeriodosNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Periodos_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.SlDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SL_Descripcion");
            });

            modelBuilder.Entity<VprosInscritos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VprosInscritos");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Carrera).HasMaxLength(151);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.Ferianombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ferianombre");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpEstatus).HasColumnName("GP_Estatus");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.Gpmatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPMatricula");

                entity.Property(e => e.Gppfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GPPFecha");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.Idferia).HasColumnName("idferia");

                entity.Property(e => e.ModDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Promotor)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<VprosUsu>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VProsUSU");

                entity.Property(e => e.Promotor).HasColumnName("promotor");

                entity.Property(e => e.ProspectosUsu).HasColumnName("ProspectosUSU");
            });

            modelBuilder.Entity<VprospIndividual>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VProspIndividual");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Carrera).HasMaxLength(151);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.Ferianombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ferianombre");

                entity.Property(e => e.GpBeca).HasColumnName("GP_Beca");

                entity.Property(e => e.GpBecaInscripcion).HasColumnName("GP_BecaInscripcion");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpDescPromocion).HasColumnName("GP_DescPromocion");

                entity.Property(e => e.GpEstatus).HasColumnName("GP_Estatus");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpPorcentajeBeca).HasColumnName("GP_PorcentajeBeca");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.Gppfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GPPFecha");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.Idferia).HasColumnName("idferia");

                entity.Property(e => e.ModDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Promotor)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<Vprospectos>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vprospectos");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.Carrera).HasMaxLength(151);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("estatus");

                entity.Property(e => e.Ferianombre)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ferianombre");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpEstatus).HasColumnName("GP_Estatus");

                entity.Property(e => e.GpModalidadInterez).HasColumnName("GP_ModalidadInterez");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.Gppfecha)
                    .HasColumnType("datetime")
                    .HasColumnName("GPPFecha");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Idcarrera).HasColumnName("IDCarrera");

                entity.Property(e => e.Idferia).HasColumnName("idferia");

                entity.Property(e => e.ModDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Mod_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .HasMaxLength(31)
                    .IsUnicode(false);

                entity.Property(e => e.Promotor)
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.Usuid).HasColumnName("usuid");
            });

            modelBuilder.Entity<VrepFormEspCrm>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VRepFormEspCRM");

                entity.Property(e => e.Campid).HasColumnName("campid");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.GpApm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APM");

                entity.Property(e => e.GpApp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_APP");

                entity.Property(e => e.GpBeca).HasColumnName("GP_Beca");

                entity.Property(e => e.GpBecaInscripcion).HasColumnName("GP_BecaInscripcion");

                entity.Property(e => e.GpDescPromocion).HasColumnName("GP_DescPromocion");

                entity.Property(e => e.GpDifusion).HasColumnName("GP_Difusion");

                entity.Property(e => e.GpEstado).HasColumnName("GP_Estado");

                entity.Property(e => e.GpNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GP_Nombre");

                entity.Property(e => e.GpPorcentajeBeca).HasColumnName("GP_PorcentajeBeca");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpSemestre).HasColumnName("GP_Semestre");

                entity.Property(e => e.Gpmatricula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPMatricula");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.IdCarrera).HasColumnName("idCarrera");

                entity.Property(e => e.NivelId).HasColumnName("Nivel_ID");

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.Periodo)
                    .HasMaxLength(31)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VresolutivoBeca>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VResolutivoBeca");

                entity.Property(e => e.AlApm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APM");

                entity.Property(e => e.AlApp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_APP");

                entity.Property(e => e.AlId).HasColumnName("AL_ID");

                entity.Property(e => e.AlMatricula)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("AL_Matricula");

                entity.Property(e => e.AlNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AL_Nombre");

                entity.Property(e => e.Beanio).HasColumnName("beanio");

                entity.Property(e => e.BecasClave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Clave");

                entity.Property(e => e.BecasId).HasColumnName("Becas_ID");

                entity.Property(e => e.BecasNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Becas_Nombre");

                entity.Property(e => e.Beestatus).HasColumnName("beestatus");

                entity.Property(e => e.Beid).HasColumnName("beid");

                entity.Property(e => e.Beinscrip).HasColumnName("beinscrip");

                entity.Property(e => e.Beparcialidades).HasColumnName("beparcialidades");

                entity.Property(e => e.Beperiodo).HasColumnName("beperiodo");

                entity.Property(e => e.CarreraClave).HasMaxLength(50);

                entity.Property(e => e.CarreraNombre).HasMaxLength(100);

                entity.Property(e => e.NivelDescripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.NivelNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nivel_Nombre")
                    .IsFixedLength();

                entity.Property(e => e.PeriodosId).HasColumnName("Periodos_ID");

                entity.Property(e => e.PeriodosNombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Periodos_Nombre")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VsegProgUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vseg_prog_user");

                entity.Property(e => e.AdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_ID");

                entity.Property(e => e.Carrera)
                    .HasMaxLength(151)
                    .HasColumnName("carrera");

                entity.Property(e => e.FechaSeguimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_seguimiento");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.GpporsMat)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GPPorsMat");

                entity.Property(e => e.Promotor)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasColumnName("promotor");

                entity.Property(e => e.Prospecto)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasColumnName("prospecto");

                entity.Property(e => e.SeguimientosAcciones)
                    .IsUnicode(false)
                    .HasColumnName("Seguimientos_acciones");

                entity.Property(e => e.SeguimientosEcho).HasColumnName("Seguimientos_echo");

                entity.Property(e => e.SeguimientosFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Seguimientos_Fecha");

                entity.Property(e => e.SeguimientosFechaProx)
                    .HasColumnType("date")
                    .HasColumnName("Seguimientos_fecha_prox");

                entity.Property(e => e.SeguimientosObservaciones)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Seguimientos_Observaciones");

                entity.Property(e => e.SeguimientosProspectoId).HasColumnName("Seguimientos_ProspectoID");

                entity.Property(e => e.TsDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TS_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TsId).HasColumnName("TS_ID");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.Property(e => e.Usuusuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUusuario")
                    .IsFixedLength();
            });

            modelBuilder.Entity<VsegTProgUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VsegT_prog_user");

                entity.Property(e => e.AdminId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_ID");

                entity.Property(e => e.Carrera)
                    .HasMaxLength(151)
                    .HasColumnName("carrera");

                entity.Property(e => e.FechaSeguimiento)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_seguimiento");

                entity.Property(e => e.GpCorreoElectronico)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GP_CorreoElectronico");

                entity.Property(e => e.GpProspectoId).HasColumnName("GP_ProspectoID");

                entity.Property(e => e.GpTelefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GP_Telefono");

                entity.Property(e => e.Promotor)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasColumnName("promotor");

                entity.Property(e => e.Prospecto)
                    .HasMaxLength(152)
                    .IsUnicode(false)
                    .HasColumnName("prospecto");

                entity.Property(e => e.SeguimientosAcciones)
                    .IsUnicode(false)
                    .HasColumnName("Seguimientos_acciones");

                entity.Property(e => e.SeguimientosEcho).HasColumnName("Seguimientos_echo");

                entity.Property(e => e.SeguimientosFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("Seguimientos_Fecha");

                entity.Property(e => e.SeguimientosFechaProx)
                    .HasColumnType("date")
                    .HasColumnName("Seguimientos_fecha_prox");

                entity.Property(e => e.SeguimientosObservaciones)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Seguimientos_Observaciones");

                entity.Property(e => e.TsDescripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TS_Descripcion")
                    .IsFixedLength();

                entity.Property(e => e.TsId).HasColumnName("TS_ID");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.Property(e => e.Usuusuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUusuario")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Vsolicitud>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VSolicitud");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("alumno");

                entity.Property(e => e.CodBarras)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EfecState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("efecState");

                entity.Property(e => e.EfectivoMonto)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("efectivoMonto");

                entity.Property(e => e.FechaExpiro).HasColumnType("datetime");

                entity.Property(e => e.RReferenciaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("R_ReferenciaID");

                entity.Property(e => e.SolicitudId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("solicitudId");
            });

            modelBuilder.Entity<VsolicitudPo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VSolicitudPO");

                entity.Property(e => e.Alumno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("alumno");

                entity.Property(e => e.CodBarras)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionE)
                    .IsRequired()
                    .HasMaxLength(2255)
                    .IsUnicode(false);

                entity.Property(e => e.EfecCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecCode");

                entity.Property(e => e.EfecError)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("efecError");

                entity.Property(e => e.EfecOperationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("efecOperationDate");

                entity.Property(e => e.EfecOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecOrder");

                entity.Property(e => e.EfecPendingReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecPendingReason");

                entity.Property(e => e.EfecResponseCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efecResponseCode");

                entity.Property(e => e.EfecState)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("efecState");

                entity.Property(e => e.EfecTransaccion)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("efecTransaccion");

                entity.Property(e => e.EfectivoAccountNivel).HasColumnName("efectivoAccountNivel");

                entity.Property(e => e.EfectivoEmailBuyer)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("efectivoEmailBuyer");

                entity.Property(e => e.EfectivoMetodoPago).HasColumnName("efectivoMetodoPago");

                entity.Property(e => e.EfectivoMonto)
                    .HasColumnType("decimal(13, 2)")
                    .HasColumnName("efectivoMonto");

                entity.Property(e => e.EfectivoRespuesta)
                    .HasMaxLength(2255)
                    .IsUnicode(false)
                    .HasColumnName("efectivoRespuesta");

                entity.Property(e => e.EfectivoSignature)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("efectivoSignature");

                entity.Property(e => e.EfectrazabilityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("efectrazabilityCode");

                entity.Property(e => e.ErrorRedPago)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEstatus)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaEstatus");

                entity.Property(e => e.FechaExpiro).HasColumnType("datetime");

                entity.Property(e => e.RReferenciaId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("R_ReferenciaID");

                entity.Property(e => e.RefPayu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SolicitudId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("solicitudId");
            });

            modelBuilder.Entity<Vusuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vusuario");

                entity.Property(e => e.Rolid).HasColumnName("ROLId");

                entity.Property(e => e.Tbipaddresss)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TBIpaddresss");

                entity.Property(e => e.Tbucoordenadas)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TBUCoordenadas");

                entity.Property(e => e.TbufechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("TBUfechaIngreso");

                entity.Property(e => e.Usuactivo).HasColumnName("USUactivo");

                entity.Property(e => e.Usuid).HasColumnName("usuid");

                entity.Property(e => e.Usuidtipo).HasColumnName("USUidtipo");

                entity.Property(e => e.Usuimage)
                    .HasColumnType("image")
                    .HasColumnName("USUImage");

                entity.Property(e => e.Usukey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUKey");

                entity.Property(e => e.UsulastChange)
                    .HasColumnType("datetime")
                    .HasColumnName("USULastChange");

                entity.Property(e => e.UsumoodleL).HasColumnName("USUMoodleL");

                entity.Property(e => e.UsumoodleM).HasColumnName("USUMoodleM");

                entity.Property(e => e.UsumoodleP).HasColumnName("USUMoodleP");

                entity.Property(e => e.Usumovil)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USUMovil");

                entity.Property(e => e.Usupassword)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("USUpassword");

                entity.Property(e => e.Usutipo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("USUtipo")
                    .IsFixedLength();

                entity.Property(e => e.Usuusuario)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("USUusuario")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
