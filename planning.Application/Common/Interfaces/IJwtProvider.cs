namespace planning.Application.Common.Interfaces;

public interface IJwtProvider
{
    string Generate(User user, JwtType type);
}