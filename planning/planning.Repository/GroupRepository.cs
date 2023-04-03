using planning.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class GroupRepository : IRepository<Group>
{
    private readonly PlanningDbContext _context;
    public GroupRepository(PlanningDbContext context)
    {
        _context = context;
    }
    public List<Group> GetAll()
    {
        return _context.Groups.ToList();
    }

    public Group Get(Guid id)
    {
        return _context.Groups.FirstOrDefault(g => g.Id==id);
    }

    public void Create(Group entity)
    {
        _context.Groups.Add(entity);
        _context.SaveChanges();
    }
}