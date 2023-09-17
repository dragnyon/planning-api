using System.ComponentModel.DataAnnotations;

namespace planning.Entities.DTOs;

public class RoleDto
{
    [Required] [MinLength(1)] public string Name { get; set; } = default!;
}