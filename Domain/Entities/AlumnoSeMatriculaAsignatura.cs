using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class AlumnoSeMatriculaAsignatura : BaseEntity
{
    public int IdAlumno { get; set; }

    public int IdAsignatura { get; set; }

    public int IdCurso { get; set; }

    public virtual Persona IdAlumnoNavigation { get; set; }

    public virtual Asignatura IdAsignaturaNavigation { get; set; }

    public virtual CursoEscolar IdCursoNavigation { get; set; }
}
