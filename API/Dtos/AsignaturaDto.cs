using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class AsignaturaDto
{
    public int Id {get; set;}
    public string Nombre {get; set;}
    public float Creditos {get; set;}
    public Tipo Tipos {get; set;}
    public int Curso {get; set;}
    public int Cuatrimestre {get; set;}
    public int? IdProfesorFk {get; set;}
    public string Profesor {get; set;}
}

/*  */
public enum Tipo {
        básica,
        Obligatoria, 
        Optativa
    }