
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly ApiContext _context;
    public GradoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }


    // C21 Devuelve un listado con el nombre de todos los grados y el número de asignaturas en cada uno.
    public async Task<IEnumerable<object>> C21GetTodosGradosConAsignaturas()
    {

        
        var todosGradosConAsignaturas = await _context.Grados
            .Select(g => new
            {
                NombreGrado = g.NombreGrado,
                CantidadAsignaturas = g.Asignaturas.Count()
            })
            .ToListAsync();

        return todosGradosConAsignaturas.OrderByDescending(g => g.CantidadAsignaturas);
    }


    // 22. Devuelve un listado con el nombre de todos los grados existentes en la base de datos y el número de asignaturas que tiene cada uno, de los grados que tengan más de `40` asignaturas asociadas.
    public async Task<IEnumerable<object>> C22GetGradosConMasDe40Asignaturas()
    {
        var gradosConMasDe40Asignaturas = await _context.Grados
            .Where(g => g.Asignaturas.Count > 40)
            .Select(g => new
            {
                NombreGrado = g.NombreGrado,
                CantidadAsignaturas = g.Asignaturas.Count
            })
            .ToListAsync();

        return gradosConMasDe40Asignaturas.OrderByDescending(g => g.CantidadAsignaturas);
    }

    public async Task<IEnumerable<object>> C23GetSumaCreditosPorTipoAsignatura()
    {
        return await _context.Grados
            .SelectMany(g => g.Asignaturas, (g, a) => new { Grado = g, Asignatura = a })
            .GroupBy(ga => new { ga.Grado.NombreGrado, ga.Asignatura.TipoAsignatura })
            .Select(group => new
            {
                NombreGrado = group.Key.NombreGrado,
                TipoAsignatura = group.Key.TipoAsignatura,
                SumaCreditos = group.Sum(ga => ga.Asignatura.Creditos)
            })
            .OrderByDescending(result => result.SumaCreditos)
            .ToListAsync();

    }




}
