using System.ComponentModel.DataAnnotations.Schema;
using planning.Domain.Entities;

namespace planning.Domain.Entities;

public class User : BaseAuditableEntity
{
    [Column(nameof(LastName))] public string LastName { get; set; } = default!;

    [Column(nameof(FirstName))] public string FirstName { get; set; } = default!;

    public List<Activity> Activities { get; set; } = default!;
    public List<Group> Groups { get; set; } = default!;

    public List<Role> Roles { get; set; } = default!;

}