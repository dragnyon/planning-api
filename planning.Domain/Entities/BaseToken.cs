namespace planning.Domain.Entities;

public class BaseToken
{
    public string Token { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
}