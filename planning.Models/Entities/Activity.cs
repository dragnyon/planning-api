using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;

[Table("Activity")]
public class Activity : BaseEntity
{
    
    [Column("Name")]
    public string Name { get; set; } = default!;

    public List<User> Users { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
}