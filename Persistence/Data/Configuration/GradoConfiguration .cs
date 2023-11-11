
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class GradoConfiguration  : IEntityTypeConfiguration<Grado>
    {
        public void Configure(EntityTypeBuilder<Grado> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("grado");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_grado");
            builder.Property(e => e.NombreGrado)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("nombre_grado");

            
        }

        
    }
}