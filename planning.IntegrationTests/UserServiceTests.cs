using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using planning.Entities.DTOs;
using planning.Entities.Entities;
using planning.Services.Contracts;
using Assert = Xunit.Assert;


namespace planning.IntegrationTests;

public class UserServiceTests
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserServiceTests()
    {
        var services = TestUtilities.ConfigureServices();
        _serviceProvider = services.BuildServiceProvider();
        _userService = _serviceProvider.GetRequiredService<IUserService>();
        _mapper = _serviceProvider.GetRequiredService<IMapper>();
    }

    [Fact]
    [Order(1)]
    public async Task TestAddUser()
    {
        // Arrange
        var userDto = new UserDto
        {
            FirstName = "John",
            LastName = "Doe"
        };
        
        // Act
        var user = _mapper.Map<User>(userDto);
        await _userService.Create(user);
        var userCreated = await _userService.Get(user.Id);
        
        // Assert
        Assert.Equal(user, userCreated);
    }
    
    [Fact]
    [Order(2)]
    public async Task TestAddGroupToUser()
    {
        // Arrange
        var userDto = new UserDto
        {
            FirstName = "John",
            LastName = "Doe"
        };
        var groupDto = new GroupDto
        {
            Name = "Group 1"
        };
        
        // Act
        var user = _mapper.Map<User>(userDto);
        var group = _mapper.Map<Group>(groupDto);
        
        await _userService.Create(user);
        await _serviceProvider.GetService<IGroupService>()!.Create(group);
        
        await _userService.AddGroup(user.Id, group.Id);

        var userFetched = await _userService.Get(user.Id);
        
        // Assert
        Assert.Contains(userFetched.Groups, g => g.Id == group.Id);
    }
}