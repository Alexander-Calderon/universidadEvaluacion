
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
{
    private readonly ApiContext _context;
    public DepartamentoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
    
}
