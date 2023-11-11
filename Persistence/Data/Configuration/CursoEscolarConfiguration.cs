using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
    {
        public void Configure(EntityTypeBuilder<CursoEscolar> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("curso_escolar");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_curso");
            builder.Property(e => e.AnioFin)
                .HasColumnType("year")
                .HasColumnName("anio_fin");
            builder.Property(e => e.AnioInicio)
                .HasColumnType("year")
                .HasColumnName("anio_inicio");

            
        }

        
    }
}