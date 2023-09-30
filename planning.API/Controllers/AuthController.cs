using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using planning.API.Filters;

namespace planning.API.Controllers;

public class AuthController : BaseApiController
{
    public AuthController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("login")]
    [AllowAnonymous]
    [ValidationModelFilter(typeof(LoginCommandValidator))]
    public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
    {
        var result = await _mediator.Send(loginCommand);

        return Ok(result);
    }


    [HttpPost("signup")]
    [AllowAnonymous]
    [ValidationModelFilter(typeof(SignUpCommandValidator))]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand signUpCommand)
    {
        var result = await _mediator.Send(signUpCommand);

        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPost("refresh")]
    [AllowAnonymous]
    [ValidationModelFilter(typeof(RefreshCommandValidator))]
    public async Task<IActionResult> Refresh([FromBody] RefreshCommand refreshCommand)
    {
        var result = await _mediator.Send(refreshCommand);

        return StatusCode(StatusCodes.Status201Created, result);
    }

    [HttpPost("forgot-password")]
    [AllowAnonymous]
    [ValidationModelFilter(typeof(RequestPasswordResetCommandValidator))]
    public async Task<IActionResult> RequestPasswordReset([FromBody] RequestPasswordResetCommand requestPasswordResetCommand)
    {
        await _mediator.Send(requestPasswordResetCommand);

        return Ok(new { message = "Password reset link sent to email" });
    }

    [HttpPost("reset-password")]
    [Authorize(Policy = "ResetPassword")]
    [ValidationModelFilter(typeof(ResetPasswordCommandValidator))]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordCommand resetPasswordCommand)
    {
        await _mediator.Send(resetPasswordCommand);

        return Ok(new { message = "Password reset successfully" });
    }

    [HttpPost("logout")]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _mediator.Send(new LogoutAllDevicesCommand());

        return Ok(new { Message = "Logout successfully" });
    }
}