using System.ComponentModel.DataAnnotations;

namespace planning.Entities.DTOs;

public class UserDto
{
    [Required] [MinLength(1)] public string LastName { get; set; } = default!;

    [Required] [MinLength(1)] public string FirstName { get; set; } = default!;
    
    [Required] [MinLength(1)] public Guid RoleId { get; set; } = default!;
}