using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CursoEscolar : BaseEntity
{    

    public int AnioInicio { get; set; }

    public int AnioFin { get; set; }

    public virtual ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; } = new List<AlumnoSeMatriculaAsignatura>();
}
