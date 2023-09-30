using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Domain.Entities;
public class Permission : BaseAuditableEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column(nameof(Name))]
    public string Name { get; set; } = default!;
}