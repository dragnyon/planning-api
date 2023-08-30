using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class EnseignantService : BaseService<Enseignant, IEnseignantRepository>, IEnseignantService
{
    protected EnseignantService(IEnseignantRepository repository, List<Expression<Func<Enseignant, object>>> includes) : base(repository, includes)
    {
    }
}