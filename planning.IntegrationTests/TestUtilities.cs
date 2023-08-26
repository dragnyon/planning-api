using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using planning.EntitiesContext;
using planning.Repository;
using planning.Repository.Contracts;
using planning.Services;
using planning.Services.Contracts;
using planning.WebApplication.Configurations;

namespace planning.IntegrationTests;

public static class TestUtilities
{
    public static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        
        // Ajoutez les services de l'application, mais remplacez certains services par des versions mockées ou des versions spécifiques au test
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        
        services.AddDbContext<PlanningDbContext>(options => 
            options.UseInMemoryDatabase(Guid.NewGuid().ToString()));  // Base de données en mémoire avec un nom unique à chaque fois
        
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MapperInitializer()); });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        return services;
    }
}