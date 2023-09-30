using MediatR;
using Microsoft.AspNetCore.Mvc;
using planning.API.Filters;

namespace planning.API.Controllers;

[Route("[controller]")]
[ApiController]
[ApiExceptionFilter]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}