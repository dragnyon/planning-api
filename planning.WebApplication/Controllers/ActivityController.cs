using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using planning.Entities.DTOs;
using planning.Entities.Entities;
using planning.Entities.Wrappers;
using planning.Services;
using planning.Services.Contracts;

namespace planning.WebApplication.Controllers;


[ApiController]
[Route("[controller]")]

public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;
    private readonly IMapper _mapper;
    
    
    public ActivityController(IActivityService activityService, IMapper mapper)
    {
        _activityService = activityService;
        _mapper = mapper;
    }
    
    
    [HttpGet]
    [Route("{activityId}")]
    public async Task<IActionResult> Get(Guid activityId)
    {
        var group = await _activityService.Get(activityId);
        var groupWrapped = _mapper.Map<ActivityWrapper>(group);

        return Ok(groupWrapped);
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var activities = await _activityService.GetAll();
        var activitiesWrapped = _mapper.Map<IList<ActivityWrapper>>(activities);

        return Ok(activitiesWrapped);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(ActivityDto activity)
    {
        var activityEntity = _mapper.Map<Activity>(activity);
        await _activityService.Create(activityEntity);

        return Ok();
    }
    
    [HttpPut]
    [Route("{activityId}")]
    public async Task Update(Guid activityId, ActivityDto activity)
    {
        var activityEntity = _mapper.Map<Activity>(activity);
        activityEntity.Id = activityId;
        await _activityService.Update(activityEntity);
    }
    
    
    
    
    
    
    
    
    
    
    
   
    
    
}