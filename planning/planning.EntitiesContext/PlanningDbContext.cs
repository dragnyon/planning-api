using Bogus;
using Microsoft.EntityFrameworkCore;
using planning.Entities;

namespace planning.EntitiesContext;

public class PlanningDbContext : DbContext
{
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options)
    {
        var userFaker = new Faker<User>()
            .RuleFor(u => u.Name, f => f.Name.FullName());
        Users.AddRange(userFaker.Generate(50));
        SaveChanges();
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
}