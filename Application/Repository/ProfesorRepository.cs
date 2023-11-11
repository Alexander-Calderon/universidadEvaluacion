
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

    

    

    
}