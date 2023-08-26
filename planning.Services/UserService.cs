using System.Linq.Expressions;
using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class UserService : BaseService<User, IUserRepository>, IUserService
{
    private readonly IGroupService _groupService;
    public UserService(IUserRepository repository, IGroupService groupService) : base(repository,new List<Expression<Func<User, object>>> 
    { 
        user => user.Groups
    })
    {
        _groupService = groupService;
    }

    public async Task AddGroup(Guid userId, Guid groupId)
    {
        var user = await Get(userId);
        var group = await _groupService.Get(groupId);
        user.Groups.Add(group);
        group.Users.Add(user);
        await Update(user);
        await _groupService.Update(group);
    }

    public async Task DeleteGroup(Guid userId, Guid groupId)
    {
        var user = await Get(userId);
        var group = await _groupService.Get(groupId);
        user.Groups.Remove(group);
        group.Users.Remove(user);
        await Update(user);
        await _groupService.Update(group);
    }
    
}