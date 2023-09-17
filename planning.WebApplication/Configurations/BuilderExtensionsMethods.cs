using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using planning.Attributes;
using planning.Entities.Entities;
using planning.EntitiesContext;
using planning.Repository;
using planning.Repository.Contracts;
using planning.Services;
using planning.Services.Contracts;

namespace planning.WebApplication.Configurations;

public static class BuilderExtensionsMethods
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigureRepositories();
        builder.Services.ConfigureServices();
        builder.Services.ConfigureMapper();
        builder.Services.ConfigureCors();
        builder.Services.ConfigureSgbd(builder.Configuration);
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllersWithViews();
    }
    
    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IActivityRepository, ActivityRepository>();
    }
    
    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IActivityService, ActivityService>();
    }
    
    private static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MapperInitializer());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
    
    private static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(
                "AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }
    
    private static void ConfigureSgbd(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        var type = configuration.GetValue("SGBD_TYPE", "none");
        
        services.AddDbContext<PlanningDbContext>(options =>
        {
            switch (type)
            {
                case "sqlite":
                    options.UseSqlite(connectionString);
                    break;
                case "postgresql":
                    options.UseNpgsql(connectionString);
                    break;
                case "none":
                    options.UseSqlite(connectionString);
                    break;
            }
        });
    }
}