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


}