using Microsoft.AspNetCore.Mvc;
using planning.Entities;
using planning.EntitiesContext;
using planning.Repository.Contracts;

namespace planning.WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    
    [HttpGet("")]
    public IActionResult Get()
    {
        return Ok(_userRepository.GetAll());
    }
    
    [HttpPost("{username}")]
    public IActionResult Create(string username)
    {
        _userRepository.Create(new User() { Name = username });
        return Ok();
    }
}