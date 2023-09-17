using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using planning.EntitiesContext;
using planning.Repository;
using planning.Repository.Contracts;
using planning.WebApplication.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Configure();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
using var context = services.GetRequiredService<PlanningDbContext>();
context.Database.EnsureCreated();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();