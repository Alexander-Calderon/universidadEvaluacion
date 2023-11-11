using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Asignatura : BaseEntity
{

    public string NombreAsignatura { get; set; }

    public float? Creditos { get; set; }


    // public enum ETipoAsignatura {
    //     básica,
    //     Obligatoria,
    //     Optativa
    // }


    // public ETipoAsignatura TipoAsignatura { get; set; }
    public string TipoAsignatura { get; set; }

    public sbyte? Curso { get; set; }

    public sbyte? Cuatrimestre { get; set; }

    public int? IdProfesor { get; set; }

    public int? IdGrado { get; set; }

    public virtual ICollection<AlumnoSeMatriculaAsignatura> AlumnoSeMatriculaAsignaturas { get; set; } = new List<AlumnoSeMatriculaAsignatura>();

    public virtual Profesor IdProfesorNavigation { get; set; }
    
    public virtual Grado IdGradoNavigation { get; set; }
}
