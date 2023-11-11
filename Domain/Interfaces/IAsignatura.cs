using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IAsignatura : IGenericRepository<Asignatura>
{
    
    Task<IEnumerable<Asignatura>> C5GetAsignaturasPrimerCuatrimestreTercerCurso();
    Task<IEnumerable<Asignatura>> C7GetAsignaturasPorNombreGrado();
    Task<IEnumerable<object>> C9GetInfoCursoAlumno();
    Task<IEnumerable<Asignatura>> C15GetAsignaturasSinProfesor();
    Task<IEnumerable<Asignatura>> C30GetAsignaturasSinProfesor();

    
    
    

}
