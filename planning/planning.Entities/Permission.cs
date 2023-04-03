using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities;
[Table("Permission")]
public class Permission
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(nameof(Name))]
    public string Name { get; set; } = default!;
}