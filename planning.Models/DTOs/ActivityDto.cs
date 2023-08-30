using System.ComponentModel.DataAnnotations;

namespace planning.Entities.DTOs;

public class ActivityDto
{
    [Required] [MinLength(1)] public string Name { get; set; } = default!;
}