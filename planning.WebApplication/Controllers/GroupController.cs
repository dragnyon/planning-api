using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using planning.Entities.DTOs;
using planning.Entities.Entities;
using planning.Entities.Wrappers;
using planning.Services.Contracts;

namespace planning.WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;
    private readonly IMapper _mapper;


    public GroupController(IGroupService groupService, IMapper mapper)
    {
        _groupService = groupService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("{groupId}")]
    public async Task<IActionResult> Get(Guid groupId)
    {
        var group = await _groupService.Get(groupId);
        var groupWrapped = _mapper.Map<GroupWrapper>(group);

        return Ok(groupWrapped);
    }
    
    
    
    
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _groupService.GetAll();
        var groupsWrapped = _mapper.Map<IList<GroupWrapper>>(groups);

        return Ok(groupsWrapped);
    }


    [HttpPost]
    public async Task<IActionResult> Create(GroupDto group)
    {
        var groupEntity = _mapper.Map<Group>(group);
        await _groupService.Create(groupEntity);

        return Ok();
    }
    
    [HttpPut]
    [Route("{groupId}")]
    public async Task Update(Guid groupId, GroupDto group)
    {
        var groupEntity = _mapper.Map<Group>(group);
        groupEntity.Id = groupId;
        await _groupService.Update(groupEntity);
    }
}