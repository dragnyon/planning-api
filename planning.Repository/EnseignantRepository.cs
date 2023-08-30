using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.Repository;

public class EnseignantRepository : BaseRepository<Enseignant>, IEnseignantRepository
{
    protected EnseignantRepository(PlanningDbContext context) : base(context)
    {
    }
}