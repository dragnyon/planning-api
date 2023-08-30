using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class RessourceRepository : BaseRepository<Ressource>, IRessourceRepository
{
    public RessourceRepository(PlanningDbContext context)
        : base(context)
    {
    }
}