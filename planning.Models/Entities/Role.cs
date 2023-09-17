using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;


[Table("nameof(Role)")]
public class Role : BaseEntity
{
    [Column(nameof(Name))]
    public string Name { get; set; } = default!;
    
    
}