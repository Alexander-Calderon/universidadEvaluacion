using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using API.Dtos;


namespace API.Controllers;
public class CursoEscolarController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public CursoEscolarController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult<List<CursoEscolarDto>>> GetAll() {
        var cursoescolars = await _unitOfWork.CursosEscolares.GetAll();
        return _mapper.Map<List<CursoEscolarDto>>(cursoescolars); 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> GetById(int id)
    {
        var dato = await _unitOfWork.CursosEscolares.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<CursoEscolarDto>(dato);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> GuardarCurso(CursoEscolarDto param)
    {
        var dato = _mapper.Map<CursoEscolar>(param);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.CursosEscolares.Add(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }

 
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> Actualizar(CursoEscolarDto param)
    {
        var dato = await _unitOfWork.CursosEscolares.GetById(param.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.CursosEscolares.Update(dato);
        await _unitOfWork.SaveAsync();

        return param;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CursoEscolarDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.CursosEscolares.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.CursosEscolares.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CursoEscolarDto>(dato);
    }



    // Consultas

    


}