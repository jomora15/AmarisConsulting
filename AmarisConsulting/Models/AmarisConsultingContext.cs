using Microsoft.EntityFrameworkCore;

namespace AmarisConsulting.Models
{
    public partial class AmarisConsultingContext : DbContext
    {
        public AmarisConsultingContext()
        { }

        public AmarisConsultingContext(DbContextOptions<AmarisConsultingContext> options) : base(options)
        { }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<EstadoTurno> EstadoTurnos { get; set; } = null!;
        public virtual DbSet<Sucursal> Sucursales { get; set; } = null!;
        public virtual DbSet<Turno> Turnos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.Apellidos).HasMaxLength(50);

                entity.Property(e => e.Nombres).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(10);
            });

            modelBuilder.Entity<EstadoTurno>(entity =>
            {
                entity.HasKey(e => e.IdEstado);

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.IdSucursal);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(10);
            });

            modelBuilder.Entity<Turno>(entity =>
            {
                entity.HasKey(e => e.IdTurno);

                entity.Property(e => e.FechaHora)
                    .HasColumnType("dateTime");

                entity.HasOne(d => d.Clientes)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turnos_Clientes");

                entity.HasOne(d => d.EstadosTurno)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turnos_EstadoTurnos");

                entity.HasOne(d => d.Sucursales)
                    .WithMany(p => p.Turnos)
                    .HasForeignKey(d => d.IdSucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turnos_Sucursales");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Clave).HasMaxLength(100);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .HasColumnName("Usuario");

                entity.HasOne(d => d.Clientes)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Clientes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
