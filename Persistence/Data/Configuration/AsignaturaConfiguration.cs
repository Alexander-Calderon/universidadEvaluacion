using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AsignaturaConfiguration : IEntityTypeConfiguration<Asignatura>
    {
        public void Configure(EntityTypeBuilder<Asignatura> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("asignatura");

            builder.HasIndex(e => e.IdGrado, "id_grado");

            builder.HasIndex(e => e.IdProfesor, "id_profesor");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_asignatura");
            builder.Property(e => e.Creditos).HasColumnName("creditos");
            builder.Property(e => e.Cuatrimestre).HasColumnName("cuatrimestre");
            builder.Property(e => e.Curso).HasColumnName("curso");
            builder.Property(e => e.IdGrado).HasColumnName("id_grado");
            builder.Property(e => e.IdProfesor).HasColumnName("id_profesor");
            builder.Property(e => e.NombreAsignatura)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nombre_asignatura");
            builder.Property(e => e.TipoAsignatura)
                .HasColumnType("enum('básica','obligatoria','optativa')")
                .HasColumnName("tipo_asignatura");

            builder.HasOne(d => d.IdGradoNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.IdGrado)
                .HasConstraintName("asignatura_ibfk_2");

            builder.HasOne(d => d.IdProfesorNavigation).WithMany(p => p.Asignaturas)
                .HasForeignKey(d => d.IdProfesor)
                .HasConstraintName("asignatura_ibfk_1");
        }

        
    }
}