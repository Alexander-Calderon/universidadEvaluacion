using AutoMapper;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using API.Dtos;


namespace API.Controllers;
public class ProfesorController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public ProfesorController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public async Task<ActionResult<List<ProfesorDto>>> GetAll() {
        var profesores = await _unitOfWork.Profesores.GetAll();
        return _mapper.Map<List<ProfesorDto>>(profesores); 
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Profesores.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<ProfesorDto>(dato);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> GuardarCurso(ProfesorDto profesorDto)
    {
        var dato = _mapper.Map<Profesor>(profesorDto);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Profesores.Add(dato);
        await _unitOfWork.SaveAsync();

        return profesorDto;
    }

 
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Profesor>> Actualizar(Profesor profesor)
    {
        var dato = await _unitOfWork.Profesores.GetById(profesor.IdProfesor);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Profesores.Update(dato);
        await _unitOfWork.SaveAsync();

        return profesor;
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProfesorDto>> Borrar(int id)
    {
        var dato = await _unitOfWork.Profesores.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Profesores.Remove(dato);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<ProfesorDto>(dato);
    }



    // Consultas

    


}