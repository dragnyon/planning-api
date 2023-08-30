using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class RessourceService : BaseService<Ressource, IRessourceRepository>, IRessourceService
{
    protected RessourceService(IRessourceRepository repository, List<Expression<Func<Ressource, object>>> includes) : base(repository, includes)
    {
        
    }
}