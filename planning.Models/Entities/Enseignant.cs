using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;


[Table("Enseignant")]
public class Enseignant : BaseEntity
{
    
    [ForeignKey(nameof(Ressource))]
    public Guid IdRessource;
    
    [Column(nameof(Nom))]
    public string Nom { get; set; } = default!;

    [Column(nameof(Prenom))]
    public string Prenom{ get; set; } = default!;

    [Column(nameof(Email))]
    public string Email { get; set; } = default!;

    [Column(nameof(Code))]
    public string Code { get; set; } = default!;

    
}