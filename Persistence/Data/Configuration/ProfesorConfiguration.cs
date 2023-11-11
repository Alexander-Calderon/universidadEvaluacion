
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
    {
        public void Configure(EntityTypeBuilder<Profesor> builder)
        {

            builder.HasKey(e => e.IdProfesor).HasName("PRIMARY");

            builder.ToTable("profesor");

            builder.HasIndex(e => e.IdDepartamento, "id_departamento");

            builder.Property(e => e.IdProfesor)
                .ValueGeneratedNever()
                .HasColumnName("id_profesor");
            builder.Property(e => e.IdDepartamento).HasColumnName("id_departamento");



            builder.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Profesores)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("profesor_ibfk_2");

            builder.HasOne(d => d.IdProfesorNavigation).WithOne(p => p.Profesor)
                .HasForeignKey<Profesor>(d => d.IdProfesor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("profesor_ibfk_1");

            
        }

        
    }
}