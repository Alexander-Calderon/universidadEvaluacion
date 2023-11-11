using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Departamento : BaseEntity
{    

    public string NombreDepartamento { get; set; }

    public virtual ICollection<Profesor> Profesores { get; set; } = new List<Profesor>();
    
}
