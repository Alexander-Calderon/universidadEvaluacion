
using API.Dtos;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.Entities;
namespace API.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile(){


        CreateMap<Asignatura, AsignaturaDto>().ReverseMap();
        CreateMap<CursoEscolar, CursoEscolarDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Grado, GradoDto>().ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Profesor,ProfesorDto>().ReverseMap();
        
        
        
    }
}
