namespace planning.Entities.Wrappers;

public class EnseignantWrapper
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Prenom{ get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Code { get; set; } = default!;
}