using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(PlanningDbContext context)
        : base(context)
    {
    }
}