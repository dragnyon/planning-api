using System.ComponentModel.DataAnnotations;

namespace planning.Entities.DTOs;

public class EnseignantDto
{
    [Required] [MinLength(1)] public string Name { get; set; } = default!;
    
    string Prenom { get; set; } = default!;
    string Email { get; set; } = default!;
    string Code { get; set; } = default!;
    
}