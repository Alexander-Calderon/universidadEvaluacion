using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using API.Dtos;


namespace API.Controllers;
public class PersonaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult<List<PersonaDto>>> GetAll() {
        var personas = await _unitOfWork.Personas.GetAll();
        return _mapper.Map<List<PersonaDto>>(personas); 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Personas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<PersonaDto>(dato);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> GuardarCurso(PersonaDto param)
    {
        var dato = _mapper.Map<Persona>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Personas.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }

 
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Actualizar(PersonaDto param)
    {
        var dato = await _unitOfWork.Personas.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Personas.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonaDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Personas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Personas.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<PersonaDto>(dato);
    }



    // Consultas

    
    [HttpGet("C1GetAllAlumnosOrderedByName")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AlumnoLightDto>>> GetAllAlumnosOrderedByName()
    {
        var datos = await _unitOfWork.Personas.C1GetAllAlumnosOrderedByName();
        return _mapper.Map<List<AlumnoLightDto>>(datos);
    }

    [HttpGet("C2GetAllAlumnosWithoutPhone")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAlumnosSinTelefono()
    {
        var datos = await _unitOfWork.Personas.C2GetAllAlumnosWithoutPhone();
        return _mapper.Map<List<PersonaDto>>(datos);
    }

    
    [HttpGet("C3GetAllAlumnosBornIn1999")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAlumnosNacidosEn1999()
    {
        var datos = await _unitOfWork.Personas.C3GetAllAlumnosBornIn1999();
        return _mapper.Map<List<PersonaDto>>(datos);
    }

    
    [HttpGet("C6GetAllAlumnasMatriculadasEnInformatica")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAllAlumnasMatriculadasEnIngenieriaInformatica()
    {
        var datos = await _unitOfWork.Personas.C6GetAllAlumnasMatriculadasEnInformatica();
        return _mapper.Map<List<PersonaDto>>(datos);
    }

    
    // [HttpGet("C9GetAllAsignaturasByAlumnoQuemado")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<AsignaturaDto>>> C9GetAllAsignaturasByAlumnoQuemado()
    // {
    //     var datos = await _unitOfWork.Personas.C9GetAllAsignaturasByAlumnoQuemado();
    //     return _mapper.Map<List<AsignaturaDto>>(datos);
    // }

    
    [HttpGet("C11GetAllAlumnosMatriculadosEnCurso20182019")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> C11GetAllAlumnosMatriculadosEnCurso20182019()
    {
        var datos = await _unitOfWork.Personas.C11GetAllAlumnosMatriculadosEnCurso20182019();
        return _mapper.Map<List<PersonaDto>>(datos);
    }

    [HttpGet("C12GetProfesoresConDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C12GetProfesoresConDepartamento()
    {
        try
        {
            var profesoresConDepartamento = await _unitOfWork.Personas.C12GetProfesoresConDepartamento();
            return Ok(profesoresConDepartamento);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener los profesores con departamentos." });
        }
    }


    [HttpGet("C17GetTotalAlumnas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C17GetTotalAlumnas()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C17GetTotalAlumnas();
            return Ok(new { CantidadAlumnas = resultado });
        }
        catch (Exception)
        {            
            return StatusCode(500, new { MensajeError = "Error al obtener el total de alumnas." });
        }
    }

    [HttpGet("C18GetTotalAlumnosNacidosEn1999")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C18GetTotalAlumnosNacidosEn1999()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C18GetTotalAlumnosNacidosEn1999();
            return Ok(new { CantidadAlumnosNacidosEn1999 = resultado });
        }
        catch (Exception)
        {            
            return StatusCode(500, new { MensajeError = "Error al obtener el total de alumnos nacidos en 1999." });
        }
    }

    [HttpGet("C24GetTotalAlumnosMatriculadosPorCurso")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C24GetTotalAlumnosMatriculadosPorCurso()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C24GetTotalAlumnosMatriculadosPorCurso();
            return Ok(resultado);
        }
        catch (Exception)
        {            
            return StatusCode(500, new { MensajeError = "Error al obtener el total de alumnos matriculados por curso." });
        }
    }

    [HttpGet("C26GetAlumnoMasJoven")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C26GetAlumnoMasJoven()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C26GetAlumnoMasJoven();
            // return Ok(resultado);
            return Ok(_mapper.Map<PersonaDto>(resultado)); /* cuando fijo es solo uno y no una lista */

        }
        catch (Exception ex)
        {            
            return StatusCode(500, new { MensajeError = "Error al obtener el alumno más joven." }) + ex.Message;
        }
    }

    [HttpGet("C4GetProfesoresSinTelefonoYNifK")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonaDto>>> C4GetProfesoresSinTelefonoYNifK()
    {
        var datos = await _unitOfWork.Personas.C4GetProfesoresSinTelefonoYNifK();
        return _mapper.Map<List<PersonaDto>>(datos);
    }

    [HttpGet("C8GetProfesoresConDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ProfesorDto>>> C8GetProfesoresConDepartamento()
    {
        var datos = await _unitOfWork.Personas.C8GetProfesoresConDepartamento();
        return _mapper.Map<List<ProfesorDto>>(datos);
    }


    [HttpGet("C13GetProfesoresYDepartamentosSinAsociar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C13GetProfesoresYDepartamentosSinAsociar()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C13GetProfesoresYDepartamentosSinAsociar();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener profesores y departamentos sin asociar." });
        }
    }

    [HttpGet("C14GetProfesoresSinAsignaturas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> C14GetProfesoresSinAsignaturas()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C14GetProfesoresSinAsignaturas();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener profesores sin asignaturas." });
        }
    }

    [HttpGet("C25GetNumeroAsignaturasPorProfesor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C25GetNumeroAsignaturasPorProfesor()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C25GetNumeroAsignaturasPorProfesor();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener el número de asignaturas por profesor." });
        }
    }

    [HttpGet("C27GetProfesoresSinDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C27GetProfesoresSinDepartamento()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C27GetProfesoresSinDepartamento();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener los profesores sin departamento." });
        }
    }

    [HttpGet("C29GetProfesoresSinAsignaturasEnDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C29GetProfesoresSinAsignaturasEnDepartamento()
    {
        try
        {
            var resultado = await _unitOfWork.Personas.C29GetProfesoresSinAsignaturasEnDepartamento();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener los profesores sin asignaturas en departamento." });
    }
}










    




}