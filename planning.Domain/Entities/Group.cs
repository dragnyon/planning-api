using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Domain.Entities;

public class Group : BaseAuditableEntity
{
    [Column(nameof(Name))] public string Name { get; set; } = default!;

    public List<User> Users { get; set; } = new();

    public List<Permission> Permissions { get; set; } = default!;
}