using System.Linq.Expressions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using planning.Application.Commands.User.CreateUser;
using planning.Entities.DTOs;
using planning.Entities.Entities;
using planning.Entities.Wrappers;
using planning.Services.Contracts;

namespace planning.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : BaseApiController
{

    public UserController(IMediator mediator) : base(mediator)
    {

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
    public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
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