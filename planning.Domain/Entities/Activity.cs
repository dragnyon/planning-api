using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Domain.Entities;

public class Activity : BaseAuditableEntity
{
    
    [Column("Name")]
    public string Name { get; set; } = default!;

    public List<User> Users { get; set; } = default!;
    
    public DateTime Date { get; set; } = default!;
}