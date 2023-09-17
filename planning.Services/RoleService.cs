using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class RoleService : BaseService<Role, IRoleRepository>, IRoleService
{
    protected RoleService(IRoleRepository repository, List<Expression<Func<Role, object>>> includes) : base(repository, includes)
    {
    }
}