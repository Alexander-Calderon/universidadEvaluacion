using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Asignatura : BaseEntity
{    

    public string NombreAsignatura { get; set; }

    public float? Creditos { get; set; }

    public string TipoAsignatura { get; set; }

    public int? IdGrado { get; set; }

    public int? Curso { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdProfesor { get; set; }

    public virtual ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; } = new List<AlumnoSeMatriculaAsignatura>();

    public virtual Departamento IdDepartamentoNavigation { get; set; }

    public virtual Grado IdGradoNavigation { get; set; }

    public virtual Profesor IdProfesorNavigation { get; set; }
}
