using AutoMapper;
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
    }

    private static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
    }

    private static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
    }

    private static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MapperInitializer()); });

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
}