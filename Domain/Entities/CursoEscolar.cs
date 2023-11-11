using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class CursoEscolar : BaseEntity
{    

    
    public short AnioInicio { get; set; }

    public short AnioFin { get; set; }

    public virtual ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; } = new List<AlumnoSeMatriculaAsignatura>();
}
