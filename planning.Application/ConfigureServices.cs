using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using planning.Application.Authentication.Commands.Login;
using planning.Application.Common.Interfaces;
using planning.Application.Common.Mappings;

namespace planning.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.ConfigureDependancies();
        services.ConfigureMapper();

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        return services;
    }

    private static void ConfigureDependancies(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddTransient<LoginCommandValidator>();
        services.AddTransient<SignUpCommandValidator>();
        services.AddTransient<AddOpenAITokenCommandValidator>();
        services.AddTransient<RefreshCommandValidator>();
        services.AddTransient<RequestPasswordResetCommandValidator>();
        services.AddTransient<ResetPasswordCommandValidator>();
        services.AddTransient<DeleteMyAccountCommandValidator>();
        services.AddTransient<AddSystemPromptCommandValidator>();
        services.AddTransient<EditSystemPromptCommandValidator>();
        services.AddTransient<AddMessageCommandValidator>();
        services.AddTransient<AddChatSessionCommandValidator>();
        services.AddTransient<EditChatSessionTitleCommandValidator>();
        services.AddTransient<ForkMessageCommandValidator>();
    }

    private static void ConfigureMapper(this IServiceCollection services)
    {
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new GlobalProfile());
            mc.AddProfile(new CommandsProfile());
            mc.AddProfile(new ResponsesProfile());
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}