using MediatR;
using planning.Application.Authentification.DTOs;

namespace planning.Application.Authentication.Commands.Login;

public class LoginCommand : IRequest<LoginResponse>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}