using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backendC_.Models
{
    public partial class nombre_apellido_dbContext : DbContext
    {
        public nombre_apellido_dbContext()
        {
        }

        public nombre_apellido_dbContext(DbContextOptions<nombre_apellido_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Tiendum> Tienda { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activo).HasColumnName("activo");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.Dui)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DUI");

                entity.Property(e => e.IdTienda).HasColumnName("idTienda");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Tiendum>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdEmpleado).HasColumnName("idEmpleado");

                entity.Property(e => e.NombreTienda)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_tienda");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Tienda)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK__Tienda__idEmplea__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
