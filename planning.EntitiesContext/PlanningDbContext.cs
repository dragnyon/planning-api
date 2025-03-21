﻿using Bogus;
using Microsoft.EntityFrameworkCore;
using planning.Entities.Entities;

namespace planning.EntitiesContext;

public class PlanningDbContext : DbContext
{
    public PlanningDbContext(DbContextOptions<PlanningDbContext> options) : base(options)
    {
        //var userFaker = new Faker<User>()
        //    .RuleFor(u => u.Name, f => f.Name.FullName());
        //Users.AddRange(userFaker.Generate(50));
        //SaveChanges();
    }
    
    public PlanningDbContext CreateContextForInMemory()
    {
        var option = new DbContextOptionsBuilder<PlanningDbContext>()
            .UseInMemoryDatabase(databaseName: "Test_Database") // Choisissez un nom unique pour chaque test si nécessaire
            .Options;
        var context = new PlanningDbContext(option);
        return context;
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Permission> Permissions { get; set; }

}