using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using API.Dtos;


namespace API.Controllers;
public class DepartamentoController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult<List<DepartamentoDto>>> GetAll() {
        var departamentos = await _unitOfWork.Departamentos.GetAll();
        return _mapper.Map<List<DepartamentoDto>>(departamentos); 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Departamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<DepartamentoDto>(dato);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> GuardarCurso(DepartamentoDto param)
    {
        var dato = _mapper.Map<Departamento>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }

 
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Actualizar(DepartamentoDto param)
    {
        var dato = await _unitOfWork.Departamentos.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Departamentos.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Departamentos.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<DepartamentoDto>(dato);
    }



    // Consultas

    [HttpGet("C10GetDepartamentosConAsignaturasEnGradoInformatica")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> C10GetDepartamentosConAsignaturasEnGradoInformatica()
    {
        try
        {
            var departamentos = await _unitOfWork.Departamentos.C10GetDepartamentosConAsignaturasEnGradoInformatica();            
            return Ok( _mapper.Map<List<DepartamentoDto>>(departamentos) );
        }
        catch (Exception)
        {            
            return StatusCode(500, new { MensajeError = "Error al obtener los departamentos con asignaturas en el Grado de Ingeniería Informática." });
        }
    }


    [HttpGet("C16GetDepartamentosConAsignaturasNoImpartidas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C16GetDepartamentosConAsignaturasNoImpartidas()
    {
        try
        {
            var resultado = await _unitOfWork.Departamentos.C16GetDepartamentosConAsignaturasNoImpartidas();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener departamentos con asignaturas no impartidas." });
        }
    }


    [HttpGet("C19GetCantidadProfesoresPorDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C19GetCantidadProfesoresPorDepartamento()
    {
        try
        {
            var resultado = await _unitOfWork.Departamentos.C19GetCantidadProfesoresPorDepartamento();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al calcular la cantidad de profesores por departamento." });
        }
    }


    [HttpGet("C20GetTodosDepartamentosConProfesores")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C20GetTodosDepartamentosConProfesores()
    {
        try
        {
            var resultado = await _unitOfWork.Departamentos.C20GetTodosDepartamentosConProfesores();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener la información de los departamentos con profesores." });
        }
    }


    [HttpGet("C28GetDepartamentosSinProfesores")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> C28GetDepartamentosSinProfesores()
    {
        try
        {
            var resultado = await _unitOfWork.Departamentos.C28GetDepartamentosSinProfesores();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener los departamentos sin profesores." });
        }
    }

    [HttpGet("C31GetDepartamentosSinAsignaturas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Departamento>>> C31GetDepartamentosSinAsignaturas()
    {
        try
        {
            var resultado = await _unitOfWork.Departamentos.C31GetDepartamentosSinAsignaturas();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener los departamentos sin asignaturas." });
        }
    }






}