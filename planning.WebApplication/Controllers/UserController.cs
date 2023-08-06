using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using planning.Entities.DTOs;
using planning.Entities.Entities;
using planning.Entities.Wrappers;
using planning.Services.Contracts;

namespace planning.WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAll();
        var usersWrapped = _mapper.Map<IList<UserWrapper>>(users);

        return Ok(usersWrapped);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDto user)
    {
        var userEntity = _mapper.Map<User>(user);
        await _userService.Create(userEntity);

        return Ok();
    }

    [HttpPost]
    [Route("{userId}/addGroup/{groupId}")]
    public async Task AddGroup(Guid userId, Guid groupId)
    {
        await _userService.AddGroup(userId, groupId);
    }
}