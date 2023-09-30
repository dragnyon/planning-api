using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Domain.Entities;


[Table("nameof(Role)")]
public class Role : BaseAuditableEntity
{
    [Column(nameof(Name))]
    public string Name { get; set; } = default!;
    
    
}