using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;

[Table("User")]
public class User : BaseEntity
{
    [Column("Name")]
    public string Name { get; set; } = default!;

    public List<Activity> Activities { get; set; } = default!;
}