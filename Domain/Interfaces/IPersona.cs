using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;
public interface IPersona : IGenericRepository<Persona>
{
    Task<IEnumerable<Persona>> C1GetAllAlumnosOrderedByName();
    Task<IEnumerable<Persona>> C2GetAllAlumnosWithoutPhone();
    Task<IEnumerable<Persona>> C3GetAllAlumnosBornIn1999();
    Task<IEnumerable<Persona>> C4GetProfesoresSinTelefonoYNifK();
    Task<IEnumerable<Persona>> C6GetAllAlumnasMatriculadasEnInformatica();
    // Task<IEnumerable<Persona>> C9GetAllAsignaturasByAlumnoQuemado();
    Task<IEnumerable<Profesor>> C8GetProfesoresConDepartamento();

    Task<IEnumerable<Persona>> C11GetAllAlumnosMatriculadosEnCurso20182019();
    Task<int> C17GetTotalAlumnas();
    Task<int> C18GetTotalAlumnosNacidosEn1999();
    Task<IEnumerable<object>> C24GetTotalAlumnosMatriculadosPorCurso();
    Task<Persona> C26GetAlumnoMasJoven();

    Task<IEnumerable<object>> C12GetProfesoresConDepartamento();
    Task<IEnumerable<object>> C13GetProfesoresYDepartamentosSinAsociar();
    Task<IEnumerable<Persona>> C14GetProfesoresSinAsignaturas();
    Task<IEnumerable<Object>> C25GetNumeroAsignaturasPorProfesor();
    Task<IEnumerable<Object>> C27GetProfesoresSinDepartamento();
    Task<IEnumerable<object>> C29GetProfesoresSinAsignaturasEnDepartamento();

    

    

    


    
    


    

    

    

    

    
}
