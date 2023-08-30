using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;



[Table("Ressourse")]
public class Ressource : BaseEntity
{
    [Key]
    public Guid IdRessource;
    
    [Column(nameof(Type))]
    public string Type { get; set; } = default!;
    

}