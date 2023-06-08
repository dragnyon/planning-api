using planning.Attributes;
using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

[RepositoryImplementation]
public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(PlanningDbContext context)
        : base(context)
    {
    }
}