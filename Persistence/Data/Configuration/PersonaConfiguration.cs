
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class PersonaConfiguration  : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {

            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persona");

            builder.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id_persona");
            builder.Property(e => e.Apellido1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido1");
            builder.Property(e => e.Apellido2)
                .HasMaxLength(50)
                .HasColumnName("apellido2");
            builder.Property(e => e.Ciudad)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("ciudad");
            builder.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            builder.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            builder.Property(e => e.Genero)
                .HasColumnType("enum('H','M')")
                .HasColumnName("genero");
            builder.Property(e => e.Nif)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("nif");
            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre");
            builder.Property(e => e.Telefono)
                .HasMaxLength(15)
                .HasColumnName("telefono");
            builder.Property(e => e.TipoPersona)
                .IsRequired()
                .HasColumnType("enum('alumno','profesor')")
                .HasColumnName("tipo_persona");

            
        }

        
    }
}