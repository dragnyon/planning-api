
using planning.EntitiesContext;
using planning.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configure();

var app = builder.Build();

await app.Configure();

app.Run();