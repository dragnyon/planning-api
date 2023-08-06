using planning.Attributes;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

[ServiceImplementation]
public class GroupService : BaseService<Group, IGroupRepository>, IGroupService
{
    public GroupService(IGroupRepository repository) : base(repository)
    {
    }
}