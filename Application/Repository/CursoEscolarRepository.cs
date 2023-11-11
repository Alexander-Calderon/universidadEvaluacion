
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class CursoEscolarRepository : GenericRepository<CursoEscolar>, ICursoEscolar
{
    private readonly ApiContext _context;
    public CursoEscolarRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    
}
