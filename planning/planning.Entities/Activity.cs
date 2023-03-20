using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities;

[Table("Activity")]
public class Activity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Column("Name")]
    public string Name { get; set; } = default!;
    
    public List<User> Users { get; set; } = default!;
}