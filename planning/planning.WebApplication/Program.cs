using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using planning.Entities;
using planning.EntitiesContext;
using planning.Repository;
using planning.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PlanningDbContext>(options =>
{
    //options.UseNpgsql(builder.Configuration.GetConnectionString("postgresql"));
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
});

builder.Services.AddScoped<IRepository<User>, UserRepository>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
using var context = services.GetRequiredService<PlanningDbContext>();
context.Database.EnsureCreated();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();