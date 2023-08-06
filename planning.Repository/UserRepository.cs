using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(PlanningDbContext context)
        : base(context)
    {
    }
}