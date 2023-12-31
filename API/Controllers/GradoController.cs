using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using API.Dtos;


namespace API.Controllers;
public class GradoController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public GradoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult<List<GradoDto>>> GetAll() {
        var grados = await _unitOfWork.Grados.GetAll();
        return _mapper.Map<List<GradoDto>>(grados); 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Grados.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<GradoDto>(dato);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> GuardarCurso(GradoDto param)
    {
        var dato = _mapper.Map<Grado>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Grados.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }

 
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> Actualizar(GradoDto param)
    {
        var dato = await _unitOfWork.Grados.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Grados.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GradoDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Grados.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Grados.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<GradoDto>(dato);
    }



    // Consultas

    [HttpGet("C21GetTodosGradosConAsignaturas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C21GetTodosGradosConAsignaturas()
    {
        try
        {
            var resultado = await _unitOfWork.Grados.C21GetTodosGradosConAsignaturas();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener la información de los grados con asignaturas." });
        }
    }


    [HttpGet("C22GetGradosConMasDe40Asignaturas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C22GetGradosConMasDe40Asignaturas()
    {
        try
        {
            var resultado = await _unitOfWork.Grados.C22GetGradosConMasDe40Asignaturas();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener los grados con más de 40 asignaturas." });
        }
    }

    [HttpGet("C23GetSumaCreditosPorTipoAsignatura")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<object>>> C23GetSumaCreditosPorTipoAsignatura()
    {
        try
        {
            var resultado = await _unitOfWork.Grados.C23GetSumaCreditosPorTipoAsignatura();
            return Ok(resultado);
        }
        catch (Exception)
        {
            return StatusCode(500, new { MensajeError = "Error al obtener la suma de créditos por tipo de asignatura." });
        }
    }




}