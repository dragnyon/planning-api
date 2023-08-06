using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class UserService : BaseService<User, IUserRepository>, IUserService
{
    private readonly IGroupRepository _groupRepository;

    public UserService(IUserRepository repository, IGroupRepository groupRepository) : base(repository)
    {
        _groupRepository = groupRepository;
    }

    public async Task AddGroup(Guid userId, Guid groupId)
    {
        var user = await _repository.Get(userId);
        var group = await _groupRepository.Get(groupId);
        user.Groups.Add(group);
        group.Users.Add(user);
        _repository.Update(user);
        _groupRepository.Update(group);
        await _repository.Save();
    }
}