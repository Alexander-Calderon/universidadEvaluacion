using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Profesor
{    

    public int IdProfesor { get; set; }

    public int? IdDepartamento { get; set; }

    
    public virtual Persona IdProfesorNavigation { get; set; }
    
    public virtual Departamento IdDepartamentoNavigation { get; set; }
    public virtual Persona IdPersonaNavigation { get; set; }
    
    public virtual ICollection<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
}
