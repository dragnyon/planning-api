using planning.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class UserRepository : IRepository<User>
{
    private readonly PlanningDbContext _context;

    public UserRepository(PlanningDbContext context)
    {
        _context = context;
    }
    
    public List<User> GetAll()
    {
        return _context.Users.ToList();
    }

    public User Get(Guid id)
    {
        return _context.Users.FirstOrDefault(u => u.Id == id);
    }

    public void Create(User entity)
    {
        _context.Users.Add(entity);
        _context.SaveChanges();
    }
}