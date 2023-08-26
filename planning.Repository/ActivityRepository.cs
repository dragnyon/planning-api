using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
{
    public ActivityRepository(PlanningDbContext context)
        : base(context)
    {
    }
}