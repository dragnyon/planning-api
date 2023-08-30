namespace planning.Entities.Wrappers;

public class UserWrapper
{
    public Guid Id { get; set; }
    public string LastName { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public List<GroupWrapper> Groups { get; set; } = default!;
}