
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class PersonaRepository : GenericRepository<Persona>, IPersona
{
    private readonly ApiContext _context;
    public PersonaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    
}
