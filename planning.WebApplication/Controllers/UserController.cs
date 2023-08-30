using System.Linq.Expressions;
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
    [Route("{userId}")]
    public async Task<IActionResult> Get(Guid userId)
    {
        var user = await _userService.Get(userId);
        var userWrapped = _mapper.Map<UserWrapper>(user);

        return Ok(userWrapped);
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

    [HttpPost]
    [Route("{userId}/deleteGroup/{groupId}")]
    public async Task DeleteGroup(Guid userId, Guid groupId)
    {
        await _userService.DeleteGroup(userId, groupId);
    }

    [HttpPut]
    [Route("{userId}")]
    public async Task Update(Guid userId, UserDto user)
    {
        var userEntity = _mapper.Map<User>(user);
        userEntity.Id = userId;
        await _userService.Update(userEntity);
    }
    
}