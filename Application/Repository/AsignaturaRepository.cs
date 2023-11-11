
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    private readonly ApiContext _context;
    public AsignaturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }





    // Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso del grado que tiene el identificador `7`.
    public async Task<IEnumerable<Asignatura>> C5GetAsignaturasPrimerCuatrimestreTercerCurso()
    {
        var asignaturas = await _context.Asignaturas
            .Where(a => a.Cuatrimestre == 1 && a.Curso == 3 && a.IdGrado == 7)
            .ToListAsync();

        return asignaturas;
    }

    // Devuelve un listado con todas las asignaturas ofertadas en el `Grado en Ingeniería Informática (Plan 2015)`.
    public async Task<IEnumerable<Asignatura>> C7GetAsignaturasPorNombreGrado()
    {
        var asignaturas = await _context.Asignaturas
            .Where(a => a.IdGradoNavigation.NombreGrado == "Grado en Ingeniería Informática (Plan 2015)")
            .ToListAsync();

        return asignaturas;
    }

    // Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`
    public async Task<IEnumerable<object>> C9GetInfoCursoAlumno()
    {
        return await _context.AlumnoSeMatriculaAsignaturas
            .Where(am => am.IdAlumnoNavigation.Nif == "26902806M")
            .Select(am => new
            {
                NombreAsignatura = am.IdAsignaturaNavigation.NombreAsignatura,
                AnioInicio = am.IdCursoNavigation.AnioInicio,
                AnioFin = am.IdCursoNavigation.AnioFin
            })
            .ToListAsync();
    }

    // 15. Devuelve un listado con las asignaturas que no tienen un profesor asignado.
    public async Task<IEnumerable<Asignatura>> C15GetAsignaturasSinProfesor()
    {
        var asignaturasSinProfesor = await _context.Asignaturas
            .Where(a => a.IdProfesor == null)
            .ToListAsync();

        return asignaturasSinProfesor;
    }

    // 30. Devuelve un listado con las asignaturas que no tienen un profesor asignado.
    public async Task<IEnumerable<Asignatura>> C30GetAsignaturasSinProfesor()
    {
        return await _context.Asignaturas
            .Where(a => a.IdProfesor == null)
            .ToListAsync();
    }


    



    

    
}
