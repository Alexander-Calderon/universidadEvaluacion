
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ProfesorRepository : GenericRepository<Profesor>, IProfesor
{
    private readonly ApiContext _context;
    public ProfesorRepository(ApiContext context) : base(context)
    {
        _context = context;
    }

    // para diccionario anidado
    public override async Task<IEnumerable<Profesor>> GetAll()
    {
        return await _context.Profesores
        .Include(x => x.IdDepartamentoNavigation)
        .Include(x => x.IdProfesorNavigation)
        .ToListAsync();
    }
    

    

    
}