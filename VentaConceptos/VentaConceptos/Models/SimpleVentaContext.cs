using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VentaConceptos.Models
{
    public partial class SimpleVentaContext : DbContext
    {
        public SimpleVentaContext()
        {
        }

        public SimpleVentaContext(DbContextOptions<SimpleVentaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TConceptos> TConceptos { get; set; }
        public virtual DbSet<TVenta> TVenta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=SimpleVenta;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TConceptos>(entity =>
            {
                entity.ToTable("tConceptos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.IdVenta).HasColumnName("idVenta");

                entity.Property(e => e.Importe)
                    .HasColumnName("importe")
                    .HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnName("precioUnitario")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.TConceptos)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tConceptos_tVenta");
            });

            modelBuilder.Entity<TVenta>(entity =>
            {
                entity.ToTable("tVenta");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasColumnName("nombreCliente")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
