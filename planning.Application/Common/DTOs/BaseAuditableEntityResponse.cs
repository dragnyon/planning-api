namespace planning.Application.Common.DTOs;

public class BaseAuditableEntityResponse : BaseEntityResponse
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}