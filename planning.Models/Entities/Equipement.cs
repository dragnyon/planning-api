using System.ComponentModel.DataAnnotations.Schema;

namespace planning.Entities.Entities;

public class Equipement
{
    [ForeignKey(nameof(Ressource))]
    public Guid IdRessource;
    
    [Column(nameof(Nom))]
    public string Nom { get; set; } = default!;
    
    [Column(nameof(Quantite))]
    public int Quantite { get; set; } = default!;
    
    
}