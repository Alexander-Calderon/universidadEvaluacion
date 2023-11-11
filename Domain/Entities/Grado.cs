using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Grado : BaseEntity
{
    

    public string NombreGrado { get; set; }

    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}
