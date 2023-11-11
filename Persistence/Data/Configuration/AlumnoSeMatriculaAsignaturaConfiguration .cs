using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class AlumnoSeMatriculaAsignaturaConfiguration : IEntityTypeConfiguration<AlumnoSeMatriculaAsignatura>
    {
        public void Configure(EntityTypeBuilder<AlumnoSeMatriculaAsignatura> builder)
        {
            builder.HasKey(e => new { e.IdAlumno, e.IdAsignatura, e.IdCurso }).HasName("PRIMARY");

            builder.ToTable("alumno_se_matricula_asignatura");

            builder.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            builder.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            builder.Property(e => e.IdCurso).HasColumnName("id_curso");

            builder.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnoSeMatriculaAsignaturas)
                .HasForeignKey(d => d.IdAlumno)
                .HasConstraintName("alumnosematriculaasignaturas_ibfk_1");

            builder.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.AlumnoSeMatriculaAsignaturas)
                .HasForeignKey(d => d.IdAsignatura)
                .HasConstraintName("alumnosematriculaasignaturas_ibfk_2");
            
            builder.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AlumnoSeMatriculaAsignaturas)
                .HasForeignKey(d => d.IdCurso)
                .HasConstraintName("alumnosematriculaasignaturas_ibfk_3");




            // ==

            // builder.HasKey(e => e.Id).HasName("PRIMARY");

            // builder.ToTable("alumno_se_matricula_asignatura");

            // builder.HasIndex(e => e.IdAlumno, "id_alumno");

            // builder.HasIndex(e => e.IdAsignatura, "id_asignatura");

            // builder.HasIndex(e => e.IdCurso, "id_curso");

            // builder.Property(e => e.Id).HasColumnName("id");
            // builder.Property(e => e.IdAlumno).HasColumnName("id_alumno");
            // builder.Property(e => e.IdAsignatura).HasColumnName("id_asignatura");
            // builder.Property(e => e.IdCurso).HasColumnName("id_curso");

            // builder.HasOne(d => d.IdAlumnoNavigation).WithMany(p => p.AlumnoSeMatriculaAsignaturas)
            //     .HasForeignKey(d => d.IdAlumno)
            //     .HasConstraintName("alumno_se_matricula_asignatura_ibfk_1");

            // builder.HasOne(d => d.IdAsignaturaNavigation).WithMany(p => p.AlumnoSeMatriculaAsignaturas)
            //     .HasForeignKey(d => d.IdAsignatura)
            //     .HasConstraintName("alumno_se_matricula_asignatura_ibfk_2");

            // builder.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AlumnoSeMatriculaAsignaturas)
            //     .HasForeignKey(d => d.IdCurso)
            //     .HasConstraintName("alumno_se_matricula_asignatura_ibfk_3");
            
            
        }

            

        
    }
}