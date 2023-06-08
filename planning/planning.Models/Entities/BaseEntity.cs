using System.ComponentModel.DataAnnotations;

namespace planning.Entities.Entities;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
}