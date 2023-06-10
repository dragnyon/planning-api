using planning.Entities.Entities;
using planning.Repository.Contracts;
using planning.Services.Contracts;

namespace planning.Services;

public class UserService : BaseService<User, IUserRepository>, IUserService
{
    public UserService(IUserRepository repository) : base(repository)
    {
    }
}