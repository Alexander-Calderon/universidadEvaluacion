using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Departamento : BaseEntity
{    

    public string NombreDepartamento { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();

    public virtual ICollection<Profesor> Profesors { get; set; } = new List<Profesor>();
}
