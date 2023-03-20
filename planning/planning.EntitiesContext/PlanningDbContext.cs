using Microsoft.EntityFrameworkCore;
using planning.Entities;

namespace planning.EntitiesContext;

public class PlanningDbContext : DbContext
{
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
}