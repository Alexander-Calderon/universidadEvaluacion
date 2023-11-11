
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly ApiContext _context;
    public DepartamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }




    // Devuelve un listado con el nombre de todos los departamentos que tienen profesores que imparten alguna asignatura en el `Grado en Ingeniería Informática (Plan 2015)`
    public async Task<IEnumerable<Departamento>> C10GetDepartamentosConAsignaturasEnGradoInformatica()
    {
        return await _context.Departamentos
            .Where(d => d.Profesores.Any(p => p.Asignaturas.Any(a => a.IdGradoNavigation.NombreGrado == "Grado en Ingeniería Informática (Plan 2015)")))
            .ToListAsync();
    }

    // C16 Devuelve un listado con todos los departamentos que tienen alguna asignatura que no se haya impartido en ningún curso escolar.
    public async Task<IEnumerable<object>> C16GetDepartamentosConAsignaturasNoImpartidas()
    {
        var departamentosConAsignaturasNoImpartidas = await _context.Departamentos
            .Where(d => d.Profesores.Any(p => p.Asignaturas.Any(a => a.AlumnoSeMatriculaAsignaturas.Count() == 0)))
            .Select(d => new
            {
                NombreDepartamento = d.NombreDepartamento,
                AsignaturasNoImpartidas = d.Profesores
                    .SelectMany(p => p.Asignaturas.Where(a => a.AlumnoSeMatriculaAsignaturas.Count() == 0))
                    .Select(a => a.NombreAsignatura)
            })
            .ToListAsync();

        return departamentosConAsignaturasNoImpartidas;
    }

    // C19 Calcula cuántos profesores hay en cada departamento.
    public async Task<IEnumerable<object>> C19GetCantidadProfesoresPorDepartamento()
    {
        var cantidadProfesoresPorDepartamento = await _context.Departamentos
            .Where(d => d.Profesores.Any())
            .Select(d => new
            {
                NombreDepartamento = d.NombreDepartamento,
                CantidadProfesores = d.Profesores.Count()
            })
            .OrderByDescending(d => d.CantidadProfesores)
            .ToListAsync();

        return cantidadProfesoresPorDepartamento;
    }

    // C20 Devuelve un listado con todos los departamentos y el número de profesores en cada uno.
    public async Task<IEnumerable<object>> C20GetTodosDepartamentosConProfesores()
    {
        var todosDepartamentosConProfesores = await _context.Departamentos
            .Select(d => new
            {
                NombreDepartamento = d.NombreDepartamento,
                CantidadProfesores = d.Profesores.Count()
            })
            .ToListAsync();

        return todosDepartamentosConProfesores;
    }

    // 28. Devuelve un listado con los departamentos que no tienen profesores asociados
    public async Task<IEnumerable<object>> C28GetDepartamentosSinProfesores()
    {
        return await _context.Departamentos
            .Where(d => d.Profesores.Count == 0)
            .Select(d => new
            {
                Id = d.Id,
                Nombre = d.NombreDepartamento
            })
            .ToListAsync();
    }

    // 31. Devuelve un listado con todos los departamentos que no han impartido asignaturas en ningún curso escolar.
    public async Task<IEnumerable<Departamento>> C31GetDepartamentosSinAsignaturas()
    {
        return await _context.Departamentos
            .Where(d => !d.Profesores.Any(p => p.Asignaturas.Any()))
            .ToListAsync();
    }




    
}
