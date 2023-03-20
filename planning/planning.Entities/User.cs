using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities;

[Table("User")]
public class User
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("Name")]
    public string Name { get; set; } = default!;

    public List<Activity> Activities { get; set; } = default!;
}