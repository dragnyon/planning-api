using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;

public class Salle : BaseEntity
{
    [ForeignKey(nameof(Ressource))]
    public Guid IdRessource;
    
    [Column(nameof(Nom))]
    public string Nom { get; set; } = default!;
    
    [Column(nameof(Ville))]
    public string Ville { get; set; } = default!;
    
    [Column(nameof(Batiment))]
    public string Batiment { get; set; } = default!;
    
    [Column(nameof(Numero))]
    public string Numero { get; set; } = default!;
    
    [Column(nameof(Etage))]
    public int Etage { get; set; } = default!;
}