using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using API.Dtos;


namespace API.Controllers;
public class AsignaturaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public AsignaturaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult<List<AsignaturaDto>>> GetAll() {
        var asignaturas = await _unitOfWork.Asignaturas.GetAll();
        return _mapper.Map<List<AsignaturaDto>>(asignaturas); 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Asignaturas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<AsignaturaDto>(dato);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> GuardarCurso(AsignaturaDto param)
    {
        var dato = _mapper.Map<Asignatura>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Asignaturas.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }

 
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> Actualizar(AsignaturaDto param)
    {
        var dato = await _unitOfWork.Asignaturas.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Asignaturas.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AsignaturaDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Asignaturas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Asignaturas.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<AsignaturaDto>(dato);
    }



    // Consultas
    
    [HttpGet("C5GetAsignaturasPrimerCuatrimestreTercerCurso")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AsignaturaDto>>> C5GetAsignaturasPrimerCuatrimestreTercerCurso()
    {
        var asignaturas = await _unitOfWork.Asignaturas.C5GetAsignaturasPrimerCuatrimestreTercerCurso();
        return _mapper.Map<List<AsignaturaDto>>(asignaturas);
    }

    [HttpGet("C7GetAsignaturasPorNombreGrado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Asignatura>>> C7GetAsignaturasPorNombreGrado()
    {
        try
        {
            var asignaturas = await _unitOfWork.Asignaturas.C7GetAsignaturasPorNombreGrado();
            return Ok(asignaturas);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener las asignaturas por nombre de grado." });
        }
    }



    [HttpGet("C9GetInfoCursoAlumno")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C9GetInfoCursoAlumno()
    {        
        try
        {
            var infoCurso = await _unitOfWork.Asignaturas.C9GetInfoCursoAlumno();
            return Ok(infoCurso);
        }
        catch (Exception)
        {            
            return StatusCode(500, new { MensajeError = "Error al obtener la información del curso para el alumno." });
        }
    }



    [HttpGet("C15GetAsignaturasSinProfesor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Asignatura>>> C15GetAsignaturasSinProfesor()
    {
        try
        {
            var resultado = await _unitOfWork.Asignaturas.C15GetAsignaturasSinProfesor();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener asignaturas sin profesor asignado." });
        }
    }

    [HttpGet("C30GetAsignaturasSinProfesor")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Asignatura>>> C30GetAsignaturasSinProfesor()
    {
        try
        {
            var resultado = await _unitOfWork.Asignaturas.C30GetAsignaturasSinProfesor();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener las asignaturas sin profesor." });
        }
    }



    




    


}