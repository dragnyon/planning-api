using planning.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class PermissionRepository : IRepository<Permission>
{
    private readonly PlanningDbContext _context;
    public PermissionRepository(PlanningDbContext context)
    {
        _context = context;
    }
    public List<Permission> GetAll()
    {
        return _context.Permissions.ToList();
    }

    public Permission Get(Guid id)
    {
        return _context.Permissions.FirstOrDefault(p => p.Id==id);
    }

    public void Create(Permission entity)
    {
        _context.Permissions.Add(entity);
        _context.SaveChanges();
    }
}