using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("departamento");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_departamento");
            builder.Property(e => e.NombreDepartamento)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("nombre_departamento");

            
        }

        
    }
}