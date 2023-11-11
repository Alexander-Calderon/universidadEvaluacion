using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persona : BaseEntity
{
    

    public string Dni { get; set; }

    public string Nombre { get; set; }

    public string Apellido1 { get; set; }

    public string Apellido2 { get; set; }

    public string Ciudad { get; set; }

    public string Direccion { get; set; }

    public string Telefono { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string Genero { get; set; }

    public string TipoPersona { get; set; }

    public virtual ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; } = new List<AlumnoSeMatriculaAsignatura>();

    public virtual Profesor Profesor { get; set; }
}
