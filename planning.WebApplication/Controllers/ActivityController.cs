using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}