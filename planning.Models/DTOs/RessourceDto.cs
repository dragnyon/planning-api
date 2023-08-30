using System.ComponentModel.DataAnnotations;

namespace planning.Entities.DTOs;

public class RessourceDto
{
    [Required] [MinLength(1)] public string Type { get; set; } = default!;
}