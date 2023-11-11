using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class AsignaturaDto
{
    public int Id {get; set;}
    public string NombreAsignatura {get; set;}
    public float Creditos {get; set;}
    // public Tipo TipoAsignatura {get; set;}
    public string TipoAsignatura { get; set; }

    public sbyte? Curso { get; set; }

    public sbyte? Cuatrimestre { get; set; }

    public int? IdProfesor { get; set; }

    // public ProfesorDto Profesor { get; set; }

    public int? IdGrado { get; set; }
}

/*  */
public enum Tipo {
    básica,
    Obligatoria, 
    Optativa
}




            

            

            

            