using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;

[Table("User")]
public class User : BaseEntity
{
    [Column(nameof(LastName))] public string LastName { get; set; } = default!;

    [Column(nameof(FirstName))] public string FirstName { get; set; } = default!;

    public List<Activity> Activities { get; set; } = default!;
    public List<Group> Groups { get; set; } = new();
}