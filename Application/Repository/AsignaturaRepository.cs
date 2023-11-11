
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class AsignaturaRepository : GenericRepository<Asignatura>, IAsignatura
{
    private readonly ApiContext _context;
    public AsignaturaRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    
    
}
