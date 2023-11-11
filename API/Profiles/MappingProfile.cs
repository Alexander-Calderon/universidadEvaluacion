
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
        CreateMap<Grado, GradoDto>()
        .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreGrado))
        .ReverseMap();
        CreateMap<Persona,PersonaDto>().ReverseMap();
        CreateMap<Profesor,ProfesorDto>()
        .ForMember(dest => dest.Profesor, opt => opt.MapFrom(src => src.IdProfesorNavigation))
        .ReverseMap();
        
        CreateMap<Persona, AlumnoLightDto>().ReverseMap();
        
    }
}
