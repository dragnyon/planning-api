using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities;

[Table(nameof(Group))]
public class Group
{
    [Key]
    public Guid Id { get; set; } = default!;
    
    [Column(nameof(Name))]
    public string Name { get; set; } = default!;
    
    public List<User> Users { get; set; } = default!;
    
    public List<Permission> Permissions { get; set; } = default!;

}