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

    


}