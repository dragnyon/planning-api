using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using planning.Entities.Wrappers;
using planning.Services.Contracts;

namespace planning.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IRoleService _userService;

    public RoleController(IRoleService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [Route("{roleId}")]
    public async Task<IActionResult> Get(Guid roleId)
    {
        var role = await _userService.Get(roleId);
        var userWrapped = _mapper.Map<RoleWrapper>(role);

        return Ok(userWrapped);
    }
    
    
    
    
    
    
}