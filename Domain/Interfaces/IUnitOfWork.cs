using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interface;

namespace Domain.Interface;
public interface IUnitOfWork
{
    IAsignatura Asignaturas {get;}
    ICursoEscolar CursosEscolares {get;}
    IDepartamento Departamentos {get;}
    IGrado Grados {get;}
    IPersona Personas {get;}
    IProfesor Profesores {get;}
    Task<int> SaveAsync();
}
