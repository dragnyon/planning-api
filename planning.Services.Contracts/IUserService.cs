using planning.Entities.Entities;
using planning.Repository.Contracts;

namespace planning.Services.Contracts;

public interface IUserService : IBaseService<User, IUserRepository>
{
    Task AddGroup(Guid userId, Guid groupId);
}