
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly ApiContext _context;
    public PersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    // C1 Devuelve un listado con el primer apellido, segundo apellido y el nombre de todos los alumnos. El listado deberá estar ordenado alfabéticamente de menor a mayor por el primer apellido, segundo apellido y nombre.
    public async Task<IEnumerable<Persona>> C1GetAllAlumnosOrderedByName()
    {
        return await _context.Set<Persona>()
            .Where(e => e.TipoPersona == "alumno")
            .OrderBy(e => e.Apellido1)
            .ThenBy(e => e.Apellido2)
            .ThenBy(e => e.Nombre)
            .ToListAsync();
    }

    // C2 Averigua el nombre y los dos apellidos de los alumnos que **no** han dado de alta su número de teléfono en la base de datos.
    public async Task<IEnumerable<Persona>> C2GetAllAlumnosWithoutPhone()
    {
        return await _context.Set<Persona>()
            .Where(e => e.TipoPersona == "alumno" && e.Telefono == null)
            .ToListAsync();
    }

    // C3 Devuelve el listado de los alumnos que nacieron en `1999`.
    public async Task<IEnumerable<Persona>> C3GetAllAlumnosBornIn1999()
    {
        return await _context.Set<Persona>()
            .Where(e => e.TipoPersona == "alumno" && e.FechaNacimiento.Value.Year == 1999)
            .ToListAsync();
    }

    // C6 Devuelve un listado con los datos de todas las **alumnas** que se han matriculado alguna vez en el `Grado en Ingeniería Informática (Plan 2015)`.
    public async Task<IEnumerable<Persona>> C6GetAllAlumnasMatriculadasEnInformatica()
    {
        return await _context.Personas
        .Where(p => p.TipoPersona == "alumno" && p.Genero == "M")
        .Where(p => p.AlumnoSeMatriculaAsignaturas
            .Any(matricula => matricula.IdAsignaturaNavigation.IdGradoNavigation.NombreGrado == "Grado en Ingeniería Informática (Plan 2015)"))
        .ToListAsync();


    }

    // C9 Devuelve un listado con el nombre de las asignaturas, año de inicio y año de fin del curso escolar del alumno con nif `26902806M`.
    // public async Task<IEnumerable<Asignatura>> C9GetAllAsignaturasByAlumnoQuemado()
    // {
    //     return await _context.Asignaturas
    //         .Where(a => a.AlumnoSeMatriculaAsignaturas
    //             .Any(matricula => matricula.IdAlumnoNavigation.Dni == "26902806M"))
    //         .ToListAsync();
    // }

    // C11 Devuelve un listado con todos los alumnos que se han matriculado en alguna asignatura durante el curso escolar 2018/2019.
    public async Task<IEnumerable<Persona>> C11GetAllAlumnosMatriculadosEnCurso20182019()
    {
        var curso20182019 = await _context.CursosEscolares
            .SingleOrDefaultAsync(c => c.AnioInicio == 2018 && c.AnioFin == 2019);

        if (curso20182019 == null)
        {
            // Manejar el caso en que no se encuentre el curso 2018/2019
            return Enumerable.Empty<Persona>();
        }

        var alumnosMatriculados = await _context.AlumnoSeMatriculaAsignaturas
            .Where(am => am.IdCurso == curso20182019.Id)
            .Select(am => am.IdAlumnoNavigation)
            .Distinct()
            .ToListAsync();

        return alumnosMatriculados;
    }

    // C17 Devuelve el número total de **alumnas** que hay.
    public async Task<int> C17GetTotalAlumnas()
    {
        return await _context.Personas
            .Where(p => p.TipoPersona == "alumno" && p.Genero == "M")
            .CountAsync();
        

        
    }

    // C18 Calcula cuántos alumnos nacieron en `1999`
    public async Task<int> C18GetTotalAlumnosNacidosEn1999()
    {
        return await _context.Personas
            .Where(p => p.TipoPersona == "alumno" && p.FechaNacimiento.Value.Year == 1999)
            .CountAsync();
    }

    // C24 Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados
    public async Task<IEnumerable<object>> C24GetTotalAlumnosMatriculadosPorCurso()
    {
        return await _context.CursosEscolares
            .Select(c => new
            {
                AnioInicio = c.AnioInicio,
                NumeroAlumnosMatriculados = c.AlumnoSeMatriculaAsignaturas.Count()
            })
            .ToListAsync();
    }

    // C26 Devuelve todos los datos del alumno más joven
    public async Task<Persona> C26GetAlumnoMasJoven()
    {
        return await _context.Personas
        .Where(p => p.TipoPersona == "alumno" && p.FechaNacimiento != null)
        .OrderByDescending(p => p.FechaNacimiento)
        .FirstOrDefaultAsync();


    }


    // C4 Devuelve el listado de `profesores` que **no** han dado de alta su número de teléfono en la base de datos y además su nif termina en `K`.
    public async Task<IEnumerable<Persona>> C4GetProfesoresSinTelefonoYNifK()
    {
        var profesoresSinTelefonoYNifK = await _context.Personas
            .Where(p => p.TipoPersona == "profesor" && string.IsNullOrEmpty(p.Telefono) && p.Dni.EndsWith("K"))
            .ToListAsync();

        return profesoresSinTelefonoYNifK;
    }


    // C8 Devuelve un listado de los `profesores` junto con el nombre del `departamento` al que están vinculados. El listado debe devolver cuatro columnas, `primer apellido, segundo apellido, nombre y nombre del departamento.` El resultado estará ordenado alfabéticamente de menor a mayor por los `apellidos y el nombre.`
    public async Task<IEnumerable<Profesor>> C8GetProfesoresConDepartamento()
    {
        return await _context.Profesores
            .Include(p => p.IdDepartamentoNavigation)
            .OrderBy(p => p.IdProfesorNavigation.Apellido1)
            .ThenBy(p => p.IdProfesorNavigation.Apellido2)
            .ThenBy(p => p.IdProfesorNavigation.Nombre)
            .ToListAsync();
    }



    





    
    




    
}
