
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;
public class GradoRepository : GenericRepository<Grado>, IGrado
{
    private readonly ApiContext _context;
    public GradoRepository(ApiContext context) : base(context)
    {
        _context = context;
    }
}
