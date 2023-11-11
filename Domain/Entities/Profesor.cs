using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Profesor : BaseEntity
{    

    public int? IdDepartamento { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

    public virtual Departamento IdDepartamentoNavigation { get; set; }

    public virtual Persona IdProfesorNavigation { get; set; }
}
