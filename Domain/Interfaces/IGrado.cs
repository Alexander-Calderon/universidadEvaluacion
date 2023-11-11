using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IGrado : IGenericRepository<Grado>
{
    Task<IEnumerable<object>> C21GetTodosGradosConAsignaturas();
    Task<IEnumerable<object>> C22GetGradosConMasDe40Asignaturas();
    Task<IEnumerable<object>> C23GetSumaCreditosPorTipoAsignatura();



    
}
