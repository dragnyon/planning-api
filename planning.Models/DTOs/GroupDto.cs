using System.ComponentModel.DataAnnotations;

namespace planning.Entities.DTOs;

public class GroupDto
{
    [Required] [MinLength(1)] public string Name { get; set; } = default!;
}