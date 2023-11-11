using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IDepartamento : IGenericRepository<Departamento>
{
    Task<IEnumerable<Departamento>> C10GetDepartamentosConAsignaturasEnGradoInformatica();
    Task<IEnumerable<Object>> C16GetDepartamentosConAsignaturasNoImpartidas();
    Task<IEnumerable<Object>> C19GetCantidadProfesoresPorDepartamento();
    Task<IEnumerable<Object>> C20GetTodosDepartamentosConProfesores();
    Task<IEnumerable<object>> C28GetDepartamentosSinProfesores();
    Task<IEnumerable<Departamento>> C31GetDepartamentosSinAsignaturas();
    
    
}
