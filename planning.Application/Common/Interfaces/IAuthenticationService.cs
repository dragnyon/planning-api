using planning.Application.Authentification.DTOs;

namespace planning.Application.Common.Interfaces;

public interface IAuthenticationService
{
    Task<LoginResponse> GenerateUserAuthenticationTokens(User user);
}